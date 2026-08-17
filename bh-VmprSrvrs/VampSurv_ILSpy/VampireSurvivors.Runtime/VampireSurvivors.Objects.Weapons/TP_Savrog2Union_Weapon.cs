using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Savrog2Union_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int localIndex;

		public TP_Savrog2Union_Weapon _003C_003E4__this;

		internal void _003CInternalUpdate_003Eb__0()
		{
			//IL_0107: Expected O, but got I4
			//IL_013c: Expected O, but got I4
			//IL_0154->IL0159: Incompatible stack heights: 3 vs 0
			//IL_00a6->IL0159: Incompatible stack heights: 3 vs 0
			//IL_00b9->IL0159: Incompatible stack heights: 3 vs 0
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float detune = (float)localIndex * 4.294967E+09f;
			soundConfig.Detune = detune;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 200f, 12, time);
			Dictionary<int, GameObject>.Enumerator enumerator = default(Dictionary<int, GameObject>.Enumerator);
			GameObject gameObject = default(GameObject);
			while (enumerator.MoveNext())
			{
				bool flag = (object)gameObject == null;
				TP_Savrog2Union_Projectile component = gameObject.GetComponent<TP_Savrog2Union_Projectile>();
				bool flag2 = (object)component == null;
				bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)component).m_CachedPtr);
				if (obj != null && ((Projectile)component)._indexInWeapon == localIndex)
				{
					component.Yeet();
				}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public TP_Savrog2Union_Weapon _003C_003E4__this;

		public Vector2 position1;

		public Vector2 position2;

		public TP_Savrog2Union_Projectile p0;

		public TP_Savrog2Union_Projectile p1;

		public TP_Savrog2Union_Projectile p2;

		public Vector2 position0;

		public TP_Savrog2Union_Spinning_Projectile sp1;

		public TP_Savrog2Union_Spinning_Projectile sp2;
	}

	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals1;

		internal unsafe void _003CFire_003Eb__0()
		{
			//IL_0f4e: Expected O, but got I4
			//IL_00ee: Expected O, but got I
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0209: Expected O, but got I
			//IL_03f6: Expected I, but got O
			//IL_0404: Expected I, but got O
			//IL_0414: Expected O, but got I
			//IL_0494: Expected O, but got I4
			//IL_0450: Expected O, but got I
			//IL_0486: Expected O, but got I4
			//IL_0578: Expected I, but got O
			//IL_0586: Expected I, but got O
			//IL_0596: Expected O, but got I
			//IL_0616: Expected O, but got I4
			//IL_05d2: Expected O, but got I
			//IL_0608: Expected O, but got I4
			//IL_06fb: Expected I, but got O
			//IL_0709: Expected I, but got O
			//IL_0719: Expected O, but got I
			//IL_0799: Expected O, but got I4
			//IL_0755: Expected O, but got I
			//IL_078b: Expected O, but got I4
			//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f4: Expected O, but got Unknown
			//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0af1: Expected O, but got Unknown
			//IL_0bc3: Expected O, but got I
			//IL_0bf9: Expected I, but got O
			//IL_0c07: Expected I, but got O
			//IL_0c17: Expected O, but got I
			//IL_0c97: Expected O, but got I4
			//IL_0c53: Expected O, but got I
			//IL_0c89: Expected O, but got I4
			//IL_0dd3: Expected I, but got O
			//IL_0de1: Expected I, but got O
			//IL_0df1: Expected O, but got I
			//IL_0e71: Expected O, but got I4
			//IL_0e2d: Expected O, but got I
			//IL_0e63: Expected O, but got I4
			//IL_0084->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_00b3->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_00d8->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0116->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0145->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_019f->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_01ce->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_01f3->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0231->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0260->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_02de->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_030d->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_032f->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_036a->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0399->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_04ca->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_04f9->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_051b->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_064c->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_067b->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_069d->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_07d0->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0939->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_083c->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_086b->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0a0a->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_08a8->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0a39->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_08ca->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0a5b->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_09a6->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0a96->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_09c8->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0ac5->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0b27->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0b56->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0b75->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0b9a->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0ccd->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_10af->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0d3e->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0d5d->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0d7f->IL0eee: Incompatible stack heights: 1 vs 0
			//IL_0ea7->IL0eee: Incompatible stack heights: 1 vs 0
			_003C_003Ec__DisplayClass24_0 obj = CS_0024_003C_003E8__locals1;
			object obj6 = default(object);
			_003C_003Ec__DisplayClass24_0 obj8;
			GameObject gameObject4;
			float2 pos = default(float2);
			GameObject p;
			object obj12;
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
					GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 != null)
					{
						IntPtr cachedPtr = ((UnityEngine.Object)gameObject2).m_CachedPtr;
						if (((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v13 (System.IntPtr)+58]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v13 (System.IntPtr)+58]");
								float2 position = ((ArcadeSprite)0).position;
								_003C_003Ec__DisplayClass24_0 obj3 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon = obj3._003C_003E4__this;
									if ((object)obj3._003C_003E4__this != null)
									{
										object obj4 = (object)position + (object)tP_Savrog2Union_Weapon.radiusOffset90;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v18 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
										object obj5 = obj6 + 0;
										GameObject gameObject3 = (GameObject)(object)CS_0024_003C_003E8__locals1;
										if (CS_0024_003C_003E8__locals1 != null)
										{
											IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject3).m_CachedPtr;
											if (((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v19 (System.IntPtr)+58]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v19 (System.IntPtr)+58]");
													float2 position2 = ((ArcadeSprite)0).position;
													_003C_003Ec__DisplayClass24_0 obj7 = CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals1 != null)
													{
														TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon2 = obj7._003C_003E4__this;
														if ((object)obj7._003C_003E4__this != null)
														{
															float num = (float)tP_Savrog2Union_Weapon2.radiusOffset90 * -1f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v16 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
															float num2 = 0f * -1f;
															float num3 = (float)position2 + num;
															float num4 = (float)obj6 + num2;
															obj8 = CS_0024_003C_003E8__locals1;
															if (CS_0024_003C_003E8__locals1 != null)
															{
																TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon3 = obj8._003C_003E4__this;
																if ((object)obj8._003C_003E4__this != null && (object)((Equipment)tP_Savrog2Union_Weapon3)._003COwner_003Ek__BackingField != null)
																{
																	float2 position3 = ((Equipment)tP_Savrog2Union_Weapon3)._003COwner_003Ek__BackingField.position;
																	_003C_003Ec__DisplayClass24_0 obj9 = CS_0024_003C_003E8__locals1;
																	if (CS_0024_003C_003E8__locals1 != null)
																	{
																		TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon4 = obj9._003C_003E4__this;
																		if ((object)obj9._003C_003E4__this != null)
																		{
																			gameObject4 = (GameObject)(object)obj8._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Savrog2Union_Weapon4._targetTransform);
																			if ((object)gameObject4 == null)
																			{
																				p = null;
																				goto IL_0f6b;
																			}
																			nint num5 = (nint)gameObject4;
																			nint num6 = (nint)typeof(TP_Savrog2Union_Projectile);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
																			object obj10 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v46 (Il2CppClass<UnityEngine.GameObject>)+130]");
																			nint num7 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
																			if (num7 >= 0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v46 (Il2CppClass<UnityEngine.GameObject>)+C8]");
																				object obj11 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v133+FFFFFFF8+v978 @ rax_v128*8]");
																				if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
																				{
																					obj12 = 1;
																					goto IL_0f7d;
																				}
																			}
																			obj12 = 0;
																			goto IL_0f7d;
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
						}
					}
				}
			}
			goto IL_0eee;
			IL_0fd3:
			_003C_003Ec__DisplayClass24_0 obj13;
			GameObject p2;
			obj13.p2 = (TP_Savrog2Union_Projectile)(object)p2;
			_003C_003Ec__DisplayClass24_0 obj14 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Projectile p3 = obj14.p1;
				if ((object)obj14.p1 == null || ((UnityEngine.Object)p3).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0915;
				}
				_003C_003Ec__DisplayClass24_0 obj15 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					TP_Savrog2Union_Projectile p4 = obj15.p1;
					if ((object)obj15.p1 != null)
					{
						p4._isInverted = false;
						Weapon weapon = ((Projectile)p4)._weapon;
						if ((object)((Projectile)p4)._weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							Vector2 scaledVelocity = ((Equipment)weapon)._003COwner_003Ek__BackingField.ScaledVelocity;
							Vector2 vector = (Vector2)(obj15.p1 + 272);
							p4._previousVector = scaledVelocity;
							((Vector2*)vector)->Normalize();
							goto IL_0915;
						}
					}
				}
			}
			goto IL_0eee;
			IL_10c6:
			object obj16;
			bool flag2 = obj16 == null;
			GameObject sp = null;
			Projectile projectile;
			if (!flag2)
			{
				sp = (GameObject)(object)projectile;
			}
			goto IL_10b4;
			IL_0f6b:
			obj8.p0 = (TP_Savrog2Union_Projectile)(object)p;
			_003C_003Ec__DisplayClass24_0 obj17 = CS_0024_003C_003E8__locals1;
			GameObject gameObject5;
			GameObject p5;
			object obj20;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon5 = obj17._003C_003E4__this;
				if ((object)obj17._003C_003E4__this != null && (object)obj17._003C_003E4__this != null)
				{
					gameObject5 = (GameObject)(object)obj17._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Savrog2Union_Weapon5._targetTransform);
					if ((object)gameObject5 == null)
					{
						p5 = null;
						goto IL_0f9f;
					}
					nint num8 = (nint)gameObject5;
					nint num9 = (nint)typeof(TP_Savrog2Union_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ r8_v41 (Il2CppClass<UnityEngine.GameObject>)+130]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					if (num10 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ r8_v41 (Il2CppClass<UnityEngine.GameObject>)+C8]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rax_v122+FFFFFFF8+v1139 @ rax_v117*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
						{
							obj20 = 1;
							goto IL_0fb1;
						}
					}
					obj20 = 0;
					goto IL_0fb1;
				}
			}
			goto IL_0eee;
			IL_0f9f:
			obj17.p1 = (TP_Savrog2Union_Projectile)(object)p5;
			obj13 = CS_0024_003C_003E8__locals1;
			GameObject gameObject6;
			object obj23;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon6 = obj13._003C_003E4__this;
				if ((object)obj13._003C_003E4__this != null && (object)obj13._003C_003E4__this != null)
				{
					gameObject6 = (GameObject)(object)obj13._003C_003E4__this.FireOneProjectile(pos, localIndex, tP_Savrog2Union_Weapon6._targetTransform);
					if ((object)gameObject6 == null)
					{
						p2 = null;
						goto IL_0fd3;
					}
					nint num11 = (nint)gameObject6;
					nint num12 = (nint)typeof(TP_Savrog2Union_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1298 @ r8_v36 (Il2CppClass<UnityEngine.GameObject>)+130]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					if (num13 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1298 @ r8_v36 (Il2CppClass<UnityEngine.GameObject>)+C8]");
						object obj22 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1353 @ rax_v111+FFFFFFF8+v1300 @ rax_v106*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
						{
							obj23 = 1;
							goto IL_0fe5;
						}
					}
					obj23 = 0;
					goto IL_0fe5;
				}
			}
			goto IL_0eee;
			IL_1069:
			object obj24;
			bool flag3 = obj24 == null;
			GameObject sp2 = null;
			Projectile projectile2;
			if (!flag3)
			{
				sp2 = (GameObject)(object)projectile2;
			}
			goto IL_1057;
			IL_10b4:
			_003C_003Ec__DisplayClass24_0 obj25;
			obj25.sp2 = (TP_Savrog2Union_Spinning_Projectile)(object)sp;
			_003C_003Ec__DisplayClass24_0 obj26 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Spinning_Projectile sp3 = obj26.sp2;
				if ((object)obj26.sp2 != null)
				{
					sp3._isInverted = true;
				}
				return;
			}
			goto IL_0eee;
			IL_0915:
			_003C_003Ec__DisplayClass24_0 obj27 = CS_0024_003C_003E8__locals1;
			_003C_003Ec__DisplayClass24_0 obj32;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Projectile p6 = obj27.p2;
				if ((object)obj27.p2 != null && ((UnityEngine.Object)p6).m_CachedPtr != (IntPtr)0)
				{
					_003C_003Ec__DisplayClass24_0 obj28 = CS_0024_003C_003E8__locals1;
					if (CS_0024_003C_003E8__locals1 == null || (object)obj28.p2 == null)
					{
						goto IL_0eee;
					}
					obj28.p2.SetInversion(isInverted: true);
				}
				_003C_003Ec__DisplayClass24_0 obj29 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon7 = obj29._003C_003E4__this;
					if ((object)obj29._003C_003E4__this != null && (object)((Equipment)tP_Savrog2Union_Weapon7)._003COwner_003Ek__BackingField != null)
					{
						float2 position4 = ((Equipment)tP_Savrog2Union_Weapon7)._003COwner_003Ek__BackingField.position;
						_003C_003Ec__DisplayClass24_0 obj30 = CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon8 = obj30._003C_003E4__this;
							if ((object)obj30._003C_003E4__this != null)
							{
								Vector2 position5 = (Vector2)((object)position4 + (object)tP_Savrog2Union_Weapon8.RadiusOffset);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v53 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
								object obj31 = obj6 + 0;
								obj29.position0 = position5;
								obj32 = CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals1 != null)
								{
									Weapon weapon2 = obj32._003C_003E4__this;
									if ((object)obj32._003C_003E4__this != null && CS_0024_003C_003E8__locals1 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v54 (VampireSurvivors.Objects.Weapons.Weapon)+1A8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v54 (VampireSurvivors.Objects.Weapons.Weapon)+1A8]");
											projectile2 = ((BulletPool)0).SpawnAt(pos, obj32._003C_003E4__this, localIndex);
											if ((object)projectile2 == null)
											{
												sp2 = null;
												goto IL_1057;
											}
											nint num14 = (nint)projectile2;
											nint num15 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
											object obj33 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1678 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
											nint num16 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
											if (num16 >= 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1678 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
												object obj34 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1733 @ rax_v83+FFFFFFF8+v1680 @ rax_v78*8]");
												if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
												{
													obj24 = 1;
													goto IL_1069;
												}
											}
											obj24 = 0;
											goto IL_1069;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0eee;
			IL_1057:
			obj32.sp1 = (TP_Savrog2Union_Spinning_Projectile)(object)sp2;
			_003C_003Ec__DisplayClass24_0 obj35 = CS_0024_003C_003E8__locals1;
			if (CS_0024_003C_003E8__locals1 != null)
			{
				TP_Savrog2Union_Spinning_Projectile sp4 = obj35.sp1;
				if ((object)obj35.sp1 != null)
				{
					sp4._isInverted = false;
				}
				obj25 = CS_0024_003C_003E8__locals1;
				if (CS_0024_003C_003E8__locals1 != null)
				{
					TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon9 = obj25._003C_003E4__this;
					if ((object)obj25._003C_003E4__this != null && CS_0024_003C_003E8__locals1 != null && tP_Savrog2Union_Weapon9._spinningPool != null)
					{
						projectile = tP_Savrog2Union_Weapon9._spinningPool.SpawnAt(pos, obj25._003C_003E4__this, localIndex);
						bool flag4 = (object)projectile == null;
						sp = null;
						if (flag4)
						{
							goto IL_10b4;
						}
						nint num17 = (nint)projectile;
						nint num18 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
						object obj36 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1846 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
						if (num19 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1846 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj37 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1901 @ rax_v72+FFFFFFF8+v1848 @ rax_v68*8]");
							if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
							{
								obj16 = 1;
								goto IL_10c6;
							}
						}
						obj16 = 0;
						goto IL_10c6;
					}
				}
			}
			goto IL_0eee;
			IL_0fb1:
			bool flag5 = obj20 == null;
			p5 = null;
			if (!flag5)
			{
				p5 = gameObject5;
			}
			goto IL_0f9f;
			IL_0eee:
			throw new NullReferenceException();
			IL_0fe5:
			bool flag6 = obj23 == null;
			p2 = null;
			if (!flag6)
			{
				p2 = gameObject6;
			}
			goto IL_0fd3;
			IL_0f7d:
			bool flag7 = obj12 == null;
			p = null;
			if (!flag7)
			{
				p = gameObject4;
			}
			goto IL_0f6b;
		}
	}

	private Projectile _SpinningProjectilePrefab;

	public Color[] _UnionSpriteColours;

	public Color[] _UnionTrailColours;

	private Vector2 radiusOffset90;

	private PhaserSprite clone1;

	private PhaserSprite clone2;

	public uint[] _cloneTint;

	private float _timeStopped;

	private Vector2 _previousVector;

	public Vector2 RadiusOffset;

	private BulletPool _spinningPool;

	private const float Mul = 16.666666f;

	private bool _003CIsUnion_003Ek__BackingField;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	public bool IsUnion
	{
		get
		{
			return _003CIsUnion_003Ek__BackingField;
		}
		set
		{
			_003CIsUnion_003Ek__BackingField = value;
		}
	}

	protected override void OnStart()
	{
		base.OnStart();
		BulletPool spinningPool = new BulletPool(_SpinningProjectilePrefab);
		_spinningPool = spinningPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		ArcadePhysicsCallback collideCallback = base.OnBulletOverlapsEnemy;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_spinningPool, core.Enemies, collideCallback, processCallback, callbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			ArcadePhysicsCallback collideCallback2 = base.OnBulletOverlapsDestructible;
			Collider collider2 = physics2.add.overlap(_spinningPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
			GenerateParticleSystem();
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_explosionType = WeaponType.FIREEXPLOSION;
		base.InitWeapon(characterController, weaponType);
		BulletPool projectilePool = _projectilePool;
		projectilePool.IsUncapped = true;
		MakeOwnerClones();
	}

	private Vector2 Rotate45(Vector2 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	private Vector2 Rotate90(Vector2 v)
	{
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_00a6: Invalid comparison between I4 and F4
		//IL_00f1: Expected F4, but got I4
		//IL_070c: Expected O, but got F4
		//IL_0149: Invalid comparison between I4 and F4
		//IL_0194: Expected F4, but got I4
		//IL_07b3: Expected O, but got F4
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_052e: Invalid comparison between F4 and I4
		//IL_05c6: Expected I, but got O
		//IL_05dc: Expected O, but got I
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Expected O, but got Unknown
		//IL_0653: Expected I, but got O
		//IL_07fa: Expected O, but got I4
		//IL_0811: Expected I, but got I8
		//IL_0890: Invalid comparison between F4 and I4
		//IL_063c: Expected I, but got I8
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = default(object);
		object obj = obj2 ^ 0;
		float num = (float)obj * 0.75f;
		object obj3 = default(object);
		float num2 = (float)obj3 * 0.75f;
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		VampireSurvivors.Objects.Characters.CharacterController characterController3 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		object obj4 = characterController2._currentDirectionRaw * characterController2._currentDirectionRaw;
		float num3 = (float)obj4 * 0.25f;
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
		float num4 = num - (float)radiusOffset90;
		float num5 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		float num6 = num5 - 0f;
		float num7 = num4 * num3;
		float num8 = num6 * num3;
		float num9 = num7 + (float)radiusOffset90;
		float num10 = num8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		float num11 = num10 + 0f;
		radiusOffset90 = (Vector2)num9;
		float num12 = (float)obj3 * 0.75f;
		float num13 = (float)obj2 * 0.75f;
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		VampireSurvivors.Objects.Characters.CharacterController characterController5 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		object obj5 = characterController4._currentDirectionRaw * characterController4._currentDirectionRaw;
		float num14 = (float)obj5 * 0.25f;
		if (!(0f > num14))
		{
			if (num14 > 1f)
			{
				num14 = 1f;
			}
		}
		else
		{
			num14 = 0f;
		}
		float num15 = num12 - (float)RadiusOffset;
		float num16 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
		float num17 = num16 - 0f;
		float num18 = num15 * num14;
		float num19 = num17 * num14;
		float num20 = num18 + (float)RadiusOffset;
		float num21 = num19;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
		float num22 = num21 + 0f;
		RadiusOffset = (Vector2)num20;
		float deltaTime = PauseSystem.DeltaTime;
		float num23 = deltaTime * 1000f;
		float num24 = (base._003CTotalTime_003Ek__BackingField = num23 + base._003CTotalTime_003Ek__BackingField);
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float num25 = num23 / 16.666666f;
		float num26 = frameWalk * 100f;
		float num27 = num26 * num25;
		float num28 = (base._003CTotalTime_003Ek__BackingField = num27 + num24);
		float num29 = base.PInterval();
		if (!(num28 < frameWalk))
		{
			base._003CTotalTime_003Ek__BackingField = 0f;
			base.Fire();
		}
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		object obj6 = obj2 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num30 = (float)radiusOffset90 * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		float num31 = 0f * -1f;
		float num32 = (float)obj2 + num31;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 position3 = clone1.position;
		float2 position4 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		bool flag = (byte)(position3 < position4) != 0;
		object obj7 = position3 - position4;
		bool flag2 = obj7 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flipX = flag4 & flag3;
		PhaserSprite phaserSprite = clone1.setFlipX(flipX);
		float2 position5 = clone2.position;
		float2 position6 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		bool flag5 = (byte)(position5 < position6) != 0;
		object obj8 = position5 - position6;
		bool flag6 = obj8 == null;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		bool flipX2 = flag8 & flag7;
		PhaserSprite phaserSprite2 = clone2.setFlipX(flipX2);
		float2 position7 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		_pfxManager.EmitParticleAt(pos, 10);
		Vector2 scaledVelocity = ((Equipment)this)._003COwner_003Ek__BackingField.ScaledVelocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187462045h\"");
		if ((object)scaledVelocity == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187462045h\"");
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187461DBAh\"");
				if ((object)_previousVector == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+198]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187461DBAh\"");
					if (flag9)
					{
						return;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
				object obj9 = default(object);
				float num33 = (_timeStopped = (float)obj9 + _timeStopped);
				if (num33 < 0.16f)
				{
					return;
				}
				_previousVector = scaledVelocity;
				_timeStopped = 0f;
				float num34 = base.PAmount();
				if (!(num33 > 0f))
				{
					return;
				}
				bool flag10 = false;
				bool flag11 = false;
				float num38;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					_003C_003Ec__DisplayClass22_0 obj10 = new _003C_003Ec__DisplayClass22_0();
					obj10._003C_003E4__this = this;
					obj10.localIndex = (flag11 ? 1 : 0);
					Action action = null;
					nint num35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r10_v4 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass22_0._003CInternalUpdate_003Eb__0);
					((Delegate)action).m_target = obj10;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r10_v4 (Il2CppMethodInfo)+4C]");
					object obj11 = (nint)0 >> 4;
					object obj12 = obj11 & 1;
					nint num36;
					if (obj12 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ r10_v4 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num36 = unchecked((nint)6447293664L);
							goto IL_07f1;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num36 = ((Delegate)action).method_ptr;
					goto IL_07f1;
					IL_07f1:
					object obj13 = 24;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float num37 = (float)(flag10 ? 1 : 0) + 8f;
					num38 = num37 * 0.001f;
					Timer timer = Timers.Register(num38, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					flag11 = (byte)((flag11 ? 1u : 0u) + 1u) != 0;
					flag10 = (byte)((flag10 ? 1u : 0u) + 64u) != 0;
					float num39 = base.PAmount();
				}
				while (num38 > (float)(flag11 ? 1 : 0));
				return;
			}
		}
		_previousVector = scaledVelocity;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_0110: Expected O, but got F4
		//IL_012f: Expected O, but got F4
		//IL_0165: Expected I, but got O
		//IL_0173: Expected I, but got O
		//IL_0183: Expected O, but got I
		//IL_0203: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_01f5: Expected O, but got I4
		//IL_026c: Expected O, but got F4
		//IL_02a3: Expected I, but got O
		//IL_02b1: Expected I, but got O
		//IL_02c1: Expected O, but got I
		//IL_0341: Expected O, but got I4
		//IL_02fd: Expected O, but got I
		//IL_0333: Expected O, but got I4
		//IL_03bb: Expected O, but got F4
		//IL_03f1: Expected I, but got O
		//IL_03ff: Expected I, but got O
		//IL_040f: Expected O, but got I
		//IL_048f: Expected O, but got I4
		//IL_044b: Expected O, but got I
		//IL_04b7: Expected O, but got F4
		//IL_0481: Expected O, but got I4
		//IL_04ed: Expected I, but got O
		//IL_04fb: Expected I, but got O
		//IL_050b: Expected O, but got I
		//IL_058b: Expected O, but got I4
		//IL_0547: Expected O, but got I
		//IL_05ad: Expected F4, but got I
		//IL_05c3: Expected O, but got F4
		//IL_057d: Expected O, but got I4
		//IL_05f9: Expected I, but got O
		//IL_0607: Expected I, but got O
		//IL_0617: Expected O, but got I
		//IL_0697: Expected O, but got I4
		//IL_0653: Expected O, but got I
		//IL_0689: Expected O, but got I4
		//IL_10dc: Expected O, but got F4
		//IL_06e6: Expected O, but got F4
		//IL_110b: Expected F4, but got O
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1149: Expected O, but got Unknown
		//IL_1152: Invalid comparison between O and F4
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
		//IL_0746: Expected O, but got Unknown
		//IL_07b3: Expected F4, but got O
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c5: Expected O, but got Unknown
		//IL_08ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f3: Expected O, but got Unknown
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Expected O, but got Unknown
		//IL_0840: Expected O, but got F4
		//IL_0f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f61: Expected O, but got Unknown
		//IL_0a18: Expected I, but got O
		//IL_0a26: Expected I, but got O
		//IL_0a36: Expected O, but got I
		//IL_0964: Expected I, but got O
		//IL_0974: Expected O, but got I
		//IL_137e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1383: Expected O, but got Unknown
		//IL_138b: Invalid comparison between F4 and I4
		//IL_0ab6: Expected O, but got I4
		//IL_09f4: Expected O, but got I4
		//IL_0a72: Expected O, but got I
		//IL_11b3: Expected O, but got I4
		//IL_09b0: Expected O, but got I
		//IL_0ada: Expected I, but got O
		//IL_0ae8: Expected I, but got O
		//IL_0af8: Expected O, but got I
		//IL_0aa8: Expected O, but got I4
		//IL_0b78: Expected O, but got I4
		//IL_09e6: Expected O, but got I4
		//IL_0b34: Expected O, but got I
		//IL_0b6a: Expected O, but got I4
		//IL_0c87: Expected O, but got F4
		//IL_0cc2: Expected I, but got O
		//IL_0cd0: Expected I, but got O
		//IL_0ce0: Expected O, but got I
		//IL_0d60: Expected O, but got I4
		//IL_0d1c: Expected O, but got I
		//IL_12fb: Expected F4, but got I
		//IL_0d52: Expected O, but got I4
		//IL_0d99: Expected O, but got F4
		//IL_0dd4: Expected I, but got O
		//IL_0de2: Expected I, but got O
		//IL_0df2: Expected O, but got I
		//IL_0e72: Expected O, but got I4
		//IL_0e2e: Expected O, but got I
		//IL_13cd: Expected O, but got I4
		//IL_0e7f: Expected I4, but got O
		//IL_0e64: Expected O, but got I4
		_003C_003Ec__DisplayClass24_0 obj = new _003C_003Ec__DisplayClass24_0();
		obj._003C_003E4__this = this;
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 position2 = (Vector2)((object)position + (object)RadiusOffset);
		float num2 = default(float);
		float num = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
		float num3 = num + 0f;
		obj.position0 = position2;
		float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 position4 = (Vector2)((object)position3 + (object)radiusOffset90);
		float num4 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		float num5 = num4 + 0f;
		obj.position1 = position4;
		float2 position5 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float num6 = (float)radiusOffset90 * -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
		float num7 = 0f * -1f;
		float num8 = (float)position5 + num6;
		float num9 = num2 + num7;
		obj.position2 = (Vector2)num8;
		float num10 = default(float);
		Projectile projectile = _spinningPool.SpawnAt((float2)num10, this);
		Projectile sp;
		if ((object)projectile == null)
		{
			sp = null;
			goto IL_0fb6;
		}
		nint num11 = (nint)projectile;
		nint num12 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rdx_v76 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
		object obj4;
		if (num13 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v688 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v742 @ rax_v223+FFFFFFF8+v690 @ rax_v218*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
			{
				obj4 = 1;
				goto IL_0fc8;
			}
		}
		obj4 = 0;
		goto IL_0fc8;
		IL_1053:
		Projectile p;
		obj.p1 = (TP_Savrog2Union_Projectile)p;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon+<>c__DisplayClass24_0)+24]");
		float num14 = 0f;
		Projectile projectile2 = base.FireOneProjectile((Vector2)num10, 0, _targetTransform);
		Projectile p2;
		if ((object)projectile2 == null)
		{
			p2 = null;
			goto IL_1087;
		}
		nint num15 = (nint)projectile2;
		nint num16 = (nint)typeof(TP_Savrog2Union_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1388 @ rdx_v64 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ r9_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1388 @ rdx_v64 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		object obj7;
		if (num17 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ r9_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ rax_v179+FFFFFFF8+v1389 @ rax_v174*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
			{
				obj7 = 1;
				goto IL_1099;
			}
		}
		obj7 = 0;
		goto IL_1099;
		IL_1087:
		obj.p2 = (TP_Savrog2Union_Projectile)p2;
		TP_Savrog2Union_Projectile p3 = obj.p1;
		bool flag = (object)obj.p1 == null;
		float2 float5 = (float2)num10;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)p3).m_CachedPtr == (IntPtr)0;
			float5 = (float2)num10;
			if (!flag2)
			{
				TP_Savrog2Union_Projectile p4 = obj.p1;
				p4._isInverted = false;
				Weapon weapon = ((Projectile)p4)._weapon;
				Vector2 scaledVelocity = ((Equipment)weapon)._003COwner_003Ek__BackingField.ScaledVelocity;
				Vector2 vector = (Vector2)(p4 + 272);
				p4._previousVector = scaledVelocity;
				((Vector2*)vector)->Normalize();
				float5 = scaledVelocity;
				num14 = num2;
			}
		}
		TP_Savrog2Union_Projectile p5 = obj.p2;
		bool flag3 = (object)obj.p2 == null;
		float num18 = (float)float5;
		if (!flag3)
		{
			bool flag4 = ((UnityEngine.Object)p5).m_CachedPtr == (IntPtr)0;
			num18 = (float)float5;
			if (!flag4)
			{
				TP_Savrog2Union_Projectile p6 = obj.p2;
				p6._isInverted = true;
				Weapon weapon2 = ((Projectile)p6)._weapon;
				Vector2 scaledVelocity2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.ScaledVelocity;
				num14 = (float)scaledVelocity2 * -1f;
				num18 = num2 * -1f;
				Vector2 vector2 = (Vector2)(p6 + 272);
				p6._previousVector = (Vector2)num14;
				((Vector2*)vector2)->Normalize();
			}
		}
		float num19 = base.PAmount();
		bool flag5 = !(num18 > 1f);
		bool flag7 = default(bool);
		bool flag6 = flag7;
		if (!flag5)
		{
			float num20 = base.PAmount();
			bool flag8 = !(num18 > 1f);
			flag6 = flag7;
			if (!flag8)
			{
				object obj8 = obj + 40;
				object obj9 = obj + 48;
				int num21 = 1;
				object obj11 = default(object);
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				TP_Savrog2Union_Projectile tP_Savrog2Union_Projectile2 = default(TP_Savrog2Union_Projectile);
				TP_Savrog2Union_Projectile tP_Savrog2Union_Projectile3 = default(TP_Savrog2Union_Projectile);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj10 = num21 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					object obj12;
					object obj16;
					if ((nint)obj10 <= 0)
					{
						Vector2 playerPos = base.PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						bool flag9 = obj11 == null;
						obj12 = obj11;
						if (flag9)
						{
							goto IL_1169;
						}
						object obj13 = obj11;
						nint num22 = (nint)typeof(TP_Savrog2Union_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1953 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ r8_v43+130]");
						nint num23 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1953 @ rdx_v59 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
						if (num23 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1952 @ r8_v43+C8]");
							object obj15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1999 @ rax_v151+FFFFFFF8+v1954 @ rax_v146*8]");
							if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
							{
								obj16 = 1;
								goto IL_119b;
							}
						}
						obj16 = 0;
						goto IL_119b;
					}
					_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals47 = new _003C_003Ec__DisplayClass24_1();
					CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 = obj;
					CS_0024_003C_003E8__locals47.localIndex = num21;
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_0f4e: Expected O, but got I4
						//IL_00ee: Expected O, but got I
						//IL_016c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0171: Expected O, but got Unknown
						//IL_0209: Expected O, but got I
						//IL_03f6: Expected I, but got O
						//IL_0404: Expected I, but got O
						//IL_0414: Expected O, but got I
						//IL_0494: Expected O, but got I4
						//IL_0450: Expected O, but got I
						//IL_0486: Expected O, but got I4
						//IL_0578: Expected I, but got O
						//IL_0586: Expected I, but got O
						//IL_0596: Expected O, but got I
						//IL_0616: Expected O, but got I4
						//IL_05d2: Expected O, but got I
						//IL_0608: Expected O, but got I4
						//IL_06fb: Expected I, but got O
						//IL_0709: Expected I, but got O
						//IL_0719: Expected O, but got I
						//IL_0799: Expected O, but got I4
						//IL_0755: Expected O, but got I
						//IL_078b: Expected O, but got I4
						//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
						//IL_08f4: Expected O, but got Unknown
						//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
						//IL_0af1: Expected O, but got Unknown
						//IL_0bc3: Expected O, but got I
						//IL_0bf9: Expected I, but got O
						//IL_0c07: Expected I, but got O
						//IL_0c17: Expected O, but got I
						//IL_0c97: Expected O, but got I4
						//IL_0c53: Expected O, but got I
						//IL_0c89: Expected O, but got I4
						//IL_0dd3: Expected I, but got O
						//IL_0de1: Expected I, but got O
						//IL_0df1: Expected O, but got I
						//IL_0e71: Expected O, but got I4
						//IL_0e2d: Expected O, but got I
						//IL_0e63: Expected O, but got I4
						//IL_0084->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_00b3->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_00d8->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0116->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0145->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_019f->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_01ce->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_01f3->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0231->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0260->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_02de->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_030d->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_032f->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_036a->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0399->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_04ca->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_04f9->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_051b->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_064c->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_067b->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_069d->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_07d0->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0939->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_083c->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_086b->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0a0a->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_08a8->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0a39->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_08ca->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0a5b->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_09a6->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0a96->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_09c8->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0ac5->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0b27->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0b56->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0b75->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0b9a->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0ccd->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_10af->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0d3e->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0d5d->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0d7f->IL0eee: Incompatible stack heights: 1 vs 0
						//IL_0ea7->IL0eee: Incompatible stack heights: 1 vs 0
						_003C_003Ec__DisplayClass24_0 obj40 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						object obj45 = default(object);
						_003C_003Ec__DisplayClass24_0 obj47;
						GameObject gameObject4;
						float2 pos = default(float2);
						GameObject p10;
						object obj51;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null && (object)obj40._003C_003E4__this != null)
						{
							GameObject gameObject = obj40._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag22 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj41 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj41 == null)
								{
									return;
								}
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
								{
									IntPtr cachedPtr = ((UnityEngine.Object)gameObject2).m_CachedPtr;
									if (((UnityEngine.Object)gameObject2).m_CachedPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v13 (System.IntPtr)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v13 (System.IntPtr)+58]");
											float2 position8 = ((ArcadeSprite)0).position;
											_003C_003Ec__DisplayClass24_0 obj42 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
											{
												TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon = obj42._003C_003E4__this;
												if ((object)obj42._003C_003E4__this != null)
												{
													object obj43 = (object)position8 + (object)tP_Savrog2Union_Weapon.radiusOffset90;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v18 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
													object obj44 = obj45 + 0;
													GameObject gameObject3 = (GameObject)(object)CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
													if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
													{
														IntPtr cachedPtr2 = ((UnityEngine.Object)gameObject3).m_CachedPtr;
														if (((UnityEngine.Object)gameObject3).m_CachedPtr != (IntPtr)0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v19 (System.IntPtr)+58]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v19 (System.IntPtr)+58]");
																float2 position9 = ((ArcadeSprite)0).position;
																_003C_003Ec__DisplayClass24_0 obj46 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
																if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
																{
																	TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon2 = obj46._003C_003E4__this;
																	if ((object)obj46._003C_003E4__this != null)
																	{
																		float num52 = (float)tP_Savrog2Union_Weapon2.radiusOffset90 * -1f;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rcx_v16 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+174]");
																		float num53 = 0f * -1f;
																		float num54 = (float)position9 + num52;
																		float num55 = (float)obj45 + num53;
																		obj47 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
																		if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
																		{
																			TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon3 = obj47._003C_003E4__this;
																			if ((object)obj47._003C_003E4__this != null && (object)((Equipment)tP_Savrog2Union_Weapon3)._003COwner_003Ek__BackingField != null)
																			{
																				float2 position10 = ((Equipment)tP_Savrog2Union_Weapon3)._003COwner_003Ek__BackingField.position;
																				_003C_003Ec__DisplayClass24_0 obj48 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
																				if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
																				{
																					TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon4 = obj48._003C_003E4__this;
																					if ((object)obj48._003C_003E4__this != null)
																					{
																						gameObject4 = (GameObject)(object)obj47._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals47.localIndex, tP_Savrog2Union_Weapon4._targetTransform);
																						if ((object)gameObject4 == null)
																						{
																							p10 = null;
																							goto IL_0f6b;
																						}
																						nint num56 = (nint)gameObject4;
																						nint num57 = (nint)typeof(TP_Savrog2Union_Projectile);
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
																						object obj49 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v46 (Il2CppClass<UnityEngine.GameObject>)+130]");
																						nint num58 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ rdx_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
																						if (num58 >= 0)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v976 @ r8_v46 (Il2CppClass<UnityEngine.GameObject>)+C8]");
																							object obj50 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1031 @ rax_v133+FFFFFFF8+v978 @ rax_v128*8]");
																							if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
																							{
																								obj51 = 1;
																								goto IL_0f7d;
																							}
																						}
																						obj51 = 0;
																						goto IL_0f7d;
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
									}
								}
							}
						}
						goto IL_0eee;
						IL_0fd3:
						_003C_003Ec__DisplayClass24_0 obj52;
						GameObject p11;
						obj52.p2 = (TP_Savrog2Union_Projectile)(object)p11;
						_003C_003Ec__DisplayClass24_0 obj53 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Projectile p12 = obj53.p1;
							if ((object)obj53.p1 == null || ((UnityEngine.Object)p12).m_CachedPtr == (IntPtr)0)
							{
								goto IL_0915;
							}
							_003C_003Ec__DisplayClass24_0 obj54 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Savrog2Union_Projectile p13 = obj54.p1;
								if ((object)obj54.p1 != null)
								{
									p13._isInverted = false;
									Weapon weapon3 = ((Projectile)p13)._weapon;
									if ((object)((Projectile)p13)._weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
									{
										Vector2 scaledVelocity3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.ScaledVelocity;
										Vector2 vector3 = (Vector2)(obj54.p1 + 272);
										p13._previousVector = scaledVelocity3;
										((Vector2*)vector3)->Normalize();
										goto IL_0915;
									}
								}
							}
						}
						goto IL_0eee;
						IL_10c6:
						object obj55;
						bool flag23 = obj55 == null;
						GameObject sp8 = null;
						Projectile projectile8;
						if (!flag23)
						{
							sp8 = (GameObject)(object)projectile8;
						}
						goto IL_10b4;
						IL_0f6b:
						obj47.p0 = (TP_Savrog2Union_Projectile)(object)p10;
						_003C_003Ec__DisplayClass24_0 obj56 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						GameObject gameObject5;
						GameObject p14;
						object obj59;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon5 = obj56._003C_003E4__this;
							if ((object)obj56._003C_003E4__this != null && (object)obj56._003C_003E4__this != null)
							{
								gameObject5 = (GameObject)(object)obj56._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals47.localIndex, tP_Savrog2Union_Weapon5._targetTransform);
								if ((object)gameObject5 == null)
								{
									p14 = null;
									goto IL_0f9f;
								}
								nint num59 = (nint)gameObject5;
								nint num60 = (nint)typeof(TP_Savrog2Union_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
								object obj57 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ r8_v41 (Il2CppClass<UnityEngine.GameObject>)+130]");
								nint num61 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rdx_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
								if (num61 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ r8_v41 (Il2CppClass<UnityEngine.GameObject>)+C8]");
									object obj58 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ rax_v122+FFFFFFF8+v1139 @ rax_v117*8]");
									if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
									{
										obj59 = 1;
										goto IL_0fb1;
									}
								}
								obj59 = 0;
								goto IL_0fb1;
							}
						}
						goto IL_0eee;
						IL_0f9f:
						obj56.p1 = (TP_Savrog2Union_Projectile)(object)p14;
						obj52 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						GameObject gameObject6;
						object obj62;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon6 = obj52._003C_003E4__this;
							if ((object)obj52._003C_003E4__this != null && (object)obj52._003C_003E4__this != null)
							{
								gameObject6 = (GameObject)(object)obj52._003C_003E4__this.FireOneProjectile(pos, CS_0024_003C_003E8__locals47.localIndex, tP_Savrog2Union_Weapon6._targetTransform);
								if ((object)gameObject6 == null)
								{
									p11 = null;
									goto IL_0fd3;
								}
								nint num62 = (nint)gameObject6;
								nint num63 = (nint)typeof(TP_Savrog2Union_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
								object obj60 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1298 @ r8_v36 (Il2CppClass<UnityEngine.GameObject>)+130]");
								nint num64 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1299 @ rdx_v35 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
								if (num64 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1298 @ r8_v36 (Il2CppClass<UnityEngine.GameObject>)+C8]");
									object obj61 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1353 @ rax_v111+FFFFFFF8+v1300 @ rax_v106*8]");
									if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
									{
										obj62 = 1;
										goto IL_0fe5;
									}
								}
								obj62 = 0;
								goto IL_0fe5;
							}
						}
						goto IL_0eee;
						IL_1069:
						object obj63;
						bool flag24 = obj63 == null;
						GameObject sp9 = null;
						Projectile projectile9;
						if (!flag24)
						{
							sp9 = (GameObject)(object)projectile9;
						}
						goto IL_1057;
						IL_10b4:
						_003C_003Ec__DisplayClass24_0 obj64;
						obj64.sp2 = (TP_Savrog2Union_Spinning_Projectile)(object)sp8;
						_003C_003Ec__DisplayClass24_0 obj65 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Spinning_Projectile sp10 = obj65.sp2;
							if ((object)obj65.sp2 != null)
							{
								sp10._isInverted = true;
							}
							return;
						}
						goto IL_0eee;
						IL_0915:
						_003C_003Ec__DisplayClass24_0 obj66 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						_003C_003Ec__DisplayClass24_0 obj71;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Projectile p15 = obj66.p2;
							if ((object)obj66.p2 != null && ((UnityEngine.Object)p15).m_CachedPtr != (IntPtr)0)
							{
								_003C_003Ec__DisplayClass24_0 obj67 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
								if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 == null || (object)obj67.p2 == null)
								{
									goto IL_0eee;
								}
								obj67.p2.SetInversion(isInverted: true);
							}
							_003C_003Ec__DisplayClass24_0 obj68 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon7 = obj68._003C_003E4__this;
								if ((object)obj68._003C_003E4__this != null && (object)((Equipment)tP_Savrog2Union_Weapon7)._003COwner_003Ek__BackingField != null)
								{
									float2 position11 = ((Equipment)tP_Savrog2Union_Weapon7)._003COwner_003Ek__BackingField.position;
									_003C_003Ec__DisplayClass24_0 obj69 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
									if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
									{
										TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon8 = obj69._003C_003E4__this;
										if ((object)obj69._003C_003E4__this != null)
										{
											Vector2 position12 = (Vector2)((object)position11 + (object)tP_Savrog2Union_Weapon8.RadiusOffset);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v53 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
											object obj70 = obj45 + 0;
											obj68.position0 = position12;
											obj71 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
											if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
											{
												Weapon weapon4 = obj71._003C_003E4__this;
												if ((object)obj71._003C_003E4__this != null && CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v54 (VampireSurvivors.Objects.Weapons.Weapon)+1A8]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v54 (VampireSurvivors.Objects.Weapons.Weapon)+1A8]");
														projectile9 = ((BulletPool)0).SpawnAt(pos, obj71._003C_003E4__this, CS_0024_003C_003E8__locals47.localIndex);
														if ((object)projectile9 == null)
														{
															sp9 = null;
															goto IL_1057;
														}
														nint num65 = (nint)projectile9;
														nint num66 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
														object obj72 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1678 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
														nint num67 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1679 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
														if (num67 >= 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1678 @ r8_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
															object obj73 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1733 @ rax_v83+FFFFFFF8+v1680 @ rax_v78*8]");
															if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
															{
																obj63 = 1;
																goto IL_1069;
															}
														}
														obj63 = 0;
														goto IL_1069;
													}
												}
											}
										}
									}
								}
							}
						}
						goto IL_0eee;
						IL_1057:
						obj71.sp1 = (TP_Savrog2Union_Spinning_Projectile)(object)sp9;
						_003C_003Ec__DisplayClass24_0 obj74 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
						if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
						{
							TP_Savrog2Union_Spinning_Projectile sp11 = obj74.sp1;
							if ((object)obj74.sp1 != null)
							{
								sp11._isInverted = false;
							}
							obj64 = CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1;
							if (CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null)
							{
								TP_Savrog2Union_Weapon tP_Savrog2Union_Weapon9 = obj64._003C_003E4__this;
								if ((object)obj64._003C_003E4__this != null && CS_0024_003C_003E8__locals47.CS_0024_003C_003E8__locals1 != null && tP_Savrog2Union_Weapon9._spinningPool != null)
								{
									projectile8 = tP_Savrog2Union_Weapon9._spinningPool.SpawnAt(pos, obj64._003C_003E4__this, CS_0024_003C_003E8__locals47.localIndex);
									bool flag25 = (object)projectile8 == null;
									sp8 = null;
									if (flag25)
									{
										goto IL_10b4;
									}
									nint num68 = (nint)projectile8;
									nint num69 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
									object obj75 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1846 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
									nint num70 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1847 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
									if (num70 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1846 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
										object obj76 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1901 @ rax_v72+FFFFFFF8+v1848 @ rax_v68*8]");
										if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
										{
											obj55 = 1;
											goto IL_10c6;
										}
									}
									obj55 = 0;
									goto IL_10c6;
								}
							}
						}
						goto IL_0eee;
						IL_0fb1:
						bool flag26 = obj59 == null;
						p14 = null;
						if (!flag26)
						{
							p14 = gameObject5;
						}
						goto IL_0f9f;
						IL_0eee:
						throw new NullReferenceException();
						IL_0fe5:
						bool flag27 = obj62 == null;
						p11 = null;
						if (!flag27)
						{
							p11 = gameObject6;
						}
						goto IL_0fd3;
						IL_0f7d:
						bool flag28 = obj51 == null;
						p10 = null;
						if (!flag28)
						{
							p10 = gameObject4;
						}
						goto IL_0f6b;
					};
					float num24 = (float)num21 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					num18 = num24 * 0.001f;
					Timer lastShotTimer = Timers.Register(num18, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
					obj9 = obj + 48;
					goto IL_135d;
					IL_135d:
					num21++;
					float num25 = base.PAmount();
					obj8 = obj + 40;
					continue;
					IL_11f3:
					object obj17;
					bool flag10 = obj17 == null;
					TP_Savrog2Union_Projectile tP_Savrog2Union_Projectile = null;
					if (!flag10)
					{
						tP_Savrog2Union_Projectile = tP_Savrog2Union_Projectile2;
					}
					goto IL_11c1;
					IL_11c1:
					obj9 = tP_Savrog2Union_Projectile;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					TP_Savrog2Union_Projectile p7;
					if ((object)tP_Savrog2Union_Projectile3 == null)
					{
						p7 = null;
						goto IL_1215;
					}
					nint num26 = (nint)tP_Savrog2Union_Projectile3;
					nint num27 = (nint)typeof(TP_Savrog2Union_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2244 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					object obj18 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2243 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					nint num28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2244 @ rdx_v57 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					object obj20;
					if (num28 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2243 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+C8]");
						object obj19 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2288 @ rax_v137+FFFFFFF8+v2245 @ rax_v132*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
						{
							obj20 = 1;
							goto IL_122f;
						}
					}
					obj20 = 0;
					goto IL_122f;
					IL_1337:
					object obj21;
					bool flag11 = obj21 == null;
					bool flag12 = false;
					Projectile projectile3;
					if (!flag11)
					{
						flag12 = (byte)(int)projectile3 != 0;
					}
					obj.sp2 = (TP_Savrog2Union_Spinning_Projectile)flag12;
					goto IL_1300;
					IL_1215:
					obj.p2 = p7;
					object obj22 = obj9;
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rbx_v15+10]");
						if ((nint)0 != 0)
						{
							((TP_Savrog2Union_Projectile)obj9).SetInversion(false);
						}
					}
					TP_Savrog2Union_Projectile p8 = obj.p2;
					if ((object)obj.p2 != null && ((UnityEngine.Object)p8).m_CachedPtr != (IntPtr)0)
					{
						obj.p2.SetInversion(isInverted: true);
					}
					Vector2 playerPos2 = base.PlayerPos;
					Vector2 position6 = playerPos2 + RadiusOffset;
					float num29 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon)+1A0]");
					float num30 = num29 + 0f;
					obj.position0 = position6;
					Projectile projectile4 = _spinningPool.SpawnAt((float2)num10, this, num21);
					if ((object)projectile4 == null)
					{
						obj.sp1 = null;
						goto IL_129a;
					}
					nint num31 = (nint)projectile4;
					nint num32 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rdx_v54 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
					object obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2562 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num33 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2563 @ rdx_v54 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
					object obj25;
					if (num33 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2562 @ r8_v38 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj24 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2605 @ rax_v117+FFFFFFF8+v2564 @ rax_v111*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
						{
							obj25 = 1;
							goto IL_12c9;
						}
					}
					obj25 = 0;
					goto IL_12c9;
					IL_119b:
					bool flag13 = obj16 == null;
					obj12 = 0;
					if (!flag13)
					{
						obj12 = obj11;
					}
					goto IL_1169;
					IL_1300:
					TP_Savrog2Union_Spinning_Projectile sp2 = obj.sp2;
					bool flag14 = (object)obj.sp2 == null;
					num18 = num10;
					if (!flag14)
					{
						sp2._isInverted = true;
						num18 = num10;
					}
					goto IL_135d;
					IL_1169:
					obj8 = obj12;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					if ((object)tP_Savrog2Union_Projectile2 == null)
					{
						tP_Savrog2Union_Projectile = null;
						goto IL_11c1;
					}
					nint num34 = (nint)tP_Savrog2Union_Projectile2;
					nint num35 = (nint)typeof(TP_Savrog2Union_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2075 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2074 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					nint num36 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2075 @ rdx_v58 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
					if (num36 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2074 @ r8_v42 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+C8]");
						object obj27 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2140 @ rax_v144+FFFFFFF8+v2076 @ rax_v139*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
						{
							obj17 = 1;
							goto IL_11f3;
						}
					}
					obj17 = 0;
					goto IL_11f3;
					IL_129a:
					TP_Savrog2Union_Spinning_Projectile sp3 = obj.sp1;
					if ((object)obj.sp1 != null)
					{
						sp3._isInverted = false;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v2 (VampireSurvivors.Objects.Weapons.TP_Savrog2Union_Weapon+<>c__DisplayClass24_0)+44]");
					num14 = 0f;
					projectile3 = _spinningPool.SpawnAt((float2)num10, this, num21);
					if ((object)projectile3 == null)
					{
						obj.sp2 = null;
						goto IL_1300;
					}
					nint num37 = (nint)projectile3;
					nint num38 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rdx_v53 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
					object obj28 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2671 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					nint num39 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rdx_v53 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
					if (num39 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2671 @ r8_v37 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
						object obj29 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2713 @ rax_v110+FFFFFFF8+v2673 @ rax_v104*8]");
						if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
						{
							obj21 = 1;
							goto IL_1337;
						}
					}
					obj21 = 0;
					goto IL_1337;
					IL_12c9:
					bool flag15 = obj25 == null;
					Projectile sp4 = null;
					if (!flag15)
					{
						sp4 = projectile4;
					}
					obj.sp1 = (TP_Savrog2Union_Spinning_Projectile)sp4;
					goto IL_129a;
					IL_122f:
					bool flag16 = obj20 == null;
					p7 = null;
					if (!flag16)
					{
						p7 = tP_Savrog2Union_Projectile3;
					}
					goto IL_1215;
				}
				while (num18 > (float)num21);
				flag6 = flag7;
			}
		}
		float num40 = base.PInterval();
		float num41 = _lastFiringInterval - num18;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj30 = num41 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj30) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num42 = base.PInterval();
			_lastFiringInterval = num18;
			ResetFiringTimer();
		}
		if (!flag6)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
		return;
		IL_101f:
		Projectile p9;
		obj.p0 = (TP_Savrog2Union_Projectile)p9;
		Projectile projectile5 = base.FireOneProjectile((Vector2)num10, 0, _targetTransform);
		if ((object)projectile5 == null)
		{
			p = null;
			goto IL_1053;
		}
		nint num43 = (nint)projectile5;
		nint num44 = (nint)typeof(TP_Savrog2Union_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1220 @ rdx_v67 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ r9_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1220 @ rdx_v67 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		object obj33;
		if (num45 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ r9_v28 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj32 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1275 @ rax_v190+FFFFFFF8+v1221 @ rax_v185*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
			{
				obj33 = 1;
				goto IL_1065;
			}
		}
		obj33 = 0;
		goto IL_1065;
		IL_0ffc:
		object obj34;
		bool flag17 = obj34 == null;
		Projectile sp5 = null;
		Projectile projectile6;
		if (!flag17)
		{
			sp5 = projectile6;
		}
		goto IL_0fea;
		IL_0fc8:
		bool flag18 = obj4 == null;
		sp = null;
		if (!flag18)
		{
			sp = projectile;
		}
		goto IL_0fb6;
		IL_1065:
		bool flag19 = obj33 == null;
		p = null;
		if (!flag19)
		{
			p = projectile5;
		}
		goto IL_1053;
		IL_1031:
		object obj35;
		bool flag20 = obj35 == null;
		p9 = null;
		Projectile projectile7;
		if (!flag20)
		{
			p9 = projectile7;
		}
		goto IL_101f;
		IL_0fb6:
		obj.sp1 = (TP_Savrog2Union_Spinning_Projectile)sp;
		TP_Savrog2Union_Spinning_Projectile sp6 = obj.sp1;
		if ((object)obj.sp1 != null)
		{
			sp6._isInverted = false;
		}
		projectile6 = _spinningPool.SpawnAt((float2)num10, this);
		if ((object)projectile6 == null)
		{
			sp5 = null;
			goto IL_0fea;
		}
		nint num46 = (nint)projectile6;
		nint num47 = (nint)typeof(TP_Savrog2Union_Spinning_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
		object obj36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ r9_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num48 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v860 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Spinning_Projectile>)+130]");
		if (num48 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ r9_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v913 @ rax_v212+FFFFFFF8+v861 @ rax_v207*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Spinning_Projectile))
			{
				obj34 = 1;
				goto IL_0ffc;
			}
		}
		obj34 = 0;
		goto IL_0ffc;
		IL_0fea:
		obj.sp2 = (TP_Savrog2Union_Spinning_Projectile)sp5;
		TP_Savrog2Union_Spinning_Projectile sp7 = obj.sp2;
		if ((object)obj.sp2 != null)
		{
			sp7._isInverted = true;
		}
		float2 position7 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		projectile7 = base.FireOneProjectile((Vector2)num10, 0, _targetTransform);
		if ((object)projectile7 == null)
		{
			p9 = null;
			goto IL_101f;
		}
		nint num49 = (nint)projectile7;
		nint num50 = (nint)typeof(TP_Savrog2Union_Projectile);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdx_v70 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		object obj38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1043 @ r9_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		nint num51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1044 @ rdx_v70 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Savrog2Union_Projectile>)+130]");
		if (num51 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1043 @ r9_v29 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
			object obj39 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1098 @ rax_v201+FFFFFFF8+v1045 @ rax_v196*8]");
			if (0 == (nint)typeof(TP_Savrog2Union_Projectile))
			{
				obj35 = 1;
				goto IL_1031;
			}
		}
		obj35 = 0;
		goto IL_1031;
		IL_1099:
		bool flag21 = obj7 == null;
		p2 = null;
		if (!flag21)
		{
			p2 = projectile2;
		}
		goto IL_1087;
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0198: Expected I4, but got O
		//IL_0165: Expected F4, but got I4
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
						goto IL_01b5;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							TP_Savrog2Union_Projectile component2 = gameObject2.GetComponent<TP_Savrog2Union_Projectile>();
							if ((object)component2 != null)
							{
								bool flag = component2.HasAlreadyHitObject(component);
								if (!flag)
								{
									float num3;
									object obj = default(object);
									if (component2._isYeeted != flag)
									{
										float num = base.PPower();
										float num2 = component2._durataMillis / 1000f;
										num3 = (float)obj * num2;
									}
									else
									{
										num3 = 0f;
									}
									float num4 = base.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									float num5 = (float)obj + num3;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									component.GetDamaged(num5, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num6 = num5 + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num6;
								}
								goto IL_01b5;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01b5:
		return false;
	}

	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager gameMan2 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan2._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
		CheckBeginningArcana();
	}

	protected override bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0192: Expected I4, but got O
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
						goto IL_01af;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							TP_Savrog2Union_Projectile component2 = gameObject2.GetComponent<TP_Savrog2Union_Projectile>();
							if ((object)component2 != null && ((UnityEngine.Object)component2).m_CachedPtr != (IntPtr)0 && !component2.HasAlreadyHitObject(component))
							{
								float num = base.PPower();
								WeaponData currentWeaponData = _currentWeaponData;
								object obj = default(object);
								float num2 = (float)obj * 0.5f;
								HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
								float knockback = base.Knockback;
								component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
								float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
								base._003CStatsInflictedDamage_003Ek__BackingField = num3;
							}
							goto IL_01af;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01af:
		return false;
	}

	private void MakeOwnerClones()
	{
		//IL_00d0: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_018d: Expected I4, but got O
		//IL_02a5: Expected O, but got I4
		//IL_0353: Expected O, but got I4
		//IL_04f3: Expected I4, but got I8
		//IL_0579: Expected I4, but got I8
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)21);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v14 (System.Object)+18]");
		string textureName;
		string text;
		int end;
		int fps;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v14 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rcx_v12+20]");
			CharacterData characterData = (CharacterData)0;
			if (characterData._003Cskins_003Ek__BackingField == null)
			{
				bool flag = (object)characterData._003CwalkFrameRate_003Ek__BackingField == null;
				textureName = characterData._003CtextureName_003Ek__BackingField;
				text = characterData._003CspriteName_003Ek__BackingField;
				end = characterData._003CwalkingFrames_003Ek__BackingField;
				if (!flag)
				{
					if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
					{
						fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
						goto IL_01d0;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new IndexOutOfRangeException();
				}
			}
			else
			{
				Skin currentSkinData = characterData.GetCurrentSkinData();
				textureName = currentSkinData._003CtextureName_003Ek__BackingField;
				text = currentSkinData._003CspriteName_003Ek__BackingField;
				end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
			}
			fps = 8;
			goto IL_01d0;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_01d0:
		string animName = text.Replace("01.png", "");
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num);
		PhaserSprite phaserSprite = clone1;
		Vector2 pos = default(Vector2);
		if ((object)clone1 == null || ((UnityEngine.Object)phaserSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			PhaserSprite phaserSprite2 = instance.AddPhaserSprite(pos, "vfx", "WhiteDot");
			PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.65f);
			PhaserSprite phaserSprite4 = phaserSprite3.setScale(1f, (float?)(object)0);
			clone1 = phaserSprite4;
		}
		PhaserSprite phaserSprite5 = clone2;
		if ((object)clone2 == null || ((UnityEngine.Object)phaserSprite5).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "WhiteDot");
			PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0.65f);
			PhaserSprite phaserSprite8 = phaserSprite7.setScale(1f, (float?)(object)0);
			clone2 = phaserSprite8;
		}
		PhaserSprite phaserSprite9 = clone1;
		phaserSprite9._spriteAnimation.CleanAnimations();
		PhaserSprite phaserSprite10 = clone1;
		bool flag2 = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		phaserSprite10._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag2, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite11 = clone1;
		phaserSprite11._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite12 = clone2;
		phaserSprite12._spriteAnimation.CleanAnimations();
		PhaserSprite phaserSprite13 = clone2;
		phaserSprite13._spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag2, onComplete, autoSetAnimation);
		PhaserSprite phaserSprite14 = clone2;
		phaserSprite14._spriteAnimation.SetAnimation("walk");
		PhaserSprite phaserSprite15 = clone2.setFlipX(flipX: true);
		uint[] cloneTint = _cloneTint;
		PhaserSprite phaserSprite16 = clone1.setTint(cloneTint[0], cloneTint[1], cloneTint[2], (uint)num, flag2 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite17 = clone1.setAlpha(0.65f);
		PhaserSprite phaserSprite18 = clone1.setDepth(-1);
		uint[] cloneTint2 = _cloneTint;
		PhaserSprite phaserSprite19 = clone2.setTint(cloneTint2[0], cloneTint2[1], cloneTint2[2], (uint)num, flag2 ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite20 = clone2.setAlpha(0.65f);
		PhaserSprite phaserSprite21 = clone2.setDepth(-1);
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_048c: Expected O, but got Ref
		//IL_04b3: Expected O, but got I
		//IL_04c8: Expected native int or pointer, but got O
		//IL_04e2: Expected O, but got I
		//IL_0502: Expected O, but got Ref
		//IL_051c: Expected native int or pointer, but got O
		//IL_0702: Expected O, but got I
		//IL_0554: Expected O, but got Ref
		//IL_056e: Expected native int or pointer, but got O
		//IL_073c: Expected O, but got I
		//IL_067d: Expected O, but got I
		//IL_06aa: Expected I4, but got I8
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 64f;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
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
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPink.png");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version3 = list._version + 1;
			list._version = version3;
			string[] items3 = list._items;
			if (list._size >= items3.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxYellow.png");
			}
			else
			{
				int size3 = list._size + 1;
				list._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list._version + 1;
			list._version = version4;
			string[] items4 = list._items;
			if (list._size >= items4.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPurple.png");
			}
			else
			{
				int size4 = list._size + 1;
				list._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version5 = list._version + 1;
			list._version = version5;
			string[] items5 = list._items;
			if (list._size >= items5.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPurple2.png");
			}
			else
			{
				int size5 = list._size + 1;
				list._size = size5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version6 = list._version + 1;
			list._version = version6;
			string[] items6 = list._items;
			if (list._size >= items6.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxPurple3.png");
			}
			else
			{
				int size6 = list._size + 1;
				list._size = size6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(400f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-79]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-69]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+17]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+27]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
			_ = 0;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
			Transform parent2 = base.transform;
			ParticleSystem particleSystem = _pfxManager.CreateEmitter(particleSystemConfig, parent2);
			Circle circle2 = new Circle();
			circle2._x = 0f;
			circle2._radius = 64f;
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Edge;
			emitZone2._source = circle2;
			_ = 0;
			_ = 360;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
			emitZone2._quantity = (int?)(object)0;
			RenderingExtensions.SetEmitZone(_pfx, emitZone2);
			ParticleEmitterManager particleEmitterManager = _pfxManager.SetDepth(-6);
		}
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		PhaserSprite phaserSprite = clone1.setVisible(visible);
		PhaserSprite phaserSprite2 = clone2.setVisible(visible);
	}

	public TP_Savrog2Union_Weapon()
	{
		//IL_005f: Expected I, but got O
		//IL_0024: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		radiusOffset90 = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_cloneTint = new uint[4] { 16711680u, 16711680u, 16711935u, 16711935u };
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		RadiusOffset = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}
}
