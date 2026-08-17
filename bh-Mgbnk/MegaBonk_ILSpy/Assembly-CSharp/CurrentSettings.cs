using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSettingsTypes;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class CurrentSettings : MonoBehaviour
{
	private sealed class _003CDoUpdateResolution_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int index;

		public CurrentSettings _003C_003E4__this;

		public int oldValue;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoUpdateResolution_003Ed__17(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0065: Expected O, but got I4
			//IL_006e: Expected O, but got I4
			//IL_0262: Expected I4, but got O
			//IL_0154: Expected O, but got I4
			//IL_0090: Expected O, but got Ref
			//IL_0090: Expected O, but got Ref
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00c1: Expected O, but got Ref
			//IL_0100: Expected O, but got I
			//IL_0115: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Resolution[] myResolutions = ConfigSettingsUtility.GetMyResolutions();
				int width = default(int);
				if (index < 0 || index >= myResolutions.Length)
				{
					object obj = 0;
					object obj2 = 0;
					Resolution resolution = default(Resolution);
					while ((nint)obj2 < myResolutions.Length)
					{
						Resolution currentResolution = Screen.currentResolution;
						if (!ConfigSettingsUtility.AreResolutionSame((Resolution)(&width), (Resolution)(&resolution)))
						{
							obj++;
							resolution = (Resolution)System.Runtime.CompilerServices.Unsafe.AsPointer(ref myResolutions[obj]);
							width = currentResolution.m_Width;
							obj2 = obj;
							continue;
						}
						goto IL_00e1;
					}
				}
				if (myResolutions == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				Resolution currentResolution2 = Screen.currentResolution;
				object obj3 = (Resolution)width;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1815154E0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					_003C_003E4__this.SetResolution(index);
					if (index != oldValue)
					{
						Action<int> revert = _003C_003E4__this.RevertResolution;
						Action<int> action = _003C_003E4__this.AcceptResolution;
						Action<int> accept = default(Action<int>);
						ResolutionListener.Instance.NewResolution(index, oldValue, revert, accept);
					}
				}
			}
			goto IL_0262;
			IL_0262:
			return false;
			IL_00e1:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v314 @ rax_v33+20]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v34+20]");
			object obj6 = 0;
			goto IL_0262;
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

	private sealed class _003CDoUpdateTargetMonitor_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int index;

		public CurrentSettings _003C_003E4__this;

		public int oldValue;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CDoUpdateTargetMonitor_003Ed__22(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0258: Expected I4, but got O
			//IL_01ab: Expected O, but got I
			//IL_00e1: Expected O, but got Ref
			//IL_020f: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				int currentDisplayIndex = MonitorController.GetCurrentDisplayIndex();
				if (index != currentDisplayIndex)
				{
					List<DisplayInfo> list = new List<DisplayInfo>();
					Screen.GetDisplayLayout(list);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.DisplayInfo>)+18]");
					if ((nint)0 != 0)
					{
						if (index >= 0)
						{
							int num = index;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.DisplayInfo>)+18]");
							if ((nint)num < (nint)0)
							{
								DisplayInfo displayInfo = list.get_Item(index);
								object obj = default(object);
								MonitorController.UseMonitor((DisplayInfo)(&obj));
								if (index != oldValue)
								{
									Action<int> revert = _003C_003E4__this.RevertTargetMonitor;
									Action<int> action = _003C_003E4__this.AcceptTargetMonitor;
									Action<int> accept = default(Action<int>);
									ResolutionListener.Instance.NewResolution(index, oldValue, revert, accept);
								}
								goto IL_015f;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
						object obj2 = default(object);
						if (obj2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v18+20]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rax_v18+20]");
							if ((nint)0 != 0 && (object)_003C_003E4__this != null)
							{
								CurrentSettings currentSettings = _003C_003E4__this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r9_v4+20]");
								object value = default(object);
								currentSettings.BetterUpdateCfSettings("target_monitor", value, (CFSettings)0);
								goto IL_015f;
							}
						}
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					Debug.LogError("No monitors found...");
				}
			}
			goto IL_015f;
			IL_015f:
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

	private sealed class _003CMoveToPrimaryDisplay_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CMoveToPrimaryDisplay_003Ed__27(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0137: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				List<DisplayInfo> list = new List<DisplayInfo>();
				Screen.GetDisplayLayout(list);
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v5 (System.Collections.Generic.List`1<UnityEngine.DisplayInfo>)+18]");
					if ((nint)0 > (nint)1)
					{
						DisplayInfo displayInfo = list.get_Item(0);
						DisplayInfo displayInfo2 = list.get_Item(0);
						DisplayInfo displayInfo3 = list.get_Item(0);
						object obj2 = default(object);
						object obj = obj2 >> 31;
						object obj3 = obj2 - obj;
						Vector2Int position = (Vector2Int)(obj3 >> 1);
						DisplayInfo display = default(DisplayInfo);
						AsyncOperation asyncOperation = Screen.MoveMainWindowTo(ref display, position);
						_003C_003E2__current = asyncOperation;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
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

	public AudioMixer audioMixer;

	public Material warningMaterial;

	public static CurrentSettings Instance;

	public static Action<EControllerType> A_ControllerTypeChanged;

	public static Action<string, object, object> A_SettingUpdated;

	public static Action<int> A_ResolutionChanged;

	private Resolution resolutionBeforeMonitorChange;

	private static bool firstResolutionChange = true;

	private void Awake()
	{
		//IL_017a: Expected I, but got O
		if ((bool)Instance)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		Action b = UpdateSave;
		Delegate obj2 = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		if ((object)obj2 == null)
		{
			SaveManager.A_SavesLoaded = null;
			goto IL_00d2;
		}
		bool flag = (object)obj2.GetType() != typeof(Action);
		Delegate obj3 = null;
		if (!flag)
		{
			obj3 = obj2;
		}
		bool flag2 = (object)obj3 == null;
		nint num = (nint)typeof(Action);
		if (!flag2)
		{
			SaveManager.A_SavesLoaded = (Action)obj3;
			bool flag3 = (object)obj2.GetType() != typeof(Action);
			Delegate obj4 = null;
			if (!flag3)
			{
				obj4 = obj2;
			}
			if ((object)obj4 != null)
			{
				goto IL_00d2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_00d2:
		if (SaveManager.loaded)
		{
			UpdateSave();
		}
	}

	private void Start()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317205B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("RefreshAudioMixer", 0f);
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = UpdateSave;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void UpdateSave()
	{
		//IL_0038: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_0196: Expected O, but got I4
		//IL_02e2: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		//IL_0437: Expected O, but got I4
		//IL_0440: Expected O, but got I4
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_058c: Expected O, but got I4
		//IL_0595: Expected O, but got I4
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_06e1: Expected O, but got I4
		//IL_06ea: Expected O, but got I4
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Expected O, but got Unknown
		//IL_07ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFGameSettings));
		FieldInfo[] fields = typeFromHandle.GetFields();
		object obj = 0;
		object obj2 = 0;
		Type type = default(Type);
		while ((nint)obj2 < fields.Length)
		{
			string text = fields[obj].Name;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			object value = fields[obj].GetValue(config.cfGameSettings);
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config2 = saveManager2.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field = type.GetField(text);
			object value2 = field.GetValue(config2.cfGameSettings);
			object value3 = field.GetValue(config2.cfGameSettings);
			field.SetValue(config2.cfGameSettings, value);
			OnSettingUpdated(text, value, value3);
			obj++;
			obj2 = obj;
		}
		Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFVideoSettings));
		FieldInfo[] fields2 = typeFromHandle2.GetFields();
		object obj3 = 0;
		object obj4 = 0;
		Type type2 = default(Type);
		while ((nint)obj4 < fields2.Length)
		{
			string text2 = fields2[obj3].Name;
			SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config3 = saveManager3.config;
			object value4 = fields2[obj3].GetValue(config3.cfVideoSettings);
			SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config4 = saveManager4.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field2 = type2.GetField(text2);
			object value5 = field2.GetValue(config4.cfVideoSettings);
			object value6 = field2.GetValue(config4.cfVideoSettings);
			field2.SetValue(config4.cfVideoSettings, value4);
			OnSettingUpdated(text2, value4, value6);
			obj3++;
			obj4 = obj3;
		}
		Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFControlSettings));
		FieldInfo[] fields3 = typeFromHandle3.GetFields();
		object obj5 = 0;
		object obj6 = 0;
		Type type3 = default(Type);
		while ((nint)obj6 < fields3.Length)
		{
			string text3 = fields3[obj5].Name;
			SaveManager saveManager5 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config5 = saveManager5.config;
			object value7 = fields3[obj5].GetValue(config5.cfControlSettings);
			SaveManager saveManager6 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config6 = saveManager6.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field3 = type3.GetField(text3);
			object value8 = field3.GetValue(config6.cfControlSettings);
			object value9 = field3.GetValue(config6.cfControlSettings);
			field3.SetValue(config6.cfControlSettings, value7);
			OnSettingUpdated(text3, value7, value9);
			obj5++;
			obj6 = obj5;
		}
		Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFAudioSettings));
		FieldInfo[] fields4 = typeFromHandle4.GetFields();
		object obj7 = 0;
		object obj8 = 0;
		Type type4 = default(Type);
		while ((nint)obj8 < fields4.Length)
		{
			string text4 = fields4[obj7].Name;
			SaveManager saveManager7 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config7 = saveManager7.config;
			object value10 = fields4[obj7].GetValue(config7.cfAudioSettings);
			SaveManager saveManager8 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config8 = saveManager8.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field4 = type4.GetField(text4);
			object value11 = field4.GetValue(config8.cfAudioSettings);
			object value12 = field4.GetValue(config8.cfAudioSettings);
			field4.SetValue(config8.cfAudioSettings, value10);
			OnSettingUpdated(text4, value10, value12);
			obj7++;
			obj8 = obj7;
		}
		Type typeFromHandle5 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFVisualsSettings));
		FieldInfo[] fields5 = typeFromHandle5.GetFields();
		object obj9 = 0;
		object obj10 = 0;
		Type type5 = default(Type);
		while ((nint)obj10 < fields5.Length)
		{
			string text5 = fields5[obj9].Name;
			SaveManager saveManager9 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config9 = saveManager9.config;
			object value13 = fields5[obj9].GetValue(config9.cfVisualsSettings);
			SaveManager saveManager10 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config10 = saveManager10.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field5 = type5.GetField(text5);
			object value14 = field5.GetValue(config10.cfVisualsSettings);
			object value15 = field5.GetValue(config10.cfVisualsSettings);
			field5.SetValue(config10.cfVisualsSettings, value13);
			OnSettingUpdated(text5, value13, value15);
			obj9++;
			obj10 = obj9;
		}
		Type typeFromHandle6 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFOtherSettings));
		FieldInfo[] fields6 = typeFromHandle6.GetFields();
		object obj11 = 0;
		object obj12 = 0;
		Type type6 = default(Type);
		while ((nint)obj12 < fields6.Length)
		{
			string text6 = fields6[obj11].Name;
			SaveManager saveManager11 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config11 = saveManager11.config;
			object value16 = fields6[obj11].GetValue(config11.cfOtherSettings);
			SaveManager saveManager12 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config12 = saveManager12.config;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
			FieldInfo field6 = type6.GetField(text6);
			object value17 = field6.GetValue(config12.cfOtherSettings);
			object value18 = field6.GetValue(config12.cfOtherSettings);
			field6.SetValue(config12.cfOtherSettings, value16);
			OnSettingUpdated(text6, value16, value18);
			obj11++;
			obj12 = obj11;
		}
		SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
		RuntimePlatform platform = Application.platform;
		if (platform == RuntimePlatform.OSXPlayer)
		{
			MyLogger.LogInBuild("im on osx, setting vsync on and capping fps");
			QualitySettings.vSyncCount = 1;
			Application.targetFrameRate = 60;
		}
	}

	public void BetterUpdateCfSettings(string settingName, object value, CFSettings cfSettings)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		Type type = default(Type);
		FieldInfo field = type.GetField(settingName);
		object value2 = field.GetValue(cfSettings);
		object value3 = field.GetValue(cfSettings);
		field.SetValue(cfSettings, value);
		OnSettingUpdated(settingName, value, value3);
	}

	private unsafe void OnSettingUpdated(string name, object value, object oldValue)
	{
		//IL_1847: Expected I, but got O
		//IL_1936: Expected I, but got O
		//IL_14ef: Expected I, but got O
		//IL_12ac: Expected I, but got O
		//IL_0d0a: Expected I, but got O
		//IL_186e: Expected I, but got O
		//IL_18a4: Expected I, but got O
		//IL_15fb: Expected I, but got O
		//IL_13d5: Expected I, but got O
		//IL_0f3c: Expected I, but got O
		//IL_0e03: Expected I, but got O
		//IL_06ae: Expected I, but got O
		//IL_195d: Expected I, but got O
		//IL_196d: Expected O, but got I
		//IL_1993: Expected I, but got O
		//IL_199b: Expected I, but got O
		//IL_1752: Expected I, but got O
		//IL_1516: Expected I, but got O
		//IL_154c: Expected I, but got O
		//IL_12d3: Expected I, but got O
		//IL_1309: Expected I, but got O
		//IL_103d: Expected I, but got O
		//IL_0d31: Expected I, but got O
		//IL_0d67: Expected I, but got O
		//IL_0a0d: Expected I, but got O
		//IL_08d3: Expected I, but got O
		//IL_07a7: Expected I, but got O
		//IL_00b0: Expected I, but got O
		//IL_18cd: Expected I4, but got O
		//IL_1622: Expected I, but got O
		//IL_1658: Expected I, but got O
		//IL_13fc: Expected I, but got O
		//IL_1432: Expected I, but got O
		//IL_1130: Expected I, but got O
		//IL_0f63: Expected I, but got O
		//IL_0f99: Expected I, but got O
		//IL_0e2a: Expected I, but got O
		//IL_0e3a: Expected O, but got I
		//IL_0e60: Expected I, but got O
		//IL_0e68: Expected I4, but got O
		//IL_0b59: Expected I, but got O
		//IL_06d5: Expected I, but got O
		//IL_070b: Expected I, but got O
		//IL_046f: Expected I, but got O
		//IL_19cf: Expected I, but got O
		//IL_1779: Expected I, but got O
		//IL_1789: Expected O, but got I
		//IL_17af: Expected I, but got O
		//IL_17b7: Expected I4, but got O
		//IL_1575: Unknown result type (might be due to invalid IL or missing references)
		//IL_157a: Expected O, but got Unknown
		//IL_1332: Expected I4, but got O
		//IL_1064: Expected I, but got O
		//IL_109a: Expected I, but got O
		//IL_0d8b: Expected I, but got O
		//IL_0d93: Expected O, but got I4
		//IL_0a34: Expected I, but got O
		//IL_0a44: Expected O, but got I
		//IL_0a6a: Expected I, but got O
		//IL_091e: Expected I, but got O
		//IL_092f: Expected O, but got I
		//IL_07ce: Expected I, but got O
		//IL_0804: Expected I, but got O
		//IL_05bd: Expected I, but got O
		//IL_00d7: Expected I, but got O
		//IL_00e7: Expected O, but got I
		//IL_010d: Expected I, but got O
		//IL_1340: Unknown result type (might be due to invalid IL or missing references)
		//IL_1345: Expected O, but got Unknown
		//IL_1360: Expected F4, but got O
		//IL_1157: Expected I, but got O
		//IL_1167: Expected O, but got I
		//IL_118d: Expected I, but got O
		//IL_1195: Expected I, but got O
		//IL_0fc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Expected I4, but got Unknown
		//IL_0e8c: Expected I, but got O
		//IL_1b39: Expected F4, but got O
		//IL_1b47: Expected F4, but got O
		//IL_0b80: Expected I, but got O
		//IL_0b90: Expected O, but got I
		//IL_0bb6: Expected I, but got O
		//IL_1ba6: Expected I4, but got O
		//IL_072f: Expected I, but got O
		//IL_0737: Expected O, but got I4
		//IL_0496: Expected I, but got O
		//IL_04a6: Expected O, but got I
		//IL_04cc: Expected I, but got O
		//IL_1ab7: Expected I4, but got O
		//IL_19fd: Expected I, but got O
		//IL_17db: Expected I, but got O
		//IL_10c3: Expected I4, but got O
		//IL_1bcb: Expected I4, but got O
		//IL_1bd8: Expected I4, but got O
		//IL_0945: Expected I, but got O
		//IL_097b: Expected I, but got O
		//IL_1b94: Expected O, but got I4
		//IL_082d: Expected I4, but got O
		//IL_05e4: Expected I, but got O
		//IL_05f4: Expected O, but got I
		//IL_061a: Expected I, but got O
		//IL_1af6: Expected I4, but got O
		//IL_1686: Expected I4, but got O
		//IL_16a0: Expected I, but got O
		//IL_11c9: Expected I, but got O
		//IL_0ada: Expected I4, but got O
		//IL_083f: Expected I4, but got O
		//IL_1b15: Expected I4, but got O
		//IL_1b22: Expected I4, but got O
		//IL_1bfa: Expected I, but got O
		//IL_063e: Expected I, but got O
		//IL_0528: Expected I4, but got O
		//IL_052c: Expected I4, but got O
		//IL_1d88: Expected I, but got O
		//IL_16ee: Expected O, but got Ref
		//IL_11f7: Expected I, but got O
		//IL_054c: Expected F4, but got O
		//IL_1cb5: Expected I, but got O
		//IL_015a: Expected I, but got O
		//IL_0186: Expected O, but got I
		//IL_01a2: Expected I, but got O
		//IL_0c59: Expected I4, but got O
		//IL_01ce: Expected O, but got I
		//IL_01ea: Expected I, but got O
		//IL_0246: Expected I, but got O
		//IL_0274: Expected I, but got O
		//IL_027c: Expected O, but got I
		//IL_02b0: Expected I, but got O
		//IL_02b8: Expected O, but got I
		//IL_02ec: Expected I, but got O
		//IL_030e: Expected I, but got O
		//IL_033c: Expected I, but got O
		//IL_0344: Expected O, but got I
		//IL_0396: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804BF510");
		object obj = default(object);
		object obj6;
		string groupVolumeName;
		int num16;
		int num21;
		nint num39;
		int num44;
		string text;
		nint num60;
		nint num;
		string text2;
		float num10;
		if ((long)obj > 2539662121L)
		{
			if ((long)obj > 3119462523L)
			{
				if ((long)obj > 3394781895L)
				{
					if ((long)obj == 3574321017L)
					{
						if (name == "skip_chest_animation")
						{
							bool flag = value == null;
							num = unchecked((nint)null);
							text = "skip_chest_animation";
							text2 = name;
							if (!flag)
							{
								nint num2 = (nint)value;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
								text = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1129 @ rcx_v138 (Il2CppClass<System.Object>)+40]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
								bool flag2 = num3 != 0;
								num = unchecked((nint)null);
								text2 = (string)value;
								if (flag2)
								{
									Locale locale = ((List<Locale>)(object)text2).get_Item((int)text);
									goto IL_1ae9;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								object obj2 = default(object);
								if (obj2 == null)
								{
									goto IL_03d6;
								}
								text = (string)(object)SaveManager._003CInstance_003Ek__BackingField;
								bool flag3 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
								num = unchecked((nint)null);
								text2 = (string)(object)typeof(SaveManager);
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+20]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+20]");
									bool flag4 = (nint)0 == 0;
									num = unchecked((nint)null);
									text2 = (string)(object)typeof(SaveManager);
									if (!flag4)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v169+50]");
										object obj4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ rax_v169+50]");
										bool flag5 = (nint)0 == 0;
										num = unchecked((nint)null);
										text2 = (string)(object)typeof(SaveManager);
										if (!flag5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v170+29]");
											if ((nint)0 != 0)
											{
												goto IL_03d6;
											}
											nint num4 = (nint)typeof(SaveManager);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2399 @ rax_v174 (Il2CppClass<SaveManager>)+B8]");
											nint num5 = 0;
											SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
											bool flag6 = (object)SaveManager._003CInstance_003Ek__BackingField == null;
											num = unchecked((nint)null);
											text2 = (string)num5;
											if (!flag6)
											{
												ConfigSaveFile config = saveManager.config;
												bool flag7 = saveManager.config == null;
												num = unchecked((nint)null);
												text2 = (string)num5;
												if (!flag7)
												{
													text2 = (string)(object)config.preferences;
													bool flag8 = config.preferences == null;
													num = unchecked((nint)null);
													if (!flag8)
													{
														_ = 1;
														nint num6 = (nint)typeof(AlwaysUi);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2404 @ rax_v177 (Il2CppClass<AlwaysUi>)+B8]");
														nint num7 = 0;
														AlwaysUi instance = AlwaysUi.Instance;
														bool flag9 = (object)AlwaysUi.Instance == null;
														num = unchecked((nint)null);
														text2 = (string)num7;
														if (!flag9)
														{
															string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "WARNING");
															string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "CHESTSKIPWARNING");
															bool flag10 = (object)instance.dynamicWindows == null;
															num = unchecked((nint)null);
															text = "CHESTSKIPWARNING";
															text2 = "DynamicWindows";
															if (!flag10)
															{
																instance.dynamicWindows.NewWindow(localizedString, localizedString2);
																goto IL_03d6;
															}
														}
													}
												}
											}
										}
									}
								}
							}
							goto IL_1a70;
						}
					}
					else if ((long)obj == 3582686958L)
					{
						if (name == "anti_aliasing")
						{
							bool flag11 = value == null;
							num = unchecked((nint)null);
							text = "anti_aliasing";
							text2 = name;
							if (flag11)
							{
								goto IL_1a70;
							}
							nint num8 = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							text = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1525 @ rcx_v132 (Il2CppClass<System.Object>)+40]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
							bool flag12 = num9 != 0;
							num = unchecked((nint)null);
							text2 = (string)value;
							if (flag12)
							{
								goto IL_1ae9;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							object obj5 = default(object);
							if (obj5 == null)
							{
								QualitySettings.antiAliasing = 0;
							}
							else
							{
								int antiAliasing = (int)((List<Locale>)obj5).get_Item((int)text);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
								QualitySettings.antiAliasing = antiAliasing;
								num10 = (float)obj5;
								float num11 = 2f;
							}
						}
					}
					else if ((long)obj == 4094074503L && name == "game_sfx")
					{
						bool flag13 = value == null;
						num = unchecked((nint)null);
						text = "game_sfx";
						text2 = name;
						if (flag13)
						{
							goto IL_1a70;
						}
						nint num12 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1918 @ rcx_v129 (Il2CppClass<System.Object>)+40]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag14 = num13 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag14)
						{
							goto IL_1b08;
						}
						groupVolumeName = "GameSfxVolume";
						nint num14 = unchecked((nint)null);
						object obj7 = value;
						goto IL_1b27;
					}
				}
				else if ((long)obj == 3147452822L)
				{
					if (name == "master_volume")
					{
						bool flag15 = value == null;
						num = unchecked((nint)null);
						text = "master_volume";
						text2 = name;
						if (flag15)
						{
							goto IL_1a70;
						}
						nint num15 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						num16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1423 @ rcx_v126 (Il2CppClass<System.Object>)+40]");
						nint num17 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1986 @ rdx_v20 (System.Int32)+40]");
						bool flag16 = num17 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (!flag16)
						{
							groupVolumeName = "MasterVolume";
							nint num14 = unchecked((nint)null);
							text = (string)num16;
							object obj7 = value;
							goto IL_1b27;
						}
						goto IL_1b4c;
					}
				}
				else if ((long)obj == 3394781895L && name == "shadow_quality")
				{
					bool flag17 = value == null;
					num = unchecked((nint)null);
					text = "shadow_quality";
					text2 = name;
					if (flag17)
					{
						goto IL_1a70;
					}
					nint num18 = (nint)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
					num16 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1578 @ rcx_v121 (Il2CppClass<System.Object>)+40]");
					nint num19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1986 @ rdx_v20 (System.Int32)+40]");
					bool flag18 = num19 != 0;
					num = unchecked((nint)null);
					obj6 = value;
					if (flag18)
					{
						goto IL_1b63;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object obj8 = default(object);
					QualitySettings.shadows = (UnityEngine.ShadowQuality)obj8;
					int shadowCascades = (int)(obj8 + obj8);
					QualitySettings.shadowCascades = shadowCascades;
				}
			}
			else
			{
				if ((long)obj <= 2931535181L)
				{
					if ((long)obj == 2677821396L)
					{
						if (!(name == "music"))
						{
							goto IL_03d6;
						}
						bool flag19 = value == null;
						num = unchecked((nint)null);
						text = "music";
						text2 = name;
						if (flag19)
						{
							goto IL_1a70;
						}
						nint num20 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						num21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1461 @ rcx_v94 (Il2CppClass<System.Object>)+40]");
						nint num22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2036 @ rdx_v14 (System.Int32)+40]");
						bool flag20 = num22 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag20)
						{
							goto IL_1c0d;
						}
						groupVolumeName = "MusicVolume";
						nint num14 = unchecked((nint)null);
						text = (string)num21;
						object obj7 = value;
					}
					else
					{
						if ((long)obj != 2931535181L || !(name == "ambience"))
						{
							goto IL_03d6;
						}
						bool flag21 = value == null;
						num = unchecked((nint)null);
						text = "ambience";
						text2 = name;
						if (flag21)
						{
							goto IL_1a70;
						}
						nint num23 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1685 @ rcx_v91 (Il2CppClass<System.Object>)+40]");
						nint num24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag22 = num24 != 0;
						num = unchecked((nint)null);
						num21 = (int)text;
						obj6 = value;
						if (flag22)
						{
							goto IL_1c24;
						}
						groupVolumeName = "AmbienceVolume";
						nint num14 = unchecked((nint)null);
						object obj7 = value;
					}
					goto IL_1b27;
				}
				if ((long)obj == 2942216506L)
				{
					if (name == "controller_type")
					{
						nint num25 = (nint)typeof(CurrentSettings);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v493 @ rax_v140 (Il2CppClass<CurrentSettings>)+B8]");
						nint num26 = 0;
						Action<EControllerType> a_ControllerTypeChanged = A_ControllerTypeChanged;
						if (A_ControllerTypeChanged != null)
						{
							bool flag23 = value == null;
							num = unchecked((nint)null);
							text = "controller_type";
							text2 = (string)num26;
							if (flag23)
							{
								goto IL_1a70;
							}
							nint num27 = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							num16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1974 @ rcx_v117 (Il2CppClass<System.Object>)+40]");
							nint num28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1986 @ rdx_v20 (System.Int32)+40]");
							bool flag24 = num28 != 0;
							num = unchecked((nint)null);
							obj6 = value;
							if (flag24)
							{
								goto IL_1b7a;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v430 @ rbx_v34 (System.Action`1<EControllerType>)+18] (should have been resolved before IL gen)");
						}
					}
				}
				else if ((long)obj == 3078805355L)
				{
					if (name == "input_delay")
					{
						bool flag25 = value == null;
						num = unchecked((nint)null);
						text = "input_delay";
						text2 = name;
						if (flag25)
						{
							goto IL_1a70;
						}
						nint num29 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ rcx_v109 (Il2CppClass<System.Object>)+40]");
						nint num30 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag26 = num30 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag26)
						{
							goto IL_1b99;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,dword ptr [rax]\"");
						if ((nint)value >= 7)
						{
							QualitySettings.maxQueuedFrames = 6;
						}
						else
						{
							bool flag27 = (nint)value >= 0;
							int maxQueuedFrames = (int)value;
							if (!flag27)
							{
								maxQueuedFrames = 0;
							}
							QualitySettings.maxQueuedFrames = maxQueuedFrames;
						}
					}
				}
				else if ((long)obj == 3119462523L && name == "language")
				{
					bool flag28 = value == null;
					num = unchecked((nint)null);
					text = "language";
					text2 = name;
					if (!flag28)
					{
						nint num31 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2016 @ rcx_v97 (Il2CppClass<System.Object>)+40]");
						nint num32 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag29 = num32 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag29)
						{
							goto IL_1bbe;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
						bool flag30 = availableLocales == null;
						num = unchecked((nint)null);
						text2 = null;
						if (!flag30)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
							List<Locale> list = default(List<Locale>);
							object obj9 = default(object);
							if (list != null && (nint)obj9 >= 0 && (nint)obj9 < list._size)
							{
								LocalizationSettings instance2 = LocalizationSettings.Instance;
								Locale selectedLocale = list.get_Item((int)obj9);
								bool flag31 = (object)instance2 == null;
								num = 0;
								text = (string)obj9;
								text2 = (string)(object)list;
								if (flag31)
								{
									goto IL_1a70;
								}
								instance2.SetSelectedLocale(selectedLocale);
							}
							goto IL_03d6;
						}
					}
					goto IL_1a70;
				}
			}
		}
		else if ((nint)obj > 1547907707)
		{
			if ((nint)obj > 1894656452)
			{
				if ((long)obj == 2206693122L)
				{
					if (name == "texture_quality")
					{
						bool flag32 = value == null;
						num = unchecked((nint)null);
						text = "texture_quality";
						text2 = name;
						if (flag32)
						{
							goto IL_1a70;
						}
						nint num33 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						num21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1476 @ rcx_v81 (Il2CppClass<System.Object>)+40]");
						nint num34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2036 @ rdx_v14 (System.Int32)+40]");
						bool flag33 = num34 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag33)
						{
							goto IL_1c3b;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj10 = default(object);
						int globalTextureMipmapLimit = 3 - obj10;
						QualitySettings.globalTextureMipmapLimit = globalTextureMipmapLimit;
					}
				}
				else if ((long)obj == 2400797266L)
				{
					if (name == "fullscreen_mode")
					{
						bool flag34 = value == null;
						num = unchecked((nint)null);
						text = "fullscreen_mode";
						text2 = name;
						if (flag34)
						{
							goto IL_1a70;
						}
						nint num35 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						num21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1738 @ rcx_v77 (Il2CppClass<System.Object>)+40]");
						nint num36 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2036 @ rdx_v14 (System.Int32)+40]");
						bool flag35 = num36 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag35)
						{
							goto IL_1c52;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj11 = default(object);
						Screen.fullScreenMode = (FullScreenMode)obj11;
					}
				}
				else if ((long)obj == 2539662121L && name == "target_monitor")
				{
					bool flag36 = oldValue == null;
					num = unchecked((nint)null);
					text = "target_monitor";
					text2 = name;
					if (!flag36)
					{
						nint num37 = (nint)oldValue;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2052 @ rcx_v69 (Il2CppClass<System.Object>)+40]");
						nint num38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag37 = num38 != 0;
						num = unchecked((nint)null);
						num39 = (nint)text;
						obj6 = oldValue;
						if (flag37)
						{
							goto IL_1c69;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						bool flag38 = value == null;
						num = unchecked((nint)null);
						text2 = (string)oldValue;
						if (!flag38)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
							num = 0;
							nint num40 = (nint)value;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2204 @ rdx_v55 (Il2CppClass<System.Object>)+40]");
							nint num41 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2333 @ r8_v26 (Il2CppMethodInfo)+40]");
							bool flag39 = num41 != 0;
							obj6 = value;
							if (flag39)
							{
								goto IL_1c88;
							}
							object obj13 = default(object);
							object obj12 = obj13;
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
							object obj15 = default(object);
							object obj14 = obj15;
							nint num42 = (nint)typeof(_003CDoUpdateTargetMonitor_003Ed__22);
							goto IL_1d8d;
						}
					}
					goto IL_1a70;
				}
			}
			else if ((nint)obj == 1755353376)
			{
				if (name == "shadow_resolution")
				{
					bool flag40 = value == null;
					num = unchecked((nint)null);
					text = "shadow_resolution";
					text2 = name;
					if (flag40)
					{
						goto IL_1a70;
					}
					nint num43 = (nint)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
					num44 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1480 @ rcx_v65 (Il2CppClass<System.Object>)+40]");
					nint num45 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rdx_v5 (System.Int32)+40]");
					bool flag41 = num45 != 0;
					num = unchecked((nint)null);
					obj6 = value;
					if (flag41)
					{
						goto IL_1cba;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object obj16 = default(object);
					QualitySettings.shadowResolution = (UnityEngine.ShadowResolution)obj16;
					object obj17 = obj16 * 4;
					object obj18 = obj16 + obj17;
					float num46 = (QualitySettings.shadowDistance = obj18 << 3);
					float num11 = num46;
				}
			}
			else if ((nint)obj == 1894656452 && name == "fps_limit")
			{
				bool flag42 = value == null;
				num = unchecked((nint)null);
				text = "fps_limit";
				text2 = name;
				if (flag42)
				{
					goto IL_1a70;
				}
				nint num48 = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
				num44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1780 @ rcx_v61 (Il2CppClass<System.Object>)+40]");
				nint num49 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rdx_v5 (System.Int32)+40]");
				bool flag43 = num49 != 0;
				num = unchecked((nint)null);
				obj6 = value;
				if (flag43)
				{
					goto IL_1cd1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,dword ptr [rax]\"");
				UpdateMaxFps(num44);
			}
		}
		else if ((nint)obj > 488725647)
		{
			if ((nint)obj != 1341745145)
			{
				if ((nint)obj == 1516116007)
				{
					if (!(name == "warning_color"))
					{
						goto IL_03d6;
					}
					bool flag44 = value == null;
					num = unchecked((nint)null);
					text = "warning_color";
					text2 = name;
					if (!flag44)
					{
						nint num50 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
						num44 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1821 @ rcx_v48 (Il2CppClass<System.Object>)+40]");
						nint num51 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rdx_v5 (System.Int32)+40]");
						bool flag45 = num51 != 0;
						num = unchecked((nint)null);
						obj6 = value;
						if (flag45)
						{
							goto IL_1cff;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
						object obj19 = default(object);
						Color warningColor = MyColorUtility.GetWarningColor((EHpBarColor)obj19);
						bool flag46 = (object)warningMaterial == null;
						num = unchecked((nint)null);
						text = (string)obj19;
						text2 = (string)(object)warningMaterial;
						if (!flag46)
						{
							num10 = warningColor.g;
							float num11 = warningColor.b;
							object obj20 = default(object);
							warningMaterial.SetColor("_MainColor", (Color)(&obj20));
							goto IL_03d6;
						}
					}
				}
				else
				{
					if ((nint)obj != 1547907707 || !(name == "ui"))
					{
						goto IL_03d6;
					}
					bool flag47 = value == null;
					num = unchecked((nint)null);
					text = "ui";
					text2 = name;
					if (!flag47)
					{
						nint num52 = (nint)value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
						text = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2087 @ rcx_v45 (Il2CppClass<System.Object>)+40]");
						nint num53 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
						bool flag48 = num53 != 0;
						num = unchecked((nint)null);
						num44 = (int)text;
						obj6 = value;
						if (!flag48)
						{
							groupVolumeName = "UiVolume";
							nint num14 = unchecked((nint)null);
							object obj7 = value;
							goto IL_1b27;
						}
						goto IL_1d1b;
					}
				}
				goto IL_1a70;
			}
			if (name == "soft_particles")
			{
				bool flag49 = value == null;
				num = unchecked((nint)null);
				text = "soft_particles";
				text2 = name;
				if (flag49)
				{
					goto IL_1a70;
				}
				nint num54 = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				num44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1485 @ rcx_v57 (Il2CppClass<System.Object>)+40]");
				nint num55 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rdx_v5 (System.Int32)+40]");
				bool flag50 = num55 != 0;
				num = unchecked((nint)null);
				obj6 = value;
				if (flag50)
				{
					goto IL_1ce8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj22 = default(object);
				object obj21 = obj22 - 1;
				bool softParticles = obj21 == null;
				QualitySettings.softParticles = softParticles;
			}
		}
		else if ((nint)obj == 116977766)
		{
			if (name == "vsync")
			{
				bool flag51 = value == null;
				num = unchecked((nint)null);
				text = "vsync";
				text2 = name;
				if (flag51)
				{
					goto IL_1a70;
				}
				nint num56 = (nint)value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				num44 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1499 @ rcx_v41 (Il2CppClass<System.Object>)+40]");
				nint num57 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rdx_v5 (System.Int32)+40]");
				bool flag52 = num57 != 0;
				num = unchecked((nint)null);
				obj6 = value;
				if (flag52)
				{
					goto IL_1d32;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj23 = default(object);
				QualitySettings.vSyncCount = (int)obj23;
			}
		}
		else if ((nint)obj == 488725647 && name == "resolution")
		{
			bool flag53 = oldValue == null;
			num = unchecked((nint)null);
			text = "resolution";
			text2 = name;
			if (!flag53)
			{
				nint num58 = (nint)oldValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1874 @ rcx_v33 (Il2CppClass<System.Object>)+40]");
				nint num59 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rdx_v23 (System.String)+40]");
				bool flag54 = num59 != 0;
				num = unchecked((nint)null);
				num60 = (nint)text;
				obj6 = oldValue;
				if (flag54)
				{
					goto IL_1d49;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				bool flag55 = value == null;
				num = unchecked((nint)null);
				text2 = (string)oldValue;
				if (!flag55)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
					num = 0;
					nint num61 = (nint)value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2158 @ rdx_v34 (Il2CppClass<System.Object>)+40]");
					nint num62 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2333 @ r8_v26 (Il2CppMethodInfo)+40]");
					bool flag56 = num62 != 0;
					obj6 = value;
					if (flag56)
					{
						goto IL_1d5b;
					}
					object obj24 = default(object);
					object obj12 = obj24;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
					object obj25 = default(object);
					object obj14 = obj25;
					nint num42 = (nint)typeof(_003CDoUpdateResolution_003Ed__17);
					goto IL_1d8d;
				}
			}
			goto IL_1a70;
		}
		goto IL_03d6;
		IL_1c24:
		Locale locale2 = ((List<Locale>)obj6).get_Item(num21);
		goto IL_1c3b;
		IL_1b27:
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
		object obj26 = default(object);
		num10 = (float)obj26;
		UpdateMixerVolume((float)obj26, groupVolumeName);
		goto IL_03d6;
		IL_1c0d:
		Locale locale3 = ((List<Locale>)obj6).get_Item(num21);
		goto IL_1c24;
		IL_1ae9:
		Locale locale4 = ((List<Locale>)(object)text2).get_Item((int)text);
		obj6 = text2;
		goto IL_1b08;
		IL_1b63:
		Locale locale5 = ((List<Locale>)obj6).get_Item(num16);
		goto IL_1b7a;
		IL_1c52:
		Locale locale6 = ((List<Locale>)obj6).get_Item(num21);
		goto IL_1c88;
		IL_1d8d:
		IEnumerator routine = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		_ = 0;
		Coroutine coroutine = StartCoroutine(routine);
		goto IL_03d6;
		IL_1a70:
		throw new NullReferenceException();
		IL_1d32:
		Locale locale7 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1d5b;
		IL_03d6:
		Action<string, object, object> a_SettingUpdated = A_SettingUpdated;
		if (A_SettingUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1055 @ r10_v1 (System.Action`3<System.String, System.Object, System.Object>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_1b99:
		Locale locale8 = ((List<Locale>)obj6).get_Item((int)text);
		goto IL_1bbe;
		IL_1b08:
		Locale locale9 = ((List<Locale>)obj6).get_Item((int)text);
		num16 = (int)text;
		goto IL_1b4c;
		IL_1c88:
		Locale locale10 = ((List<Locale>)obj6).get_Item((int)num);
		num39 = num;
		goto IL_1c69;
		IL_1c69:
		Locale locale11 = ((List<Locale>)obj6).get_Item((int)num39);
		num44 = (int)num39;
		goto IL_1cba;
		IL_1bbe:
		Locale locale12 = ((List<Locale>)obj6).get_Item((int)text);
		num21 = (int)text;
		goto IL_1c0d;
		IL_1c3b:
		Locale locale13 = ((List<Locale>)obj6).get_Item(num21);
		goto IL_1c52;
		IL_1cd1:
		Locale locale14 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1ce8;
		IL_1d5b:
		Locale locale15 = ((List<Locale>)obj6).get_Item((int)num);
		num60 = num;
		goto IL_1d49;
		IL_1d49:
		Locale locale16 = ((List<Locale>)obj6).get_Item((int)num60);
		return;
		IL_1b7a:
		Locale locale17 = ((List<Locale>)obj6).get_Item(num16);
		text = (string)num16;
		goto IL_1b99;
		IL_1b4c:
		Locale locale18 = ((List<Locale>)obj6).get_Item(num16);
		goto IL_1b63;
		IL_1cba:
		Locale locale19 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1cd1;
		IL_1ce8:
		Locale locale20 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1cff;
		IL_1cff:
		Locale locale21 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1d1b;
		IL_1d1b:
		Locale locale22 = ((List<Locale>)obj6).get_Item(num44);
		goto IL_1d32;
	}

	private void UpdateInputDelay(int i)
	{
		if (i >= 7)
		{
			QualitySettings.maxQueuedFrames = 6;
			return;
		}
		bool flag = i >= 0;
		int maxQueuedFrames = i;
		if (!flag)
		{
			maxQueuedFrames = 0;
		}
		QualitySettings.maxQueuedFrames = maxQueuedFrames;
	}

	private void UpdateLanguage(int i)
	{
		ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
		List<Locale> list = default(List<Locale>);
		if (list != null && i >= 0 && i < list._size)
		{
			LocalizationSettings instance = LocalizationSettings.Instance;
			Locale selectedLocale = list.get_Item(i);
			instance.SetSelectedLocale(selectedLocale);
		}
	}

	private void UpdateSkipChestAnimation(int i)
	{
		if (i != 0)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			Preferences preferences = config.preferences;
			if (!preferences.hasShownWarningForChestSkip)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager2.config;
				Preferences preferences2 = config2.preferences;
				preferences2.hasShownWarningForChestSkip = true;
				AlwaysUi instance = AlwaysUi.Instance;
				string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "WARNING");
				string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "CHESTSKIPWARNING");
				instance.dynamicWindows.NewWindow(localizedString, localizedString2);
			}
		}
	}

	private unsafe void UpdateWarningColor(int i)
	{
		//IL_002b: Expected O, but got Ref
		Color warningColor = MyColorUtility.GetWarningColor((EHpBarColor)i);
		object obj = default(object);
		warningMaterial.SetColor("_MainColor", (Color)(&obj));
	}

	private void UpdateResolution(int index, int oldValue)
	{
		_003CDoUpdateResolution_003Ed__17 obj = new _003CDoUpdateResolution_003Ed__17(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.index = index;
		obj.oldValue = oldValue;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private void UpdateMonitor(int index, int oldValue)
	{
		_003CDoUpdateTargetMonitor_003Ed__22 obj = new _003CDoUpdateTargetMonitor_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.index = index;
		obj.oldValue = oldValue;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator DoUpdateResolution(int index, int oldValue)
	{
		_003CDoUpdateResolution_003Ed__17 obj = new _003CDoUpdateResolution_003Ed__17(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.index = index;
		obj.oldValue = oldValue;
		return obj;
	}

	private void AcceptResolution(int newValue)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		cfVideoSettings.resolution = newValue;
		Action<int> a_ResolutionChanged = A_ResolutionChanged;
		if (A_ResolutionChanged != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v133 @ r9_v1 (System.Action`1<System.Int32>)+18] (should have been resolved before IL gen)");
		}
	}

	private void RevertResolution(int oldValue)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		cfVideoSettings.resolution = oldValue;
		SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
		SetResolution(oldValue);
	}

	private IEnumerator DoUpdateTargetMonitor(int index, int oldValue)
	{
		_003CDoUpdateTargetMonitor_003Ed__22 obj = new _003CDoUpdateTargetMonitor_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.index = index;
		obj.oldValue = oldValue;
		return obj;
	}

	private void AcceptTargetMonitor(int newValue)
	{
		//IL_0060: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_014b: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_011f: Expected O, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		cfVideoSettings.target_monitor = newValue;
		Resolution[] myResolutions = ConfigSettingsUtility.GetMyResolutions();
		object obj = 0;
		object obj2 = 0;
		Resolution resolution = default(Resolution);
		object obj6 = default(object);
		object value = default(object);
		while ((nint)obj < myResolutions.Length)
		{
			Resolution currentResolution = Screen.currentResolution;
			object obj3 = obj2 + 2;
			object obj4 = obj3 + obj3;
			object obj5 = resolution;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1815154E0");
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v27+20]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ r9_v6+20]");
				BetterUpdateCfSettings("resolution", value, (CFSettings)0);
				object obj8 = obj2;
			}
			obj2++;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v14 (UnityEngine.Resolution[])+v391 @ rax_v21*8]");
			resolution = (Resolution)0;
			obj = obj2;
		}
		Settings.Instance.RefreshSettings();
	}

	private void RevertTargetMonitor(int oldValue)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		cfVideoSettings.target_monitor = oldValue;
		SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
		_003CDoUpdateTargetMonitor_003Ed__22 obj = new _003CDoUpdateTargetMonitor_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.index = oldValue;
		obj.oldValue = oldValue;
		Coroutine coroutine = StartCoroutine(obj);
		Settings.Instance.RefreshSettings();
	}

	private void SetResolution(int index)
	{
		//IL_0013: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		Resolution[] myResolutions = ConfigSettingsUtility.GetMyResolutions();
		object obj = index + 2;
		object obj2 = obj << 4;
		object obj3 = obj2 + (object)myResolutions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DD6D0");
		object obj4 = index + 2;
		object obj5 = obj4 << 4;
		object obj6 = obj5 + (object)myResolutions;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809DB5A0");
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVideoSettings cfVideoSettings = config.cfVideoSettings;
		int width = default(int);
		int height = default(int);
		Screen.SetResolution(width, height, (FullScreenMode)cfVideoSettings.fullscreen_mode);
	}

	private IEnumerator MoveToPrimaryDisplay()
	{
		_003CMoveToPrimaryDisplay_003Ed__27 obj = new _003CMoveToPrimaryDisplay_003Ed__27(0);
		obj._003C_003E1__state = 0;
		return obj;
	}

	private void UpdateFullscreenMode(int i)
	{
		Screen.fullScreenMode = (FullScreenMode)i;
	}

	private void UpdateVSync(int i)
	{
		QualitySettings.vSyncCount = i;
	}

	private void UpdateMaxFps(int i)
	{
		Application.targetFrameRate = i;
	}

	private void UpdateShadowQuality(int i)
	{
		QualitySettings.shadows = (UnityEngine.ShadowQuality)i;
		int shadowCascades = i + i;
		QualitySettings.shadowCascades = shadowCascades;
	}

	private void UpdateShadowResolution(int i)
	{
		//IL_0017: Expected O, but got I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0032: Expected F4, but got O
		QualitySettings.shadowResolution = (UnityEngine.ShadowResolution)i;
		object obj = i * 4;
		object obj2 = i + obj;
		float shadowDistance = obj2 << 3;
		QualitySettings.shadowDistance = shadowDistance;
	}

	private void UpdateTextureQuality(int i)
	{
		int globalTextureMipmapLimit = 3 - i;
		QualitySettings.globalTextureMipmapLimit = globalTextureMipmapLimit;
	}

	private void UpdateAntiAliasing(int i)
	{
		//IL_0045: Expected I4, but got O
		if (i == 0)
		{
			QualitySettings.antiAliasing = 0;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FF020");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
		QualitySettings.antiAliasing = (int)this;
	}

	private void UpdateSoftParticles(int b)
	{
		//IL_000e: Expected O, but got I4
		object obj = b - 1;
		bool softParticles = obj == null;
		QualitySettings.softParticles = softParticles;
	}

	public void UpdateMixerVolume(float f, string groupVolumeName)
	{
		float value;
		if (0.0001f < f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEE20");
			value = f * 20f;
		}
		else
		{
			value = -80f;
		}
		bool flag = audioMixer.SetFloat(groupVolumeName, value);
	}

	private float SliderToDb(float sliderValue)
	{
		if (0.0001f < sliderValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FEE20");
			return sliderValue * 20f;
		}
		return -80f;
	}

	private void RefreshAudioMixer()
	{
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		if (!(SaveManager._003CInstance_003Ek__BackingField != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if (saveManager.config != null)
		{
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFAudioSettings));
			FieldInfo[] fields = typeFromHandle.GetFields();
			object obj = 0;
			object obj2 = 0;
			Type type = default(Type);
			while ((nint)obj2 < fields.Length)
			{
				string text = fields[obj].Name;
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config = saveManager2.config;
				object value = fields[obj].GetValue(config.cfAudioSettings);
				SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager3.config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
				FieldInfo field = type.GetField(text);
				object value2 = field.GetValue(config2.cfAudioSettings);
				object value3 = field.GetValue(config2.cfAudioSettings);
				field.SetValue(config2.cfAudioSettings, value);
				OnSettingUpdated(text, value, value3);
				obj++;
				obj2 = obj;
			}
		}
	}
}
