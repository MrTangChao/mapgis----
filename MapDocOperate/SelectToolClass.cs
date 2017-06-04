using System;
using System.Collections.Generic;
using System.Text;
using MapGIS.GISControl;
using MapGIS.GISControl.IATool;
using System.Windows.Forms;
using MapGIS.GeoMap;
using MapGIS.GeoDataBase;
using MapGIS.GeoObjects.Geometry;
using MapGIS.PluginEngine;

namespace MapDocOperate
{
    class CirSelectToolClass : GISBasTool
    {
        //地图视图控件
        MapControl mapCtrl;
        //交互工具：选择工具控件
        SelectTool selTool;
        //选择数据时的数据类型过滤 
        SelectDataType dataType;
        //地理类对象基类接口 
        IBasCls basClass = null;
        //结果集对象
        RecordSet rcdSet = null;
        //属性视图控件
        AttControl attCtrl = null;
        //查询选择方式：圆选择、多边形选择、矩形选择 
        SelectType selectType;

        /// <summary>
        /// 实现圆选择查询
        /// </summary>
        /// <param name="control">地图视图控件</param>
        /// <param name="dataType">选择数据时的数据类型过滤</param>
        /// <param name="attctr">属性视图控件</param>
        /// <param name="seltype">查询选择方式：圆查询 </param>
        public CirSelectToolClass(MapGIS.GISControl.MapControl control, SelectDataType dataType, AttControl attctr, SelectType seltype)
            : base()
        {

            this.mapCtrl = control;
            this.dataType = dataType;
            this.attCtrl = attctr;
            this.selectType = seltype;

            //查询选择项
            SelectOption selOpt = new SelectOption();
            selOpt.DataType = dataType;  //选择数据时的类型过滤类型  
            selOpt.SelMode = SelectMode.Multiply; //选择模式  
            selOpt.UnMode = UnionMode.Xor;  //结果数据合并模式  
            selOpt.LayerCtrl = SelectLayerControl.All; //选择数据时的图层过滤类型 

            //创建圆交互工具
            selTool = new SelectTool(control, selectType, selOpt, SpaQueryMode.MBRIntersect, control.Transformation);
            selTool.Selected += new SelectTool.SelectHandler(selTool_Selected);
            this.Active += new ToolEventHandler(CirSelectToolClass_Active);
            this.Unactive += new ToolEventHandler(CirSelectToolClass_Unactive);
            this.Cancel += new ToolEventHandler(CirSelectToolClass_Cancel);
            this.PreRefresh += new ToolEventHandler(CirSelectToolClass_PreRefresh);
            this.PostRefresh += new ToolEventHandler(CirSelectToolClass_PostRefresh);

        }

        #region 事件响应实现
        void CirSelectToolClass_Active(object sender, ToolEventArgs e)
        {
            this.mapCtrl.Cursor = Cursors.Arrow;
            this.selTool.Start();
        }
        void CirSelectToolClass_Unactive(object sender, ToolEventArgs e)
        {
            this.mapCtrl.Cursor = Cursors.Default;
            this.selTool.Pause();
        }
        void CirSelectToolClass_Cancel(object sender, ToolEventArgs e)
        {
            this.selTool.Cancel();
        }
        void CirSelectToolClass_PreRefresh(object sender, ToolEventArgs e)
        {
            return;
        }
        void CirSelectToolClass_PostRefresh(object sender, ToolEventArgs e)
        {
            this.selTool.PostRefresh();
        }
        #endregion

        #region  重写GISBasTool方法
        public override int OnKeyDown(object sender, KeyEventArgs e)
        {

            return 0;
        }
        public override int OnKeyUp(object sender, KeyEventArgs e)
        {
            return 0;
        }
        public override int OnMouseDbClick(object sender, MouseEventArgs e)
        {
            return 0;
        }
        public override int OnMouseDown(object sender, MouseEventArgs e)
        {

            this.mapCtrl.EndFlash();
            //this.mapCtrl.ActiveMap.GetSelectSet().Clear();
            this.selTool.OnMouseDown(sender, e);
            if (e.Button == MouseButtons.Left)
            {
                this.mapCtrl.Cursor = Cursors.Arrow;
            }
            return 0;
        }
        public override int OnMouseMove(object sender, MouseEventArgs e)
        {
            this.selTool.OnMouseMove(sender, e);
            return 0;
        }
        public override int OnMouseUp(object sender, MouseEventArgs e)
        {
            this.selTool.OnMouseUp(sender, e);
            return 0;
        }
        public override int OnMouseWheel(object sender, MouseEventArgs e)
        {
            return 0;
        }
        public override int OnContextMenu(int X, int Y)
        {
            return 0;
        }
        #endregion

        #region SelectTool的Selected事件响应
        void selTool_Selected(object sender, SelectEventArgs e)
        {
            if (e.SelSet != null)
            {
                this.mapCtrl.FlashSelectSet();
                int objCount = getSelectSetCount(e.SelSet);
                MessageBox.Show("共选择了" + objCount + "个图元");
            }
        }
        #endregion

        public int getSelectSetCount(SelectSet set)
        {
            int count = 0;
            //记录符合选择项的ids
            ObjectIDs oids = new ObjectIDs();
            ObjectID oid = new ObjectID();

            if (set != null)
            {
                //获取选择集列表
                List<SelectSetItem> lst = set.Get();

                foreach (SelectSetItem item in lst)
                {
                    count += item.IDList.Count;
                }
                if (lst == null || lst.Count == 0) return count;

                //获取图层信息
                MapLayer maplayer = lst[0].Layer;
                //获取图层对应的要素类的信息
                basClass = maplayer.GetData();

                //获取处于编辑状态第一个图层的要素ID列表
                List<long> idarr = lst[0].IDList;

                for (int i = 0; i < idarr.Count; i++)
                {
                    oid.Int64Val = idarr[i];
                    oids.Append(oid);
                }
                rcdSet = new RecordSet(basClass);
                //添加结果集
                rcdSet.AddSet(oids);
            }
            attCtrl.SetXCls((IVectorCls)basClass, rcdSet);
            return count;
        }

        public RecordSet GetRcdSet
        { get { return rcdSet; } }
    }
}