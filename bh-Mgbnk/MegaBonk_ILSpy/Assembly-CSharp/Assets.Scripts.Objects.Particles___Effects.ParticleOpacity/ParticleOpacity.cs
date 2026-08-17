using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.Combat.ConstantAttacks;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Assets.Scripts.Objects.Particles___Effects.ParticleOpacity;

public class ParticleOpacity : MonoBehaviour
{
	public enum EOpacityCurve
	{
		Linear,
		OutCirc,
		Custom
	}

	public ParticleSystem[] particleSystems;

	public float[] defaultOpacitiesParticles;

	public TrailRenderer[] trails;

	public float[] defaultOpacitiesTrailsStart;

	public float[] defaultOpacitiesTrailsEnd;

	public LineRenderer[] lines;

	public float[] defaultOpacitiesLinesStart;

	public float[] defaultOpacitiesLinesEnd;

	public MeshRenderer[] meshRenderer;

	public EffectPlayer effectPlayer;

	public bool subscribeToOpacityChange;

	private bool queueRefreshForce;

	private bool queueRefresh;

	private float readyAtTime;

	private float cooldown;

	private float lastSetOpacity;

	private bool isHidden;

	public EOpacityCurve opacityCurve;

	public AnimationCurve customCurve;

	public bool useProjectileAutoOpacity;

	public ProjectileBase projectileBase;

	public ConstantAttack constantAttack;

	public float autoMinSize;

	public float autoMaxSize;

	public float minOpacity;

	public bool useScaleWithoutProjectileData;

	private string particleOpacitySettingName;

