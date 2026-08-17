using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PPController : MonoBehaviour
{
	private UnityEngine.Rendering.PostProcessing.Bloom bloom;

	private MotionBlur motionBlur;

	private AmbientOcclusion ao;

	private unsafe void Awake()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected Ref, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Ref, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Ref, but got Unknown
		//IL_0146: Expected I, but got O
		//IL_0166: Expected O, but got I4
		//IL_0196: Expected I, but got O
		PostProcessVolume component = GetComponent<PostProcessVolume>();
		if ((object)component != null)
		{
			PostProcessProfile profile = component.profile;
			if ((object)profile != null)
			{
				bool flag = profile.TryGetSettings<UnityEngine.Rendering.PostProcessing.Bloom>(out *(UnityEngine.Rendering.PostProcessing.Bloom*)(this + 32));
				PostProcessProfile profile2 = component.profile;
				if ((object)profile2 != null)
				{
					bool flag2 = profile2.TryGetSettings<MotionBlur>(out *(MotionBlur*)(this + 40));
					PostProcessProfile profile3 = component.profile;
					if ((object)profile3 != null)
					{
						bool flag3 = profile3.TryGetSettings<AmbientOcclusion>(out *(AmbientOcclusion*)(this + 48));
						Action<string, object, object> b = OnSettingUpdated;
						Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
						if ((object)obj == null)
						{
							CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
							return;
						}
						bool flag4 = ((PostProcessProfile)(object)obj).TryGetSettings(out *(UnityEngine.Rendering.PostProcessing.Bloom*)typeof(Action<string, object, object>));
						bool flag5 = !flag4;
						nint num = (nint)typeof(Action<string, object, object>);
						PostProcessVolume postProcessVolume = (PostProcessVolume)(object)obj;
						if (!flag5)
						{
							CurrentSettings.A_SettingUpdated = (Action<string, object, object>)flag4;
							bool flag6 = ((PostProcessProfile)(object)obj).TryGetSettings(out *(UnityEngine.Rendering.PostProcessing.Bloom*)typeof(Action<string, object, object>));
							bool flag7 = !flag6;
							num = (nint)typeof(Action<string, object, object>);
							postProcessVolume = (PostProcessVolume)(object)obj;
							if (!flag7)
							{
								return;
							}
							bool flag8 = ((PostProcessProfile)(object)postProcessVolume).TryGetSettings(out *(UnityEngine.Rendering.PostProcessing.Bloom*)num);
						}
						bool flag9 = ((PostProcessProfile)(object)postProcessVolume).TryGetSettings(out *(UnityEngine.Rendering.PostProcessing.Bloom*)num);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
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

	private void Start()
	{
		//IL_01ac: Expected O, but got I4
		//IL_021d: Expected O, but got I4
		GraphicsDeviceType graphicsDeviceType = SystemInfo.graphicsDeviceType;
		if (graphicsDeviceType == GraphicsDeviceType.Direct3D12 && ao != null)
		{
			AmbientOcclusion ambientOcclusion = ao;
			ambientOcclusion.active = false;
			AmbientOcclusion ambientOcclusion2 = ao;
			BoolParameter boolParameter = ambientOcclusion2.enabled;
			_ = 0;
			AmbientOcclusion ambientOcclusion3 = ao;
			ambientOcclusion3.enabled.Override(x: false);
		}
		if (SaveManager._003CInstance_003Ek__BackingField != null)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			if (saveManager.config != null)
			{
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config = saveManager2.config;
				CFVideoSettings cfVideoSettings = config.cfVideoSettings;
				SetBloom(cfVideoSettings.bloom);
				SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config2 = saveManager3.config;
				CFVideoSettings cfVideoSettings2 = config2.cfVideoSettings;
				MotionBlur motionBlur = this.motionBlur;
				BoolParameter boolParameter2 = motionBlur.enabled;
				object obj = cfVideoSettings2.motion_blur - 1;
				bool flag = obj == null;
				SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
				ConfigSaveFile config3 = saveManager4.config;
				CFVideoSettings cfVideoSettings3 = config3.cfVideoSettings;
				AmbientOcclusion ambientOcclusion4 = ao;
				BoolParameter boolParameter3 = ambientOcclusion4.enabled;
				object obj2 = cfVideoSettings3.ambient_occlusion - 1;
				bool flag2 = obj2 == null;
			}
		}
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
		//IL_004b: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		//IL_01fb: Expected O, but got I4
		//IL_0072: Expected I, but got O
		//IL_0082: Expected O, but got I
		//IL_00ac: Expected O, but got I4
		//IL_0146: Expected I, but got O
		//IL_0156: Expected O, but got I
		//IL_0180: Expected O, but got I4
		//IL_0222: Expected I, but got O
		//IL_0232: Expected O, but got I
		//IL_025c: Expected O, but got I4
		//IL_00d6: Expected I4, but got O
		//IL_01b3: Expected O, but got I4
		//IL_028f: Expected O, but got I4
		//IL_02a4: Expected O, but got I
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171FF2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text2;
		switch (name)
		{
		default:
			return;
		case "bloom":
		{
			bool flag6 = newValue == null;
			object obj = 0;
			string text = "bloom";
			text2 = name;
			if (flag6)
			{
				goto IL_02ec;
			}
			nint num5 = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rcx_v18 (Il2CppClass<System.Object>)+40]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (System.String)+40]");
			bool flag7 = num6 != 0;
			obj = 0;
			text2 = (string)newValue;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj4 = default(object);
				SetBloom((int)obj4);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			goto IL_0333;
		}
		case "motion_blur":
		{
			bool flag4 = newValue == null;
			object obj = 0;
			string text = "motion_blur";
			text2 = name;
			if (flag4)
			{
				goto IL_02ec;
			}
			nint num3 = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
			text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v14 (Il2CppClass<System.Object>)+40]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (System.String)+40]");
			bool flag5 = num4 != 0;
			obj = 0;
			text2 = (string)newValue;
			if (flag5)
			{
				goto IL_0333;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
			text2 = (string)(object)motionBlur;
			obj = 0;
			goto IL_0343;
		}
		case "ambient_occlusion":
			{
				bool flag = newValue == null;
				object obj = 0;
				string text = "ambient_occlusion";
				text2 = name;
				if (flag)
				{
					goto IL_02ec;
				}
				nint num = (nint)newValue;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B28]");
				text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v11 (Il2CppClass<System.Object>)+40]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v7 (System.String)+40]");
				bool flag2 = num2 != 0;
				obj = 0;
				text2 = (string)newValue;
				if (flag2)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				text2 = (string)(object)ao;
				obj = 0;
				goto IL_0343;
			}
			IL_0343:
			if (text2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v3 (System.String)+20]");
				text2 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v3 (System.String)+20]");
				if ((nint)0 != 0)
				{
					object obj3 = default(object);
					object obj2 = obj3 - 1;
					bool flag3 = obj2 == null;
					return;
				}
			}
			goto IL_02ec;
			IL_02ec:
			throw new NullReferenceException();
			IL_0333:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			break;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public void SetBloom(int value)
	{
		//IL_002b: Expected O, but got I4
		bool flag = value == 0;
		if (!flag)
		{
			object obj = value - 1;
			if (flag)
			{
				UnityEngine.Rendering.PostProcessing.Bloom bloom = this.bloom;
				BoolParameter boolParameter = bloom.enabled;
				_ = 1;
				UnityEngine.Rendering.PostProcessing.Bloom bloom2 = this.bloom;
				BoolParameter fastMode = bloom2.fastMode;
				_ = 1;
				return;
			}
			if ((nint)obj != 1)
			{
				return;
			}
			UnityEngine.Rendering.PostProcessing.Bloom bloom3 = this.bloom;
			BoolParameter boolParameter2 = bloom3.enabled;
			_ = 1;
			UnityEngine.Rendering.PostProcessing.Bloom bloom4 = this.bloom;
			BoolParameter fastMode2 = bloom4.fastMode;
		}
		else
		{
			UnityEngine.Rendering.PostProcessing.Bloom bloom5 = this.bloom;
			BoolParameter fastMode2 = bloom5.enabled;
		}
		_ = 0;
	}

	public void SetMotionBlur(int on)
	{
		//IL_002f: Expected O, but got I4
		MotionBlur motionBlur = this.motionBlur;
		BoolParameter boolParameter = motionBlur.enabled;
		object obj = on - 1;
		bool flag = obj == null;
	}

	public void SetAO(int on)
	{
		//IL_002f: Expected O, but got I4
		AmbientOcclusion ambientOcclusion = ao;
		BoolParameter boolParameter = ambientOcclusion.enabled;
		object obj = on - 1;
		bool flag = obj == null;
	}
}
