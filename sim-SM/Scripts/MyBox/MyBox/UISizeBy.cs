using UnityEngine;

namespace MyBox
{
	[ExecuteInEditMode]
	public class UISizeBy : MonoBehaviour
	{
		[MustBeAssigned]
		public RectTransform CopySizeFrom;

		[Separator("CopyWidth/Height, Set optional offset", false)]
		public OptionalInt CopyWidth;

		public OptionalInt CopyHeight;

		[Separator("Optional Min/Max Width/Height", false)]
		public OptionalMinMax MinMaxWidth;

		public OptionalMinMax MinMaxHeight;

		private RectTransform _transform;

		private Vector2 _latestSize;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
