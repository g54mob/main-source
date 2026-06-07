using UnityEngine;

namespace ModularOptions
{
	public abstract class OptionBase<T, U> : MonoBehaviour where T : struct where U : UIDataType<T>
	{
		[Tooltip("Key for saving & loading, with other possible re-use.")]
		public string optionName;

		public U defaultSetting;

		[HideInInspector]
		public OptionPreset preset;

		protected bool allowPresetCallback;

		public abstract T Value { get; set; }

		public void ApplyPreset(T _value)
		{
		}

		protected abstract void ApplySetting(T _value);
	}
}