	private void Awake()
	{
		//IL_0052: Expected O, but got I4
		//IL_023e: Expected O, but got I4
		//IL_0255: Expected O, but got I4
		//IL_029d: Expected O, but got I4
		//IL_02ab: Expected I, but got O
		//IL_02b4: Expected O, but got I4
		//IL_0365: Expected I, but got O
		//IL_01fc: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0213: Expected O, but got I4
		//IL_034d: Expected I, but got O
		//IL_02e2: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		UnityEngine.Object obj = this.effectPlayer;
		Delegate obj3;
		UnityEngine.Object obj8;
		object obj6;
		object obj2;
		nint num;
		if (this.effectPlayer != null)
		{
			EffectPlayer effectPlayer = this.effectPlayer;
			bool flag = (object)this.effectPlayer == null;
			obj2 = 0;
			if (flag)
			{
				goto IL_0271;
			}
			obj3 = effectPlayer.A_Played;
			Action action = Refresh;
			Delegate obj4 = Delegate.Combine(effectPlayer.A_Played, action);
			if ((object)obj4 == null)
			{
				effectPlayer.A_Played = (Action)obj4;
			}
			else
			{
				bool flag2 = (object)obj4.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag2)
				{
					obj5 = obj4;
				}
				bool flag3 = (object)obj5 == null;
				obj = (UnityEngine.Object)(object)action;
				obj6 = 0;
				num = (nint)typeof(Action);
				obj2 = 0;
				if (flag3)
				{
					goto IL_033a;
				}
				effectPlayer.A_Played = (Action)obj5;
				bool flag4 = (object)obj4.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag4)
				{
					obj7 = obj4;
				}
				bool flag5 = (object)obj7 == null;
				obj = (UnityEngine.Object)(object)action;
				obj6 = 0;
				obj2 = 0;
				obj8 = (UnityEngine.Object)(object)typeof(Action);
				if (flag5)
				{
					goto IL_0352;
				}
			}
		}
		if (!subscribeToOpacityChange)
		{
			return;
		}
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj9 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj9 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		nint num2;
		if (action2 != null)
		{
			CurrentSettings.A_SettingUpdated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag6 = obj10 == null;
			obj = (UnityEngine.Object)(object)obj9;
			obj6 = 0;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = 0;
			if (flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj = (UnityEngine.Object)(object)obj9;
		obj6 = 0;
		obj3 = (Delegate)(object)typeof(Action<string, object, object>);
		obj2 = 0;
		obj8 = (UnityEngine.Object)(object)obj9;
		goto IL_0352;
		IL_033a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj3;
		goto IL_0271;
		IL_0352:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = (nint)obj8;
		goto IL_033a;
		IL_0271:
		throw new NullReferenceException();
	}

	private void OnDestroy()
	{
		//IL_0052: Expected O, but got I4
		//IL_023e: Expected O, but got I4
		//IL_0255: Expected O, but got I4
		//IL_029d: Expected O, but got I4
		//IL_02ab: Expected I, but got O
		//IL_02b4: Expected O, but got I4
		//IL_0365: Expected I, but got O
		//IL_01fc: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0213: Expected O, but got I4
		//IL_034d: Expected I, but got O
		//IL_02e2: Expected O, but got I4
		//IL_02eb: Expected O, but got I4
		UnityEngine.Object obj = this.effectPlayer;
		Delegate obj3;
		UnityEngine.Object obj8;
		object obj6;
		object obj2;
		nint num;
		if (this.effectPlayer != null)
		{
			EffectPlayer effectPlayer = this.effectPlayer;
			bool flag = (object)this.effectPlayer == null;
			obj2 = 0;
			if (flag)
			{
				goto IL_0271;
			}
			obj3 = effectPlayer.A_Played;
			Action action = Refresh;
			Delegate obj4 = Delegate.Remove(effectPlayer.A_Played, action);
			if ((object)obj4 == null)
			{
				effectPlayer.A_Played = (Action)obj4;
			}
			else
			{
				bool flag2 = (object)obj4.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag2)
				{
					obj5 = obj4;
				}
				bool flag3 = (object)obj5 == null;
				obj = (UnityEngine.Object)(object)action;
				obj6 = 0;
				num = (nint)typeof(Action);
				obj2 = 0;
				if (flag3)
				{
					goto IL_033a;
				}
				effectPlayer.A_Played = (Action)obj5;
				bool flag4 = (object)obj4.GetType() != typeof(Action);
				Delegate obj7 = null;
				if (!flag4)
				{
					obj7 = obj4;
				}
				bool flag5 = (object)obj7 == null;
				obj = (UnityEngine.Object)(object)action;
				obj6 = 0;
				obj2 = 0;
				obj8 = (UnityEngine.Object)(object)typeof(Action);
				if (flag5)
				{
					goto IL_0352;
				}
			}
		}
		if (!subscribeToOpacityChange)
		{
			return;
		}
		Action<string, object, object> value = OnSettingUpdated;
		Delegate obj9 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value);
		if ((object)obj9 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		nint num2;
		if (action2 != null)
		{
			CurrentSettings.A_SettingUpdated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag6 = obj10 == null;
			obj = (UnityEngine.Object)(object)obj9;
			obj6 = 0;
			num2 = (nint)typeof(Action<string, object, object>);
			obj2 = 0;
			if (flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj = (UnityEngine.Object)(object)obj9;
		obj6 = 0;
		obj3 = (Delegate)(object)typeof(Action<string, object, object>);
		obj2 = 0;
		obj8 = (UnityEngine.Object)(object)obj9;
		goto IL_0352;
		IL_033a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj3;
		goto IL_0271;
		IL_0352:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = (nint)obj8;
		goto IL_033a;
		IL_0271:
		throw new NullReferenceException();
	}

	private void OnEnable()
	{
		queueRefresh = true;
	}

	private void Refresh()
	{
		Refresh(false);
	}

	private unsafe void Refresh(bool force = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_014b: Invalid comparison between F4 and O
		//IL_01b4: Invalid comparison between I4 and F4
		//IL_016b: Invalid comparison between F4 and I4
		//IL_0831: Expected O, but got I4
		//IL_083a: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_038a: Expected O, but got I4
		//IL_0393: Expected O, but got I4
		//IL_018d: Invalid comparison between F4 and I4
		//IL_08ab: Expected O, but got I4
		//IL_08b4: Expected O, but got I4
		//IL_0471: Expected O, but got I4
		//IL_047a: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0216: Expected O, but got I4
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_0886: Expected O, but got Unknown
		//IL_0600: Expected O, but got I4
		//IL_0609: Expected O, but got I4
		//IL_03e5: Expected O, but got Ref
		//IL_0903: Expected O, but got I4
		//IL_090c: Expected O, but got I4
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08de: Expected O, but got Unknown
		//IL_027e: Expected O, but got I4
		//IL_0287: Expected O, but got I4
		//IL_0238: Expected O, but got Ref
		//IL_0a8b: Expected O, but got Ref
		//IL_0a99: Expected O, but got Ref
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae7: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0794: Expected O, but got I4
		//IL_079d: Expected O, but got I4
		//IL_095b: Expected O, but got I4
		//IL_0964: Expected O, but got I4
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_02d6: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_0581: Expected O, but got Ref
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected O, but got Unknown
		//IL_05a6: Expected O, but got Ref
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_032e: Expected O, but got I4
		//IL_0337: Expected O, but got I4
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_07f3: Expected O, but got Ref
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Expected O, but got Unknown
		//IL_0710: Expected O, but got Ref
		//IL_0735: Expected O, but got Ref
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		float time = Time.time;
		if (readyAtTime > time && !force)
		{
			return;
		}
		float time2 = Time.time;
		float num = time2 + cooldown;
		readyAtTime = num;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
		float autoOpacity = GetAutoOpacity();
		bool flag = opacityCurve == EOpacityCurve.OutCirc;
		float num2 = autoOpacity * cfVisualsSettings.particle_opacity;
		float num3;
		if (!flag)
		{
			if (opacityCurve != EOpacityCurve.Custom)
			{
				goto IL_011c;
			}
			num3 = customCurve.Evaluate(num2);
		}
		else
		{
			num3 = Easing.OutCubic(num2);
		}
		num2 = num3;
		goto IL_011c;
		IL_011c:
		float num4 = num2 - lastSetOpacity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = num4 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && num2 > 0f && lastSetOpacity > 0f)
		{
			return;
		}
		lastSetOpacity = num2;
		if (0f < num2)
		{
			if (isHidden)
			{
				ParticleSystem[] array = particleSystems;
				isHidden = false;
				object obj4 = 0;
				object obj5 = 0;
				while ((nint)obj4 < array.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
					ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
					((ParticleSystem.EmissionModule*)emissionModule)->enabled = true;
					obj5++;
					obj4 = obj5;
				}
				TrailRenderer[] array2 = trails;
				object obj6 = 0;
				object obj7 = 0;
				while ((nint)obj6 < array2.Length)
				{
					array2[obj7].enabled = true;
					obj7++;
					obj6 = obj7;
				}
				LineRenderer[] array3 = lines;
				object obj8 = 0;
				object obj9 = 0;
				while ((nint)obj8 < array3.Length)
				{
					array3[obj9].enabled = true;
					obj9++;
					obj8 = obj9;
				}
				MeshRenderer[] array4 = meshRenderer;
				object obj10 = 0;
				object obj11 = 0;
				while ((nint)obj10 < array4.Length)
				{
					array4[obj11].enabled = true;
					obj11++;
					obj10 = obj11;
				}
			}
			ParticleSystem[] array5 = particleSystems;
			object obj12 = 0;
			object obj13 = 0;
			object obj14 = 0;
			while ((nint)obj13 < array5.Length)
			{
				ParticleSystem[] array6 = particleSystems;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
				ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				ParticleSystem.MinMaxGradient startColor = ((ParticleSystem.MainModule*)mainModule)->startColor;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231E790");
				if (defaultOpacitiesParticles != null)
				{
					float[] array7 = defaultOpacitiesParticles;
					if ((nint)obj14 >= array7.Length)
					{
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1814AD5F0");
				ParticleSystem.MinMaxGradient startColor2 = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				_ = startColor.m_GradientMax;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1867 @ rax_v89 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1867 @ rax_v89 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
				_ = 0;
				((ParticleSystem.MainModule*)mainModule2)->startColor = startColor2;
				array5 = particleSystems;
				obj14++;
				obj13 = obj14;
			}
			TrailRenderer[] array8 = trails;
			object obj15 = 0;
			object obj16 = 0;
			float num5 = default(float);
			float num6 = default(float);
			bool flag2;
			do
			{
				if ((nint)obj15 < array8.Length)
				{
					TrailRenderer[] array9 = trails;
					Color startColor3 = array9[obj16].startColor;
					TrailRenderer[] array10 = trails;
					Color endColor = array10[obj16].endColor;
					if (defaultOpacitiesTrailsStart != null)
					{
						float[] array11 = defaultOpacitiesTrailsStart;
						if ((nint)obj16 >= array11.Length)
						{
						}
					}
					if (defaultOpacitiesTrailsEnd != null)
					{
						float[] array12 = defaultOpacitiesTrailsEnd;
						if ((nint)obj16 >= array12.Length)
						{
						}
					}
					TrailRenderer[] array13 = trails;
					array13[obj16].startColor = (Color)(&num5);
					TrailRenderer[] array14 = trails;
					array14[obj16].endColor = (Color)(&num6);
					array8 = trails;
					obj16++;
					flag2 = trails != null;
					obj15 = obj16;
					continue;
				}
				LineRenderer[] array15 = lines;
				object obj17 = 0;
				object obj18 = 0;
				bool flag3;
				do
				{
					if ((nint)obj17 < array15.Length)
					{
						LineRenderer[] array16 = lines;
						Color startColor4 = array16[obj18].startColor;
						LineRenderer[] array17 = lines;
						Color endColor2 = array17[obj18].endColor;
						if (defaultOpacitiesLinesStart != null)
						{
							float[] array18 = defaultOpacitiesLinesStart;
							if ((nint)obj18 >= array18.Length)
							{
							}
						}
						if (defaultOpacitiesLinesEnd != null)
						{
							float[] array19 = defaultOpacitiesLinesEnd;
							if ((nint)obj18 >= array19.Length)
							{
							}
						}
						LineRenderer[] array20 = lines;
						array20[obj18].startColor = (Color)(&num6);
						LineRenderer[] array21 = lines;
						array21[obj18].endColor = (Color)(&num5);
						array15 = lines;
						obj18++;
						flag3 = lines != null;
						obj17 = obj18;
						continue;
					}
					MeshRenderer[] array22 = meshRenderer;
					object obj19 = 0;
					object obj20 = 0;
					while ((nint)obj19 < array22.Length)
					{
						Material sharedMaterial = ((Renderer)array22[obj20]).GetSharedMaterial();
						Color color = sharedMaterial.color;
						Material sharedMaterial2 = ((Renderer)array22[obj20]).GetSharedMaterial();
						sharedMaterial2.color = (Color)(&num6);
						obj20++;
						obj19 = obj20;
					}
					return;
				}
				while (flag3);
				break;
			}
			while (flag2);
			throw new NullReferenceException();
		}
		ParticleSystem[] array23 = particleSystems;
		isHidden = true;
		object obj21 = 0;
		object obj22 = 0;
		ParticleSystem.EmissionModule emissionModule2 = default(ParticleSystem.EmissionModule);
		while ((nint)obj21 < array23.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			emissionModule2.enabled = false;
			array23[obj22].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			obj22++;
			obj21 = obj22;
		}
		TrailRenderer[] array24 = trails;
		object obj23 = 0;
		object obj24 = 0;
		while ((nint)obj23 < array24.Length)
		{
			array24[obj24].enabled = false;
			obj24++;
			obj23 = obj24;
		}
		LineRenderer[] array25 = lines;
		object obj25 = 0;
		object obj26 = 0;
		while ((nint)obj25 < array25.Length)
		{
			array25[obj26].enabled = false;
			obj26++;
			obj25 = obj26;
		}
		MeshRenderer[] array26 = meshRenderer;
		object obj27 = 0;
		object obj28 = 0;
		while ((nint)obj27 < array26.Length)
		{
			array26[obj28].enabled = false;
			obj28++;
			obj27 = obj28;
		}
	}

	private float GetAutoOpacity()
	{
		//IL_0181: Invalid comparison between I4 and F4
		//IL_01cc: Expected F4, but got I4
		//IL_026f: Invalid comparison between I4 and F4
		//IL_0231: Expected F4, but got I4
		if (useProjectileAutoOpacity)
		{
			if (!useScaleWithoutProjectileData)
			{
				ProjectileBase projectileBase = this.projectileBase;
				if ((object)this.projectileBase == null || projectileBase.weaponBase == null)
				{
					goto IL_023c;
				}
			}
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
			if (cfVisualsSettings.particle_auto_opacity != 0)
			{
				ConstantAttack constantAttack = (ConstantAttack)(useScaleWithoutProjectileData ? ((MonoBehaviour)this.constantAttack) : ((MonoBehaviour)this.projectileBase));
				float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(constantAttack.weaponBase);
				if (!(attackSizeMultiplier < autoMinSize))
				{
					float num = autoMaxSize - autoMinSize;
					float num2 = attackSizeMultiplier - autoMinSize;
					float num3 = num2 / num;
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
					if (!(0f > num3))
					{
						if (num3 > 1f)
						{
							float num4 = minOpacity - 1f;
							float num5 = num4 * 1f;
							return num5 + 1f;
						}
					}
					else
					{
						num3 = 0f;
					}
					float num6 = minOpacity - 1f;
					float num7 = num6 * num3;
					return num7 + 1f;
				}
				return 1f;
			}
		}
		goto IL_023c;
		IL_023c:
		return 1f;
	}

	public void TryValidate()
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e4: Expected F4, but got I
		//IL_01a4: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		//IL_031c: Expected O, but got I4
		//IL_0325: Expected O, but got I4
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		particleSystems = componentsInChildren;
		ParticleSystem[] array = particleSystems;
		float[] array2 = new float[array.Length];
		defaultOpacitiesParticles = array2;
		ParticleSystem[] array3 = particleSystems;
		ParticleSystemGradientMode particleSystemGradientMode = ParticleSystemGradientMode.Color;
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)0;
		object obj = 0;
		object obj2 = 0;
		ParticleSystem.MainModule mainModule2 = default(ParticleSystem.MainModule);
		while ((nint)obj2 < array3.Length)
		{
			ParticleSystem[] array4 = particleSystems;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			float[] array5 = defaultOpacitiesParticles;
			ParticleSystem.MinMaxGradient startColor = mainModule.startColor;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231E790");
			object obj3 = obj + 1;
			object obj4 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rax_v51+C]");
			array5[obj4] = 0f;
			array3 = particleSystems;
			particleSystemGradientMode = startColor.m_Mode;
			mainModule = mainModule2;
			obj = obj3;
			obj2 = obj3;
		}
		TrailRenderer[] componentsInChildren2 = GetComponentsInChildren<TrailRenderer>();
		trails = componentsInChildren2;
		TrailRenderer[] array6 = trails;
		float[] array7 = new float[array6.Length];
		defaultOpacitiesTrailsStart = array7;
		TrailRenderer[] array8 = trails;
		float[] array9 = new float[array8.Length];
		defaultOpacitiesTrailsEnd = array9;
		TrailRenderer[] array10 = trails;
		object obj5 = 0;
		object obj6 = 0;
		bool flag;
		do
		{
			if ((nint)obj6 < array10.Length)
			{
				TrailRenderer[] array11 = trails;
				float[] array12 = defaultOpacitiesTrailsStart;
				array12[obj5] = array11[obj5].startColor.a;
				TrailRenderer[] array13 = trails;
				float[] array14 = defaultOpacitiesTrailsEnd;
				Color endColor = array13[obj5].endColor;
				object obj7 = obj5 + 1;
				array14[obj5] = endColor.a;
				array10 = trails;
				flag = trails != null;
				obj5 = obj7;
				obj6 = obj7;
				continue;
			}
			LineRenderer[] componentsInChildren3 = GetComponentsInChildren<LineRenderer>();
			lines = componentsInChildren3;
			LineRenderer[] array15 = lines;
			float[] array16 = new float[array15.Length];
			defaultOpacitiesLinesStart = array16;
			LineRenderer[] array17 = lines;
			float[] array18 = new float[array17.Length];
			defaultOpacitiesLinesEnd = array18;
			LineRenderer[] array19 = lines;
			object obj8 = 0;
			object obj9 = 0;
			bool flag2;
			do
			{
				if ((nint)obj9 < array19.Length)
				{
					LineRenderer[] array20 = lines;
					float[] array21 = defaultOpacitiesLinesStart;
					array21[obj8] = array20[obj8].startColor.a;
					LineRenderer[] array22 = lines;
					float[] array23 = defaultOpacitiesLinesEnd;
					Color endColor2 = array22[obj8].endColor;
					object obj10 = obj8 + 1;
					array23[obj8] = endColor2.a;
					array19 = lines;
					flag2 = lines != null;
					obj8 = obj10;
					obj9 = obj10;
					continue;
				}
				EffectPlayer componentInChildren = GetComponentInChildren<EffectPlayer>();
				effectPlayer = componentInChildren;
				if (useProjectileAutoOpacity)
				{
					ProjectileBase component = GetComponent<ProjectileBase>();
					projectileBase = component;
				}
				return;
			}
			while (flag2);
			break;
		}
		while (flag);
		throw new NullReferenceException();
	}

	private void OnSettingUpdated(string name, object oldValue, object newValue)
	{
		if (name == particleOpacitySettingName)
		{
			queueRefreshForce = true;
		}
	}

	private void Update()
	{
		//IL_0052: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (MyTime.paused)
		{
			return;
		}
		if (queueRefreshForce)
		{
			queueRefreshForce = false;
			Refresh(force: true);
			ParticleSystem[] array = particleSystems;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
				array[obj].Play();
				obj++;
				obj2 = obj;
			}
		}
		if (queueRefresh)
		{
			queueRefresh = false;
			Refresh(false);
		}
	}

	public ParticleOpacity()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831726E0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		cooldown = 1f;
		lastSetOpacity = 0.5f;
		autoMinSize = 4f;
		autoMaxSize = 8f;
		minOpacity = 0.1f;
		particleOpacitySettingName = "particle_opacity";
		base._002Ector();
	}
}
