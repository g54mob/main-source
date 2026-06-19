using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModIO;
using ModIO.Implementation.API.Objects;
using ModIO.Util;
using ModIOBrowser;
using Steamworks;
using UnityEngine;

public class RadicalMainMenuOption_OpenMods : RadicalPauseMenuOption
{
	private List<long> _installedMods = new List<long>();

	private List<string> _modsWithEnhancedAccess = new List<string>();

	private HashSet<long> _subscribeRequests = new HashSet<long>();

	protected override void Awake()
	{
		if (Manager.platform.platformImpl is SteamPlatform)
		{
			Browser.SetupSteamAuthenticationOption(delegate(Action<string> code)
			{
				StartCoroutine(SteamLoginCoroutine(code));
			});
		}
		Mods.OnModManagementEvent = (ModManagementEventDelegate)Delegate.Combine(Mods.OnModManagementEvent, new ModManagementEventDelegate(ModManagementEventCallback));
		base.Awake();
	}

	private IEnumerator SteamLoginCoroutine(Action<string> callback)
	{
		Task<byte[]> requestEncryptedAppTicketTask = SteamUser.RequestEncryptedAppTicketAsync();
		while (!requestEncryptedAppTicketTask.IsCompleted)
		{
			yield return null;
		}
		if (!requestEncryptedAppTicketTask.IsCompletedSuccessfully)
		{
			Debug.LogError($"failed to get encrypted steam app ticket: {requestEncryptedAppTicketTask.Status}");
			callback(null);
		}
		else
		{
			byte[] result = requestEncryptedAppTicketTask.Result;
			string obj = ModIO.Util.Utility.EncodeEncryptedSteamAppTicket(result, (uint)result.Length);
			callback(obj);
		}
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (!Manager.platform.parentalControlManager.IParentalControl.UGCAllowed(showUI: true))
		{
			return;
		}
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ModMenuPopUp", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
		{
			if (response.IsConfirm)
			{
				OpenModUI();
			}
		}, new List<string> { "cancelDialogue", "continue" }, 10f, 0.8f, 0, 20f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0.2f);
	}

	private void SubToDependencies()
	{
		ModIO.Result result;
		SubscribedMod[] subscribedMods = ModIOUnity.GetSubscribedMods(out result);
		if (!result.Succeeded())
		{
			Debug.Log($"failed to get existing mods: {result.message} (code: {result.errorCode})");
			return;
		}
		HashSet<long> modSet = new HashSet<long>(subscribedMods.Select((SubscribedMod x) => x.modProfile.id.id));
		SubscribedMod[] array = subscribedMods;
		for (int num = 0; num < array.Length; num++)
		{
			SubscribedMod mod = array[num];
			if (!mod.enabled)
			{
				continue;
			}
			ModIOUnity.GetModDependencies(mod.modProfile.id, delegate(ResultAnd<ModDependencies[]> resultDependencies)
			{
				result = resultDependencies.result;
				if (!result.Succeeded())
				{
					object[] obj = new object[4]
					{
						mod.modProfile.name,
						null,
						null,
						null
					};
					ModId id = mod.modProfile.id;
					obj[1] = id.id;
					obj[2] = result.message;
					obj[3] = result.errorCode;
					Debug.Log(string.Format("failed to get dependencies for {0}:{1}: {2} (code: {3})", obj));
				}
				else
				{
					ModDependencies[] value = resultDependencies.value;
					for (int i = 0; i < value.Length; i++)
					{
						ModDependencies dep = value[i];
						if (!modSet.Contains(dep.modId) && !_subscribeRequests.Contains(dep.modId))
						{
							_subscribeRequests.Add(dep.modId);
							ModIOUnity.SubscribeToMod(dep.modId, delegate(ModIO.Result result2)
							{
								_subscribeRequests.Remove(dep.modId);
								if (!result2.Succeeded())
								{
									Debug.Log($"failed to subscribe to dependency {dep.modId} for {mod.modProfile.name}:{mod.modProfile.id}: {result2.message} (code: {result2.errorCode})");
								}
								ModId modId = dep.modId;
								Debug.Log($"Added dependency id={modId.id} from {mod.modProfile.name}");
							});
						}
					}
				}
			});
		}
	}

	private void ModManagementEventCallback(ModManagementEventType eventType, ModId modId, ModIO.Result eventResult)
	{
		SubToDependencies();
	}

	private void OpenModUI()
	{
		_installedMods.Clear();
		Manager.input.DisableInput();
		Manager.input.DisableSystemInput();
		ModIO.Result result;
		SubscribedMod[] subscribedMods = ModIOUnity.GetSubscribedMods(out result);
		if (result.Succeeded())
		{
			SubscribedMod[] array = subscribedMods;
			for (int i = 0; i < array.Length; i++)
			{
				SubscribedMod subscribedMod = array[i];
				if (subscribedMod.enabled && subscribedMod.status == SubscribedModStatus.Installed)
				{
					_installedMods.Add(subscribedMod.modProfile.id);
				}
			}
		}
		Browser.Open(delegate
		{
			Manager.input.EnableInput();
			Manager.input.EnableSystemInput();
			SubToDependencies();
			Manager.mod.CheckForModChanges(restartIfNeeded: true, forceRestart: false);
		});
	}

	private void ModChanged()
	{
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/RestartToApplyModChanges", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
		{
			if (response.IsConfirm)
			{
				Manager.platform.Restart();
			}
		}, new List<string> { "cancelDialogue", "yes" }, 10f, 0.8f, 0, 20f);
	}
}
