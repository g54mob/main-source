using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gh.Tk
{
	public abstract class AiValueWithModifiers : AiComponent
	{
		[PersistenceOptIn]
		private float _minValue;

		[PersistenceOptIn]
		private float _maxValue;

		[PersistenceOptIn]
		protected float _baseValue;

		[PersistenceOptIn]
		private float _effectiveValue;

		[PersistenceOptIn]
		protected List<ValueModifier> _modifiers;

		public float MinValue
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public float MaxValue
		{
			get
			{
				return 0f;
			}
			protected set
			{
			}
		}

		public float BaseValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float EffectiveValue => 0f;

		public event EventHandler EffectiveValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected AiValueWithModifiers()
		{
		}

		protected AiValueWithModifiers(GameObjectX owner)
		{
		}

		public AiValueWithModifiers(GameObjectX owner, string name, string displayNameKey, string descriptionKey, float defaultValue, float minValue, float maxValue)
		{
		}

		public override void Update()
		{
		}

		protected virtual void OnEffectiveValueChanged()
		{
		}

		public void SetFixedModifier(string key, float value, string displayReasonKey)
		{
		}

		public void SetModifier(string key, float value, bool isPercentageModifier, string displayReasonKey, float expiresAt = 0f)
		{
		}

		private void InvalidateValue()
		{
		}

		public void RemoveModifier(string key)
		{
		}

		public virtual string GetCurrentValueLabelKey()
		{
			return null;
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		protected virtual void AppendBaseValueDescription(StringBuilder sb)
		{
		}
	}
}
