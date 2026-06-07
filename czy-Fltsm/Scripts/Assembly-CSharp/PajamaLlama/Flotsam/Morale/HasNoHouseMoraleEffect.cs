using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Has No House")]
	public class HasNoHouseMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class HasNoHousePersistentData : BasePersistentData
		{
			public HasNoHousePersistentData(HasNoHouseMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		public bool HasNoHouse { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			HasNoHouse = agent.ReservedHouse == null;
			GameEventDispatcher.AddListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentHouseUpdated, OnHouseUpdated);
		}

		private void OnHouseUpdated(GameEvent gameEvent)
		{
			if (!(gameEvent is AgentEvent agentEvent) || !(agentEvent.Agent == _agent))
			{
				return;
			}
			bool flag = _agent.ReservedHouse == null;
			if (flag != HasNoHouse)
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
			HasNoHouse = true;
			base.Activate();
		}

		protected override void Deactivate()
		{
			HasNoHouse = false;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			return HasNoHouse;
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
			if (!persistentData.TryReturnCast<HasNoHousePersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new HasNoHousePersistentData(this);
		}
	}
}
