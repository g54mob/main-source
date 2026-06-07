using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Has House")]
	public class HasHouseMoraleEffect : MoraleEffect
	{
		[Serializable]
		private struct HouseModifier
		{
			public BuildableProperties HouseProperties;

			public int Modifier;

			public LocalizedString Description;
		}

		[Serializable]
		public class HasHousePersistentData : BasePersistentData
		{
			public HasHousePersistentData(HasHouseMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private HouseModifier[] _modifiers;

		private HouseModifier _houseModifier;

		private bool _active;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			_active = agent.ReservedHouse != null;
			GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		}

		private void OnHouseUpdated(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				if (_agent.ReservedHouse != null && TryReturnModifier(_agent.ReservedHouse, out _houseModifier))
				{
					Activate();
				}
				else
				{
					Deactivate();
				}
			}
		}

		protected override void Activate()
		{
			if (!_active)
			{
				_active = true;
				base.Activate();
			}
		}

		protected override void Deactivate()
		{
			if (_active)
			{
				_active = false;
				base.Deactivate();
			}
		}

		public override bool IsActive()
		{
			return _active;
		}

		public override int ReturnModifier()
		{
			return _houseModifier.Modifier;
		}

		public override string ReturnDescription()
		{
			return _houseModifier.Description;
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = null;
			return false;
		}

		private bool TryReturnModifier(House house, out HouseModifier modifier)
		{
			for (int i = 0; i < _modifiers.Length; i++)
			{
				modifier = _modifiers[i];
				if (house.Buildable.Properties == modifier.HouseProperties)
				{
					return true;
				}
			}
			modifier = default(HouseModifier);
			return false;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (!persistentData.TryReturnCast<HasHousePersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new HasHousePersistentData(this);
		}
	}
}
