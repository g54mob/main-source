using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[AssetCreator(typeof(MainAssetCategory))]
	[CreateAssetMenu(menuName = "GRP/Main/MissionPoint", fileName = "MissionPoint")]
	public class MissionPoint : ScriptableObject
	{
		public MissionPoint[] requirements;

		[HideInInspector]
		public int projectVersion;

		[HideInInspector]
		public string projectJson;

		public string key => null;

		public MissionItem GetMissionItem(GameSession gameSession)
		{
			return null;
		}

		public bool IsLocked(GameSession gameSession)
		{
			return false;
		}

		public void SaveProject(ProjectData data)
		{
		}

		public ProjectData ParseProject()
		{
			return null;
		}
	}
}
