using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/PartConfigEntry", fileName = "PartConfigEntry")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class PartConfigEntry : ScriptableObject
	{
		public PartConfig config;

		public PartView view;

		public PartSim sim;

		public PartHandle handle;
	}
}
