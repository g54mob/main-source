using System;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class AlertUi : MonoBehaviour
{
	public TextMeshProUGUI t_alert;

	public AudioSource audio;

	public AudioClip c_swarm;

	public AudioClip c_finalSwarm;

	public AudioClip c_boss;

	public Color swarmColor;

	public Color swarmFinalColor;

	public Color bossColor;

	private float timer;

	private bool startedFade;

	private void Awake()
	{
		//IL_027d: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0306: Expected I, but got O
		//IL_032c: Expected O, but got I4
		//IL_0342: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03ba: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_03ee: Expected O, but got I4
		Action b = OnSwarmStarted;
		Delegate obj = Delegate.Combine(SummonerController.A_SwarmStarted, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SummonerController.A_SwarmStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_043f;
			}
			SummonerController.A_SwarmStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0404;
			}
		}
		Action b2 = OnFinalSwarmStarted;
		Delegate obj6 = Delegate.Combine(SummonerController.A_FinalSwarmStarted, b2);
		if ((object)obj6 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_040f;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_041f;
			}
		}
		Action b3 = SetAlertBoss;
		Delegate obj9 = Delegate.Combine(InteractableBossSpawner.A_BossSpawned, b3);
		if ((object)obj9 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
			return;
		}
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag8)
		{
			obj10 = obj9;
		}
		bool flag9 = (object)obj10 == null;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_042f;
		}
		InteractableBossSpawner.A_BossSpawned = (Action)obj10;
		bool flag10 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag10)
		{
			obj11 = obj9;
		}
		bool flag11 = (object)obj11 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj9;
		if (!flag11)
		{
			return;
		}
		goto IL_043f;
		IL_042f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_041f;
		IL_040f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0404;
		IL_0404:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_043f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042f;
		IL_041f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_040f;
	}

	private void OnDestroy()
	{
		//IL_027d: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		//IL_0306: Expected I, but got O
		//IL_032c: Expected O, but got I4
		//IL_0342: Expected I, but got O
		//IL_0368: Expected O, but got I4
		//IL_037e: Expected I, but got O
		//IL_03a4: Expected O, but got I4
		//IL_03ba: Expected I, but got O
		//IL_03e5: Expected I, but got O
		//IL_03ee: Expected O, but got I4
		Action value = OnSwarmStarted;
		Delegate obj = Delegate.Remove(SummonerController.A_SwarmStarted, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SummonerController.A_SwarmStarted = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_043f;
			}
			SummonerController.A_SwarmStarted = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0404;
			}
		}
		Action value2 = OnFinalSwarmStarted;
		Delegate obj6 = Delegate.Remove(SummonerController.A_FinalSwarmStarted, value2);
		if ((object)obj6 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag4)
			{
				obj7 = obj6;
			}
			bool flag5 = (object)obj7 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_040f;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj7;
			bool flag6 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag6)
			{
				obj8 = obj6;
			}
			bool flag7 = (object)obj8 == null;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_041f;
			}
		}
		Action value3 = SetAlertBoss;
		Delegate obj9 = Delegate.Remove(InteractableBossSpawner.A_BossSpawned, value3);
		if ((object)obj9 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
			return;
		}
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag8)
		{
			obj10 = obj9;
		}
		bool flag9 = (object)obj10 == null;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_042f;
		}
		InteractableBossSpawner.A_BossSpawned = (Action)obj10;
		bool flag10 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag10)
		{
			obj11 = obj9;
		}
		bool flag11 = (object)obj11 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj9;
		if (!flag11)
		{
			return;
		}
		goto IL_043f;
		IL_042f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_041f;
		IL_040f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0404;
		IL_0404:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_043f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_042f;
		IL_041f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_040f;
	}

	private void OnSwarmStarted()
	{
		SetAlert(EWaveType.Swarm);
	}

	private void OnFinalSwarmStarted()
	{
		SetAlert(EWaveType.FinalSwarm);
	}

	private void OnNewWave(EWaveType waveType)
	{
		//IL_000e: Expected O, but got I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_003a: Expected O, but got I4
		object obj = waveType - 1;
		object obj2 = obj & 0xFFFFFFFDL;
		bool flag = obj2 == null;
		object obj3 = !flag;
		if (obj3 == null)
		{
			SetAlert(waveType);
		}
	}

	public unsafe void SetAlertBoss()
	{
		//IL_0057: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F12]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		t_alert.fontSize = 62f;
		object obj = default(object);
		t_alert.color = (Color)(&obj);
		audio.clip = c_boss;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_HUD", "ALERT_BOSS");
		t_alert.text = localizedString;
		AnimateAlert();
	}

	public unsafe void SetAlertTimesUp()
	{
		//IL_0057: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F13]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		t_alert.fontSize = 62f;
		object obj = default(object);
		t_alert.color = (Color)(&obj);
		audio.clip = c_finalSwarm;
		string localizedString = LocalizationUtility.GetLocalizedString("Game_HUD", "ALERT_TIME_UP");
		t_alert.text = localizedString;
		AnimateAlert();
	}

	public unsafe void SetAlert(EWaveType waveType)
	{
		//IL_00bf: Expected O, but got Ref
		//IL_0077: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F14]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = default(object);
		string key;
		if (waveType != EWaveType.FinalSwarm)
		{
			if (waveType != EWaveType.Swarm)
			{
				goto IL_0114;
			}
			t_alert.fontSize = 62f;
			t_alert.color = (Color)(&obj);
			audio.clip = c_swarm;
			key = "ALERT_SWARM";
		}
		else
		{
			t_alert.fontSize = 62f;
			t_alert.color = (Color)(&obj);
			audio.clip = c_finalSwarm;
			key = "ALERT_FINAL_SWARM";
		}
		string localizedString = LocalizationUtility.GetLocalizedString("Game_HUD", key);
		t_alert.text = localizedString;
		goto IL_0114;
		IL_0114:
		AnimateAlert();
	}

	private unsafe void AnimateAlert()
	{
		//IL_0063: Expected O, but got Ref
		CancelInvoke();
		audio.Play();
		GameObject gameObject = t_alert.gameObject;
		gameObject.SetActive(value: true);
		Transform transform = t_alert.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
		audio.Play();
		t_alert.CrossFadeAlpha(1f, 0f, ignoreTimeScale: true);
		startedFade = false;
		timer = 0f;
	}

	private unsafe void Update()
	{
		//IL_009e: Invalid comparison between I4 and F4
		//IL_00e9: Expected F4, but got I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_027b: Invalid comparison between I4 and F4
		//IL_01b8: Expected F4, but got I4
		//IL_01ca: Expected O, but got Ref
		if (MyTime.paused)
		{
			return;
		}
		GameObject gameObject = t_alert.gameObject;
		if (!gameObject.activeInHierarchy)
		{
			return;
		}
		float time = Time.time;
		float num = time * 4f;
		float num2 = num * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE430");
		float num3 = num2 + num2;
		float num4 = num - num3;
		if (!(0f > num4))
		{
			if (num4 > 2f)
			{
				num4 = 2f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num5 = num4 - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num5 & 0;
		float num6 = 1f - (float)obj;
		float alpha = num6 + 0.25f;
		t_alert.alpha = alpha;
		Transform transform = t_alert.transform;
		Transform transform2 = t_alert.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num7 = deltaTime * 8f;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num8 = default(float);
		transform.localScale = (Vector3)(&num8);
		if (!((timer += MyTime.deltaTime) < 2.5f) && !startedFade)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F16]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			startedFade = true;
			t_alert.CrossFadeAlpha(0f, 1f, ignoreTimeScale: true);
			Invoke("Disable", 1f);
		}
	}

	private void StartFade()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F16]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		startedFade = true;
		t_alert.CrossFadeAlpha(0f, 1f, ignoreTimeScale: true);
		Invoke("Disable", 1f);
	}

	private void Disable()
	{
		GameObject gameObject = t_alert.gameObject;
		gameObject.SetActive(value: false);
	}
}
