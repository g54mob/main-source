using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomItemEctoVatComponent : EntityComponent
	{
		[SerializeField]
		private float _useIncrement = 1f;

		[SerializeField]
		private float _useDecrement = 1f;

		[SerializeField]
		private float _maxCapacity = 10f;

		public float MinToDropOff = 2f;

		[SerializeField]
		private float _janitorSearchRadius = 10f;

		public ExternalBehavior Behaviour;

		private RoomItem _roomItem;

		private static List<RoomItemEctoVatComponent> _ectoVats = new List<RoomItemEctoVatComponent>();

		public float Amount { get; private set; }

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			Amount = 0f;
			_roomItem = GetOwner<RoomItem>();
			RoomItem roomItem = _roomItem;
			roomItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(roomItem.OnInteractionStarted, new Action<Character>(OnInteractionStarted));
			_ectoVats.Add(this);
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RoomItem roomItem = _roomItem;
			roomItem.OnInteractionStarted = (Action<Character>)Delegate.Combine(roomItem.OnInteractionStarted, new Action<Character>(OnInteractionStarted));
			_ectoVats.Add(this);
			if (_roomItem.Visual != null)
			{
				SyncParticleSystem();
			}
			else
			{
				_roomItem.OnVisualSet += SyncParticleSystem;
			}
		}

		public override void Destroy()
		{
			_ectoVats.Remove(this);
			RoomItem roomItem = _roomItem;
			roomItem.OnInteractionStarted = (Action<Character>)Delegate.Remove(roomItem.OnInteractionStarted, new Action<Character>(OnInteractionStarted));
			_roomItem.OnVisualSet -= SyncParticleSystem;
			base.Destroy();
		}

		private void OnInteractionStarted(Character character)
		{
			CarryEctoplasmComponent component = character.GetComponent<CarryEctoplasmComponent>();
			if (component != null)
			{
				Amount += _useIncrement * (float)component.Amount;
				component.Amount = 0;
			}
			else
			{
				Amount -= _useDecrement;
			}
			Amount = Mathf.Clamp(Amount, 0f, _maxCapacity);
			SyncParticleSystem();
		}

		private void SyncParticleSystem()
		{
			_roomItem.OnVisualSet -= SyncParticleSystem;
			ParticleSystem componentInChildren = _roomItem.Visual.GameObject.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != null)
			{
				ParticleSystem.MainModule main = componentInChildren.main;
				main.maxParticles = (int)Amount;
				componentInChildren.Play();
			}
		}

		private bool IsFull()
		{
			return Amount >= _maxCapacity;
		}

		public static RoomItemEctoVatComponent Find(Vector3 position)
		{
			float num = float.MaxValue;
			RoomItemEctoVatComponent result = null;
			foreach (RoomItemEctoVatComponent ectoVat in _ectoVats)
			{
				if (!ectoVat.IsFull())
				{
					float num2 = ectoVat._janitorSearchRadius * ectoVat._janitorSearchRadius;
					float num3 = ectoVat._roomItem.WorldPosition.SquareDistance2D(position);
					if (num3 < num2 && num3 < num)
					{
						result = ectoVat;
						num = num3;
					}
				}
			}
			return result;
		}
	}
}
