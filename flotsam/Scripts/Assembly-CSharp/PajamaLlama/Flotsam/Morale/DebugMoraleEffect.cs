using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Debug")]
	public class DebugMoraleEffect : DayTimedMoraleEffect
	{
		[Serializable]
		public class DebugPersistentData : DayTimedPersistentData
		{
			public bool IsDebugging;

			public DebugPersistentData(DebugMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private Sprite _icon;

		public int Modifier { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.AgentMoraleDebug_Add, OnEventAddedTriggered);
			GameEventDispatcher.AddListener(GameEventType.AgentMoraleDebug_Remove, OnEventRemovedTriggered);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentMoraleDebug_Add, OnEventAddedTriggered);
			GameEventDispatcher.RemoveListener(GameEventType.AgentMoraleDebug_Remove, OnEventRemovedTriggered);
		}

		private void OnEventAddedTriggered(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				Modifier++;
				if (Modifier == 0)
				{
					Deactivate();
				}
				else
				{
					Activate();
				}
			}
		}

		private void OnEventRemovedTriggered(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				Modifier--;
				if (Modifier == 0)
				{
					Deactivate();
				}
				else
				{
					Activate();
				}
			}
		}

		protected override void Activate()
		{
			base.Activate();
		}

		protected override void Deactivate()
		{
			Modifier = 0;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			if (base.IsActive())
			{
				return Modifier != 0;
			}
			return false;
		}

		public override int ReturnModifier()
		{
			return Modifier;
		}

		public override string ReturnDescription()
		{
			return "Debug Morale Modifer";
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
			base.Restore(persistentData);
			if (!persistentData.TryReturnCast<DebugPersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new DebugPersistentData(this);
		}
	}
}
