using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_Support(CharacterController controller)
{
	public class TemporaryEffect
	{
		public ParticleSystem ParticleSystem;

		public int Actives;

		public MultiTargetTween Tween;

		public List<float> ActiveValueChanges;
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public CharacterController_Support _003C_003E4__this;

		public float cooldownChange;

		public float speedChange;

		internal void _003CAddActiveRapidFire_003Eb__2()
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected I4, but got Unknown
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect rapidFireEffect = characterController_Support._rapidFireEffect;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = rapidFireEffect.Actives - characterController_Support;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			TemporaryEffect rapidFireEffect2 = characterController_Support2._rapidFireEffect;
			int depth = characterController_Support2.controller.depth;
			int depth2 = depth - 1;
			RenderingExtensions.SetDepth(rapidFireEffect2.ParticleSystem, depth2);
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			TemporaryEffect rapidFireEffect3 = characterController_Support3._rapidFireEffect;
			CharacterController_Support characterController_Support4 = _003C_003E4__this;
			float2 position = characterController_Support4.controller.position;
			int count = obj + 11;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(rapidFireEffect3.ParticleSystem, pos, count);
		}

		internal void _003CAddActiveRapidFire_003Eb__0()
		{
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect rapidFireEffect = characterController_Support._rapidFireEffect;
			int actives = rapidFireEffect.Actives + 1;
			rapidFireEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + cooldownChange;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			CharacterController controller2 = characterController_Support3.controller;
			PlayerModifierStats playerStats2 = controller2._playerStats;
			EggFloat eggFloat3 = playerStats2._003CSpeed_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + speedChange;
			playerStats2._003CSpeed_003Ek__BackingField = eggFloat4;
		}

		internal void _003CAddActiveRapidFire_003Eb__1()
		{
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect rapidFireEffect = characterController_Support._rapidFireEffect;
			int actives = rapidFireEffect.Actives - 1;
			rapidFireEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - cooldownChange;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			CharacterController controller2 = characterController_Support3.controller;
			PlayerModifierStats playerStats2 = controller2._playerStats;
			EggFloat eggFloat3 = playerStats2._003CSpeed_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val - speedChange;
			playerStats2._003CSpeed_003Ek__BackingField = eggFloat4;
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public CharacterController_Support _003C_003E4__this;

		public float statChange1;

		internal void _003CAddActiveHeartRefresh_003Eb__2()
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected I4, but got Unknown
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect heartRefreshEffect = characterController_Support._heartRefreshEffect;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			object obj = heartRefreshEffect.Actives - characterController_Support;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			TemporaryEffect heartRefreshEffect2 = characterController_Support2._heartRefreshEffect;
			int depth = characterController_Support2.controller.depth;
			int depth2 = depth - 1;
			RenderingExtensions.SetDepth(heartRefreshEffect2.ParticleSystem, depth2);
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			TemporaryEffect heartRefreshEffect3 = characterController_Support3._heartRefreshEffect;
			CharacterController_Support characterController_Support4 = _003C_003E4__this;
			float2 position = characterController_Support4.controller.position;
			int count = obj + 11;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(heartRefreshEffect3.ParticleSystem, pos, count);
		}

		internal void _003CAddActiveHeartRefresh_003Eb__0()
		{
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect heartRefreshEffect = characterController_Support._heartRefreshEffect;
			int actives = heartRefreshEffect.Actives + 1;
			heartRefreshEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + statChange1;
			playerStats._003CRegen_003Ek__BackingField = eggFloat2;
		}

		internal void _003CAddActiveHeartRefresh_003Eb__1()
		{
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect heartRefreshEffect = characterController_Support._heartRefreshEffect;
			int actives = heartRefreshEffect.Actives - 1;
			heartRefreshEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - statChange1;
			playerStats._003CRegen_003Ek__BackingField = eggFloat2;
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public CharacterController_Support _003C_003E4__this;

		public float2 offset;

		public float _amount;

		internal void _003CAddActiveMirrorOfTruth_003Eb__2()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected I4, but got Unknown
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				CharacterController_Support characterController_Support = _003C_003E4__this;
				TemporaryEffect mirrorOfTruthEffect = characterController_Support._mirrorOfTruthEffect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj = mirrorOfTruthEffect.Actives - characterController_Support;
				CharacterController_Support characterController_Support2 = _003C_003E4__this;
				TemporaryEffect mirrorOfTruthEffect2 = characterController_Support2._mirrorOfTruthEffect;
				int depth = characterController_Support2.controller.depth;
				int depth2 = depth - 1;
				RenderingExtensions.SetDepth(mirrorOfTruthEffect2.ParticleSystem, depth2);
				CharacterController_Support characterController_Support3 = _003C_003E4__this;
				TemporaryEffect mirrorOfTruthEffect3 = characterController_Support3._mirrorOfTruthEffect;
				CharacterController_Support characterController_Support4 = _003C_003E4__this;
				float2 position = characterController_Support4.controller.position;
				int count = obj + 11;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(mirrorOfTruthEffect3.ParticleSystem, pos, count);
			}
		}

		internal void _003CAddActiveMirrorOfTruth_003Eb__0()
		{
			//IL_0116: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_0182: Expected O, but got I
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect = characterController_Support._mirrorOfTruthEffect;
			int actives = mirrorOfTruthEffect.Actives + 1;
			mirrorOfTruthEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val + _amount;
			playerStats._003CAmount_003Ek__BackingField = eggFloat2;
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect2 = characterController_Support3._mirrorOfTruthEffect;
			List<float> activeValueChanges = mirrorOfTruthEffect2.ActiveValueChanges;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v4+18]");
			if (num >= 0)
			{
				activeValueChanges.AddWithResize(_amount);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = _amount;
		}

		internal void _003CAddActiveMirrorOfTruth_003Eb__1()
		{
			//IL_00bb: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_01c4: Expected O, but got I
			CharacterController_Support characterController_Support = _003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect = characterController_Support._mirrorOfTruthEffect;
			int actives = mirrorOfTruthEffect.Actives - 1;
			mirrorOfTruthEffect.Actives = actives;
			CharacterController_Support characterController_Support2 = _003C_003E4__this;
			CharacterController controller = characterController_Support2.controller;
			PlayerModifierStats playerStats = controller._playerStats;
			CharacterController_Support characterController_Support3 = _003C_003E4__this;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			TemporaryEffect mirrorOfTruthEffect2 = characterController_Support3._mirrorOfTruthEffect;
			List<float> activeValueChanges = mirrorOfTruthEffect2.ActiveValueChanges;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = -1;
				float value = default(float);
				EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
				float num = eggFloat._val;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v9+20+v242 @ rax_v11*4]");
				value = num - 0f;
				playerStats._003CAmount_003Ek__BackingField = eggFloat2;
				CharacterController_Support characterController_Support4 = _003C_003E4__this;
				TemporaryEffect mirrorOfTruthEffect3 = characterController_Support4._mirrorOfTruthEffect;
				TemporaryEffect mirrorOfTruthEffect4 = characterController_Support4._mirrorOfTruthEffect;
				List<float> activeValueChanges2 = mirrorOfTruthEffect3.ActiveValueChanges;
				List<float> activeValueChanges3 = mirrorOfTruthEffect4.ActiveValueChanges;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj4 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
					_ = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	[NonSerialized]
	public float RapidFire_Life;

	[NonSerialized]
	public float HeartRefresh_Life;

	[NonSerialized]
	public float MirrorOfTruth_Life;

	private TemporaryEffect _rapidFireEffect;

	private TemporaryEffect _heartRefreshEffect;

	private KarmaCoinVFX _lastKarmaCoinVFX;

	private int _karmaCoinCount;

	private HeartRefreshVFX _lastHeartRefreshVFX;

	private TemporaryEffect _mirrorOfTruthEffect;

	private readonly CharacterController controller = controller;

	public void InternalUpdate()
	{
		if (_karmaCoinCount <= 0)
		{
			return;
		}
		KarmaCoinVFX lastKarmaCoinVFX = _lastKarmaCoinVFX;
		if ((object)_lastKarmaCoinVFX != null && ((UnityEngine.Object)lastKarmaCoinVFX).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _lastKarmaCoinVFX.gameObject;
			if (gameObject.activeSelf)
			{
				return;
			}
		}
		float num = controller.PLuck();
		float pLuck = default(float);
		ActivateKarmaCoin(pLuck);
		int karmaCoinCount = _karmaCoinCount - 1;
		_karmaCoinCount = karmaCoinCount;
	}

	private unsafe void InitRapidFireEffect()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0217: Expected O, but got Ref
		//IL_0231: Expected native int or pointer, but got O
		//IL_024b: Expected O, but got I
		//IL_026b: Expected O, but got Ref
		//IL_0285: Expected native int or pointer, but got O
		//IL_0607: Expected O, but got I4
		//IL_029d: Expected O, but got Ref
		//IL_02c4: Expected O, but got I
		//IL_02de: Expected native int or pointer, but got O
		//IL_02f8: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_0332: Expected native int or pointer, but got O
		//IL_0624: Expected O, but got I4
		//IL_034a: Expected O, but got Ref
		//IL_0364: Expected native int or pointer, but got O
		//IL_064e: Expected O, but got I
		//IL_039c: Expected O, but got Ref
		//IL_03b1: Expected native int or pointer, but got O
		//IL_03cb: Expected O, but got I
		//IL_06b5: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		TemporaryEffect rapidFireEffect = new TemporaryEffect();
		_rapidFireEffect = rapidFireEffect;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"PfxRed");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxYellow");
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					if (particleSystemConfig != null)
					{
						particleSystemConfig._frame = list;
						ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-58]");
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-48]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(25f, 50f));
						particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
						_ = 0;
						_ = 10;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A0]");
						particleSystemConfig._quantity = (int?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-18]");
						particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-8]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+38]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-80]");
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-70]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-60]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+48]");
						particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+58]");
						_ = 0;
						particleSystemConfig._on = false;
						EmitZone emitZone = new EmitZone();
						emitZone._type = EmitZoneType.Random;
						emitZone._source = circle;
						particleSystemConfig._emitZone = emitZone;
						TemporaryEffect rapidFireEffect2 = _rapidFireEffect;
						if ((object)controller != null)
						{
							Transform transform = controller.transform;
							ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, transform, "RAPIDFIRE_PFX");
							if (_rapidFireEffect != null)
							{
								rapidFireEffect2.ParticleSystem = particleSystem;
								TemporaryEffect rapidFireEffect3 = _rapidFireEffect;
								if (_rapidFireEffect != null && (object)controller != null)
								{
									int depth = controller.depth;
									int depth2 = depth - 1;
									RenderingExtensions.SetDepth(rapidFireEffect3.ParticleSystem, depth2);
									TemporaryEffect rapidFireEffect4 = _rapidFireEffect;
									if (_rapidFireEffect != null && (object)rapidFireEffect4.ParticleSystem != null)
									{
										Transform transform2 = rapidFireEffect4.ParticleSystem.transform;
										if ((object)transform2 != null)
										{
											bool flag = (object)((ParticleSystemConfig)(object)transform2)._x == null;
											nint num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1503 @ rcx_v48 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Transform.SetParent_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, (IntPtr)0, true);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void AddActiveRapidFire(float cooldownChange, float speedChange, float duration)
	{
		//IL_00ed: Expected I, but got O
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		CS_0024_003C_003E8__locals17.cooldownChange = cooldownChange;
		CS_0024_003C_003E8__locals17.speedChange = speedChange;
		if (_rapidFireEffect == null)
		{
			InitRapidFireEffect();
		}
		TemporaryEffect rapidFireEffect = _rapidFireEffect;
		RapidFire_Life = 0f;
		if (rapidFireEffect.Tween != null)
		{
			rapidFireEffect.Tween.Kill();
		}
		TemporaryEffect rapidFireEffect2 = _rapidFireEffect;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"RapidFire_Life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = duration;
			tweenConfig.ease = Ease.Linear;
			TweenCallback onUpdate = delegate
			{
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0033: Expected O, but got Unknown
				//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d6: Expected I4, but got Unknown
				CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals17._003C_003E4__this;
				TemporaryEffect rapidFireEffect3 = characterController_Support._rapidFireEffect;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj2 = rapidFireEffect3.Actives - characterController_Support;
				CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				TemporaryEffect rapidFireEffect4 = characterController_Support2._rapidFireEffect;
				int depth = characterController_Support2.controller.depth;
				int depth2 = depth - 1;
				RenderingExtensions.SetDepth(rapidFireEffect4.ParticleSystem, depth2);
				CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				TemporaryEffect rapidFireEffect5 = characterController_Support3._rapidFireEffect;
				CharacterController_Support characterController_Support4 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				float2 position = characterController_Support4.controller.position;
				int count = obj2 + 11;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(rapidFireEffect5.ParticleSystem, pos, count);
			};
			tweenConfig.onUpdate = onUpdate;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			rapidFireEffect2.Tween = tween;
			Action action = delegate
			{
				CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals17._003C_003E4__this;
				TemporaryEffect rapidFireEffect3 = characterController_Support._rapidFireEffect;
				int actives = rapidFireEffect3.Actives + 1;
				rapidFireEffect3.Actives = actives;
				CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				CharacterController characterController = characterController_Support2.controller;
				PlayerModifierStats playerStats = characterController._playerStats;
				EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat2 = new EggFloat(value2, eggFloat._eggVal);
				value2 = eggFloat._val + CS_0024_003C_003E8__locals17.cooldownChange;
				playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
				CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				CharacterController characterController2 = characterController_Support3.controller;
				PlayerModifierStats playerStats2 = characterController2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CSpeed_003Ek__BackingField;
				float value3 = default(float);
				EggFloat eggFloat4 = new EggFloat(value3, eggFloat3._eggVal);
				value3 = eggFloat3._val + CS_0024_003C_003E8__locals17.speedChange;
				playerStats2._003CSpeed_003Ek__BackingField = eggFloat4;
			};
			Action onComplete = delegate
			{
				CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals17._003C_003E4__this;
				TemporaryEffect rapidFireEffect3 = characterController_Support._rapidFireEffect;
				int actives = rapidFireEffect3.Actives - 1;
				rapidFireEffect3.Actives = actives;
				CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				CharacterController characterController = characterController_Support2.controller;
				PlayerModifierStats playerStats = characterController._playerStats;
				EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
				float value2 = default(float);
				EggFloat eggFloat2 = new EggFloat(value2, eggFloat._eggVal);
				value2 = eggFloat._val - CS_0024_003C_003E8__locals17.cooldownChange;
				playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
				CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
				CharacterController characterController2 = characterController_Support3.controller;
				PlayerModifierStats playerStats2 = characterController2._playerStats;
				EggFloat eggFloat3 = playerStats2._003CSpeed_003Ek__BackingField;
				float value3 = default(float);
				EggFloat eggFloat4 = new EggFloat(value3, eggFloat3._eggVal);
				value3 = eggFloat3._val - CS_0024_003C_003E8__locals17.speedChange;
				playerStats2._003CSpeed_003Ek__BackingField = eggFloat4;
			};
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v703.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			float duration2 = duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void InitHeartRefreshEffect()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0217: Expected O, but got Ref
		//IL_0231: Expected native int or pointer, but got O
		//IL_024b: Expected O, but got I
		//IL_026b: Expected O, but got Ref
		//IL_0285: Expected native int or pointer, but got O
		//IL_0607: Expected O, but got I4
		//IL_029d: Expected O, but got Ref
		//IL_02c4: Expected O, but got I
		//IL_02de: Expected native int or pointer, but got O
		//IL_02f8: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_0332: Expected native int or pointer, but got O
		//IL_0624: Expected O, but got I4
		//IL_034a: Expected O, but got Ref
		//IL_0364: Expected native int or pointer, but got O
		//IL_064e: Expected O, but got I
		//IL_039c: Expected O, but got Ref
		//IL_03b1: Expected native int or pointer, but got O
		//IL_03cb: Expected O, but got I
		//IL_06b5: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		TemporaryEffect heartRefreshEffect = new TemporaryEffect();
		_heartRefreshEffect = heartRefreshEffect;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"vfxHeartMini");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxHoly1");
					}
					else
					{
						int size2 = list._size + 1;
						list._size = size2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					if (particleSystemConfig != null)
					{
						particleSystemConfig._frame = list;
						ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 180f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-58]");
						particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-48]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(5f, 20f));
						particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
						ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
						_ = 0;
						_ = 10;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+A0]");
						particleSystemConfig._quantity = (int?)(object)0;
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(100f, 400f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-18]");
						particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-8]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
						particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
						ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+38]");
						_ = 0;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-80]");
						particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-70]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-60]");
						_ = 0;
						ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
						_ = 0;
						_ = 0;
						System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-1000f));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+48]");
						particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+58]");
						_ = 0;
						particleSystemConfig._on = false;
						EmitZone emitZone = new EmitZone();
						emitZone._type = EmitZoneType.Random;
						emitZone._source = circle;
						particleSystemConfig._emitZone = emitZone;
						TemporaryEffect heartRefreshEffect2 = _heartRefreshEffect;
						if ((object)controller != null)
						{
							Transform transform = controller.transform;
							ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, transform, "_heartRefreshEffect_PFX");
							if (_heartRefreshEffect != null)
							{
								heartRefreshEffect2.ParticleSystem = particleSystem;
								TemporaryEffect heartRefreshEffect3 = _heartRefreshEffect;
								if (_heartRefreshEffect != null && (object)controller != null)
								{
									int depth = controller.depth;
									int depth2 = depth - 1;
									RenderingExtensions.SetDepth(heartRefreshEffect3.ParticleSystem, depth2);
									TemporaryEffect heartRefreshEffect4 = _heartRefreshEffect;
									if (_heartRefreshEffect != null && (object)heartRefreshEffect4.ParticleSystem != null)
									{
										Transform transform2 = heartRefreshEffect4.ParticleSystem.transform;
										if ((object)transform2 != null)
										{
											bool flag = (object)((ParticleSystemConfig)(object)transform2)._x == null;
											nint num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1503 @ rcx_v48 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Transform.SetParent_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, (IntPtr)0, true);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void AddActiveHeartRefresh(float statChange1, float statChange2, float duration)
	{
		//IL_0320: Expected F4, but got O
		//IL_0628: Expected F4, but got I4
		//IL_035f->IL0514: Incompatible stack heights: 1 vs 0
		//IL_03a7->IL0514: Incompatible stack heights: 1 vs 0
		//IL_062d->IL0269: Incompatible stack heights: 3 vs 0
		//IL_044b->IL0514: Incompatible stack heights: 1 vs 0
		//IL_04a6->IL0514: Incompatible stack heights: 1 vs 0
		//IL_04c3->IL0514: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass16_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			float statChange3 = default(float);
			CS_0024_003C_003E8__locals13.statChange1 = statChange3;
			if (_heartRefreshEffect == null)
			{
				InitHeartRefreshEffect();
			}
			HeartRefreshVFX lastHeartRefreshVFX = _lastHeartRefreshVFX;
			if ((object)_lastHeartRefreshVFX == null || ((UnityEngine.Object)lastHeartRefreshVFX).m_CachedPtr == (IntPtr)0)
			{
				goto IL_0565;
			}
			if ((object)_lastHeartRefreshVFX != null)
			{
				GameObject gameObject = _lastHeartRefreshVFX.gameObject;
				if ((object)gameObject != null)
				{
					bool activeSelf = gameObject.activeSelf;
					float num = duration;
					if (activeSelf)
					{
						goto IL_0269;
					}
					goto IL_0565;
				}
			}
		}
		goto IL_0514;
		IL_0269:
		TemporaryEffect heartRefreshEffect = _heartRefreshEffect;
		HeartRefresh_Life = 0f;
		Vector3 ret = default(Vector3);
		if (_heartRefreshEffect != null)
		{
			if (heartRefreshEffect.Tween != null)
			{
				heartRefreshEffect.Tween.Kill();
			}
			Transform heartRefreshEffect2 = (Transform)(object)_heartRefreshEffect;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				Transform transform = RenderingExtensions.SetScale((Transform)(object)this, (float)ret);
				bool flag = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					Dictionary<string, object> dictionary = new Dictionary<string, object>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					if (dictionary != null)
					{
						object value = default(object);
						bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"HeartRefresh_Life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						tweenConfig.custom = dictionary;
						tweenConfig.duration = duration;
						tweenConfig.ease = Ease.Linear;
						TweenCallback onUpdate = delegate
						{
							//IL_002e: Unknown result type (might be due to invalid IL or missing references)
							//IL_0033: Expected O, but got Unknown
							//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00d6: Expected I4, but got Unknown
							CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals13._003C_003E4__this;
							TemporaryEffect heartRefreshEffect3 = characterController_Support._heartRefreshEffect;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
							object obj2 = heartRefreshEffect3.Actives - characterController_Support;
							CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
							TemporaryEffect heartRefreshEffect4 = characterController_Support2._heartRefreshEffect;
							int depth = characterController_Support2.controller.depth;
							int depth2 = depth - 1;
							RenderingExtensions.SetDepth(heartRefreshEffect4.ParticleSystem, depth2);
							CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals13._003C_003E4__this;
							TemporaryEffect heartRefreshEffect5 = characterController_Support3._heartRefreshEffect;
							CharacterController_Support characterController_Support4 = CS_0024_003C_003E8__locals13._003C_003E4__this;
							float2 position = characterController_Support4.controller.position;
							int count = obj2 + 11;
							Vector2 pos = default(Vector2);
							RenderingExtensions.EmitParticleAt(heartRefreshEffect5.ParticleSystem, pos, count);
						};
						tweenConfig.onUpdate = onUpdate;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						if (_heartRefreshEffect != null)
						{
							Action action = delegate
							{
								CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals13._003C_003E4__this;
								TemporaryEffect heartRefreshEffect3 = characterController_Support._heartRefreshEffect;
								int actives = heartRefreshEffect3.Actives + 1;
								heartRefreshEffect3.Actives = actives;
								CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
								CharacterController characterController = characterController_Support2.controller;
								PlayerModifierStats playerStats = characterController._playerStats;
								EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
								float value3 = default(float);
								EggFloat eggFloat2 = new EggFloat(value3, eggFloat._eggVal);
								value3 = eggFloat._val + CS_0024_003C_003E8__locals13.statChange1;
								playerStats._003CRegen_003Ek__BackingField = eggFloat2;
							};
							Action onComplete = delegate
							{
								CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals13._003C_003E4__this;
								TemporaryEffect heartRefreshEffect3 = characterController_Support._heartRefreshEffect;
								int actives = heartRefreshEffect3.Actives - 1;
								heartRefreshEffect3.Actives = actives;
								CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
								CharacterController characterController = characterController_Support2.controller;
								PlayerModifierStats playerStats = characterController._playerStats;
								EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
								float value3 = default(float);
								EggFloat eggFloat2 = new EggFloat(value3, eggFloat._eggVal);
								value3 = eggFloat._val - CS_0024_003C_003E8__locals13.statChange1;
								playerStats._003CRegen_003Ek__BackingField = eggFloat2;
							};
							if ((object)controller != null && action != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1493.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								float duration2 = duration * 0.001f;
								bool useRealTime = default(bool);
								MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0514;
		IL_0514:
		throw new NullReferenceException();
		IL_0565:
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.HeartRefresh);
			if ((object)pool != null)
			{
				HeartRefreshVFX objectComponent = pool.GetObjectComponent<HeartRefreshVFX>();
				if ((object)objectComponent != null)
				{
					Transform transform2 = objectComponent.transform;
					if ((object)controller != null)
					{
						Transform transform3 = controller.transform;
						if ((object)transform2 != null)
						{
							transform2.SetParent(transform3, worldPositionStays: true);
							Transform transform4 = objectComponent.transform;
							Transform transform5 = RenderingExtensions.SetScale(transform4, 2f);
							Transform transform6 = objectComponent.transform;
							if ((object)controller != null)
							{
								Transform transform7 = controller.transform;
								if ((object)transform7 != null)
								{
									bool flag3 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out ret);
									object obj = default(object);
									float num2 = (float)obj + 1f;
									bool flag4 = (object)transform6 == null;
									bool flag5 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
									Vector3 value2 = default(Vector3);
									Transform.set_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value2);
									objectComponent.PlaySequence();
									_lastHeartRefreshVFX = objectComponent;
									float num = 0f;
									goto IL_0269;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0514;
	}

	public void AddKarmaCoin()
	{
		int karmaCoinCount = _karmaCoinCount + 1;
		_karmaCoinCount = karmaCoinCount;
	}

	private void ActivateKarmaCoin(float pLuck)
	{
		//IL_01e5->IL021f: Incompatible stack heights: 3 vs 0
		KarmaCoinVFX lastKarmaCoinVFX = _lastKarmaCoinVFX;
		if ((object)_lastKarmaCoinVFX != null && ((UnityEngine.Object)lastKarmaCoinVFX).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_lastKarmaCoinVFX != null)
			{
				GameObject gameObject = _lastKarmaCoinVFX.gameObject;
				if ((object)gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						goto IL_0220;
					}
					return;
				}
			}
			goto IL_01e5;
		}
		goto IL_0220;
		IL_0220:
		if ((object)HeroVfxManager._factory != null)
		{
			ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.KarmaCoin);
			if ((object)pool != null)
			{
				KarmaCoinVFX objectComponent = pool.GetObjectComponent<KarmaCoinVFX>();
				if ((object)objectComponent != null)
				{
					Transform transform = objectComponent.transform;
					if ((object)controller != null)
					{
						Transform transform2 = controller.transform;
						if ((object)transform != null)
						{
							transform.SetParent(transform2, worldPositionStays: true);
							Transform transform3 = objectComponent.transform;
							if ((object)controller != null)
							{
								Transform transform4 = controller.transform;
								if ((object)transform4 != null)
								{
									bool flag = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out Vector3 _);
									bool flag2 = (object)transform3 == null;
									bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
									Action action = ApplyKarmaCoinEffect;
									objectComponent.PlaySequence(action, pLuck);
									_lastKarmaCoinVFX = objectComponent;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_01e5;
		IL_01e5:
		throw new NullReferenceException();
	}

	private void ApplyKarmaCoinEffect()
	{
		CharacterController characterController = controller;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(WeaponType.TP_SOULSTEAL_PICKUP, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			weaponByType.Fire(skipTriggers: true);
			return;
		}
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD570");
	}

	private unsafe void InitMirrorOfTruthEffect()
	{
		//IL_0008: Expected O, but got Ref
		//IL_013e: Expected O, but got Ref
		//IL_0158: Expected native int or pointer, but got O
		//IL_0172: Expected O, but got I
		//IL_0192: Expected O, but got Ref
		//IL_01ac: Expected native int or pointer, but got O
		//IL_01c6: Expected O, but got I
		//IL_01e6: Expected O, but got Ref
		//IL_020d: Expected O, but got I
		//IL_0227: Expected native int or pointer, but got O
		//IL_0241: Expected O, but got I
		//IL_0261: Expected O, but got Ref
		//IL_027b: Expected native int or pointer, but got O
		//IL_04e8: Expected O, but got I4
		//IL_028e: Expected native int or pointer, but got O
		//IL_0298: Expected native int or pointer, but got O
		//IL_0505: Expected O, but got I4
		//IL_02ea: Expected O, but got I
		//IL_054a: Expected I, but got O
		//IL_056e->IL04bb: Incompatible stack heights: 1 vs 0
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
		TemporaryEffect mirrorOfTruthEffect = new TemporaryEffect();
		_mirrorOfTruthEffect = mirrorOfTruthEffect;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
		List<string> list = new List<string>();
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"TP_VFX_Neutron04");
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				if (particleSystemConfig != null)
				{
					particleSystemConfig._frame = list;
					ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 128));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-80]");
					particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-70]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 96));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 360f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-60]");
					particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-50]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 64));
					_ = 0;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+40]");
					particleSystemConfig._quantity = (int?)(object)0;
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(16f, 32f));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-40]");
					particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)-30]");
					_ = 0;
					ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref minMaxCurve2, 32));
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
					particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
					((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_Mode = ParticleSystemCurveMode.Constant;
					System.Runtime.CompilerServices.Unsafe.Write(&((ParticleSystem.MinMaxCurve*)(nint)minMaxCurve)->m_CurveMax, null);
					minMaxCurve2 = new ParticleSystem.MinMaxCurve(0.5f, 0.6f);
					particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
					_ = 0;
					particleSystemConfig._on = false;
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1 (UnityEngine.ParticleSystem+MinMaxCurve)+40]");
					particleSystemConfig._blendMode = (BlendMode?)(object)0;
					TemporaryEffect mirrorOfTruthEffect2 = _mirrorOfTruthEffect;
					if ((object)controller != null)
					{
						Transform transform = controller.transform;
						ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, transform, "_mirrorOfTruthEffect_PFX");
						if (_mirrorOfTruthEffect != null)
						{
							mirrorOfTruthEffect2.ParticleSystem = particleSystem;
							TemporaryEffect mirrorOfTruthEffect3 = _mirrorOfTruthEffect;
							if (_mirrorOfTruthEffect != null && (object)controller != null)
							{
								int depth = controller.depth;
								int depth2 = depth - 1;
								RenderingExtensions.SetDepth(mirrorOfTruthEffect3.ParticleSystem, depth2);
								TemporaryEffect mirrorOfTruthEffect4 = _mirrorOfTruthEffect;
								if (_mirrorOfTruthEffect != null && (object)mirrorOfTruthEffect4.ParticleSystem != null)
								{
									Transform transform2 = mirrorOfTruthEffect4.ParticleSystem.transform;
									if ((object)transform2 != null)
									{
										bool flag = (object)((ParticleSystemConfig)(object)transform2)._x == null;
										nint num = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1206 @ rcx_v38 (Il2CppMethodInfo)+38]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
										}
										Transform.SetParent_Injected((IntPtr)((ParticleSystemConfig)(object)transform2)._x, (IntPtr)0, true);
										List<float> list2 = new List<float>();
										if (_mirrorOfTruthEffect != null)
										{
											return;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void AddActiveMirrorOfTruth(float statChange1, float statChange2, float duration)
	{
		//IL_009b: Expected O, but got I4
		//IL_0118: Expected I, but got O
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Expected O, but got Unknown
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals18._003C_003E4__this = this;
		if (_mirrorOfTruthEffect == null)
		{
			InitMirrorOfTruthEffect();
		}
		ArcadeSprite arcadeSprite = controller;
		MirrorOfTruth_Life = 0f;
		((ArcadeSprite)controller).CheckRenderer();
		Vector2 size = arcadeSprite._spriteRenderer.size;
		object obj = default(object);
		float num = (float)obj * 0.65f;
		CS_0024_003C_003E8__locals18.offset = (float2)0;
		TemporaryEffect mirrorOfTruthEffect = _mirrorOfTruthEffect;
		if (mirrorOfTruthEffect.Tween != null)
		{
			mirrorOfTruthEffect.Tween.Kill();
		}
		TemporaryEffect mirrorOfTruthEffect2 = _mirrorOfTruthEffect;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		float num3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"MirrorOfTruth_Life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			tweenConfig.duration = duration;
			tweenConfig.ease = Ease.Linear;
			TweenCallback onUpdate = delegate
			{
				//IL_0076: Unknown result type (might be due to invalid IL or missing references)
				//IL_007b: Expected O, but got Unknown
				//IL_0119: Unknown result type (might be due to invalid IL or missing references)
				//IL_011e: Expected I4, but got Unknown
				GameManager core = GM.Core;
				PlayerOptionsData config = core._playerOptions.Config;
				if (config._003CFlashingVFXEnabled_003Ek__BackingField)
				{
					CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals18._003C_003E4__this;
					TemporaryEffect mirrorOfTruthEffect3 = characterController_Support._mirrorOfTruthEffect;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
					object obj5 = mirrorOfTruthEffect3.Actives - characterController_Support;
					CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals18._003C_003E4__this;
					TemporaryEffect mirrorOfTruthEffect4 = characterController_Support2._mirrorOfTruthEffect;
					int depth = characterController_Support2.controller.depth;
					int depth2 = depth - 1;
					RenderingExtensions.SetDepth(mirrorOfTruthEffect4.ParticleSystem, depth2);
					CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals18._003C_003E4__this;
					TemporaryEffect mirrorOfTruthEffect5 = characterController_Support3._mirrorOfTruthEffect;
					CharacterController_Support characterController_Support4 = CS_0024_003C_003E8__locals18._003C_003E4__this;
					float2 position = characterController_Support4.controller.position;
					int count = obj5 + 11;
					Vector2 pos = default(Vector2);
					RenderingExtensions.EmitParticleAt(mirrorOfTruthEffect5.ParticleSystem, pos, count);
				}
			};
			tweenConfig.onUpdate = onUpdate;
			MultiTargetTween tween = Tweens.Add(tweenConfig);
			mirrorOfTruthEffect2.Tween = tween;
			CharacterController characterController = controller;
			PlayerModifierStats playerStats = characterController._playerStats;
			EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
			num3 = eggFloat._eggVal + eggFloat._val;
			object obj3 = num3 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num3 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D4D3Ah\"");
					if (num3 == -1f / 0f)
					{
						num3 = -3.4028235E+38f;
					}
					goto IL_03b6;
				}
			}
			num3 = 3.4028235E+38f;
			goto IL_03b6;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
		IL_03b6:
		bool flag2 = statChange1 > num3;
		float num4 = statChange1;
		if (!flag2)
		{
			num4 = num3;
		}
		bool flag3 = num4 > 16f;
		float amount = 16f;
		if (!flag3)
		{
			amount = num4;
		}
		CS_0024_003C_003E8__locals18._amount = amount;
		Action action = delegate
		{
			//IL_0116: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_0182: Expected O, but got I
			CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals18._003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect3 = characterController_Support._mirrorOfTruthEffect;
			int actives = mirrorOfTruthEffect3.Actives + 1;
			mirrorOfTruthEffect3.Actives = actives;
			CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals18._003C_003E4__this;
			CharacterController characterController2 = characterController_Support2.controller;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			EggFloat eggFloat2 = playerStats2._003CAmount_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat3 = new EggFloat(value2, eggFloat2._eggVal);
			value2 = eggFloat2._val + CS_0024_003C_003E8__locals18._amount;
			playerStats2._003CAmount_003Ek__BackingField = eggFloat3;
			CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals18._003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect4 = characterController_Support3._mirrorOfTruthEffect;
			List<float> activeValueChanges = mirrorOfTruthEffect4.ActiveValueChanges;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v4+18]");
			if (num5 >= 0)
			{
				activeValueChanges.AddWithResize(CS_0024_003C_003E8__locals18._amount);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v11 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj7 = (nint)0 + (nint)1;
				_ = CS_0024_003C_003E8__locals18._amount;
			}
		};
		Action action2 = delegate
		{
			//IL_00bb: Expected O, but got I
			//IL_00f2: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_01c4: Expected O, but got I
			CharacterController_Support characterController_Support = CS_0024_003C_003E8__locals18._003C_003E4__this;
			TemporaryEffect mirrorOfTruthEffect3 = characterController_Support._mirrorOfTruthEffect;
			int actives = mirrorOfTruthEffect3.Actives - 1;
			mirrorOfTruthEffect3.Actives = actives;
			CharacterController_Support characterController_Support2 = CS_0024_003C_003E8__locals18._003C_003E4__this;
			CharacterController characterController2 = characterController_Support2.controller;
			PlayerModifierStats playerStats2 = characterController2._playerStats;
			CharacterController_Support characterController_Support3 = CS_0024_003C_003E8__locals18._003C_003E4__this;
			EggFloat eggFloat2 = playerStats2._003CAmount_003Ek__BackingField;
			TemporaryEffect mirrorOfTruthEffect4 = characterController_Support3._mirrorOfTruthEffect;
			List<float> activeValueChanges = mirrorOfTruthEffect4.ActiveValueChanges;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj5 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)obj5 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v9 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj7 = -1;
				float value2 = default(float);
				EggFloat eggFloat3 = new EggFloat(value2, eggFloat2._eggVal);
				float num5 = eggFloat2._val;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v9+20+v242 @ rax_v11*4]");
				value2 = num5 - 0f;
				playerStats2._003CAmount_003Ek__BackingField = eggFloat3;
				CharacterController_Support characterController_Support4 = CS_0024_003C_003E8__locals18._003C_003E4__this;
				TemporaryEffect mirrorOfTruthEffect5 = characterController_Support4._mirrorOfTruthEffect;
				TemporaryEffect mirrorOfTruthEffect6 = characterController_Support4._mirrorOfTruthEffect;
				List<float> activeValueChanges2 = mirrorOfTruthEffect5.ActiveValueChanges;
				List<float> activeValueChanges3 = mirrorOfTruthEffect6.ActiveValueChanges;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rax_v17 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj8 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)obj8 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
					_ = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdx_v8 (System.Collections.Generic.List`1<System.Single>)+1C]");
					_ = (nint)0 + (nint)1;
					return;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		};
		action2._002Ector(CS_0024_003C_003E8__locals18, (nint)__ldftn(_003C_003Ec__DisplayClass21_0._003CAddActiveMirrorOfTruth_003Eb__1));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v868.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		float duration2 = duration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}
}
