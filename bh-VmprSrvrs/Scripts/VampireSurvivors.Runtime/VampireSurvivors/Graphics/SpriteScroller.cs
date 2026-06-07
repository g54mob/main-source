using UnityEngine;

namespace VampireSurvivors.Graphics
{
	public class SpriteScroller : GameMonoBehaviour
	{
		[SerializeField]
		private float _ScrollSpeedX;

		[SerializeField]
		private float _ScrollSpeedY;

		[SerializeField]
		private float _ScrollOffsetX;

		[SerializeField]
		private float _ScrollOffsetY;

		[SerializeField]
		private float _TextureOffsetX;

		[SerializeField]
		private float _TextureOffsetY;

		private SpriteRenderer _spriteRenderer;

		private float _prevScrollSpeedX;

		private float _prevScrollSpeedY;

		private float _spriteWidthUnits;

		private float _spriteHeightUnits;

		private float _textureWidthUnits;

		private float _textureHeightUnits;

		public SpriteRenderer Renderer => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnPause()
		{
		}

		protected override void OnResume()
		{
		}

		public void SetScrollSpeedX(float speed)
		{
		}

		public void SetScrollSpeedY(float speed)
		{
		}

		public void SetScrollOffsetX(float offset)
		{
		}

		public void SetScrollOffsetY(float offset)
		{
		}

		public void SetTextureOffsetX(float offset)
		{
		}

		public void SetTextureOffsetY(float offset)
		{
		}

		public void SpriteUpdated()
		{
		}
	}
}
