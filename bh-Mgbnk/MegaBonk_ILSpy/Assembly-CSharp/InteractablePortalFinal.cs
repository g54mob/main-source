using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Steam;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class InteractablePortalFinal : BaseInteractable
{
	private sealed class _003CDoFinishGame_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InteractablePortalFinal _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoFinishGame_003Ed__3(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0373: Expected I4, but got I8
			//IL_0420: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_00cb: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj == 1)
					{
						_003C_003E1__state = -1;
						UiManager instance = UiManager.Instance;
						if ((object)UiManager.Instance == null || (object)instance.deathScreen == null)
						{
							goto IL_0412;
						}
						instance.deathScreen.ShowStats();
					}
					return false;
				}
				_003C_003E1__state = -1;
				MyTime.Pause();
				Action action = delegate
				{
					GameObject gameObject = PlayerCamera.Instance.gameObject;
					gameObject.SetActive(value: false);
					GameObject gameObject2 = _003C_003E4__this.cameraCircling.gameObject;
					gameObject2.SetActive(value: true);
					UiManager instance4 = UiManager.Instance;
					instance4.hud.SetActive(value: false);
				};
				if ((object)TransitionUI.Instance != null)
				{
					TransitionUI.Instance.StartTransition(action);
					int stat = RunStats.GetStat(EMyStat.kills);
					Leaderboards.UploadScore(stat);
					SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
					if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
					{
						ProgressionSaveFile progression = saveManager.progression;
						if (saveManager.progression != null)
						{
							MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
							if ((object)MapController._003CcurrentMap_003Ek__BackingField != null && progression.menuMeta != null)
							{
								MapProgress mapProgress = progression.menuMeta.GetMapProgress(mapData.eMap);
								int stat2 = RunStats.GetStat(EMyStat.kills);
								if (mapProgress != null)
								{
									mapProgress.SetKills(stat2);
									SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
									if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
									{
										ProgressionSaveFile progression2 = saveManager2.progression;
										if (saveManager2.progression != null)
										{
											MapData mapData2 = MapController._003CcurrentMap_003Ek__BackingField;
											if ((object)MapController._003CcurrentMap_003Ek__BackingField != null && progression2.menuMeta != null)
											{
												MapProgress mapProgress2 = progression2.menuMeta.GetMapProgress(mapData2.eMap);
												MyPlayer instance2 = MyPlayer.Instance;
												if ((object)MyPlayer.Instance != null)
												{
													RunConfig runConfig = MapController.runConfig;
													if (MapController.runConfig != null && mapProgress2 != null)
													{
														mapProgress2.OnRunFinished(instance2.character, victory: true, runConfig.mapTierIndex);
														WaitForSeconds waitForSeconds = new WaitForSeconds(3f);
														_003C_003E2__current = waitForSeconds;
														_003C_003E1__state = 2;
														goto IL_049d;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				GameManager instance3 = GameManager.Instance;
				if ((object)GameManager.Instance != null)
				{
					instance3.cutscene = true;
					if ((object)MyPlayer.Instance != null)
					{
						MyPlayer.Instance.TeleportPlayerNextStage();
						if ((object)GameManager.Instance != null)
						{
							GameManager.Instance.OnTeleportAway();
							WaitForSeconds waitForSeconds2 = new WaitForSeconds(2f);
							_003C_003E2__current = waitForSeconds2;
							_003C_003E1__state = 1;
							goto IL_049d;
						}
					}
				}
			}
			goto IL_0412;
			IL_049d:
			return true;
			IL_0412:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private bool done;

	public GameObject cameraCircling;

	public override bool Interact()
	{
		//IL_00a5: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C65]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!done)
		{
			done = true;
			_003CDoFinishGame_003Ed__3 obj = new _003CDoFinishGame_003Ed__3(0);
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				gameObject.tag = "Untagged";
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private IEnumerator DoFinishGame()
	{
		_003CDoFinishGame_003Ed__3 obj = new _003CDoFinishGame_003Ed__3(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C67]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "FINAL_PORTAL");
	}

	public InteractablePortalFinal()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}

	private void _003CDoFinishGame_003Eb__3_0()
	{
		GameObject gameObject = PlayerCamera.Instance.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = cameraCircling.gameObject;
		gameObject2.SetActive(value: true);
		UiManager instance = UiManager.Instance;
		instance.hud.SetActive(value: false);
	}
}
