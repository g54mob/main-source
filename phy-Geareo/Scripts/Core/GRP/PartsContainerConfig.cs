using System.Collections.Generic;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/PartsContainerConfig", fileName = "PartsContainerConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class PartsContainerConfig : ScriptableObject
	{
		public List<PartConfigEntry> entries;
	}
}
