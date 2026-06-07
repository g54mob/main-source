using System.Collections.Generic;
using UnityEngine;

namespace UIScripts.SettingHandles
{
	public abstract class SettingsListHandle : ISettingsListHandle, ISettingHandle
	{
		public string GroupTitle = "";

		public GameObject Holder;

		public List<ISettingHandle> Settings;

		public virtual int GetSettingsCount()
		{
			int n = 0;
			Settings?.ForEach(delegate(ISettingHandle _s)
			{
				if (_s is SettingsListHandle settingsListHandle)
				{
					n += settingsListHandle.GetSettingsCount();
				}
				else
				{
					n++;
				}
			});
			return n;
		}

		public ISettingsListHandle AssignHolder(GameObject _holder)
		{
			Holder = _holder;
			return this;
		}

		public virtual void CreateUIElements()
		{
			CreateUIElement(Holder);
		}

		public void ResetValue()
		{
			Settings?.ForEach(delegate(ISettingHandle _s)
			{
				_s.ResetValue();
			});
		}

		public void UpdateUIElement()
		{
			Settings?.ForEach(delegate(ISettingHandle _s)
			{
				_s.UpdateUIElement();
			});
		}

		public abstract void CreateUIElement(GameObject _parent);

		public virtual void ReleaseDependencies()
		{
			Settings?.ForEach(delegate(ISettingHandle s)
			{
				s.ReleaseDependencies();
			});
		}

		public void InitUIElement()
		{
		}

		public abstract void HideUIElement();

		public abstract void ShowUIElement();

		public void SetInteractable(bool isInteractable)
		{
			Settings.ForEach(delegate(ISettingHandle s)
			{
				s.SetInteractable(isInteractable);
			});
		}
	}
}
