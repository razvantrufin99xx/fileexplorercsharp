/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 5/9/2024
 * Time: 11:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace directoryControl
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			//  Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}
		
		public char[] split = {'\\', ':' , '/', };
		public int dimoftxta = 0;
		public string exepath = "";
		public int nro = 0;
		public string [] splited = new string[100];
		
		public void createpathTextBox()
		{
			nro = this.Controls.Count;
			exepath = Application.ExecutablePath;
			splited = exepath.Split(split);
			string x = "";
			
			//dimoftxta = textBox1.Width;
			for(int i = 0 ; i < splited.Length ; i++)
			{
				if(i<splited.Length-1){
					x = splited[i];//+ "\\";
					
				}
				else
				{
				 x = splited[i]  ;
				 	
				}
					this.Controls.Add(new TextBox());
				
				this.Controls[nro].Text = x;
				if(nro>1){
					this.Controls[nro].Left =  (this.Controls[nro-1].Left   +  this.Controls[nro-1].Width +  5)-1  ;
					}
				else 
				{
					this.Controls[nro].Left =  0  ;
				}
				this.Controls[nro].Top = 30;
				this.Controls[nro].Visible = true;
				this.Controls[nro].Width = this.Controls[nro].Text.Length*(int)this.Font.SizeInPoints;
				nro++;
					
			}
			x = "";
			for(int j = 0 ; j < splited.Length ; j++)
			{
			if(j<splited.Length-1){
					x = splited[j];//+ "\\";
					//this.textBox1.Text += x + "\\";
				}
				else
				{
				 x = splited[j]  ;
				 	//this.textBox1.Text += x ;
				}
			}
		//	this.textBox1.Width = this.textBox1.Text.Length*(int)this.Font.SizeInPoints;
		}
		
		public List<directoryControl>nds = new List<directoryControl>();
		public void createpathDirectoryControl(string s)
		{
		
				nds.Clear();
				this.panel1.Controls.Clear();
				Refresh();
				exepath = s;
				Text = s;
			
			splited = exepath.Split(split);
			string x = "";
			string p = "";
			for(int i = 0 ; i < splited.Length ; i++)
			{
				//G:\__mydocuments\src\directoryControl\directoryControl\bin\Debug
				x = splited[i];
				if(i<1 ){
				p +=splited[i]+":";
				}
				if(i>1 && splited[i-1]!="\\")
				{
				p +="\\"+splited[i];
			
				}
				
						
				nds.Add(new directoryControl());
				
				nds[i].setName(x);
				nds[i].setLabel(x);
				nds[i].setWidth(x.Length*(int)this.Font.SizeInPoints+10);
				nds[i].path = p;
				this.panel1.Controls.Add(nds[i]);
				nds[i].typeofthiscontrol = "MAINPATH";
				if(i==0)
				{
				this.panel1.Controls[i].Left =  10 ;
				}
				else
				{
					this.panel1.Controls[i].Left = this.panel1.Controls[i-1].Left + 10 + this.panel1.Controls[i-1].Width ;
				}
				
				
				this.panel1.Controls[i].Top = 30;
				this.panel1.Controls[i].Visible = true;
			
				
			}
				this.Refresh();
				try{
					doit(this.Text);
				}
				catch{}
		}
		
		public void createpathDirectoryControl2(string s)
		{
		
				nds.Clear();
				this.panel1.Controls.Clear();
				Refresh();
				exepath = s;
				Text = s;
			
			splited = exepath.Split(split);
			string x = "";
			string p = "";
			for(int i = 0 ; i < splited.Length ; i++)
			{
				//G:\__mydocuments\src\directoryControl\directoryControl\bin\Debug
				x = splited[i];
				if(i<1 ){
				p +=splited[i]+":";
				}
				if(i>1 && splited[i-1]!="\\")
				{
				p +="\\"+splited[i];
			
				}
				
						
				nds.Add(new directoryControl());
				
				nds[i].setName(x);
				nds[i].setLabel(x);
				nds[i].setWidth(x.Length*(int)this.Font.SizeInPoints+10);
				nds[i].path = p;
				this.panel1.Controls.Add(nds[i]);
				nds[i].typeofthiscontrol = "MAINPATH";
				if(i==0)
				{
				this.panel1.Controls[i].Left =  10 ;
				}
				else
				{
					this.panel1.Controls[i].Left = this.panel1.Controls[i-1].Left + 10 + this.panel1.Controls[i-1].Width ;
				}
				
				
				this.panel1.Controls[i].Top = 30;
				this.panel1.Controls[i].Visible = true;
			
				
			}
				this.Refresh();
				try{
					//doit(this.Text);
				}
				catch{}
		}
		
		/*
		 recreaza path dupa apasare directoryControl utilizand splited array
		 prin combinarea primele i intrari de mai inainte
		 */
		
			public List<directoryControl>dc = new List<directoryControl>();
			public List<directoryControl>f = new List<directoryControl>();
			public List<string> fost = new List<string>();
			public int counterofdirsadded = 0;
		
			public void setCounterBackWith1()
			{
				this.counterofdirsadded -=2;
			}
		public void doit(string s){
				counterofdirsadded++;
				dc.Clear();
				f.Clear();
				this.panel2.Controls.Clear();
					this.panel3.Controls.Clear();
						this.panel4.Controls.Clear();
				fost.Add(s);
			Text = s;
			string [] dirs = System.IO.Directory.GetDirectories(s);
			Text = dirs.Length.ToString();
			for(int i = 0 ; i < dirs.Length ; i++)
			{
				//Text = i.ToString();
				dc.Add(new directoryControl());
				dc[i].setName(dirs[i]);
				dc[i].setLabel(dirs[i]);
				dc[i].setWidth(250);
				this.panel2.Controls.Add(dc[i]);
				dc[i].typeofthiscontrol = "FOLDER";
				this.panel2.Controls[i].Visible = true;
				this.panel2.Controls[i].Left = 10;
				this.panel2.Controls[i].Top = i*25;
				
				this.Refresh();
			}
			//int dcn = dc.Count;
			int dcn=0;
			string [] files = System.IO.Directory.GetFiles(s);
			for(int i = 0 ; i < files.Length ; i++)
			{
				f.Add(new directoryControl());
				f[i].setName(files[i]);
				f[i].setLabel(files[i]);
				f[i].setWidth(250);
				this.panel3.Controls.Add(f[i]);
				f[i].typeofthiscontrol = "FILE";
				this.panel3.Controls[dcn+i].Visible = true;
				this.panel3.Controls[dcn+i].Left = 10+250+20;
				this.panel3.Controls[dcn+i].Top = 25+i*25;
				
				this.Refresh();
			}
			
			directoryControl back = new directoryControl();
			this.panel4.Controls.Add(back);
			back.Left = 600;
			back.Top = 50;
			back.setLabel("C:\\");
			
		
			
			directoryControl backc = new directoryControl();
			this.panel4.Controls.Add(backc);
			backc.Left = 600;
			backc.Top = 80;
			backc.type = "backwithone";
			if(counterofdirsadded>1)
			{
								
				backc.setLabel(fost[counterofdirsadded-1]);
			}
			if(counterofdirsadded>2)
			{
								
				backc.setLabel(fost[counterofdirsadded-2]);
				
			}
			createpathDirectoryControl2(s);
		}
		void MainFormShown(object sender, EventArgs e)
		{
			Thread.Sleep(200);
			//createpath();
			exepath = Application.ExecutablePath;
			
		
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.panel1.Controls.Clear();
			createpathDirectoryControl(exepath);
	
		}
		void Button2Click(object sender, EventArgs e)
		{
			this.panel2.Controls.Clear();
			doit("C:\\");
		}
		
	}
}
