using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	public class UISizeBy : MonoBehaviour
	{
		[MustBeAssigned]
		public RectTransform CopySizeFrom;

		[Header("CopyWidth/Height, Set optional offset")]
		public OptionalInt CopyWidth = OptionalInt.WithValue(0);

		public OptionalInt CopyHeight = OptionalInt.WithValue(0);

		[Header("Optional Min/Max Width/Height")]
		public OptionalMinMax MinMaxWidth;

		public OptionalMinMax MinMaxHeight;

		private RectTransform _transform;

		private Vector2 _latestSize;

		private void Start()
		{
			_transform = base.transform as RectTransform;
			if (_transform == null)
			{
				Debug.LogError(base.name + " Caused: Transform is not a RectTransform", this);
			}
			if (!CopyWidth.IsSet && !CopyHeight.IsSet)
			{
				Debug.LogError(base.name + " Caused: You must set CopyWidth or CopyHeight for UISizeBy to work", this);
			}
		}

		private void LateUpdate()
		{
			if (!(CopySizeFrom == null) && !(_transform == null))
			{
				Vector2 sizeDelta = CopySizeFrom.sizeDelta;
				if (!(_latestSize == sizeDelta))
				{
					_latestSize = sizeDelta;
					Vector2 sizeDelta2 = _transform.sizeDelta;
					float value = (CopyWidth.IsSet ? (_latestSize.x + (float)CopyWidth.Value) : sizeDelta2.x);
					float value2 = (CopyHeight.IsSet ? (_latestSize.y + (float)CopyHeight.Value) : sizeDelta2.y);
					value = MinMaxWidth.GetFixed(value);
					value2 = MinMaxHeight.GetFixed(value2);
					_transform.sizeDelta = new Vector2(value, value2);
				}
			}
		}
	}
}
