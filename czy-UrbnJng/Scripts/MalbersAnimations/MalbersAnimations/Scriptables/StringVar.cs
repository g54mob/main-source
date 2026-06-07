using System;
using UnityEngine;

namespace MalbersAnimations.Scriptables
{
	[CreateAssetMenu(menuName = "Malbers Animations/Variables/String", order = 1000)]
	public class StringVar : ScriptableVar
	{
		[SerializeField]
		private string value = "";

		public Action<string> OnValueChanged = delegate
		{
		};

		public virtual string Value
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
				OnValueChanged(value);
			}
		}

		public virtual void SetValue(StringVar var)
		{
			Value = var.Value;
		}

		public virtual void SetValue(string var)
		{
			Value = var;
		}

		public virtual void SetValue(UnityEngine.Object var)
		{
			Value = var.name;
		}

		public static implicit operator string(StringVar reference)
		{
			return reference.Value;
		}

		public virtual void _Add(string var)
		{
			Value += var;
		}

		public virtual void _Add(StringVar var)
		{
			Value += var.Value;
		}

		public virtual void _Add(char var)
		{
			Value += var;
		}

		public virtual void _Clear()
		{
			Value = string.Empty;
		}

		public virtual void _RemoveFirst()
		{
			if (!string.IsNullOrEmpty(Value))
			{
				string text = Value;
				Value = text.Substring(1, text.Length - 1);
			}
		}

		public virtual void _RemoveLast()
		{
			if (!string.IsNullOrEmpty(Value))
			{
				string text = Value;
				Value = text.Substring(0, text.Length - 1);
			}
		}
	}
}
