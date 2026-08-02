using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/GuideRowConfig", fileName = "GuideRowConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class GuideRowConfig : ScriptableObject
	{
		public GuideIconSource iconSource;

		public AnimationCurve alphaOverTime;

		public Gradient activeBackground;

		public Gradient activeForeground;

		public float smooth;
	}
}
