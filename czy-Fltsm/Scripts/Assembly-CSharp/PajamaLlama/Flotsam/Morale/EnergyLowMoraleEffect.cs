using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Energy Low")]
	public class EnergyLowMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class EnergyLowPersistentData : BasePersistentData
		{
			public EnergyLowPersistentData(EnergyLowMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private float _energyThreshold = 500f;

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		private bool _isUnderThreshold;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.EnergyConsumed, OnEnergyUpdated);
			GameEventDispatcher.AddListener(GameEventType.EnergyProduced, OnEnergyUpdated);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.EnergyConsumed, OnEnergyUpdated);
			GameEventDispatcher.RemoveListener(GameEventType.EnergyProduced, OnEnergyUpdated);
		}

		private void OnEnergyUpdated(GameEvent gameEvent)
		{
			OnEnergyUpdated();
		}

		private void OnEnergyUpdated()
		{
			if (!_agent.Community.IsPlayerCommunity())
			{
				return;
			}
			bool flag = _agent.Community.Engine.EnergyGrid.ReturnStorageEnergy() < _energyThreshold;
			if (flag != _isUnderThreshold)
			{
				if (flag)
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
			_isUnderThreshold = true;
			base.Activate();
		}

		protected override void Deactivate()
		{
			_isUnderThreshold = false;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			return _isUnderThreshold;
		}

		public override int ReturnModifier()
		{
			return _modifier;
		}

		public override string ReturnDescription()
		{
			return _description;
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

		public override void Restore(BasePersistentData persistentData)
		{
			if (!persistentData.TryReturnCast<EnergyLowPersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new EnergyLowPersistentData(this);
		}
	}
}
