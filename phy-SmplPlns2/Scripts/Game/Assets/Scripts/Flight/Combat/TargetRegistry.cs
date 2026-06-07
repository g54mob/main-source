using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.Combat.Events;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class TargetRegistry
	{
		private List<Target> _targets;

		public IReadOnlyList<Target> Targets => _targets;

		public event EventHandler<TargetEventArgs> TargetDied;

		public event EventHandler<TargetEventArgs> TargetRegistered;

		public event EventHandler<TargetEventArgs> TargetUnregistered;

		public TargetRegistry()
		{
			_targets = new List<Target>();
		}

		public void RegisterTarget(Target target)
		{
			if (!_targets.Contains(target))
			{
				_targets.Add(target);
				target.OnRegistered();
				RaiseEvent(this.TargetRegistered, target);
			}
		}

		public void UnregisterTarget(Target target)
		{
			if (_targets.Remove(target))
			{
				target.OnUnregistered();
				RaiseEvent(this.TargetUnregistered, target);
			}
		}

		public void Update()
		{
			for (int num = _targets.Count - 1; num >= 0; num--)
			{
				Target target = _targets[num];
				if (target.IsDead)
				{
					_targets.RemoveAt(num);
					target.OnUnregistered();
					RaiseEvent(this.TargetDied, target);
					RaiseEvent(this.TargetUnregistered, target);
				}
			}
		}

		private void RaiseEvent(EventHandler<TargetEventArgs> handler, Target target)
		{
			try
			{
				handler?.Invoke(this, new TargetEventArgs(target));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
