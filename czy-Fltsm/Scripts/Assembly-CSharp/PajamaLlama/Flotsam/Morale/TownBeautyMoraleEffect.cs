using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Town Beauty Morale Effect")]
	public class TownBeautyMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class PersistentData : BasePersistentData
		{
			public PersistentData(TownBeautyMoraleEffect instance)
				: base(instance)
			{
			}
		}

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private MoraleEffectModifierThreshold[] _modifierThresholds;

		private Community _community;

		private int _modifier;

		private LocalizedString _description = null;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToCommunity);
			SetCommunity(agent);
		}

		public override void Destroy()
		{
			base.Destroy();
			GameEventDispatcher.RemoveListener(GameEventType.AgentAddedToPlayerCommunity, OnAgentAddedToCommunity);
			if (_community != null)
			{
				_community.BeautyScoreUpdated -= UpdateModifier;
			}
		}

		public override bool IsActive()
		{
			return _modifier != 0;
		}

		public override string ReturnDescription()
		{
			return _description;
		}

		public override int ReturnModifier()
		{
			return _modifier;
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

		private void OnAgentAddedToCommunity(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				SetCommunity(_agent);
			}
		}

		private void SetCommunity(Agent agent)
		{
			if (_community != null)
			{
				_community.BeautyScoreUpdated -= UpdateModifier;
			}
			_community = agent.Community;
			if (_community != null)
			{
				_community.BeautyScoreUpdated += UpdateModifier;
			}
			UpdateModifier();
		}

		private void UpdateModifier()
		{
			_modifier = 0;
			if (_community == null)
			{
				return;
			}
			MoraleEffectModifierThreshold[] modifierThresholds = _modifierThresholds;
			for (int i = 0; i < modifierThresholds.Length; i++)
			{
				MoraleEffectModifierThreshold moraleEffectModifierThreshold = modifierThresholds[i];
				if (moraleEffectModifierThreshold.Threshold <= (float)_community.BeautyScore)
				{
					_modifier = moraleEffectModifierThreshold.Modifier;
					_description = moraleEffectModifierThreshold.Description;
				}
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new PersistentData(this);
		}

		public override void Restore(BasePersistentData persistentData)
		{
		}
	}
}
