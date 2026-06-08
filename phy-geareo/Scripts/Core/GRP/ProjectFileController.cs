using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public static class ProjectFileController
	{
		public static ProjectFileDefinition[] GetAllSavedFiles(string path)
		{
			return null;
		}

		public static ProjectFolderDefinition[] GetAllSavedFolders(string path)
		{
			return null;
		}

		public static void SaveProjectFile(string path, ProjectFile file)
		{
		}

		public static bool IsFolder(string path)
		{
			return false;
		}

		public static bool IsProject(string path)
		{
			return false;
		}

		public static ProjectFile LoadProjectFile(string path)
		{
			return null;
		}

		public static bool DeleteProjectFile(string path)
		{
			return false;
		}

		public static bool DeleteFolder(string path)
		{
			return false;
		}

		public static string GetProjectPath(string relativePath = "")
		{
			return null;
		}

		public static string GetBuiltinProjectPath(string relativePath = "")
		{
			return null;
		}

		private static void EnsureDirectory()
		{
		}

		public static bool TryLoadManifest(string projectDirectoryPath, out ProjectFileManifestJson manifest)
		{
			manifest = null;
			return false;
		}

		public static void MergeProject(ProjectFileDefinition manifest, Project originalProject)
		{
		}

		public static void MergeProject(ProjectData projectData, Project originalProject)
		{
		}

		public static void SaveProject(Context context, string path, ProjectData data, Texture2D thumbnail)
		{
		}

		public static bool TrySaveProject(Context context, ProjectData data, string directory, string name, Texture2D thumbnail, out string error, bool forceOverride = false)
		{
			error = null;
			return false;
		}

		public static void ImportBuiltinProjects()
		{
		}

		public static void CopyDirectoryRecursive(string source, string destination)
		{
		}
	}
}
