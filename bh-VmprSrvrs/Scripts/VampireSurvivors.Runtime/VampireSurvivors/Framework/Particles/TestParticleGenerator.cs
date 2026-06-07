using UnityEngine;

namespace VampireSurvivors.Framework.Particles
{
	public class TestParticleGenerator : GameMonoBehaviour
	{
		[SerializeField]
		private RectTransform _Canvas;

		private ParticleSystem _playerDamageVfx;

		private ParticleSystem _pickupVfx;

		private ParticleEmitterManager _explosionManager;

		private ParticleSystem _explosion1Pfx;

		private ParticleSystem _explosion2Pfx;

		private GravityWell _explosionGravWell;

		private ParticleEmitterManager _fireworksManager;

		protected override void OnUpdate()
		{
		}

		private void TestFireworksVfx(int index)
		{
		}

		private void TestPlayerDamageVfx()
		{
		}

		private void TestPickupVfx()
		{
		}

		private void TestExplosion()
		{
		}

		private void TestArcanaParticles()
		{
		}

		private void TestEnemyEye()
		{
		}

		private void TestGoldFever()
		{
		}

		private void TestBackground4Particles()
		{
		}

		private void TestUiFireworks()
		{
		}
	}
}
