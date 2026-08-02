using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ExhibitBlinkerConfig", fileName = "ExhibitBlinkerConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ExhibitBlinkerConfig : ScriptableObject
	{
		public AnimationCurve appearCurve;

		public AnimationCurve blinkCurve;

		public AnimationCurve disappearCurve;

		public AnimationCurve pulseCurve;
	}
}
