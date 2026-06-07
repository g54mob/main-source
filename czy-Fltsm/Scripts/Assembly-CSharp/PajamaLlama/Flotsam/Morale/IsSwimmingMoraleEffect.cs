using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Is Swimming")]
	public class IsSwimmingMoraleEffect : SecondsTimedMoraleEffect
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
			GameEventDispatcher.AddListener(GameEventType.AgentTerrainChanged, OnTerrainUpdated);
			UpdateTerrain(agent);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentTerrainChanged, OnTerrainUpdated);
		}

		private void OnTerrainUpdated(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent)
			{
				UpdateTerrain(agentEvent.Agent);
			}
		}

		private void UpdateTerrain(Agent agent)
		{
			if (_agent == agent && agent.IsInWater)
			{
				Activate();
			}
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
