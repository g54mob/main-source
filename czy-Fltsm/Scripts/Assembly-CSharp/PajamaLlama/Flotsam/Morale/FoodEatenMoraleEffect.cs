using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Food Eaten")]
	public class FoodEatenMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class FoodEatenPersistentData : BasePersistentData
		{
			public int LastFoodItemIndex;

			public FoodEatenPersistentData(FoodEatenMoraleEffect moraleEffect)
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
		private ItemQuality _itemQuality;

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

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
			GameEventDispatcher.RemoveListener(GameEventType.AgentAteNoFood, OnNoFood);
			GameEventDispatcher.RemoveListener(GameEventType.AgentAteFood, OnFood);
		}

		private void OnFood(GameEvent gameEvent)
		{
			if (gameEvent is AgentItemPropertiesEvent agentItemPropertiesEvent && agentItemPropertiesEvent.Agent == _agent)
			{
				LastFoodItem = agentItemPropertiesEvent.ItemProperties;
				if (LastFoodItem.Quality == _itemQuality)
				{
					Activate();
				}
			}
		}

		private void OnNoFood(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				Deactivate();
			}
		}

		protected override void Activate()
		{
			base.Activate();
		}

		protected override void Deactivate()
		{
			LastFoodItem = null;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			if (LastFoodItem == null)
			{
				return false;
			}
			return LastFoodItem.Quality == _itemQuality;
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
			if (persistentData.TryReturnCast<FoodEatenPersistentData>(out var persistentData2))
			{
				if (persistentData2.LastFoodItemIndex >= 0 && GameManager.PersistenceManager.TryReturnPropertiesReference<ItemProperties>(persistentData2.LastFoodItemIndex, out var reference))
				{
					LastFoodItem = reference;
				}
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new FoodEatenPersistentData(this);
		}
	}
}
