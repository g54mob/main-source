using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PajamaLlama.Flotsam.Morale
{
	public abstract class MoraleEffect : PersistentProperties, IComparable<MoraleEffect>
	{
		[Serializable]
		public abstract class BasePersistentData
		{
			public int PropertiesIndex;

			public BasePersistentData(MoraleEffect effect)
			{
				PropertiesIndex = effect.PropertiesIndex;
			}

			public bool TryReturnCast<T>(out T persistentData) where T : BasePersistentData
			{
				persistentData = this as T;
				return persistentData != null;
			}
		}

		protected Agent _agent;

		public UnityEvent UpdatedEvent { get; private set; }

		public int PropertiesIndex { get; private set; }

		public override Types Type => Types.MoraleEffect;

		public virtual void Initialize(Agent agent, MoraleEffect properties)
		{
			_agent = agent;
			PropertiesIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(properties);
			UpdatedEvent = new UnityEvent();
		}

		public virtual void Update()
		{
		}

		public virtual void Destroy()
		{
		}

		protected virtual void Activate()
		{
			UpdatedEvent.Invoke();
			AchievementEvent.Dispatch(GameEventType.MoraleEffectActivated, this);
		}

		protected virtual void Deactivate()
		{
			UpdatedEvent.Invoke();
			AchievementEvent.Dispatch(GameEventType.MoraleEffectDeactivated, this);
		}

		public abstract bool IsActive();

		public abstract int ReturnModifier();

		public abstract bool TryReturnAttributeEffect(out DrifterAttributesEffect effect);

		public abstract string ReturnDescription();

		public abstract Sprite ReturnSprite();

		public int CompareTo(MoraleEffect other)
		{
			return other.ReturnModifier().CompareTo(ReturnModifier());
		}

		public abstract void Restore(BasePersistentData persistentData);

		public abstract BasePersistentData ReturnPersistentData();

		protected static string ReturnStackedDescription(string description, int stacks)
		{
			return $"<b>{stacks}x</b> " + description;
		}

		protected static bool TryReturnAttributeEffect(IReadOnlyList<DrifterAttributesEffect> effects, int stacks, out int currentStack, out DrifterAttributesEffect effect)
		{
			effect = null;
			currentStack = 0;
			int count = effects.Count;
			if (count == 0 || stacks <= 0)
			{
				return false;
			}
			currentStack = Mathf.Clamp(stacks, 0, count);
			effect = effects[currentStack - 1];
			return true;
		}
	}
}
