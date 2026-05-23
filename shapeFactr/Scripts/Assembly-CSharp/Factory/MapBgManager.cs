using Factory.FieldData;
using Libs;
using UnityEngine;

namespace Factory
{
	public class MapBgManager : SingletonMonoBehaviour<MapBgManager>
	{
		[SerializeField]
		private SpriteRenderer[] bgList;

		[SerializeField]
		private SpriteRenderer[] previewBgList;

		[SerializeField]
		private SpriteRenderer[] previewFrameList;

		[SerializeField]
		private Transform[] fieldAccessoryList;

		[SerializeField]
		private SpriteRenderer bgFrame9Slice;

		[SerializeField]
		private Vector2 bgFrame9SliceDefaultSize;

		[SerializeField]
		private Vector3 bgFrame9SliceDefaultPosition;

		[SerializeField]
		private Vector3 bgFrame9SliceScale;

		private Vector2 bgFrame9SliceTextureSize;

		private Vector2 bgFrame9SliceTextureCoreSize;

		private Vector2 bgFrame9SliceSpriteBorderSize;

		private void Awake()
		{
		}

		private Vector2 CalcBgFrame9SliceSpriteSize(RectInt playAreaGridRect)
		{
			return default(Vector2);
		}

		private Vector2 CalcBgFrame9SliceSpriteSize2(RectInt playAreaGridRect)
		{
			return default(Vector2);
		}

		public void Refresh()
		{
		}

		public void PreviewMode(bool enablePreview, eMapExtension cursorArea = eMapExtension.None)
		{
		}
	}
}
