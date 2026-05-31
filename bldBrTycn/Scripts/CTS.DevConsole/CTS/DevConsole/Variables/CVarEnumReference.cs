using System;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	public class CVarEnumReference<TEnum> : ISerializationCallbackReceiver where TEnum : unmanaged, Enum
	{
		[SerializeField]
		private CVarEnumReferenceAsset _enumValue;

		[SerializeField]
		private string _genericType;

		protected event Action<TEnum> OnValueChanged;

		public CVarEnumReference()
		{
			_genericType = GetType().GenericTypeArguments[0].AssemblyQualifiedName;
		}

		~CVarEnumReference()
		{
			if ((object)_enumValue != null)
			{
				_enumValue.UnsubscribeToChange(OnInternalValueChanged);
			}
		}

		public static implicit operator TEnum(CVarEnumReference<TEnum> varEnum)
		{
			return varEnum.GetCurrentValue();
		}

		public void SubscribeToChange(Action<TEnum> action)
		{
			UnsubscribeToChange(action);
			OnValueChanged += action;
		}

		public void UnsubscribeToChange(Action<TEnum> action)
		{
			OnValueChanged -= action;
		}

		public TEnum GetCurrentValue()
		{
			return (TEnum)_enumValue.GetCurrentValue();
		}

		public void SetCurrentValue(TEnum newValue)
		{
			_enumValue.SetCurrentValue(newValue);
		}

		public void ResetDefaultValue()
		{
			_enumValue.ResetDefaultValue();
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			if ((bool)_enumValue)
			{
				_enumValue.SubscribeToChange(OnInternalValueChanged);
			}
		}

		internal void OnInternalValueChanged(Enum newValue)
		{
			this.OnValueChanged?.Invoke(GetCurrentValue());
		}
	}
}
