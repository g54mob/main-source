using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Particles;

public static class ParticleSystemGenerator
{
	public unsafe static ParticleSystem GenerateParticleSystem(ParticleSystemConfig config, Transform parent = null, string name = null, bool usePauseSystem = true)
	{
		//IL_034a: Expected I, but got O
		//IL_0309: Expected O, but got I
		//IL_0130->IL0214: Incompatible stack heights: 2 vs 0
		//IL_00e6->IL0214: Incompatible stack heights: 2 vs 0
		//IL_01c1->IL0358: Incompatible stack heights: 4 vs 3
		//IL_01f8->IL0214: Incompatible stack heights: 3 vs 0
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "ParticleSystem");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if (name != null && name._stringLength > 0)
			{
				((UnityEngine.Object)gameObject).SetName(name);
			}
			bool flag3 = (object)parent == null;
			bool flag4 = usePauseSystem;
			if (!flag3)
			{
				bool flag5 = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
				flag4 = usePauseSystem;
				if (!flag5)
				{
					Transform transform2 = gameObject.transform;
					if ((object)transform2 == null)
					{
						goto IL_0214;
					}
					transform2.SetParent(parent, worldPositionStays: false);
					flag4 = false;
				}
			}
			ParticleSystem particleSystem = gameObject.AddComponent<ParticleSystem>();
			if ((object)particleSystem != null)
			{
				bool flag6 = ((string)(object)particleSystem)._stringLength == 0;
				ParticleSystem.Stop_Injected((IntPtr)((string)(object)particleSystem)._stringLength, true, ParticleSystemStopBehavior.StopEmittingAndClear);
				bool flag7 = !usePauseSystem;
				nint num = 1;
				nint num2 = unchecked((nint)null);
				if (!flag7)
				{
					bool flag8 = gameObject.TryGetComponent<ParticlePauseController>(out var component);
					num = (nint)(&component);
					num2 = 0;
					if (!flag8)
					{
						ParticlePauseController particlePauseController = gameObject.AddComponent<ParticlePauseController>();
						num = 0;
						num2 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9D0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag9 = obj == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v915 @ rax_v47 (should have been resolved before IL gen)");
				if (config != null)
				{
					ConfigureParticleSystem(particleSystem, config);
					PfxData pfxData = gameObject.AddComponent<PfxData>();
					if ((object)pfxData == null)
					{
						goto IL_0214;
					}
					pfxData._003CCurrentConfig_003Ek__BackingField = config;
				}
				return particleSystem;
			}
		}
		goto IL_0214;
		IL_0214:
		throw new NullReferenceException();
	}

