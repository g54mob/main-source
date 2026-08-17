using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupDirecter : NetworkPickup
{
	public float _Radius1;

	public float _Radius2;

	public float _Radius3;

	public float _Radius4;

	public float _Radius5;

	public float _Radius6;

	public float _Radius7;

	private float _myAngle1;

	private float _myAngle2;

	private float _myAngle3;

	private float _myAngle4;

	private float _myAngle5;

	private float _myAngle6;

	private float _myAngle7;

	private PhaserSprite _eye1;

	private PhaserSprite _eye2;

	private PhaserSprite _eye3;

	private PhaserSprite _eye4;

	private PhaserSprite _eye5;

	private PhaserSprite _eye6;

	private PhaserSprite _eye7;

	private TileSprite _stars1;

	private TileSprite _stars2;

	private bool _isBehind;

	private PhaserSprite _LeftHand;

	private PhaserSprite _RightHand;

	private float _angleUnit = (float)Math.PI / 360f;

	private SpriteMask _spriteMask;

	private List<MultiTargetTween> _allTweens;

	private bool _locallyDisableGet;

	protected override bool UsesOrderedCommand => true;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1c22: Expected O, but got Ref
		//IL_017d: Expected O, but got I4
		//IL_01e0: Expected O, but got I4
		//IL_0243: Expected O, but got I4
		//IL_02a6: Expected O, but got I4
		//IL_0309: Expected O, but got I4
		//IL_036c: Expected O, but got I4
		//IL_03cf: Expected O, but got I4
		//IL_044b: Expected O, but got I
		//IL_047f: Expected O, but got I4
		//IL_052a: Expected O, but got I
		//IL_055e: Expected O, but got I4
		//IL_07cb: Expected O, but got Ref
		//IL_08cf: Expected I, but got O
		//IL_093b: Expected O, but got Ref
		//IL_0a3f: Expected I, but got O
		//IL_0aa6: Expected O, but got Ref
		//IL_0baa: Expected I, but got O
		//IL_0c11: Expected O, but got Ref
		//IL_0d15: Expected I, but got O
		//IL_0d7c: Expected O, but got Ref
		//IL_0e80: Expected I, but got O
		//IL_0ee7: Expected O, but got Ref
		//IL_0feb: Expected I, but got O
		//IL_1052: Expected O, but got Ref
		//IL_1156: Expected I, but got O
		//IL_128b: Expected I, but got O
		//IL_13c0: Expected I, but got O
		//IL_14f5: Expected I, but got O
		//IL_162a: Expected I, but got O
		//IL_175f: Expected I, but got O
		//IL_1894: Expected I, but got O
		//IL_19c9: Expected I, but got O
		//IL_1b17: Expected I, but got O
		//IL_0165->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_01c8->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_022b->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_028e->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0354->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_03b7->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_042c->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0467->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_049b->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_050b->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0546->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_057a->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_05a9->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0619->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_063b->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0690->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_06b2->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_06ee->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0710->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0765->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0787->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_07f8->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0830->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0883->IL1bb6: Incompatible stack heights: 1 vs 0
		//IL_0900->IL1bb6: Incompatible stack heights: 2 vs 0
		//IL_0968->IL1bb6: Incompatible stack heights: 2 vs 0
		//IL_09a0->IL1bb6: Incompatible stack heights: 2 vs 0
		//IL_09f3->IL1bb6: Incompatible stack heights: 2 vs 0
		//IL_0a6b->IL1bb6: Incompatible stack heights: 3 vs 0
		//IL_0ad3->IL1bb6: Incompatible stack heights: 3 vs 0
		//IL_0b0b->IL1bb6: Incompatible stack heights: 3 vs 0
		//IL_0b5e->IL1bb6: Incompatible stack heights: 3 vs 0
		//IL_0bd6->IL1bb6: Incompatible stack heights: 4 vs 0
		//IL_0c3e->IL1bb6: Incompatible stack heights: 4 vs 0
		//IL_0c76->IL1bb6: Incompatible stack heights: 4 vs 0
		//IL_0cc9->IL1bb6: Incompatible stack heights: 4 vs 0
		//IL_0d41->IL1bb6: Incompatible stack heights: 5 vs 0
		//IL_0da9->IL1bb6: Incompatible stack heights: 5 vs 0
		//IL_0de1->IL1bb6: Incompatible stack heights: 5 vs 0
		//IL_0e34->IL1bb6: Incompatible stack heights: 5 vs 0
		//IL_0eac->IL1bb6: Incompatible stack heights: 6 vs 0
		//IL_0f14->IL1bb6: Incompatible stack heights: 6 vs 0
		//IL_0f4c->IL1bb6: Incompatible stack heights: 6 vs 0
		//IL_0f9f->IL1bb6: Incompatible stack heights: 6 vs 0
		//IL_1017->IL1bb6: Incompatible stack heights: 7 vs 0
		//IL_107f->IL1bb6: Incompatible stack heights: 7 vs 0
		//IL_10b7->IL1bb6: Incompatible stack heights: 7 vs 0
		//IL_110a->IL1bb6: Incompatible stack heights: 7 vs 0
		//IL_1182->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_11ca->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1220->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_12b7->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1274->IL1274: Incompatible stack heights: 9 vs 8
		//IL_12ff->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1355->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_13ec->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_13a9->IL13a9: Incompatible stack heights: 9 vs 8
		//IL_1434->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_148a->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1521->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_14de->IL14de: Incompatible stack heights: 9 vs 8
		//IL_1569->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_15bf->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1656->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1613->IL1613: Incompatible stack heights: 9 vs 8
		//IL_169e->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_16f4->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_178b->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1748->IL1748: Incompatible stack heights: 9 vs 8
		//IL_17d3->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_1829->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_18c0->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_187d->IL187d: Incompatible stack heights: 9 vs 8
		//IL_1908->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_195e->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_19f5->IL1bb6: Incompatible stack heights: 8 vs 0
		//IL_19b2->IL19b2: Incompatible stack heights: 9 vs 8
		//IL_1a8e->IL1a8e: Incompatible stack heights: 10 vs 9
		//IL_1ae7->IL1ae7: Incompatible stack heights: 10 vs 9
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Action action = OnForceClosedUi;
			if (core._signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA8BB0");
				List<MultiTargetTween> allTweens = new List<MultiTargetTween>();
				_allTweens = allTweens;
				_Radius1 = 0.64f;
				_Radius2 = 0.64f;
				_Radius3 = 0.64f;
				_Radius4 = 0.64f;
				_Radius5 = 0.64f;
				_Radius6 = 0.64f;
				_Radius7 = 0.64f;
				_myAngle2 = 1.4451327f;
				_myAngle3 = (float)Math.PI * 41f / 50f;
				_myAngle4 = 3.8327432f;
				_myAngle5 = 4.4610615f;
				_myAngle6 = 4.9637165f;
				_myAngle7 = 5.215044f;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((Delegate)(object)transform).method_ptr == (IntPtr)0;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.get_position_Injected(((Delegate)(object)transform).method_ptr, out *(Vector3*)obj3);
					GameObject gameObject = base.gameObject;
					Vector2 pos = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "enemiesM", "mask_sun_0");
					if ((object)phaserSprite != null)
					{
						PhaserSprite eye = phaserSprite.setScale(2f, (float?)(object)0);
						_eye1 = eye;
						GameObject gameObject2 = base.gameObject;
						PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "enemiesM", "mask_moon_0");
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite eye2 = phaserSprite2.setScale(1.75f, (float?)(object)0);
							_eye2 = eye2;
							GameObject gameObject3 = base.gameObject;
							PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "enemiesM", "mask_city_0");
							if ((object)phaserSprite3 != null)
							{
								PhaserSprite eye3 = phaserSprite3.setScale(1.5f, (float?)(object)0);
								_eye3 = eye3;
								GameObject gameObject4 = base.gameObject;
								PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "enemiesM", "mask_seawind_0");
								if ((object)phaserSprite4 != null)
								{
									PhaserSprite eye4 = phaserSprite4.setScale(1.25f, (float?)(object)0);
									_eye4 = eye4;
									GameObject gameObject5 = base.gameObject;
									PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "enemiesM", "mask_volcano_0");
									if ((object)phaserSprite5 != null)
									{
										PhaserSprite eye5 = phaserSprite5.setScale(1f, (float?)(object)0);
										_eye5 = eye5;
										GameObject gameObject6 = base.gameObject;
										PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject6, pos, "enemiesM", "mask_stone_0");
										if ((object)phaserSprite6 != null)
										{
											PhaserSprite eye6 = phaserSprite6.setScale(0.75f, (float?)(object)0);
											_eye6 = eye6;
											GameObject gameObject7 = base.gameObject;
											PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject7, pos, "enemiesM", "nomask_0");
											if ((object)phaserSprite7 != null)
											{
												PhaserSprite eye7 = phaserSprite7.setScale(0.5f, (float?)(object)0);
												_eye7 = eye7;
												GameObject gameObject8 = base.gameObject;
												PhaserSprite phaserSprite8 = RenderingExtensions.AddPhaserSprite(gameObject8, pos, "enemiesM", "hand_01");
												_ = 0;
												_ = 1056964608;
												_ = 1;
												if ((object)phaserSprite8 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
													PhaserSprite phaserSprite9 = phaserSprite8.setOrigin(1f, (float?)(object)0);
													if ((object)phaserSprite9 != null)
													{
														PhaserSprite phaserSprite10 = phaserSprite9.setScale(1f, (float?)(object)0);
														if ((object)phaserSprite10 != null)
														{
															PhaserSprite leftHand = phaserSprite10.setFlipY(flipY: true);
															_LeftHand = leftHand;
															GameObject gameObject9 = base.gameObject;
															PhaserSprite phaserSprite11 = RenderingExtensions.AddPhaserSprite(gameObject9, pos, "enemiesM", "hand_01");
															_ = 0;
															_ = 1056964608;
															_ = 1;
															if ((object)phaserSprite11 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																PhaserSprite phaserSprite12 = phaserSprite11.setOrigin(0f, (float?)(object)0);
																if ((object)phaserSprite12 != null)
																{
																	PhaserSprite phaserSprite13 = phaserSprite12.setScale(1f, (float?)(object)0);
																	if ((object)phaserSprite13 != null)
																	{
																		PhaserSprite phaserSprite14 = phaserSprite13.setFlipY(flipY: true);
																		if ((object)phaserSprite14 != null)
																		{
																			PhaserSprite rightHand = phaserSprite14.setFlipX(flipX: true);
																			_RightHand = rightHand;
																			int num = default(int);
																			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("hand_", 1, 4, "enemiesM", num);
																			PhaserSprite leftHand2 = _LeftHand;
																			if ((object)_LeftHand != null && (object)leftHand2._spriteAnimation != null)
																			{
																				bool startRandomFrame = default(bool);
																				Action onComplete = default(Action);
																				bool autoSetAnimation = default(bool);
																				leftHand2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																				PhaserSprite leftHand3 = _LeftHand;
																				if ((object)_LeftHand != null && (object)leftHand3._spriteAnimation != null)
																				{
																					leftHand3._spriteAnimation.SetAnimation("idle");
																					PhaserSprite rightHand2 = _RightHand;
																					if ((object)_RightHand != null && (object)rightHand2._spriteAnimation != null)
																					{
																						rightHand2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																						PhaserSprite rightHand3 = _RightHand;
																						if ((object)_RightHand != null && (object)rightHand3._spriteAnimation != null)
																						{
																							rightHand3._spriteAnimation.SetAnimation("idle");
																							TweenConfig tweenConfig = new TweenConfig();
																							Dictionary<string, object> dictionary = new Dictionary<string, object>();
																							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																							_ = 1050924810;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																							if (dictionary != null)
																							{
																								object value = default(object);
																								bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_Radius1", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																								if (tweenConfig != null)
																								{
																									((Delegate)(object)tweenConfig).invoke_impl = (IntPtr)1148993536;
																									_ = 1;
																									_ = 4294967295L;
																									object[] array = new object[1];
																									if (array != null)
																									{
																										void* value2 = ((IntPtr*)(&array))->m_value;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																										object obj5 = default(object);
																										bool flag3 = obj5 == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										((Delegate)(object)tweenConfig).method_ptr = (IntPtr)array;
																										MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																										if (_allTweens != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																											TweenConfig tweenConfig2 = new TweenConfig();
																											Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
																											object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																											_ = 1050924810;
																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																											if (dictionary2 != null)
																											{
																												object value3 = default(object);
																												bool flag4 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Radius2", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																												if (tweenConfig2 != null)
																												{
																													((Delegate)(object)tweenConfig2).invoke_impl = (IntPtr)1150820352;
																													_ = 1;
																													_ = 4294967295L;
																													object[] array2 = new object[1];
																													if (array2 != null)
																													{
																														void* value4 = ((IntPtr*)(&array2))->m_value;
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																														object obj7 = default(object);
																														bool flag5 = obj7 == null;
																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																														((Delegate)(object)tweenConfig2).method_ptr = (IntPtr)array2;
																														MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																														if (_allTweens != null)
																														{
																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																															TweenConfig tweenConfig3 = new TweenConfig();
																															Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
																															object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																															_ = 1050924810;
																															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																															if (dictionary3 != null)
																															{
																																object value5 = default(object);
																																bool flag6 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_Radius3", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																if (tweenConfig3 != null)
																																{
																																	((Delegate)(object)tweenConfig3).invoke_impl = (IntPtr)1153048576;
																																	_ = 1;
																																	_ = 4294967295L;
																																	object[] array3 = new object[1];
																																	if (array3 != null)
																																	{
																																		void* value6 = ((IntPtr*)(&array3))->m_value;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																		object obj9 = default(object);
																																		bool flag7 = obj9 == null;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																		((Delegate)(object)tweenConfig3).method_ptr = (IntPtr)array3;
																																		MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
																																		if (_allTweens != null)
																																		{
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																			TweenConfig tweenConfig4 = new TweenConfig();
																																			Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
																																			object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																																			_ = 1050924810;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																			if (dictionary4 != null)
																																			{
																																				object value7 = default(object);
																																				bool flag8 = ((Dictionary<object, object>)(object)dictionary4).TryInsert((object)"_Radius4", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																				if (tweenConfig4 != null)
																																				{
																																					((Delegate)(object)tweenConfig4).invoke_impl = (IntPtr)1154113536;
																																					_ = 1;
																																					_ = 4294967295L;
																																					object[] array4 = new object[1];
																																					if (array4 != null)
																																					{
																																						void* value8 = ((IntPtr*)(&array4))->m_value;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																						object obj11 = default(object);
																																						bool flag9 = obj11 == null;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																						((Delegate)(object)tweenConfig4).method_ptr = (IntPtr)array4;
																																						MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																																						if (_allTweens != null)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																							TweenConfig tweenConfig5 = new TweenConfig();
																																							Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
																																							object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																																							_ = 1050924810;
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																							if (dictionary5 != null)
																																							{
																																								object value9 = default(object);
																																								bool flag10 = ((Dictionary<object, object>)(object)dictionary5).TryInsert((object)"_Radius5", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																								if (tweenConfig5 != null)
																																								{
																																									((Delegate)(object)tweenConfig5).invoke_impl = (IntPtr)1156096000;
																																									_ = 1;
																																									_ = 4294967295L;
																																									object[] array5 = new object[1];
																																									if (array5 != null)
																																									{
																																										void* value10 = ((IntPtr*)(&array5))->m_value;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																										object obj13 = default(object);
																																										bool flag11 = obj13 == null;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																										((Delegate)(object)tweenConfig5).method_ptr = (IntPtr)array5;
																																										MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
																																										if (_allTweens != null)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																											TweenConfig tweenConfig6 = new TweenConfig();
																																											Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
																																											object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																																											_ = 1050924810;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																											if (dictionary6 != null)
																																											{
																																												object value11 = default(object);
																																												bool flag12 = ((Dictionary<object, object>)(object)dictionary6).TryInsert((object)"_Radius6", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																												if (tweenConfig6 != null)
																																												{
																																													((Delegate)(object)tweenConfig6).invoke_impl = (IntPtr)1157836800;
																																													_ = 1;
																																													_ = 4294967295L;
																																													object[] array6 = new object[1];
																																													if (array6 != null)
																																													{
																																														void* value12 = ((IntPtr*)(&array6))->m_value;
																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																														object obj15 = default(object);
																																														bool flag13 = obj15 == null;
																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																														((Delegate)(object)tweenConfig6).method_ptr = (IntPtr)array6;
																																														MultiTargetTween multiTargetTween6 = Tweens.Add(tweenConfig6);
																																														if (_allTweens != null)
																																														{
																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																															TweenConfig tweenConfig7 = new TweenConfig();
																																															Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
																																															object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
																																															_ = 1050924810;
																																															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																															if (dictionary7 != null)
																																															{
																																																object value13 = default(object);
																																																bool flag14 = ((Dictionary<object, object>)(object)dictionary7).TryInsert((object)"_Radius7", value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																																if (tweenConfig7 != null)
																																																{
																																																	((Delegate)(object)tweenConfig7).invoke_impl = (IntPtr)1158828032;
																																																	_ = 1;
																																																	_ = 4294967295L;
																																																	object[] array7 = new object[1];
																																																	if (array7 != null)
																																																	{
																																																		void* value14 = ((IntPtr*)(&array7))->m_value;
																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																		object obj17 = default(object);
																																																		bool flag15 = obj17 == null;
																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																		((Delegate)(object)tweenConfig7).method_ptr = (IntPtr)array7;
																																																		MultiTargetTween multiTargetTween7 = Tweens.Add(tweenConfig7);
																																																		if (_allTweens != null)
																																																		{
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																			TweenConfig tweenConfig8 = new TweenConfig();
																																																			_ = 0;
																																																			_ = 1056964608;
																																																			_ = 1;
																																																			if (tweenConfig8 != null)
																																																			{
																																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																				_ = 0;
																																																				((Delegate)(object)tweenConfig8).invoke_impl = (IntPtr)1148993536;
																																																				_ = 1;
																																																				_ = 4294967295L;
																																																				object[] array8 = new object[1];
																																																				if (array8 != null)
																																																				{
																																																					if ((object)_eye1 != null)
																																																					{
																																																						void* value15 = ((IntPtr*)(&array8))->m_value;
																																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																						object obj18 = default(object);
																																																						bool flag16 = obj18 == null;
																																																					}
																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																					((Delegate)(object)tweenConfig8).method_ptr = (IntPtr)array8;
																																																					MultiTargetTween multiTargetTween8 = Tweens.Add(tweenConfig8);
																																																					if (_allTweens != null)
																																																					{
																																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																						TweenConfig tweenConfig9 = new TweenConfig();
																																																						_ = 0;
																																																						_ = 1061158912;
																																																						_ = 1;
																																																						if (tweenConfig9 != null)
																																																						{
																																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																							_ = 0;
																																																							((Delegate)(object)tweenConfig9).invoke_impl = (IntPtr)1150820352;
																																																							_ = 1;
																																																							_ = 4294967295L;
																																																							object[] array9 = new object[1];
																																																							if (array9 != null)
																																																							{
																																																								if ((object)_eye2 != null)
																																																								{
																																																									void* value16 = ((IntPtr*)(&array9))->m_value;
																																																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																									object obj19 = default(object);
																																																									bool flag17 = obj19 == null;
																																																								}
																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																								((Delegate)(object)tweenConfig9).method_ptr = (IntPtr)array9;
																																																								MultiTargetTween multiTargetTween9 = Tweens.Add(tweenConfig9);
																																																								if (_allTweens != null)
																																																								{
																																																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																									TweenConfig tweenConfig10 = new TweenConfig();
																																																									_ = 0;
																																																									_ = 1065353216;
																																																									_ = 1;
																																																									if (tweenConfig10 != null)
																																																									{
																																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																										_ = 0;
																																																										((Delegate)(object)tweenConfig10).invoke_impl = (IntPtr)1153048576;
																																																										_ = 1;
																																																										_ = 4294967295L;
																																																										object[] array10 = new object[1];
																																																										if (array10 != null)
																																																										{
																																																											if ((object)_eye3 != null)
																																																											{
																																																												void* value17 = ((IntPtr*)(&array10))->m_value;
																																																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																												object obj20 = default(object);
																																																												bool flag18 = obj20 == null;
																																																											}
																																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																											((Delegate)(object)tweenConfig10).method_ptr = (IntPtr)array10;
																																																											MultiTargetTween multiTargetTween10 = Tweens.Add(tweenConfig10);
																																																											if (_allTweens != null)
																																																											{
																																																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																												TweenConfig tweenConfig11 = new TweenConfig();
																																																												_ = 0;
																																																												_ = 1067450368;
																																																												_ = 1;
																																																												if (tweenConfig11 != null)
																																																												{
																																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																													_ = 0;
																																																													((Delegate)(object)tweenConfig11).invoke_impl = (IntPtr)1154113536;
																																																													_ = 1;
																																																													_ = 4294967295L;
																																																													object[] array11 = new object[1];
																																																													if (array11 != null)
																																																													{
																																																														if ((object)_eye4 != null)
																																																														{
																																																															void* value18 = ((IntPtr*)(&array11))->m_value;
																																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																															object obj21 = default(object);
																																																															bool flag19 = obj21 == null;
																																																														}
																																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																														((Delegate)(object)tweenConfig11).method_ptr = (IntPtr)array11;
																																																														MultiTargetTween multiTargetTween11 = Tweens.Add(tweenConfig11);
																																																														if (_allTweens != null)
																																																														{
																																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																															TweenConfig tweenConfig12 = new TweenConfig();
																																																															_ = 0;
																																																															_ = 1069547520;
																																																															_ = 1;
																																																															if (tweenConfig12 != null)
																																																															{
																																																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																																_ = 0;
																																																																((Delegate)(object)tweenConfig12).invoke_impl = (IntPtr)1156096000;
																																																																_ = 1;
																																																																_ = 4294967295L;
																																																																object[] array12 = new object[1];
																																																																if (array12 != null)
																																																																{
																																																																	if ((object)_eye5 != null)
																																																																	{
																																																																		void* value19 = ((IntPtr*)(&array12))->m_value;
																																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																		object obj22 = default(object);
																																																																		bool flag20 = obj22 == null;
																																																																	}
																																																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																	((Delegate)(object)tweenConfig12).method_ptr = (IntPtr)array12;
																																																																	MultiTargetTween multiTargetTween12 = Tweens.Add(tweenConfig12);
																																																																	if (_allTweens != null)
																																																																	{
																																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																		TweenConfig tweenConfig13 = new TweenConfig();
																																																																		_ = 0;
																																																																		_ = 1071644672;
																																																																		_ = 1;
																																																																		if (tweenConfig13 != null)
																																																																		{
																																																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																																			_ = 0;
																																																																			((Delegate)(object)tweenConfig13).invoke_impl = (IntPtr)1157836800;
																																																																			_ = 1;
																																																																			_ = 4294967295L;
																																																																			object[] array13 = new object[1];
																																																																			if (array13 != null)
																																																																			{
																																																																				if ((object)_eye6 != null)
																																																																				{
																																																																					void* value20 = ((IntPtr*)(&array13))->m_value;
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																					object obj23 = default(object);
																																																																					bool flag21 = obj23 == null;
																																																																				}
																																																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																				((Delegate)(object)tweenConfig13).method_ptr = (IntPtr)array13;
																																																																				MultiTargetTween multiTargetTween13 = Tweens.Add(tweenConfig13);
																																																																				if (_allTweens != null)
																																																																				{
																																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																					TweenConfig tweenConfig14 = new TweenConfig();
																																																																					_ = 0;
																																																																					_ = 1073741824;
																																																																					_ = 1;
																																																																					if (tweenConfig14 != null)
																																																																					{
																																																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																																						_ = 0;
																																																																						((Delegate)(object)tweenConfig14).invoke_impl = (IntPtr)1158828032;
																																																																						_ = 1;
																																																																						_ = 4294967295L;
																																																																						object[] array14 = new object[1];
																																																																						if (array14 != null)
																																																																						{
																																																																							if ((object)_eye7 != null)
																																																																							{
																																																																								void* value21 = ((IntPtr*)(&array14))->m_value;
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																								object obj24 = default(object);
																																																																								bool flag22 = obj24 == null;
																																																																							}
																																																																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																							((Delegate)(object)tweenConfig14).method_ptr = (IntPtr)array14;
																																																																							MultiTargetTween multiTargetTween14 = Tweens.Add(tweenConfig14);
																																																																							if (_allTweens != null)
																																																																							{
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																								TweenConfig tweenConfig15 = new TweenConfig();
																																																																								object[] array15 = new object[2];
																																																																								bool flag23 = array15 == null;
																																																																								if ((object)_LeftHand != null)
																																																																								{
																																																																									void* value22 = ((IntPtr*)(&array15))->m_value;
																																																																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																									object obj25 = default(object);
																																																																									bool flag24 = obj25 == null;
																																																																								}
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																								if ((object)_RightHand != null)
																																																																								{
																																																																									void* value23 = ((IntPtr*)(&array15))->m_value;
																																																																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																																									object obj26 = default(object);
																																																																									bool flag25 = obj26 == null;
																																																																								}
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																																								bool flag26 = tweenConfig15 == null;
																																																																								((Delegate)(object)tweenConfig15).method_ptr = (IntPtr)array15;
																																																																								_ = 0;
																																																																								_ = 1053609165;
																																																																								_ = 1;
																																																																								_ = 0;
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																																								_ = 0;
																																																																								_ = 1063675494;
																																																																								_ = 1;
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
																																																																								_ = 0;
																																																																								((Delegate)(object)tweenConfig15).invoke_impl = (IntPtr)1148846080;
																																																																								_ = 1;
																																																																								_ = 4294967295L;
																																																																								MultiTargetTween multiTargetTween15 = Tweens.Add(tweenConfig15);
																																																																								bool flag27 = _allTweens == null;
																																																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97480");
																																																																								_isBehind = false;
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

	public override void SetData(ItemType itemType)
	{
		//IL_0856: Expected O, but got I4
		//IL_0502: Expected I4, but got O
		//IL_0563: Expected I4, but got I8
		//IL_0571: Expected O, but got I4
		//IL_05b8: Expected I4, but got O
		//IL_0661: Expected I4, but got O
		//IL_0630: Expected I4, but got O
		//IL_06a2: Expected O, but got I4
		//IL_06de: Expected I4, but got I8
		//IL_0720: Expected I4, but got O
		//IL_0746: Expected I4, but got F4
		//IL_0792: Expected I4, but got O
		//IL_0792: Expected I4, but got F4
		//IL_0806: Expected O, but got I4
		//IL_0806: Expected O, but got I4
		//IL_0a4b->IL0835: Incompatible stack heights: 1 vs 0
		//IL_0471->IL0835: Incompatible stack heights: 1 vs 0
		//IL_0498->IL0835: Incompatible stack heights: 2 vs 0
		//IL_051e->IL0835: Incompatible stack heights: 2 vs 0
		//IL_04ee->IL04ee: Incompatible stack heights: 3 vs 2
		//IL_059d->IL0835: Incompatible stack heights: 2 vs 0
		//IL_05f6->IL0835: Incompatible stack heights: 2 vs 0
		//IL_067d->IL0835: Incompatible stack heights: 2 vs 0
		//IL_064d->IL064d: Incompatible stack heights: 3 vs 2
		//IL_0705->IL0835: Incompatible stack heights: 2 vs 0
		//IL_0764->IL0835: Incompatible stack heights: 2 vs 0
		//IL_07ac->IL0835: Incompatible stack heights: 2 vs 0
		//IL_07e6->IL0835: Incompatible stack heights: 2 vs 0
		base.SetData(itemType);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		base.GoToPlayer = true;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					PhaserScene.Renderer renderer2 = s_scene2._renderer;
					if (s_scene2._renderer != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null)
						{
							PhaserScene.Renderer renderer3 = s_scene3._renderer;
							if (s_scene3._renderer != null)
							{
								PhaserScene s_scene4 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene4._renderer != null)
								{
									float y = renderer2.height * 0.5f;
									float x = renderer.width * 0.5f;
									float num = default(float);
									string text = default(string);
									string text2 = default(string);
									TileSprite component = RenderingExtensions.AddTileSprite(this, x, y, renderer3.width, num, text, text2);
									TileSprite tileSprite = RenderingExtensions.SetScrollFactor(component, 0f);
									PhaserScene s_scene5 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer4 = s_scene5._renderer;
										if (s_scene5._renderer != null && (object)tileSprite != null)
										{
											int num2 = renderer4.pixelHeight - 1;
											TileSprite stars = tileSprite.SetDepth(num2);
											_stars1 = stars;
											PhaserScene s_scene6 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer5 = s_scene6._renderer;
												if (s_scene6._renderer != null)
												{
													PhaserScene s_scene7 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserScene.Renderer renderer6 = s_scene7._renderer;
														if (s_scene7._renderer != null)
														{
															PhaserScene s_scene8 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer7 = s_scene8._renderer;
																if (s_scene8._renderer != null)
																{
																	PhaserScene s_scene9 = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null && s_scene9._renderer != null)
																	{
																		float y2 = renderer6.height * 0.5f;
																		float x2 = renderer5.width * 0.5f;
																		TileSprite component2 = RenderingExtensions.AddTileSprite(this, x2, y2, renderer7.width, num, text, text2);
																		TileSprite tileSprite2 = RenderingExtensions.SetScrollFactor(component2, 0f);
																		PhaserScene s_scene10 = ArcadePhysics.s_scene;
																		if (ArcadePhysics.s_scene != null)
																		{
																			PhaserScene.Renderer renderer8 = s_scene10._renderer;
																			if (s_scene10._renderer != null && (object)tileSprite2 != null)
																			{
																				int num3 = renderer8.pixelHeight - 1;
																				TileSprite stars2 = tileSprite2.SetDepth(num3);
																				_stars2 = stars2;
																				if ((object)_itemRenderer != null)
																				{
																					GameObject gameObject = _itemRenderer.gameObject;
																					if ((object)gameObject != null)
																					{
																						SpriteMask spriteMask = gameObject.AddComponent<SpriteMask>();
																						_spriteMask = spriteMask;
																						TileSprite stars3 = _stars1;
																						if ((object)_stars1 != null)
																						{
																							object spriteRenderer = stars3._spriteRenderer;
																							if ((object)stars3._spriteRenderer != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v11 (System.Object)+10]");
																								bool flag = (nint)0 == 0;
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rsi_v11 (System.Object)+10]");
																								SpriteRenderer.set_maskInteraction_Injected((IntPtr)0, SpriteMaskInteraction.VisibleInsideMask);
																								TileSprite stars4 = _stars2;
																								if ((object)_stars2 != null)
																								{
																									TileSprite spriteRenderer2 = (TileSprite)(object)stars4._spriteRenderer;
																									if ((object)stars4._spriteRenderer != null)
																									{
																										bool flag2 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
																										SpriteRenderer.set_maskInteraction_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, SpriteMaskInteraction.VisibleInsideMask);
																										TweenConfig tweenConfig = new TweenConfig();
																										object[] array = new object[1];
																										if (array != null)
																										{
																											if ((object)_stars2 != null)
																											{
																												TileSprite tileSprite3 = RenderingExtensions.SetScrollFactor(_stars2, 0f);
																												bool flag3 = (object)tileSprite3 == null;
																											}
																											TileSprite tileSprite4 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array, 0f, (byte)(int)_stars2 != 0);
																											if (tweenConfig != null)
																											{
																												tweenConfig.targets = array;
																												tweenConfig.duration = 1000f;
																												tweenConfig.yoyo = true;
																												tweenConfig.repeat = -1;
																												tweenConfig.alpha = (float?)(object)1;
																												MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																												if (_allTweens != null)
																												{
																													TileSprite tileSprite5 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars2 != 0);
																													TweenConfig tweenConfig2 = new TweenConfig();
																													object[] array2 = new object[1];
																													if (array2 != null)
																													{
																														if ((object)_stars1 != null)
																														{
																															TileSprite tileSprite6 = RenderingExtensions.SetScrollFactor(_stars1, 0f, (byte)(int)_stars2 != 0);
																															bool flag4 = (object)tileSprite6 == null;
																														}
																														TileSprite tileSprite7 = RenderingExtensions.SetScrollFactor((TileSprite)(object)array2, 0f, (byte)(int)_stars1 != 0);
																														if (tweenConfig2 != null)
																														{
																															tweenConfig2.targets = array2;
																															tweenConfig2.alpha = (float?)(object)1;
																															tweenConfig2.duration = 1000f;
																															tweenConfig2.delay = 500f;
																															tweenConfig2.yoyo = true;
																															tweenConfig2.repeat = -1;
																															MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																															if (_allTweens != null)
																															{
																																TileSprite tileSprite8 = RenderingExtensions.SetScrollFactor((TileSprite)(object)_allTweens, 0f, (byte)(int)_stars1 != 0);
																																List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("v_i", 1, 4, "enemiesM", (int)num);
																																if ((object)_spriteAnimation != null)
																																{
																																	bool autoSetAnimation = default(bool);
																																	_spriteAnimation.AddAnimation("idle", animationFrames, 12, (byte)(int)num != 0, (byte)(int)text != 0, (Action)(object)text2, autoSetAnimation);
																																	if ((object)_spriteAnimation != null)
																																	{
																																		_spriteAnimation.SetAnimation("idle");
																																		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
																																		if (body != null)
																																		{
																																			BaseBody baseBody = body.setCircle(80f, (float?)(object)1, (float?)(object)1);
																																			CheckRenderer();
																																			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(((ArcadeSprite)this)._spriteRenderer, 5f);
																																			_locallyDisableGet = false;
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

	public override void InternalUpdate()
	{
		//IL_0d17: Expected I4, but got O
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected I4, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected I4, but got Unknown
		//IL_06e5: Expected O, but got F4
		//IL_07d0: Expected O, but got F4
		//IL_08ab: Expected O, but got F4
		//IL_0986: Expected O, but got F4
		//IL_0a61: Expected O, but got F4
		//IL_0b3c: Expected O, but got F4
		//IL_0c17: Expected O, but got F4
		//IL_0d8c->IL0cac: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0cac: Incompatible stack heights: 1 vs 0
		//IL_00e7->IL0cac: Incompatible stack heights: 1 vs 0
		//IL_0116->IL0cac: Incompatible stack heights: 1 vs 0
		//IL_0df3->IL0d03: Incompatible stack heights: 2 vs 0
		base.InternalUpdate();
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		Transform transform2 = default(Transform);
		if (!_isBehind)
		{
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					GameSessionData gameSessionData = core._gameSessionData;
					if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
					{
						transform2 = gameSessionData._activeCharacter.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							object obj2 = default(object);
							object obj3 = default(object);
							object obj = obj2 - obj3;
							float num = (float)obj * -100f;
							float num2 = num + 9f;
							goto IL_0d03;
						}
					}
				}
			}
		}
		else
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					float num2 = renderer.height;
					goto IL_0d03;
				}
			}
		}
		goto IL_0cac;
		IL_0d03:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
		ArcadeSprite arcadeSprite = setDepth((int)transform2);
		if ((object)_eye1 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
			int num3 = default(int);
			PhaserSprite phaserSprite = _eye1.setDepth(num3);
			if ((object)_eye2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
				int num4 = default(int);
				PhaserSprite phaserSprite2 = _eye2.setDepth(num4);
				if ((object)_eye3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
					int num5 = default(int);
					PhaserSprite phaserSprite3 = _eye3.setDepth(num5);
					if ((object)_eye4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
						int num6 = default(int);
						PhaserSprite phaserSprite4 = _eye4.setDepth(num6);
						if ((object)_eye5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
							int num7 = default(int);
							PhaserSprite phaserSprite5 = _eye5.setDepth(num7);
							if ((object)_eye6 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
								int num8 = default(int);
								PhaserSprite phaserSprite6 = _eye6.setDepth(num8);
								if ((object)_eye7 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697C150");
									int num9 = default(int);
									PhaserSprite phaserSprite7 = _eye7.setDepth(num9);
									TileSprite stars = _stars1;
									if ((object)_stars1 != null && (object)stars._spriteRenderer != null)
									{
										int sortingOrder = transform2 + 1;
										stars._spriteRenderer.sortingOrder = sortingOrder;
										TileSprite stars2 = _stars2;
										if ((object)_stars2 != null && (object)stars2._spriteRenderer != null)
										{
											int sortingOrder2 = transform2 + 1;
											stars2._spriteRenderer.sortingOrder = sortingOrder2;
											float2 float5 = base.position;
											if ((object)_LeftHand != null)
											{
												float x = (float)float5 - 0.48f;
												float num10 = default(float);
												PhaserSprite phaserSprite8 = _LeftHand.setPosition(x, num10);
												int num11 = base.Depth;
												if ((object)phaserSprite8 != null)
												{
													int num12 = num11 + 2;
													PhaserSprite phaserSprite9 = phaserSprite8.setDepth(num12);
													if ((object)_RightHand != null)
													{
														float x2 = (float)float5 + 0.48f;
														PhaserSprite phaserSprite10 = _RightHand.setPosition(x2, num10);
														int num13 = base.Depth;
														if ((object)phaserSprite10 != null)
														{
															int num14 = num13 + 2;
															PhaserSprite phaserSprite11 = phaserSprite10.setDepth(num14);
															float2 float6 = SafeXY();
															base.position = float6;
															float deltaTime = PauseSystem.DeltaTime;
															float num15 = deltaTime * 1000f;
															float num16 = num15 * _angleUnit;
															float num17 = num15 * _angleUnit;
															float myAngle = num16 + _myAngle1;
															float num18 = num15 * _angleUnit;
															float myAngle2 = num17 + _myAngle4;
															float myAngle3 = num18 + _myAngle2;
															_myAngle1 = myAngle;
															float num19 = num15 * _angleUnit;
															_myAngle4 = myAngle2;
															float num20 = num15 * _angleUnit;
															float myAngle4 = num19 + _myAngle3;
															_myAngle2 = myAngle3;
															float myAngle5 = num20 + _myAngle6;
															_myAngle3 = myAngle4;
															float num21 = num15 * _angleUnit;
															float num22 = num15 * _angleUnit;
															float myAngle6 = num21 + _myAngle5;
															_myAngle6 = myAngle5;
															float myAngle7 = num22 + _myAngle7;
															_myAngle5 = myAngle6;
															_myAngle7 = myAngle7;
															float2 float7 = base.position;
															if ((object)_eye1 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																float num23 = _myAngle1 * 1.0799999f;
																float x3 = num23 + (float)float7;
																_eye1.X = x3;
																if ((object)_eye1 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																	object obj4 = _Radius2 ^ -0f;
																	float num24 = num10 + 0.64f;
																	float num25 = _myAngle2 * (float)obj4;
																	float y = num25 + num24;
																	_eye1.Y = y;
																	if ((object)_eye2 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																		float num26 = _myAngle2 * 1.0799999f;
																		float x4 = num26 + (float)float7;
																		_eye2.X = x4;
																		if ((object)_eye2 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																			float num27 = num10 + 0.64f;
																			object obj5 = _Radius4 ^ -0f;
																			float num28 = _myAngle3 * (float)obj5;
																			float y2 = num28 + num27;
																			_eye2.Y = y2;
																			if ((object)_eye3 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																				float num29 = _myAngle3 * 1.0799999f;
																				float x5 = num29 + (float)float7;
																				_eye3.X = x5;
																				if ((object)_eye3 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																					float num30 = num10 + 0.64f;
																					object obj6 = _Radius6 ^ -0f;
																					float num31 = _myAngle4 * (float)obj6;
																					float y3 = num31 + num30;
																					_eye3.Y = y3;
																					if ((object)_eye4 != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																						float num32 = _myAngle4 * 1.0799999f;
																						float x6 = num32 + (float)float7;
																						_eye4.X = x6;
																						if ((object)_eye4 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																							float num33 = num10 + 0.64f;
																							object obj7 = _Radius1 ^ -0f;
																							float num34 = _myAngle5 * (float)obj7;
																							float y4 = num34 + num33;
																							_eye4.Y = y4;
																							if ((object)_eye5 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																								float num35 = _myAngle5 * 1.0799999f;
																								float x7 = num35 + (float)float7;
																								_eye5.X = x7;
																								if ((object)_eye5 != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																									float num36 = num10 + 0.64f;
																									object obj8 = _Radius3 ^ -0f;
																									float num37 = _myAngle6 * (float)obj8;
																									float y5 = num37 + num36;
																									_eye5.Y = y5;
																									if ((object)_eye6 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																										float num38 = _myAngle6 * 1.0799999f;
																										float x8 = num38 + (float)float7;
																										_eye6.X = x8;
																										if ((object)_eye6 != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																											float num39 = num10 + 0.64f;
																											object obj9 = _Radius5 ^ -0f;
																											float num40 = _myAngle7 * (float)obj9;
																											float y6 = num40 + num39;
																											_eye6.Y = y6;
																											if ((object)_eye7 != null)
																											{
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																												float num41 = _myAngle7 * 1.0799999f;
																												float x9 = num41 + (float)float7;
																												_eye7.X = x9;
																												if ((object)_eye7 != null)
																												{
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																													float num42 = num10 + 0.64f;
																													object obj10 = _Radius7 ^ -0f;
																													float num43 = _myAngle1 * (float)obj10;
																													float y7 = num43 + num42;
																													_eye7.Y = y7;
																													if ((object)_itemRenderer != null)
																													{
																														Sprite sprite = _itemRenderer.sprite;
																														if ((object)_spriteMask != null)
																														{
																															_spriteMask.sprite = sprite;
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
		goto IL_0cac;
		IL_0cac:
		throw new NullReferenceException();
	}

	public unsafe override void GetTaken()
	{
		//IL_0099: Expected O, but got Ref
		//IL_0099: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = (byte)(~(((Pickup)this)._003CDisableGet_003Ek__BackingField ? 1u : 0u)) != 0;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "PICKUPDIRECTER GetTaken - DisableGet = " + text;
		Debug.Log(message);
		if (!_locallyDisableGet)
		{
			object core = GM.Core;
			Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = GM.Core.EnterDirecter;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rsi_v2 (System.Object)+1F0]");
			object obj = default(object);
			((List<UiTransition>)0).Add((UiTransition)(&obj));
			((Pickup)this)._003CDisableGet_003Ek__BackingField = true;
			_locallyDisableGet = true;
		}
	}

	public override void Despawn()
	{
		//IL_0082: Expected I4, but got O
		//IL_0082: Expected O, but got I
		base.Despawn();
		bool flag = _allTweens == null;
		NetworkPickup networkPickup = this;
		if (!flag)
		{
			List<MultiTargetTween>.Enumerator enumerator = default(List<MultiTargetTween>.Enumerator);
			if (enumerator.MoveNext())
			{
				MultiTargetTween multiTargetTween = null;
				throw new NullReferenceException();
			}
			networkPickup = (NetworkPickup)(object)_allTweens;
			if (_allTweens != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v4 (VampireSurvivors.NetworkPickup)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)networkPickup).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)networkPickup).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)networkPickup).m_CachedPtr, 0, (int)((MonoBehaviour)networkPickup).m_CancellationTokenSource);
				}
				PhaserSprite eye = _eye1;
				if ((object)_eye1 != null && ((UnityEngine.Object)eye).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye1 == null)
					{
						goto IL_054d;
					}
					_eye1.destroy();
				}
				PhaserSprite eye2 = _eye2;
				if ((object)_eye2 != null && ((UnityEngine.Object)eye2).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye2 == null)
					{
						goto IL_054d;
					}
					_eye2.destroy();
				}
				PhaserSprite eye3 = _eye3;
				if ((object)_eye3 != null && ((UnityEngine.Object)eye3).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye3 == null)
					{
						goto IL_054d;
					}
					_eye3.destroy();
				}
				PhaserSprite eye4 = _eye4;
				if ((object)_eye4 != null && ((UnityEngine.Object)eye4).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye4 == null)
					{
						goto IL_054d;
					}
					_eye4.destroy();
				}
				PhaserSprite eye5 = _eye5;
				if ((object)_eye5 != null && ((UnityEngine.Object)eye5).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye5 == null)
					{
						goto IL_054d;
					}
					_eye5.destroy();
				}
				PhaserSprite eye6 = _eye6;
				if ((object)_eye6 != null && ((UnityEngine.Object)eye6).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye6 == null)
					{
						goto IL_054d;
					}
					_eye6.destroy();
				}
				PhaserSprite eye7 = _eye7;
				if ((object)_eye7 != null && ((UnityEngine.Object)eye7).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_eye7 == null)
					{
						goto IL_054d;
					}
					_eye7.destroy();
				}
				PhaserSprite leftHand = _LeftHand;
				if ((object)_LeftHand != null && ((UnityEngine.Object)leftHand).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_LeftHand == null)
					{
						goto IL_054d;
					}
					_LeftHand.destroy();
				}
				PhaserSprite rightHand = _RightHand;
				if ((object)_RightHand != null && ((UnityEngine.Object)rightHand).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_RightHand == null)
					{
						goto IL_054d;
					}
					_RightHand.destroy();
				}
				TileSprite stars = _stars1;
				if ((object)_stars1 != null && ((UnityEngine.Object)stars).m_CachedPtr != (IntPtr)0)
				{
					if ((object)_stars1 == null)
					{
						goto IL_054d;
					}
					_stars1.destroy();
				}
				TileSprite stars2 = _stars2;
				if ((object)_stars2 == null || ((UnityEngine.Object)stars2).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if ((object)_stars2 != null)
				{
					_stars2.destroy();
					return;
				}
			}
		}
		goto IL_054d;
		IL_054d:
		throw new NullReferenceException();
	}

	private void OnForceClosedUi()
	{
		Debug.Log("PICKUPDIRECTER OnForceClosedUI");
		Reset();
		((Pickup)this)._003CDisableGet_003Ek__BackingField = false;
		_locallyDisableGet = false;
	}
}
