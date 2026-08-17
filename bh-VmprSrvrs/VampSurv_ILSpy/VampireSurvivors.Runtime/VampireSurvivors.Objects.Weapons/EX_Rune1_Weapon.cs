using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EX_Rune1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public EX_Rune1_Weapon _003C_003E4__this;

		public Vector2 startingPosition;
	}

	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_02c5: Expected O, but got I4
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected Ref, but got Unknown
			//IL_0082->IL0265: Incompatible stack heights: 1 vs 0
			//IL_00ab->IL0265: Incompatible stack heights: 1 vs 0
			//IL_00da->IL0265: Incompatible stack heights: 1 vs 0
			//IL_00fc->IL0265: Incompatible stack heights: 1 vs 0
			//IL_011e->IL0265: Incompatible stack heights: 1 vs 0
			//IL_031c->IL0265: Incompatible stack heights: 1 vs 0
			//IL_023f->IL0265: Incompatible stack heights: 1 vs 0
			//IL_01a6->IL0265: Incompatible stack heights: 1 vs 0
			//IL_01c8->IL0265: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass11_0 obj = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						_003C_003Ec__DisplayClass11_0 obj3 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							EX_Rune1_Weapon eX_Rune1_Weapon = obj3._003C_003E4__this;
							if ((object)obj3._003C_003E4__this != null && (object)((Equipment)eX_Rune1_Weapon)._003COwner_003Ek__BackingField != null && (object)core._stage != null)
							{
								ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)eX_Rune1_Weapon)._003COwner_003Ek__BackingField + 176);
								EnemyController enemyController = core._stage.PickRandomEnemyController(ref rng);
								_003C_003Ec__DisplayClass11_0 obj4;
								if ((object)enemyController != null)
								{
									bool flag2 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
									obj4 = CS_0024_003C_003E8__locals1;
									if (!flag2)
									{
										if (CS_0024_003C_003E8__locals1 != null && (object)obj4._003C_003E4__this != null)
										{
											Vector2 startPosition = default(Vector2);
											obj4._003C_003E4__this.FireStripAtEnemy(enemyController, localIndex, startPosition);
											return;
										}
										goto IL_0265;
									}
								}
								else
								{
									obj4 = CS_0024_003C_003E8__locals1;
								}
								if (obj4 != null)
								{
									EX_Rune1_Weapon eX_Rune1_Weapon2 = obj4._003C_003E4__this;
									_003C_003Ec__DisplayClass11_0 obj5 = CS_0024_003C_003E8__locals1;
									EX_Rune1_Weapon eX_Rune1_Weapon3 = obj5._003C_003E4__this;
									if ((object)obj5._003C_003E4__this != null)
									{
										int accumulatedProjectiles = eX_Rune1_Weapon3.AccumulatedProjectiles + 1;
										eX_Rune1_Weapon2.AccumulatedProjectiles = accumulatedProjectiles;
										return;
									}
								}
							}
						}
					}
				}
			}
			goto IL_0265;
			IL_0265:
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public EX_Rune1_Weapon _003C_003E4__this;

		public Vector2 startPosition;

		public EnemyController enemy;
	}

	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals1;

		internal void _003CFireStripAtEnemy_003Eb__0()
		{
			//IL_0244: Expected O, but got I4
			//IL_00f4: Expected I, but got O
			//IL_00fc: Expected I, but got O
			//IL_010c: Expected O, but got I
			//IL_018c: Expected O, but got I4
			//IL_0148: Expected O, but got I
			//IL_017e: Expected O, but got I4
			//IL_0084->IL01e4: Incompatible stack heights: 1 vs 0
			//IL_00a6->IL01e4: Incompatible stack heights: 1 vs 0
			//IL_01c2->IL01e4: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass9_0 obj = CS_0024_003C_003E8__locals1;
			Projectile projectile;
			object obj6;
			if (CS_0024_003C_003E8__locals1 != null && (object)obj._003C_003E4__this != null)
			{
				GameObject gameObject = obj._003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj2 == null)
					{
						return;
					}
					_003C_003Ec__DisplayClass9_0 obj3 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null && (object)obj3._003C_003E4__this != null)
					{
						Vector2 pos = default(Vector2);
						projectile = obj3._003C_003E4__this.FireOneProjectile(pos, localIndex);
						if ((object)projectile == null)
						{
							return;
						}
						nint num = (nint)typeof(EX_Rune1_Projectile);
						nint num2 = (nint)projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18+FFFFFFF8+v392 @ rcx_v14*8]");
							if (0 == (nint)typeof(EX_Rune1_Projectile))
							{
								obj6 = 1;
								goto IL_0261;
							}
						}
						obj6 = 0;
						goto IL_0261;
					}
				}
			}
			goto IL_01e4;
			IL_01e4:
			throw new NullReferenceException();
			IL_0261:
			bool flag2 = obj6 == null;
			EX_Rune1_Projectile eX_Rune1_Projectile = null;
			if (!flag2)
			{
				eX_Rune1_Projectile = (EX_Rune1_Projectile)projectile;
			}
			if ((object)eX_Rune1_Projectile != null)
			{
				_003C_003Ec__DisplayClass9_0 obj7 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					eX_Rune1_Projectile.SetEnemyTarget(obj7.enemy);
					return;
				}
				goto IL_01e4;
			}
		}
	}

	public int AccumulatedProjectiles;

	private int activations;

	private List<PhaserSprite> magicCircles;

	private int magicCircleIndex;

	private float _angle1;

	private float _angle2;

	private float _angle3;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0022: Expected O, but got I4
		//IL_007e: Expected I4, but got I8
		//IL_024b->IL01b9: Incompatible stack heights: 1 vs 0
		//IL_02ca->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_0122->IL01b9: Incompatible stack heights: 2 vs 0
		//IL_01b3->IL02cf: Incompatible stack heights: 2 vs 0
		base.InitWeapon(characterController, weaponType);
		AccumulatedProjectiles = 0;
		int num = 0;
		while (true)
		{
			GameObject gameObject = base.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)0, "vfx", "MagicCircleRed");
			if ((object)phaserSprite == null)
			{
				break;
			}
			PhaserSprite phaserSprite2 = phaserSprite.setBlendMode(BlendMode.Add);
			PhaserSprite phaserSprite3 = phaserSprite.setAlpha(0f);
			PhaserSprite phaserSprite4 = phaserSprite.setDepth(-1995);
			bool flag = ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)phaserSprite).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform == null)
			{
				break;
			}
			bool flag2 = ((string)(object)transform)._stringLength == 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v28 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Transform transform2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>((nint)(delegate*<Transform, IntPtr>)(&UnityEngine.Object.MarshalledUnityObject.Marshal));
			}
			Transform.SetParent_Injected((IntPtr)((string)(object)transform)._stringLength, (IntPtr)0, true);
			PhaserSprite phaserSprite5 = phaserSprite.setVisible(visible: false);
			((UnityEngine.Object)phaserSprite).SetName("MagicCircleRed EX_Rune1Weapon");
			List<object> list = (List<object>)(object)magicCircles;
			if (magicCircles == null)
			{
				break;
			}
			int version = list._version + 1;
			list._version = version;
			object[] items = list._items;
			if (list._items == null)
			{
				break;
			}
			if (list._size >= items.Length)
			{
				((List<object>)(object)magicCircles).AddWithResize((object)phaserSprite);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			num++;
			if (num < 24)
			{
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	protected float StripLength()
	{
		float num = base.PAmount();
		float num2 = base.PSpeed();
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		object obj2 = default(object);
		object obj = obj2 * obj2;
		return (float)obj2 * (float)obj;
	}

	private void FireStripAtEnemy(EnemyController enemy, int index, Vector2 startPosition)
	{
		//IL_00b0: Invalid comparison between F4 and I4
		//IL_0391: Expected O, but got I4
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		//IL_0470: Invalid comparison between F4 and I4
		//IL_0338: Invalid comparison between F4 and I4
		//IL_0302: Expected I4, but got F4
		//IL_016b: Expected I, but got O
		//IL_0173: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_022b: Expected O, but got I4
		//IL_01c7: Expected O, but got I
		//IL_01f6: Expected O, but got I
		//IL_0214: Expected O, but got I
		//IL_021d: Expected O, but got I4
		_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
		obj._003C_003E4__this = this;
		obj.startPosition = startPosition;
		obj.enemy = enemy;
		float num = base.PAmount();
		float num2 = base.PSpeed();
		float num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PDuration();
		float num4 = (float)startPosition * (float)startPosition;
		float num5 = (float)startPosition * num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm9\"");
		Vector2 vector = default(Vector2);
		int num6 = default(int);
		ShowMagicCircleAt(vector, num6);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm9\"");
		ShowMagicCircleAt(vector, num6);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm9\"");
		ShowMagicCircleAt(vector, num6);
		bool flag = !(num5 > 0f);
		Vector2 vector2 = vector;
		float num7 = default(float);
		if (!flag)
		{
			bool flag2 = false;
			float num8 = default(float);
			num7 = num8;
			float num10 = default(float);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag6;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				float num9 = (((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField == null) ? 1000f : num10);
				float num11 = (float)(flag2 ? 1 : 0) * num9;
				Projectile projectile;
				object obj3;
				if (!(num11 > 0f))
				{
					projectile = base.FireOneProjectile(vector, flag2 ? 1 : 0);
					bool flag3 = (object)projectile == null;
					vector2 = vector;
					if (!flag3)
					{
						nint num12 = (nint)typeof(EX_Rune1_Projectile);
						nint num13 = (nint)projectile;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						Vector2 vector3 = (Vector2)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
						bool flag4 = num14 < 0;
						vector2 = vector;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ rax_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rcx_v35+FFFFFFF8+v677 @ rcx_v29 (UnityEngine.Vector2)*8]");
							bool flag5 = 0 != (nint)typeof(EX_Rune1_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
							vector2 = (Vector2)0;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
								vector2 = (Vector2)0;
								obj3 = 1;
								goto IL_0484;
							}
						}
						obj3 = 0;
						goto IL_0484;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass9_1();
					CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals9.localIndex = (flag2 ? 1 : 0);
					float hitBoxDelay = base.HitBoxDelay;
					Action action = delegate
					{
						//IL_0244: Expected O, but got I4
						//IL_00f4: Expected I, but got O
						//IL_00fc: Expected I, but got O
						//IL_010c: Expected O, but got I
						//IL_018c: Expected O, but got I4
						//IL_0148: Expected O, but got I
						//IL_017e: Expected O, but got I4
						//IL_0084->IL01e4: Incompatible stack heights: 1 vs 0
						//IL_00a6->IL01e4: Incompatible stack heights: 1 vs 0
						//IL_01c2->IL01e4: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass9_0 obj10 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						Projectile projectile2;
						object obj15;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag8 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								_003C_003Ec__DisplayClass9_0 obj12 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null && (object)obj12._003C_003E4__this != null)
								{
									Vector2 pos = default(Vector2);
									projectile2 = obj12._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals9.localIndex);
									if ((object)projectile2 == null)
									{
										return;
									}
									nint num16 = (nint)typeof(EX_Rune1_Projectile);
									nint num17 = (nint)projectile2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num18 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile>)+130]");
									if (num18 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj14 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ rcx_v18+FFFFFFF8+v392 @ rcx_v14*8]");
										if (0 == (nint)typeof(EX_Rune1_Projectile))
										{
											obj15 = 1;
											goto IL_0261;
										}
									}
									obj15 = 0;
									goto IL_0261;
								}
							}
						}
						goto IL_01e4;
						IL_01e4:
						throw new NullReferenceException();
						IL_0261:
						bool flag9 = obj15 == null;
						EX_Rune1_Projectile eX_Rune1_Projectile2 = null;
						if (!flag9)
						{
							eX_Rune1_Projectile2 = (EX_Rune1_Projectile)projectile2;
						}
						if ((object)eX_Rune1_Projectile2 == null)
						{
							return;
						}
						_003C_003Ec__DisplayClass9_0 obj16 = CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals9.CS_0024_003C_003E8__locals1 != null)
						{
							eX_Rune1_Projectile2.SetEnemyTarget(obj16.enemy);
							return;
						}
						goto IL_01e4;
					};
					float num15 = (float)(flag2 ? 1 : 0) * hitBoxDelay;
					float duration = num15 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num7 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					vector2 = (Vector2)action;
				}
				goto IL_0322;
				IL_0322:
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
				flag6 = num5 > (float)(flag2 ? 1 : 0);
				num7 = num7;
				continue;
				IL_0484:
				bool flag7 = obj3 == null;
				EX_Rune1_Projectile eX_Rune1_Projectile = null;
				if (!flag7)
				{
					eX_Rune1_Projectile = (EX_Rune1_Projectile)projectile;
				}
				if ((object)eX_Rune1_Projectile != null)
				{
					eX_Rune1_Projectile.SetEnemyTarget(obj.enemy);
					vector2 = (Vector2)obj.enemy;
				}
				goto IL_0322;
			}
			while (flag6);
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r15d\"");
		object obj4 = (object)vector2 >> 1;
		soundConfig.Volume = (float?)(object)1;
		object obj5 = obj4 >> 31;
		object obj6 = obj4 + obj5;
		object obj7 = obj6 * 4;
		object obj8 = obj6 + obj7;
		object obj9 = num6 - obj8;
		float detune = (float)obj9 * -500f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Magic4, soundConfig, 200f, 12, num7);
	}

	private Vector2 GetScreenPosition()
	{
		//IL_00e0: Expected O, but got I4
		int num = activations & 1;
		bool flag = num == 0;
		object obj = !flag;
		if (obj == null)
		{
		}
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && s_scene._renderer != null && (object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					Vector2 result = default(Vector2);
					if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
					{
						return result;
					}
				}
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0464: Expected O, but got I4
		//IL_0078: Expected O, but got I
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0110: Expected O, but got F4
		//IL_0153: Expected O, but got Ref
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_04dd: Invalid comparison between O and F4
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03e5: Invalid comparison between O and F4
		//IL_0410: Expected F4, but got O
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Ref, but got Unknown
		//IL_0375: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		_003C_003Ec__DisplayClass11_0 obj = new _003C_003Ec__DisplayClass11_0();
		obj._003C_003E4__this = this;
		int num = activations + 1;
		activations = num;
		int num2 = activations & 1;
		bool flag = num2 == 0;
		object obj2 = !flag;
		float num3 = ((obj2 != null) ? (-1f) : 1f);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 s_scene = (Vector2)ArcadePhysics.s_scene;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ r9_v6 (UnityEngine.Vector2)+28]");
		object obj3 = 0;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene2._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rax_v11+10]");
		float num4 = 0f * 0.25f;
		float height = renderer.height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = height ^ 0;
		float num5 = (float)obj4 * 0.5f;
		float num6 = num4 * num3;
		object obj5 = default(object);
		float num7 = (float)obj5 + num5;
		float num8 = (float)position + num6;
		obj.startingPosition = (Vector2)num8;
		GameManager core = GM.Core;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		object obj6 = default(object);
		EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj6), excludeDead: true);
		Vector2 vector = default(Vector2);
		Vector2 vector2;
		if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
		{
			FireStripAtEnemy(enemyController, 0, vector);
			vector2 = vector;
		}
		else
		{
			int accumulatedProjectiles = AccumulatedProjectiles + 1;
			AccumulatedProjectiles = accumulatedProjectiles;
			vector2 = vector;
		}
		float num9 = base.PAmount();
		AccumulatedProjectiles = 0;
		object obj7 = AccumulatedProjectiles + vector2;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
		{
			int num10 = 1;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			bool flag2;
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj8 = num10 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj8 <= 0)
				{
					GameManager core2 = GM.Core;
					ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
					EnemyController enemyController2 = core2._stage.PickRandomEnemyController(ref rng);
					if ((object)enemyController2 != null && ((UnityEngine.Object)enemyController2).m_CachedPtr != (IntPtr)0)
					{
						FireStripAtEnemy(enemyController2, num10, vector);
					}
					else
					{
						int accumulatedProjectiles2 = AccumulatedProjectiles + 1;
						AccumulatedProjectiles = accumulatedProjectiles2;
					}
				}
				else
				{
					_003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass11_1();
					CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals11.localIndex = num10;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_02c5: Expected O, but got I4
						//IL_0131: Unknown result type (might be due to invalid IL or missing references)
						//IL_0136: Expected Ref, but got Unknown
						//IL_0082->IL0265: Incompatible stack heights: 1 vs 0
						//IL_00ab->IL0265: Incompatible stack heights: 1 vs 0
						//IL_00da->IL0265: Incompatible stack heights: 1 vs 0
						//IL_00fc->IL0265: Incompatible stack heights: 1 vs 0
						//IL_011e->IL0265: Incompatible stack heights: 1 vs 0
						//IL_031c->IL0265: Incompatible stack heights: 1 vs 0
						//IL_023f->IL0265: Incompatible stack heights: 1 vs 0
						//IL_01a6->IL0265: Incompatible stack heights: 1 vs 0
						//IL_01c8->IL0265: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass11_0 obj10 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null && (object)obj10._003C_003E4__this != null)
						{
							GameObject gameObject = obj10._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj11 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj11 == null)
								{
									return;
								}
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null)
								{
									_003C_003Ec__DisplayClass11_0 obj12 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
									{
										EX_Rune1_Weapon eX_Rune1_Weapon = obj12._003C_003E4__this;
										if ((object)obj12._003C_003E4__this != null && (object)((Equipment)eX_Rune1_Weapon)._003COwner_003Ek__BackingField != null && (object)core3._stage != null)
										{
											ref Unity.Mathematics.Random rng2 = ref *(Unity.Mathematics.Random*)(((Equipment)eX_Rune1_Weapon)._003COwner_003Ek__BackingField + 176);
											EnemyController enemyController3 = core3._stage.PickRandomEnemyController(ref rng2);
											_003C_003Ec__DisplayClass11_0 obj13;
											if ((object)enemyController3 != null)
											{
												bool flag5 = ((UnityEngine.Object)enemyController3).m_CachedPtr == (IntPtr)0;
												obj13 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
												if (!flag5)
												{
													if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null && (object)obj13._003C_003E4__this != null)
													{
														Vector2 startPosition = default(Vector2);
														obj13._003C_003E4__this.FireStripAtEnemy(enemyController3, CS_0024_003C_003E8__locals11.localIndex, startPosition);
														return;
													}
													goto IL_0265;
												}
											}
											else
											{
												obj13 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
											}
											if (obj13 != null)
											{
												EX_Rune1_Weapon eX_Rune1_Weapon2 = obj13._003C_003E4__this;
												_003C_003Ec__DisplayClass11_0 obj14 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
												EX_Rune1_Weapon eX_Rune1_Weapon3 = obj14._003C_003E4__this;
												if ((object)obj14._003C_003E4__this != null)
												{
													int accumulatedProjectiles3 = eX_Rune1_Weapon3.AccumulatedProjectiles + 1;
													eX_Rune1_Weapon2.AccumulatedProjectiles = accumulatedProjectiles3;
													return;
												}
											}
										}
									}
								}
							}
						}
						goto IL_0265;
						IL_0265:
						throw new NullReferenceException();
					};
					float num11 = (float)num10 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					float duration = num11 * 0.001f;
					Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					s_scene = (Vector2)0;
				}
				num10++;
				flag2 = (nint)obj7 > num10;
				vector2 = (Vector2)num10;
			}
			while (flag2);
		}
		float num12 = base.PInterval();
		float num13 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj9 = num13 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num14 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		bool flag3 = default(bool);
		if (!flag3)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Magic;
	}

	private void ShowMagicCircleAt(Vector2 position, int times)
	{
		//IL_0190: Expected O, but got I4
		//IL_0130: Expected O, but got I
		//IL_021f: Expected O, but got I
		List<PhaserSprite> list = magicCircles;
		int num = ++magicCircleIndex % list._size;
		if (num < list._size)
		{
			PhaserSprite[] items = list._items;
			object obj = items[num];
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num2 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)items[num], false, optionalFloat, optionalObj, optionalArray);
			Transform transform = items[num].transform;
			if ((object)transform != null)
			{
				int num3 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, optionalFloat, optionalObj, optionalArray);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v5 (System.Object)+28]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v5 (System.Object)+28]");
				int num4 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)0, false, optionalFloat, optionalObj, optionalArray);
			}
			PhaserSprite phaserSprite = items[num].setVisible(visible: true);
			PhaserSprite phaserSprite2 = items[num].setAlpha(0.65f);
			PhaserSprite phaserSprite3 = items[num].setScale(0.1f, (float?)(object)0);
			Transform target = items[num].transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0.75f, 0.25f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdi_v5 (System.Object)+28]");
			TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade((SpriteRenderer)0, 0f, 0.25f);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 0.25f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			float delay = default(float);
			TweenerCore<Color, Color, ColorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay((TweenerCore<Color, Color, ColorOptions>)(object)items[num], delay);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0033: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0170: Expected O, but got Ref
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0196: Expected O, but got I4
		//IL_0136: Expected O, but got Ref
		//IL_00fc: Expected O, but got Ref
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		List<PhaserSprite> list = magicCircles;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float angle = num2 + _angle2;
		float angle2 = num + _angle1;
		float angle3 = num3 + _angle3;
		_angle2 = angle;
		_angle1 = angle2;
		_angle3 = angle3;
		if (list._size <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = 0;
		object obj5 = default(object);
		while (true)
		{
			List<PhaserSprite> list2 = magicCircles;
			if ((nint)obj >= list2._size)
			{
				break;
			}
			PhaserSprite[] items = list2._items;
			bool flag = obj2 == null;
			if (flag)
			{
				goto IL_0144;
			}
			object obj3 = obj2 - 1;
			Transform transform;
			Vector3 axis;
			float angle4;
			if (!flag)
			{
				if ((nint)obj3 != 1)
				{
					goto IL_0144;
				}
				transform = items[obj].transform;
				object obj4 = obj5;
				axis = (Vector3)(&obj4);
				angle4 = 2.4f;
			}
			else
			{
				transform = items[obj].transform;
				object obj6 = obj5;
				axis = (Vector3)(&obj6);
				angle4 = 2.2f;
			}
			goto IL_0257;
			IL_0144:
			transform = items[obj].transform;
			object obj7 = obj5;
			axis = (Vector3)(&obj7);
			angle4 = 2f;
			goto IL_0257;
			IL_0257:
			transform.Rotate(axis, angle4, Space.Self);
			object obj8 = obj2 + 1;
			List<PhaserSprite> list3 = magicCircles;
			obj++;
			bool flag2 = (nint)obj8 > 2;
			obj2 = 0;
			if (!flag2)
			{
				obj2 = obj8;
			}
			if ((nint)obj >= list3._size)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void Cleanup()
	{
		base.Cleanup();
		List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public EX_Rune1_Weapon()
	{
		List<PhaserSprite> list = new List<PhaserSprite>();
		magicCircles = list;
		base._002Ector();
	}
}
