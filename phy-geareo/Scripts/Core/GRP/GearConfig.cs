using System.Collections.Generic;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GearConfig", fileName = "GearConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GearConfig : ScriptableObject
	{
		public AnimationCurve segmentsOverTeeth;

		public Sprite guideIcon;

		public GearModule defaultModule;

		public List<GearModule> modules;

		public GearModule GetModule(int key)
		{
			return null;
		}
	}
}
