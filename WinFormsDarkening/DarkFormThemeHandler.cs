using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsDarkening
{
    public static class DarkFormThemeHandler
    {
        public static Color Darken(Color color)
        {
            return ControlPaint.Dark(color, (float)0.6);
            //return Color.FromArgb(32, 34, 39);
            //return Contrast(color);
            //return DarkContrast(color);
        }

        public static Color Contrast(Color color)
        {
            return RGBUtils.FlipContrast(color);
        }

        public static Color DarkContrast(Color color)
        {
            return RGBUtils.FlipContrastDark(color);
        }


        public static Color Lighter(Color color)
        {
            return ControlPaint.Light(color);
        }

        public static void DarkenFormControls(Form form, List<Type> controlTypes, bool noBorders, Color contrastTextColor, bool selfDarken)
        {

            if (controlTypes.Count > 0)
            {
                foreach (Type ctrlType in controlTypes)
                {
                    DarkenFormControlsOfType(form, ctrlType, noBorders, contrastTextColor);
                }
            }
            else
            {
                DarkenAllFormControls(form, noBorders, contrastTextColor);
            }

            if (selfDarken)
            {
                DarkenForm(form, noBorders, contrastTextColor);
            }
        }

        public static void DarkenFormControlsOfType(Form form, Type type, bool noBorders, Color contrastTextColor)
        {
            foreach (var control in form.Controls)
            {
                if (IsType(control, type))
                {
                    DarkenControl(control, noBorders, contrastTextColor);
                }
            }
        }

        public static void DarkenAllFormControls(Form form, bool noBorders, Color contrastTextColor)
        {
            foreach (Control control in form.Controls)
            {
                DarkenControl(control, noBorders, contrastTextColor);
            }
            
            foreach (ToolStripMenuItem control in form.MainMenuStrip.Items)
            {
                control.ForeColor = contrastTextColor;
                foreach (ToolStripMenuItem subControl in control.DropDownItems)
                {
                    DarkenToolStripMenuItem(subControl, noBorders, contrastTextColor);
                }
            }
        }
        public static void DarkenControl(dynamic control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);

            if (control is Button) DarkenButton((Button)control, noBorders, contrastTextColor);
            if (control is Form) DarkenForm((Form)control, noBorders, contrastTextColor);
            if (control is TextBox) DarkenTextBox((TextBox)control, noBorders, contrastTextColor);
            if (control is RichTextBox) DarkenRichTextBox((RichTextBox)control, noBorders, contrastTextColor);
            if (control is TreeView) DarkenTreeView((TreeView)control, noBorders, contrastTextColor);
            if (control is ListBox) DarkenListBox((ListBox)control, noBorders, contrastTextColor);
            if (control is ListView) DarkenListView((ListView)control, noBorders, contrastTextColor);
            if (control is GroupBox) DarkenGroupBox((GroupBox)control, noBorders, contrastTextColor);

            if (control is TabControl) DarkenTabControl((TabControl)control, noBorders, contrastTextColor);
            if (control is TabPage) DarkenTabPage((TabPage)control, noBorders, contrastTextColor);

            if (control is ToolStrip) DarkenToolStrip((ToolStrip)control, noBorders, contrastTextColor);
            if (control is StatusStrip) DarkenStatusStrip((StatusStrip)control, noBorders, contrastTextColor);

            if (control is DataGridView) DarkenDataGridView((DataGridView)control, noBorders, contrastTextColor);
        }

        public static void DarkenButton(Button control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.FlatAppearance.BorderSize = 0;
                control.FlatStyle = FlatStyle.Flat;
            }
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenTextBox(TextBox control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;

        }
        public static void DarkenRichTextBox(RichTextBox control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;

        }
        public static void DarkenToolStripTextBox(ToolStripTextBox control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenTreeView(TreeView control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;

        }
        public static void DarkenListBox(ListBox control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;

        }
        public static void DarkenGroupBox(GroupBox control, bool noBorders, Color contrastTextColor)
        {
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenTabControl(TabControl control, bool noBorders, Color contrastTextColor)
        {
            control.Appearance = TabAppearance.Normal;
            foreach (TabPage page in control.TabPages)
            {
                DarkenTabPage((TabPage)page, noBorders, contrastTextColor);
            }
        }
        public static void DarkenTabPage(TabPage control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;
        }
        public static void DarkenListView(ListView control, bool noBorders, Color contrastTextColor)
        {
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
            }

            control.ForeColor = contrastTextColor;

        }
        public static void DarkenToolStripMenuItem(ToolStripMenuItem control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenToolStrip(ToolStrip control, bool noBorders, Color contrastTextColor)
        {
            foreach (dynamic subControl in control.Items)
            {
                if (subControl is ToolStripTextBox) DarkenToolStripTextBox((ToolStripTextBox)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripComboBox) DarkenToolStripComboBox((ToolStripComboBox)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripDropDown) DarkenToolStripDropDown((ToolStripDropDown)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripDropDownButton) DarkenToolStripDropDownButton((ToolStripDropDownButton)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripSplitButton) DarkenToolStripSplitButton((ToolStripSplitButton)subControl, noBorders, contrastTextColor);
            }
        }
        public static void DarkenStatusStrip(StatusStrip control, bool noBorders, Color contrastTextColor)
        {
            foreach (dynamic subControl in control.Items)
            {
                //BUG - StatusStrip Sub controls are not allowed to change color...
                if (subControl is ToolStripComboBox) DarkenToolStripComboBox((ToolStripComboBox)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripDropDown) DarkenToolStripDropDown((ToolStripDropDown)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripDropDownButton) DarkenToolStripDropDownButton((ToolStripDropDownButton)subControl, noBorders, contrastTextColor);
                if (subControl is ToolStripSplitButton) DarkenToolStripSplitButton((ToolStripSplitButton)subControl, noBorders, contrastTextColor);
            }
        }
        public static void DarkenToolStripComboBox(ToolStripComboBox control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenToolStripDropDown(ToolStripDropDown control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenToolStripDropDownButton(ToolStripDropDownButton control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            foreach (ToolStripMenuItem subControl in control.DropDownItems)
            {
                DarkenToolStripMenuItem(subControl, noBorders, contrastTextColor);
            }
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenToolStripSplitButton(ToolStripSplitButton control, bool noBorders, Color contrastTextColor)
        {
            control.BackColor = Darken(control.BackColor);
            foreach(ToolStripMenuItem subControl in control.DropDownItems)
            {
                DarkenToolStripMenuItem(subControl, noBorders, contrastTextColor);
            }
            control.ForeColor = contrastTextColor;
        }
        public static void DarkenForm(Form form, bool noBorders, Color contrastTextColor)
        {
            form.BackColor = Color.FromArgb(32,34,60);
            form.BackColor = Darken(form.BackColor);
            if (noBorders)
            {
                form.FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            form.ForeColor = contrastTextColor;
        }

        public static void DarkenDataGridView(DataGridView control, bool noBorders, Color contrastTextColor)
        {
            control.BackgroundColor = Darken(control.BackColor);
            if (noBorders)
            {
                control.BorderStyle = BorderStyle.None;
                control.CellBorderStyle = DataGridViewCellBorderStyle.None;
                control.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                control.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            }
            control.RowsDefaultCellStyle.BackColor = Darken(control.RowsDefaultCellStyle.BackColor);
            control.RowHeadersDefaultCellStyle.BackColor = Darken(control.RowHeadersDefaultCellStyle.BackColor);

            control.ColumnHeadersDefaultCellStyle.BackColor = Darken(control.ColumnHeadersDefaultCellStyle.BackColor);

            //control.RowTemplate.DefaultCellStyle.BackColor = Darken(control.RowTemplate.DefaultCellStyle.BackColor);
            //control.ColumnHeadersDefaultCellStyle.BackColor = Darken(control.ColumnHeadersDefaultCellStyle.BackColor);


            control.ForeColor = contrastTextColor;
        }
        public static bool IsType(object obj1, Type type)
        {
            var t = obj1.GetType();

            return t.IsAssignableFrom(type) || type.IsAssignableFrom(t);
        }
    }
}
