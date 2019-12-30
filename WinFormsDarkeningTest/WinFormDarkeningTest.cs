using System;
using WinFormsDarkening;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace WinFormsDarkeningTest
{
    public partial class WinFormDarkeningTest : Form
    {
        public WinFormDarkeningTest()
        {
            InitializeComponent();
        }

        public void GoDarker()
        {
            List<Type> targetedTypes = new List<Type>();
            //targetedTypes.Add(typeof(Button));
            //targetedTypes.Add(typeof(Form));

            DarkFormThemeHandler.DarkenFormControls(this, targetedTypes, true, Color.White, true);
        }

        private void WinFormDarkeningTest_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F8)
            {
                GoDarker();
            }
        }
    }
}
