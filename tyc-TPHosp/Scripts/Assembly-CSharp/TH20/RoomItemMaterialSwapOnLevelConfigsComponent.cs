using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	[CreateAssetMenu(menuName = "TH20/Configs/Room Item Material Swap On Level Configs", order = 1103)]
	public class RoomItemMaterialSwapOnLevelConfigsComponent : ScriptableObjectWithID
	{
		public SharedInstance_TH20TH20_LevelConfig[] Levels;

		public Material[] OriginalMaterials;

		public Material[] NewMaterials;
	}
}
