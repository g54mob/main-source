using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	public class UIRelativePosition : MonoBehaviour
	{
		[MustBeAssigned]
		public RectTransform Target;

		[Separator("Set X/Y, with optional offset", false)]
		public OptionalFloat SetX;

		public OptionalFloat SetY;

		[Separator("0-1 point on Target rect", false)]
		public Vector2 TargetAnchor;

		private RectTransform _transform;

		private Vector2 _latestSize;

		private Vector3 _latestPosition;

		private bool _firstCall;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
