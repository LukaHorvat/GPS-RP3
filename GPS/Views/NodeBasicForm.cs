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
    public partial class NodeBasicForm : Form
    {
        public GPSNode node { get; set; }
        public NodeBasicForm()
        {
            InitializeComponent();
        }
    }
}
