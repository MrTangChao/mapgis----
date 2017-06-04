using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MapGIS.GISControl;
using MapGIS.GeoMap;
using MapGIS.UI.Controls;
using MapGIS.WorkSpaceEngine;
using MapGIS.GeoDataBase;
using MapGIS.GeoObjects;
using MapGIS.GeoDataBase.Convert;
using MapGIS.GeoObjects.Geometry;
using MapGIS.GISControl.IATool;

namespace MapDocOperate
{
    public partial class MainForm : Form
    {
        //在SplitContainer添加MapControl控件
        MapControl mapCtrl = new MapControl();
        //在SplitContainer添加AttControl控件
        AttControl attCtrl = new AttControl();
        //工作空间树
        MapWorkSpaceTree _Tree = new MapWorkSpaceTree();

        void test()
        {
            //设置转换源数据url,67数据为区简单要素类
            string SrcUrl = @"D:\武汉地质调查中心---矿产资源潜力评价项目\广西壮族自治区\铝土矿种潜力评价图库\DZ_成矿地质背景\CJGZ_预测工作区沉积建造构造图\JWMAP_经纬坐标图件\MDZCJGZDFSPX_扶绥-凭祥预测工作区沉积建造构造图\LDLYAAB002.WT";
            //目的数据的名称
            string DesSFname = "convertsfcls";

            SFeatureCls decsfc = null;

            Server Svr = null;
            DataBase GDB = null;

            Svr = new Server();

            Svr.Connect("MapGISLocal", "", "");
            GDB = Svr.OpenGDB("test");

            decsfc = new SFeatureCls(GDB);

            //创建区简单要素类目的数据
            decsfc.Create(DesSFname, GeomType.Pnt, 0, 0, null);

            //设置转换类型
            DataConvert dataConvert = new DataConvert();
            dataConvert.SetOption(ConvertOptionType.OPT_6TO7, 0);

            //打开源数据和目的数据
            if (dataConvert.OpenSource(SrcUrl) > 0 && dataConvert.OpenDestination(decsfc) > 0)
            {
                //转换数据
                bool rtn = dataConvert.Convert() > 0;
                if (rtn)
                {
                    MessageBox.Show("数据迁移成功");
                }
                else
                {

                    MessageBox.Show("数据转换失败");
                }
                dataConvert.Close();
                decsfc.Close();
            }

        }
        public MainForm()
        {
            InitializeComponent();
            //test();
            //布局界面
            initControls();
            //注册文档树事件  
            _Tree.Document.ClosedDocument += new Document.ClosedDocumentHandle(Document_ClosedDocument);
            _Tree.Document.ClosingDocument += new Document.ClosingDocumentHandle(Document_ClosingDocument);
            _Tree.MenuItemOnClickEvent += new MenuItemOnClickHandler(_Tree_MenuItemOnClickEvent);
            _Tree.Document.GetMaps().RemoveMap += new Maps.RemoveMapHandle(MainForm_RemoveMap);
        }

        #region  窗体事件
        private void MainForm_Load(object sender, EventArgs e)
        {                    
            //新建一个文档树
            _Tree.WorkSpace.BeginUpdateTree();

            _Tree.Document.Title = "地图文档";
            _Tree.Document.New();

            //在地图文档下添加一个地图
            Map map = new Map();
            map.Name = "新地图";
            _Tree.Document.GetMaps().Append(map);
            //将该地图设置为MapConrol的激活地图
            this.mapCtrl.ActiveMap = map;
            this.mapCtrl.Restore();

            //展开所有的节点
            _Tree.ExpandAll();
            _Tree.WorkSpace.EndUpdateTree();

            return;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._Tree.Document.IsDirty)
            {
                this._Tree.WorkSpace.BeginUpdateTree();
                this._Tree.Document.Close(false);
                this._Tree.WorkSpace.EndUpdateTree();
            }
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            initControls();
        }
        #endregion      

        #region  文档树各种响应事件

        void Document_ClosedDocument(object sender, EventArgs e)
        {
            this.mapCtrl.ActiveMap = null;
            this.mapCtrl.Restore();

            return;
        }

