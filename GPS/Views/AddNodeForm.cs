﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS.Views
{
    public partial class AddNodeForm: Form
    {
        public GraphMainForm creator;

        public AddNodeForm()
        {
            InitializeComponent();
            InitializeStaticProperties();
            CustomizeComponent();
        }

        public void CustomizeComponent()
        {

        }

        public void InitializeStaticProperties() {
            numericUpDown1.Minimum = 0;
            numericUpDown2.Minimum = 0;
            numericUpDown2.Increment = 1;
            numericUpDown1.Increment = 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.creator == null) return;
            var name = this.textBox1.Text;
            var xCoordinate = this.numericUpDown1.Value;
            var yCoordinate = this.numericUpDown2.Value;
            this.creator.NodeCreated(name, (float)xCoordinate,(float)yCoordinate);
            this.Close();
        }
    }
}
