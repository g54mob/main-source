using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachineClippingPlanesShaker")]
	public class MMCinemachineClippingPlanesShaker : MMShaker
	{
		[MMInspectorGroup("Clipping Planes", true, 45)]
		public bool RelativeClippingPlanes;

		[MMInspectorGroup("Near Plane", true, 46)]
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeNear = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapNearZero = 0.3f;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapNearOne = 100f;

		[MMInspectorGroup("Far Plane", true, 47)]
		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeFar = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapFarZero = 1000f;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapFarOne = 1000f;
	}
}
