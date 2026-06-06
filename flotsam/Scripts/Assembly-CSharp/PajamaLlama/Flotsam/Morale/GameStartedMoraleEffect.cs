using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Game Started")]
	public class GameStartedMoraleEffect : DayTimedMoraleEffect
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
			GameEventDispatcher.AddListener(GameEventType.NewGameStart, OnGameStart);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.NewGameStart, OnGameStart);
		}

		private void OnGameStart(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent && _agent.Community.IsPlayerCommunity())
			{
				Activate();
			}
		}

		public override bool IsActive()
		{
			if (_agent.Community.IsPlayerCommunity())
			{
				return base.IsActive();
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
