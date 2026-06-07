using System;
using System.Linq;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class BreakableObjectScript : MonoBehaviour, INetworkStateReceiver
	{
		public class DamageReceivedEventArgs
		{
			public float Damage { get; set; }

			public DamageType DamageType { get; set; }

			public int? PlayerId { get; set; }
		}

		[SerializeField]
		private float _breakThreshold = 100f;

		private bool _broken;

		private int _currentDamage;

		[SerializeField]
		private float _damageAbsorption = 75f;

		[SerializeField]
		private BreakableObjectScript[] _parents;

		private int _receiverId;

		private INetworkStateRegistry _stateRegistry;

		public int ReceiverId => _receiverId;

		public Rigidbody RigidBody => null;

		public event EventHandler<DamageReceivedEventArgs> LocalDamageReceived;

		[ContextMenu("Break")]
		public void Break()
		{
			DamageReceivedEventArgs eventArgs = new DamageReceivedEventArgs
			{
				DamageType = DamageType.Unknown,
				Damage = _breakThreshold + _damageAbsorption,
				PlayerId = null
			};
			OnLocalDamageReceived(this, eventArgs);
		}

		[ContextMenu("Heal")]
		public void Heal()
		{
			if (_parents == null || !_parents.Any((BreakableObjectScript x) => x._broken))
			{
				_stateRegistry.SetState(this, 0);
			}
		}

		public void SetState(int state, bool initialValue)
		{
			if (!_broken)
			{
				_currentDamage = state;
				if ((float)_currentDamage >= _breakThreshold)
				{
					_broken = true;
					OnBroken(initialValue);
				}
			}
			else if (state < _currentDamage)
			{
				_broken = false;
				_currentDamage = state;
				OnHealed();
			}
		}

		protected virtual void OnBroken(bool initialValue)
		{
		}

		protected virtual void OnDestroy()
		{
			if (_parents != null)
			{
				BreakableObjectScript[] parents = _parents;
				for (int i = 0; i < parents.Length; i++)
				{
					parents[i].LocalDamageReceived -= OnLocalDamageReceived;
				}
			}
			_stateRegistry.Unregister(this);
		}

		protected virtual void OnHealed()
		{
		}

		protected virtual void Start()
		{
			_stateRegistry = FlightSceneScript.Instance.NetworkStateRegistry;
			_receiverId = _stateRegistry.Register(this, Utilities.GetFullObjectHierarchy(base.transform));
			BreakableObjectDamageHandlerScript[] componentsInChildren = GetComponentsInChildren<BreakableObjectDamageHandlerScript>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].LocalDamageReceived += OnLocalDamageReceived;
			}
			if (_parents != null)
			{
				BreakableObjectScript[] parents = _parents;
				for (int i = 0; i < parents.Length; i++)
				{
					parents[i].LocalDamageReceived += OnLocalDamageReceived;
				}
			}
		}

		private void OnLocalDamageReceived(object sender, DamageReceivedEventArgs eventArgs)
		{
			if (!_broken)
			{
				int num = (int)(eventArgs.Damage - _damageAbsorption);
				if (num > 0)
				{
					_stateRegistry.AddState(this, num);
					this.LocalDamageReceived?.Invoke(this, eventArgs);
				}
			}
		}
	}
}
