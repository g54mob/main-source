using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.Speedup;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Stages;

public class DopplegangerGate : GameMonoBehaviour
{
	private enum GateState
	{
		ClosedDoorsOpen,
		ClosedAndReady,
		Opening,
		Open,
		Closing,
		ClosedForever
	}

	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public int index;

		public DopplegangerGate _003C_003E4__this;

		internal void _003CSpawnDopplegangers_003Eb__0()
		{
			//IL_0165: Expected O, but got I
			//IL_01d3: Expected O, but got I8
			GameManager core = GM.Core;
			DopplegangerGate dopplegangerGate = _003C_003E4__this;
			float2 position = dopplegangerGate._gatePortal.position;
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.TP_BOSS_DOPPLEGANGER, spawnPos, asRemote: false, forceSpawn);
			if ((object)gameObject == null || ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			EnemyDoppleganger component = gameObject.GetComponent<EnemyDoppleganger>();
			GameManager core2 = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
			int num = index;
			if (index < mainCharacters._size)
			{
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters._items;
				GameManager core3 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core3._mainCharacters;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[num];
				component._characterToCopy = items[num];
				float reloadSpeed = 1f / (float)mainCharacters2._size;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj = 0;
				component._reloadSpeed = reloadSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
					characterController = (VampireSurvivors.Objects.Characters.CharacterController)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v615 @ rax_v29 (should have been resolved before IL gen)");
				component._weaponUsageCooldown = 2f;
				component.SetupDoppleganger(component._characterToCopy, _003C_003E4__this);
				DopplegangerGate dopplegangerGate2 = _003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6410");
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003CRunClosingAnimation_003Ed__32(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DopplegangerGate _003C_003E4__this;

		private float _003CopenAmount_003E5__2;

		private float _003CdoorOpeningDistance_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0023: Expected I4, but got I8
			//IL_02d8: Expected I4, but got I8
			//IL_08c3: Invalid comparison between F4 and I4
			//IL_0717: Expected F4, but got I4
			//IL_0749: Expected F4, but got I4
			//IL_0372: Expected O, but got I4
			//IL_03d4: Expected O, but got I4
			//IL_040a: Expected O, but got I4
			//IL_044a: Expected O, but got I4
			//IL_0469: Invalid comparison between I4 and F4
			//IL_0538: Invalid comparison between F4 and I4
			//IL_055a: Expected I, but got O
			//IL_057a: Expected F4, but got I
			//IL_0299: Expected F4, but got I4
			//IL_03bc->IL0826: Incompatible stack heights: 1 vs 0
			//IL_011b->IL0826: Incompatible stack heights: 1 vs 0
			//IL_0154->IL0826: Incompatible stack heights: 1 vs 0
			//IL_0176->IL0826: Incompatible stack heights: 1 vs 0
			//IL_094c->IL0826: Incompatible stack heights: 2 vs 0
			//IL_01a5->IL0826: Incompatible stack heights: 1 vs 0
			//IL_04db->IL0826: Incompatible stack heights: 3 vs 0
			//IL_0502->IL0826: Incompatible stack heights: 3 vs 0
			//IL_08b3->IL0826: Incompatible stack heights: 2 vs 0
			//IL_01ff->IL0826: Incompatible stack heights: 3 vs 0
			//IL_0995->IL0826: Incompatible stack heights: 3 vs 0
			//IL_0226->IL0826: Incompatible stack heights: 3 vs 0
			//IL_05d9->IL0826: Incompatible stack heights: 3 vs 0
			//IL_02a7->IL08b8: Incompatible stack heights: 3 vs 0
			//IL_06e4->IL0a4d: Incompatible stack heights: 6 vs 0
			DopplegangerGate dopplegangerGate = _003C_003E4__this;
			Rect ret = default(Rect);
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
				BgmType bgmType = default(BgmType);
				SoundManager.FadeMusic(bgmType, 0f, 1000f);
				if ((object)GM.Core != null)
				{
					GM.Core.SetAllPlayersWeaponsActive(active: false);
					_003CopenAmount_003E5__2 = 1f;
					if ((object)_003C_003E4__this != null)
					{
						List<PhaserSprite> gateDoors = dopplegangerGate._gateDoors;
						if (dopplegangerGate._gateDoors != null)
						{
							bool flag = gateDoors._size <= 0;
							PhaserSprite[] items = gateDoors._items;
							if (gateDoors._items != null)
							{
								PhaserSprite phaserSprite = items[0];
								if ((object)items[0] != null && (object)phaserSprite._spriteRenderer != null)
								{
									Sprite sprite = phaserSprite._spriteRenderer.sprite;
									if ((object)sprite != null)
									{
										bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret);
										List<PhaserSprite> gateDoors2 = dopplegangerGate._gateDoors;
										if (dopplegangerGate._gateDoors != null)
										{
											bool flag3 = gateDoors2._size <= 0;
											PhaserSprite[] items2 = gateDoors2._items;
											if (gateDoors2._items != null && (object)items2[0] != null)
											{
												float scale = items2[0].scale;
												object obj = default(object);
												float num = scale * (float)obj;
												float num2 = num * 0.01f;
												_003CdoorOpeningDistance_003E5__3 = num2;
												PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Bangu, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
												goto IL_08b8;
											}
										}
									}
								}
							}
						}
					}
				}
				goto IL_0826;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_0818;
			}
			_003C_003E1__state = -1;
			goto IL_08b8;
			IL_0826:
			throw new NullReferenceException();
			IL_0818:
			return false;
			IL_08b8:
			if (_003CopenAmount_003E5__2 > 0f)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num3 = deltaTime * 0.5f;
				float num4 = (_003CopenAmount_003E5__2 -= num3);
				if ((object)_003C_003E4__this != null)
				{
					List<PhaserSprite> gateDoors3 = dopplegangerGate._gateDoors;
					if (dopplegangerGate._gateDoors != null)
					{
						object obj2 = gateDoors3._size - 2;
						bool flag4 = (nint)obj2 >= gateDoors3._size;
						PhaserSprite[] items3 = gateDoors3._items;
						if (gateDoors3._items != null)
						{
							object obj3 = gateDoors3._size - 2;
							PhaserSprite phaserSprite2 = items3[obj3];
							List<PhaserSprite> gateDoors4 = dopplegangerGate._gateDoors;
							object obj4 = gateDoors4._size - 1;
							bool flag5 = (nint)obj4 >= gateDoors4._size;
							PhaserSprite[] items4 = gateDoors4._items;
							object obj5 = gateDoors4._size - 1;
							PhaserSprite phaserSprite3 = items4[obj5];
							if (0f > num4)
							{
								_003CopenAmount_003E5__2 = 0f;
							}
							float num5 = _003CopenAmount_003E5__2 * 200f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
							float num6 = _003CopenAmount_003E5__2 * 200f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							List<PhaserSprite> gateDoors5 = dopplegangerGate._gateDoors;
							float num7 = num6 * 0.003f;
							if (dopplegangerGate._gateDoors != null)
							{
								bool flag6 = gateDoors5._size <= 0;
								PhaserSprite[] items5 = gateDoors5._items;
								if (gateDoors5._items != null && (object)items5[0] != null)
								{
									float scale2 = items5[0].scale;
									float num8 = num7 * scale2;
									float num11;
									if (!(_003CopenAmount_003E5__2 > 0f))
									{
										nint num9 = (nint)typeof(float2);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1480 @ rax_v72 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
										nint num10 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1481 @ rcx_v56 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
										num11 = 0f;
									}
									else
									{
										float num12 = _003CopenAmount_003E5__2 + 1f;
										num11 = num8 / num12;
									}
									float num13 = _003CdoorOpeningDistance_003E5__3 * 0f;
									float num14 = num13 * _003CopenAmount_003E5__2;
									if ((object)items3[obj3] != null)
									{
										items3[obj3].angle = 0f;
										if ((object)dopplegangerGate._gatePortal != null)
										{
											float2 position = dopplegangerGate._gatePortal.position;
											float num15 = 1.0653532E+09f - num14;
											float num16 = num15 + num11;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
											object spriteRenderer = phaserSprite2._spriteRenderer;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1115 @ rsi_v11 (System.Object)+10]");
											bool flag7 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1115 @ rsi_v11 (System.Object)+10]");
											SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&ret));
											PhaserSprite phaserSprite4 = items3[obj3].setVisible(visible: true);
											items4[obj5].angle = 0f;
											float2 position2 = dopplegangerGate._gatePortal.position;
											float num17 = 1.0653532E+09f + num14;
											float num18 = num17 + num11;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
											object spriteRenderer2 = phaserSprite3._spriteRenderer;
											bool flag8 = (object)phaserSprite3._spriteRenderer == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rsi_v12 (System.Object)+10]");
											bool flag9 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v301 @ rsi_v12 (System.Object)+10]");
											SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&ret));
											PhaserSprite phaserSprite5 = items4[obj5].setVisible(visible: true);
											_003C_003E2__current = null;
											_003C_003E1__state = 1;
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.LittleHit, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
				PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
				if ((object)_003C_003E4__this != null && (object)dopplegangerGate._gatePortal != null)
				{
					float2 position3 = dopplegangerGate._gatePortal.position;
					_003C_003E4__this.AwardChest(position3);
					if ((object)GM.Core != null)
					{
						GM.Core.SetupMusicBanger();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
						BgmType bgmType2 = default(BgmType);
						SoundManager.FadeMusic(bgmType2, 0.3f, 2000f);
						_003C_003E4__this.OpenDoors();
						goto IL_0818;
					}
				}
			}
			goto IL_0826;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CRunOpeningAnimation_003Ed__30(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DopplegangerGate _003C_003E4__this;

		private float _003CfullRotationAmount_003E5__2;

		private float _003CdoorOpeningDistance_003E5__3;

		private float _003CfullOpeningTime_003E5__4;

		private float _003CrotationStartPoint_003E5__5;

		private float _003CopeningTimeBeforeEachDoor_003E5__6;

		private float _003CopeningTimer_003E5__7;

		private float _003ClastEffectiveOpeningTimer_003E5__8;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_00c0: Expected I4, but got I8
			//IL_00ac: Expected I4, but got I8
			//IL_002e: Invalid comparison between F4 and I4
			//IL_0054: Expected I4, but got I8
			//IL_04ad: Expected F4, but got I4
			//IL_04c8: Expected F4, but got I4
			//IL_14bf: Invalid comparison between F4 and I4
			//IL_0bb1: Invalid comparison between F4 and I4
			//IL_0c55: Invalid comparison between I4 and F4
			//IL_1110: Expected F4, but got I4
			//IL_1119: Expected F4, but got I4
			//IL_0ce6: Expected O, but got I4
			//IL_055d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0562: Expected O, but got Unknown
			//IL_0566: Unsupported input type for neg.
			//IL_0566: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Expected I4, but got Unknown
			//IL_057e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0583: Expected O, but got Unknown
			//IL_05ce: Invalid comparison between I4 and F4
			//IL_112b: Invalid comparison between F4 and I4
			//IL_05eb: Invalid comparison between F4 and I4
			//IL_114f: Invalid comparison between F4 and I4
			//IL_1267: Expected O, but got I4
			//IL_0635: Expected F4, but got I4
			//IL_0667: Expected F4, but got I4
			//IL_0679: Invalid comparison between F4 and I4
			//IL_119f: Invalid comparison between F4 and I4
			//IL_13dd: Invalid comparison between I4 and F4
			//IL_08be: Expected I, but got O
			//IL_08de: Expected F4, but got I
			//IL_0701: Expected F4, but got I4
			//IL_0718: Expected O, but got I4
			//IL_0720: Invalid comparison between F4 and O
			//IL_0737: Expected F4, but got I4
			//IL_0740: Expected O, but got I4
			//IL_0950: Expected F4, but got I4
			//IL_06c3: Expected F4, but got I4
			//IL_13fa: Invalid comparison between I4 and F4
			//IL_0996: Expected F4, but got I4
			//IL_0793: Expected F4, but got I4
			//IL_07a6: Expected F4, but got I4
			//IL_07af: Expected O, but got I4
			//IL_142a: Expected F4, but got I4
			//IL_1433: Expected F4, but got I4
			//IL_0337: Expected I, but got O
			//IL_0340: Expected F4, but got I4
			//IL_09ae: Expected O, but got I4
			//IL_09b6: Invalid comparison between F4 and O
			//IL_09c8: Expected F4, but got I4
			//IL_09d1: Expected F4, but got I4
			//IL_0352: Invalid comparison between F4 and I4
			//IL_0ad5: Expected O, but got Ref
			//IL_0b6a: Expected O, but got Ref
			//IL_0423: Unknown result type (might be due to invalid IL or missing references)
			//IL_0428: Expected O, but got Unknown
			//IL_0442: Expected F4, but got O
			//IL_01bf->IL12dd: Incompatible stack heights: 1 vs 0
			//IL_01e1->IL12dd: Incompatible stack heights: 1 vs 0
			//IL_0210->IL12dd: Incompatible stack heights: 1 vs 0
			//IL_1380->IL12dd: Incompatible stack heights: 2 vs 0
			//IL_023f->IL12a9: Incompatible stack heights: 2 vs 0
			//IL_11d3->IL12dd: Incompatible stack heights: 1 vs 0
			//IL_026e->IL12dd: Incompatible stack heights: 2 vs 0
			//IL_1210->IL152d: Incompatible stack heights: 1 vs 0
			//IL_02b3->IL12dd: Incompatible stack heights: 3 vs 0
			//IL_13af->IL12dd: Incompatible stack heights: 3 vs 0
			//IL_0457->IL1303: Incompatible stack heights: 3 vs 0
			//IL_0388->IL12a9: Incompatible stack heights: 3 vs 0
			//IL_03b7->IL12dd: Incompatible stack heights: 3 vs 0
			//IL_03fa->IL12dd: Incompatible stack heights: 4 vs 0
			//IL_0ba8->IL14b2: Incompatible stack heights: 4 vs 0
			//IL_0447->IL1385: Incompatible stack heights: 4 vs 3
			DopplegangerGate dopplegangerGate = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			float num2;
			float num3;
			float num4;
			Sprite sprite2 = default(Sprite);
			if (!flag)
			{
				float num = (float)_003C_003E1__state - 1f;
				if (flag)
				{
					_003C_003E1__state = -1;
					goto IL_1303;
				}
				if (num != 1f)
				{
					goto IL_129b;
				}
				_003C_003E1__state = -1;
				num2 = _003CopeningTimer_003E5__7;
				num3 = _003CfullOpeningTime_003E5__4 + 1f;
				if ((object)_003C_003E4__this != null)
				{
					num4 = 1f;
					goto IL_12e4;
				}
			}
			else
			{
				_003C_003E1__state = -1;
				_003CfullRotationAmount_003E5__2 = -90f;
				if ((object)_003C_003E4__this != null)
				{
					List<PhaserSprite> gateDoors = dopplegangerGate._gateDoors;
					if (dopplegangerGate._gateDoors != null)
					{
						if (gateDoors._size <= 0)
						{
							goto IL_12a9;
						}
						PhaserSprite[] items = gateDoors._items;
						if (gateDoors._items != null)
						{
							bool flag2 = items.Length <= 0;
							PhaserSprite phaserSprite = items[0];
							if ((object)items[0] != null && (object)phaserSprite._spriteRenderer != null)
							{
								Sprite sprite = phaserSprite._spriteRenderer.sprite;
								if ((object)sprite != null)
								{
									bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
									Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
									List<PhaserSprite> gateDoors2 = dopplegangerGate._gateDoors;
									if (dopplegangerGate._gateDoors != null)
									{
										if (gateDoors2._size <= 0)
										{
											goto IL_12a9;
										}
										PhaserSprite[] items2 = gateDoors2._items;
										if (gateDoors2._items != null)
										{
											bool flag4 = items2.Length <= 0;
											if ((object)items2[0] != null)
											{
												float scale = items2[0].scale;
												object obj = default(object);
												float num5 = scale * (float)obj;
												_003CfullOpeningTime_003E5__4 = 5f;
												_003CrotationStartPoint_003E5__5 = 0.4f;
												float num6 = num5 * 0.01f;
												_003CdoorOpeningDistance_003E5__3 = num6;
												float num7 = 4f / (float)dopplegangerGate._howManyGates;
												_003CopeningTimeBeforeEachDoor_003E5__6 = num7;
												sprite2 = null;
												nint num8 = unchecked((nint)null);
												float num = 0f;
												while (true)
												{
													List<PhaserSprite> gateDoors3 = dopplegangerGate._gateDoors;
													if (dopplegangerGate._gateDoors == null)
													{
														break;
													}
													if (!(num < (float)gateDoors3._size))
													{
														goto IL_0447;
													}
													if ((nint)sprite2 < gateDoors3._size)
													{
														PhaserSprite[] items3 = gateDoors3._items;
														if (gateDoors3._items == null)
														{
															break;
														}
														bool flag5 = (nint)sprite2 >= items3.Length;
														if ((object)items3[(object)sprite2] == null)
														{
															break;
														}
														PhaserSprite phaserSprite2 = items3[(object)sprite2].setVisible(visible: true);
														sprite2 = (Sprite)(sprite2 + 1);
														int num9 = 0;
														num8 = 1;
														num = (float)sprite2;
														continue;
													}
													goto IL_12a9;
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
			goto IL_12dd;
			IL_129b:
			return false;
			IL_0e85:
			float num10;
			_003ClastEffectiveOpeningTimer_003E5__8 = num10;
			float deltaTime = PauseSystem.DeltaTime;
			float num11 = deltaTime + _003CopeningTimer_003E5__7;
			_003C_003E2__current = null;
			_003CopeningTimer_003E5__7 = num11;
			_003C_003E1__state = 1;
			goto IL_151f;
			IL_0447:
			_003CopeningTimer_003E5__7 = 0f;
			goto IL_1303;
			IL_12e4:
			if (num3 > num2)
			{
				if ((object)dopplegangerGate._openingLight != null)
				{
					float num12 = _003CopeningTimer_003E5__7 - _003CfullOpeningTime_003E5__4;
					float alpha = num4 - num12;
					PhaserSprite phaserSprite3 = dopplegangerGate._openingLight.setAlpha(alpha);
					if ((object)dopplegangerGate._fullscreenLight != null)
					{
						float alpha2 = num4 - num12;
						PhaserSprite phaserSprite4 = dopplegangerGate._fullscreenLight.setAlpha(alpha2);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null && (object)dopplegangerGate._fullscreenLight != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									float deltaTime2 = PauseSystem.DeltaTime;
									float num13 = deltaTime2 + _003CopeningTimer_003E5__7;
									_003C_003E2__current = null;
									_003CopeningTimer_003E5__7 = num13;
									_003C_003E1__state = 2;
									goto IL_151f;
								}
							}
						}
					}
				}
			}
			else if ((object)dopplegangerGate._fullscreenLight != null)
			{
				PhaserSprite phaserSprite5 = dopplegangerGate._fullscreenLight.setVisible(visible: false);
				float num14 = 0f;
				float num15 = 0f;
				while (true)
				{
					List<PhaserSprite> gateDoors4 = dopplegangerGate._gateDoors;
					if (dopplegangerGate._gateDoors == null)
					{
						break;
					}
					if (!(num14 < (float)gateDoors4._size))
					{
						goto IL_1210;
					}
					if (num15 < (float)gateDoors4._size)
					{
						PhaserSprite[] items4 = gateDoors4._items;
						if (gateDoors4._items == null)
						{
							break;
						}
						bool flag6 = !(num15 < (float)items4.Length);
						if ((object)items4[num15] == null)
						{
							break;
						}
						PhaserSprite phaserSprite6 = items4[num15].setVisible(visible: false);
						num15++;
						num14 = num15;
						continue;
					}
					goto IL_12a9;
				}
			}
			goto IL_12dd;
			IL_1210:
			if ((object)GM.Core != null)
			{
				GM.Core.SetOnlySomePlayersWeaponsActive(1);
				dopplegangerGate._fightTimer = 0f;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				soundConfig.Loop = true;
				SoundManager.PlayMusic(BgmType.BGM_TP_sotn_FestivalOfServants, soundConfig);
				SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0.3f, 2000f);
				goto IL_129b;
			}
			goto IL_12dd;
			IL_12dd:
			throw new NullReferenceException();
			IL_151f:
			return true;
			IL_1303:
			if (_003CfullOpeningTime_003E5__4 > _003CopeningTimer_003E5__7)
			{
				float num16 = _003CopeningTimer_003E5__7 / _003CfullOpeningTime_003E5__4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				num10 = num16 * _003CfullOpeningTime_003E5__4;
				if ((object)_003C_003E4__this != null)
				{
					float num17 = 0f;
					float num18 = 1f;
					float num19 = 3f;
					float num20 = 0f;
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					object obj4 = default(object);
					IntPtr intPtr = default(IntPtr);
					object obj5 = default(object);
					PhaserSprite phaserSprite7 = default(PhaserSprite);
					float num51 = default(float);
					PhaserSprite phaserSprite8 = default(PhaserSprite);
					float num52 = default(float);
					while (num20 < (float)dopplegangerGate._howManyGates)
					{
						if (dopplegangerGate._gateDoors != null)
						{
							float num21 = num17 + num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (dopplegangerGate._gateDoors != null)
							{
								float num22 = num17 * 2f;
								float num23 = num22 + 1f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								object obj2 = num17 & 1;
								SfxType sfxType = (SfxType)(0 - obj2);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb esi,esi\"");
								sprite2 = (Sprite)(sprite2 & 0x5A);
								float num24 = num17 * _003CopeningTimeBeforeEachDoor_003E5__6;
								float num25 = num10 - num24;
								float num26 = num17 * _003CopeningTimeBeforeEachDoor_003E5__6;
								float num27 = _003ClastEffectiveOpeningTimer_003E5__8 - num26;
								if (!(0f < num27) && num25 > 0f)
								{
									PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.LittleHit, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
									PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
									if (num17 == 0f)
									{
										PlaySoundResult playSoundResult3 = SoundManager.PlaySoundNonAlloc(SfxType.Bangu, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
									}
									PlaySoundResult playSoundResult4 = SoundManager.PlaySoundNonAlloc(SfxType.Bell, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
									object obj3 = dopplegangerGate._howManyGates - 1;
									bool flag7 = (object)num17 != obj3;
									float num28 = 0f;
									obj4 = 1056964608;
									int num9 = 10;
									sfxType = SfxType.Bell;
									if (!flag7)
									{
										PlaySoundResult playSoundResult5 = SoundManager.PlaySoundNonAlloc(SfxType.Explosion2, 1000f, 10, 0f, volume, rate, detune, loop, 1f);
										num28 = 0f;
										obj4 = 1056964608;
										num9 = 10;
										sfxType = SfxType.Explosion2;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,r14d\"");
								float num29 = _003CopeningTimer_003E5__7 * 200f;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm13,esi\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,r14d\"");
								float num30 = _003CopeningTimer_003E5__7 * 200f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								float num31 = num30 * 0.003f;
								if (dopplegangerGate._gateDoors != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									if (intPtr != (IntPtr)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FEC910");
										float num32 = (float)obj5 * num31;
										float num35;
										if (!(num25 > -0.25f))
										{
											nint num33 = (nint)typeof(float2);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v56 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
											nint num34 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rcx_v37 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
											num35 = 0f;
										}
										else
										{
											float num36 = num25 + 1f;
											num35 = num32 / num36;
											nint num34 = intPtr;
										}
										float num37 = num18 * 4f;
										float num38 = num37 + 0.25f;
										float num39 = ((0f > num38) ? 0f : ((num38 > 1f) ? 1f : num38));
										num18 = ((0f > num25) ? 0f : ((num25 > 1f) ? 1f : num25));
										bool flag8 = !(num18 > _003CrotationStartPoint_003E5__5);
										float num40 = 0f;
										float num41 = 0f;
										if (!flag8)
										{
											object obj6 = dopplegangerGate._howManyGates - 1;
											bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num17) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
											num40 = 0f;
											num41 = 0f;
											if (!flag9)
											{
												float num42 = 1f - _003CrotationStartPoint_003E5__5;
												num40 = num18 - _003CrotationStartPoint_003E5__5;
												float num43 = 1f / num42;
												float num44 = num43 * num40;
												num41 = num44 * _003CfullRotationAmount_003E5__2;
											}
										}
										float num45 = num41 * ((float)Math.PI / 180f);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
										float num46 = num41 * ((float)Math.PI / 180f);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
										float num47 = num46 * _003CdoorOpeningDistance_003E5__3;
										float num48 = num47 * num18;
										if ((object)phaserSprite7 != null)
										{
											phaserSprite7.angle = num41;
											if ((object)dopplegangerGate._gatePortal != null)
											{
												float2 position = dopplegangerGate._gatePortal.position;
												float num49 = (float)obj4 - num48;
												float num50 = num35 + num49;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
												bool flag10 = (object)phaserSprite7._spriteRenderer == null;
												phaserSprite7._spriteRenderer.color = (Color)(&num51);
												bool flag11 = (object)phaserSprite8 == null;
												phaserSprite8.angle = num41;
												bool flag12 = (object)dopplegangerGate._gatePortal == null;
												float2 position2 = dopplegangerGate._gatePortal.position;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
												bool flag13 = (object)phaserSprite8._spriteRenderer == null;
												phaserSprite8._spriteRenderer.color = (Color)(&num52);
												num17++;
												num51 = num39;
												int num9 = 0;
												num19 = num41;
												num16 = num39;
												num20 = num17;
												continue;
											}
										}
									}
								}
							}
						}
						goto IL_12dd;
					}
					if (!(num18 > 0f))
					{
						if ((object)dopplegangerGate._openingLight != null)
						{
							PhaserSprite phaserSprite9 = dopplegangerGate._openingLight.setVisible(visible: false);
							if ((object)dopplegangerGate._fullscreenLight != null)
							{
								PhaserSprite phaserSprite10 = dopplegangerGate._fullscreenLight.setVisible(visible: false);
								goto IL_0e85;
							}
						}
					}
					else
					{
						float num53 = num18 + 0.5f;
						if (0f > num53 || num53 > 1f)
						{
						}
						if ((object)dopplegangerGate._openingLight != null)
						{
							float num54 = _003CdoorOpeningDistance_003E5__3 * 100f;
							float num55 = num54 * num18;
							float num56 = num55 * 5f;
							float xScale = num56 / 5f;
							PhaserSprite phaserSprite11 = dopplegangerGate._openingLight.setScale(xScale, (float?)(object)1);
							if ((object)dopplegangerGate._openingLight != null)
							{
								PhaserSprite phaserSprite12 = dopplegangerGate._openingLight.setAlpha(1f);
								if ((object)dopplegangerGate._openingLight != null)
								{
									PhaserSprite phaserSprite13 = dopplegangerGate._openingLight.setVisible(visible: true);
									if ((object)dopplegangerGate._fullscreenLight != null)
									{
										PhaserSprite phaserSprite14 = dopplegangerGate._fullscreenLight.setVisible(visible: true);
										if ((object)dopplegangerGate._fullscreenLight != null)
										{
											float alpha3 = num18 * num18;
											PhaserSprite phaserSprite15 = dopplegangerGate._fullscreenLight.setAlpha(alpha3);
											if ((object)GM.Core != null)
											{
												PhaserScene scene = GM.Core.scene;
												if (scene != null)
												{
													PhaserScene.Renderer renderer2 = scene._renderer;
													if (scene._renderer != null && (object)dopplegangerGate._fullscreenLight != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
														goto IL_0e85;
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
			else if ((object)_003C_003E4__this != null)
			{
				dopplegangerGate._gateState = GateState.Open;
				_003C_003E4__this.SpawnDopplegangers();
				if ((object)dopplegangerGate._openingLight != null)
				{
					PhaserSprite phaserSprite16 = dopplegangerGate._openingLight.setVisible(visible: false);
					num2 = _003CopeningTimer_003E5__7;
					num3 = _003CfullOpeningTime_003E5__4 + 1f;
					num4 = 1f;
					goto IL_12e4;
				}
			}
			goto IL_12dd;
			IL_12a9:
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			goto IL_12dd;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003C_CloseDoors_003Ed__25(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DopplegangerGate _003C_003E4__this;

		private float _003CopenAmount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0025: Expected I4, but got I8
			//IL_015c: Expected I4, but got I8
			//IL_0165: Expected F4, but got I4
			//IL_016f: Expected F4, but got I4
			//IL_02b4: Expected I4, but got O
			//IL_0250: Expected F4, but got I4
			//IL_00ce: Expected F4, but got I4
			//IL_0201: Expected O, but got F4
			//IL_02ee: Expected F4, but got I4
			//IL_02f8: Expected F4, but got I4
			DopplegangerGate dopplegangerGate = _003C_003E4__this;
			float? volume = default(float?);
			float rate = default(float);
			float detune = default(float);
			bool loop = default(bool);
			float num;
			float num2;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_02a6;
				}
				if (dopplegangerGate._doorLocations != null)
				{
					List<Vector2> doorLocations = dopplegangerGate._doorLocations;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rax_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)0 > (nint)0)
					{
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.LittleHit, 0f, 10, 0f, volume, rate, detune, loop, 1f);
						if (dopplegangerGate._doorBlocks == null)
						{
							goto IL_02a6;
						}
						List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
						if (enumerator.MoveNext())
						{
							throw new NullReferenceException();
						}
						_003CopenAmount_003E5__2 = 1f;
						num = 0f;
						num2 = 0f;
						goto IL_0321;
					}
				}
				Debug.LogError("No door locations!");
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				num = 0f;
				num2 = 0f;
				goto IL_0321;
			}
			goto IL_0259;
			IL_0321:
			if (_003CopenAmount_003E5__2 > num)
			{
				float deltaTime = PauseSystem.DeltaTime;
				if (num > (_003CopenAmount_003E5__2 -= deltaTime))
				{
					_003CopenAmount_003E5__2 = num2;
				}
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, 0);
					_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, 1);
					_003C_003E2__current = num2;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_02a6;
			}
			PlaySoundResult playSoundResult2 = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, num, 10, num, volume, rate, detune, loop, 1f);
			goto IL_0259;
			IL_02a6:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0259:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003C_OpenDoors_003Ed__27(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DopplegangerGate _003C_003E4__this;

		private float _003CopenAmount_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0186: Expected I4, but got I8
			DopplegangerGate dopplegangerGate = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_029e;
				}
				if (dopplegangerGate._doorLocations != null)
				{
					List<Vector2> doorLocations = dopplegangerGate._doorLocations;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v35 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)0 > (nint)0)
					{
						if (dopplegangerGate._mapToken != null)
						{
							GameManager core = GM.Core;
							if ((object)GM.Core == null || core._mapTokens == null)
							{
								goto IL_029e;
							}
							bool flag = ((List<object>)(object)core._mapTokens).Remove((object)dopplegangerGate._mapToken);
							dopplegangerGate._mapToken = null;
						}
						_003CopenAmount_003E5__2 = 0f;
						goto IL_02da;
					}
				}
				Debug.LogError("No door locations!");
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				goto IL_02da;
			}
			goto IL_0147;
			IL_0147:
			return false;
			IL_029e:
			throw new NullReferenceException();
			IL_02da:
			if (1f > _003CopenAmount_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				if ((_003CopenAmount_003E5__2 = deltaTime + _003CopenAmount_003E5__2) > 1f)
				{
					_003CopenAmount_003E5__2 = 1f;
				}
				if ((object)_003C_003E4__this != null)
				{
					_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, 0);
					_003C_003E4__this.SetDoorOpenAmount(_003CopenAmount_003E5__2, 1);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else if ((object)_003C_003E4__this != null && dopplegangerGate._doorBlocks != null)
			{
				List<PhaserSprite>.Enumerator enumerator = default(List<PhaserSprite>.Enumerator);
				if (enumerator.MoveNext())
				{
					PhaserSprite phaserSprite = null;
					throw new NullReferenceException();
				}
				goto IL_0147;
			}
			goto IL_029e;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public PhaserSprite _gatePortal;

	private PhaserSprite _gateMask;

	private PhaserSprite _gateRainbow;

	private List<PhaserSprite> _gateDoors;

	private GateState _gateState;

	private int _howManyGates;

	private PhaserSprite _openingLight;

	private PhaserSprite _fullscreenLight;

	private List<PhaserSprite> _doorBlocks;

	private List<Vector2> _doorLocations;

	private Rectangle _doorTriggerArea;

	private Rectangle _hardBoundsArea;

	private Rect? _originalHardBounds;

	private Rectangle _cameraLimitsRectangle;

	private List<EnemyDoppleganger> _liveDopplegangers;

	private float _fightTimer;

	private MapToken _mapToken;

	public void SetupGate(float2 position, float scale)
	{
		//IL_004f: Expected O, but got I4
		//IL_0130: Expected O, but got I4
		//IL_0163: Expected I4, but got I8
		//IL_02b9: Expected O, but got I4
		//IL_0305: Expected O, but got I
		//IL_0367: Expected I4, but got I8
		//IL_039e: Expected I4, but got I8
		//IL_1384: Expected O, but got I4
		//IL_041d: Expected O, but got I4
		//IL_13b8: Expected O, but got I4
		//IL_05a0: Expected O, but got I4
		//IL_0629: Expected I4, but got I8
		//IL_0632: Expected O, but got I4
		//IL_0682: Expected O, but got I4
		//IL_06b5: Expected O, but got I4
		//IL_0788: Expected O, but got I4
		//IL_07ea: Expected O, but got I4
		//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac5: Expected O, but got Unknown
		//IL_0db7: Expected O, but got I4
		//IL_0e07: Expected O, but got I4
		//IL_0f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f68: Expected O, but got Unknown
		//IL_1596: Expected F4, but got O
		//IL_034e->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0385->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_03c8->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0400->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_13a0->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0439->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0468->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_04af->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_04e7->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_13d5->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_13fc->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0520->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_053e->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_1423->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0566->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_0584->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_05bc->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_05eb->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_14ea->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_066a->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_069e->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_06d1->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_06ff->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_072e->IL12f4: Incompatible stack heights: 1 vs 0
		//IL_1480->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_0770->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_07a4->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_07d3->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_0806->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_0834->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_0863->IL12f4: Incompatible stack heights: 2 vs 0
		//IL_089d->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_08e4->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_091f->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_096e->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_09fd->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0a4c->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0aed->IL14c9: Incompatible stack heights: 3 vs 1
		//IL_0b1f->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0b4e->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0b70->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_1511->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0c81->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0ca3->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0c1b->IL12f4: Incompatible stack heights: 4 vs 0
		//IL_0c57->IL14ef: Incompatible stack heights: 5 vs 3
		//IL_155e->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0d50->IL12f4: Incompatible stack heights: 4 vs 0
		//IL_0def->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0d8d->IL0d8d: Incompatible stack heights: 5 vs 3
		//IL_0e23->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0e58->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0ea0->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0eef->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0fa7->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0fd6->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_0ff8->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_1104->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_1133->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_1155->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_10a6->IL12f4: Incompatible stack heights: 4 vs 0
		//IL_10e2->IL10e2: Incompatible stack heights: 5 vs 3
		//IL_11a7->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_11e1->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_1203->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_122b->IL12f4: Incompatible stack heights: 3 vs 0
		//IL_12f4->IL1576: Incompatible stack heights: 5 vs 3
		PhaserWorld instance = PhaserWorld.Instance;
		if ((object)instance != null)
		{
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "ThosePeople", "Doppleganger_Portal");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setScale(scale, (float?)(object)0);
				if ((object)phaserSprite2 != null)
				{
					PhaserSprite phaserSprite3 = phaserSprite2.SetMaterial(MaterialType.DefaultSpriteLit);
					if ((object)phaserSprite3 != null)
					{
						PhaserSprite gatePortal = phaserSprite3.setVisible(visible: false);
						_gatePortal = gatePortal;
						PhaserWorld instance2 = PhaserWorld.Instance;
						if ((object)instance2 != null)
						{
							PhaserSprite phaserSprite4 = instance2.AddPhaserSprite(pos, "ThosePeople", "Doppleganger_Mask");
							if ((object)phaserSprite4 != null)
							{
								PhaserSprite phaserSprite5 = phaserSprite4.setScale(scale, (float?)(object)0);
								if ((object)phaserSprite5 != null)
								{
									PhaserSprite phaserSprite6 = phaserSprite5.setDepth(-1701);
									if ((object)phaserSprite6 != null)
									{
										PhaserSprite gateMask = phaserSprite6.setVisible(visible: false);
										_gateMask = gateMask;
										if ((object)_gateMask != null)
										{
											GameObject gameObject = _gateMask.gameObject;
											if ((object)gameObject != null)
											{
												SpriteMask spriteMask = gameObject.AddComponent<SpriteMask>();
												Sprite sprite = SpriteManager.GetSprite("Doppleganger_Mask", "ThosePeople");
												if ((object)spriteMask != null)
												{
													spriteMask.sprite = sprite;
													PhaserWorld instance3 = PhaserWorld.Instance;
													if ((object)instance3 != null)
													{
														PhaserSprite phaserSprite7 = instance3.AddPhaserSprite(pos, "ThosePeople", "Doppleganger_Rainbow");
														if ((object)phaserSprite7 != null)
														{
															PhaserSprite gateRainbow = phaserSprite7.setScale(scale, (float?)(object)0);
															_gateRainbow = gateRainbow;
															SpriteMask gateRainbow2 = (SpriteMask)(object)_gateRainbow;
															if ((object)_gateRainbow != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v13 (UnityEngine.SpriteMask)+28]");
																object obj = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rdi_v13 (UnityEngine.SpriteMask)+28]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v14 (System.Object)+10]");
																	bool flag = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v14 (System.Object)+10]");
																	SpriteRenderer.set_maskInteraction_Injected((IntPtr)0, SpriteMaskInteraction.VisibleInsideMask);
																	List<PhaserSprite> gateDoors = new List<PhaserSprite>();
																	_gateDoors = gateDoors;
																	if ((object)_gateRainbow != null)
																	{
																		PhaserSprite phaserSprite8 = _gateRainbow.setDepth(-1700);
																		if ((object)_gatePortal != null)
																		{
																			PhaserSprite phaserSprite9 = _gatePortal.setDepth(-1600);
																			PhaserWorld instance4 = PhaserWorld.Instance;
																			if ((object)instance4 != null)
																			{
																				PhaserSprite phaserSprite10 = instance4.AddPhaserSprite(pos, "DopplegangerLight", "DopplegangerLight");
																				if ((object)phaserSprite10 != null)
																				{
																					PhaserSprite phaserSprite11 = phaserSprite10.setOrigin(0.5f, (float?)(object)1);
																					if ((object)phaserSprite11 != null)
																					{
																						PhaserSprite phaserSprite12 = phaserSprite11.setScale(1f, (float?)(object)1);
																						if ((object)phaserSprite12 != null)
																						{
																							PhaserSprite phaserSprite13 = phaserSprite12.setDepth(4000);
																							if ((object)phaserSprite13 != null)
																							{
																								PhaserSprite openingLight = phaserSprite13.setVisible(visible: false);
																								_openingLight = openingLight;
																								PhaserWorld instance5 = PhaserWorld.Instance;
																								if ((object)instance5 != null)
																								{
																									PhaserSprite phaserSprite14 = instance5.AddPhaserSprite(pos, "vfx", "WhiteDot");
																									if ((object)phaserSprite14 != null)
																									{
																										PhaserSprite phaserSprite15 = phaserSprite14.setOrigin(0.5f, (float?)(object)1);
																										if ((object)GM.Core != null)
																										{
																											PhaserScene s_scene = ArcadePhysics.s_scene;
																											if (ArcadePhysics.s_scene != null)
																											{
																												PhaserScene.Renderer renderer = s_scene._renderer;
																												if (s_scene._renderer != null && (object)GM.Core != null)
																												{
																													PhaserScene s_scene2 = ArcadePhysics.s_scene;
																													if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)phaserSprite15 != null)
																													{
																														PhaserSprite phaserSprite16 = phaserSprite15.setScale(renderer.screenWidthPixels, (float?)(object)1);
																														if ((object)phaserSprite16 != null)
																														{
																															PhaserSprite phaserSprite17 = phaserSprite16.setDepth(5000);
																															if ((object)phaserSprite17 != null)
																															{
																																PhaserSprite fullscreenLight = phaserSprite17.setVisible(visible: false);
																																_fullscreenLight = fullscreenLight;
																																_howManyGates = 9;
																																int num = -1601;
																																float? num2 = (float?)(object)0;
																																float y = default(float);
																																Action<EnemyController> action = default(Action<EnemyController>);
																																object obj3 = default(object);
																																while (true)
																																{
																																	PhaserWorld instance6 = PhaserWorld.Instance;
																																	if ((object)instance6 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite18 = instance6.AddPhaserSprite(position, "ThosePeople", "Doppleganger_Door");
																																	if ((object)phaserSprite18 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite19 = phaserSprite18.setOrigin(1f, (float?)(object)1);
																																	if ((object)phaserSprite19 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite20 = phaserSprite19.setScale(scale, (float?)(object)0);
																																	if ((object)phaserSprite20 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite21 = phaserSprite20.setDepth(num);
																																	if ((object)phaserSprite21 == null)
																																	{
																																		break;
																																	}
																																	object spriteRenderer = phaserSprite21._spriteRenderer;
																																	if ((object)phaserSprite21._spriteRenderer == null)
																																	{
																																		break;
																																	}
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v20 (System.Object)+10]");
																																	bool flag2 = (nint)0 == 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rdi_v20 (System.Object)+10]");
																																	SpriteRenderer.set_maskInteraction_Injected((IntPtr)0, SpriteMaskInteraction.VisibleInsideMask);
																																	PhaserWorld instance7 = PhaserWorld.Instance;
																																	if ((object)instance7 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite22 = instance7.AddPhaserSprite(pos, "ThosePeople", "Doppleganger_Door");
																																	if ((object)phaserSprite22 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite23 = phaserSprite22.setOrigin(0f, (float?)(object)1);
																																	if ((object)phaserSprite23 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite24 = phaserSprite23.setFlipX(flipX: true);
																																	if ((object)phaserSprite24 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite25 = phaserSprite24.setScale(scale, (float?)(object)0);
																																	if ((object)phaserSprite25 == null)
																																	{
																																		break;
																																	}
																																	PhaserSprite phaserSprite26 = phaserSprite25.setDepth(num);
																																	if ((object)phaserSprite26 == null)
																																	{
																																		break;
																																	}
																																	SpriteRenderer spriteRenderer2 = phaserSprite26._spriteRenderer;
																																	if ((object)phaserSprite26._spriteRenderer == null)
																																	{
																																		break;
																																	}
																																	bool flag3 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
																																	SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
																																	phaserSprite21.EnsureSpriteRenderer();
																																	Material material = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
																																	if ((object)phaserSprite21._spriteRenderer == null)
																																	{
																																		break;
																																	}
																																	((Renderer)phaserSprite21._spriteRenderer).SetMaterial(material);
																																	phaserSprite26.EnsureSpriteRenderer();
																																	Material material2 = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
																																	if ((object)phaserSprite26._spriteRenderer == null)
																																	{
																																		break;
																																	}
																																	((Renderer)phaserSprite26._spriteRenderer).SetMaterial(material2);
																																	List<object> gateDoors2 = (List<object>)(object)_gateDoors;
																																	if (_gateDoors == null)
																																	{
																																		break;
																																	}
																																	int version = gateDoors2._version + 1;
																																	gateDoors2._version = version;
																																	object[] items = gateDoors2._items;
																																	if (gateDoors2._items == null)
																																	{
																																		break;
																																	}
																																	if (gateDoors2._size >= items.Length)
																																	{
																																		((List<object>)(object)_gateDoors).AddWithResize((object)phaserSprite21);
																																	}
																																	else
																																	{
																																		int size = gateDoors2._size + 1;
																																		gateDoors2._size = size;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																	}
																																	List<object> gateDoors3 = (List<object>)(object)_gateDoors;
																																	if (_gateDoors == null)
																																	{
																																		break;
																																	}
																																	int version2 = gateDoors3._version + 1;
																																	gateDoors3._version = version2;
																																	object[] items2 = gateDoors3._items;
																																	if (gateDoors3._items == null)
																																	{
																																		break;
																																	}
																																	if (gateDoors3._size >= items2.Length)
																																	{
																																		((List<object>)(object)_gateDoors).AddWithResize((object)phaserSprite26);
																																	}
																																	else
																																	{
																																		int size2 = gateDoors3._size + 1;
																																		gateDoors3._size = size2;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																	}
																																	num2 = (float?)(object)((_003F?)num2 + 1);
																																	num--;
																																	if ((nint)num2 < _howManyGates)
																																	{
																																		continue;
																																	}
																																	_gateState = GateState.ClosedDoorsOpen;
																																	GameManager core = GM.Core;
																																	if ((object)GM.Core == null)
																																	{
																																		break;
																																	}
																																	Stage stage = core._stage;
																																	if ((object)core._stage == null || (object)stage._tilingTileset == null)
																																	{
																																		break;
																																	}
																																	List<Rectangle> scriptRectangularLocations = stage._tilingTileset.GetScriptRectangularLocations("DopplegangerBounds");
																																	if (scriptRectangularLocations != null && scriptRectangularLocations._size >= 1)
																																	{
																																		bool flag4 = scriptRectangularLocations._size <= 0;
																																		Rectangle[] items3 = scriptRectangularLocations._items;
																																		if (scriptRectangularLocations._items == null)
																																		{
																																			break;
																																		}
																																		bool flag5 = items3.Length <= 0;
																																		_hardBoundsArea = items3[0];
																																	}
																																	GameManager core2 = GM.Core;
																																	if ((object)GM.Core == null)
																																	{
																																		break;
																																	}
																																	Stage stage2 = core2._stage;
																																	if ((object)core2._stage == null || (object)stage2._tilingTileset == null)
																																	{
																																		break;
																																	}
																																	List<Rectangle> scriptRectangularLocations2 = stage2._tilingTileset.GetScriptRectangularLocations("DopplegangerBounds", autoScaleAndOffset: true);
																																	if (scriptRectangularLocations2 != null && scriptRectangularLocations2._size >= 1)
																																	{
																																		bool flag6 = scriptRectangularLocations2._size <= 0;
																																		Rectangle[] items4 = scriptRectangularLocations2._items;
																																		if (scriptRectangularLocations2._items == null)
																																		{
																																			break;
																																		}
																																		bool flag7 = items4.Length <= 0;
																																		_doorTriggerArea = items4[0];
																																	}
																																	List<PhaserSprite> list = null;
																																	PhaserSprite[] items5 = null;
																																	list._items = items5;
																																	_doorBlocks = list;
																																	float? num3 = (float?)(object)0;
																																	while (true)
																																	{
																																		List<object> doorBlocks = (List<object>)(object)_doorBlocks;
																																		PhaserWorld instance8 = PhaserWorld.Instance;
																																		if ((object)instance8 == null)
																																		{
																																			break;
																																		}
																																		PhaserSprite phaserSprite27 = instance8.AddPhaserSprite(position, "ThosePeople", "TP_DoorBlock");
																																		if ((object)phaserSprite27 == null)
																																		{
																																			break;
																																		}
																																		PhaserSprite phaserSprite28 = phaserSprite27.setScale(1f, (float?)(object)0);
																																		if ((object)phaserSprite28 == null)
																																		{
																																			break;
																																		}
																																		phaserSprite28.EnsureSpriteRenderer();
																																		Material material3 = MaterialManager.GetMaterial(MaterialType.DefaultSpriteLit);
																																		if ((object)phaserSprite28._spriteRenderer == null)
																																		{
																																			break;
																																		}
																																		((Renderer)phaserSprite28._spriteRenderer).SetMaterial(material3);
																																		PhaserSprite item = phaserSprite28.setVisible(visible: false);
																																		if (_doorBlocks == null)
																																		{
																																			break;
																																		}
																																		int version3 = doorBlocks._version + 1;
																																		doorBlocks._version = version3;
																																		object[] items6 = doorBlocks._items;
																																		if (doorBlocks._items == null)
																																		{
																																			break;
																																		}
																																		if (doorBlocks._size >= items6.Length)
																																		{
																																			((List<object>)(object)_doorBlocks).AddWithResize((object)item);
																																		}
																																		else
																																		{
																																			int size3 = doorBlocks._size + 1;
																																			doorBlocks._size = size3;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																		}
																																		num3 = (float?)(object)((_003F?)num3 + 1);
																																		if ((nint)num3 < 8)
																																		{
																																			continue;
																																		}
																																		GameManager core3 = GM.Core;
																																		if ((object)GM.Core == null)
																																		{
																																			break;
																																		}
																																		Stage stage3 = core3._stage;
																																		if ((object)core3._stage == null || (object)stage3._tilingTileset == null)
																																		{
																																			break;
																																		}
																																		List<Rectangle> scriptRectangularLocations3 = stage3._tilingTileset.GetScriptRectangularLocations("DopplegangerCameraLimits", autoScaleAndOffset: true);
																																		if (scriptRectangularLocations3 != null && scriptRectangularLocations3._size > 0)
																																		{
																																			bool flag8 = scriptRectangularLocations3._size <= 0;
																																			Rectangle[] items7 = scriptRectangularLocations3._items;
																																			if (scriptRectangularLocations3._items == null)
																																			{
																																				break;
																																			}
																																			bool flag9 = items7.Length <= 0;
																																			_cameraLimitsRectangle = items7[0];
																																		}
																																		GameManager core4 = GM.Core;
																																		if ((object)GM.Core == null)
																																		{
																																			break;
																																		}
																																		Stage stage4 = core4._stage;
																																		if ((object)core4._stage == null || (object)stage4._tilingTileset == null)
																																		{
																																			break;
																																		}
																																		List<Vector2> specialLocations = stage4._tilingTileset.GetSpecialLocations("DopplegangerDoor");
																																		_doorLocations = specialLocations;
																																		MapToken mapToken = new MapToken();
																																		if (mapToken == null)
																																		{
																																			break;
																																		}
																																		mapToken.texture = "TP_items";
																																		mapToken.frameName = "TP_BossToken";
																																		mapToken.x = (float)position;
																																		mapToken.y = y;
																																		_mapToken = mapToken;
																																		GameManager core5 = GM.Core;
																																		if ((object)GM.Core == null || core5._mapTokens == null)
																																		{
																																			break;
																																		}
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
																																		if ((object)GM.Core == null)
																																		{
																																			break;
																																		}
																																		if (!GM.Core.IsStageHost)
																																		{
																																			Delegate obj2 = Delegate.Combine(b: new Action<EnemyController>(OnRemoteEnemySpawned), a: EnemyInstantiator.OnRemoteEnemySpawned);
																																			if ((object)obj2 == null)
																																			{
																																				EnemyInstantiator.OnRemoteEnemySpawned = null;
																																				return;
																																			}
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																			bool flag10 = action == null;
																																			EnemyInstantiator.OnRemoteEnemySpawned = action;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																			bool flag11 = obj3 == null;
																																		}
																																		return;
																																	}
																																	break;
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
		throw new NullReferenceException();
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType == EnemyType.TP_BOSS_DOPPLEGANGER)
		{
			if (_liveDopplegangers == null)
			{
				List<EnemyDoppleganger> liveDopplegangers = new List<EnemyDoppleganger>();
				_liveDopplegangers = liveDopplegangers;
			}
			EnemyDoppleganger component = enemy.GetComponent<EnemyDoppleganger>();
			component.SetupDoppleganger(component._characterToCopy, this);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6410");
		}
	}

	private void StopRegularSpawning()
	{
		//IL_006c: Expected O, but got I4
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (!flag)
		{
			EnemyController[] items;
			do
			{
				GameManager core3 = GM.Core;
				Stage stage2 = core3._stage;
				List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
				if ((nint)obj < spawnedEnemies2._size)
				{
					items = spawnedEnemies2._items;
					items[obj].Disappear();
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)items[obj] >= 0);
		}
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		if (stage3._spawnTimer != null)
		{
			stage3._spawnTimer.Cancel();
		}
		if (stage3._destructibleTimer != null)
		{
			stage3._destructibleTimer.Cancel();
		}
	}

	private void ResumeRegularSpawning()
	{
		GameManager core = GM.Core;
		core._canRunTickerTimer = true;
		GameManager core2 = GM.Core;
		core2._stage.StartTimers();
	}

	protected override void OnUpdate()
	{
		//IL_02fb: Expected I, but got O
		//IL_032c: Expected O, but got I
		//IL_00b8: Expected O, but got I4
		//IL_0187: Expected I, but got O
		//IL_01b8: Expected O, but got I
		//IL_0356: Expected O, but got I
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_01e2: Expected O, but got I
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected I4, but got Unknown
		bool flag = (object)_gateRainbow == null;
		Component component = this;
		if (!flag)
		{
			Transform transform = _gateRainbow.transform;
			bool flag2 = (object)transform == null;
			component = _gateRainbow;
			if (!flag2)
			{
				Vector3 localEulerAngles = transform.localEulerAngles;
				float deltaTime = PauseSystem.DeltaTime;
				float num = deltaTime * 45f;
				float angle = localEulerAngles.z - num;
				_gateRainbow.angle = angle;
				bool flag3 = _gateState == GateState.ClosedDoorsOpen;
				if (!flag3)
				{
					object obj = _gateState - 1;
					if (!flag3)
					{
						object obj2 = obj - 1;
						if (flag3 || (nint)obj2 != 1)
						{
							return;
						}
						float deltaTime2 = PauseSystem.DeltaTime;
						float fightTimer = deltaTime2 + _fightTimer;
						_fightTimer = fightTimer;
						bool flag4 = (object)GM.Core == null;
						component = GM.Core;
						if (!flag4)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
							int onlySomePlayersWeaponsActive = transform + 1;
							GM.Core.SetOnlySomePlayersWeaponsActive(onlySomePlayersWeaponsActive);
							return;
						}
					}
					else
					{
						nint num2 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v34 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num3 = 0;
						GameManager core = GM.Core;
						bool flag5 = (object)GM.Core == null;
						component = (Component)num3;
						if (!flag5)
						{
							bool flag6 = core._mainCharacters == null;
							component = (Component)num3;
							if (!flag6)
							{
								List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
								if (!enumerator.MoveNext())
								{
									return;
								}
								if ((object)_gatePortal != null)
								{
									float2 position = _gatePortal.position;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
						}
					}
				}
				else
				{
					if (_doorTriggerArea == null)
					{
						_gateState = GateState.ClosedAndReady;
						return;
					}
					nint num4 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v18 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num5 = 0;
					GameManager core2 = GM.Core;
					bool flag7 = (object)GM.Core == null;
					component = (Component)num5;
					if (!flag7)
					{
						bool flag8 = core2._mainCharacters == null;
						component = (Component)num5;
						if (!flag8)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
							if (enumerator2.MoveNext())
							{
								Rectangle doorTriggerArea = _doorTriggerArea;
								ArcadeSprite arcadeSprite = null;
								throw new NullReferenceException();
							}
							CloseDoors();
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void CloseDoors()
	{
		//IL_00b1: Expected O, but got I4
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: true);
		GM.Core.SetAllPlayersWeaponsActive(active: false);
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 2000f);
		GameManager core = GM.Core;
		core._canRunTickerTimer = false;
		GameManager core2 = GM.Core;
		Stage stage = core2._stage;
		List<EnemyController> spawnedEnemies = stage._spawnedEnemies;
		bool flag = (nint)stage._spawnedEnemies < 0;
		object obj = spawnedEnemies._size - 1;
		if (!flag)
		{
			EnemyController[] items;
			do
			{
				GameManager core3 = GM.Core;
				Stage stage2 = core3._stage;
				List<EnemyController> spawnedEnemies2 = stage2._spawnedEnemies;
				if ((nint)obj < spawnedEnemies2._size)
				{
					items = spawnedEnemies2._items;
					items[obj].Disappear();
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)items[obj] >= 0);
		}
		GameManager core4 = GM.Core;
		Stage stage3 = core4._stage;
		if (stage3._spawnTimer != null)
		{
			stage3._spawnTimer.Cancel();
		}
		if (stage3._destructibleTimer != null)
		{
			stage3._destructibleTimer.Cancel();
		}
		GameManager core5 = GM.Core;
		Rectangle hardBoundsArea = _hardBoundsArea;
		_originalHardBounds = core5._003CHardBounds_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v36 (VampireSurvivors.Framework.GameManager)+388]");
		_ = 0;
		float xMax = hardBoundsArea._width + hardBoundsArea._x;
		float yMax = default(float);
		bool skipInverseCalculation = default(bool);
		GM.Core.SetHardBoundsMinMax(hardBoundsArea._x, hardBoundsArea._y, xMax, yMax, skipInverseCalculation);
		_gateState = GateState.ClosedAndReady;
		_003C_CloseDoors_003Ed__25 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj2);
		if (_cameraLimitsRectangle != null)
		{
			PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
			platformZoneMovement._limitCameraPosition = true;
			PlatformZoneMovement._003CInstance_003Ek__BackingField.SetCameraLimits(_cameraLimitsRectangle);
		}
	}

	public void OpenDoors()
	{
		//IL_0072: Expected O, but got I4
		//IL_0149: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		SpeedupManager instance = SpeedupManager.Instance;
		instance.SetSpeedupBlocked(isBlocked: false);
		GM.Core.SetAllPlayersWeaponsActive(active: true);
		GameManager core = GM.Core;
		core._canRunTickerTimer = true;
		GameManager core2 = GM.Core;
		core2._stage.StartTimers();
		GameManager core3 = GM.Core;
		core3._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
		GameManager core4 = GM.Core;
		core4._003CHardBounds_003Ek__BackingField = _originalHardBounds;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.DopplegangerGate)+90]");
		_ = 0;
		_003C_OpenDoors_003Ed__27 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
		PlatformZoneMovement platformZoneMovement = PlatformZoneMovement._003CInstance_003Ek__BackingField;
		if (platformZoneMovement._limitCameraPosition)
		{
			platformZoneMovement._blendAfterCameraLimitsDisabled = true;
		}
		platformZoneMovement.MinCameraX = (float?)(object)0;
		platformZoneMovement.MinCameraY = (float?)(object)0;
		platformZoneMovement.MaxCameraX = (float?)(object)0;
		platformZoneMovement.MaxCameraY = (float?)(object)0;
		platformZoneMovement._limitCameraPosition = false;
	}

	private IEnumerator _CloseDoors()
	{
		_003C_CloseDoors_003Ed__25 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void AwardChest(float2 location)
	{
		//IL_0033: Expected F4, but got I4
		//IL_007d: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_04a3: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_04cb: Expected O, but got I
		//IL_01ab: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_04f3: Expected O, but got I
		//IL_02d6: Expected O, but got I
		//IL_02bb: Expected O, but got I4
		//IL_051b: Expected O, but got I
		//IL_0340: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_0543: Expected O, but got I
		//IL_03aa: Expected O, but got I
		//IL_038f: Expected O, but got I4
		//IL_056b: Expected O, but got I
		//IL_0414: Expected O, but got I
		//IL_03f9: Expected O, but got I4
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.TP_sfx_Pickup, 0f, 10, 0f, volume, rate, detune, loop, 1f);
		Treasure treasure = new Treasure();
		List<float> list = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(0.1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1036831949;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v7+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(100f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 1120403456;
		}
		treasure._003Cchances_003Ek__BackingField = list;
		treasure._003Clevel_003Ek__BackingField = 3;
		List<PrizeType?> list2 = new List<PrizeType?>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v14+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v16+18]");
		if (num7 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v18+18]");
		if (num8 >= 0)
		{
			list2.AddWithResize((PrizeType?)(object)1);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rax_v18 (System.Collections.Generic.List`1<System.Nullable`1<VampireSurvivors.Data.PrizeType>>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 1;
		}
		treasure._003CprizeTypes_003Ek__BackingField = list2;
		GameManager core = GM.Core;
		int num9 = core._stage.SetTreasureLevelFromChance(treasure);
		treasure._003Clevel_003Ek__BackingField = num9;
		Vector2 pos = default(Vector2);
		TreasureChest treasureChest = GM.Core.MakeTreasure(pos, treasure);
	}

	private IEnumerator _OpenDoors()
	{
		_003C_OpenDoors_003Ed__27 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SetDoorOpenAmount(float amount, int doorID)
	{
		//IL_005b: Expected O, but got I4
		//IL_0072: Expected O, but got I4
		//IL_0108: Expected I4, but got I8
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0048->IL020e: Incompatible stack heights: 1 vs 0
		//IL_031a->IL020e: Incompatible stack heights: 1 vs 0
		//IL_00c2->IL020e: Incompatible stack heights: 2 vs 0
		//IL_00e8->IL020e: Incompatible stack heights: 2 vs 0
		//IL_0130->IL020e: Incompatible stack heights: 2 vs 0
		//IL_017f->IL020e: Incompatible stack heights: 3 vs 0
		//IL_01a6->IL020e: Incompatible stack heights: 3 vs 0
		//IL_01f4->IL020e: Incompatible stack heights: 3 vs 0
		//IL_02f1->IL02f6: Incompatible stack heights: 6 vs 1
		List<Vector2> doorLocations = _doorLocations;
		if (_doorLocations != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag = (nint)doorID >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v2 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				object obj = doorID * 4;
				int num = -doorID;
				object obj2 = num * 4;
				Vector3 value = default(Vector3);
				while (true)
				{
					List<PhaserSprite> doorBlocks = _doorBlocks;
					if (_doorBlocks == null)
					{
						break;
					}
					bool flag2 = (nint)obj >= doorBlocks._size;
					PhaserSprite[] items = doorBlocks._items;
					if (doorBlocks._items == null || (object)items[obj] == null)
					{
						break;
					}
					PhaserSprite phaserSprite = items[obj].setDepth(-1999);
					List<PhaserSprite> doorBlocks2 = _doorBlocks;
					if (_doorBlocks == null)
					{
						break;
					}
					bool flag3 = (nint)obj >= doorBlocks2._size;
					PhaserSprite[] items2 = doorBlocks2._items;
					if (doorBlocks2._items == null || (object)items2[obj] == null)
					{
						break;
					}
					Transform transform = items2[obj].transform;
					Transform transform2 = items2[obj].transform;
					if ((object)transform2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v29 (UnityEngine.Transform)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v29 (UnityEngine.Transform)+10]");
					float ret;
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					obj++;
					object obj3 = obj2 + obj;
					if ((nint)obj3 >= 4)
					{
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void StartOpening()
	{
		_gateState = GateState.Opening;
		_003CRunOpeningAnimation_003Ed__30 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator RunOpeningAnimation()
	{
		_003CRunOpeningAnimation_003Ed__30 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void SpawnDopplegangers()
	{
		//IL_00cf: Expected I, but got O
		//IL_00e5: Expected O, but got I
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_015c: Expected I, but got O
		//IL_019e: Expected O, but got I4
		//IL_01b5: Expected I, but got I8
		//IL_0145: Expected I, but got I8
		List<EnemyDoppleganger> liveDopplegangers = new List<EnemyDoppleganger>();
		_liveDopplegangers = liveDopplegangers;
		GameManager core = GM.Core;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			if ((flag3 ? 1 : 0) >= mainCharacters._size)
			{
				break;
			}
			_003C_003Ec__DisplayClass31_0 obj = new _003C_003Ec__DisplayClass31_0();
			obj._003C_003E4__this = this;
			obj.index = (flag2 ? 1 : 0);
			Action action = null;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v3 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass31_0._003CSpawnDopplegangers_003Eb__0);
			((Delegate)action).m_target = obj;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v3 (Il2CppMethodInfo)+4C]");
			object obj2 = (nint)0 >> 4;
			object obj3 = obj2 & 1;
			nint num2;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r10_v3 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num2 = unchecked((nint)6447293664L);
					goto IL_0195;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num2 = ((Delegate)action).method_ptr;
			goto IL_0195;
			IL_0195:
			object obj4 = 24;
			((Delegate)action).extra_arg = unchecked((nint)6447293568L);
			float duration = (float)(flag ? 1 : 0) * 0.001f;
			Timer timer = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			flag = (byte)((flag ? 1u : 0u) + 1000u) != 0;
			core = GM.Core;
			flag3 = flag2;
		}
	}

	private IEnumerator RunClosingAnimation()
	{
		_003CRunClosingAnimation_003Ed__32 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void OnDopplegangerDied(EnemyDoppleganger doppleganger)
	{
		bool flag = ((List<object>)(object)_liveDopplegangers).Remove((object)doppleganger);
		List<EnemyDoppleganger> liveDopplegangers = _liveDopplegangers;
		if (liveDopplegangers._size <= 0 && _gateState == GateState.Open)
		{
			_gateState = GateState.Closing;
			_003CRunClosingAnimation_003Ed__32 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	protected override void OnDestroy()
	{
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<EnemyController> action = default(Action<EnemyController>);
		if (action != null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	public DopplegangerGate()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
