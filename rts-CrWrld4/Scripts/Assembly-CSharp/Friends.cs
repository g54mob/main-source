using System.Collections.Generic;
using Galaxy.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Friends : MonoBehaviour
{
	private class FriendListListener : GlobalFriendListListener
	{
		public bool retrieved;

		public override void OnFriendListRetrieveSuccess()
		{
		}

		public override void OnFriendListRetrieveFailure(FailureReason failureReason)
		{
		}
	}

	private class RichPresenceChangeListener : GlobalRichPresenceChangeListener
	{
		public override void OnRichPresenceChangeSuccess()
		{
		}

		public override void OnRichPresenceChangeFailure(FailureReason failureReason)
		{
		}
	}

	private Dictionary<string, string> sceneToRichPresenceDict;

	private FriendListListener friendListListener;

	private RichPresenceChangeListener richPresenceChangeListener;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void ListenersInit()
	{
	}

	private void ListenersDispose()
	{
	}

	public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
	}

	public uint GetFriendCount()
	{
		return 0u;
	}

	public GalaxyID GetFriendByIndex(uint index)
	{
		return null;
	}

	public string GetMyUsername(bool silent = false)
	{
		return null;
	}

	public string GetFriendPersonaName(GalaxyID galaxyID)
	{
		return null;
	}

	public PersonaState GetFriendPersonaState(GalaxyID galaxyID)
	{
		return default(PersonaState);
	}

	public void SetRichPresence(string key, string value)
	{
	}
}
