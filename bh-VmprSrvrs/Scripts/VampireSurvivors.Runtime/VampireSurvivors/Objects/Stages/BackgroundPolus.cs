using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundPolus : BackgroundManager
	{
		private MeshRenderer _magicWaterImage;

		private TileSprite _lavaTile;

		private bool _hasShaderBackground;

		private PhaserSprite _waterAnim;

		private float scrollOffset;

		private bool _hasGeneratedBackgroundSprites;

		private TileSprite _backgroundStars;

		private PhaserSprite _backgroundMountainsFar;

		private PhaserSprite _backgroundMountainsMid;

		private PhaserSprite _backgroundMountainsNear;

		private SpriteScroller _backgroundMountainsFarScroller;

		private SpriteScroller _backgroundMountainsMidScroller;

		private SpriteScroller _backgroundMountainsNearScroller;

		private float _mapHeight;

		public override void Create()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		private void InitVFX()
		{
		}

		private void MakeTheLava()
		{
		}

		private void MakeBackgroundSprites()
		{
		}

		private void LockY(Transform trans, float yPos)
		{
		}

		private void ShiftY(Transform trans, float min)
		{
		}

		private void ForceScrollOffset(SpriteScroller scroller)
		{
		}
	}
}
