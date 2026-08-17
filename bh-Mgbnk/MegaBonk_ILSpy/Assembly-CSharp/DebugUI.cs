using System;
using System.Linq;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class DebugUI : MonoBehaviour
{
	public TextMeshProUGUI t_fps;

	public TextMeshProUGUI t_speed;

	public TextMeshProUGUI t_ram;

	private float fpsTimer;

	private int frameCount;

	private float fpsUpdateInterval = 0.25f;

	private float[] speedSamples = new float[2];

	private int speedSampleIndex;

	private float sampleSpeedInterval = 0.1f;

	private float sampleRamInterval = 0.5f;

	private void Awake()
	{
		//IL_048f: Expected I, but got O
		//IL_0498: Expected O, but got I4
		//IL_04a1: Expected O, but got I4
		//IL_044d: Expected I, but got O
		//IL_0456: Expected O, but got I4
		//IL_045f: Expected O, but got I4
		//IL_0160: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_0554: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_022a: Expected O, but got I4
		//IL_0258: Expected O, but got I4
		//IL_0281: Expected O, but got I4
		//IL_02b7: Expected O, but got I4
		//IL_058c: Expected O, but got I4
		//IL_030b: Expected O, but got I4
		//IL_034b: Expected O, but got I4
		//IL_0379: Expected O, but got I4
		//IL_03a2: Expected O, but got I4
		InvokeRepeating("SampleSpeed", 0f, sampleSpeedInterval);
		InvokeRepeating("SampleRam", 0f, sampleRamInterval);
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		object obj2;
		GameObject gameObject2;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager.config != null)
		{
			if ((object)t_fps != null)
			{
				GameObject gameObject = t_fps.gameObject;
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				bool flag = (object)SaveManager._003CInstance_003Ek__BackingField == null;
				gameObject2 = gameObject;
				if (!flag)
				{
					ConfigSaveFile config = saveManager2.config;
					bool flag2 = saveManager2.config == null;
					gameObject2 = gameObject;
					if (!flag2)
					{
						CFGameSettings cfGameSettings = config.cfGameSettings;
						bool flag3 = config.cfGameSettings == null;
						gameObject2 = gameObject;
						if (!flag3)
						{
							bool flag4 = (object)gameObject == null;
							gameObject2 = gameObject;
							if (!flag4)
							{
								object obj = cfGameSettings.debug_fps - 1;
								bool active = obj == null;
								gameObject.SetActive(active);
								bool flag5 = (object)t_speed == null;
								obj2 = 0;
								gameObject2 = gameObject;
								if (!flag5)
								{
									GameObject gameObject3 = t_speed.gameObject;
									SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
									bool flag6 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
									obj2 = 0;
									gameObject2 = gameObject3;
									if (!flag6)
									{
										ConfigSaveFile config2 = saveManager3.config;
										bool flag7 = saveManager3.config == null;
										obj2 = 0;
										gameObject2 = gameObject3;
										if (!flag7)
										{
											CFGameSettings cfGameSettings2 = config2.cfGameSettings;
											bool flag8 = config2.cfGameSettings == null;
											obj2 = 0;
											gameObject2 = gameObject3;
											if (!flag8)
											{
												bool flag9 = (object)gameObject3 == null;
												obj2 = 0;
												gameObject2 = gameObject3;
												if (!flag9)
												{
													object obj3 = cfGameSettings2.debug_speed - 1;
													bool active2 = obj3 == null;
													gameObject3.SetActive(active2);
													bool flag10 = (object)t_ram == null;
													obj2 = 0;
													gameObject2 = gameObject3;
													if (!flag10)
													{
														GameObject gameObject4 = t_ram.gameObject;
														SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
														bool flag11 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
														obj2 = 0;
														gameObject2 = gameObject4;
														if (!flag11)
														{
															ConfigSaveFile config3 = saveManager4.config;
															bool flag12 = saveManager4.config == null;
															obj2 = 0;
															gameObject2 = gameObject4;
															if (!flag12)
															{
																CFGameSettings cfGameSettings3 = config3.cfGameSettings;
																bool flag13 = config3.cfGameSettings == null;
																obj2 = 0;
																gameObject2 = gameObject4;
																if (!flag13)
																{
																	bool flag14 = (object)gameObject4 == null;
																	obj2 = 0;
																	gameObject2 = gameObject4;
																	if (!flag14)
																	{
																		object obj4 = cfGameSettings3.debug_ram - 1;
																		bool active3 = obj4 == null;
																		gameObject4.SetActive(active3);
																		goto IL_04ff;
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
						}
					}
				}
			}
			goto IL_04e4;
		}
		goto IL_04ff;
		IL_04e4:
		throw new NullReferenceException();
		IL_04ff:
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj5 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj5 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj5;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action = default(Action<string, object, object>);
		nint num;
		object obj7;
		if (action != null)
		{
			CurrentSettings.A_SettingUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj6 = default(object);
			bool flag15 = obj6 == null;
			num = (nint)typeof(Action<string, object, object>);
			obj7 = 0;
			obj2 = 0;
			gameObject2 = (GameObject)(object)obj5;
			if (flag15)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = (nint)typeof(Action<string, object, object>);
		obj7 = 0;
		obj2 = 0;
		gameObject2 = (GameObject)(object)obj5;
		goto IL_04e4;
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<string, object, object> value = OnSettingUpdated;
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

	private void OnSettingUpdated(string setting, object oldValue, object newValue)
	{
		//IL_02d1: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		//IL_00a2: Expected O, but got I4
		//IL_0306: Expected O, but got I4
		//IL_0205: Expected O, but got I4
		//IL_00d7: Expected O, but got I4
		//IL_032c: Expected O, but got I4
		//IL_022b: Expected O, but got I4
		//IL_00fd: Expected O, but got I4
		//IL_034a: Expected O, but got I
		//IL_0352: Expected I, but got O
		//IL_0249: Expected O, but got I
		//IL_0251: Expected I, but got O
		//IL_011b: Expected O, but got I
		//IL_0123: Expected I, but got O
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EDB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject2;
		if (setting != "debug_fps")
		{
			if (setting != "debug_speed")
			{
				if (!(setting == "debug_ram"))
				{
					return;
				}
				Component component = t_ram;
				bool flag = (object)t_ram == null;
				object obj = 0;
				if (!flag)
				{
					GameObject gameObject = t_ram.gameObject;
					bool flag2 = (object)gameObject == null;
					obj = 0;
					if (!flag2)
					{
						bool flag3 = newValue == null;
						obj = 0;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							object obj2 = 0;
							nint num = (nint)newValue;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v12 (Il2CppClass<System.Object>)+40]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v351 @ r8_v8+40]");
							bool flag4 = num2 != 0;
							Component component2 = (Component)newValue;
							gameObject2 = gameObject;
							obj = obj2;
							component = (Component)newValue;
							if (!flag4)
							{
								goto IL_0172;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
							goto IL_03ea;
						}
					}
				}
			}
			else
			{
				Component component = t_speed;
				bool flag5 = (object)t_speed == null;
				object obj = 0;
				if (!flag5)
				{
					GameObject gameObject3 = t_speed.gameObject;
					bool flag6 = (object)gameObject3 == null;
					obj = 0;
					if (!flag6)
					{
						bool flag7 = newValue == null;
						obj = 0;
						if (!flag7)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							obj = 0;
							nint num3 = (nint)newValue;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rdx_v16 (Il2CppClass<System.Object>)+40]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r8_v2+40]");
							bool flag8 = num4 != 0;
							component = (Component)newValue;
							if (!flag8)
							{
								object obj2 = obj;
								nint num = num3;
								Component component2 = (Component)newValue;
								gameObject2 = gameObject3;
								goto IL_0172;
							}
							goto IL_03ea;
						}
					}
				}
			}
		}
		else
		{
			Component component = t_fps;
			bool flag9 = (object)t_fps == null;
			object obj = 0;
			if (!flag9)
			{
				GameObject gameObject4 = t_fps.gameObject;
				bool flag10 = (object)gameObject4 == null;
				obj = 0;
				if (!flag10)
				{
					bool flag11 = newValue == null;
					obj = 0;
					if (!flag11)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						obj = 0;
						nint num5 = (nint)newValue;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rdx_v10 (Il2CppClass<System.Object>)+40]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ r8_v2+40]");
						bool flag12 = num6 != 0;
						component = (Component)newValue;
						if (!flag12)
						{
							object obj2 = obj;
							nint num = num5;
							Component component2 = (Component)newValue;
							gameObject2 = gameObject4;
							goto IL_0172;
						}
						goto IL_03fa;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0172:
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
		object obj4 = default(object);
		object obj3 = obj4 - 1;
		bool active = obj3 == null;
		gameObject2.SetActive(active);
		return;
		IL_03ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03fa;
		IL_03fa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EDC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = t_fps.gameObject;
		if (gameObject.activeInHierarchy)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = unscaledDeltaTime + fpsTimer;
			int num2 = ++frameCount;
			fpsTimer = num;
			if (!(num < fpsUpdateInterval))
			{
				float num3 = (float)num2 / num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text = $"FPS: {arg}";
				t_fps.text = text;
				fpsTimer = 0f;
			}
		}
	}

	private void UpdateFps()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EDC]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = t_fps.gameObject;
		if (gameObject.activeInHierarchy)
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			float num = unscaledDeltaTime + fpsTimer;
			int num2 = ++frameCount;
			fpsTimer = num;
			if (!(num < fpsUpdateInterval))
			{
				float num3 = (float)num2 / num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text = $"FPS: {arg}";
				t_fps.text = text;
				fpsTimer = 0f;
			}
		}
	}

	private void SampleSpeed()
	{
		GameObject gameObject = t_speed.gameObject;
		if (!gameObject.activeInHierarchy || !(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		if (playerMovement.rb != null)
		{
			if (MyPlayer.Instance != null)
			{
				float[] array = speedSamples;
				MyPlayer instance2 = MyPlayer.Instance;
				float speedHorizontal = instance2.playerMovement.GetSpeedHorizontal();
				int num = speedSampleIndex % array.Length;
				array[num] = speedHorizontal;
				int num2 = speedSampleIndex + 1;
				speedSampleIndex = num2;
				float num3 = Enumerable.Average(speedSamples);
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				object arg = default(object);
				string text = $"SPD: {arg:F1}";
				t_speed.text = text;
			}
			else
			{
				t_speed.text = "SPD: 0";
			}
		}
	}

	private void SampleRam()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172EDE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		GameObject gameObject = t_ram.gameObject;
		if (gameObject.activeInHierarchy)
		{
			long totalReservedMemoryLong = Profiler.GetTotalReservedMemoryLong();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,rax\"");
			int systemMemorySize = SystemInfo.systemMemorySize;
			if (systemMemorySize <= 0)
			{
				systemMemorySize = 16000;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			object arg2 = default(object);
			string text = $"RAM: {arg:N0} MB ({arg2:N0}%)";
			t_ram.text = text;
		}
	}
}
