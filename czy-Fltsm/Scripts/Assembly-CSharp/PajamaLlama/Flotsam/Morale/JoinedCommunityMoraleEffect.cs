using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Joined Town")]
	public class JoinedCommunityMoraleEffect : DayTimedMoraleEffect
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
			GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnCommunityJoin);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnCommunityJoin);
		}

		private void OnCommunityJoin(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent && _agent.Community.IsPlayerCommunity())
			{
				Activate();
			}
		}

		public override bool IsActive()
		{
			if (base.IsActive())
			{
				return _agent.InPlayerCommunity();
			}
			return false;
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
