using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_GothMissile_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public TP_GothMissile_Weapon _003C_003E4__this;

		public float _FlipX;

		public float _defY;

		public Vector2 cachedPos;

		public Vector2 direction;
	}

	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_003Eb__0()
		{
			//IL_0459: Expected O, but got I4
			//IL_0177: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_031d: Expected I, but got O
			//IL_0325: Expected I, but got O
			//IL_0335: Expected O, but got I
			//IL_03b5: Expected O, but got I4
			//IL_0371: Expected O, but got I
			//IL_03a7: Expected O, but got I4
			//IL_00e1->IL03f9: Incompatible stack heights: 1 vs 0
			//IL_0110->IL03f9: Incompatible stack heights: 1 vs 0
			//IL_013f->IL03f9: Incompatible stack heights: 1 vs 0
			//IL_0197->IL03f9: Incompatible stack heights: 2 vs 0
			//IL_0200->IL03f9: Incompatible stack heights: 3 vs 0
			//IL_0258->IL03f9: Incompatible stack heights: 4 vs 0
			//IL_0298->IL03f9: Incompatible stack heights: 5 vs 0
			//IL_02c7->IL03f9: Incompatible stack heights: 5 vs 0
			//IL_030a->IL03f8: Incompatible stack heights: 5 vs 1
			//IL_04b0->IL03f8: Incompatible stack heights: 5 vs 1
			//IL_03e1->IL03f9: Incompatible stack heights: 5 vs 0
			//IL_03f8->IL03f8: Incompatible stack heights: 5 vs 1
			_003C_003Ec__DisplayClass8_0 obj = CS_0024_003C_003E8__locals1;
			Projectile projectile;
			Vector2 vector = default(Vector2);
			object obj10;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_GothMissile_Weapon tP_GothMissile_Weapon = obj._003C_003E4__this;
				if ((object)obj._003C_003E4__this != null)
				{
					List<float> offsetsX = tP_GothMissile_Weapon.offsetsX;
					if (tP_GothMissile_Weapon.offsetsX != null)
					{
						int num = localIndex;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
						int num2 = (int)((nint)num % (nint)0);
						_003C_003Ec__DisplayClass8_0 obj2 = CS_0024_003C_003E8__locals1;
						GameObject gameObject = obj2._003C_003E4__this.gameObject;
						if ((object)gameObject != null)
						{
							bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
							object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
							if (obj3 == null)
							{
								return;
							}
							_003C_003Ec__DisplayClass8_0 obj4 = CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals1 != null)
							{
								TP_GothMissile_Weapon tP_GothMissile_Weapon2 = obj4._003C_003E4__this;
								if ((object)obj4._003C_003E4__this != null)
								{
									List<float> offsetsX2 = tP_GothMissile_Weapon2.offsetsX;
									if (tP_GothMissile_Weapon2.offsetsX != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
										bool flag2 = (nint)num2 >= (nint)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
										object obj5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v17+18]");
											bool flag3 = (nint)num2 >= (nint)0;
											_003C_003Ec__DisplayClass8_0 obj6 = CS_0024_003C_003E8__locals1;
											TP_GothMissile_Weapon tP_GothMissile_Weapon3 = obj6._003C_003E4__this;
											List<float> offsetsY = tP_GothMissile_Weapon3.offsetsY;
											if (tP_GothMissile_Weapon3.offsetsY != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
												bool flag4 = (nint)num2 >= (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v20+18]");
													bool flag5 = (nint)num2 >= (nint)0;
													if (obj6 != null)
													{
														TP_GothMissile_Weapon tP_GothMissile_Weapon4 = obj6._003C_003E4__this;
														if ((object)obj6._003C_003E4__this != null)
														{
															projectile = obj6._003C_003E4__this.FireOneProjectile(vector, localIndex, tP_GothMissile_Weapon4._targetTransform);
															if ((object)projectile == null)
															{
																return;
															}
															nint num3 = (nint)typeof(TP_GothMissile_Projectile);
															nint num4 = (nint)projectile;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
															object obj8 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
															nint num5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
															if (num5 >= 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
																object obj9 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rcx_v26+FFFFFFF8+v619 @ rcx_v22*8]");
																if (0 == (nint)typeof(TP_GothMissile_Projectile))
																{
																	obj10 = 1;
																	goto IL_0476;
																}
															}
															obj10 = 0;
															goto IL_0476;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_03f9;
			IL_0476:
			bool flag6 = obj10 == null;
			TP_GothMissile_Projectile tP_GothMissile_Projectile = null;
			if (!flag6)
			{
				tP_GothMissile_Projectile = (TP_GothMissile_Projectile)projectile;
			}
			if ((object)tP_GothMissile_Projectile != null)
			{
				if (CS_0024_003C_003E8__locals1 != null)
				{
					tP_GothMissile_Projectile.SetDirection(vector);
					return;
				}
				goto IL_03f9;
			}
			return;
			IL_03f9:
			throw new NullReferenceException();
		}
	}

	private static float init = 0.5f;

	private static float unitX = 0.48f;

	private static float unitY = 0.32f;

	private List<float> offsetsX;

	private List<float> offsetsY;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		float num = base.PInterval();
		object obj = default(object);
		float num2 = (float)obj * 0.1f;
		base._003CTotalTime_003Ek__BackingField = num2;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = base.PInterval();
		float num2 = deltaTime * 1000f;
		if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_08a8: Expected O, but got I
		//IL_08c5: Expected O, but got I
		//IL_08e0: Expected O, but got I
		//IL_08ea: Expected I, but got O
		//IL_08ef: Expected I, but got O
		//IL_016b: Expected I, but got O
		//IL_0173: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_0203: Expected O, but got I4
		//IL_0385: Expected O, but got I
		//IL_01bf: Expected O, but got I
		//IL_0914: Expected O, but got I
		//IL_0922: Expected I, but got O
		//IL_01f5: Expected O, but got I4
		//IL_03d6: Expected I, but got O
		//IL_0404: Invalid comparison between F4 and I
		//IL_042a: Invalid comparison between F4 and I4
		//IL_0453: Expected O, but got I4
		//IL_0225: Expected O, but got I
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0852: Invalid comparison between O and F4
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_0319: Expected O, but got I
		//IL_0322: Expected I, but got O
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Expected O, but got Unknown
		//IL_04db: Expected F4, but got I
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_054b: Expected O, but got I
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		//IL_07a4: Expected I, but got O
		//IL_0610: Expected I, but got O
		//IL_0618: Expected I4, but got O
		//IL_0628: Expected O, but got I
		//IL_06a8: Expected O, but got I4
		//IL_0664: Expected O, but got I
		//IL_094e: Expected I, but got O
		//IL_069a: Expected O, but got I4
		//IL_06ca: Expected F4, but got I
		//IL_06d7: Expected O, but got I
		//IL_06dd: Expected I, but got O
		_003C_003Ec__DisplayClass8_0 obj = new _003C_003Ec__DisplayClass8_0();
		obj._003C_003E4__this = this;
		float flipX = ((!((Equipment)this)._003COwner_003Ek__BackingField.flipX) ? (-1f) : 1f);
		obj._FlipX = flipX;
		ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 size = arcadeSprite._spriteRenderer.size;
		float num = default(float);
		float defY = num * 0.5f;
		obj._defY = defY;
		List<float> list = offsetsX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
		IntPtr intPtr = default(IntPtr);
		Projectile projectile;
		Vector2 vector;
		nint num2;
		object obj4;
		nint num3;
		if ((nint)0 > (nint)0)
		{
			List<float> list2 = offsetsY;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v15 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 > (nint)0)
			{
				float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				obj.cachedPos = position;
				if (((Equipment)this)._003COwner_003Ek__BackingField.flipX)
				{
				}
				obj.direction = (Vector2)(nint)intPtr;
				projectile = base.FireOneProjectile((Vector2)(nint)intPtr, 0, _targetTransform);
				bool flag = (object)projectile == null;
				vector = (Vector2)(nint)intPtr;
				num2 = (nint)_targetTransform;
				num3 = unchecked((nint)null);
				if (flag)
				{
					goto IL_0327;
				}
				nint num4 = (nint)typeof(TP_GothMissile_Projectile);
				num2 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
				if (num5 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rcx_v48+FFFFFFF8+v956 @ rcx_v43*8]");
					if (0 == (nint)typeof(TP_GothMissile_Projectile))
					{
						obj4 = 1;
						goto IL_0827;
					}
				}
				obj4 = 0;
				goto IL_0827;
			}
		}
		goto IL_081c;
		IL_0827:
		bool flag2 = obj4 == null;
		ArcadeSprite arcadeSprite2 = null;
		if (!flag2)
		{
			arcadeSprite2 = projectile;
		}
		bool flag3 = (object)arcadeSprite2 == null;
		vector = (Vector2)(nint)intPtr;
		num3 = (nint)typeof(TP_GothMissile_Projectile);
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_GothMissile_Weapon+<>c__DisplayClass8_0)+2C]");
			vector = (Vector2)0;
			bool flag4 = 0 < (nint)obj.direction;
			object obj5 = 0 - obj.direction;
			bool flag5 = obj5 == null;
			_ = obj.direction;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_GothMissile_Weapon+<>c__DisplayClass8_0)+2C]");
			_ = 0;
			bool flag6 = !flag4;
			bool flag7 = !flag5;
			bool flipX2 = flag7 & flag6;
			ArcadeSprite arcadeSprite3 = arcadeSprite2.setFlipX(flipX2);
			bool flag8 = 0 < (nint)obj.direction;
			object obj6 = 0 - obj.direction;
			bool flag9 = obj6 == null;
			bool flag10 = !flag8;
			bool flag11 = !flag9;
			bool flipX3 = flag11 & flag10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v15 (ArcadeSprite)+D8]");
			PhaserSprite phaserSprite = ((PhaserSprite)0).setFlipX(flipX3);
			num3 = unchecked((nint)null);
		}
		goto IL_0327;
		IL_0327:
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num6 = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num6 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rcx_v16 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj7 = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			float num7 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			List<float> list3 = offsetsX;
			nint num8 = (nint)this;
			float num9 = base.PAmount();
			float num10 = (float)vector * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v17+20+v224 @ rdx_v12 (System.Int32)*4]");
			bool flag12 = num10 < 0f;
			float num11 = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v17+20+v224 @ rdx_v12 (System.Int32)*4]");
			float num12 = num11 - 0f;
			bool flag13 = num12 == 0f;
			bool flag14 = !flag12;
			bool flag15 = !flag13;
			object obj8 = flag15 & flag14;
			bool flag16 = obj8 == null;
			float num13 = num;
			Vector2 vector2 = vector;
			if (!flag16)
			{
				Vector2 vector3 = vector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rbx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				Vector2 vector4 = vector3 / 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				float num14 = (float)vector4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rbx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				float num15 = num14 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rbx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				vector2 = (Vector2)(num15 + 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rbx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
				num13 = 0f;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f))
			{
				bool flag17 = true;
				bool flag18 = (byte)num2 != 0;
				Projectile projectile2 = default(Projectile);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData2 = _currentWeaponData;
					object obj9 = flag17 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					object obj13;
					if ((nint)obj9 <= 0)
					{
						List<float> list4 = offsetsX;
						bool num16 = flag17;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v30 (System.Collections.Generic.List`1<System.Single>)+18]");
						object obj10 = (nint)(num16 ? 1 : 0) % (nint)0;
						GameObject gameObject = base.gameObject;
						if (gameObject.activeSelf)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
							float num17 = (float)obj9 + obj._defY;
							float num18 = num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_GothMissile_Weapon+<>c__DisplayClass8_0)+24]");
							num13 = num18 + 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
							bool flag19 = (object)projectile2 == null;
							flag18 = flag17;
							num3 = intPtr;
							if (!flag19)
							{
								nint num19 = (nint)typeof(TP_GothMissile_Projectile);
								flag18 = (byte)(int)projectile2 != 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ r9_v9 (System.Boolean)+130]");
								nint num20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
								if (num20 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1159 @ r9_v9 (System.Boolean)+C8]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1354 @ rcx_v42+FFFFFFF8+v1340 @ rcx_v36*8]");
									if (0 == (nint)typeof(TP_GothMissile_Projectile))
									{
										obj13 = 1;
										goto IL_0869;
									}
								}
								obj13 = 0;
								goto IL_0869;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass8_1();
						CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = obj;
						CS_0024_003C_003E8__locals11.localIndex = (flag17 ? 1 : 0);
						WeaponData currentWeaponData3 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_0459: Expected O, but got I4
							//IL_0177: Expected O, but got I
							//IL_0238: Expected O, but got I
							//IL_031d: Expected I, but got O
							//IL_0325: Expected I, but got O
							//IL_0335: Expected O, but got I
							//IL_03b5: Expected O, but got I4
							//IL_0371: Expected O, but got I
							//IL_03a7: Expected O, but got I4
							//IL_00e1->IL03f9: Incompatible stack heights: 1 vs 0
							//IL_0110->IL03f9: Incompatible stack heights: 1 vs 0
							//IL_013f->IL03f9: Incompatible stack heights: 1 vs 0
							//IL_0197->IL03f9: Incompatible stack heights: 2 vs 0
							//IL_0200->IL03f9: Incompatible stack heights: 3 vs 0
							//IL_0258->IL03f9: Incompatible stack heights: 4 vs 0
							//IL_0298->IL03f9: Incompatible stack heights: 5 vs 0
							//IL_02c7->IL03f9: Incompatible stack heights: 5 vs 0
							//IL_030a->IL03f8: Incompatible stack heights: 5 vs 1
							//IL_04b0->IL03f8: Incompatible stack heights: 5 vs 1
							//IL_03e1->IL03f9: Incompatible stack heights: 5 vs 0
							//IL_03f8->IL03f8: Incompatible stack heights: 5 vs 1
							_003C_003Ec__DisplayClass8_0 obj15 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
							Projectile projectile3;
							Vector2 vector5 = default(Vector2);
							object obj24;
							if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
							{
								TP_GothMissile_Weapon tP_GothMissile_Weapon = obj15._003C_003E4__this;
								if ((object)obj15._003C_003E4__this != null)
								{
									List<float> list5 = tP_GothMissile_Weapon.offsetsX;
									if (tP_GothMissile_Weapon.offsetsX != null)
									{
										int localIndex = CS_0024_003C_003E8__locals11.localIndex;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r8_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
										int num21 = (int)((nint)localIndex % (nint)0);
										_003C_003Ec__DisplayClass8_0 obj16 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
										GameObject gameObject2 = obj16._003C_003E4__this.gameObject;
										if ((object)gameObject2 != null)
										{
											bool flag22 = ((UnityEngine.Object)gameObject2).m_CachedPtr == (IntPtr)0;
											object obj17 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject2).m_CachedPtr);
											if (obj17 == null)
											{
												return;
											}
											_003C_003Ec__DisplayClass8_0 obj18 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
											{
												TP_GothMissile_Weapon tP_GothMissile_Weapon2 = obj18._003C_003E4__this;
												if ((object)obj18._003C_003E4__this != null)
												{
													List<float> list6 = tP_GothMissile_Weapon2.offsetsX;
													if (tP_GothMissile_Weapon2.offsetsX != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+18]");
														bool flag23 = (nint)num21 >= (nint)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
														object obj19 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v25 (System.Collections.Generic.List`1<System.Single>)+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v17+18]");
															bool flag24 = (nint)num21 >= (nint)0;
															_003C_003Ec__DisplayClass8_0 obj20 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
															TP_GothMissile_Weapon tP_GothMissile_Weapon3 = obj20._003C_003E4__this;
															List<float> list7 = tP_GothMissile_Weapon3.offsetsY;
															if (tP_GothMissile_Weapon3.offsetsY != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+18]");
																bool flag25 = (nint)num21 >= (nint)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
																object obj21 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v19 (System.Collections.Generic.List`1<System.Single>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v20+18]");
																	bool flag26 = (nint)num21 >= (nint)0;
																	if (obj20 != null)
																	{
																		TP_GothMissile_Weapon tP_GothMissile_Weapon4 = obj20._003C_003E4__this;
																		if ((object)obj20._003C_003E4__this != null)
																		{
																			projectile3 = obj20._003C_003E4__this.FireOneProjectile(vector5, CS_0024_003C_003E8__locals11.localIndex, tP_GothMissile_Weapon4._targetTransform);
																			if ((object)projectile3 == null)
																			{
																				return;
																			}
																			nint num22 = (nint)typeof(TP_GothMissile_Projectile);
																			nint num23 = (nint)projectile3;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
																			object obj22 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
																			nint num24 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GothMissile_Projectile>)+130]");
																			if (num24 >= 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
																				object obj23 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rcx_v26+FFFFFFF8+v619 @ rcx_v22*8]");
																				if (0 == (nint)typeof(TP_GothMissile_Projectile))
																				{
																					obj24 = 1;
																					goto IL_0476;
																				}
																			}
																			obj24 = 0;
																			goto IL_0476;
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
							goto IL_03f9;
							IL_0476:
							bool flag27 = obj24 == null;
							TP_GothMissile_Projectile tP_GothMissile_Projectile2 = null;
							if (!flag27)
							{
								tP_GothMissile_Projectile2 = (TP_GothMissile_Projectile)projectile3;
							}
							if ((object)tP_GothMissile_Projectile2 == null)
							{
								return;
							}
							if (CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 != null)
							{
								tP_GothMissile_Projectile2.SetDirection(vector5);
								return;
							}
							goto IL_03f9;
							IL_03f9:
							throw new NullReferenceException();
						};
						object obj14 = flag17 * currentWeaponData3._003CrepeatInterval_003Ek__BackingField;
						float duration = (float)obj14 * 0.001f;
						Timer lastShotTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
						flag18 = false;
						num3 = unchecked((nint)null);
					}
					goto IL_07a9;
					IL_0869:
					bool flag20 = obj13 == null;
					TP_GothMissile_Projectile tP_GothMissile_Projectile = null;
					if (!flag20)
					{
						tP_GothMissile_Projectile = (TP_GothMissile_Projectile)projectile2;
					}
					bool flag21 = (object)tP_GothMissile_Projectile == null;
					num3 = (nint)typeof(TP_GothMissile_Projectile);
					if (!flag21)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_GothMissile_Weapon+<>c__DisplayClass8_0)+2C]");
						num13 = 0f;
						tP_GothMissile_Projectile.SetDirection((Vector2)(nint)intPtr);
						num3 = unchecked((nint)null);
					}
					goto IL_07a9;
					IL_07a9:
					flag17 = (byte)((flag17 ? 1u : 0u) + 1u) != 0;
				}
				while ((nint)vector2 > (flag17 ? 1 : 0));
			}
			if (!skipTriggers)
			{
				((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
			}
			return;
		}
		goto IL_081c;
		IL_081c:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public TP_GothMissile_Weapon()
	{
		//IL_0028: Expected O, but got I
		//IL_0038: Expected O, but got I
		//IL_0092: Expected O, but got I
		//IL_0fc3: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0ffc: Expected O, but got I
		//IL_0163: Expected O, but got I
		//IL_1035: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_107e: Expected O, but got I
		//IL_0233: Expected O, but got I
		//IL_10c7: Expected O, but got I
		//IL_029b: Expected O, but got I
		//IL_1110: Expected O, but got I
		//IL_0303: Expected O, but got I
		//IL_1159: Expected O, but got I
		//IL_036b: Expected O, but got I
		//IL_11a2: Expected O, but got I
		//IL_03d3: Expected O, but got I
		//IL_11eb: Expected O, but got I
		//IL_043b: Expected O, but got I
		//IL_1234: Expected O, but got I
		//IL_04a3: Expected O, but got I
		//IL_127d: Expected O, but got I
		//IL_050b: Expected O, but got I
		//IL_12c6: Expected O, but got I
		//IL_0573: Expected O, but got I
		//IL_130f: Expected O, but got I
		//IL_05db: Expected O, but got I
		//IL_1358: Expected O, but got I
		//IL_0643: Expected O, but got I
		//IL_13a1: Expected O, but got I
		//IL_06ab: Expected O, but got I
		//IL_13ea: Expected O, but got I
		//IL_0713: Expected O, but got I
		//IL_1433: Expected O, but got I
		//IL_077b: Expected O, but got I
		//IL_147c: Expected O, but got I
		//IL_07e3: Expected O, but got I
		//IL_14c5: Expected O, but got I
		//IL_084b: Expected O, but got I
		//IL_150e: Expected O, but got I
		//IL_08b3: Expected O, but got I
		//IL_08f9: Expected O, but got I
		//IL_0963: Expected O, but got I
		//IL_1566: Expected O, but got I
		//IL_1589: Expected O, but got I
		//IL_09cc: Expected O, but got I
		//IL_159e: Expected O, but got I
		//IL_0a35: Expected O, but got I
		//IL_15d5: Expected O, but got I
		//IL_0a9d: Expected O, but got I
		//IL_160e: Expected O, but got I
		//IL_0b05: Expected O, but got I
		//IL_1647: Expected O, but got I
		//IL_1669: Expected O, but got F4
		//IL_0b6d: Expected O, but got I
		//IL_168d: Expected O, but got I
		//IL_16b0: Expected O, but got I
		//IL_0bd6: Expected O, but got I
		//IL_16c5: Expected O, but got I
		//IL_0c3f: Expected O, but got I
		//IL_16fc: Expected O, but got I
		//IL_0ca7: Expected O, but got I
		//IL_1735: Expected O, but got I
		//IL_1757: Expected O, but got F4
		//IL_0d0f: Expected O, but got I
		//IL_177c: Expected O, but got I
		//IL_0d77: Expected O, but got I
		//IL_17b5: Expected O, but got I
		//IL_0ddf: Expected O, but got I
		//IL_17ee: Expected O, but got I
		//IL_1810: Expected O, but got F4
		//IL_0e47: Expected O, but got I
		//IL_1851: Expected O, but got F4
		//IL_0ea9: Expected O, but got F4
		//IL_0ef9: Expected O, but got I
		//IL_0f1b: Expected O, but got F4
		//IL_0f84: Expected O, but got I
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(init);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = init;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj4 = 0;
		float item = unitX + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rdx_v5+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(item);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj5 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj6 = 0;
		float item2 = unitX + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rdx_v6+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(item2);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj7 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj8 = 0;
		float num4 = unitX + unitX;
		float item3 = num4 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rdx_v7+18]");
		if (num5 >= 0)
		{
			list.AddWithResize(item3);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj9 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj10 = 0;
		float num6 = unitX + unitX;
		float item4 = num6 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v8+18]");
		if (num7 >= 0)
		{
			list.AddWithResize(item4);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj11 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj12 = 0;
		float num8 = unitX + unitX;
		float item5 = num8 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rdx_v9+18]");
		if (num9 >= 0)
		{
			list.AddWithResize(item5);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj13 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj14 = 0;
		float num10 = unitX * 3f;
		float item6 = num10 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rdx_v10+18]");
		if (num11 >= 0)
		{
			list.AddWithResize(item6);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj15 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj16 = 0;
		float num12 = unitX * 3f;
		float item7 = num12 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rdx_v11+18]");
		if (num13 >= 0)
		{
			list.AddWithResize(item7);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj17 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj18 = 0;
		float num14 = unitX * 3f;
		float item8 = num14 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdx_v12+18]");
		if (num15 >= 0)
		{
			list.AddWithResize(item8);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj19 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj20 = 0;
		float num16 = unitX * 3f;
		float item9 = num16 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rdx_v13+18]");
		if (num17 >= 0)
		{
			list.AddWithResize(item9);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj21 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj22 = 0;
		float num18 = unitX * 4f;
		float item10 = num18 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v14+18]");
		if (num19 >= 0)
		{
			list.AddWithResize(item10);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj23 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj24 = 0;
		float num20 = unitX * 4f;
		float item11 = num20 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v15+18]");
		if (num21 >= 0)
		{
			list.AddWithResize(item11);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj25 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj26 = 0;
		float num22 = unitX * 4f;
		float item12 = num22 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ rdx_v16+18]");
		if (num23 >= 0)
		{
			list.AddWithResize(item12);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj27 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj28 = 0;
		float num24 = unitX * 4f;
		float item13 = num24 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rdx_v17+18]");
		if (num25 >= 0)
		{
			list.AddWithResize(item13);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj29 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj30 = 0;
		float num26 = unitX * 4f;
		float item14 = num26 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rdx_v18+18]");
		if (num27 >= 0)
		{
			list.AddWithResize(item14);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj31 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj32 = 0;
		float num28 = unitX * 5f;
		float item15 = num28 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v19+18]");
		if (num29 >= 0)
		{
			list.AddWithResize(item15);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj33 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj34 = 0;
		float num30 = unitX * 5f;
		float item16 = num30 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v20+18]");
		if (num31 >= 0)
		{
			list.AddWithResize(item16);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj35 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj36 = 0;
		float num32 = unitX * 5f;
		float item17 = num32 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v21+18]");
		if (num33 >= 0)
		{
			list.AddWithResize(item17);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj37 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj38 = 0;
		float num34 = unitX * 5f;
		float item18 = num34 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v22+18]");
		if (num35 >= 0)
		{
			list.AddWithResize(item18);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj39 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj40 = 0;
		float num36 = unitX * 5f;
		float item19 = num36 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rdx_v23+18]");
		if (num37 >= 0)
		{
			list.AddWithResize(item19);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj41 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj42 = 0;
		float num38 = unitX * 5f;
		float item20 = num38 + init;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v24+18]");
		if (num39 >= 0)
		{
			list.AddWithResize(item20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj43 = (nint)0 + (nint)1;
		}
		offsetsX = list;
		List<float> list2 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj44 = 0;
		float item21 = unitY * 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num40 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdx_v28+18]");
		if (num40 >= 0)
		{
			list2.AddWithResize(item21);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj45 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rdx_v29+18]");
		if (num41 >= 0)
		{
			list2.AddWithResize(unitY);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = unitY;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item22 = unitY ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v30+18]");
		if (num42 >= 0)
		{
			list2.AddWithResize(item22);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj50 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item23 = unitY * 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rdx_v31+18]");
		if (num43 >= 0)
		{
			list2.AddWithResize(item23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj52 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item24 = unitY + unitY;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num44 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdx_v32+18]");
		if (num44 >= 0)
		{
			list2.AddWithResize(item24);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj54 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		object obj56 = unitY ^ -0f;
		float item25 = (float)obj56 + (float)obj56;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v33+18]");
		if (num45 >= 0)
		{
			list2.AddWithResize(item25);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj57 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj58 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num46 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v34+18]");
		if (num46 >= 0)
		{
			list2.AddWithResize(unitY);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = unitY;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item26 = unitY ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v35+18]");
		if (num47 >= 0)
		{
			list2.AddWithResize(item26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj62 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item27 = unitY * 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v36+18]");
		if (num48 >= 0)
		{
			list2.AddWithResize(item27);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj64 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		object obj66 = unitY ^ -0f;
		float item28 = (float)obj66 * 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v37+18]");
		if (num49 >= 0)
		{
			list2.AddWithResize(item28);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj67 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj68 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item29 = unitY * 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num50 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v38+18]");
		if (num50 >= 0)
		{
			list2.AddWithResize(item29);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj69 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj70 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item30 = unitY + unitY;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdx_v39+18]");
		if (num51 >= 0)
		{
			list2.AddWithResize(item30);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj71 = (nint)0 + (nint)1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj72 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		object obj73 = unitY ^ -0f;
		float item31 = (float)obj73 + (float)obj73;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num52 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdx_v40+18]");
		if (num52 >= 0)
		{
			list2.AddWithResize(item31);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj74 = (nint)0 + (nint)1;
		}
		float item32 = unitY * 4f;
		list2.Add(item32);
		object obj75 = unitY ^ -0f;
		float item33 = (float)obj75 * 4f;
		list2.Add(item33);
		list2.Add(unitY);
		list2.Add(unitY ^ -0f);
		list2.Add(unitY * 3f);
		list2.Add((float)(object)(unitY ^ -0f) * 3f);
		list2.Add(unitY * 5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj76 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		float item34 = (float)(object)(unitY ^ -0f) * 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v41+18]");
		if (num53 >= 0)
		{
			list2.AddWithResize(item34);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1973 @ rax_v51 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj77 = (nint)0 + (nint)1;
		}
		offsetsY = list2;
		base._002Ector();
	}
}
