using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat.Bullets
{
	public class BulletPool : IDisposable
	{
		private BulletData _bulletData;

		private GCHandle _bulletDataHandle;

		private IntPtr _bulletDataPtr;

		private bool _disposed;

		private BulletPoolSet _poolSet;

		public BulletPool(BulletPoolSet poolSet, BulletData bulletData)
		{
			_poolSet = poolSet;
			_bulletData = bulletData;
			_bulletDataHandle = GCHandle.Alloc(_bulletData, GCHandleType.Normal);
			_bulletDataPtr = GCHandle.ToIntPtr(_bulletDataHandle);
			_poolSet.AddPool(this);
		}

		public void CreateBullet(Vector3 position, Vector3 velocity, Vector3 direction)
		{
			_poolSet.AddBullet(position, velocity, direction, _bulletData, _bulletDataPtr);
		}

		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_bulletDataHandle.Free();
				_bulletDataPtr = IntPtr.Zero;
				_poolSet.RemovePool(this);
			}
		}
	}
}
