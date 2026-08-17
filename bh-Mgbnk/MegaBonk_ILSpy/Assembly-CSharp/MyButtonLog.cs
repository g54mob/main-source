using System;
using System.Collections.Generic;
using Actors.Enemies;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButtonLog : MyButton
{
	public TextMeshProUGUI t_enemyName;

	public EEnemy eEnemy;

	public static Action<EEnemy> A_EnemySelected;

	public static Action A_ClaimedReward;

	public GameObject claimAlert;

	public GameObject greenLoggedIcon;

	public MaskableGraphic background;

	public Color defaultColor;

	public Color hoverColor;

	public unsafe override void StartHover()
	{
		//IL_0023: Expected O, but got Ref
		Action<EEnemy> a_EnemySelected = A_EnemySelected;
		if (A_EnemySelected != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<Actors.Enemies.EEnemy>)+18] (should have been resolved before IL gen)");
		}
		object obj = default(object);
		background.color = (Color)(&obj);
		isHovering = true;
	}

	public unsafe override void StopHover()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		background.color = (Color)(&obj);
		isHovering = false;
	}

	public unsafe void SetEnemy(EEnemy enemy, int enemyIndex)
	{
		//IL_003d: Expected O, but got Ref
		eEnemy = enemy;
		bool flag = LogUtility.IsEntryUnlocked(enemy);
		bool flag2 = !flag;
		string text = "------";
		if (!flag2)
		{
			object obj = default(object);
			string s = ((Enum)(&obj)).ToString();
			string text2 = EnumUtility.EnumToReadable(s);
			text = text2;
		}
		int num = default(int);
		string text3 = num.ToString("D3");
		string text4 = text3 + " " + text;
		t_enemyName.text = text4;
		bool active = LogUtility.HasClaimedAllRewards(eEnemy);
		greenLoggedIcon.SetActive(active);
		bool active2 = (LogUtility.HasUnclaimedReward(eEnemy) ? true : false);
		claimAlert.SetActive(active2);
	}

	public unsafe void Claim()
	{
		//IL_0061: Expected O, but got Ref
		//IL_00f8: Expected I, but got O
		if (LogUtility.HasUnclaimedReward(eEnemy))
		{
			Transform transform = claimAlert.transform;
			Vector3 position = transform.position;
			object obj = default(object);
			MenuParticles.Instance.CoinEffect((Vector3)(&obj));
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			StatsSaveFile stats = saveManager.stats;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)stats.enemyLogs).get_Item((System.Int32Enum)eEnemy);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v18 (System.Object)+14]");
			_ = (nint)0 + (nint)1;
			bool flag = LogUtility.HasUnclaimedReward(eEnemy);
			nint num = 0;
			if (!flag)
			{
				claimAlert.SetActive(value: false);
				num = unchecked((nint)null);
			}
			Action a_ClaimedReward = A_ClaimedReward;
			if (A_ClaimedReward != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v93.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	protected override void OnClick()
	{
		Claim();
	}
}
