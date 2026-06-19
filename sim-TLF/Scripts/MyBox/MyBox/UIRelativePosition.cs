using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	public class UIRelativePosition : MonoBehaviour
	{
		[MustBeAssigned]
		public RectTransform Target;

		[Separator("Set X/Y, with optional offset", false)]
		public OptionalFloat SetX = OptionalFloat.WithValue(0f);

		public OptionalFloat SetY = OptionalFloat.WithValue(0f);

		[Separator("0-1 point on Target rect", false)]
		public Vector2 TargetAnchor = new Vector2(0.5f, 0.5f);

		private RectTransform _transform;

		private Vector2 _latestSize;

		private Vector3 _latestPosition;

		private bool _firstCall;

		private void Start()
		{
			_transform = base.transform as RectTransform;
			if (_transform == null)
			{
				Debug.LogError(base.name + " Caused: Transform is not a RectTransform", this);
			}
			if (!SetX.IsSet && !SetY.IsSet)
			{
				Debug.LogError(base.name + " Caused: Check SetX and/or SetY for RelativePosition to work", this);
			}
		}

		private void LateUpdate()
		{
			if (_transform == null || Target == null)
			{
				return;
			}
			if (!_firstCall)
			{
				_firstCall = true;
				return;
			}
			Vector2 sizeDelta = Target.sizeDelta;
			Vector3 position = Target.position;
			if (!(_latestSize == sizeDelta) || !(_latestPosition == position))
			{
				_latestSize = sizeDelta;
				_latestPosition = position;
				Vector3 lossyScale = Target.lossyScale;
				Vector2 pivot = Target.pivot;
				float num = sizeDelta.x * TargetAnchor.x;
				float num2 = sizeDelta.y * TargetAnchor.y;
				float num3 = position.x - sizeDelta.x * pivot.x * lossyScale.x;
				float num4 = position.y + sizeDelta.y - sizeDelta.y * pivot.y * lossyScale.y;
				float num5 = num3 + num + SetX.Value;
				float num6 = num4 - num2 + SetY.Value;
				Vector3 position2 = _transform.position;
				Vector2 vector = new Vector2(SetX.IsSet ? ((float)(int)num5) : position2.x, SetY.IsSet ? ((float)(int)num6) : position2.y);
				_transform.position = vector;
			}
		}
	}
}
