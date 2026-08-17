using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Steam.LeaderboardsNew;
using Assets.Scripts.UI.Animation;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class DeathScreen : MonoBehaviour
{
	private sealed class _003CDoTransition_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DeathScreen _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoTransition_003Ed__29(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0336: Expected I4, but got I8
			//IL_053c: Expected I4, but got O
			//IL_0015: Expected O, but got I4
			//IL_0166: Expected I4, but got I8
			//IL_0052: Expected I4, but got I8
			//IL_0405: Expected O, but got I
			//IL_043b: Expected O, but got I
			//IL_02f3: Expected O, but got Ref
			DeathScreen deathScreen = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0151;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)deathScreen.b_continue != null)
					{
						GameObject gameObject = deathScreen.b_continue.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: true);
							if ((object)deathScreen.b_continue != null)
							{
								deathScreen.b_continue.ScaleIn(2f, EEasing.OutCirc);
								if ((object)deathScreen.b_continue != null)
								{
									MyButton component = deathScreen.b_continue.GetComponent<MyButton>();
									ButtonManager.ForceHoverButton(component);
									goto IL_0151;
								}
							}
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this != null && (object)deathScreen.blocksUi != null)
					{
						GameObject gameObject2 = deathScreen.blocksUi.gameObject;
						if ((object)gameObject2 != null)
						{
							gameObject2.SetActive(value: false);
							if ((object)deathScreen.deadUiWindow != null)
							{
								deathScreen.deadUiWindow.SetActive(value: true);
								if ((object)deathScreen.background != null)
								{
									deathScreen.background.SetActive(value: true);
									if ((object)deathScreen.canvasGroup != null)
									{
										GameObject gameObject3 = deathScreen.canvasGroup.gameObject;
										if ((object)gameObject3 != null)
										{
											gameObject3.SetActive(value: true);
											if ((object)deathScreen.canvasGroup != null)
											{
												Transform transform = deathScreen.canvasGroup.transform;
												if ((object)transform != null)
												{
													object obj2 = default(object);
													transform.localScale = (Vector3)(&obj2);
													WaitForSeconds waitForSeconds = new WaitForSeconds(1.2f);
													_003C_003E2__current = waitForSeconds;
													_003C_003E1__state = 2;
													return true;
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
				if ((object)_003C_003E4__this != null)
				{
					Component blocksUi = deathScreen.blocksUi;
					if ((object)deathScreen.blocksUi != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F98]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						_ = 1073741824;
						_ = 1;
						GameObject gameObject4 = deathScreen.blocksUi.gameObject;
						if ((object)gameObject4 != null)
						{
							gameObject4.SetActive(value: true);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v2 (UnityEngine.Component)+20]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v2 (UnityEngine.Component)+20]");
								((Material)0).SetFloat("_Progress", 0f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v2 (UnityEngine.Component)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v2 (UnityEngine.Component)+28]");
									((AudioSource)0).Play();
									if ((object)deathScreen.playerOnlyRender != null)
									{
										GameObject gameObject5 = deathScreen.playerOnlyRender.gameObject;
										if ((object)gameObject5 != null)
										{
											gameObject5.SetActive(value: true);
											PlayerCamera instance = PlayerCamera.Instance;
											if ((object)PlayerCamera.Instance != null && (object)deathScreen.playerOnlyRender != null)
											{
												deathScreen.playerOnlyRender.texture = instance.deathRenderTexture;
												WaitForSeconds waitForSeconds2 = new WaitForSeconds(2f);
												_003C_003E2__current = waitForSeconds2;
												_003C_003E1__state = 1;
												return true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0151:
			return false;
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

	public DeathScreenBlocksUI blocksUi;

	public GameObject deadUiWindow;

	public GameObject statsWindow;

	public GameObject background;

	public GameObject leaderboardsWindow;

	public GameObject victoryScreen;

	public UiAnimation t_dead;

	public UiAnimation b_continue;

	public AudioSource audio;

	public RawImage playerOnlyRender;

	public CanvasGroup canvasGroup;

	private float fadeInTime = 3f;

	private float fadeTimer = -0.2f;

	private bool hasNewRecord;

	private int _003CnewRecordRank_003Ek__BackingField;

	private string _003CnewRecordLbName_003Ek__BackingField;

	private bool tierVictory;

	public GameObject restartBtn;

	public int newRecordRank
	{
		get
		{
			return _003CnewRecordRank_003Ek__BackingField;
		}
		private set
		{
			_003CnewRecordRank_003Ek__BackingField = value;
		}
	}

	public string newRecordLbName
	{
		get
		{
			return _003CnewRecordLbName_003Ek__BackingField;
		}
		private set
		{
			_003CnewRecordLbName_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		_003CnewRecordRank_003Ek__BackingField = 2147483647;
		Action<string, int> b = OnLeaderboardScoreUploaded;
		Delegate obj = Delegate.Combine(SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded = (Action<string, int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, int> action = default(Action<string, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0218;
			}
			SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01fd;
			}
		}
		Action<bool> b2 = OnBossDefeated;
		Delegate obj6 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b2);
		if ((object)obj6 == null)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action2 = default(Action<bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0208;
		}
		InteractableBossSpawner.A_BossDefeated = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0218;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0218:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0208;
		IL_0208:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01fd;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<string, int> value = OnLeaderboardScoreUploaded;
		Delegate obj = Delegate.Remove(SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded = (Action<string, int>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<string, int> action = default(Action<string, int>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<string, int>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			SteamLeaderboardsManagerNew.A_LeaderboardScoreUploaded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<string, int>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<bool> b = OnBossDefeated;
		Delegate obj6 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
		if ((object)obj6 == null)
		{
			InteractableBossSpawner.A_BossDefeated = (Action<bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action2 = default(Action<bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		InteractableBossSpawner.A_BossDefeated = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	private void OnLeaderboardScoreUploaded(string lbName, int rank)
	{
		SteamLeaderboardNew leaderboardKillsWeekly = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;
		if (lbName != leaderboardKillsWeekly.lbName)
		{
			SteamLeaderboardNew leaderboardKillsWeekly2 = SteamLeaderboardsManagerNew.leaderboardKillsWeekly;
			if (!(lbName == leaderboardKillsWeekly2.lbNameFriends))
			{
				return;
			}
		}
		hasNewRecord = true;
		if (rank < _003CnewRecordRank_003Ek__BackingField)
		{
			_003CnewRecordLbName_003Ek__BackingField = lbName;
			_003CnewRecordRank_003Ek__BackingField = rank;
		}
	}

	private void OnBossDefeated(bool canSpawnPortal)
	{
		if (MapController.IsTierFinalStage())
		{
			tierVictory = true;
		}
	}

	public void PlayAudio()
	{
		audio.Play();
	}

	public void StartDeathScreen()
	{
		_003CDoTransition_003Ed__29 obj = new _003CDoTransition_003Ed__29(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoTransition()
	{
		_003CDoTransition_003Ed__29 obj = new _003CDoTransition_003Ed__29(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void Update()
	{
		//IL_009b: Invalid comparison between I4 and F4
		//IL_00e6: Expected F4, but got I4
		//IL_01b1: Invalid comparison between I4 and F4
		//IL_012c: Expected F4, but got I4
		//IL_01e8: Invalid comparison between I4 and F4
		//IL_0190: Expected F4, but got I4
		//IL_01a2: Expected O, but got Ref
		GameObject gameObject = canvasGroup.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		float deltaTime = Time.deltaTime;
		float num = deltaTime / fadeInTime;
		float num2 = (fadeTimer = num + fadeTimer);
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float alpha = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
		canvasGroup.alpha = alpha;
		Transform transform = canvasGroup.transform;
		float num3 = Easing.OutCirc(num2);
		if (!(0f > num3))
		{
			if (num3 > 1f)
			{
				num3 = 1f;
			}
		}
		else
		{
			num3 = 0f;
		}
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
	}

	public void ShowLeaderboard()
	{
		leaderboardsWindow.SetActive(value: true);
	}

	public void HideVictoryScreen()
	{
		victoryScreen.SetActive(value: false);
		if (!tierVictory)
		{
			if (!hasNewRecord)
			{
				leaderboardsWindow.SetActive(value: false);
				PlayerCamera.Instance.HideDeathCamera();
				GameObject gameObject = canvasGroup.gameObject;
				gameObject.SetActive(value: true);
				GameObject gameObject2 = b_continue.gameObject;
				gameObject2.SetActive(value: false);
				statsWindow.SetActive(value: true);
				if (ChallengesTracker.HasChallenge())
				{
					restartBtn.SetActive(value: true);
				}
			}
			else
			{
				leaderboardsWindow.SetActive(value: true);
				hasNewRecord = false;
			}
		}
		else
		{
			victoryScreen.SetActive(value: true);
			tierVictory = false;
		}
	}

	public void ShowStats()
	{
		if (!tierVictory)
		{
			if (!hasNewRecord)
			{
				leaderboardsWindow.SetActive(value: false);
				PlayerCamera.Instance.HideDeathCamera();
				GameObject gameObject = canvasGroup.gameObject;
				gameObject.SetActive(value: true);
				GameObject gameObject2 = b_continue.gameObject;
				gameObject2.SetActive(value: false);
				statsWindow.SetActive(value: true);
				if (ChallengesTracker.HasChallenge())
				{
					restartBtn.SetActive(value: true);
				}
			}
			else
			{
				leaderboardsWindow.SetActive(value: true);
				hasNewRecord = false;
			}
		}
		else
		{
			victoryScreen.SetActive(value: true);
			tierVictory = false;
		}
	}

	public void GoToMenu()
	{
		TransitionUI.Instance.LoadMenu();
	}

	public void Restart()
	{
		MapController.RestartRun();
	}
}
