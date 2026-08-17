using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResetRunUi : MonoBehaviour
{
	public Transform content;

	public Image progressBar;

	public TextMeshProUGUI text;

	private float startedHoldingTime;

	private bool holding;

	private bool restarting;

	private float GetHoldTime()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		return cfGameSettings.quick_reset_time;
	}

	private void Update()
	{
		//IL_0376: Expected O, but got I4
		//IL_0098: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_01a3: Expected O, but got I
		//IL_01b8: Expected O, but got I
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null && !PlayerInput.IsConsoleOpen())
		{
			UiManager instance2 = UiManager.Instance;
			if (!instance2.encounterWindows.HasEncounter())
			{
				bool flag = !MyTime.paused;
				object obj = 0;
				if (!flag)
				{
					bool flag2 = MyPlayer.Instance.IsDead();
					bool flag3 = !flag2;
					obj = 0;
					if (flag3)
					{
						goto IL_02be;
					}
				}
				TransitionUI instance3 = TransitionUI.Instance;
				if (!instance3.isTransitioning)
				{
					if (!restarting)
					{
						if (holding)
						{
							UpdateBar();
							obj = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
						object obj2 = default(object);
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v28+20]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v30+20]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ rax_v31+18]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v32+48]");
								if ((nint)0 == 0)
								{
									return;
								}
								if (MyInputManager.GetButtonDown(MyInputManager.QuickReset))
								{
									GameObject gameObject = content.gameObject;
									gameObject.SetActive(value: true);
									float time = Time.time;
									startedHoldingTime = time;
									holding = true;
									UpdateBar();
									GameObject gameObject2 = text.gameObject;
									gameObject2.SetActive(value: true);
									text.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
									text.CrossFadeAlpha(1f, 0.15f, ignoreTimeScale: true);
								}
								bool button = MyInputManager.GetButton(MyInputManager.QuickReset);
								if (button || holding == button)
								{
									return;
								}
								goto IL_02dd;
							}
							return;
						}
						return;
					}
					return;
				}
			}
			goto IL_02be;
		}
		if (holding)
		{
			GameObject gameObject3 = content.gameObject;
			gameObject3.SetActive(value: false);
			holding = false;
			GameObject gameObject4 = text.gameObject;
			gameObject4.SetActive(value: false);
		}
		return;
		IL_02dd:
		StopProgress();
		return;
		IL_02be:
		if (!holding)
		{
			return;
		}
		goto IL_02dd;
	}

	private void StartProgress()
	{
		GameObject gameObject = content.gameObject;
		gameObject.SetActive(value: true);
		float time = Time.time;
		startedHoldingTime = time;
		holding = true;
		UpdateBar();
		GameObject gameObject2 = text.gameObject;
		gameObject2.SetActive(value: true);
		text.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
		text.CrossFadeAlpha(1f, 0.15f, ignoreTimeScale: true);
	}

	private void StopProgress()
	{
		GameObject gameObject = content.gameObject;
		gameObject.SetActive(value: false);
		holding = false;
		GameObject gameObject2 = text.gameObject;
		gameObject2.SetActive(value: false);
	}

	private void UpdateBar()
	{
		//IL_006a: Invalid comparison between I4 and F4
		//IL_00b5: Expected F4, but got I4
		float time = Time.time;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		float num = time - startedHoldingTime;
		float num2 = num / cfGameSettings.quick_reset_time;
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
		progressBar.fillAmount = num2;
		if (!(num2 < 1f))
		{
			MapController.RestartRun();
			GameObject gameObject = content.gameObject;
			gameObject.SetActive(value: false);
			holding = false;
			GameObject gameObject2 = text.gameObject;
			gameObject2.SetActive(value: false);
		}
	}
}
