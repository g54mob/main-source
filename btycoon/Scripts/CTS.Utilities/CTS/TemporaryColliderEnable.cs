using System;
using UnityEngine;

namespace CTS
{
	public readonly struct TemporaryColliderEnable : IDisposable
	{
		private readonly bool _startValue;

		private readonly Collider _collider;

		public TemporaryColliderEnable(Collider collider, bool isEnabled)
		{
			_startValue = collider.enabled;
			_collider = collider;
			_collider.enabled = isEnabled;
		}

		public void Dispose()
		{
			_collider.enabled = _startValue;
		}
	}
}
