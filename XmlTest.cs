using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace dbtest
{
	class XmlTest
	{
		public static void Run()
		{
			List<FormGrid> grids = new List<FormGrid>();
			grids.Add(new FormGrid());
			grids.Add(new FormGrid());
			grids.Add(new FormGrid());

			XmlSerializer serializer = new XmlSerializer(grids.GetType());
			using (StreamWriter sw = new StreamWriter("test.xml", true))
			{
				serializer.Serialize(sw, grids);
			}
		}
	}

	public class FormColumn
	{
		static private Random rand = new Random();
		[XmlAttribute("name")]
		public string Name { set; get; }
		[XmlAttribute("header")]
		public string Header { set; get; }
		[XmlAttribute("type")]
		public string Type { set; get; }
		public FormColumn()
		{
			Name = rand.Next(10000).ToString();
			Header = rand.Next(10000).ToString();
			Type = rand.Next(10000).ToString();
		}
	}

	public class FormGrid
	{
		static private Random rand = new Random();
		public List<FormColumn> columns { set; get; }
		[XmlElement("GridName")]
		public string Name { set; get; }
		public FormGrid()
		{
			Name = rand.Next(10000).ToString();
			columns = new List<FormColumn>();
			columns.Add(new FormColumn());
			columns.Add(new FormColumn());
			columns.Add(new FormColumn());
		}
	}
}
