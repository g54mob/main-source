using System;
using Assets.Scripts.Inventory__Items__Pickups;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class DeathPP : MonoBehaviour
{
	public PostProcessVolume volume;

	private ColorGrading cg;

	private Vignette vignette;

	private bool isEnabled = true;

	private float deadVignetteIntensity = 0.3f;

	private float deadVignetteSmoothness = 0.4f;

	private float deadContrast = 20f;

	private float deadSaturation = -40f;

	private bool dead;

	private void Awake()
	{
		//IL_01f2: Expected I, but got O
		NullReferenceException typeFromHandle;
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
						Vignette setting2 = profile2.GetSetting<Vignette>();
						vignette = setting2;
						GraphicsDeviceType graphicsDeviceType = SystemInfo.graphicsDeviceType;
						if (graphicsDeviceType == GraphicsDeviceType.Direct3D12)
						{
							isEnabled = false;
						}
						Action b = OnPlayerDied;
						Delegate obj = Delegate.Combine(PlayerHealth.A_Died, b);
						if ((object)obj == null)
						{
							PlayerHealth.A_Died = null;
							return;
						}
						bool flag = (object)obj.GetType() != typeof(Action);
						Delegate obj2 = null;
						if (!flag)
						{
							obj2 = obj;
						}
						bool flag2 = (object)obj2 == null;
						Delegate obj3 = obj;
						nint num = (nint)typeof(Action);
						if (flag2)
						{
							goto IL_025b;
						}
						PlayerHealth.A_Died = (Action)obj2;
						bool flag3 = (object)obj.GetType() != typeof(Action);
						Delegate obj4 = null;
						if (!flag3)
						{
							obj4 = obj;
						}
						bool flag4 = (object)obj4 == null;
						obj3 = obj;
						typeFromHandle = (NullReferenceException)(object)typeof(Action);
						if (!flag4)
						{
							return;
						}
						goto IL_0266;
					}
				}
			}
		}
		typeFromHandle = new NullReferenceException();
		goto IL_0266;
		IL_025b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0266:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025b;
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = OnPlayerDied;
		Delegate obj = Delegate.Remove(PlayerHealth.A_Died, value);
		if ((object)obj == null)
		{
			PlayerHealth.A_Died = null;
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
			PlayerHealth.A_Died = (Action)obj2;
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

	private void OnPlayerDied()
	{
		bool flag = !isEnabled;
		dead = true;
		if (!flag)
		{
			ColorGrading colorGrading = cg;
			BoolParameter boolParameter = colorGrading.enabled;
			_ = 1;
			ColorGrading colorGrading2 = cg;
			colorGrading2.active = true;
			ColorGrading colorGrading3 = cg;
			FloatParameter postExposure = colorGrading3.postExposure;
			_ = 1073741824;
		}
	}

	private void Update()
	{
		//IL_0048: Invalid comparison between I4 and F4
		//IL_0093: Expected F4, but got I4
		//IL_02dd: Expected O, but got I
		//IL_00cc: Invalid comparison between I4 and F4
		//IL_0117: Expected F4, but got I4
		//IL_0150: Invalid comparison between I4 and F4
		//IL_019b: Expected F4, but got I4
		//IL_01d4: Invalid comparison between I4 and F4
		//IL_021f: Expected F4, but got I4
		//IL_0258: Invalid comparison between I4 and F4
		//IL_02a3: Expected F4, but got I4
		if (!dead)
		{
			return;
		}
		ColorGrading colorGrading = cg;
		FloatParameter postExposure = colorGrading.postExposure;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 8f;
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v3 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		object obj = -0;
		float num2 = (float)obj * num;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v3 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num4 = num3 + 0f;
		ColorGrading colorGrading2 = cg;
		FloatParameter contrast = colorGrading2.contrast;
		float deltaTime2 = Time.deltaTime;
		float num5 = deltaTime2 * 0.5f;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		float num6 = deadContrast;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v6 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num7 = num6 - 0f;
		float num8 = num7 * num5;
		float num9 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v6 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num10 = num9 + 0f;
		ColorGrading colorGrading3 = cg;
		FloatParameter saturation = colorGrading3.saturation;
		float deltaTime3 = Time.deltaTime;
		float num11 = deltaTime3 * 0.5f;
		if (!(0f > num11))
		{
			if (num11 > 1f)
			{
				num11 = 1f;
			}
		}
		else
		{
			num11 = 0f;
		}
		float num12 = deadSaturation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v8 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num13 = num12 - 0f;
		float num14 = num13 * num11;
		float num15 = num14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v8 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num16 = num15 + 0f;
		Vignette vignette = this.vignette;
		FloatParameter intensity = vignette.intensity;
		float deltaTime4 = Time.deltaTime;
		float num17 = deltaTime4 * 0.5f;
		if (!(0f > num17))
		{
			if (num17 > 1f)
			{
				num17 = 1f;
			}
		}
		else
		{
			num17 = 0f;
		}
		float num18 = deadVignetteIntensity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v10 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num19 = num18 - 0f;
		float num20 = num19 * num17;
		float num21 = num20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rcx_v10 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num22 = num21 + 0f;
		Vignette vignette2 = this.vignette;
		FloatParameter smoothness = vignette2.smoothness;
		float deltaTime5 = Time.deltaTime;
		float num23 = deltaTime5 * 0.5f;
		if (!(0f > num23))
		{
			if (num23 > 1f)
			{
				num23 = 1f;
			}
		}
		else
		{
			num23 = 0f;
		}
		float num24 = deadVignetteSmoothness;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v12 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num25 = num24 - 0f;
		float num26 = num25 * num23;
		float num27 = num26;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v12 (UnityEngine.Rendering.PostProcessing.FloatParameter)+18]");
		float num28 = num27 + 0f;
	}
}
