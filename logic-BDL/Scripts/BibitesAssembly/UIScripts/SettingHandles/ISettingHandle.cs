using UnityEngine;

namespace UIScripts.SettingHandles
{
	public interface ISettingHandle
	{
		void ResetValue();

		void CreateUIElement(GameObject _parent);

		void UpdateUIElement();

		void ReleaseDependencies();

		void InitUIElement();

		void HideUIElement();

		void ShowUIElement();

		void SetInteractable(bool isInteractable);
	}
}
