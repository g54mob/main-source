using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/No Food")]
	public class NoFoodMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class NoFoodPersistentData : BasePersistentData
		{
			public int DaysWithoutFood;

			public NoFoodPersistentData(NoFoodMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private int _perLevelModifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private DrifterAttributesEffect[] _effects;

		private int _lastValue;

		public int CurrentValue => _agent.Vitals.ReturnVitalAmount(VitalType.Hunger);

		public DrifterAttributesEffect CurrentEffect { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.VitalsUpdated, OnVitalsUpdated);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.VitalsUpdated, OnVitalsUpdated);
		}

		private void OnVitalsUpdated(GameEvent gameEvent)
		{
			int currentValue = CurrentValue;
			if (currentValue != _lastValue)
			{
				UpdateAttributeEffect();
				if (currentValue == 0)
				{
					Deactivate();
				}
				else
				{
					Activate();
				}
				_lastValue = currentValue;
			}
		}

		private void UpdateAttributeEffect()
		{
			ClearCurrentEffect();
			SetCurrentEffect();
		}

		private void SetCurrentEffect()
		{
			if (MoraleEffect.TryReturnAttributeEffect(_effects, CurrentValue, out var _, out var effect))
			{
				CurrentEffect = effect;
				_agent.Attributes.AddEffect(CurrentEffect);
			}
		}

		private void ClearCurrentEffect()
		{
			if (CurrentEffect != null)
			{
				_agent.Attributes.RemoveEffect(CurrentEffect);
				CurrentEffect = null;
			}
		}

		public override bool IsActive()
		{
			return CurrentValue > 0;
		}

		public override int ReturnModifier()
		{
			return _perLevelModifier * CurrentValue;
		}

		public override string ReturnDescription()
		{
			return MoraleEffect.ReturnStackedDescription(_description, CurrentValue);
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = CurrentEffect;
			return effect != null;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (persistentData.TryReturnCast<NoFoodPersistentData>(out var _))
			{
				SetCurrentEffect();
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new NoFoodPersistentData(this);
		}
	}
}
