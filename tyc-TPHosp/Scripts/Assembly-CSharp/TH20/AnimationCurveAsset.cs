using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Animation Curve Asset", order = 1024)]
	public class AnimationCurveAsset : ScriptableObjectWithID
	{
		[SerializeField]
		public AnimationCurve Curve;
	}
}
