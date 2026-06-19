using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	[CreateAssetMenu(menuName = "TH20/Configs/Room Item Material Swap On Level Config", order = 1103)]
	public class RoomItemMaterialSwapOnLevelConfigComponent : ScriptableObjectWithID
	{
		public SharedInstance_TH20TH20_LevelConfig Level;

		public Material[] OriginalMaterials;

		public Material[] NewMaterials;
	}
}