        void Document_ClosingDocument(object sender, ClosingDocumentEventArgs e)
        {
            if (this._Tree.Document.IsDirty )
            {
                if (MessageBox.Show("是否保存地图文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    this._Tree.Document.Save();
                }
            }

            return;
        }

        void _Tree_MenuItemOnClickEvent(string typeName, DocumentItem item)
        {
            //点击工作空间树中地图的右键菜单中的“预览地图”
      
            if (typeName == "MapGIS.WorkSpace.Style.PreviewMap" && item.DocItemType == DocItemType.Map)
            {
                //获取地图
                Map map = item as Map;
                this.mapCtrl.ActiveMap = map;
                this.mapCtrl.Restore();
            }
            return;
        }

        //移除地图操作触发的事件
        void MainForm_RemoveMap(object sender, MapsEventArgs e)
        {
            this.mapCtrl.ActiveMap = null;
            this.mapCtrl.Restore();
        }

        #endregion

        #region   地图操作
        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //地图放大
            mapCtrl.ZoomIn();
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //地图缩小
            mapCtrl.ZoomOut();
        }

        private void 复位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //地图复位
            mapCtrl.Restore();
        }

        private void 移动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //地图移动
            mapCtrl.Move();
        }

        private void 添加地图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._Tree.Document != null)
            {
                Map map = new Map();
                map.Name = "自定义添加地图";
                int i = this._Tree.Document.GetMaps().Append(map);
                if (i >= 0)
                    MessageBox.Show("成功在文档树上添加了一幅新地图！");
                else
                    MessageBox.Show("添加失败");
            }
            return;
        }
 #endregion

        #region 地图文档操作

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            //地图文档
            Document doc = _Tree.Document;

            if (doc.Close(false))
            {                
                OpenFileDialog mapxDialog = new OpenFileDialog();
                mapxDialog.Filter = ".mapx(地图文档)|*.mapx|.map(地图文档)|*.map|.mbag(地图包)|*.mbag";
                if (mapxDialog.ShowDialog() != DialogResult.OK)
                    return;
                string mapUrl = mapxDialog.FileName;
                //打开地图文档
                doc.Open(mapUrl);                
            }

            Maps maps = doc.GetMaps();
            if (maps.Count > 0)
            {
                //获取当前第一个地图
                Map map = maps.GetMap(0);
                //设置地图的第一个图层为激活状态
                map.get_Layer(0).State = LayerState.Active;
                this.mapCtrl.ActiveMap = map;
                this.mapCtrl.Restore();
            }
            return;     
        }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = this._Tree.Document;

            _Tree.WorkSpace.BeginUpdateTree();

            if (!_Tree.Document.Close(false))
                return;
            doc.Title = "中地数码";
            int rtn = doc.New();

            _Tree.WorkSpace.EndUpdateTree();
            
            return;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = null;
            doc = this._Tree.Document;
            if (doc != null)
            {
                doc.Save();
            }
            return;
        }
 #endregion 

        #region 图层操作     

        private void 添加图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断地图视图中是否有处于显示状态中的地图
            if (this.mapCtrl.ActiveMap == null)
            {
                MessageBox.Show("请先在地图视图中显示一幅地图！！！");
                return;
            }

            //选择待添加的图层
            GDBOpenFileDialog ofDlg = new GDBOpenFileDialog();
            //ofDlg.Filter = "简单要素类、注记类|sfcls;acls";
            if (ofDlg.ShowDialog() != DialogResult.OK)
                return;
            string fileName = ofDlg.FileName;
            
            IVectorCls   sfcls = new SFeatureCls();
            
            if (sfcls.Open(fileName))
                MessageBox.Show("打开成功");
            else
                MessageBox.Show("打开失败");
            return;
            this._Tree.WorkSpace.BeginUpdateTree();

            //附加矢量图层
            VectorLayer vecLayer = new VectorLayer(VectorLayerType.SFclsLayer);
            vecLayer.AttachData(sfcls);
            //将图层添加到地图中
            vecLayer.Name = sfcls.ClsName;
            //获取激活地图
            Map activeMap = this.mapCtrl.ActiveMap;
            activeMap.Append(vecLayer);
            //复位
            this.mapCtrl.ActiveMap = activeMap;
            this.mapCtrl.Restore();

            this._Tree.WorkSpace.EndUpdateTree();

            return;
        }

        private void 删除地图中第一个图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断地图视图中是否有处于显示状态中的地图
            if (this.mapCtrl.ActiveMap == null)
            {
                MessageBox.Show("请先在地图视图中显示一幅地图！！！");
                return;
            }

            //获取激活地图
            Map map = this.mapCtrl.ActiveMap;
            //判断地图中是否有图层
            if (map.LayerCount < 1)
            {
                MessageBox.Show("操作失败，地图中没有图层！！！");
                return;
            }
            //删除地图的第一个图层
            bool rtn = map.Remove(0);
            if (rtn)
            {
                this.mapCtrl.ActiveMap = map;
                this.mapCtrl.Restore();
                this.attCtrl.SetXCls(null, null);
            }

            return;
        }

        private void 查看地图中第一个图层的属性记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断地图视图中是否有处于显示状态中的地图
            if (this.mapCtrl.ActiveMap == null)
            {
                MessageBox.Show("请先在地图视图中显示一幅地图！！！");
                return;
            }

            //获取激活地图
            Map map = this.mapCtrl.ActiveMap;
            //判断地图中是否有图层
            if (map.LayerCount < 1)
            {
                MessageBox.Show("操作失败，地图中没有图层！！！");
                return;
            }

            //获取地图中第一个图层的属性表
            VectorLayer vecLayer = map.get_Layer(0) as VectorLayer;

            RecordSet rcdSet = null;
            QueryDef qryDef = new QueryDef();

            IVectorCls vecCls = vecLayer.GetData() as IVectorCls;

            rcdSet = vecCls.Select(qryDef);

            this.attCtrl.SetXCls(vecCls, rcdSet);

            return;
        }     
           
        #endregion


        /// <summary>
        /// 初始化 文档树、地图视图、属性视图控件在界面上的布局
        /// </summary>
        public void initControls()
        {
            //MapControl控件占Panel2的三分之二的空间
            this.splitContainer1.Panel2.Controls.Add(mapCtrl);
            mapCtrl.Width = this.splitContainer1.Panel2.Width;
            mapCtrl.Height = this.splitContainer1.Panel2.Height * 2 / 3;

            //AttControl控件占Panel2的三分之一的空间
            this.splitContainer1.Panel2.Controls.Add(attCtrl);
            attCtrl.Width = this.splitContainer1.Panel2.Width;
            attCtrl.Top = mapCtrl.Bottom;
            attCtrl.Height = this.splitContainer1.Panel2.Height - mapCtrl.Height;

            //工作空间树控件加载到Panel1上
            _Tree.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(_Tree);

            this.mapCtrl.MouseClick += new EventHandler(mapCtrl_MouseClick);
            this.mapCtrl.Click += new EventHandler(mapCtrl_Click);
            //注册鼠标移动事件
            this.mapCtrl.MouseMove +=new MouseEventHandler(mapCtrl_MouseMove);
            this.mapCtrl.MouseDown += new MouseEventHandler(mapCtrl_MouseDown);

        }
        private void mapCtrl_MouseClick(object sender, EventArgs e)
        {
            MouseEventArgs mea = e as MouseEventArgs;
            //MessageBox.Show(string.Format("x={0},y={1}", mea.X, mea.Y));
        }
        private void mapCtrl_Click(object sender, EventArgs e)
        {
            MouseEventArgs mea = e as MouseEventArgs;
            //MessageBox.Show(string.Format("mouseclick: x={0},y={1}", mea.X, mea.Y));
        }
        private void mapCtrl_MouseDown(object sender, EventArgs e)
        {
            MouseEventArgs mea = e as MouseEventArgs;
//             //查询相关变量
//             QueryDef def = null;
//             SelectSet set = null;
//             SelectOption option = null;
//             Transformation trans = null;
// 
//             trans = mapCtrl.Transformation;
//             def = new QueryDef();
//             def.SetRect(new Rect(mea.X - 1, mea.Y - 1, mea.X + 1, mea.Y + 1), SpaQueryMode.Intersect);
//             option = new SelectOption();
//             option.DataType = SelectDataType.AnyVector;
//             option.LayerCtrl = SelectLayerControl.All;
//             option.SelMode = SelectMode.Multiply;
//             option.UnMode = UnionMode.Add;
//             IVectorCls VectorCls = new SFeatureCls();
//             VectorCls = this.mapCtrl.ActiveMap.get_Layer(0).GetData() as IVectorCls;
//             RecordSet _RecordSet = VectorCls.Select(def);
//             if (_RecordSet != null)
//             {
//                 int num = _RecordSet.Count;
//                 MessageBox.Show("查询结果为" + num);
//             }
//             else
//             {
//                 MessageBox.Show("没查询");
//             }
// 
//             set = this.mapCtrl.ActiveMap.Select(def, true, trans, option);
//             this.mapCtrl.FlashSelectSet();

        }
        //鼠标移动事件
        void mapCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            //添加代码，进行其他操作 
            MouseEventArgs mea = e as MouseEventArgs;
           // MessageBox.Show(string.Format("x={0},y={1}", mea.X, mea.Y));
        }

        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map acMap = this.mapCtrl.ActiveMap;
            MapLayer mapLayer = null;
            if (acMap.LayerCount > 0)
            {
               mapLayer = acMap.get_Layer(0);
            }
            SFeatureCls Sfcls = mapLayer.GetData() as SFeatureCls;
            FileLayer6x file6x = mapLayer as FileLayer6x;
            
            VectorLayer veclayer = file6x.get_Item(0) as VectorLayer;
            Sfcls = veclayer.GetData() as SFeatureCls;

            SFeatureCls tesfcl = new SFeatureCls();
            if (!tesfcl.Open("file:///c:\\users\\tangchao\\desktop\\ppp.wp"))
            {
                int i = 0;
            }
           
            QueryDef def = new QueryDef();
            def.Filter = "NAME=吉林省";
            RecordSet rst = Sfcls.Select(def);
            this.mapCtrl.FlashSelectSet();
            //设置为拉框查询
            SelectType seltype = SelectType.Rectangle;
            //创建拉框选择类对象
            mapCtrl.SetBasTool(null);
            CirSelectToolClass basTool = new CirSelectToolClass(mapCtrl, SelectDataType.Anyone, attCtrl, seltype);
            mapCtrl.SetBasTool(basTool);
            
        }

        private void 闪烁ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mapCtrl.EndFlash();
            IVectorCls VectorCls = new SFeatureCls();
            if (!VectorCls.Open("file:///c:\\users\\tangchao\\desktop\\ppp.wp"))
            {
                int i = 0;
            }
