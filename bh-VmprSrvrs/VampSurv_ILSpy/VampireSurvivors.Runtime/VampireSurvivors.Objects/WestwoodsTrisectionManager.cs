using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects;

public class WestwoodsTrisectionManager : StageEventTrisectionManager
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public float r;

		internal bool _003CChooseEvent_003Eb__0(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x != null)
			{
				bool flag = (float)x.weight < r;
				return !flag;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public WestwoodsTrisectionManager _003C_003E4__this;

		public float tweenCounterValue;

		public Action onEventSelected;

		internal void _003CSpinnn_003Eb__0()
		{
			//IL_006a: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_wheelOfFortuneFanfare, soundConfig, 0f, 10, time);
			_003C_003E4__this.HideCircles();
			WestwoodsTrisectionManager westwoodsTrisectionManager = _003C_003E4__this;
			westwoodsTrisectionManager._isSpinning = false;
		}

		internal void _003CSpinnn_003Eb__1()
		{
			WestwoodsTrisectionManager westwoodsTrisectionManager = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj = default(object);
			if (obj == null)
			{
				tweenCounterValue = westwoodsTrisectionManager._tweenCounterTargetValue;
				if (westwoodsTrisectionManager._tweenCounterTargetValue < 12f)
				{
					_003C_003E4__this.RotateEventNames();
				}
				else
				{
					_003C_003E4__this.HighlightEventName(onEventSelected);
				}
			}
		}
	}

	private PhaserSprite _wheelOfFortune;

	private PhaserSprite _needleArrow;

	private MultiTargetTween _tweenWheelOfFortune;

	private MultiTargetTween _tweenShowNeedle;

	private const string UITextureName = "UI";

	public bool _isSpinning;

	public bool _isIdle;

	private float _wheelAngleAtLastTickAudio;

	private float _minTimeBetweenTicks;

	private float _tickTimer;

	private const float AnglePerTick = 30f;

	private const float TickVolume = 2f;

	private const float FanfareVolume = 0.5f;

	private Action m_OnUnlockZoneEvent;

	private readonly SoundManager.SoundConfig _fanfareSoundConfig;

	public int queuedSpins;

	public event Action OnUnlockZoneEvent
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 456;
			Delegate obj2 = this.m_OnUnlockZoneEvent;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 456;
			Delegate obj2 = this.m_OnUnlockZoneEvent;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public override void Init(Stage stage)
	{
		base.Init(stage);
		_dontRepeatEvents = true;
	}

	protected unsafe override void CreateUI()
	{
		//IL_0008: Expected O, but got Ref
		//IL_012f: Expected O, but got Ref
		//IL_01f3: Expected O, but got I
		//IL_02de: Expected O, but got Ref
		//IL_04f8: Expected O, but got Ref
		//IL_0533: Expected O, but got Ref
		//IL_0571: Expected O, but got Ref
		//IL_057f: Expected O, but got Ref
		//IL_05d4: Expected O, but got Ref
		//IL_063f: Expected O, but got Ref
		//IL_0666: Expected O, but got I
		//IL_040d: Expected O, but got I4
		//IL_0445: Expected O, but got I4
		//IL_06a4->IL044a: Incompatible stack heights: 8 vs 0
		//IL_042b->IL044a: Incompatible stack heights: 8 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
			{
				PhaserWorld instance = PhaserWorld.Instance;
				if ((object)instance != null)
				{
					Vector2 vector = default(Vector2);
					PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "wheelOfFortune3", "wheelOfFortune3_0");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setDepth(31757);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite component = phaserSprite2.setAlpha(0f);
							PhaserSprite wheelOfFortune = RenderingExtensions.SetScrollFactor(component, 0f);
							_wheelOfFortune = wheelOfFortune;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
									_ = 0;
									float fontSize = default(float);
									PhaserText component2 = RenderingExtensions.text(s_scene2.add, vector, "", color, fontSize);
									PhaserText phaserText = RenderingExtensions.SetScrollFactor(component2, 0f);
									if ((object)phaserText != null)
									{
										PhaserText phaserText2 = phaserText.SetDepth(31758);
										_ = 0;
										_ = 1056964608;
										_ = 1;
										if ((object)phaserText2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
											PhaserText nextEventText = phaserText2.setOrigin(0f, (float?)(object)0);
											_nextEventText = nextEventText;
											PhaserWorld instance2 = PhaserWorld.Instance;
											if ((object)instance2 != null)
											{
												PhaserSprite phaserSprite3 = instance2.AddPhaserSprite(vector, "UI", "arrow_01");
												if ((object)phaserSprite3 != null)
												{
													PhaserSprite phaserSprite4 = phaserSprite3.setDepth(31758);
													if ((object)phaserSprite4 != null)
													{
														PhaserSprite component3 = phaserSprite4.setAlpha(0f);
														PhaserSprite needleArrow = RenderingExtensions.SetScrollFactor(component3, 0f);
														_needleArrow = needleArrow;
														PhaserSprite component4 = (PhaserSprite)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
														PhaserSprite phaserSprite5 = RenderingExtensions.SetScrollFactor(component4, 1f);
														if ((object)_wheelOfFortune != null)
														{
															float width = _wheelOfFortune.Width;
															if ((object)_needleArrow != null)
															{
																Transform transform = _needleArrow.transform;
																if ((object)transform != null)
																{
																	_ = 0;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v57 (UnityEngine.Transform)+10]");
																	bool flag = (nint)0 == 0;
																	object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v57 (UnityEngine.Transform)+10]");
																	Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v57 (UnityEngine.Transform)+10]");
																	bool flag2 = (nint)0 == 0;
																	object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v57 (UnityEngine.Transform)+10]");
																	Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj4);
																	bool flag3 = (object)_needleArrow == null;
																	Transform transform2 = _needleArrow.transform;
																	_ = (float)Math.PI * -3f / 4f;
																	_ = 0;
																	object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
																	object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																	Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj6, out *(Quaternion*)obj5);
																	bool flag4 = (object)transform2 == null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v67 (UnityEngine.Transform)+10]");
																	bool flag5 = (nint)0 == 0;
																	object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1390 @ rax_v67 (UnityEngine.Transform)+10]");
																	Transform.set_rotation_Injected((IntPtr)0, ref *(Quaternion*)obj7);
																	bool flag6 = (object)_nextEventText == null;
																	Transform transform3 = _nextEventText.transform;
																	bool flag7 = (object)transform3 == null;
																	_ = 0;
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v75 (UnityEngine.Transform)+10]");
																	bool flag8 = (nint)0 == 0;
																	object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rax_v75 (UnityEngine.Transform)+10]");
																	Transform.get_localPosition_Injected((IntPtr)0, out *(Vector3*)obj8);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
																	_nextEventTextDefaultLocalPosition = (Vector3)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
																	_ = 0;
																	_nextEventTextGoldFeverLocalPosition = vector;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-21]");
																	_ = 0;
																	if ((object)_wheelOfFortune != null)
																	{
																		PhaserSprite phaserSprite6 = _wheelOfFortune.setScale(2.5f, (float?)(object)0);
																		if ((object)_needleArrow != null)
																		{
																			PhaserSprite phaserSprite7 = _needleArrow.setScale(2.5f, (float?)(object)0);
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

	protected override void PopulateEvents()
	{
		List<TrisectionEvent> goodEvents = new List<TrisectionEvent>();
		_goodEvents = goodEvents;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 96 Invalid \"Jump target not found in method: 0x186EAC2FB\"");
	}

	protected unsafe override void ChooseEvent()
	{
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_00ae: Expected O, but got Ref
		//IL_00ed: Expected I8, but got I
		//IL_0110: Expected I8, but got I
		//IL_01eb: Expected I4, but got I8
		//IL_013f: Expected I8, but got I
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected Ref, but got Unknown
		//IL_0172: Expected I8, but got I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Ref, but got Unknown
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass21_0();
		object obj = (object)_eventsRng << 13;
		object obj2 = obj ^ (object)_eventsRng;
		object obj3 = (object)_eventsRng >> 9;
		object obj4 = obj3 | 0x3F800000;
		object obj5 = obj2 >> 17;
		object obj6 = obj2 ^ obj5;
		object obj7 = obj6 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
		_eventsRng = eventsRng;
		float num = (float)obj4 - 1f;
		float r = num * (float)_totalWeightNeutral;
		CS_0024_003C_003E8__locals2.r = r;
		Predicate<WeightedTrisectionEventData> match = delegate(WeightedTrisectionEventData x)
		{
			//IL_0050: Expected I4, but got O
			//IL_002c: Invalid comparison between I4 and F4
			if (x == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag7 = (float)x.weight < CS_0024_003C_003E8__locals2.r;
			return !flag7;
		};
		WeightedTrisectionEventData nextChosenEvent = _weightedNeutral.Find(match);
		_nextChosenEvent = nextChosenEvent;
		int num2 = 0;
		WeightedTrisectionEventData nextChosenEvent2 = _nextChosenEvent;
		TrisectionEvent ev = nextChosenEvent2.ev;
		string text = ((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField;
		object obj8 = default(object);
		string text2 = ((Enum)(&obj8)).ToString();
		if ((object)((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField != text2)
		{
			bool flag = ((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField == null;
			ulong num3 = 0uL;
			if (!flag)
			{
				bool flag2 = text2 == null;
				num3 = 0uL;
				if (!flag2)
				{
					bool flag3 = text._stringLength != text2._stringLength;
					num3 = 0uL;
					if (!flag3)
					{
						ref byte second = ref *(byte*)(text2 + 20);
						num3 = (ulong)(text._stringLength + text._stringLength);
						bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField + 20), ref second, num3);
						num2 = 0;
						if (flag4)
						{
							goto IL_0277;
						}
					}
				}
			}
			WeightedTrisectionEventData nextChosenEvent3 = _nextChosenEvent;
			List<TrisectionEvent> triggeredEvents = _triggeredEvents;
			bool flag5 = triggeredEvents._size == 0;
			int num4 = (int)num3;
			if (!flag5)
			{
				num2 = triggeredEvents._size;
				int num5 = Array.IndexOf((object[])triggeredEvents._items, (object)nextChosenEvent3.ev, 0, triggeredEvents._size);
				bool flag6 = num5 != -1;
				num4 = 0;
				if (flag6)
				{
					return;
				}
			}
			WeightedTrisectionEventData nextChosenEvent4 = _nextChosenEvent;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4B00");
			return;
		}
		goto IL_0277;
		IL_0277:
		List<TrisectionEvent> triggeredEvents2 = _triggeredEvents;
		int version = triggeredEvents2._version + 1;
		triggeredEvents2._version = version;
		triggeredEvents2._size = 0;
		if (triggeredEvents2._size > 0)
		{
			Array.Clear(triggeredEvents2._items, 0, triggeredEvents2._size);
		}
	}

	private (float, float) GetEventAngles(TrisectionEvent trisectionEvent)
	{
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0307: Invalid comparison between F4 and I4
		//IL_03bb: Expected I, but got O
		//IL_00de: Expected I, but got O
		//IL_0404: Expected I, but got O
		//IL_0127: Expected I, but got O
		StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CeventType_003Ek__BackingField);
		(float, float) result = default((float, float));
		if (stageEventType > StageEventType.DRAGONSTREAM)
		{
			if (stageEventType > StageEventType.LUCK_BOOST)
			{
				if (stageEventType == StageEventType.MONSTER_RAIN)
				{
					return result;
				}
				if (stageEventType == StageEventType.GENERIC_CIRCLE)
				{
					object obj = ((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField;
					if (((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField != null)
					{
						nint num = (nint)typeof(EnemyType);
						bool flag = (object)obj.GetType() != typeof(EnemyType);
						object obj2 = null;
						if (!flag)
						{
							obj2 = ((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField;
						}
						if (obj2 != null)
						{
							nint num2 = (nint)obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v18 (Il2CppClass<System.Object>)+40]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r9_v7 (Il2CppClass<VampireSurvivors.Data.EnemyType>)+40]");
							if (num3 != 0)
							{
								throw new InvalidCastException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v7 (System.Object)+10]");
							if ((nint)0 > (nint)1200)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v7 (System.Object)+10]");
								if ((nint)0 != 1207)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v7 (System.Object)+10]");
									if ((nint)0 != 1221)
									{
									}
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v7 (System.Object)+10]");
								if ((nint)0 != 871)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v7 (System.Object)+10]");
									if ((nint)0 != 1200)
									{
									}
								}
							}
						}
					}
					goto IL_0587;
				}
			}
			else
			{
				if (stageEventType == StageEventType.SHOOTING_STAR)
				{
					object obj3 = (object)_eventsRng << 13;
					object obj4 = obj3 ^ (object)_eventsRng;
					object obj5 = (object)_eventsRng >> 9;
					object obj6 = obj4 >> 17;
					object obj7 = obj5 | 0x3F800000;
					object obj8 = obj4 ^ obj6;
					object obj9 = obj8 << 5;
					Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj9 ^ obj8);
					float num4 = (float)obj7 - 1f;
					_eventsRng = eventsRng;
					float num5 = num4 + num4;
					float num6 = num5 - 1f;
					if (!(num6 < 0f))
					{
						goto IL_0587;
					}
				}
				if (stageEventType == StageEventType.LUCK_BOOST)
				{
					return result;
				}
			}
		}
		else if (stageEventType > StageEventType.PILE_ASSAULT)
		{
			if (stageEventType == StageEventType.GENERIC_SWARM)
			{
				object obj10 = ((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField;
				if (((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField != null)
				{
					nint num7 = (nint)typeof(EnemyType);
					bool flag2 = (object)obj10.GetType() != typeof(EnemyType);
					object obj11 = null;
					if (!flag2)
					{
						obj11 = ((VampireSurvivors.Data.Stage.Event)trisectionEvent)._003CmoreY_003Ek__BackingField;
					}
					if (obj11 != null)
					{
						nint num8 = (nint)obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v11 (Il2CppClass<System.Object>)+40]");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ r9_v6 (Il2CppClass<VampireSurvivors.Data.EnemyType>)+40]");
						if (num9 != 0)
						{
							return ((float, float))new InvalidCastException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r8_v6 (System.Object)+10]");
						if ((nint)0 != 1208)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r8_v6 (System.Object)+10]");
							if ((nint)0 != 1209)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ r8_v6 (System.Object)+10]");
								if ((nint)0 != 1227)
								{
								}
							}
						}
					}
				}
				goto IL_0587;
			}
			if (stageEventType == StageEventType.DRAGONSTREAM)
			{
				return result;
			}
		}
		else
		{
			switch (stageEventType)
			{
			case StageEventType.JELLY_WALL:
				return result;
			case StageEventType.PILE_ASSAULT:
				return result;
			}
		}
		return result;
		IL_0587:
		return result;
	}

	private float EventAngleRange((float, float) eventAngles)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		object obj = default(object);
		float num = (float)obj * 0.5f;
		object obj2 = (object)_eventsRng << 13;
		object obj3 = obj2 ^ (object)_eventsRng;
		object obj4 = (object)_eventsRng >> 9;
		object obj5 = obj4 | 0x3F800000;
		object obj6 = obj3 >> 17;
		object obj7 = obj3 ^ obj6;
		float num2 = (float)obj5 - 1f;
		object obj8 = obj7 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj8 ^ obj7);
		_eventsRng = eventsRng;
		float num3 = num2 * 1.9f;
		float num4 = num3 - 0.95f;
		return num4 * num;
	}

	public bool CheckForUnlockZoneEvent()
	{
		//IL_00b4: Expected I4, but got O
		WeightedTrisectionEventData nextChosenEvent = _nextChosenEvent;
		if (_nextChosenEvent != null)
		{
			TrisectionEvent ev = nextChosenEvent.ev;
			if (nextChosenEvent.ev != null)
			{
				StageEventType stageEventType = Enum.Parse<StageEventType>(((VampireSurvivors.Data.Stage.Event)ev)._003CeventType_003Ek__BackingField);
				if (stageEventType != StageEventType.LUCK_BOOST)
				{
					return false;
				}
				Action onUnlockZoneEvent = this.m_OnUnlockZoneEvent;
				if (this.m_OnUnlockZoneEvent != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v129.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected override void ShowCircles()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_01b2: Expected I, but got O
		//IL_0208: Expected O, but got I4
		//IL_0224: Expected O, but got I4
		if (_tweenShowCircles != null)
		{
			_tweenShowCircles.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_wheelOfFortune != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.scale = (float?)(object)1;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 500f;
		Func<int, float> staggerDelay = Tweens.Stagger(100f, staggerConfig);
		tweenConfig.staggerDelay = staggerDelay;
		MultiTargetTween tweenShowCircles = Tweens.Add(tweenConfig);
		_tweenShowCircles = tweenShowCircles;
		if (_tweenShowNeedle != null)
		{
			_tweenShowNeedle.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_needleArrow != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 200f;
		tweenConfig2.scale = (float?)(object)1;
		StaggerConfig staggerConfig2 = new StaggerConfig();
		staggerConfig2.ease = Ease.Linear;
		staggerConfig2.start = 500f;
		Func<int, float> staggerDelay2 = Tweens.Stagger(100f, staggerConfig2);
		tweenConfig2.staggerDelay = staggerDelay2;
		MultiTargetTween tweenShowNeedle = Tweens.Add(tweenConfig2);
		_tweenShowNeedle = tweenShowNeedle;
	}

	protected override void HideCircles()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_011a: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		if (_tweenHideCircles != null)
		{
			_tweenHideCircles.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_wheelOfFortune != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_needleArrow != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.scale = (float?)(object)1;
		StaggerConfig staggerConfig = new StaggerConfig();
		staggerConfig.ease = Ease.Linear;
		staggerConfig.start = 500f;
		Func<int, float> staggerDelay = Tweens.Stagger(100f, staggerConfig);
		tweenConfig.staggerDelay = staggerDelay;
		MultiTargetTween tweenHideCircles = Tweens.Add(tweenConfig);
		_tweenHideCircles = tweenHideCircles;
	}

	public void UpdateTrisectionAudio()
	{
		//IL_0010: Invalid comparison between F4 and I4
		//IL_0126: Expected I, but got O
		//IL_0149: Expected I, but got O
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0269: Invalid comparison between F4 and I4
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02bd: Invalid comparison between O and F4
		//IL_0090: Expected O, but got I4
		if (!_isSpinning)
		{
			return;
		}
		if (!(_tickTimer > 0f))
		{
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			Transform transform = _wheelOfFortune.transform;
			Vector3 up = transform.up;
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE6840");
			object obj2 = default(object);
			object obj = (object)Vector3.upVector * obj2;
			float num5 = (float)Vector3.upVector * up.z;
			float num6 = up.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num7 = num6 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			object obj3 = 0 * obj2;
			float num8 = num7 - num5;
			object obj4 = default(object);
			float num9 = (float)obj4 * up.z;
			float num10 = up.x * (float)obj4;
			float num11 = num9 - (float)obj3;
			object obj5 = default(object);
			float num12 = num8 * (float)obj5;
			float num13 = (float)obj - num10;
			float num14 = num11 * (float)Vector3.forwardVector;
			float num15 = num13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			float num16 = num15 * 0f;
			float num17 = num12 + num14;
			float num18 = num17 + num16;
			float num19 = ((num18 < 0f) ? (-1f) : 1f);
			float num20 = num19 * _tickTimer;
			float num21 = num20 - _wheelAngleAtLastTickAudio;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj6 = num21 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)30f))
			{
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_wheelOfFortuneTick, soundConfig, 0f, 20, time);
				_tickTimer = _minTimeBetweenTicks;
				_wheelAngleAtLastTickAudio = num20;
			}
		}
		else
		{
			float deltaTime = PauseSystem.DeltaTime;
			float tickTimer = _tickTimer - deltaTime;
			_tickTimer = tickTimer;
		}
	}

	public override void Spinnn(float duration = 5000f, TrisectionEvent forcedEvent = null, Action onEventSelected = null)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_01bb: Expected I, but got O
		//IL_022c: Expected O, but got I4
		//IL_02bb: Expected I, but got O
		_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass28_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		Action onEventSelected2 = default(Action);
		CS_0024_003C_003E8__locals10.onEventSelected = onEventSelected2;
		_isSpinning = true;
		if (forcedEvent != null)
		{
			WeightedTrisectionEventData weightedTrisectionEventData = new WeightedTrisectionEventData();
			weightedTrisectionEventData.weight = 0;
			weightedTrisectionEventData.ev = forcedEvent;
			_nextChosenEvent = weightedTrisectionEventData;
		}
		else
		{
			CalculateMainChances();
			ChooseEvent();
		}
		WeightedTrisectionEventData nextChosenEvent = _nextChosenEvent;
		object obj = (object)_eventsRng << 13;
		object obj2 = obj ^ (object)_eventsRng;
		object obj3 = obj2 >> 17;
		object obj4 = obj2 ^ obj3;
		object obj5 = obj4 << 5;
		Unity.Mathematics.Random eventsRng = (Unity.Mathematics.Random)(obj5 ^ obj4);
		_eventsRng = eventsRng;
		(float, float) eventAngles = GetEventAngles(nextChosenEvent.ev);
		object obj6 = (object)_eventsRng << 13;
		object obj7 = obj6 ^ (object)_eventsRng;
		object obj8 = obj7 >> 17;
		object obj9 = obj7 ^ obj8;
		object obj10 = obj9 << 5;
		Unity.Mathematics.Random eventsRng2 = (Unity.Mathematics.Random)(obj10 ^ obj9);
		object obj11 = _eventsRng * 2;
		object obj12 = (object)_eventsRng + obj11;
		object obj13 = obj12 + obj12;
		_eventsRng = eventsRng2;
		object obj14 = obj13 >> 32;
		object obj15 = obj14 + 4;
		object obj16 = obj15 * 360;
		if (_tweenWheelOfFortune != null)
		{
			_tweenWheelOfFortune.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_wheelOfFortune != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			if (obj17 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.OutCirc;
		tweenConfig.angle = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			//IL_006a: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_wheelOfFortuneFanfare, soundConfig, 0f, 10, time);
			CS_0024_003C_003E8__locals10._003C_003E4__this.HideCircles();
			WestwoodsTrisectionManager westwoodsTrisectionManager = CS_0024_003C_003E8__locals10._003C_003E4__this;
			westwoodsTrisectionManager._isSpinning = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tweenWheelOfFortune = Tweens.Add(tweenConfig);
		_tweenWheelOfFortune = tweenWheelOfFortune;
		_tweenCounterTargetValue = 1f;
		CS_0024_003C_003E8__locals10.tweenCounterValue = 0f;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj18 = default(object);
		if (obj18 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_tweenCounterTargetValue", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			float duration2 = duration * 0.95f;
			tweenConfig2.duration = duration2;
			TweenCallback onUpdate = delegate
			{
				WestwoodsTrisectionManager westwoodsTrisectionManager = CS_0024_003C_003E8__locals10._003C_003E4__this;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
				object obj19 = default(object);
				if (obj19 == null)
				{
					CS_0024_003C_003E8__locals10.tweenCounterValue = westwoodsTrisectionManager._tweenCounterTargetValue;
					if (westwoodsTrisectionManager._tweenCounterTargetValue < 12f)
					{
						CS_0024_003C_003E8__locals10._003C_003E4__this.RotateEventNames();
					}
					else
					{
						CS_0024_003C_003E8__locals10._003C_003E4__this.HighlightEventName(CS_0024_003C_003E8__locals10.onEventSelected);
					}
				}
			};
			tweenConfig2.onUpdate = onUpdate;
			MultiTargetTween tweenCounter = Tweens.Add(tweenConfig2);
			_tweenCounter = tweenCounter;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public WestwoodsTrisectionManager()
	{
		//IL_002e: Expected O, but got I4
		_isIdle = true;
		_fanfareSoundConfig = new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		};
		base._002Ector();
	}
}
