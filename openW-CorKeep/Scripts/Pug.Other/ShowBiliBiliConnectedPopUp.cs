using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBiliBiliConnectedPopUp : MonoBehaviour
{
	private static bool _hasChecked;

	private IEnumerator Start()
	{
		if (!_hasChecked)
		{
			_hasChecked = true;
			while (Manager.stream.StreamIntegrationManager.IsConnecting())
			{
				yield return null;
			}
			if (Manager.stream.StreamIntegrationManager.TriedToConnectAtStartup(out var result))
			{
				Debug.Log("bilibili connected at start");
				Manager.menu.centerPopUpText.StartNewDisplaySequence(result ? "Menu/BiliBiliConnectSucceeded" : "Menu/BiliBiliConnectFailed", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
				{
				}, new List<string> { "ok" }, 10f, 0f, 0, 20f);
			}
		}
	}
}
