using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogsDisplayEnemy : MonoBehaviour
{
	public TextMeshProUGUI t_enemyName;

	public TextMeshProUGUI t_enemyDescription;

	public TextMeshProUGUI t_enemyStats;

	public TextMeshProUGUI t_enemyMaps;

	public TextMeshProUGUI t_killsCounter;

	public TextMeshProUGUI t_challengeCounter;

	public TextMeshProUGUI t_reward;

	public RawImage enemyRenderer;

	public RawImage barProgress;

	public RawImage i_rewardCoin;

	public List<RawImage> challengeProgress;

	public Color dotColorIncomplete;

	public Color dotColorComplete;

	public Material rainbow;

	public Texture unknownTexture;

	public Texture renderTexture;

	private EEnemy eEnemy;

	private void Awake()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_022e: Expected I, but got O
		//IL_0254: Expected I, but got O
		//IL_0265: Expected O, but got I4
		//IL_027b: Expected I, but got O
		Action<EEnemy> b = SetEnemy;
		Delegate obj = Delegate.Combine(MyButtonLog.A_EnemySelected, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonLog.A_EnemySelected = (Action<EEnemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EEnemy> action = default(Action<EEnemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EEnemy>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0299;
			}
			MyButtonLog.A_EnemySelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EEnemy>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01e4;
			}
		}
		Action action2 = OnClaimedReward;
		Delegate obj6 = Delegate.Combine(MyButtonLog.A_ClaimedReward, action2);
		if ((object)obj6 == null)
		{
			MyButtonLog.A_ClaimedReward = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)MyButtonLog.A_ClaimedReward;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_0289;
		}
		MyButtonLog.A_ClaimedReward = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)MyButtonLog.A_ClaimedReward;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_0299;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01e4;
		IL_01e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0299:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0289;
	}

	private void OnDestroy()
	{
		//IL_01a1: Expected I, but got O
		//IL_01b2: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0207: Expected I, but got O
		//IL_0218: Expected O, but got I4
		//IL_022e: Expected I, but got O
		//IL_0254: Expected I, but got O
		//IL_0265: Expected O, but got I4
		//IL_027b: Expected I, but got O
		Action<EEnemy> value = SetEnemy;
		Delegate obj = Delegate.Remove(MyButtonLog.A_EnemySelected, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyButtonLog.A_EnemySelected = (Action<EEnemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EEnemy> action = default(Action<EEnemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EEnemy>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0299;
			}
			MyButtonLog.A_EnemySelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EEnemy>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_01e4;
			}
		}
		Action action2 = OnClaimedReward;
		Delegate obj6 = Delegate.Remove(MyButtonLog.A_ClaimedReward, action2);
		if ((object)obj6 == null)
		{
			MyButtonLog.A_ClaimedReward = null;
			return;
		}
		bool flag2 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag2)
		{
			obj7 = obj6;
		}
		bool flag3 = (object)obj7 == null;
		num2 = (nint)MyButtonLog.A_ClaimedReward;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag3)
		{
			goto IL_0289;
		}
		MyButtonLog.A_ClaimedReward = (Action)obj7;
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag4)
		{
			obj8 = obj6;
		}
		bool flag5 = (object)obj8 == null;
		num = (nint)MyButtonLog.A_ClaimedReward;
		obj2 = action2;
		obj3 = 0;
		obj4 = obj6;
		nint num4 = (nint)typeof(Action);
		if (!flag5)
		{
			return;
		}
		goto IL_0299;
		IL_0289:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01e4;
		IL_01e4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0299:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0289;
	}

	private void OnClaimedReward()
	{
		SetEnemy(eEnemy);
	}

	public unsafe void SetEnemy(EEnemy eEnemy)
	{
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Ref, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Ref, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected Ref, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_0322: Invalid comparison between I and F4
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0651: Expected I, but got O
		//IL_0678: Expected O, but got I
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected O, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Expected O, but got Unknown
		//IL_0398: Expected I, but got O
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_038b: Expected O, but got I
		this.eEnemy = eEnemy;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool flag = LogUtility.IsEntryUnlocked(eEnemy);
		bool flag2 = LogUtility.HasClaimedAllRewards(eEnemy);
		object obj2 = default(object);
		if (flag)
		{
			EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
			bool flag3 = enemyData != null;
			TextMeshProUGUI textMeshProUGUI = t_enemyName;
			string text4;
			if (flag3)
			{
				string text = enemyData.GetName();
				t_enemyName.text = text;
				enemyRenderer.texture = renderTexture;
				GameObject gameObject;
				bool active;
				if (flag2)
				{
					t_reward.text = "";
					gameObject = i_rewardCoin.gameObject;
					active = false;
				}
				else
				{
					int reward = LogUtility.GetReward(eEnemy);
					object obj = obj2 - 52;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
					object arg = default(object);
					string text2 = $"{arg}";
					t_reward.text = text2;
					gameObject = i_rewardCoin.gameObject;
					active = true;
				}
				gameObject.SetActive(active);
				ref int numKillsForNextChallengeTier = default(ref int);
				LogUtility.GetChallengeProgress(eEnemy, out *(float*)(obj2 + 64), out *(int*)(obj2 - 56), out *(int*)(obj2 + 80), out numKillsForNextChallengeTier);
				List<RawImage> list = challengeProgress;
				int num = 0;
				int num2 = 0;
				while (num2 < list._size)
				{
					RawImage rawImage = challengeProgress.get_Item(num);
					int num3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
					if ((nint)num3 < (nint)0)
					{
						Color color = dotColorComplete;
					}
					else
					{
						Color color = dotColorIncomplete;
					}
					Color color2 = (Color)(obj2 - 40);
					rawImage.color = color2;
					list = challengeProgress;
					num++;
					bool flag4 = challengeProgress != null;
					num2 = num;
					if (flag4)
					{
						continue;
					}
					goto IL_05f8;
				}
				Transform transform = barProgress.transform;
				Vector3 localScale = (Vector3)(obj2 - 40);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+40]");
				_ = 0;
				_ = 1065353216;
				_ = 1065353216;
				transform.localScale = localScale;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+40]");
				RawImage rawImage2;
				Material material;
				if (!(0f < 1f) && !flag2)
				{
					rawImage2 = barProgress;
					material = rainbow;
				}
				else
				{
					rawImage2 = barProgress;
					material = null;
				}
				nint num4 = (nint)rawImage2;
				rawImage2.material = material;
				TextMeshProUGUI textMeshProUGUI2 = t_challengeCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+50]");
				object obj3 = 0;
				object obj4 = obj2 - 52;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+50]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+38]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+38]");
					obj3 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object obj5 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg2 = default(object);
				object arg3 = default(object);
				string text3 = $"{arg2}/{arg3}";
				nint num6 = (nint)textMeshProUGUI2;
				textMeshProUGUI2.text = text3;
				object obj6 = obj2 - 44;
				textMeshProUGUI = t_killsCounter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg4 = default(object);
				text4 = $"Kills: {arg4}";
			}
			else
			{
				Enum obj7 = (Enum)(obj2 - 40);
				_ = typeof(EEnemy);
				_ = -1;
				string text5 = obj7.ToString();
				text4 = "ERROR: Enemy data not found for: " + text5;
			}
			textMeshProUGUI.text = text4;
			return;
		}
		t_enemyName.text = "------";
		t_enemyDescription.text = "------";
		t_enemyStats.text = "------";
		t_enemyMaps.text = "------";
		enemyRenderer.texture = unknownTexture;
		Transform transform2 = barProgress.transform;
		_ = 0;
		Vector3 localScale2 = (Vector3)(obj2 - 40);
		_ = 1065353216;
		_ = 1065353216;
		transform2.localScale = localScale2;
		t_challengeCounter.text = "";
		t_killsCounter.text = "Kills: 0";
		t_reward.text = "";
		GameObject gameObject2 = i_rewardCoin.gameObject;
		gameObject2.SetActive(value: false);
		List<RawImage> list2 = challengeProgress;
		int num7 = 0;
		int num8 = 0;
		bool flag5;
		do
		{
			if (num8 < list2._size)
			{
				RawImage rawImage3 = challengeProgress.get_Item(num7);
				Color color3 = (Color)(obj2 - 40);
				_ = dotColorIncomplete;
				rawImage3.color = color3;
				list2 = challengeProgress;
				num7++;
				flag5 = challengeProgress != null;
				num8 = num7;
				continue;
			}
			return;
		}
		while (flag5);
		goto IL_05f8;
		IL_05f8:
		throw new NullReferenceException();
	}
}
