using System;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Objects
{
	public class ShootingEyesManager : IInitializable, IDisposable
	{
		[Inject]
		private GameSessionData _gameSessionData;

		[Inject]
		private DiContainer _diContainer;

		private Camera _mainCamera;

		private ObjectPool _explosionEyesPool;

		private const float Damage = 15f;

		private const float Radius = 0.6f;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void ShootOne(float radiusMul = 1f)
		{
		}

		public void Stop()
		{
		}

		public void InternalUpdate()
		{
		}

		private void ShootOneAt(Vector2 spawnPos)
		{
		}
	}
}
