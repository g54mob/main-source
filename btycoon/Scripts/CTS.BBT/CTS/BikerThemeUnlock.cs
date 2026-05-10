using System.Collections;
using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public class BikerThemeUnlock : CTSBehaviour
	{
		[SerializeField]
		private SettingObject<bool> _bikerUnlockSetting;

		[SerializeField]
		private UIMessageBase _uiMessage;

		private IEnumerator Start()
		{
			yield return Coroutines.WaitForSeconds(5f);
			if (GameMode.StartMode == EGameMode.FreeMode && !_bikerUnlockSetting.GetValue())
			{
				_bikerUnlockSetting.SetValue(value: true);
				CTSSingleton<UIMessage>.Instance.ShowMessage(_uiMessage);
			}
			if (_bikerUnlockSetting.GetValue())
			{
				UnlockingManager.AddUnlockKey(EUnlockKey.BikerBarPackage);
			}
		}
	}
}
