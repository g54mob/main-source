using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParentalControlManager
{
	public IParentalControl IParentalControl;

	private PlatformInterface _platformInterface;

	private Dictionary<string, string> _cachedRestrictedInput = new Dictionary<string, string>();

	public ParentalControlManager()
	{
		IParentalControl = new DummyParentalControl();
		Manager.RunAfterInitComplete(UpdateParentalControls());
	}

	private IEnumerator UpdateParentalControls()
	{
		while (true)
		{
			IParentalControl.UpdateInfo();
			yield return new WaitForSecondsRealtime(300f);
		}
	}

	public void RestrictInput(string textInput, Action<string> callback)
	{
		if (string.IsNullOrEmpty(textInput))
		{
			Debug.LogWarning("ParentalControlManager.RestrictInput: tried to restrict text input for a null or empty string.");
			callback?.Invoke(textInput);
			return;
		}
		if (_cachedRestrictedInput.TryGetValue(textInput, out var value))
		{
			callback?.Invoke(value);
			return;
		}
		IParentalControl.RestrictInput(textInput, delegate(string result)
		{
			Debug.Log("ParentalControlManager.RestrictInput: original - " + textInput + ", filtered - " + result + ".");
			_cachedRestrictedInput.TryAdd(textInput, result);
			callback?.Invoke(result);
		});
	}

	public void CommunicationAllowed(bool showUI, Action<bool> callback)
	{
		callback?.Invoke(IParentalControl.CommunicationAllowed(showUI));
	}

	public void CommunicationAllowed(bool showUI, PlayerController[] playerControllers, Action<bool> callback)
	{
		IParentalControl.FriendInfo[] array = (from x in playerControllers
			where x.platformID.GetPlatformOnlineId() != Manager.platform.platformImpl.GetPlatformUserID().GetPlatformOnlineId()
			select new IParentalControl.FriendInfo
			{
				FriendID = x.platformID.GetPlatformOnlineId(),
				Platform = x.platform
			}).ToArray();
		if (array.Length == 0)
		{
			callback?.Invoke(obj: true);
		}
		else
		{
			CommunicationAllowed(showUI, array, callback);
		}
	}

	public void CommunicationAllowed(bool showUI, IParentalControl.FriendInfo[] friendInfos, Action<bool> callback)
	{
		IParentalControl.CommunicationAllowed(showUI, friendInfos, callback);
	}

	public bool AllowCrossPlay(bool showUI)
	{
		if (Manager.prefs.crossPlay)
		{
			return IParentalControl.CrossPlayAllowed(showUI);
		}
		return false;
	}
}
