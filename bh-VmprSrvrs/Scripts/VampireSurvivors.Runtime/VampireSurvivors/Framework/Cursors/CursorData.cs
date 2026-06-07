using UnityEngine;

namespace VampireSurvivors.Framework.Cursors
{
	public class CursorData
	{
		public string AnimationName;

		public int AnimationStartingFrame;

		public int AnimationFramesCount;

		public int AnimationFrameRate;

		public Sprite CursorSprite;

		public Sprite IconSprite;

		public string CursorColorHex;

		public float CursorAlpha;

		public float CursorScale;

		public bool OnScreenPointAt;

		public float IconAlpha;

		public Vector3 OnScreenCursorOffset;

		public string Text;

		private float _cursorProportionOfScreenFromCenter;

		public CursorIndicator _CursorInstanceReference;

		public float CursorProportionOfScreenFromCenter
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}
	}
}
