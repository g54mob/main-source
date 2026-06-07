using System;
using ManagementScripts;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;

namespace UIScripts.SettingHandles
{
	public abstract class SettingHandle<TSetting, TType> : ISettingHandle where TSetting : Setting<TType>
	{
		internal TSetting setting;

		[NonSerialized]
		public bool simple;

		[NonSerialized]
		protected bool updatedFromSetting;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public bool changeIsRevertable = true;

		[NonSerialized]
		public bool interactable = true;

		[NonSerialized]
		public UnityEvent<TType> onValueChangedByUser = new UnityEvent<TType>();

		public SettingHandle(TSetting _setting, bool simplified = false)
		{
			setting = _setting;
			simple = simplified;
		}

		public SettingHandle()
		{
		}

		public void OnSettingChanged()
		{
			updatedFromSetting = true;
			UpdateUIElement();
			updatedFromSetting = false;
		}

		public void ResetValue()
		{
			setting.ResetValue();
		}

		public void SetValue(TType _val)
		{
			SetValue(_val, changeIsRevertable);
		}

		public void SetValue(TType _val, bool revertable)
		{
			if (updatedFromSetting)
			{
				updatedFromSetting = false;
				return;
			}
			if (revertable && initialized)
			{
				UINavigationManager.AddRevertableActionToStack(new ChangeSettingHandleAction<TSetting, TType>(this, setting.val, _val));
			}
			setting.SetValue(_val);
		}

		public TType GetValue()
		{
			return setting.val;
		}

		public void SetValueNoUIUpdate(TType _val)
		{
			setting.SetValue(_val);
		}

		public abstract void CreateUIElement(GameObject _parent);

		public virtual void InitUIElement()
		{
			setting.OnChange.AddListener(OnSettingChanged);
		}

		public abstract void UpdateUIElement();

		public virtual void ReleaseDependencies()
		{
			setting.OnChange.RemoveListener(OnSettingChanged);
		}

		public abstract void HideUIElement();

		public abstract void ShowUIElement();

		public virtual void SetInteractable(bool isInteractable)
		{
			interactable = isInteractable;
		}
	}
}
