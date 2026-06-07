using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Affinity Morale Effect")]
	public class AffinityMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class PersistentData : BasePersistentData
		{
			public PersistentData(AffinityMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private float levelsPerPoint;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		private bool _isActive;

		private int _modifier;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
			GameEventDispatcher.AddListener(GameEventType.AgentAttributeLeveled, OnAgentAttributeLeveled);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentAttributeLeveled, OnAgentAttributeLeveled);
		}

		private void OnGameStart(GameEvent gameEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
			UpdateModifier();
		}

		private void OnAgentAttributeLeveled(GameEvent gameEvent)
		{
			if (gameEvent is AttributeEvent attributeEvent && attributeEvent.Agent == _agent)
			{
				UpdateModifier();
			}
		}

		public override bool IsActive()
		{
			return _isActive;
		}

		public override string ReturnDescription()
		{
			return _description;
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override int ReturnModifier()
		{
			return _modifier;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = null;
			return false;
		}

		private void UpdateModifier()
		{
			_modifier = 0;
			DrifterAttributes.AttributeType[] array = DrifterAttributes.ReturnAttributeTypes();
			foreach (DrifterAttributes.AttributeType type in array)
			{
				int num = _agent.Attributes.ReturnAffinityAmount(type);
				int num2 = _agent.Attributes.ReturnAttributeExpertise(type);
				_modifier += Mathf.CeilToInt((float)num2 / levelsPerPoint) * num;
			}
			if (_modifier == 0)
			{
				Deactivate();
			}
			else
			{
				Activate();
			}
		}

		protected override void Activate()
		{
			if (!_isActive)
			{
				_isActive = true;
				base.Activate();
			}
		}

		protected override void Deactivate()
		{
			if (_isActive)
			{
				_isActive = false;
				base.Deactivate();
			}
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (!persistentData.TryReturnCast<PersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
			UpdateModifier();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new PersistentData(this);
		}
	}
}
