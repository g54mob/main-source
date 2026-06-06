using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Food")]
	public class FoodMoraleEffect : MoraleEffect
	{
		[Serializable]
		private class Effect
		{
			public int Modifier;

			public LocalizedString Description;

			public Sprite Icon;
		}

		[Serializable]
		private class QualityEffect
		{
			public ItemQuality Quality;

			public Effect Effect;
		}

		[Serializable]
		public class PersistentData : BasePersistentData
		{
			public int LastFoodItemIndex;

			public PersistentData(FoodMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
				if (moraleEffect.LastFoodItem == null)
				{
					LastFoodItemIndex = -1;
				}
				else
				{
					LastFoodItemIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(moraleEffect.LastFoodItem);
				}
			}
		}

		[SerializeField]
		private QualityEffect[] _qualityEffects;

		[SerializeField]
		private Effect _favouriteEffect;

		private Diet _diet;

		private Effect _activeEffect;

		public ItemProperties LastFoodItem { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			LastFoodItem = null;
			GameEventDispatcher.AddListener(GameEventType.AgentAteNoFood, OnNoFood);
			GameEventDispatcher.AddListener(GameEventType.AgentAteFood, OnFood);
		}

		public override void Destroy()
		{
			base.Destroy();
			GameEventDispatcher.RemoveListener(GameEventType.AgentAteNoFood, OnNoFood);
			GameEventDispatcher.RemoveListener(GameEventType.AgentAteFood, OnFood);
		}

		private void SetLastFoodItem(ItemProperties itemProperties)
		{
			if (_diet != null || _agent.Vitals.TryReturnDiet(VitalType.Hunger, out _diet))
			{
				LastFoodItem = itemProperties;
				if (_diet.Favourite != null && _diet.Favourite.ItemProperties == LastFoodItem)
				{
					_activeEffect = _favouriteEffect;
				}
				else if (!TryReturnQualityEffect(LastFoodItem, out _activeEffect))
				{
					_activeEffect = null;
					Deactivate();
					return;
				}
				Activate();
			}
		}

		private void OnFood(GameEvent gameEvent)
		{
			if (gameEvent is AgentItemPropertiesEvent agentItemPropertiesEvent && agentItemPropertiesEvent.Agent == _agent)
			{
				SetLastFoodItem(agentItemPropertiesEvent.ItemProperties);
			}
		}

		private void OnNoFood(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				_activeEffect = null;
				Deactivate();
			}
		}

		public override bool IsActive()
		{
			return _activeEffect != null;
		}

		public override string ReturnDescription()
		{
			if (_activeEffect == null)
			{
				return string.Empty;
			}
			return _activeEffect.Description;
		}

		public override int ReturnModifier()
		{
			if (!IsActive())
			{
				return 0;
			}
			return _activeEffect.Modifier;
		}

		public override Sprite ReturnSprite()
		{
			if (_activeEffect == null)
			{
				return null;
			}
			return _activeEffect.Icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = null;
			return false;
		}

		private bool TryReturnQualityEffect(ItemProperties itemProperties, out Effect effect)
		{
			QualityEffect[] qualityEffects = _qualityEffects;
			foreach (QualityEffect qualityEffect in qualityEffects)
			{
				if (qualityEffect.Quality == itemProperties.Quality)
				{
					effect = qualityEffect.Effect;
					return true;
				}
			}
			effect = null;
			return false;
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new PersistentData(this);
		}

		public override void Restore(BasePersistentData basePersistentData)
		{
			if (basePersistentData is PersistentData persistentData && -1 < persistentData.LastFoodItemIndex && GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(persistentData.LastFoodItemIndex, out var reference))
			{
				SetLastFoodItem(reference);
			}
		}
	}
}
