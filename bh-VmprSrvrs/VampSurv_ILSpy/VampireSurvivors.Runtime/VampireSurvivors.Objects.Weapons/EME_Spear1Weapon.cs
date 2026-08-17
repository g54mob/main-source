using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Spear1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public EME_Spear1Weapon _003C_003E4__this;

		public Vector2 pos;

		public Transform target;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass25_1
	{
		public int localIndex;

		public float localAmount;

		public _003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			//IL_0015: Expected O, but got I
			//IL_0421: Expected O, but got I4
			//IL_007b: Expected O, but got I8
			//IL_00ca: Expected O, but got I
			//IL_01d3: Expected O, but got F4
			//IL_0155: Expected O, but got I
			//IL_024e: Expected I, but got O
			//IL_025c: Expected I, but got O
			//IL_026c: Expected O, but got I
			//IL_02ec: Expected O, but got I4
			//IL_02a8: Expected O, but got I
			//IL_02de: Expected O, but got I4
			//IL_03a5: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			_003C_003Ec__DisplayClass25_1 obj2 = this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj2 = (_003C_003Ec__DisplayClass25_1)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v206 @ rax_v9 (should have been resolved before IL gen)");
			int num = localIndex & 1;
			bool flag2 = num == 0;
			object obj3 = !flag2;
			float num2 = 105f;
			if (obj3 == null)
			{
				num2 = 105f * -1f;
			}
			_003C_003Ec__DisplayClass25_0 obj4 = CS_0024_003C_003E8__locals1;
			EME_Spear1Weapon eME_Spear1Weapon = obj4._003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)eME_Spear1Weapon)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v11 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			object obj5 = 0;
			Vector2 vector = characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CFC4Ah\"");
			if ((object)characterController._lastMovementDirection == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CFC4Ah\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v11 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				if ((nint)0 == 0)
				{
					vector = characterController._lastFacingDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v11 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
					obj5 = 0;
				}
			}
			float num3 = num2 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num4 = num3 * (float)vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num5 = num3 * (float)obj5;
			float num6 = num4 - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num7 = num3 * (float)vector;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num8 = num3 * (float)obj5;
			float num9 = num7 + num8;
			float2 position = ((Equipment)eME_Spear1Weapon)._003COwner_003Ek__BackingField.position;
			float num10 = (float)position + num6;
			object obj6 = default(object);
			float num11 = (float)obj6 + num9;
			obj4.pos = (Vector2)num10;
			_003C_003Ec__DisplayClass25_0 obj7 = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass25_0 obj8 = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj7._003C_003E4__this.FireOneProjectile(pos, localIndex, obj8.target);
			Projectile projectile2;
			if ((object)projectile == null)
			{
				projectile2 = null;
				goto IL_04d3;
			}
			nint num12 = (nint)projectile;
			nint num13 = (nint)typeof(EME_SpearProjectile_Stardust);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile_Stardust>)+130]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile_Stardust>)+130]");
			object obj11;
			if (num14 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v45+FFFFFFF8+v445 @ rax_v41*8]");
				if (0 == (nint)typeof(EME_SpearProjectile_Stardust))
				{
					obj11 = 1;
					goto IL_04ac;
				}
			}
			obj11 = 0;
			goto IL_04ac;
			IL_04d3:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				float num15 = localAmount - (float)localIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001874CFF2Ah\"");
				if (num15 == 1f)
				{
					SoundManager.StopSound(SfxType.Sfx_eme_stardust);
					SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
					soundConfig.Rate = 1f;
					soundConfig.Volume = (float?)(object)1;
					float detune = (float)projectile2._indexInWeapon * -5f;
					soundConfig.Detune = detune;
					float time = default(float);
					PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_stardust_long, soundConfig, 50f, 1, time);
				}
			}
			return;
			IL_04ac:
			bool flag3 = obj11 == null;
			projectile2 = null;
			if (!flag3)
			{
				projectile2 = projectile;
			}
			goto IL_04d3;
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals2;

		internal unsafe void _003CFire_FireGlimmerProjectile_003Eb__1()
		{
			//IL_006d: Expected O, but got Ref
			//IL_009f: Expected O, but got I4
			//IL_00b3: Expected F4, but got I4
			//IL_00bc: Expected O, but got I4
			//IL_0257: Expected O, but got I
			//IL_0297: Expected I4, but got O
			//IL_02a5: Expected I, but got O
			//IL_02b5: Expected O, but got I
			//IL_0335: Expected O, but got I4
			//IL_02f1: Expected O, but got I
			//IL_0327: Expected O, but got I4
			//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03de: Expected O, but got Unknown
			//IL_01e5->IL040d: Incompatible stack heights: 1 vs 0
			//IL_0226->IL040d: Incompatible stack heights: 1 vs 0
			//IL_0491->IL040d: Incompatible stack heights: 2 vs 0
			//IL_03f8->IL040d: Incompatible stack heights: 2 vs 0
			//IL_040c->IL04e7: Incompatible stack heights: 2 vs 0
			_003C_003Ec__DisplayClass25_0 obj = CS_0024_003C_003E8__locals2;
			if (CS_0024_003C_003E8__locals2 != null)
			{
				EME_Spear1Weapon eME_Spear1Weapon = obj._003C_003E4__this;
				if ((object)obj._003C_003E4__this != null && (object)eME_Spear1Weapon.TriumvirateContainer != null)
				{
					Vector3 ret = default(Vector3);
					eME_Spear1Weapon.TriumvirateContainer.Rotate((Vector3)(&ret), Space.Self);
					_003C_003Ec__DisplayClass25_0 obj2 = CS_0024_003C_003E8__locals2;
					if (CS_0024_003C_003E8__locals2 != null)
					{
						object obj3 = 0;
						Space space = Space.Self;
						float num = 0f;
						object obj4 = 0;
						IntPtr intPtr = default(IntPtr);
						float num4 = default(float);
						while (true)
						{
							EME_Spear1Weapon eME_Spear1Weapon2 = obj2._003C_003E4__this;
							if ((object)obj2._003C_003E4__this == null)
							{
								break;
							}
							List<Transform> triumvirateSpawnPoints = eME_Spear1Weapon2.TriumvirateSpawnPoints;
							if (eME_Spear1Weapon2.TriumvirateSpawnPoints == null)
							{
								break;
							}
							if ((nint)obj4 >= triumvirateSpawnPoints._size)
							{
								return;
							}
							_003C_003Ec__DisplayClass25_0 obj5 = CS_0024_003C_003E8__locals2;
							if (CS_0024_003C_003E8__locals2 == null)
							{
								break;
							}
							EME_Spear1Weapon eME_Spear1Weapon3 = obj5._003C_003E4__this;
							if ((object)obj5._003C_003E4__this == null)
							{
								break;
							}
							List<Transform> triumvirateSpawnPoints2 = eME_Spear1Weapon3.TriumvirateSpawnPoints;
							if (eME_Spear1Weapon3.TriumvirateSpawnPoints == null)
							{
								break;
							}
							bool flag = (nint)obj3 >= triumvirateSpawnPoints2._size;
							Transform[] items = triumvirateSpawnPoints2._items;
							if (triumvirateSpawnPoints2._items == null)
							{
								break;
							}
							Transform transform = items[obj3];
							_003C_003Ec__DisplayClass25_0 obj6 = CS_0024_003C_003E8__locals2;
							if ((object)items[obj3] == null)
							{
								break;
							}
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
							_003C_003Ec__DisplayClass25_0 obj7 = CS_0024_003C_003E8__locals2;
							if (CS_0024_003C_003E8__locals2 == null)
							{
								break;
							}
							EME_SpearProjectile eME_SpearProjectile = (EME_SpearProjectile)obj6._003C_003E4__this.FireOneProjectile((Vector2)(nint)intPtr, localIndex, obj7.target);
							EME_SpearProjectile eME_SpearProjectile2;
							if ((object)eME_SpearProjectile == null)
							{
								eME_SpearProjectile2 = null;
								space = (Space)localIndex;
								goto IL_04c2;
							}
							space = (Space)eME_SpearProjectile;
							nint num2 = (nint)typeof(EME_SpearProjectile_Triumvirate);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile_Triumvirate>)+130]");
							object obj8 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v7 (UnityEngine.Space)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_SpearProjectile_Triumvirate>)+130]");
							object obj10;
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r8_v7 (UnityEngine.Space)+C8]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ rax_v51+FFFFFFF8+v626 @ rax_v47*8]");
								if (0 == (nint)typeof(EME_SpearProjectile_Triumvirate))
								{
									obj10 = 1;
									goto IL_049b;
								}
							}
							obj10 = 0;
							goto IL_049b;
							IL_04c2:
							bool flag3 = (object)eME_SpearProjectile2 == null;
							num = num4;
							if (!flag3)
							{
								bool flag4 = ((UnityEngine.Object)eME_SpearProjectile2).m_CachedPtr == (IntPtr)0;
								num = num4;
								if (!flag4)
								{
									num = items[obj3].eulerAngles.z * ((float)Math.PI / 180f);
									eME_SpearProjectile2.SetVelocityForTriumvirate(num);
									space = Space.World;
								}
							}
							obj2 = CS_0024_003C_003E8__locals2;
							obj3++;
							if (CS_0024_003C_003E8__locals2 == null)
							{
								break;
							}
							obj4 = obj3;
							continue;
							IL_049b:
							bool flag5 = obj10 == null;
							eME_SpearProjectile2 = null;
							if (!flag5)
							{
								eME_SpearProjectile2 = eME_SpearProjectile;
							}
							goto IL_04c2;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	protected Transform TriumvirateContainer;

	protected List<Transform> TriumvirateSpawnPoints;

	private Vector2 _003CCachedPlayerDirection_003Ek__BackingField;

	private const float BaseOffsetY = 0.16f;

	private List<float> _basicAttackRepeatOffsets;

	private const float StardustOffsetAngleMin = 105f;

	private const float StardustOffsetAngleMax = 170f;

	private Timer _glimmerShotTimer;

	protected override int EvolutionLevel => 6;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 6;

	protected override int _comboIndex3 => 9;

	protected override int ComboIndexFinal => base.ComboIndex1;

	public Vector2 CachedPlayerDirection
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			_003CCachedPlayerDirection_003Ek__BackingField = value;
		}
	}

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = level - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				if ((nint)obj3 != 1)
				{
					return WeaponType.VOID;
				}
				return WeaponType.EME_SPEAR_TECH_03;
			}
			return WeaponType.EME_SPEAR_TECH_02;
		}
		return WeaponType.EME_SPEAR_TECH_01;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		if (index == 0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			_003CCachedPlayerDirection_003Ek__BackingField = characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ rax_v7 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			_ = 0;
			BulletPool glimmerBulletPool = base.GetGlimmerBulletPool(_fireCounter, out var _);
			if (glimmerBulletPool == _glimmer1Pool)
			{
				return;
			}
		}
		float basicProjectileOffset = GetBasicProjectileOffset(index);
		Vector2 basicProjectilePosition = GetBasicProjectilePosition(basicProjectileOffset);
		Projectile projectile = base.FireOneProjectile(basicProjectilePosition, index, target);
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_04b7: Expected I4, but got O
		//IL_00e9: Invalid comparison between F4 and I4
		//IL_00ff: Expected I4, but got O
		//IL_0108: Expected O, but got I4
		//IL_02be: Expected I, but got O
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_019e: Expected I, but got O
		//IL_01b4: Expected O, but got I
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_022b: Expected I, but got O
		//IL_038e: Expected I, but got O
		//IL_03a4: Expected O, but got I
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_04ce: Expected O, but got I4
		//IL_04e5: Expected I, but got I8
		//IL_041b: Expected I, but got O
		//IL_0253: Invalid comparison between F4 and I4
		//IL_026b: Expected O, but got I4
		//IL_0273: Expected O, but got I4
		//IL_0565: Expected O, but got I4
		//IL_057c: Expected I, but got I8
		//IL_0214: Expected I, but got I8
		//IL_0404: Expected I, but got I8
		_003C_003Ec__DisplayClass25_0 obj = new _003C_003Ec__DisplayClass25_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		Transform target2 = default(Transform);
		obj.target = target2;
		int num2 = default(int);
		int num = num2;
		BulletPool pool2 = default(BulletPool);
		obj.pool = pool2;
		bool flag = obj.pool != _glimmer1Pool;
		object obj3 = default(object);
		object obj2 = obj3;
		Vector2 vector = pos;
		if (!flag)
		{
			float basicProjectileOffset = GetBasicProjectileOffset(num2);
			Vector2 basicProjectilePosition = GetBasicProjectilePosition(basicProjectileOffset);
			obj.pos = basicProjectilePosition;
			Vector2 vector2 = default(Vector2);
			Projectile projectile = base.FireOneProjectile(vector2, num2, obj.target);
			object obj4 = default(object);
			obj2 = obj4;
			vector = vector2;
			num = num2;
		}
		bool flag2 = obj.pool != _glimmer2Pool;
		bool flag3 = (byte)(int)obj.target != 0;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (!flag2)
		{
			float num3 = base.PAmount();
			float num4 = (float)vector * 4f;
			float num5 = num4 + 12f;
			bool flag4 = !(num5 > 0f);
			flag3 = (byte)(int)obj.target != 0;
			obj2 = 0;
			if (!flag4)
			{
				bool flag5 = false;
				bool flag6;
				do
				{
					_003C_003Ec__DisplayClass25_1 obj5 = new _003C_003Ec__DisplayClass25_1();
					obj5.CS_0024_003C_003E8__locals1 = obj;
					obj5.localAmount = num5;
					obj5.localIndex = (flag5 ? 1 : 0);
					Action action = null;
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ r10_v8 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass25_1._003CFire_FireGlimmerProjectile_003Eb__0);
					((Delegate)action).m_target = obj5;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ r10_v8 (Il2CppMethodInfo)+4C]");
					object obj6 = (nint)0 >> 4;
					object obj7 = obj6 & 1;
					nint num7;
					if (obj7 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ r10_v8 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num7 = unchecked((nint)6447293664L);
							goto IL_04c5;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num7 = ((Delegate)action).method_ptr;
					goto IL_04c5;
					IL_04c5:
					object obj8 = 24;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float num8 = (float)(flag5 ? 1 : 0) * 50f;
					float duration = num8 * 0.001f;
					Timer glimmerShotTimer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_glimmerShotTimer = glimmerShotTimer;
					num = 0;
					flag5 = (byte)((flag5 ? 1u : 0u) + 1u) != 0;
					flag6 = num5 > (float)(flag5 ? 1 : 0);
					flag3 = false;
					obj2 = 0;
					vector = (Vector2)flag5;
				}
				while (flag6);
			}
		}
		if (obj.pool != _glimmer3Pool)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		nint num9 = (nint)characterController;
		float num10 = characterController.PAmount();
		float num11 = (float)vector / 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj10 = default(object);
		object obj9 = obj10 + 3;
		if ((nint)obj9 <= 0)
		{
			return;
		}
		bool flag7 = false;
		do
		{
			_003C_003Ec__DisplayClass25_2 obj11 = new _003C_003Ec__DisplayClass25_2();
			obj11.CS_0024_003C_003E8__locals2 = obj;
			obj11.localIndex = (flag7 ? 1 : 0);
			Action action2 = null;
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass25_2._003CFire_FireGlimmerProjectile_003Eb__1);
			((Delegate)action2).m_target = obj11;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj12 = (nint)0 >> 4;
			object obj13 = obj12 & 1;
			nint num13;
			if (obj13 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num13 = unchecked((nint)6447293664L);
					goto IL_055c;
				}
			}
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			num13 = ((Delegate)action2).method_ptr;
			goto IL_055c;
			IL_055c:
			object obj14 = 24;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			float num14 = (float)(flag7 ? 1 : 0) * 400f;
			float duration2 = num14 * 0.001f;
			Timer glimmerShotTimer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_glimmerShotTimer = glimmerShotTimer2;
			flag7 = (byte)((flag7 ? 1u : 0u) + 1u) != 0;
		}
		while ((flag7 ? 1 : 0) < (nint)obj9);
	}

	private Vector2 GetBasicProjectilePosition(float offsetPos)
	{
		//IL_0046: Expected O, but got I
		//IL_010c: Expected I, but got O
		//IL_0129: Expected O, but got I4
		//IL_00d6: Expected O, but got I8
		//IL_00c4: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Vector2 lastMovementDirection = characterController._lastMovementDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CECB0h\"");
			if ((object)characterController._lastMovementDirection == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CECB0h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				if ((nint)0 == 0)
				{
					lastMovementDirection = characterController._lastFacingDirection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
					obj = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			nint num = (nint)this;
			float num2 = base.PArea();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			object obj2 = 1;
			if (!characterController._isFlipped)
			{
				obj2 = 4294967295L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	private Vector2 GetStarDustProjectilePosition(float offsetAngle)
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CEDFDh\"");
			if ((object)characterController._lastMovementDirection == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001874CEDFDh\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ rax_v1 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
				if ((nint)0 == 0)
				{
					goto IL_0085;
				}
			}
			float num = offsetAngle * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			goto IL_0085;
		}
		return (Vector2)new NullReferenceException();
		IL_0085:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 result = default(Vector2);
		return result;
	}

	private float GetBasicProjectileOffset(int index)
	{
		//IL_0051: Expected O, but got I
		//IL_0063: Expected F4, but got I
		List<float> basicAttackRepeatOffsets = _basicAttackRepeatOffsets;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)index % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v4+20+v52 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	private float GetStardustProjectileOffset(int index)
	{
		//IL_0010: Expected O, but got I
		//IL_00c9: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v46 @ rax_v2 (should have been resolved before IL gen)");
		int num = index & 1;
		bool flag = num == 0;
		object obj2 = !flag;
		float result = 105f;
		if (obj2 == null)
		{
			result = 105f * -1f;
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_explodeOnExpire = true;
			}
		}
	}

	public override void Cleanup()
	{
		if (_glimmerShotTimer != null)
		{
			_glimmerShotTimer.Cancel();
		}
		((Weapon)this).Cleanup();
		if (base.glimmerUnlockTimer != null)
		{
			base.glimmerUnlockTimer.Cancel();
		}
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Spear1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected override void InitGlimmer3BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer3Prefab = _Glimmer3Prefab;
		if ((object)_Glimmer3Prefab != null && ((UnityEngine.Object)glimmer3Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer3Pool = new BulletPool(_Glimmer3Prefab, 20);
			_glimmer3Pool = glimmer3Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer3Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Spear1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer3Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	protected bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0179;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 3f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public EME_Spear1Weapon()
	{
		//IL_0310: Expected I, but got O
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_029e: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_02c6: Expected O, but got I
		//IL_01c4: Expected O, but got I
		//IL_02ee: Expected O, but got I
		//IL_022e: Expected O, but got I
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_003CCachedPlayerDirection_003Ek__BackingField = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v4+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v5+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1098907648;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rdx_v6+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(-16f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 3246391296L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v7+18]");
		if (num6 >= 0)
		{
			list.AddWithResize(32f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1107296256;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v8+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(-32f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 3254779904L;
		}
		_basicAttackRepeatOffsets = list;
		base._002Ector();
	}
}
