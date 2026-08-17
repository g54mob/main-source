using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class C1_Guardian : CharacterController
{
	private List<CharacterController> _charactersAffectedByAura;

	private ParticleSystem _guardianParticleSystem;

	private float _timer;

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	public unsafe override void AfterFullInitialization()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007e: Expected O, but got I
		//IL_01f9: Expected O, but got Ref
		//IL_020e: Expected native int or pointer, but got O
		//IL_0228: Expected O, but got I
		//IL_0248: Expected O, but got Ref
		//IL_0262: Expected native int or pointer, but got O
		//IL_027c: Expected O, but got I
		//IL_029c: Expected O, but got Ref
		//IL_02b6: Expected native int or pointer, but got O
		//IL_02d0: Expected O, but got I
		//IL_02f0: Expected O, but got Ref
		//IL_030a: Expected native int or pointer, but got O
		//IL_047f: Expected O, but got I4
		//IL_0322: Expected O, but got Ref
		//IL_0349: Expected O, but got I
		//IL_0363: Expected native int or pointer, but got O
		//IL_049c: Expected O, but got I4
		//IL_0388: Expected O, but got Ref
		//IL_03af: Expected O, but got I
		//IL_03c9: Expected native int or pointer, but got O
		//IL_04ce: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.AfterFullInitialization();
		List<CharacterController> charactersAffectedByAura = new List<CharacterController>();
		_charactersAffectedByAura = charactersAffectedByAura;
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			ParticleEmitterManager particleEmitterManager2 = gameObject.AddComponent<ParticleEmitterManager>();
			particleEmitterManager = particleEmitterManager2;
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ArmorIron");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"HeartRuby");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-48]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-90f, -90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+48]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = particleEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
		Transform transform = particleSystem.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		_guardianParticleSystem = particleSystem;
	}

	protected override void OnUpdate()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Expected O, but got Unknown
		//IL_0286: Expected O, but got I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0273: Expected I, but got O
		//IL_03a7: Expected I4, but got O
		//IL_0418: Expected I4, but got I8
		//IL_0418: Expected O, but got F4
		//IL_0426: Expected I, but got I8
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float timer = deltaTime + _timer;
		_timer = timer;
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		object obj5 = default(object);
		object obj6 = default(object);
		nint num3 = default(nint);
		float num4 = default(float);
		while (true)
		{
			List<CharacterController> characters = core._characters;
			if ((nint)obj < characters._size)
			{
				GameManager core2 = GM.Core;
				List<CharacterController> characters2 = core2._characters;
				if ((nint)obj2 >= characters2._size)
				{
					break;
				}
				CharacterController[] items = characters2._items;
				CharacterController characterController = items[obj2];
				if ((object)items[obj2] != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0 && (object)items[obj2] != this)
				{
					if (!base._isDead)
					{
						bool isDisconnectedFromOnlinePlay = base.IsDisconnectedFromOnlinePlay;
						if (!isDisconnectedFromOnlinePlay && characterController._isDead == isDisconnectedFromOnlinePlay && !items[obj2].IsDisconnectedFromOnlinePlay)
						{
							float2 float5 = items[obj2].cachedPosition;
							float2 float6 = base.cachedPosition;
							object obj3 = float6 - float5;
							object obj4 = obj5 - obj6;
							object obj7 = obj3 * obj3;
							timer = (float)obj4 * (float)obj4;
							float num = (float)obj7 + timer;
							bool flag = 1f < num;
							bool flag2 = !flag;
							bool flag3 = _charactersAffectedByAura.Remove(items[obj2]);
							nint num2;
							if (flag2 && !flag3)
							{
								ApplyAuraToPlayer(items[obj2]);
								bool flag4 = _charactersAffectedByAura.Remove(items[obj2]);
								num2 = unchecked((nint)null);
							}
							else
							{
								object obj8 = (flag2 ? 1 : 0) ^ 1;
								object obj9 = flag3 & obj8;
								if (obj9 != null)
								{
									RemoveAuraFromPlayer(items[obj2]);
									bool flag5 = ((List<object>)(object)_charactersAffectedByAura).Remove((object)items[obj2]);
									num3 = 0;
								}
								bool flag6 = !flag2;
								num2 = num3;
								if (flag6)
								{
									goto IL_04a7;
								}
							}
							bool flag7 = characterController._isDead;
							num3 = num2;
							if (!flag7)
							{
								bool isDisconnectedFromOnlinePlay2 = items[obj2].IsDisconnectedFromOnlinePlay;
								num3 = num2;
								if (!isDisconnectedFromOnlinePlay2)
								{
									timer = _timer;
									bool flag8 = !(_timer > 0.5f);
									num3 = num2;
									if (!flag8)
									{
										flag2 = (byte)(int)_guardianParticleSystem != 0;
										((ArcadeSprite)items[obj2]).CheckRenderer();
										Bounds bounds = ((ArcadeSprite)characterController)._spriteRenderer.bounds;
										((ArcadeSprite)items[obj2]).CheckRenderer();
										Bounds bounds2 = ((ArcadeSprite)characterController)._spriteRenderer.bounds;
										RenderingExtensions.EmitParticleAt(_guardianParticleSystem, (Vector2)num4, -1);
										num3 = unchecked((nint)4294967295L);
										timer = num4;
									}
								}
							}
							goto IL_04a7;
						}
					}
					if (_charactersAffectedByAura.Remove(items[obj2]))
					{
						RemoveAuraFromPlayer(items[obj2]);
						bool flag9 = ((List<object>)(object)_charactersAffectedByAura).Remove((object)items[obj2]);
						num3 = 0;
					}
				}
				goto IL_04a7;
			}
			if (_timer > 0.5f)
			{
				_timer = 0f;
			}
			return;
			IL_04a7:
			obj2++;
			core = GM.Core;
			obj = obj2;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void ApplyAuraToPlayer(CharacterController character)
	{
		PlayerModifierStats playerStats = character._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + 1f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = character._playerStats;
		EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val + 0.3f;
		playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
	}

	private void RemoveAuraFromPlayer(CharacterController character)
	{
		PlayerModifierStats playerStats = character._playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val - 1f;
		playerStats._003CArmor_003Ek__BackingField = eggFloat2;
		PlayerModifierStats playerStats2 = character._playerStats;
		EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
		float value2 = default(float);
		EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
		value2 = eggFloat3._val - 0.3f;
		playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
	}

	public override void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
	{
		//IL_0107: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_011e: Expected O, but got F4
		//IL_0127: Invalid comparison between O and F4
		bool flag = revived._deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = revived._deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = revived._PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null)
		{
			object obj3 = UnityEngine.Random.value;
			object obj4 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
			{
				PlayerModifierStats playerStats = _playerStats;
				EggDouble eggDouble = playerStats._003CRevivals_003Ek__BackingField;
				EggDouble revivals = new EggDouble(eggDouble._val, eggDouble._eggVal);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm7,qword ptr [188A10758h]\"");
				playerStats.Revivals = revivals;
			}
		}
	}

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}
}
