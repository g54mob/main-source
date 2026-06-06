using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Rescued Drifter")]
	public class DrifterRescuedMoraleEffect : SecondsTimedMoraleEffect
	{
		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.AgentRescue, OnRescue);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentRescue, OnRescue);
		}

		private void OnRescue(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && _agent != agentEvent.Agent && _agent.Community.IsPlayerCommunity())
			{
				Activate();
			}
		}

		protected override void Activate()
		{
			base.Activate();
		}

		protected override void Deactivate()
		{
			base.Deactivate();
		}

		public override bool IsActive()
		{
			return base.IsActive();
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
	}
}