	public unsafe static GravityWell GenerateGravityWell(GravityWellConfig config, Transform parent = null, string name = null, bool usePauseSystem = true)
	{
		//IL_0177->IL01ed: Incompatible stack heights: 2 vs 0
		//IL_00de->IL01ed: Incompatible stack heights: 2 vs 0
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "GravityWell");
		if ((object)gameObject != null)
		{
			Transform transform = gameObject.transform;
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			ParticlePauseController value = default(ParticlePauseController);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			if (name != null && name._stringLength > 0)
			{
				((UnityEngine.Object)gameObject).SetName(name);
			}
			if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
			{
				Transform transform2 = gameObject.transform;
				if ((object)transform2 == null)
				{
					goto IL_01ed;
				}
				transform2.SetParent(parent, worldPositionStays: false);
			}
			GravityWell gravityWell = gameObject.AddComponent<GravityWell>();
			if (usePauseSystem && !gameObject.TryGetComponent<ParticlePauseController>(out value))
			{
				ParticlePauseController particlePauseController = gameObject.AddComponent<ParticlePauseController>();
			}
			if (config != null)
			{
				if ((object)gravityWell == null)
				{
					goto IL_01ed;
				}
				_ = config.requiresLateUpdate;
				_ = config._gravity;
				float num = config._gravity * config._power;
				float num2 = config._epsilon * config._epsilon;
				ConfigureGravityWellPosition(config, gravityWell);
			}
			return gravityWell;
		}
		goto IL_01ed;
		IL_01ed:
		throw new NullReferenceException();
	}

	public static void SetupTimeline(Transform parent, GameObject gameObject, bool usePauseSystem = true)
	{
		if (usePauseSystem && !gameObject.TryGetComponent<ParticlePauseController>(out var _))
		{
			ParticlePauseController particlePauseController = gameObject.AddComponent<ParticlePauseController>();
		}
	}

	private unsafe static void ConfigureParticleSystem(ParticleSystem particleSystem, ParticleSystemConfig config)
	{
		//IL_0008: Expected O, but got Ref
		//IL_005a: Expected O, but got I4
		//IL_05ff: Expected O, but got I
		//IL_0bbb: Expected O, but got Ref
		//IL_064b: Expected O, but got I
		//IL_0bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Expected O, but got Unknown
		//IL_0c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c19: Expected I4, but got Unknown
		//IL_00ac: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0101: Expected O, but got I
		//IL_0681: Expected O, but got Ref
		//IL_069b: Expected O, but got I
		//IL_0c2c: Expected O, but got Ref
		//IL_0c4b: Expected O, but got I
		//IL_0c6d: Expected O, but got I
		//IL_071b: Expected O, but got Ref
		//IL_0729: Expected O, but got Ref
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_029e: Expected O, but got I
		//IL_0797: Expected O, but got I
		//IL_07a5: Expected O, but got Ref
		//IL_07b3: Expected O, but got Ref
		//IL_07e7: Expected O, but got I
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_081d: Expected O, but got Ref
		//IL_03db: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_03f0: Expected O, but got I
		//IL_040a: Expected O, but got I
		//IL_041a: Expected O, but got I
		//IL_09c9: Expected O, but got Ref
		//IL_086b: Expected O, but got I
		//IL_0c80: Expected O, but got Ref
		//IL_0a20: Expected O, but got Ref
		//IL_0a2e: Expected O, but got Ref
		//IL_0a67: Expected O, but got I
		//IL_0ab4: Expected O, but got Ref
		//IL_08f6: Expected O, but got Ref
		//IL_0923: Expected O, but got Ref
		//IL_094e: Expected native int or pointer, but got O
		//IL_0963: Expected O, but got I
		//IL_0971: Expected O, but got Ref
		//IL_0981: Expected F4, but got I
		//IL_098f: Expected O, but got Ref
		//IL_0b50: Expected O, but got Ref
		//IL_047c->IL09bb: Incompatible stack heights: 1 vs 0
		//IL_09bb->IL03b2: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemRenderer component;
		if ((object)particleSystem != null)
		{
			component = particleSystem.GetComponent<ParticleSystemRenderer>();
			if (config != null)
			{
				if ((object)config._simulationSpace != null)
				{
					object obj3 = (object?)config._simulationSpace >> 32;
				}
				else
				{
					object obj3 = 1;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B978]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj4 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v713 @ rax_v50 (should have been resolved before IL gen)");
				BlendMode? blendMode = config._blendMode;
				_ = config._blendMode;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
				if ((nint)0 == 0)
				{
					_ = 0;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7F]");
					blendMode = (BlendMode?)(object)0;
					obj6 = 1;
				}
				object obj7 = (object?)blendMode >> 32;
				object obj8 = obj7 - 1;
				bool flag = obj8 == null;
				MaterialType type = ((flag & obj6) ? MaterialType.ParticlesAdditive : MaterialType.Particles);
				Material material = MaterialManager.GetMaterial(type);
				if ((object)component != null)
				{
					((Renderer)component).SetMaterial(material);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj9 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
					}
					object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v952 @ rax_v60 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj11 == null)
						{
							MissingMethodException ex3 = new MissingMethodException();
							throw ex3;
						}
					}
					object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v980 @ rax_v63 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-21]");
					ConfigureFrames(config, (ParticleSystem.TextureSheetAnimationModule)0);
					ConfigureSpeed(config, particleSystem);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
					ConfigureAngle(config, (ParticleSystem.ShapeModule)0);
					ParticleSystem.MinMaxCurve rotate = config._rotate;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
					_ = 0;
					_ = config._rotate;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+120]");
					_ = 0;
					bool flag2 = (object)config._rotate == null;
					if (flag2)
					{
						goto IL_06eb;
					}
					object obj13 = config._rotate - 1;
					if (!flag2)
					{
						object obj14 = obj13 - 1;
						if (!flag2 && (nint)obj14 == 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
							float num = 0f * ((float)Math.PI / 180f);
							goto IL_06eb;
						}
					}
					else
					{
						_ = 1016003125;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
						rotate = (ParticleSystem.MinMaxCurve)0;
					}
					goto IL_070d;
				}
			}
		}
		goto IL_059e;
		IL_06eb:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
		float num2 = 0f * ((float)Math.PI / 180f);
		goto IL_070d;
		IL_059e:
		throw new NullReferenceException();
		IL_070d:
		ParticleSystem.MinMaxCurve startRotation = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startRotation = startRotation;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+140]");
		_ = 0;
		if ((object)config._lifespan == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
			float num3 = 0f * 0.001f;
			float num4 = 0.01f;
		}
		else
		{
			bool flag3 = (nint)config._lifespan != 3;
			float num4 = 0.01f;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
				float num5 = 0f * 0.001f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
				num4 = 0f * 0.001f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		object obj15 = 0;
		ParticleSystem.MinMaxCurve startLifetime = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		_ = config._lifespan;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startLifetime = startLifetime;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj16 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1309 @ rax_v74 (should have been resolved before IL gen)");
		object obj18 = default(object);
		if ((nint)obj18 > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBE0]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBE0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj19 == null)
				{
					MissingMethodException ex5 = new MissingMethodException();
					throw ex5;
				}
			}
			object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1475 @ rax_v112 (should have been resolved before IL gen)");
			IntPtr gcHandlePtr = default(IntPtr);
			Sprite sprite = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Sprite>(gcHandlePtr);
			if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				_ = 0;
				bool flag4 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj21);
				float pixelsPerUnit = sprite.pixelsPerUnit;
				ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				float constant = 0f / pixelsPerUnit;
				_ = 0;
				_ = 0;
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(constant));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				obj15 = 0;
				ParticleSystem.MinMaxCurve startSize = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
				float num4 = 0f;
				ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
				_ = 0;
				((ParticleSystem.MainModule*)mainModule3)->startSize = startSize;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		float sizeMult = default(float);
		ConfigureScale(config, (ParticleSystem.SizeOverLifetimeModule)num6, component, (ParticleSystem.MainModule)0, sizeMult);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-11]");
		ConfigureAlpha(config, (ParticleSystem.ColorOverLifetimeModule)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		ConfigureQuantity(config, (ParticleSystem.EmissionModule)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag5 = obj22 == null;
		}
		object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1574 @ rax_v81 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+218]");
		_ = 0;
		if ((object)config._gravity == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
			float num7 = 0f * 0.001f;
		}
		else if ((nint)config._gravity == 3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
			float num8 = 0f * 0.001f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-3D]");
			float num4 = 0f * 0.001f;
		}
		ParticleSystem.MinMaxCurve gravityModifier = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		ParticleSystem.MainModule mainModule4 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		_ = config._gravity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule4)->gravityModifier = gravityModifier;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
		ConfigureTint(config, (ParticleSystem.MainModule)0);
		ConfigureEmitZone(config, particleSystem);
		Transform transform = particleSystem.transform;
		if ((object)transform != null)
		{
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v88 (UnityEngine.Transform)+10]");
			bool flag6 = (nint)0 == 0;
			object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v88 (UnityEngine.Transform)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj24);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			if ((object)config._x == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+2C]");
				_ = 0;
			}
			if ((object)config._y == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rdx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+4C]");
				_ = 0;
			}
			Transform transform2 = particleSystem.transform;
			bool flag7 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v94 (UnityEngine.Transform)+10]");
			bool flag8 = (nint)0 == 0;
			object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1535 @ rax_v94 (UnityEngine.Transform)+10]");
			Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj25);
			RenderingExtensions.SetCollisionBounds(particleSystem, config);
			RenderingExtensions.SetCollisionBoundsCircle(particleSystem, config);
			return;
		}
		goto IL_059e;
	}

	private unsafe static void ConfigureFrames(ParticleSystemConfig config, ParticleSystem.TextureSheetAnimationModule textureSheetAnimation)
	{
		//IL_02be: Expected O, but got I
		//IL_0069: Expected O, but got I
		//IL_0331: Expected O, but got I
		//IL_03d9: Expected O, but got I
		//IL_0511: Expected O, but got Ref
		//IL_0521: Expected O, but got I
		//IL_043a: Expected O, but got I
		//IL_0255: Expected O, but got I
		//IL_01a8: Expected I, but got O
		//IL_0162: Expected I, but got O
		if (config._frame != null)
		{
			List<string> frame = config._frame;
			if (frame._size > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v209 @ rax_v34 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB78]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB78]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj2 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v337 @ rax_v37 (should have been resolved before IL gen)");
				string frame2 = (string)(object)config._frame;
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				ParticleSystem.TextureSheetAnimationModule textureSheetAnimationModule = default(ParticleSystem.TextureSheetAnimationModule);
				while (enumerator.MoveNext())
				{
					Sprite sprite = SpriteManager.GetSprite(null, config._003CTexture_003Ek__BackingField);
					if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						textureSheetAnimationModule.AddSprite(sprite);
						frame2 = null;
						nint num = unchecked((nint)null);
					}
					else
					{
						frame2 = config._003CTexture_003Ek__BackingField;
						string message = string.Concat("<ParticleSystemGenerator.ConfigureFrames> sprite manager returned null.", null, "  ", config._003CTexture_003Ek__BackingField);
						Debug.LogError(message);
						nint num = unchecked((nint)"  ");
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBA8]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj3 == null)
					{
						MissingMethodException ex3 = new MissingMethodException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v727 @ rax_v46 (should have been resolved before IL gen)");
				float max = default(float);
				ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, max);
				ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
				textureSheetAnimationModule.startFrame = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB90]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB90]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj4 == null)
					{
						MissingMethodException ex4 = new MissingMethodException();
						throw ex4;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v855 @ rax_v51 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB88]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB88]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj5 == null)
					{
						MissingMethodException ex5 = new MissingMethodException();
						throw ex5;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v900 @ rax_v54 (should have been resolved before IL gen)");
				if (config._fps == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB80]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB80]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj6 == null)
					{
						MissingMethodException ex6 = new MissingMethodException();
						throw ex6;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1001 @ rax_v57 (should have been resolved before IL gen)");
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB68]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex7 = new MissingMethodException();
				throw ex7;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v152 @ rax_v29 (should have been resolved before IL gen)");
	}

	private unsafe static void ConfigureSpeed(ParticleSystemConfig config, ParticleSystem ps)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03c2: Expected O, but got Ref
		//IL_03d7: Expected native int or pointer, but got O
		//IL_03ea: Expected O, but got Ref
		//IL_03f8: Expected O, but got Ref
		//IL_0439: Expected O, but got I
		//IL_05a1: Expected O, but got Ref
		//IL_0573: Expected O, but got Ref
		//IL_0143: Expected O, but got I
		//IL_05be: Expected O, but got Ref
		//IL_0488: Expected O, but got Ref
		//IL_04a0: Expected O, but got Ref
		//IL_04ba: Expected native int or pointer, but got O
		//IL_04cd: Expected O, but got Ref
		//IL_04db: Expected O, but got Ref
		//IL_0510: Expected O, but got Ref
		//IL_052a: Expected native int or pointer, but got O
		//IL_01aa: Expected O, but got Ref
		//IL_01b8: Expected O, but got Ref
		//IL_01ed: Expected O, but got Ref
		//IL_0207: Expected native int or pointer, but got O
		//IL_021f: Expected O, but got Ref
		//IL_022d: Expected O, but got Ref
		//IL_00c5: Expected O, but got Ref
		//IL_00da: Expected native int or pointer, but got O
		//IL_00ed: Expected O, but got Ref
		//IL_0291: Expected O, but got Ref
		//IL_029f: Expected O, but got Ref
		//IL_0305: Expected O, but got Ref
		//IL_0313: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f));
		ParticleSystem.MinMaxCurve startSpeed = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startSpeed = startSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v279 @ rax_v16 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve startSpeed2;
		if (config._speed == null)
		{
			if (config._speedX == null)
			{
				if (config._speedY == null)
				{
					ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f));
					startSpeed2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
					_ = 0;
					goto IL_05b0;
				}
				if (config._speed != null)
				{
					goto IL_0333;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BBF8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj5 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v536 @ rax_v23 (should have been resolved before IL gen)");
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 0f));
			ParticleSystem.MinMaxCurve x = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
			_ = 0;
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule)->x = x;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 31));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 0f));
			ParticleSystem.MinMaxCurve y = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule2 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1F]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+2F]");
			_ = 0;
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule2)->y = y;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 0f));
			ParticleSystem.MinMaxCurve z = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule3 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule3)->z = z;
			if (config._speedX != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+C8]");
				_ = 0;
				ParticleSystem.MinMaxCurve x2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule4 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+B8]");
				_ = 0;
				((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule4)->x = x2;
			}
			if (config._speedY != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+F0]");
				_ = 0;
				ParticleSystem.MinMaxCurve y2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule5 = (ParticleSystem.VelocityOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+E0]");
				_ = 0;
				((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule5)->y = y2;
			}
			return;
		}
		goto IL_0333;
		IL_05b0:
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
		((ParticleSystem.MainModule*)mainModule2)->startSpeed = startSpeed2;
		return;
		IL_0565:
		startSpeed2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+90]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
		_ = 0;
		goto IL_05b0;
		IL_0333:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+90]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+90]");
			if ((nint)0 != 3)
			{
				goto IL_0565;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-39]");
			float num = 0f * 0.01f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-35]");
		float num2 = 0f * 0.01f;
		goto IL_0565;
	}

	private static void ConfigureAngle(ParticleSystemConfig config, ParticleSystem.ShapeModule shape)
	{
		//IL_0035: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_029a: Expected O, but got I
		//IL_0305: Expected O, but got I
		//IL_041f: Expected O, but got I
		//IL_01e1: Expected O, but got I
		//IL_03af: Expected O, but got I
		if ((object)config._angle == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v64 @ rax_v47 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v236 @ rax_v50 (should have been resolved before IL gen)");
		}
		else
		{
			if ((nint)config._angle != 3)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			object obj3 = 0;
			object obj5 = default(object);
			object obj4 = obj5 - obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj6 = obj4 & 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAD8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex3 = new MissingMethodException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v265 @ rax_v26 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB10]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj7 == null)
				{
					MissingMethodException ex4 = new MissingMethodException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v374 @ rax_v29 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj8 == null)
				{
					MissingMethodException ex5 = new MissingMethodException();
					throw ex5;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v475 @ rax_v32 (should have been resolved before IL gen)");
			if (config._angleSteps < 1)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
			object obj9 = 0;
			float num = 1f / (float)config._angleSteps;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj9 == null)
				{
					MissingMethodException ex6 = new MissingMethodException();
					throw ex6;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v611 @ rax_v36 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj10 == null)
				{
					MissingMethodException ex7 = new MissingMethodException();
					throw ex7;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v651 @ rax_v39 (should have been resolved before IL gen)");
		}
	}

	private unsafe static void ConfigureRotation(ParticleSystemConfig config, ParticleSystem.MainModule main)
	{
		//IL_008c: Expected O, but got Ref
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		bool flag = (object)config._rotate == null;
		if (!flag)
		{
			object obj = config._rotate - 1;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (!flag && (nint)obj2 != 1)
				{
				}
			}
		}
		ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
		object obj3 = default(object);
		mainModule.startRotation = (ParticleSystem.MinMaxCurve)(&obj3);
	}

	private unsafe static void ConfigureLifespan(ParticleSystemConfig config, ParticleSystem.MainModule main)
	{
		//IL_004f: Expected O, but got Ref
		if ((object)config._lifespan == null || (nint)config._lifespan == 3)
		{
		}
		ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
		object obj = default(object);
		mainModule.startLifetime = (ParticleSystem.MinMaxCurve)(&obj);
	}

	private unsafe static void ConfigureScale(ParticleSystemConfig config, ParticleSystem.SizeOverLifetimeModule sizeOverLifetime, ParticleSystemRenderer psr, ParticleSystem.MainModule main, float sizeMult)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0133: Expected O, but got I4
		//IL_095d: Expected O, but got I
		//IL_13c8: Expected O, but got Ref
		//IL_0a1f: Expected O, but got Ref
		//IL_0a28: Expected native int or pointer, but got O
		//IL_0a4a: Expected O, but got I4
		//IL_03ca: Expected O, but got I
		//IL_1425: Expected O, but got Ref
		//IL_142e: Expected native int or pointer, but got O
		//IL_1450: Expected O, but got I4
		//IL_0f41: Expected O, but got Ref
		//IL_0f5b: Expected O, but got I
		//IL_1533: Expected O, but got I
		//IL_1555: Expected O, but got I
		//IL_1577: Expected O, but got I
		//IL_158c: Expected O, but got I
		//IL_15a9: Expected O, but got I
		//IL_16f3: Expected O, but got Ref
		//IL_008c: Expected O, but got I
		//IL_195c: Expected O, but got Ref
		//IL_1974: Expected O, but got Ref
		//IL_1982: Expected O, but got Ref
		//IL_19b7: Expected O, but got Ref
		//IL_19c5: Expected O, but got Ref
		//IL_019b: Expected O, but got I
		//IL_0de2: Expected O, but got Ref
		//IL_0d67: Expected O, but got Ref
		//IL_0d75: Expected O, but got Ref
		//IL_0b4b: Expected O, but got I4
		//IL_0b54: Expected O, but got I4
		//IL_0b5f: Expected O, but got I4
		//IL_0ab0: Expected O, but got I
		//IL_0ac0: Expected O, but got I
		//IL_0e13: Expected O, but got Ref
		//IL_0e2d: Expected O, but got I
		//IL_0cc7: Expected O, but got I4
		//IL_0cd0: Expected O, but got I4
		//IL_0cd9: Expected O, but got I4
		//IL_0ce3: Expected O, but got I4
		//IL_0c1c: Expected O, but got I
		//IL_0c2c: Expected O, but got I
		//IL_0c35: Expected O, but got I4
		//IL_0b1e: Expected O, but got I
		//IL_0b2e: Expected O, but got I
		//IL_1405: Expected O, but got Ref
		//IL_1412: Expected O, but got Ref
		//IL_169c: Expected O, but got Ref
		//IL_0c92: Expected O, but got I
		//IL_0ca2: Expected O, but got I
		//IL_0cab: Expected O, but got I4
		//IL_059f: Expected O, but got I4
		//IL_05a8: Expected O, but got I4
		//IL_0514: Expected O, but got I
		//IL_0579: Expected O, but got I
		//IL_0f9a: Expected F4, but got O
		//IL_0f9e: Expected O, but got I4
		//IL_0272: Expected O, but got I
		//IL_027b: Expected O, but got I4
		//IL_0fd3: Expected F4, but got O
		//IL_0fd7: Expected O, but got I4
		//IL_0fe9: Expected O, but got I4
		//IL_0ff1: Expected I4, but got O
		//IL_1002: Expected I4, but got O
		//IL_100c: Expected O, but got I4
		//IL_1015: Expected O, but got I4
		//IL_14de: Invalid comparison between I4 and F4
		//IL_05fd: Expected O, but got I4
		//IL_0ebb: Expected F4, but got I
		//IL_0ebb: Expected F4, but got I
		//IL_1656: Invalid comparison between I4 and F4
		//IL_0bba: Expected O, but got I4
		//IL_07c1: Expected O, but got I4
		//IL_07ce: Expected F4, but got O
		//IL_0731: Expected O, but got I
		//IL_073e: Expected F4, but got O
		//IL_0b91: Invalid comparison between I4 and F4
		//IL_0ba3: Expected O, but got I4
		//IL_0799: Expected O, but got I
		//IL_07a6: Expected F4, but got O
		//IL_1188: Expected F4, but got I4
		//IL_1188: Expected F4, but got O
		//IL_118c: Expected O, but got I4
		//IL_0d15: Invalid comparison between I4 and F4
		//IL_11c0: Expected F4, but got I4
		//IL_11c0: Expected F4, but got O
		//IL_11c4: Expected O, but got I4
		//IL_1689: Expected O, but got Ref
		//IL_1511: Expected O, but got Ref
		//IL_1089: Expected F4, but got I4
		//IL_108d: Expected O, but got I4
		//IL_1096: Unknown result type (might be due to invalid IL or missing references)
		//IL_109b: Expected O, but got Unknown
		//IL_03a8: Expected O, but got Ref
		//IL_03b5: Expected O, but got Ref
		//IL_1115: Invalid comparison between I4 and F4
		//IL_1a2d: Expected O, but got I
		//IL_06a9: Expected O, but got I4
		//IL_064b: Expected O, but got I
		//IL_0680: Invalid comparison between I4 and F4
		//IL_0692: Expected O, but got I4
		//IL_0ef8: Expected F4, but got I4
		//IL_0efc: Expected O, but got I4
		//IL_0f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0a: Expected O, but got Unknown
		//IL_133c: Expected O, but got I
		//IL_1882: Expected O, but got Ref
		//IL_1890: Expected O, but got Ref
		//IL_08cf: Expected F4, but got I
		//IL_1152: Expected O, but got I4
		//IL_1164: Expected O, but got Ref
		//IL_116d: Expected O, but got I4
		//IL_085f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected F4, but got Unknown
		//IL_1236: Expected F4, but got I4
		//IL_1236: Expected F4, but got O
		//IL_123a: Expected O, but got I4
		//IL_1243: Unknown result type (might be due to invalid IL or missing references)
		//IL_1248: Expected O, but got Unknown
		//IL_12a8: Invalid comparison between O and F4
		//IL_138f: Expected I, but got F4
		//IL_1908: Expected O, but got I
		//IL_089b: Invalid comparison between O and F4
		//IL_13ab: Expected O, but got Ref
		//IL_09b2->IL13ba: Incompatible stack heights: 1 vs 0
		//IL_041f->IL0f33: Incompatible stack heights: 1 vs 0
		//IL_044c->IL16e5: Incompatible stack heights: 1 vs 0
		//IL_0d59->IL194e: Incompatible stack heights: 1 vs 0
		//IL_0ed7->IL0d93: Incompatible stack heights: 2 vs 0
		//IL_0d27->IL0d27: Incompatible stack heights: 1 vs 2
		//IL_168e->IL1516: Incompatible stack heights: 2 vs 0
		//IL_1516->IL1417: Incompatible stack heights: 2 vs 0
		//IL_10ba->IL0650: Incompatible stack heights: 2 vs 0
		//IL_1807->IL0d93: Incompatible stack heights: 2 vs 0
		//IL_03ba->IL0f32: Incompatible stack heights: 2 vs 0
		//IL_0650->IL10bf: Incompatible stack heights: 2 vs 0
		//IL_0884->IL0d93: Incompatible stack heights: 2 vs 0
		//IL_0f23->IL16c8: Incompatible stack heights: 4 vs 2
		//IL_0f28->IL0377: Incompatible stack heights: 4 vs 2
		//IL_126b->IL180c: Incompatible stack heights: 4 vs 2
		//IL_0901->IL1874: Incompatible stack heights: 5 vs 4
		//IL_1270->IL086c: Incompatible stack heights: 4 vs 2
		//IL_08ad->IL08ad: Incompatible stack heights: 3 vs 4
		//IL_13ba->IL0f32: Incompatible stack heights: 4 vs 0
		//IL_094d->IL139d: Incompatible stack heights: 5 vs 4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		AnimationCurve animationCurve4;
		bool num3;
		float num4;
		object obj19;
		int num6;
		object obj20;
		object obj21;
		float num9 = default(float);
		Vector3 ret;
		Vector3 value = default(Vector3);
		Easing easing;
		object obj26;
		if (config != null)
		{
			if (config._scale == null && config._scaleX == null && config._scaleY == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj3 == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
				}
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v591 @ rax_v333 (should have been resolved before IL gen)");
				return;
			}
			object obj5 = (object?)config._scaleMode >> 32;
			bool flag = obj5 == null;
			object obj6 = (_003F?)config._scaleMode & flag;
			bool flag2 = obj6 == null;
			object obj7 = !flag2;
			if (obj7 == null)
			{
				if (config._scaleX == null && config._scaleY == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC70]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC70]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj8 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
					}
					object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v882 @ rax_v292 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj10 == null)
						{
							MissingMethodException ex3 = new MissingMethodException();
							throw ex3;
						}
					}
					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1205 @ rax_v295 (should have been resolved before IL gen)");
					ParticleSystem.MinMaxCurve? minMaxCurve;
					if (config._scale != null)
					{
						minMaxCurve = config._scale;
					}
					else
					{
						minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
						_ = 0;
						_ = 0;
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
						minMaxCurve = (ParticleSystem.MinMaxCurve?)(object)0;
						minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
					}
					bool flag3 = minMaxCurve == null;
					AnimationCurve animationCurve = new AnimationCurve();
					IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
					animationCurve.m_Ptr = ptr;
					animationCurve.m_RequiresNativeCleanup = true;
					bool flag4 = config._scale == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+188]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+188]");
					_ = 0;
					bool flag5 = config._scaleEase == Easing.Linear;
					int points = 2;
					if (!flag5)
					{
						points = 8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A0]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A4]");
					float[] easedValues = EasingUtils.GetEasedValues(num, 0f, config._scaleEase, points);
					if (easedValues != null)
					{
						if (easedValues.Length > 0)
						{
							AnimationCurve animationCurve2 = null;
							do
							{
								bool flag6 = (nint)animationCurve2 >= easedValues.Length;
								bool flag7 = animationCurve.m_Ptr == (IntPtr)0;
								object obj12 = AnimationCurve.AddKey_Injected(animationCurve.m_Ptr, 0f, (float)config._scaleEase);
								animationCurve2 = (AnimationCurve)(animationCurve2 + 1);
							}
							while ((nint)animationCurve2 < easedValues.Length);
						}
						_ = 1;
						_ = 1065353216;
						_ = 0;
						_ = 0;
						_ = 0;
						ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = (ParticleSystem.SizeOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
						((ParticleSystem.SizeOverLifetimeModule*)sizeOverLifetimeModule)->size = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
						return;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC70]");
					object obj13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC70]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag8 = obj13 == null;
					}
					object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v620 @ rax_v163 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						bool flag9 = obj15 == null;
					}
					object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v921 @ rax_v166 (should have been resolved before IL gen)");
					AnimationCurve animationCurve3 = new AnimationCurve();
					IntPtr ptr2 = AnimationCurve.Internal_Create((Keyframe[])null);
					animationCurve3.m_Ptr = ptr2;
					animationCurve3.m_RequiresNativeCleanup = true;
					animationCurve4 = new AnimationCurve();
					IntPtr ptr3 = AnimationCurve.Internal_Create((Keyframe[])null);
					animationCurve4.m_Ptr = ptr3;
					animationCurve4.m_RequiresNativeCleanup = true;
					bool num2;
					int num5;
					if (config._scaleX == null)
					{
						bool flag10 = animationCurve3.m_Ptr == (IntPtr)0;
						num2 = flag10;
						object obj17 = AnimationCurve.AddKey_Injected(animationCurve3.m_Ptr, 0f, (float)psr);
						bool flag11 = animationCurve3.m_Ptr == (IntPtr)0;
						num3 = flag11;
						object obj18 = AnimationCurve.AddKey_Injected(animationCurve3.m_Ptr, 0f, (float)psr);
						num4 = 1f;
						obj19 = 0;
						num5 = (int)main;
						num6 = 2;
						easing = (Easing)psr;
						obj20 = 0;
						obj21 = 0;
						goto IL_173e;
					}
					_ = config._scaleX;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1C8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1B8]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve3;
					int num7;
					if (config._scaleX != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
						minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
						num7 = 8;
					}
					else
					{
						_ = config._scale;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A0]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+190]");
						_ = 0;
						if (config._scale != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
							minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
							num7 = 8;
						}
						else
						{
							minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
							minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
							minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
							num7 = 8;
						}
					}
					float num8 = (((object)minMaxCurve3 != null) ? num9 : num9);
					bool flag12 = config._scaleEase == Easing.Linear;
					easing = config._scaleEase;
					num5 = 2;
					if (!flag12)
					{
						num5 = num7;
					}
					float[] easedValues2 = EasingUtils.GetEasedValues(num8, num9, easing, num5);
					if (easedValues2 != null)
					{
						bool flag13 = easedValues2.Length <= 0;
						object obj22 = 0;
						AnimationCurve animationCurve5 = animationCurve3;
						if (!flag13)
						{
							while (true)
							{
								bool flag14 = (nint)obj22 >= easedValues2.Length;
								bool flag15 = animationCurve5.m_Ptr == (IntPtr)0;
								object obj23 = AnimationCurve.AddKey_Injected(animationCurve5.m_Ptr, 0f, (float)easing);
								obj22++;
								if ((nint)obj22 >= easedValues2.Length)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
								animationCurve5 = (AnimationCurve)0;
							}
						}
						if ((object)psr != null)
						{
							bool flag16 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
							num2 = flag16;
							ParticleSystemRenderer.get_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, out ret);
							if (!(0f > num8))
							{
								bool flag17 = !(0f > num9);
								value = (Vector3)0;
								if (flag17)
								{
									goto IL_1799;
								}
							}
							value = (Vector3)1065353216;
							goto IL_1799;
						}
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC68]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					bool flag18 = obj24 == null;
				}
				object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v550 @ rax_v106 (should have been resolved before IL gen)");
				if (config._scaleX == null && config._scaleY == null)
				{
					if (config._scale == null)
					{
						minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
					}
					ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
					((ParticleSystem.MainModule*)mainModule)->startSize = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
					return;
				}
				ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f));
				bool flag19 = config._scaleX == null;
				obj26 = 0;
				if (flag19)
				{
					goto IL_1417;
				}
				_ = config._scaleX;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1B8]");
				_ = 0;
				ParticleSystem.MinMaxCurve minMaxCurve5;
				if (config._scaleX != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
					minMaxCurve5 = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
					ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)0;
				}
				else
				{
					_ = config._scale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+190]");
					_ = 0;
					if (config._scale != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
						minMaxCurve5 = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)0;
					}
					else
					{
						minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)0;
						minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
						minMaxCurve5 = (ParticleSystem.MinMaxCurve)0;
					}
				}
				float num10 = (((object)minMaxCurve5 != null) ? num9 : num9);
				if ((object)psr != null)
				{
					bool flag20 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
					ParticleSystemRenderer.get_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, out ret);
					if (!(0f > num10))
					{
						bool flag21 = !(0f > num9);
						value = (Vector3)0;
						if (flag21)
						{
							goto IL_1930;
						}
					}
					value = (Vector3)1065353216;
					goto IL_1930;
				}
			}
		}
		goto IL_0d93;
		IL_0d93:
		throw new NullReferenceException();
		IL_17b7:
		_ = 1;
		_ = 1065353216;
		obj = obj21;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		_ = 0;
		bool flag22 = obj21 == null;
		float num11 = num9;
		if (!flag22)
		{
			num11 = num9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		bool flag23 = (nint)0 == 0;
		float num12 = num9;
		if (!flag23)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4648 @ rdx_v97+10]");
			num12 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC80]");
		object obj28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC80]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag24 = obj28 == null;
		}
		object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5099 @ rax_v181 (should have been resolved before IL gen)");
		_ = 1;
		_ = 1065353216;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		_ = 0;
		bool flag25 = obj21 == null;
		float num13 = num9;
		if (!flag25)
		{
			num13 = num9;
		}
		bool flag26 = animationCurve4 == null;
		nint num14 = (nint)num9;
		if (!flag26)
		{
			num14 = animationCurve4.m_Ptr;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC88]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC88]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag27 = obj31 == null;
		}
		object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v5608 @ rax_v190 (should have been resolved before IL gen)");
		return;
		IL_1799:
		bool flag28 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
		num3 = flag28;
		ParticleSystemRenderer.set_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, ref value);
		num4 = 1f;
		obj19 = 0;
		num6 = 2;
		obj20 = (object)(&value);
		obj21 = 0;
		goto IL_173e;
		IL_173e:
		bool num15;
		bool num16;
		if (config._scaleY == null)
		{
			bool flag29 = animationCurve4.m_Ptr == (IntPtr)0;
			num15 = flag29;
			object obj33 = AnimationCurve.AddKey_Injected(animationCurve4.m_Ptr, (float)obj20, (float)easing);
			bool flag30 = animationCurve4.m_Ptr == (IntPtr)0;
			num16 = flag30;
			object obj34 = AnimationCurve.AddKey_Injected(animationCurve4.m_Ptr, (float)obj20, (float)easing);
			float num17 = num4;
			goto IL_17b7;
		}
		_ = config._scaleY;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1F0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1E0]");
		_ = 0;
		object obj35;
		if (config._scaleY != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			obj35 = 0;
			float num17 = (float)config._scaleY;
		}
		else
		{
			_ = config._scale;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+190]");
			_ = 0;
			if (config._scale != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
				obj35 = 0;
				float num17 = (float)config._scale;
			}
			else
			{
				minMaxCurve2 = new ParticleSystem.MinMaxCurve(num4);
				obj35 = 0;
				float num17 = (float)config._scale;
			}
		}
		float num18 = ((obj35 != null) ? num9 : num9);
		bool flag31 = config._scaleEase == Easing.Linear;
		easing = config._scaleEase;
		if (!flag31)
		{
			num6 = 8;
		}
		float[] easedValues3 = EasingUtils.GetEasedValues(num18, num9, easing, num6);
		if (easedValues3 != null)
		{
			bool flag32 = easedValues3.Length <= 0;
			object obj36 = obj21;
			if (!flag32)
			{
				bool flag35;
				do
				{
					bool flag33 = (nint)obj36 >= easedValues3.Length;
					bool flag34 = animationCurve4.m_Ptr == (IntPtr)0;
					float num19 = easedValues3[obj36];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					float num20 = num19 & 0;
					object obj37 = AnimationCurve.AddKey_Injected(animationCurve4.m_Ptr, (float)obj20, (float)easing);
					obj36++;
					flag35 = (nint)obj36 < easedValues3.Length;
					float num17 = num20;
				}
				while (flag35);
			}
			if ((object)psr != null)
			{
				bool flag36 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
				num15 = flag36;
				ParticleSystemRenderer.get_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, out ret);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num18) || System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num9))
				{
					bool flag37 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
					num16 = flag37;
				}
				ParticleSystemRenderer.set_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, ref value);
				int num5 = num6;
				goto IL_17b7;
			}
		}
		goto IL_0d93;
		IL_1930:
		bool flag38 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
		ParticleSystemRenderer.set_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, ref value);
		obj26 = (object)(&value);
		goto IL_1417;
		IL_1417:
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f));
		bool flag39 = config._scaleY == null;
		object obj38 = 0;
		if (!flag39)
		{
			_ = config._scaleY;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1F0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1E0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8;
			if (config._scaleY != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
				minMaxCurve8 = (ParticleSystem.MinMaxCurve)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
				ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)0;
				obj38 = 0;
			}
			else
			{
				_ = config._scale;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+1A0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+190]");
				_ = 0;
				if (config._scale != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
					minMaxCurve8 = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
					ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)0;
					obj38 = 0;
				}
				else
				{
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
					ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)0;
					minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
					obj38 = 0;
					minMaxCurve8 = (ParticleSystem.MinMaxCurve)0;
				}
			}
			float num21 = (((object)minMaxCurve8 != null) ? num9 : num9);
			if ((object)psr == null)
			{
				goto IL_0d93;
			}
			bool flag40 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
			ParticleSystemRenderer.get_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, out ret);
			if (0f > num21 || !(0f > num9))
			{
				bool flag41 = ((UnityEngine.Object)psr).m_CachedPtr == (IntPtr)0;
			}
			ParticleSystemRenderer.set_flip_Injected(((UnityEngine.Object)psr).m_CachedPtr, ref value);
			obj26 = (object)(&value);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+34]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		object obj39 = num22 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		object obj40 = num23 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+54]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		object obj41 = num24 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		object obj42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		object obj43 = num25 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B908]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			bool flag42 = obj42 == null;
		}
		object obj44 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1964 @ rax_v113 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurve startSizeX = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule2)->startSizeX = startSizeX;
		ParticleSystem.MinMaxCurve startSizeY = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule3)->startSizeY = startSizeY;
		minMaxCurve2 = new ParticleSystem.MinMaxCurve(1f);
		ParticleSystem.MinMaxCurve startSizeZ = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		ParticleSystem.MainModule mainModule4 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		((ParticleSystem.MainModule*)mainModule4)->startSizeZ = startSizeZ;
	}

	private unsafe static void ConfigureAlpha(ParticleSystemConfig config, ParticleSystem.ColorOverLifetimeModule colorOverLifetime)
	{
		//IL_0008: Expected O, but got Ref
		//IL_001d: Expected O, but got I
		//IL_04e9: Expected O, but got Ref
		//IL_04b8: Expected O, but got Ref
		//IL_025f: Expected O, but got Ref
		//IL_026d: Expected O, but got Ref
		//IL_057d: Expected F4, but got I
		//IL_057d: Expected F4, but got I
		//IL_03ee: Expected O, but got I4
		//IL_040c: Expected O, but got I4
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected O, but got Unknown
		//IL_02b3->IL0552: Incompatible stack heights: 1 vs 0
		//IL_048d->IL0586: Incompatible stack heights: 2 vs 3
		//IL_059c->IL0241: Incompatible stack heights: 3 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC48]");
		object obj3 = 0;
		if (config._alpha == null)
		{
			if (obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v286 @ rax_v20 (should have been resolved before IL gen)");
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BC48]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v286 @ rax_v20 (should have been resolved before IL gen)");
		Gradient gradient = new Gradient();
		IntPtr ptr = Gradient.Init();
		gradient.m_Ptr = ptr;
		gradient.m_RequiresNativeCleanup = true;
		bool flag = config._alpha == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+168]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
		GradientAlphaKey[] alphaKeys;
		GradientColorKey[] colorKeys;
		if ((nint)0 == 0)
		{
			GradientColorKey[] array = new GradientColorKey[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			_ = 1f;
			GradientAlphaKey[] array2 = new GradientAlphaKey[2];
			bool flag2 = config._alpha == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+174]");
			_ = 0;
			_ = 0;
			bool flag3 = config._alpha == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+174]");
			_ = 0;
			_ = 1065353216;
			alphaKeys = array2;
			colorKeys = array;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
			if ((nint)0 != 3)
			{
				goto IL_0241;
			}
			GradientColorKey[] array3 = new GradientColorKey[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			_ = 1f;
			bool flag4 = config._alpha == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+158]");
			_ = 0;
			bool flag5 = config._alphaEase == Easing.Linear;
			int points = 2;
			if (!flag5)
			{
				points = 8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+170]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+174]");
			float[] easedValues = EasingUtils.GetEasedValues(num, 0f, config._alphaEase, points);
			GradientAlphaKey[] array4 = new GradientAlphaKey[easedValues.Length];
			bool flag6 = easedValues.Length <= 0;
			object obj6 = 0;
			if (!flag6)
			{
				bool flag7;
				do
				{
					object obj7 = easedValues.Length - 1;
					float num2 = 1f / (float)obj7;
					float num3 = num2 * (float)obj6;
					object obj8 = obj6 + 1;
					_ = easedValues[obj6];
					flag7 = (nint)obj8 < easedValues.Length;
					obj6 = obj8;
				}
				while (flag7);
			}
			alphaKeys = array4;
			colorKeys = array3;
		}
		gradient.SetKeys(colorKeys, alphaKeys);
		goto IL_0241;
		IL_0241:
		_ = 1;
		ParticleSystem.MinMaxGradient color = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = (ParticleSystem.ColorOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
		_ = 0;
		((ParticleSystem.ColorOverLifetimeModule*)colorOverLifetimeModule)->color = color;
	}

	private unsafe static void ConfigureQuantity(ParticleSystemConfig config, ParticleSystem.EmissionModule emission)
	{
		//IL_0008: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		//IL_0058: Expected O, but got Ref
		//IL_0079: Expected O, but got Ref
		//IL_0086: Expected O, but got Ref
		//IL_00cd: Expected O, but got Ref
		//IL_00ee: Expected F4, but got I
		//IL_00e9: Expected native int or pointer, but got O
		//IL_01e9: Expected O, but got I
		//IL_0272: Expected O, but got Ref
		//IL_02ae: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_01a0: Expected O, but got Ref
		//IL_014d: Expected F4, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)config._quantity == null)
		{
			return;
		}
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.EmissionModule emissionModule = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		((ParticleSystem.EmissionModule*)emissionModule)->rateOverTime = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		ParticleSystem.EmissionModule emissionModule2 = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		((ParticleSystem.EmissionModule*)emissionModule2)->rateOverDistance = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		_ = 0;
		_ = 0;
		_ = 0;
		if ((object)config._quantity != null)
		{
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+104]");
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			bool flag = (nint)0 == 0;
			object obj4 = default(object);
			object obj3 = obj4;
			if (!flag)
			{
				obj3 = obj4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			bool flag2 = (nint)0 == 0;
			object obj6 = obj4;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v18+10]");
				obj6 = 0;
			}
			_ = 0;
			ParticleSystem.Burst burst = (ParticleSystem.Burst)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			_ = 4294967295L;
			((ParticleSystem.Burst*)burst)->repeatInterval = 0.01f;
			bool flag3 = (object)config._frequency == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			ParticleSystem.Burst burst2 = (ParticleSystem.Burst)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+10C]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+10C]");
				if ((nint)0 >= (nint)0)
				{
					num = 10f;
				}
				float repeatInterval = num * 0.001f;
				ParticleSystem.Burst burst3 = default(ParticleSystem.Burst);
				burst3.repeatInterval = repeatInterval;
				burst2 = burst3;
			}
			ParticleSystem.Burst[] array = new ParticleSystem.Burst[1];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			_ = 0;
			ParticleSystem.EmissionModule emissionModule3 = (ParticleSystem.EmissionModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
			_ = 0;
			((ParticleSystem.EmissionModule*)emissionModule3)->SetBursts(array, array.Length);
		}
		else
		{
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		}
	}

	private static void ConfigureOn(ParticleSystemConfig config, ParticleSystem.EmissionModule emission)
	{
		//IL_0010: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BA58]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v38 @ rax_v6 (should have been resolved before IL gen)");
	}

	private unsafe static void ConfigureGravity(ParticleSystemConfig config, ParticleSystem.MainModule main)
	{
		//IL_004f: Expected O, but got Ref
		if ((object)config._gravity == null || (nint)config._gravity == 3)
		{
		}
		ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
		object obj = default(object);
		mainModule.gravityModifier = (ParticleSystem.MinMaxCurve)(&obj);
	}

	private unsafe static void ConfigureTint(ParticleSystemConfig config, ParticleSystem.MainModule main)
	{
		//IL_0008: Expected O, but got Ref
		//IL_003e: Expected O, but got Ref
		//IL_0067: Expected O, but got I
		//IL_0095: Expected O, but got I
		//IL_00b0: Expected O, but got I
		//IL_00d1: Expected O, but got Ref
		//IL_00f2: Expected O, but got Ref
		//IL_015a: Expected F4, but got I4
		//IL_0169: Invalid comparison between F4 and I4
		//IL_033d: Expected O, but got Ref
		//IL_035c: Expected O, but got Ref
		//IL_0227: Invalid comparison between F4 and I4
		//IL_027d: Invalid comparison between F4 and I4
		//IL_0463->IL0362: Incompatible stack heights: 1 vs 0
		//IL_0218->IL0362: Incompatible stack heights: 1 vs 0
		//IL_0361->IL0361: Incompatible stack heights: 3 vs 0
		//IL_0296->IL03fb: Incompatible stack heights: 2 vs 0
		//IL_029b->IL029b: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemGradientMode mode = default(ParticleSystemGradientMode);
		Gradient gradient;
		GradientColorKey[] array;
		if (config != null)
		{
			if ((object)config._tint != null)
			{
				ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
				ParticleSystem.MinMaxGradient startColor = ((ParticleSystem.MainModule*)mainModule)->startColor;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+22C]");
				object obj3 = (nint)0 >> 16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+22C]");
				_ = 0;
				_ = 255;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+22C]");
				object obj4 = (nint)0 >> 8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
				object obj5 = (nint)0 >> 8;
				float num = (float)obj5 / 255f;
				ParticleSystem.MainModule mainModule2 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
				_ = startColor.m_GradientMax;
				((ParticleSystem.MainModule*)mainModule2)->startColor = (ParticleSystem.MinMaxGradient)(&mode);
				mode = startColor.m_Mode;
				float num3 = default(float);
				float num2 = num3;
			}
			if (config._tintRandom == null)
			{
				return;
			}
			gradient = new Gradient();
			IntPtr ptr = Gradient.Init();
			gradient.m_Ptr = ptr;
			gradient.m_RequiresNativeCleanup = true;
			uint[] tintRandom = config._tintRandom;
			if (config._tintRandom != null)
			{
				array = new GradientColorKey[tintRandom.Length];
				if (tintRandom.Length <= 0)
				{
					goto IL_029b;
				}
				float num4 = 0f;
				while (true)
				{
					uint[] tintRandom2 = config._tintRandom;
					if (config._tintRandom == null)
					{
						break;
					}
					bool flag = !(num4 < (float)tintRandom2.Length);
					_ = 0;
					_ = 255;
					_ = tintRandom2[num4];
					int num5 = (int)tintRandom2[num4] >> 16;
					int num6 = (int)tintRandom2[num4] >> 8;
					float num2 = (float)num5 / 255f;
					float num7 = 1f / (float)tintRandom.Length;
					float num = num7 * num4;
					if (array == null)
					{
						break;
					}
					bool flag2 = !(num4 < (float)array.Length);
					float num8 = num4 + 1f;
					float num9 = num4 * 4f;
					float num10 = num4 + num9;
					bool flag3 = num8 < (float)tintRandom.Length;
					num4 = num8;
					if (flag3)
					{
						continue;
					}
					goto IL_029b;
				}
			}
		}
		goto IL_0362;
		IL_029b:
		bool flag4 = gradient.m_Ptr == (IntPtr)0;
		Gradient.set_mode_Injected(gradient.m_Ptr, GradientMode.Fixed);
		GradientAlphaKey[] array2 = new GradientAlphaKey[2];
		if (array2 != null)
		{
			bool flag5 = array2.Length <= 0;
			_ = 1065353216;
			bool flag6 = array2.Length <= 1;
			_ = 1065353216;
			_ = 1065353216;
			gradient.SetKeys(array, array2);
			ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient(gradient);
			ParticleSystem.MainModule mainModule3 = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			_ = 0;
			((ParticleSystem.MainModule*)mainModule3)->startColor = (ParticleSystem.MinMaxGradient)(&mode);
			return;
		}
		goto IL_0362;
		IL_0362:
		throw new NullReferenceException();
	}

	private static Color32 HexToColor(uint hexVal)
	{
		//IL_0013: Expected O, but got I4
		int num = (int)hexVal >> 16;
		return (Color32)num;
	}

	private static void ConfigureEmitZone(ParticleSystemConfig config, ParticleSystem particleSystem)
	{
		//IL_00c5: Expected O, but got I
		//IL_0189: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_02e5: Expected O, but got I
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_0167: Expected O, but got I
		//IL_0356: Expected O, but got I
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_0208: Expected O, but got I
		//IL_0423: Expected O, but got I
		if (config._emitZone != null)
		{
			EmitZone emitZone = config._emitZone;
			if (emitZone._source != null)
			{
				ParticleSystem pfx = default(ParticleSystem);
				RenderingExtensions.SetEmitZone(pfx, emitZone);
				return;
			}
		}
		if ((nint)config._x != 3 && (nint)config._y != 3)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAB8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v335 @ rax_v21 (should have been resolved before IL gen)");
		if ((nint)config._x == 3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+2C]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+28]");
			object obj2;
			if (num <= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+28]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+2C]");
				obj2 = num2 - 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+2C]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+28]");
				obj2 = num3 - 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			object obj3 = 0;
			object obj4 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj5 = obj4 & 0;
			float num4 = (float)obj5 * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v615 @ rax_v34 (should have been resolved before IL gen)");
		}
		if ((nint)config._y != 3)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+4C]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+48]");
		object obj6;
		if (num5 <= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+48]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+4C]");
			obj6 = num6 - 0;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+4C]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [config @ rcx (VampireSurvivors.Framework.Particles.ParticleSystemConfig)+48]");
			obj6 = num7 - 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
		object obj7 = 0;
		object obj8 = obj6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = obj8 & 0;
		float num8 = (float)obj9 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAC8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v633 @ rax_v26 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB08]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj10 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v667 @ rax_v29 (should have been resolved before IL gen)");
	}

	private static void ConfigurePosition(ParticleSystemConfig config, ParticleSystem particleSystem)
	{
		//IL_012b: Expected I, but got O
		//IL_00d6->IL0087: Incompatible stack heights: 1 vs 0
		//IL_0082->IL00fb: Incompatible stack heights: 2 vs 1
		if ((object)particleSystem != null)
		{
			Transform transform = particleSystem.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (config != null)
				{
					if ((object)config._x == null)
					{
					}
					Transform transform2 = default(Transform);
					if ((object)config._y != null)
					{
						transform2 = particleSystem.transform;
						bool flag2 = (object)transform2 == null;
					}
					bool flag3 = (object)((ParticleSystemConfig)(object)transform2)._x == null;
					Transform.set_position_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private static void UpdateCollisionBounds(ParticleSystemConfig config, ParticleSystem particleSystem)
	{
		RenderingExtensions.SetCollisionBounds(particleSystem, config);
		RenderingExtensions.SetCollisionBoundsCircle(particleSystem, config);
	}

	private static Material GetMaterial(BlendMode? blendMode)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected I4, but got Unknown
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		bool flag = (object)blendMode != null;
		BlendMode? blendMode2 = blendMode;
		BlendMode? blendMode3 = blendMode;
		if (!flag)
		{
			blendMode2 = (BlendMode?)(object)1;
			blendMode3 = (BlendMode?)(object)1;
		}
		object obj = (object?)blendMode3 >> 32;
		object obj2 = obj - 1;
		bool flag2 = obj2 == null;
		MaterialType type = ((flag2 & (_003F?)blendMode2) ? MaterialType.ParticlesAdditive : MaterialType.Particles);
		return MaterialManager.GetMaterial(type);
	}

	private static void ConfigureGravityWell(GravityWell gravityWell, GravityWellConfig config)
	{
		//IL_0044: Expected F4, but got I4
		gravityWell._config = config;
		float num;
		float num2;
		float num3;
		if (config == null)
		{
			num = 50f;
			num2 = 0f;
			num3 = 100f;
		}
		else
		{
			num2 = config._power;
			num3 = config._epsilon;
			num = config._gravity;
			gravityWell._requiresLateUpdate = config.requiresLateUpdate;
		}
		gravityWell._gravity = num;
		float power = num * num2;
		float epsilon = num3 * num3;
		gravityWell._power = power;
		gravityWell._epsilon = epsilon;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 89 Invalid \"Jump target not found in method: 0x186B58A00\"");
		throw new NullReferenceException();
	}

	private static void ConfigureGravityWellPosition(GravityWellConfig config, GravityWell well)
	{
		//IL_012a: Expected I, but got O
		//IL_00d8->IL006c: Incompatible stack heights: 1 vs 0
		//IL_0067->IL00fa: Incompatible stack heights: 2 vs 1
		if ((object)well != null)
		{
			Transform transform = well.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if (config != null)
				{
					if ((object)config._x != null)
					{
					}
					Transform transform2 = default(Transform);
					if ((object)config._y == null)
					{
						transform2 = well.transform;
						bool flag2 = (object)transform2 == null;
					}
					bool flag3 = (object)((GravityWellConfig)(object)transform2)._x == null;
					Transform.set_position_Injected((IntPtr)((GravityWellConfig)(object)transform2)._x, ref ret);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}
}
