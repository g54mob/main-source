using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements.Experimental;

public class SlowmoPP : MonoBehaviour
{
	public PostProcessVolume volume;

	private ColorGrading cg;

	private LensDistortion lens;

	private bool isCgEnabled = true;

	private bool isTimeFreeze;

	private bool isSlowmo;

	private bool isDone;

	private float timer = 1f;

	private float transitionTime = 1f;

	private float dLens;

	private float dExposure;

	private float dSaturation;

	private float fromLens;

	private float fromExposure;

	private float fromSaturation;

	private Color desiredColor;

	private Color fromColor;

	private void Awake()
	{
		//IL_0624: Expected I, but got O
		//IL_0295: Expected I, but got O
		//IL_02a6: Expected O, but got I4
		//IL_02e9: Expected I, but got O
		//IL_02fa: Expected O, but got I4
		//IL_038c: Expected I, but got O
		//IL_039d: Expected O, but got I4
		//IL_03e0: Expected I, but got O
		//IL_03f1: Expected O, but got I4
		//IL_0587: Expected I, but got O
		//IL_0598: Expected O, but got I4
		//IL_05ae: Expected I, but got O
		//IL_05dc: Expected O, but got I4
		NullReferenceException typeFromHandle;
		nint num;
		if ((object)volume != null)
		{
			PostProcessProfile profile = volume.profile;
			if ((object)profile != null)
			{
				ColorGrading setting = profile.GetSetting<ColorGrading>();
				cg = setting;
				if ((object)volume != null)
				{
					PostProcessProfile profile2 = volume.profile;
					if ((object)profile2 != null)
					{
						LensDistortion setting2 = profile2.GetSetting<LensDistortion>();
						lens = setting2;
						ColorGrading colorGrading = cg;
						if ((object)cg != null && colorGrading.colorFilter != null)
						{
							_ = 1065353216;
							_ = 1065353216;
							_ = 1065353216;
							_ = 1065353216;
							ColorGrading colorGrading2 = cg;
							if ((object)cg != null && colorGrading2.postExposure != null)
							{
								_ = 0;
								ColorGrading colorGrading3 = cg;
								if ((object)cg != null && colorGrading3.saturation != null)
								{
									_ = 0;
									LensDistortion lensDistortion = lens;
									if ((object)lens != null && lensDistortion.intensity != null)
									{
										_ = 0;
										GraphicsDeviceType graphicsDeviceType = SystemInfo.graphicsDeviceType;
										if (graphicsDeviceType == GraphicsDeviceType.Direct3D12)
										{
											isCgEnabled = false;
										}
										Action<EStatusEffect, bool> b = OnStatusEffectAdded;
										Delegate obj = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b);
										Action action2;
										object obj2;
										Delegate obj3;
										if ((object)obj == null)
										{
											PlayerStatusEffects.A_StatusEffectAdded = null;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											Action<EStatusEffect, bool> action = default(Action<EStatusEffect, bool>);
											bool flag = action == null;
											num = (nint)typeof(Action<EStatusEffect, bool>);
											action2 = (Action)obj;
											obj2 = 0;
											obj3 = null;
											if (flag)
											{
												goto IL_050c;
											}
											PlayerStatusEffects.A_StatusEffectAdded = action;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											object obj4 = default(object);
											bool flag2 = obj4 == null;
											num = (nint)typeof(Action<EStatusEffect, bool>);
											action2 = (Action)obj;
											obj2 = 0;
											obj3 = null;
											if (flag2)
											{
												goto IL_0517;
											}
										}
										Action<EStatusEffect> b2 = OnStatusEffectRemoved;
										Delegate obj5 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b2);
										if ((object)obj5 == null)
										{
											PlayerStatusEffects.A_StatusEffectRemoved = null;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											Action<EStatusEffect> action3 = default(Action<EStatusEffect>);
											bool flag3 = action3 == null;
											num = (nint)typeof(Action<EStatusEffect>);
											action2 = (Action)obj5;
											obj2 = 0;
											obj3 = null;
											if (flag3)
											{
												goto IL_0527;
											}
											PlayerStatusEffects.A_StatusEffectRemoved = action3;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
											object obj6 = default(object);
											bool flag4 = obj6 == null;
											num = (nint)typeof(Action<EStatusEffect>);
											action2 = (Action)obj5;
											obj2 = 0;
											obj3 = null;
											if (flag4)
											{
												goto IL_0537;
											}
										}
										Action action4 = RefreshTimeFreeze;
										Delegate obj7 = Delegate.Combine(MyTime.A_TimeScaleChange, action4);
										if ((object)obj7 == null)
										{
											MyTime.A_TimeScaleChange = null;
											return;
										}
										bool flag5 = (object)obj7.GetType() != typeof(Action);
										Delegate obj8 = null;
										if (!flag5)
										{
											obj8 = obj7;
										}
										bool flag6 = (object)obj8 == null;
										num = (nint)MyTime.A_TimeScaleChange;
										action2 = action4;
										obj2 = 0;
										obj3 = obj7;
										nint num2 = (nint)typeof(Action);
										if (flag6)
										{
											goto IL_0600;
										}
										MyTime.A_TimeScaleChange = (Action)obj8;
										bool flag7 = (object)obj7.GetType() != typeof(Action);
										Delegate obj9 = null;
										if (!flag7)
										{
											obj9 = obj7;
										}
										bool flag8 = (object)obj9 == null;
										action2 = action4;
										obj2 = 0;
										obj3 = obj7;
										typeFromHandle = (NullReferenceException)(object)typeof(Action);
										if (!flag8)
										{
											return;
										}
										goto IL_0610;
									}
								}
							}
						}
					}
				}
			}
		}
		typeFromHandle = new NullReferenceException();
		goto IL_0610;
		IL_0610:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = (nint)MyTime.A_TimeScaleChange;
		goto IL_0600;
		IL_0600:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0537;
		IL_0527:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0517;
		IL_0537:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0527;
		IL_050c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0517:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_050c;
	}

	private void OnDestroy()
	{
		//IL_0273: Expected I, but got O
		//IL_0284: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_02f2: Expected I, but got O
		//IL_033a: Expected O, but got I4
		//IL_0350: Expected I, but got O
		//IL_037e: Expected O, but got I4
		//IL_0394: Expected I, but got O
		Action<EStatusEffect, bool> value = OnStatusEffectAdded;
		Delegate obj = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = (Action<EStatusEffect, bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action = default(Action<EStatusEffect, bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<EStatusEffect, bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_03b2;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_02b6;
			}
		}
		Action<EStatusEffect> value2 = OnStatusEffectRemoved;
		Delegate obj6 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value2);
		if ((object)obj6 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = (Action<EStatusEffect>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect> action2 = default(Action<EStatusEffect>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_02c1;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_02d1;
			}
		}
		num = (nint)MyTime.A_TimeScaleChange;
		Action action3 = RefreshTimeFreeze;
		Delegate obj8 = Delegate.Remove(MyTime.A_TimeScaleChange, action3);
		if ((object)obj8 == null)
		{
			MyTime.A_TimeScaleChange = null;
			return;
		}
		bool flag4 = (object)obj8.GetType() != typeof(Action);
		Delegate obj9 = null;
		if (!flag4)
		{
			obj9 = obj8;
		}
		bool flag5 = (object)obj9 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_03a2;
		}
		MyTime.A_TimeScaleChange = (Action)obj9;
		bool flag6 = (object)obj8.GetType() != typeof(Action);
		Delegate obj10 = null;
		if (!flag6)
		{
			obj10 = obj8;
		}
		bool flag7 = (object)obj10 == null;
		obj2 = action3;
		obj3 = 0;
		obj4 = obj8;
		nint num4 = (nint)typeof(Action);
		if (!flag7)
		{
			return;
		}
		goto IL_03b2;
		IL_03a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02d1;
		IL_03b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a2;
		IL_02d1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_02c1;
		IL_02b6:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b6;
	}

	private void RefreshTimeFreeze()
	{
		//IL_0070: Invalid comparison between F4 and I4
		//IL_03a8: Expected O, but got I4
		//IL_02a8: Expected O, but got I
		//IL_02d1: Expected F4, but got I
		//IL_017f: Expected O, but got I4
		//IL_0304: Expected F4, but got I
		//IL_01c5: Expected O, but got I
		//IL_0337: Expected F4, but got I
		//IL_01ee: Expected F4, but got I
		//IL_0221: Expected F4, but got I
		//IL_025f: Expected F4, but got I
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.TimeFreeze))
		{
			bool flag = 1f < MyTime._003CtimeScale_003Ek__BackingField;
			float num = 1f - MyTime._003CtimeScale_003Ek__BackingField;
			bool flag2 = num == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			isTimeFreeze = flag5;
		}
		else
		{
			isTimeFreeze = true;
		}
		if (!isTimeFreeze)
		{
			if (~(isTimeFreeze ? 1u : 0u) == 0)
			{
				if (isCgEnabled)
				{
					ColorGrading colorGrading = cg;
					BoolParameter boolParameter = colorGrading.enabled;
					_ = 1;
					ColorGrading colorGrading2 = cg;
					colorGrading2.active = true;
				}
				LensDistortion lensDistortion = lens;
				BoolParameter boolParameter2 = lensDistortion.enabled;
				_ = 1;
				LensDistortion lensDistortion2 = lens;
				lensDistortion2.active = true;
				dExposure = 0.6f;
				dSaturation = -35f;
				ColorGrading colorGrading3 = cg;
				desiredColor = (Color)1056964608;
				_ = 1065353216;
				_ = 1065353216;
				_ = 1065353216;
				dLens = 20f;
				ColorParameter colorFilter = colorGrading3.colorFilter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rcx_v13 (UnityEngine.Rendering.PostProcessing.ColorParameter)+18]");
				fromColor = (Color)0;
				FloatParameter postExposure = colorGrading3.postExposure;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rax_v29 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
				fromExposure = 0f;
				ColorGrading colorGrading4 = cg;
				FloatParameter saturation = colorGrading4.saturation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v32 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
				fromSaturation = 0f;
				LensDistortion lensDistortion3 = lens;
				FloatParameter intensity = lensDistortion3.intensity;
				timer = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v35 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
				fromLens = 0f;
				isSlowmo = true;
			}
		}
		else if (!isTimeFreeze)
		{
			dExposure = 0f;
			ColorGrading colorGrading5 = cg;
			desiredColor = (Color)1065353216;
			_ = 1065353216;
			_ = 1065353216;
			_ = 1065353216;
			dLens = 0f;
			ColorParameter colorFilter2 = colorGrading5.colorFilter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v3 (UnityEngine.Rendering.PostProcessing.ColorParameter)+18]");
			fromColor = (Color)0;
			FloatParameter postExposure2 = colorGrading5.postExposure;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v15 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
			fromExposure = 0f;
			ColorGrading colorGrading6 = cg;
			FloatParameter saturation2 = colorGrading6.saturation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v18 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
			fromSaturation = 0f;
			LensDistortion lensDistortion4 = lens;
			FloatParameter intensity2 = lensDistortion4.intensity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v21 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
			fromLens = 0f;
			timer = 0f;
			isDone = true;
		}
	}

	private void OnStatusEffectAdded(EStatusEffect eStatusEffect, bool newEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180541840\"");
		}
	}

	private void OnStatusEffectRemoved(EStatusEffect eStatusEffect)
	{
		if (eStatusEffect == EStatusEffect.TimeFreeze)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 13 Invalid \"Jump target not found in method: 0x180541840\"");
		}
	}

	private void StartTimeFreeze()
	{
		//IL_00ae: Expected O, but got I4
		//IL_00f4: Expected O, but got I
		//IL_011d: Expected F4, but got I
		//IL_0150: Expected F4, but got I
		//IL_0183: Expected F4, but got I
		if (isCgEnabled)
		{
			ColorGrading colorGrading = cg;
			BoolParameter boolParameter = colorGrading.enabled;
			_ = 1;
			ColorGrading colorGrading2 = cg;
			colorGrading2.active = true;
		}
		LensDistortion lensDistortion = lens;
		BoolParameter boolParameter2 = lensDistortion.enabled;
		_ = 1;
		LensDistortion lensDistortion2 = lens;
		lensDistortion2.active = true;
		dExposure = 0.6f;
		dSaturation = -35f;
		ColorGrading colorGrading3 = cg;
		desiredColor = (Color)1056964608;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		dLens = 20f;
		ColorParameter colorFilter = colorGrading3.colorFilter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rcx_v4 (UnityEngine.Rendering.PostProcessing.ColorParameter)+18]");
		fromColor = (Color)0;
		FloatParameter postExposure = colorGrading3.postExposure;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rax_v6 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromExposure = 0f;
		ColorGrading colorGrading4 = cg;
		FloatParameter saturation = colorGrading4.saturation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v9 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromSaturation = 0f;
		LensDistortion lensDistortion3 = lens;
		FloatParameter intensity = lensDistortion3.intensity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v12 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromLens = 0f;
		timer = 0f;
		isSlowmo = true;
	}

	private void EndTimeFreeze()
	{
		//IL_00ef: Expected O, but got I4
		//IL_0029: Expected O, but got I
		//IL_0052: Expected F4, but got I
		//IL_0085: Expected F4, but got I
		//IL_00b8: Expected F4, but got I
		dExposure = 0f;
		ColorGrading colorGrading = cg;
		desiredColor = (Color)1065353216;
		_ = 1065353216;
		_ = 1065353216;
		_ = 1065353216;
		dLens = 0f;
		ColorParameter colorFilter = colorGrading.colorFilter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v3 (UnityEngine.Rendering.PostProcessing.ColorParameter)+18]");
		fromColor = (Color)0;
		FloatParameter postExposure = colorGrading.postExposure;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v5 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromExposure = 0f;
		ColorGrading colorGrading2 = cg;
		FloatParameter saturation = colorGrading2.saturation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v8 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromSaturation = 0f;
		LensDistortion lensDistortion = lens;
		FloatParameter intensity = lensDistortion.intensity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v11 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		fromLens = 0f;
		timer = 0f;
		isDone = true;
	}

	private void Update()
	{
		//IL_0030: Invalid comparison between I4 and F4
		//IL_0085: Expected F4, but got I4
		//IL_00e7: Invalid comparison between I4 and F4
		//IL_013c: Expected F4, but got I4
		//IL_019e: Invalid comparison between I4 and F4
		//IL_01f1: Expected F4, but got I4
		//IL_0432: Expected O, but got I
		//IL_044f: Expected O, but got I
		//IL_046c: Expected O, but got I
		//IL_022f: Invalid comparison between I4 and F4
		//IL_0282: Expected F4, but got I4
		if (!(timer < 1f))
		{
			return;
		}
		float num = MyTime.deltaTime / transitionTime;
		if ((timer = num + timer) > 1f)
		{
			timer = 1f;
		}
		float num2 = Easing.OutCirc(timer);
		ColorGrading colorGrading = cg;
		FloatParameter postExposure = colorGrading.postExposure;
		float num3 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
		float num4 = dExposure - fromExposure;
		float num5 = num4 * num3;
		float num6 = num5 + fromExposure;
		ColorGrading colorGrading2 = cg;
		FloatParameter saturation = colorGrading2.saturation;
		float num7 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
		float num8 = dSaturation - fromSaturation;
		float num9 = num8 * num7;
		float num10 = num9 + fromSaturation;
		ColorGrading colorGrading3 = cg;
		ColorParameter colorFilter = colorGrading3.colorFilter;
		float num11;
		if (!(0f > num2))
		{
			bool flag = !(num2 > 1f);
			num11 = num2;
			if (!flag)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		object obj = desiredColor - fromColor;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+60]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+70]");
		object obj2 = num12 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+64]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+74]");
		object obj3 = num13 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+68]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+78]");
		object obj4 = num14 - 0;
		float num15 = (float)obj * num11;
		float num16 = (float)obj2 * num11;
		float num17 = num15 + (float)fromColor;
		float num18 = (float)obj3 * num11;
		float num19 = num16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+70]");
		float num20 = num19 + 0f;
		float num21 = (float)obj4 * num11;
		float num22 = num18;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+74]");
		float num23 = num22 + 0f;
		float num24 = num21;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (SlowmoPP)+78]");
		float num25 = num24 + 0f;
		LensDistortion lensDistortion = lens;
		FloatParameter intensity = lensDistortion.intensity;
		float num26;
		if (!(0f > num2))
		{
			bool flag2 = !(num2 > 1f);
			num26 = num2;
			if (!flag2)
			{
				num26 = 1f;
			}
		}
		else
		{
			num26 = 0f;
		}
		float num27 = dLens - fromLens;
		float num28 = num27 * num26;
		float num29 = num28 + fromLens;
		if (!(timer < 1f) && isDone)
		{
			ColorGrading colorGrading4 = cg;
			BoolParameter boolParameter = colorGrading4.enabled;
			_ = 0;
			LensDistortion lensDistortion2 = lens;
			BoolParameter boolParameter2 = lensDistortion2.enabled;
			_ = 0;
			ColorGrading colorGrading5 = cg;
			colorGrading5.active = false;
			LensDistortion lensDistortion3 = lens;
			lensDistortion3.active = false;
			isSlowmo = false;
		}
	}
}
