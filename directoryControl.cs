/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/9/2024
 * Time: 11:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace directoryControl
{
	/// <summary>
	/// Description of directoryControl.
	/// </summary>
	public partial class directoryControl : UserControl
	{
		public directoryControl()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public string nameofdir="";
		public string type = "dir";
		public string path = "";
		public string typeofthiscontrol = "MAINPATH";
		public MainForm mf;
		public void setName(string s)
		{
			this.nameofdir = s;
			
		}
		public void setLabel(string s)
		{
			this.label1.Text = s;
		}
		public void setLabelHeight(int h)
		{
			this.label1.Height = h;
		}
		public void setHeight(int h)
		{
			this.Height = h;
		}
		public void setLabelWidth(int w)
		{
			this.label1.Width = w;
		}
		public void setWidth(int w)
		{
			this.Width = w;
			setLabelWidth(w-1);
		}
		void Label1DoubleClick(object sender, EventArgs e)
		{
			Console.Beep();
			try{
				if(this.typeofthiscontrol!= "MAINPATH")
				{
					mf.doit(this.label1.Text);
				}
				else if(this.typeofthiscontrol == "MAINPATH")
				{
					mf.createpathDirectoryControl(this.path);
				}
				//schimba aceasta linei de cod de mai sus cu o linie care sa recreeze un path
				if(this.type=="backwithone")
				{
					mf.setCounterBackWith1();
				}
			}
			catch{}
		}
		
		void DirectoryControlLoad(object sender, EventArgs e)
		{
			try{mf = (MainForm)this.Parent.Parent;}
			catch{};
		}
	}
}
