using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using RoslynCSharp.Compiler;

namespace RoslynCSharp.Project
{
	public class CSharpProject
	{
		private CSharpProjectParser parser = new CSharpProjectParser();

		protected IMetadataReferenceProvider[] compilerReferences;

		internal CSharpProjectParser Parser => parser;

		public string AssemblyName => parser.AssemblyName;

		public IReadOnlyList<string> Sources => parser.Sources;

		public IReadOnlyList<string> References => parser.References;

		public IReadOnlyList<string> ProjectReferences => parser.ProjectReferences;

		public IReadOnlyList<string> Defines => parser.Defines;

		public Exception ParseException
		{
			get
			{
				return parser.ParseException;
			}
			protected internal set
			{
				parser.ParseException = value;
			}
		}

		private protected CSharpProject()
		{
		}

		public virtual IMetadataReferenceProvider[] GetMetadataReferences()
		{
			if (compilerReferences == null)
			{
				IReadOnlyList<string> references = References;
				compilerReferences = new IMetadataReferenceProvider[references.Count];
				for (int i = 0; i < references.Count; i++)
				{
					compilerReferences[i] = AssemblyReference.FromNameOrFile(references[i]);
				}
			}
			return compilerReferences;
		}

		public static CSharpProject ParseText(string csharpProjectText)
		{
			if (!TryParseText(csharpProjectText, out var project))
			{
				if (project.ParseException != null)
				{
					throw project.ParseException;
				}
				return null;
			}
			return project;
		}

		public static bool TryParseText(string csharpProjectText, out CSharpProject project)
		{
			project = new CSharpProject();
			try
			{
				using XmlReader reader = XmlReader.Create(new StringReader(csharpProjectText));
				project.Parser.ParseCSharpProject(reader);
				if (project.ParseException != null)
				{
					project = null;
					return false;
				}
			}
			catch (Exception parseException)
			{
				project.ParseException = parseException;
			}
			return true;
		}
	}
}
