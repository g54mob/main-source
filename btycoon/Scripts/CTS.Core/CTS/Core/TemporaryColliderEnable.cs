using UnityEngine;

namespace CTS.Core
{
	public readonly ref struct TemporaryColliderEnable
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