//             DataConvert dc = new DataConvert();
//             if (dc.OpenSource(VectorCls) > 0 && dc.OpenDestination("c:\\users\\tangchao\\desktop\\ppptrr.wp") > 0)
//             {
//                 dc.Convert();
//             }
            QueryDef def1 = new QueryDef();
            def1.Filter = "NAME='黑龙江省            'or ID > 3";
            SelectOption option = null;

            option = new SelectOption();
            //类型是点、线、区、注记的图层均属于查询范围
            option.DataType = SelectDataType.AnyVector;
            //当前地图中所有图层
            option.LayerCtrl = SelectLayerControl.Visible;
            //多选
            option.SelMode = SelectMode.Multiply;
            //结果数据累加
            option.UnMode = UnionMode.Add;
            //查询
            SelectSet set = this.mapCtrl.ActiveMap.Select(def1, true, null, option);

            this.mapCtrl.FlashSelectSet();
            return;
            RecordSet rst1 = VectorCls.Select(def1);

            Map acMap = this.mapCtrl.ActiveMap;
            MapLayer mapLayer = null;
            if (acMap.LayerCount > 0)
            {
                mapLayer = acMap.get_Layer(0);
            }
            SFeatureCls Sfcls = mapLayer.GetData() as SFeatureCls;
            FileLayer6x file6x = mapLayer as FileLayer6x;
            VectorLayer veclayer = file6x.get_Item(0) as VectorLayer;
            Sfcls = veclayer.GetData() as SFeatureCls;

            QueryDef def = new QueryDef();
            def.Filter = "ID>6";
            RecordSet rst = Sfcls.Select(def);
            if (rst == null||rst.Count == 0)
            {
                MessageBox.Show("未查询到数据");
                return;
            }
            this.attCtrl.SetXCls(Sfcls, rst);
            SelectSet sleset = this.mapCtrl.ActiveMap.GetSelectSet();
            sleset.Append(mapLayer, rst);
            this.mapCtrl.FlashSelectSet();
        }

        private void 添加图层ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;
        }


    }
}