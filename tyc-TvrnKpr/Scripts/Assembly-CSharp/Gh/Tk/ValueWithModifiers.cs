using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class ValueWithModifiers : IPersistable
	{
		[PersistenceOptIn]
		private float _value;

		[PersistenceOptIn]
		private Dictionary<string, FloatModifier> _modifiers;

		[PersistenceOptIn]
		public string DisplayName { get; private set; }

		[PersistenceOptIn]
		public string Description { get; set; }

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

		[PersistenceOptIn]
		public string BaseValueHint { get; set; }

		public float Value => 0f;

		public float AggregatedFactor => 0f;

		public Dictionary<string, FloatModifier> Modifiers => null;

		public event EventHandler<EventArgs<float>> ValueChanged
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

		protected ValueWithModifiers()
		{
		}

		public ValueWithModifiers(string displayName)
		{
		}

		protected virtual void OnValueChanged()
		{
		}

		public void SetModifier(string key, float value, string displayNameKey = null)
		{
		}
	}
}
