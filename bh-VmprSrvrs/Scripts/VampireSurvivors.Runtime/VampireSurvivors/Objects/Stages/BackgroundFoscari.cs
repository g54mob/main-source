using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundFoscari : BackgroundManager
	{
		private MeshRenderer _magicWaterImage;

		private TileSprite _water;

		private bool _hasMagicWater;

		private PhaserSprite _waterAnim;

		private float _fsSealX;

		private float _fsSealY;

		protected override void OnDestroy()
		{
		}

		protected void InitMagicWater()
		{
		}

		public override void Create()
		{
		}

		private void OnRemoteDestructibleSpawned(Destructible destructible)
		{
		}

		public override void OnInitCompleted()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		private void InitVFX()
		{
		}

		private void CreateSeal1()
		{
		}

		private void CreateBadge()
		{
		}
	}
}
