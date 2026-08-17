using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_Passive_GuardianAura : CharacterSkillCard_Base
{
	private List<CharacterController> _charactersAffectedByAura;

	private ParticleSystem _guardianParticleSystem;

	private float _timer;

	public SubSkillCard_Passive_GuardianAura(ArcanaType type)
		: base(type)
	{
	}

	public unsafe override void InitialActivate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0074: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_01b5: Expected O, but got I
		//IL_022f: Expected O, but got I
		//IL_0280: Expected O, but got Ref
		//IL_0295: Expected native int or pointer, but got O
		//IL_02af: Expected O, but got I
		//IL_02cf: Expected O, but got Ref
		//IL_02e9: Expected native int or pointer, but got O
		//IL_0303: Expected O, but got I
		//IL_0323: Expected O, but got Ref
		//IL_033d: Expected native int or pointer, but got O
		//IL_0357: Expected O, but got I
		//IL_0377: Expected O, but got Ref
		//IL_0391: Expected native int or pointer, but got O
		//IL_0536: Expected O, but got I4
		//IL_03a9: Expected O, but got Ref
		//IL_03d0: Expected O, but got I
		//IL_03ea: Expected native int or pointer, but got O
		//IL_0553: Expected O, but got I4
		//IL_040f: Expected O, but got Ref
		//IL_0436: Expected O, but got I
		//IL_0450: Expected native int or pointer, but got O
		//IL_0585: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitialActivate();
		if ((object)LinkedCharacter != null)
		{
			GameObject gameObject = LinkedCharacter.gameObject;
			_ = 0;
			UnityEngine.Object obj3;
			if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
				obj3 = (UnityEngine.Object)0;
			}
			else
			{
				ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
				obj3 = particleEmitterManager;
			}
			if ((object)obj3 != null)
			{
				obj3.SetName("SubSkillCard_Passive_GuardianAura VFX");
				ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("items");
				List<string> list = new List<string>();
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v21+18]");
						if (num >= 0)
						{
							((List<object>)(object)list).AddWithResize((object)"ArmorIron");
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+18]");
							object obj5 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v23+18]");
							if (num2 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"HeartRuby");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rax_v21 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj7 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							if (particleSystemConfig != null)
							{
								particleSystemConfig._frame = list;
								ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
								particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
								particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-90f, -90f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
								particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
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
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
								particleSystemConfig._quantity = (int?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
								_ = 0;
								particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
								_ = 0;
								ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
								_ = 0;
								_ = 1065353216;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
								particleSystemConfig._frequency = (float?)(object)0;
								_ = 0;
								_ = 0;
								System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
								particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
								_ = 0;
								particleSystemConfig._on = false;
								ParticleSystem particleSystem = ((ParticleEmitterManager)obj3).CreateEmitter(particleSystemConfig, (Transform)null, "PfxEmitter");
								Transform transform = particleSystem.transform;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v48 (UnityEngine.Transform)+10]");
								bool flag = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v48 (UnityEngine.Transform)+10]");
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected((IntPtr)0, ref value);
								_guardianParticleSystem = particleSystem;
								List<CharacterController> charactersAffectedByAura = new List<CharacterController>();
								_charactersAffectedByAura = charactersAffectedByAura;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Update()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_00e7: Expected I4, but got O
		//IL_05e8: Expected I4, but got O
		//IL_02f3: Expected O, but got I4
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_02e0: Expected I, but got O
		//IL_0414: Expected I4, but got O
		//IL_0485: Expected I4, but got I8
		//IL_0485: Expected O, but got F4
		//IL_0493: Expected I, but got I8
		base.Update();
		float deltaTime = PauseSystem.DeltaTime;
		float timer = deltaTime + _timer;
		_timer = timer;
		GameManager core = GM.Core;
		object obj = 0;
		object obj2 = 0;
		object obj6 = default(object);
		object obj7 = default(object);
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
				if ((object)items[obj2] != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
				{
					bool flag = (byte)(int)LinkedCharacter != 0;
					bool flag2;
					if ((int)(~LinkedCharacter) == 0)
					{
						object obj3 = (object)items[obj2] - (object)LinkedCharacter;
						flag2 = obj3 == null;
					}
					else
					{
						flag2 = ((UnityEngine.Object)characterController).m_CachedPtr == (IntPtr)0;
					}
					if (!flag2)
					{
						CharacterController linkedCharacter = LinkedCharacter;
						if (linkedCharacter._isDead == flag2)
						{
							bool isDisconnectedFromOnlinePlay = linkedCharacter.IsDisconnectedFromOnlinePlay;
							if (!isDisconnectedFromOnlinePlay && characterController._isDead == isDisconnectedFromOnlinePlay && !items[obj2].IsDisconnectedFromOnlinePlay)
							{
								float2 cachedPosition = items[obj2].cachedPosition;
								float2 cachedPosition2 = LinkedCharacter.cachedPosition;
								object obj4 = cachedPosition2 - cachedPosition;
								object obj5 = obj6 - obj7;
								object obj8 = obj4 * obj4;
								timer = (float)obj5 * (float)obj5;
								float num = (float)obj8 + timer;
								bool flag3 = 1f < num;
								flag = !flag3;
								bool flag4 = _charactersAffectedByAura.Remove(items[obj2]);
								nint num2;
								if (flag && !flag4)
								{
									ApplyAuraToPlayer(items[obj2]);
									bool flag5 = _charactersAffectedByAura.Remove(items[obj2]);
									num2 = unchecked((nint)null);
								}
								else
								{
									object obj9 = (flag ? 1 : 0) ^ 1;
									object obj10 = flag4 & obj9;
									if (obj10 != null)
									{
										RemoveAuraFromPlayer(items[obj2]);
										bool flag6 = ((List<object>)(object)_charactersAffectedByAura).Remove((object)items[obj2]);
										num3 = 0;
									}
									bool flag7 = !flag;
									num2 = num3;
									if (flag7)
									{
										goto IL_0514;
									}
								}
								bool flag8 = characterController._isDead;
								num3 = num2;
								if (!flag8)
								{
									bool isDisconnectedFromOnlinePlay2 = items[obj2].IsDisconnectedFromOnlinePlay;
									num3 = num2;
									if (!isDisconnectedFromOnlinePlay2)
									{
										timer = _timer;
										bool flag9 = !(_timer > 0.5f);
										num3 = num2;
										if (!flag9)
										{
											flag = (byte)(int)_guardianParticleSystem != 0;
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
								goto IL_0514;
							}
						}
						if (_charactersAffectedByAura.Remove(items[obj2]))
						{
							RemoveAuraFromPlayer(items[obj2]);
							bool flag10 = ((List<object>)(object)_charactersAffectedByAura).Remove((object)items[obj2]);
							num3 = 0;
						}
					}
				}
				goto IL_0514;
			}
			if (_timer > 0.5f)
			{
				_timer = 0f;
			}
			return;
			IL_0514:
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
}
