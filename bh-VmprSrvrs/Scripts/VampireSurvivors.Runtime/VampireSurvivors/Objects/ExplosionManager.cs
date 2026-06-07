using System;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class ExplosionManager : IInitializable, IDisposable
	{
		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private DiContainer _diContainer;

		private ObjectPool _explosionPool;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void SpawnExplosion(Vector2 spawnPos, float damage, float radius)
		{
		}

		public void InternalUpdate()
		{
		}
	}
}
