using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-pixel-perfect/")]
	[ExecuteInEditMode]
	public class ProCamera2DPixelPerfectSprite : BasePC2D, IPostMover
	{
		public bool IsAMovingObject;

		public bool IsAChildSprite;

		public Vector2 LocalPosition;

		[Range(-8f, 32f)]
		public int SpriteScale;

		private Sprite _sprite;

		private ProCamera2DPixelPerfect _pixelPerfectPlugin;

		[SerializeField]
		private Vector3 _initialScale;

		private int _prevSpriteScale;

		private int _pmOrder;

		public int PMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void PostMove(float deltaTime)
		{
		}

		private void Step()
		{
		}

		private void GetPixelPerfectPlugin()
		{
		}

		private void GetSprite()
		{
		}

		public void SetAsPixelPerfect()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
