using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MapDocOperate
{
    public partial class AttSelectForm : Form
    {
        public AttSelectForm()
        {
            InitializeComponent();
        }
        public DataTable m_GridDT = new DataTable();
        public AttSelectForm(string[] attName,ref List<string[ ]> attValue)
        {
            InitializeComponent();
        }
        void InitGrid(string[] attName, ref List<string[]> attValue)
        {
            m_GridDT.Clear();
            for (int i = 0; i < attName.Length; ++i)
            {
                m_GridDT.Columns.Add(attName[i]);
            }
            for (int j = 0; j < attValue.Count; ++j)
            {
                m_GridDT.Rows.Add((object[])attValue[j]);
            }
            m_GridDT.Columns.Add("选择",typeof(bool));
            m_GridDT.Columns["选择"].DefaultValue = false;
        }
        private void AttSelectForm_Load(object sender, EventArgs e)
        {

        }
    }
}
