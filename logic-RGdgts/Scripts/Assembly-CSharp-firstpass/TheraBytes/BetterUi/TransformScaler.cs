using UnityEngine;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class TransformScaler : ResolutionSizer<Vector3>
	{
		[SerializeField]
		private Vector3SizeModifier scaleSizerFallback;

		[SerializeField]
		private Vector3SizeConfigCollection customScaleSizers;

		private DrivenRectTransformTracker rectTransformTracker;

		public Vector3SizeModifier ScaleSizer => null;

		protected override ScreenDependentSize<Vector3> sizer => null;

		protected override void OnDisable()
		{
		}

		protected override void ApplySize(Vector3 newSize)
		{
		}
	}
}
