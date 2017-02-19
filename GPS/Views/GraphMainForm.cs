﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS.Views
{
    public partial class GraphMainForm: Form
    {
        public int graphId;
        public GPSNode lastSelectedNode = null;
        private GPSGraph graph = new GPSGraph();

        public GraphMainForm()
        {
            InitializeComponent();
            CustomizeComponent();
        }

        public void CustomizeComponent()
        {
            
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addNodeForm = new AddNodeForm();
            addNodeForm.creator = this;
            addNodeForm.ShowDialog();
        }
        
        public LocationNodeButton addButtonForNode(float x, float y) 
        {
            var newLocationButton = new LocationNodeButton();
            newLocationButton.Location = new Point((int)x - newLocationButton.Height / 2,
                (int)y - newLocationButton.Height / 2 + this.menuStrip2.Height);
            this.Controls.Add(newLocationButton);
            return newLocationButton;
        }

        public void NodeCreated(string name, float xCoordinate, float yCoodrinate) {
            if (graph == null) return;
            var newNode = new GPSNode();
            newNode.Location = new PointF(xCoordinate, yCoodrinate);
            newNode.Name = name;
            var locationButton = addButtonForNode(xCoordinate, yCoodrinate);
            newNode.AssociatedControl = locationButton;
            var node = graph.NewNode(newNode);
            locationButton.node = newNode;
            locationButton.creator = this;
        }

        private void drawLineConnection(PointF point1, PointF point2)
        {

        }

        public void createOneWayConnection(GPSNode node)
        {
            PointF origin = this.lastSelectedNode.Location;
            PointF dest = this.lastSelectedNode.Location;
            this.Refresh();
        }
    }
}
