using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ProjectDataContainer", fileName = "ProjectDataContainer")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ProjectDataContainer : ScriptableObject
	{
		public int version;

		public string json;

		public string imageBase64;

		private Texture2D loadedImage;

		private int loadedImageVersion;

		private ProjectData loadedProjectData;

		private int loadedProjectDataVersion;

		public string key => null;

		public Texture2D image => null;

		public ProjectData projectData => null;

		public ProjectData Parse()
		{
			return null;
		}

		public void Write(ProjectData data)
		{
		}
	}
}
