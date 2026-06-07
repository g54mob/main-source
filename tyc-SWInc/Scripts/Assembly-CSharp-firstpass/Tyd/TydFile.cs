using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Tyd
{
	public class TydFile
	{
		protected TydDocument _docNode;

		protected string _filePath;

		public TydDocument DocumentNode
		{
			get
			{
				return _docNode;
			}
			set
			{
				_docNode = value;
			}
		}

		public string FilePath
		{
			get
			{
				return _filePath;
			}
		}

		public string FileName
		{
			get
			{
				return Path.GetFileName(_filePath);
			}
		}

		private TydFile()
		{
		}

		public static TydFile FromDocument(TydDocument doc, string filePath = null)
		{
			doc.Name = Path.GetFileName(filePath);
			return new TydFile
			{
				_docNode = doc,
				_filePath = filePath
			};
		}

		public static TydFile FromContent(string content, string filePath)
		{
			try
			{
				return FromDocument(new TydDocument(TydFromText.Parse(content)), filePath);
			}
			catch (Exception ex)
			{
				throw new Exception("Exception loading " + Path.GetFileName(filePath) + ": " + ex);
			}
		}

		public static List<TydFile> ReadAndResolvePath(string path, SearchOption searchOption, params string[] exception)
		{
			List<TydFile> list = new List<TydFile>();
			string[] files = Directory.GetFiles(path, "*.tyd", searchOption);
			foreach (string text in files)
			{
				if (exception == null || exception.Length == 0 || !exception.Contains(Path.GetFileNameWithoutExtension(text).ToLower()))
				{
					list.Add(FromContent(File.ReadAllText(text), text));
				}
			}
			foreach (TydFile item in list)
			{
				Inheritance.RegisterAllFrom(item.DocumentNode);
			}
			Inheritance.ResolveAll();
			Inheritance.Clear();
			return list;
		}

		public static TydFile FromFile(string filePath, bool treatXmlAsOneObject = false)
		{
			try
			{
				if (Path.GetExtension(filePath).ToLowerInvariant() == ".xml")
				{
					string xml = File.ReadAllText(filePath);
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(xml);
					List<TydNode> list = new List<TydNode>();
					if (treatXmlAsOneObject)
					{
						list.Add(TydXml.TydNodeFromXmlDocument(xmlDocument));
					}
					else
					{
						list.AddRange(TydXml.TydNodesFromXmlDocument(xmlDocument));
					}
					return FromDocument(new TydDocument(list), filePath);
				}
				string doc;
				using (StreamReader streamReader = new StreamReader(filePath))
				{
					doc = streamReader.ReadToEnd();
				}
				return FromDocument(new TydDocument(TydFromText.Parse(doc)), filePath);
			}
			catch (Exception ex)
			{
				throw new Exception("Exception loading " + filePath + ": " + ex);
			}
		}

		public void Save(string path = null)
		{
			if (path != null)
			{
				_filePath = path;
			}
			else if (_filePath == null)
			{
				throw new InvalidOperationException("Saved TydFile which had null path");
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (TydNode item in _docNode)
			{
				stringBuilder.AppendLine(TydToText.Write(item, true));
			}
			File.WriteAllText(_filePath, stringBuilder.ToString().TrimEnd());
		}

		public override string ToString()
		{
			return FileName;
		}
	}
}
