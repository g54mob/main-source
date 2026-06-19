using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RoslynCSharp.Project
{
	internal sealed class CSharpProjectParser
	{
		private static readonly XNamespace scheme = "http://schemas.microsoft.com/developer/msbuild/2003";

		private string assemblyName = "";

		private List<string> sources;

		private List<string> references;

		private List<string> projectReferences;

		private List<string> defines;

		private Exception parseException;

		public string AssemblyName => assemblyName;

		public IReadOnlyList<string> Sources => sources;

		public IReadOnlyList<string> References => references;

		public IReadOnlyList<string> ProjectReferences => projectReferences;

		public IReadOnlyList<string> Defines => defines;

		public Exception ParseException
		{
			get
			{
				return parseException;
			}
			internal set
			{
				parseException = value;
			}
		}

		public bool ParseCSharpProject(XmlReader reader)
		{
			XDocument document = XDocument.Load(reader);
			if (!ParseAssemblyName(document))
			{
				return false;
			}
			if (!ParseSourceFiles(document))
			{
				return false;
			}
			if (!ParseReferences(document))
			{
				return false;
			}
			if (!ParseProjectReferences(document))
			{
				return false;
			}
			if (!ParseDefines(document))
			{
				return false;
			}
			return true;
		}

		private bool ParseAssemblyName(XDocument document)
		{
			try
			{
				string value = document.Descendants().SingleOrDefault((XElement r) => r.Name.LocalName == "AssemblyName").Value;
				assemblyName = value;
			}
			catch (Exception ex)
			{
				parseException = ex;
				return false;
			}
			return true;
		}

		private bool ParseSourceFiles(XDocument document)
		{
			try
			{
				IEnumerable<string> collection = from r in document.Element(scheme + "Project").Elements(scheme + "ItemGroup").Elements(scheme + "Compile")
					select r.FirstAttribute.Value;
				sources = new List<string>(collection);
			}
			catch (Exception ex)
			{
				parseException = ex;
				return false;
			}
			return true;
		}

		private bool ParseReferences(XDocument document)
		{
			try
			{
				IEnumerable<string> source = from r in document.Element(scheme + "Project").Elements(scheme + "ItemGroup").Elements(scheme + "Reference")
					select (!string.IsNullOrEmpty(r.Value)) ? r.Value : r.FirstAttribute.Value;
				references = new List<string>(source.Select((string r) => r.Trim(' ', '\t', '"', '\n')));
			}
			catch (Exception ex)
			{
				parseException = ex;
				return false;
			}
			return true;
		}

		private bool ParseProjectReferences(XDocument document)
		{
			try
			{
				IEnumerable<string> source = from r in document.Element(scheme + "Project").Elements(scheme + "ItemGroup").Elements(scheme + "ProjectReference")
					select r.FirstAttribute.Value;
				projectReferences = new List<string>(source.Select((string r) => r.Trim(' ', '\t', '"', '\n')));
			}
			catch (Exception ex)
			{
				parseException = ex;
				return false;
			}
			return true;
		}

		private bool ParseDefines(XDocument document)
		{
			try
			{
				IEnumerable<string> enumerable = from r in (from r in document.Element(scheme + "Project").Elements(scheme + "PropertyGroup")
						where r.FirstAttribute != null
						select r).Elements(scheme + "DefineConstants")
					select r.Value;
				defines = new List<string>();
				foreach (string item in enumerable)
				{
					defines.AddRange(item.Split(';'));
				}
			}
			catch (Exception ex)
			{
				parseException = ex;
				return false;
			}
			return true;
		}
	}
}
