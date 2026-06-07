using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Sniper_Character : TP_Character
	{
		[SerializeField]
		private Vector2 _whipOffset;

		[SerializeField]
		private float _spriteWhipOffset;

		private SpriteRenderer _back2Sprite;

		private SpriteAnimation _back2Anim;

		private const string IdleAnimName = "idle";

		private const string SniperTextureName = "character_tp_sniper";

		public override float2 GetVectorWhipOffset => default(float2);

		public override float GetSpriteWhipOffset => 0f;

		public override bool NeedsCart => false;

		public override bool ShouldCollideWithWalls()
		{
			return false;
		}

		protected override void OnStop()
		{
		}

		public override void AfterFullInitialization()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
