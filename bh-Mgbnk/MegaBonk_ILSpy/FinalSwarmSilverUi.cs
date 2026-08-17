using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalSwarmSilverUi : MonoBehaviour
{
	public Transform coin;

	public TextMeshProUGUI t_silverMultiplier;

	public TextMeshProUGUI t_difficulty;

	public RawImage progressBar;

	public Image outlineGlow;

	private Material outlineGlowMat;

	private string modifierName;

	public GameObject contentParent;

	private float maxTime;

	private float maxMultiplier;

	private float lastMultiplier;

	private float nextCheckTime;

	private float checkInterval;

	public Gradient colorGradient;

	public float testTime;

	private void Start()
	{
		//IL_046c: Expected I, but got O
		//IL_0083: Expected I, but got O
		//IL_0094: Expected O, but got I4
		//IL_00d7: Expected I, but got O
		//IL_00e8: Expected O, but got I4
		//IL_0348: Expected I, but got O
		//IL_0359: Expected O, but got I4
		//IL_036f: Expected I, but got O
		//IL_039d: Expected O, but got I4
		//IL_03b3: Expected I, but got O
		//IL_03e1: Expected O, but got I4
		//IL_03f7: Expected I, but got O
		//IL_0425: Expected O, but got I4
		Delegate obj6 = default(Delegate);
		Action action3 = default(Action);
		nint num;
		Delegate obj2;
		if ((object)outlineGlow != null)
		{
			Material material = outlineGlow.material;
			outlineGlowMat = material;
			RemoveSilverMultiplier();
			Action<PlayerInventory> b = OnPlayerInventoryInitialized;
			Delegate obj = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<PlayerInventory> action = default(Action<PlayerInventory>);
				bool flag = action == null;
				num = (nint)typeof(Action<PlayerInventory>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				if (flag)
				{
					goto IL_0316;
				}
				MyPlayer.A_PlayerInventoryInitialized = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<PlayerInventory>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				if (flag2)
				{
					goto IL_0321;
				}
			}
			obj6 = SummonerController.A_FinalSwarmStarted;
			Action action2 = OnFinalSwarmStarted;
			Delegate obj7 = Delegate.Combine(SummonerController.A_FinalSwarmStarted, action2);
			if ((object)obj7 == null)
			{
				SummonerController.A_FinalSwarmStarted = null;
			}
			else
			{
				bool flag3 = (object)obj7.GetType() != typeof(Action);
				Delegate obj8 = null;
				if (!flag3)
				{
					obj8 = obj7;
				}
				bool flag4 = (object)obj8 == null;
				num = (nint)obj6;
				obj2 = action2;
				obj3 = 0;
				obj4 = obj7;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_0449;
				}
				SummonerController.A_FinalSwarmStarted = (Action)obj8;
				bool flag5 = (object)obj7.GetType() != typeof(Action);
				Delegate obj9 = null;
				if (!flag5)
				{
					obj9 = obj7;
				}
				bool flag6 = (object)obj9 == null;
				action3 = action2;
				obj3 = 0;
				obj4 = obj7;
				nint num3 = (nint)typeof(Action);
				if (flag6)
				{
					goto IL_0459;
				}
			}
			obj6 = SummonerController.A_FinalSwarmStopped;
			Action action4 = OnFinalSwarmStopped;
			Delegate obj10 = Delegate.Combine(SummonerController.A_FinalSwarmStopped, action4);
			if ((object)obj10 == null)
			{
				SummonerController.A_FinalSwarmStopped = null;
				return;
			}
			bool flag7 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag7)
			{
				obj11 = obj10;
			}
			bool flag8 = (object)obj11 == null;
			action3 = action4;
			obj3 = 0;
			obj4 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag8)
			{
				goto IL_0479;
			}
			SummonerController.A_FinalSwarmStopped = (Action)obj11;
			bool flag9 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag9)
			{
				obj12 = obj10;
			}
			bool flag10 = (object)obj12 == null;
			action3 = action4;
			obj3 = 0;
			obj4 = obj10;
			NullReferenceException typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (!flag10)
			{
				return;
			}
		}
		else
		{
			NullReferenceException typeFromHandle = new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0479;
		IL_0459:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = (nint)obj6;
		obj2 = action3;
		goto IL_0449;
		IL_0479:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0459;
		IL_0316:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0449:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0321;
		IL_0321:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0316;
	}

	private void OnDestroy()
	{
		//IL_0283: Expected I, but got O
		//IL_0294: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_02f4: Expected I, but got O
		//IL_0305: Expected O, but got I4
		//IL_031b: Expected I, but got O
		//IL_0190: Expected I, but got O
		//IL_0341: Expected I, but got O
		//IL_0352: Expected O, but got I4
		//IL_0368: Expected I, but got O
		//IL_0396: Expected O, but got I4
		//IL_03ac: Expected I, but got O
		//IL_03da: Expected O, but got I4
		//IL_03f0: Expected I, but got O
		RemoveSilverMultiplier();
		Action<PlayerInventory> value = OnPlayerInventoryInitialized;
		Delegate obj = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = (Action<PlayerInventory>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerInventory> action = default(Action<PlayerInventory>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<PlayerInventory>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0436;
			}
			MyPlayer.A_PlayerInventoryInitialized = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<PlayerInventory>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02d1;
			}
		}
		Action action2 = OnFinalSwarmStarted;
		Delegate obj6 = Delegate.Remove(SummonerController.A_FinalSwarmStarted, action2);
		if ((object)obj6 == null)
		{
			SummonerController.A_FinalSwarmStarted = null;
		}
		else
		{
			bool flag2 = (object)obj6.GetType() != typeof(Action);
			Delegate obj7 = null;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 == null;
			num2 = (nint)SummonerController.A_FinalSwarmStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num3 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_03fe;
			}
			SummonerController.A_FinalSwarmStarted = (Action)obj7;
			bool flag4 = (object)obj6.GetType() != typeof(Action);
			Delegate obj8 = null;
			if (!flag4)
			{
				obj8 = obj6;
			}
			bool flag5 = (object)obj8 == null;
			num = (nint)SummonerController.A_FinalSwarmStarted;
			obj2 = action2;
			obj3 = 0;
			obj4 = obj6;
			nint num4 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_040e;
			}
		}
		num = (nint)SummonerController.A_FinalSwarmStopped;
		Action action3 = OnFinalSwarmStopped;
		Delegate obj9 = Delegate.Remove(SummonerController.A_FinalSwarmStopped, action3);
		if ((object)obj9 == null)
		{
			SummonerController.A_FinalSwarmStopped = null;
			return;
		}
		bool flag6 = (object)obj9.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj9;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num5 = (nint)typeof(Action);
		if (flag7)
		{
			goto IL_0426;
		}
		SummonerController.A_FinalSwarmStopped = (Action)obj10;
		bool flag8 = (object)obj9.GetType() != typeof(Action);
		Delegate obj11 = null;
		if (!flag8)
		{
			obj11 = obj9;
		}
		bool flag9 = (object)obj11 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj9;
		nint num6 = (nint)typeof(Action);
		if (!flag9)
		{
			return;
		}
		goto IL_0436;
		IL_0436:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0426;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0426:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_040e;
		IL_040e:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03fe;
		IL_03fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
	}

	private void RemoveSilverMultiplier()
	{
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null && instance.inventory != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			inventory.statInventory.RemoveMovingStat(modifierName);
		}
	}

	private unsafe void OnFinalSwarmStarted()
	{
		//IL_0036: Expected O, but got Ref
		contentParent.SetActive(value: true);
		Transform transform = contentParent.transform;
		object obj = default(object);
		transform.localScale = (Vector3)(&obj);
	}

	private void OnFinalSwarmStopped()
	{
		contentParent.SetActive(value: false);
	}

	private unsafe void Update()
	{
		//IL_01c3: Invalid comparison between I4 and F4
		//IL_00d1: Expected F4, but got I4
		//IL_00e3: Expected O, but got Ref
		//IL_0201: Invalid comparison between I4 and F4
		//IL_0159: Expected F4, but got I4
		//IL_016b: Expected O, but got Ref
		//IL_019b: Expected O, but got Ref
		if (!contentParent.activeInHierarchy)
		{
			return;
		}
		UpdateMultiplier();
		Transform transform = contentParent.transform;
		Transform transform2 = contentParent.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 10f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
		Transform transform3 = coin.transform;
		Transform transform4 = coin.transform;
		Vector3 localScale2 = transform4.localScale;
		float deltaTime2 = Time.deltaTime;
		float num3 = deltaTime2 * 8f;
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
		transform3.localScale = (Vector3)(&num2);
		Transform transform5 = progressBar.transform;
		float timerLerp = GetTimerLerp();
		transform5.localScale = (Vector3)(&num2);
	}

	private unsafe void UpdateMultiplier()
	{
		//IL_02d3: Invalid comparison between I4 and F4
		//IL_02e2: Expected F4, but got I4
		//IL_0073: Invalid comparison between I4 and F4
		//IL_011d: Expected O, but got Ref
		//IL_023e: Expected O, but got Ref
		//IL_026d: Expected O, but got Ref
		//IL_0299: Expected O, but got Ref
		if (nextCheckTime > MyTime.time)
		{
			return;
		}
		float num = MyTime.time + checkInterval;
		nextCheckTime = num;
		float timerLerp = GetTimerLerp();
		bool flag = 0f > timerLerp;
		float num2 = 0f;
		if (!flag)
		{
			num2 = ((timerLerp > 1f) ? 1f : timerLerp);
		}
		float num3 = maxMultiplier - 1f;
		float num4 = num3 * num2;
		float num5 = num4 + 1f;
		double num6 = Math.Round(num5, 2, MidpointRounding.ToEven);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
		if (0f > lastMultiplier)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			StatModifier statModifier = new StatModifier();
			statModifier.modification = 0f;
			statModifier.modifyType = EStatModifyType.Multiplication;
			statModifier.stat = EStat.SilverIncreaseMultiplier;
			inventory.statInventory.ChangeMovingStat(modifierName, statModifier);
			Transform transform = coin.transform;
			float num7 = default(float);
			transform.localScale = (Vector3)(&num7);
			string text = MyStringUtil.ShowOnlyDecimals(0f);
			string text2 = "x" + text;
			t_silverMultiplier.text = text2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F2F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string key = ((0.25f > timerLerp) ? "DIFFICULTY_EASY" : ((0.5f > timerLerp) ? "DIFFICULTY_NORMAL" : ((0.75f > timerLerp) ? "DIFFICULTY_HARD" : "DIFFICULTY_COOKED")));
			string localizedString = LocalizationUtility.GetLocalizedString("Other", key);
			t_difficulty.text = localizedString;
			Color color = colorGradient.Evaluate(timerLerp);
			outlineGlowMat.SetColor("_Color", (Color)(&num7));
			Color color2 = colorGradient.Evaluate(timerLerp);
			t_difficulty.color = (Color)(&num7);
			Color color3 = colorGradient.Evaluate(timerLerp);
			progressBar.color = (Color)(&num7);
		}
		lastMultiplier = 0f;
	}

	private unsafe Color GetColor(float lerpValue)
	{
		//IL_003f: Expected native int or pointer, but got O
		if (colorGradient != null)
		{
			Color color = default(Color);
			((Color*)(nint)color)->r = colorGradient.Evaluate(lerpValue).r;
			return color;
		}
		return (Color)new NullReferenceException();
	}

	private float GetSwarmTime()
	{
		return MyTime.finalSwarmTimer;
	}

	private float GetTimerLerp()
	{
		//IL_005e: Invalid comparison between I4 and F4
		//IL_0034: Expected F4, but got I4
		float num = MyTime.finalSwarmTimer / maxTime;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				return 1f;
			}
		}
		else
		{
			num = 0f;
		}
		return num;
	}

	private string GetDifficultyText(float lerpValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F2F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!(0.25f > lerpValue))
		{
			if (!(0.5f > lerpValue))
			{
				if (!(0.75f > lerpValue))
				{
					return LocalizationUtility.GetLocalizedString("Other", "DIFFICULTY_COOKED");
				}
				return LocalizationUtility.GetLocalizedString("Other", "DIFFICULTY_HARD");
			}
			return LocalizationUtility.GetLocalizedString("Other", "DIFFICULTY_NORMAL");
		}
		return LocalizationUtility.GetLocalizedString("Other", "DIFFICULTY_EASY");
	}

	private void OnPlayerInventoryInitialized(PlayerInventory pInv)
	{
		RemoveSilverMultiplier();
	}

	public FinalSwarmSilverUi()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F30]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		modifierName = "Swarm Silver Multiplier";
		maxTime = 240f;
		maxMultiplier = 8f;
		checkInterval = 1f;
		base._002Ector();
	}
}
