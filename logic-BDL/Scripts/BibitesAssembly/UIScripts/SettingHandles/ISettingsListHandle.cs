using UnityEngine;

namespace UIScripts.SettingHandles
{
	public interface ISettingsListHandle : ISettingHandle
	{
		int GetSettingsCount();

		void CreateUIElements();

		ISettingsListHandle AssignHolder(GameObject _holder);
	}
}
