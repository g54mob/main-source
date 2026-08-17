using System;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource xp;

	public AudioSource gold;

	public AudioSource silver;

	public AudioSource dungeonDoorEnter;

	private float xpPitch;

	private float xpPitchDefault = 0.8f;

	private float xpPitchMax = 1.8f;

	private float baseXpVolume;

	private float baseGoldVolume;

	public RandomSfx uiClick;

	public RandomSfx uiSelect;

	public RandomSfx uiInputSet;

	public RandomSfx uiAbort;

	public RandomSfx customSfx;

	public RandomSfx purchaseSfx;

	public RandomSfx bullseye;

	public RandomSfx newMenuButton;

	public static AudioManager Instance;

	private float xpAndGoldVolume = 1f;

	private int xpPerInterval;

	private int goldPerInterval;

	private float interval = 2f;

	private float nextIntervalCheck;

	private int maxPerInterval = 60;

	private int minPerInterval = 20;

	private float xpVolumeMultiplier = 1f;

	private float goldVolumeMultiplier = 1f;

	private float nextMenuSelectTime;

	private float nextMenuEnterTime;

	private float minSelectInterval = 0.06f;

	private bool queueSelect;

	private bool queueEnter;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			float volume = xp.volume;
			baseXpVolume = volume;
			float volume2 = gold.volume;
			baseGoldVolume = volume2;
		}
		else
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
	}

	private void Start()
	{
		//IL_019d: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_01fa: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		Delegate a_SavesLoaded = SaveManager.A_SavesLoaded;
		Action action = UpdateVolumes;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
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
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_0240;
			}
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0281;
			}
		}
		Action<string, object, object> b = OnSettingUpdate;
		Delegate obj6 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action3 = default(Action<string, object, object>);
		bool flag4 = action3 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_0230;
		}
		CurrentSettings.A_SettingUpdated = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_0240;
		IL_0240:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0230;
		IL_0281:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0281;
	}

	private void OnDestroy()
	{
		//IL_019d: Expected O, but got I4
		//IL_01e4: Expected O, but got I4
		//IL_01fa: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		Delegate a_SavesLoaded = SaveManager.A_SavesLoaded;
		Action action = UpdateVolumes;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
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
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_0240;
			}
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_0281;
			}
		}
		Action<string, object, object> value = OnSettingUpdate;
		Delegate obj6 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_SettingUpdated = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action3 = default(Action<string, object, object>);
		bool flag4 = action3 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_0230;
		}
		CurrentSettings.A_SettingUpdated = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_SavesLoaded = (Delegate)(object)typeof(Action<string, object, object>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_0240;
		IL_0240:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0230;
		IL_0281:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0281;
	}

	private void OnSettingUpdate(string settingName, object oldValue, object newValue)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFAudioSettings cfAudioSettings = config.cfAudioSettings;
			xpAndGoldVolume = cfAudioSettings.xp_and_gold;
		}
	}

	private void UpdateVolumes()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager2.config;
			CFAudioSettings cfAudioSettings = config.cfAudioSettings;
			xpAndGoldVolume = cfAudioSettings.xp_and_gold;
		}
	}

	public void PlayXp()
	{
		xp.Play();
		int num = xpPerInterval + 1;
		xpPerInterval = num;
	}

	public void PlayGold()
	{
		gold.Play();
		int num = goldPerInterval + 1;
		goldPerInterval = num;
	}

	public void PlaySilver()
	{
		silver.Play();
	}

	public void PlayNewMenuButton()
	{
		newMenuButton.Play();
	}

	private void Update()
	{
		//IL_005f: Invalid comparison between I4 and F4
		//IL_00aa: Expected F4, but got I4
		//IL_0109: Invalid comparison between I4 and F4
		//IL_0154: Expected F4, but got I4
		//IL_017d: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_01a6: Invalid comparison between I4 and F4
		//IL_01f1: Expected F4, but got I4
		//IL_0414: Invalid comparison between I4 and F4
		//IL_022d: Expected F4, but got I4
		//IL_0243: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_026c: Invalid comparison between I4 and F4
		//IL_02b7: Expected F4, but got I4
		//IL_0456: Invalid comparison between I4 and F4
		//IL_02f3: Expected F4, but got I4
		float volume = xp.volume;
		float num = xpVolumeMultiplier * baseXpVolume;
		float num2 = num * xpAndGoldVolume;
		float deltaTime = Time.deltaTime;
		float num3 = deltaTime * 0.4f;
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
		float num4 = num2 - volume;
		float num5 = num4 * num3;
		float volume2 = num5 + volume;
		xp.volume = volume2;
		float volume3 = gold.volume;
		float num6 = goldVolumeMultiplier * baseGoldVolume;
		float num7 = num6 * xpAndGoldVolume;
		float deltaTime2 = Time.deltaTime;
		float num8 = deltaTime2 * 0.4f;
		if (!(0f > num8))
		{
			if (num8 > 1f)
			{
				num8 = 1f;
			}
		}
		else
		{
			num8 = 0f;
		}
		float num9 = num7 - volume3;
		float num10 = num9 * num8;
		float volume4 = num10 + volume3;
		gold.volume = volume4;
		if (nextIntervalCheck > MyTime.time)
		{
			return;
		}
		float num11 = MyTime.time + interval;
		nextIntervalCheck = num11;
		float num12;
		if (xpPerInterval <= minPerInterval)
		{
			num12 = 1f;
		}
		else
		{
			object obj = xpPerInterval - minPerInterval;
			object obj2 = maxPerInterval - minPerInterval;
			float num13 = (float)obj / (float)obj2;
			if (!(0f > num13))
			{
				if (num13 > 1f)
				{
					num13 = 1f;
				}
			}
			else
			{
				num13 = 0f;
			}
			if (!(0f > num13))
			{
				if (num13 > 1f)
				{
					num13 = 1f;
				}
			}
			else
			{
				num13 = 0f;
			}
			float num14 = num13 * -0.14999998f;
			num12 = num14 + 1f;
		}
		xpVolumeMultiplier = num12;
		bool flag = goldPerInterval <= minPerInterval;
		float num15 = 1f;
		if (!flag)
		{
			object obj3 = goldPerInterval - minPerInterval;
			object obj4 = maxPerInterval - minPerInterval;
			float num16 = (float)obj3 / (float)obj4;
			if (!(0f > num16))
			{
				if (num16 > 1f)
				{
					num16 = 1f;
				}
			}
			else
			{
				num16 = 0f;
			}
			if (!(0f > num16))
			{
				if (num16 > 1f)
				{
					num16 = 1f;
				}
			}
			else
			{
				num16 = 0f;
			}
			float num17 = num16 * -0.14999998f;
			float num18 = num17 + 1f;
			num15 = num18;
		}
		goldVolumeMultiplier = num15;
		xpPerInterval = 0;
	}

	private void LateUpdate()
	{
		RandomSfx randomSfx;
		if (queueEnter)
		{
			if (!queueSelect)
			{
				goto IL_006f;
			}
			randomSfx = uiClick;
		}
		else
		{
			if (!queueSelect)
			{
				goto IL_006f;
			}
			randomSfx = uiSelect;
		}
		goto IL_00ac;
		IL_00c4:
		queueSelect = false;
		return;
		IL_00ac:
		randomSfx.Play();
		goto IL_00c4;
		IL_006f:
		if (queueEnter)
		{
			randomSfx = uiClick;
			goto IL_00ac;
		}
		goto IL_00c4;
	}

	public void PlayButtonSelect()
	{
		float time = Time.time;
		if (!(nextMenuSelectTime > time))
		{
			float time2 = Time.time;
			if (!(nextMenuEnterTime > time2))
			{
				float time3 = Time.time;
				float num = time3 + minSelectInterval;
				queueSelect = true;
				nextMenuSelectTime = num;
			}
		}
	}

	public void PlayButtonEnter()
	{
		float time = Time.time;
		if (!(nextMenuEnterTime > time))
		{
			float time2 = Time.time;
			float num = time2 + minSelectInterval;
			queueEnter = true;
			nextMenuEnterTime = num;
		}
	}

	public void PlaySfx(AudioClip clip)
	{
		RandomSfx randomSfx = customSfx;
		randomSfx.sounds = new AudioClip[1] { clip };
		customSfx.Play();
	}

	public void Bullseye()
	{
		bullseye.Play();
	}

	public void PlayDungeonDoorEnter()
	{
		dungeonDoorEnter.Play();
	}
}
