using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using RoslynCSharp.Compiler;
using UnityEngine;

namespace RoslynCSharp.Project
{
	public class CSharpProjectFile : CSharpProject
	{
		private static readonly Dictionary<UnityCSharpProjectFile, string> unityProjectFilesLookup = new Dictionary<UnityCSharpProjectFile, string>
		{
			{
				UnityCSharpProjectFile.Assembly_CSharp,
				"Assembly-CSharp"
			},
			{
				UnityCSharpProjectFile.Assembly_CSharp_Editor,
				"Assembly-CSharp-Editor"
			},
			{
				UnityCSharpProjectFile.Assembly_CSharp_Firstpass,
				"Assembly-CSharp-firstpass"
			},
			{
				UnityCSharpProjectFile.Assembly_CSharp_Editor_Firstpass,
				"Assembly-CSharp-Editor-firstpass"
			}
		};

		private string projectPath = "";

		private IMetadataReferenceProvider[] metadataReferences;

		private IMetadataReferenceProvider[] projectMetadataReferences;

		private CSharpProjectFile[] projectReferences;

		public static string UnityProjectDirectory => Directory.GetParent(Application.dataPath).FullName;

		public string ProjectPath => projectPath;

		public string ProjectDirectory => Directory.GetParent(projectPath).FullName;

		private protected CSharpProjectFile(string projectPath)
		{
			this.projectPath = projectPath;
		}

		public override IMetadataReferenceProvider[] GetMetadataReferences()
		{
			if (base.ProjectReferences.Count == 0)
			{
				return base.GetMetadataReferences();
			}
			if (metadataReferences == null)
			{
				metadataReferences = base.GetMetadataReferences().Concat(GetMetadataProjectReferencesOnly()).ToArray();
			}
			return metadataReferences;
		}

		public IMetadataReferenceProvider[] GetMetadataProjectReferencesOnly()
		{
			if (projectMetadataReferences == null)
			{
				CSharpProjectFile[] array = GetProjectReferences();
				projectMetadataReferences = new IMetadataReferenceProvider[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					projectMetadataReferences[i] = AssemblyReference.FromNameOrFile(array[i].AssemblyName + ".dll");
				}
			}
			return projectMetadataReferences;
		}

		public CSharpProjectFile[] GetProjectReferences()
		{
			if (projectReferences == null)
			{
				IReadOnlyList<string> readOnlyList = base.ProjectReferences;
				projectReferences = new CSharpProjectFile[readOnlyList.Count];
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					string filePath = Path.Combine(ProjectDirectory, readOnlyList[i]);
					projectReferences[i] = ParseFile(filePath);
				}
			}
			return projectReferences;
		}

		public static CSharpProjectFile ParseFile(string filePath)
		{
			if (!TryParseFile(filePath, out var projectFile))
			{
				if (projectFile.ParseException != null)
				{
					throw projectFile.ParseException;
				}
				return null;
			}
			return projectFile;
		}

		public static bool TryParseFile(string filePath, out CSharpProjectFile projectFile)
		{
			projectFile = new CSharpProjectFile(filePath);
			try
			{
				using XmlReader reader = XmlReader.Create(filePath);
				projectFile.Parser.ParseCSharpProject(reader);
				if (projectFile.ParseException != null)
				{
					return false;
				}
			}
			catch (Exception parseException)
			{
				projectFile.ParseException = parseException;
			}
			return true;
		}

		public static CSharpProjectFile ParseUnityFile(UnityCSharpProjectFile unityProjectFile)
		{
			return ParseFile(GetUnityProjectFileLocation(unityProjectFile));
		}

		public static bool TryParseUnityFile(UnityCSharpProjectFile unityProjectFile, out CSharpProjectFile projectFile)
		{
			return TryParseFile(GetUnityProjectFileLocation(unityProjectFile), out projectFile);
		}

		public static CSharpProjectFile ParseUnityFile(string assemblyNameOnly)
		{
			if (!Path.HasExtension(assemblyNameOnly))
			{
				assemblyNameOnly += ".csproj";
			}
			return ParseFile(Path.Combine(UnityProjectDirectory, assemblyNameOnly));
		}

		public static bool TryParseUnityFile(string assemblyNameOnly, out CSharpProjectFile projectFile)
		{
			if (!Path.HasExtension(assemblyNameOnly))
			{
				assemblyNameOnly += ".csproj";
			}
			return TryParseFile(Path.Combine(UnityProjectDirectory, assemblyNameOnly), out projectFile);
		}

		public static string GetUnityProjectFileLocation(UnityCSharpProjectFile unityProjectFile)
		{
			string[] files = Directory.GetFiles(UnityProjectDirectory, "*.csproj");
			foreach (string text in files)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
				if (string.Compare(unityProjectFilesLookup[unityProjectFile], fileNameWithoutExtension) == 0)
				{
					return text;
				}
			}
			return null;
		}
	}
}
