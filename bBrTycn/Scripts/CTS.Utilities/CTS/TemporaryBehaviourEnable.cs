using System;
using UnityEngine;

namespace CTS
{
	public readonly struct TemporaryBehaviourEnable : IDisposable
	{
		private readonly bool _startValue;

		private readonly Behaviour _behaviour;

		public TemporaryBehaviourEnable(Behaviour behaviour, bool isEnabled)
		{
			_startValue = behaviour.enabled;
			_behaviour = behaviour;
			_behaviour.enabled = isEnabled;
		}

		public void Dispose()
		{
			_behaviour.enabled = _startValue;
		}
	}
}
