using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInformationUi : MonoBehaviour
{
	public GameObject parent;

	public TextMeshProUGUI t_enemies;

	public RawImage i_enemies;

	public ScalingEntry scalingEntryHp;

	public ScalingEntry scalingEntryDmg;

	public ScalingEntry scalingEntrySpeed;

	private float updateInterval = 0.5f;

	private float nextUpdateTime;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> b = OnSettingUpdate;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdate;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		Refresh();
	}

	private void OnSettingUpdate(string name, object oldVal, object newVal)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EEF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (name == "debug_enemy_scaling")
		{
			Refresh();
		}
	}

	private void Refresh()
	{
		//IL_008a: Expected O, but got I4
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			GameObject gameObject = parent.gameObject;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFGameSettings cfGameSettings = config.cfGameSettings;
			object obj = cfGameSettings.debug_enemy_scaling - 1;
			bool active = obj == null;
			gameObject.SetActive(active);
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0152: Expected O, but got Ref
		//IL_0174: Expected O, but got Ref
		//IL_01e3: Invalid comparison between I4 and F4
		//IL_022e: Expected F4, but got I4
		//IL_0246: Expected O, but got Ref
		//IL_02ab: Expected O, but got Ref
		//IL_0301: Expected F4, but got I
		//IL_0301: Expected F4, but got I
		//IL_0353: Expected O, but got Ref
		//IL_03a4: Expected F4, but got I
		//IL_03a4: Expected F4, but got I
		//IL_03f6: Expected O, but got Ref
		//IL_0447: Expected F4, but got I
		//IL_0447: Expected F4, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		if (!GameManager.Instance)
		{
			return;
		}
		GameManager instance = GameManager.Instance;
		if (!instance.isPlaying || !PlayerStats.HasStats())
		{
			return;
		}
		GameObject gameObject = parent.gameObject;
		if (!gameObject.activeInHierarchy || nextUpdateTime > MyTime.time)
		{
			return;
		}
		EnemyManager instance2 = EnemyManager.Instance;
		if ((object)EnemyManager.Instance == null)
		{
			return;
		}
		SummonerController summonerController = instance2.summonerController;
		if (instance2.summonerController == null || summonerController.stageSummoner == null)
		{
			return;
		}
		float num = MyTime.time + updateInterval;
		nextUpdateTime = num;
		EnemyManager instance3 = EnemyManager.Instance;
		SummonerController summonerController2 = instance3.summonerController;
		int numTargetEnemies = summonerController2.stageSummoner.GetNumTargetEnemies();
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 3));
		_ = instance3.numEnemies;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg} / {arg2}";
		t_enemies.text = text;
		Transform transform = i_enemies.transform;
		float num2 = (float)instance3.numEnemies / (float)numTargetEnemies;
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
		Vector3 localScale = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		_ = 1065353216;
		transform.localScale = localScale;
		float hpMultiplierAddition = CombatScaling.GetHpMultiplierAddition(out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127)));
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 11));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg3 = default(object);
		string text2 = $"{arg3:N1}x";
		ScalingEntry scalingEntry = scalingEntryHp;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
		float finalM = default(float);
		scalingEntry.Set(text2, num3, 0f, finalM);
		float damageMultiplierAddition = CombatScaling.GetDamageMultiplierAddition(out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 13)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 21)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17)));
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 15));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg4 = default(object);
		string text3 = $"{arg4:N1}x";
		ScalingEntry scalingEntry2 = scalingEntryDmg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-D]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		scalingEntry2.Set(text3, num4, 0f, finalM);
		float speedMultiplierAddition = CombatScaling.GetSpeedMultiplierAddition(out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 1)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9)), out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 5)));
		object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 19));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg5 = default(object);
		string text4 = $"{arg5:N1}x";
		ScalingEntry scalingEntry3 = scalingEntrySpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-1]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-5]");
		scalingEntry3.Set(text4, num5, 0f, finalM);
	}
}
