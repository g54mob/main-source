using System;
using UnityEngine;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_Magic2Projectile : EME_Magic1Projectile
	{
		[Tooltip("The speed at which the invisible hitboxes orbit the player while the visuals stay stationary. Shouldbe high enough that enemies won't be able to get through the gaps between the hitboxes")]
		[SerializeField]
		private float _hitboxOrbitSpeed;

		private float _vfxPositionInCircumference;

		private float _angleTravelled;

		private const float RadiansInAFullCircle = (float)Math.PI * 2f;

		protected override float OrbitSpeed => 0f;

		public override void InternalUpdate()
		{
		}

		public override void SetOffsetPosition(int index)
		{
		}
	}
}
