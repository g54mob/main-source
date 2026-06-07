using System;
using JetBrains.Annotations;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects
{
	[UsedImplicitly]
	public class ShootingStarsManager : IInitializable, IDisposable
	{
		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private DiContainer _diContainer;

		private Camera _mainCamera;

		private ObjectPool _explosionStarsPool;

		private const float Damage = 30f;

		private const float Radius = 0.6f;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void AimRandom(int times = 1, float delay = 100f, float radiusMul = 1f)
		{
		}

		public void InternalUpdate()
		{
		}

		private void ShootOne(float radiusMul = 1f)
		{
		}

		private void ShootStarAt(Vector2 spawnPos)
		{
		}
	}
}
