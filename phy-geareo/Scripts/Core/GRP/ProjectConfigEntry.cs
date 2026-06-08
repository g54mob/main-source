using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ProjectConfigEntry", fileName = "ProjectConfigEntry")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ProjectConfigEntry : ConfigEntry<ProjectConfig>
	{
	}
}
