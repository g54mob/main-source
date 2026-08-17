using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items;

public class PickupHealer : Pickup
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

	private const float ANGLE_UNIT = -(float)Math.PI / 180f;

	protected unsafe override void Awake()
	{
		//IL_14d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14de: Expected O, but got Unknown
		//IL_005f: Expected O, but got I4
		//IL_00f6: Expected O, but got I4
		//IL_018d: Expected O, but got I4
		//IL_0224: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		//IL_03e9: Expected O, but got I4
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0553: Expected I, but got O
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Expected O, but got Unknown
		//IL_0692: Expected I, but got O
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_07cc: Expected I, but got O
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Expected O, but got Unknown
		//IL_0906: Expected I, but got O
		//IL_093f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Expected O, but got Unknown
		//IL_0a40: Expected I, but got O
		//IL_0a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected O, but got Unknown
		//IL_0b7a: Expected I, but got O
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb8: Expected O, but got Unknown
		//IL_0cb4: Expected I, but got O
		//IL_0db8: Expected I, but got O
		//IL_0ebc: Expected I, but got O
		//IL_0fc0: Expected I, but got O
		//IL_10c4: Expected I, but got O
		//IL_11c8: Expected I, but got O
		//IL_12cc: Expected I, but got O
		//IL_13d0: Expected I, but got O
		//IL_0047->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_007b->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_00de->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0112->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0175->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_01a9->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_020c->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0240->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_02a3->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_02d7->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_033a->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_036e->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_03d1->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0405->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0484->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_04bc->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_0507->IL13e3: Incompatible stack heights: 1 vs 0
		//IL_05c3->IL13e3: Incompatible stack heights: 2 vs 0
		//IL_05fb->IL13e3: Incompatible stack heights: 2 vs 0
		//IL_0646->IL13e3: Incompatible stack heights: 2 vs 0
		//IL_06fd->IL13e3: Incompatible stack heights: 3 vs 0
		//IL_0735->IL13e3: Incompatible stack heights: 3 vs 0
		//IL_0780->IL13e3: Incompatible stack heights: 3 vs 0
		//IL_0837->IL13e3: Incompatible stack heights: 4 vs 0
		//IL_086f->IL13e3: Incompatible stack heights: 4 vs 0
		//IL_08ba->IL13e3: Incompatible stack heights: 4 vs 0
		//IL_0971->IL13e3: Incompatible stack heights: 5 vs 0
		//IL_09a9->IL13e3: Incompatible stack heights: 5 vs 0
		//IL_09f4->IL13e3: Incompatible stack heights: 5 vs 0
		//IL_0aab->IL13e3: Incompatible stack heights: 6 vs 0
		//IL_0ae3->IL13e3: Incompatible stack heights: 6 vs 0
		//IL_0b2e->IL13e3: Incompatible stack heights: 6 vs 0
		//IL_0be5->IL13e3: Incompatible stack heights: 7 vs 0
		//IL_0c1d->IL13e3: Incompatible stack heights: 7 vs 0
		//IL_0c68->IL13e3: Incompatible stack heights: 7 vs 0
		//IL_0cff->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0d4d->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0da1->IL0da1: Incompatible stack heights: 9 vs 8
		//IL_0e03->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0e51->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0ea5->IL0ea5: Incompatible stack heights: 9 vs 8
		//IL_0f07->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0f55->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_0fa9->IL0fa9: Incompatible stack heights: 9 vs 8
		//IL_100b->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_1059->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_10ad->IL10ad: Incompatible stack heights: 9 vs 8
		//IL_110f->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_115d->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_11b1->IL11b1: Incompatible stack heights: 9 vs 8
		//IL_1213->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_1261->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_12b5->IL12b5: Incompatible stack heights: 9 vs 8
		//IL_1317->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_1365->IL13e3: Incompatible stack heights: 8 vs 0
		//IL_13b9->IL13b9: Incompatible stack heights: 9 vs 8
		base.Awake();
		_Radius1 = 1.0799999f;
		_Radius2 = 1.0799999f;
		_Radius3 = 1.0799999f;
		_Radius4 = 1.0799999f;
		_Radius5 = 1.0799999f;
		_Radius6 = 1.0799999f;
		_Radius7 = 1.0799999f;
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
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj2 = default(object);
			object obj = obj2 - 56;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "eyeanim_0");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setScale(2f, (float?)(object)0);
				if ((object)phaserSprite2 != null)
				{
					PhaserSprite eye = phaserSprite2.setTintFill(isEnabled: true, 0u);
					_eye1 = eye;
					GameObject gameObject2 = base.gameObject;
					PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "eyeanim_0");
					if ((object)phaserSprite3 != null)
					{
						PhaserSprite phaserSprite4 = phaserSprite3.setScale(1.75f, (float?)(object)0);
						if ((object)phaserSprite4 != null)
						{
							PhaserSprite eye2 = phaserSprite4.setTintFill(isEnabled: true, 0u);
							_eye2 = eye2;
							GameObject gameObject3 = base.gameObject;
							PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "eyeanim_0");
							if ((object)phaserSprite5 != null)
							{
								PhaserSprite phaserSprite6 = phaserSprite5.setScale(1.5f, (float?)(object)0);
								if ((object)phaserSprite6 != null)
								{
									PhaserSprite eye3 = phaserSprite6.setTintFill(isEnabled: true, 0u);
									_eye3 = eye3;
									GameObject gameObject4 = base.gameObject;
									PhaserSprite phaserSprite7 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "vfx", "eyeanim_0");
									if ((object)phaserSprite7 != null)
									{
										PhaserSprite phaserSprite8 = phaserSprite7.setScale(1.25f, (float?)(object)0);
										if ((object)phaserSprite8 != null)
										{
											PhaserSprite eye4 = phaserSprite8.setTintFill(isEnabled: true, 0u);
											_eye4 = eye4;
											GameObject gameObject5 = base.gameObject;
											PhaserSprite phaserSprite9 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "vfx", "eyeanim_0");
											if ((object)phaserSprite9 != null)
											{
												PhaserSprite phaserSprite10 = phaserSprite9.setScale(1f, (float?)(object)0);
												if ((object)phaserSprite10 != null)
												{
													PhaserSprite eye5 = phaserSprite10.setTintFill(isEnabled: true, 0u);
													_eye5 = eye5;
													GameObject gameObject6 = base.gameObject;
													PhaserSprite phaserSprite11 = RenderingExtensions.AddPhaserSprite(gameObject6, pos, "vfx", "eyeanim_0");
													if ((object)phaserSprite11 != null)
													{
														PhaserSprite phaserSprite12 = phaserSprite11.setScale(0.75f, (float?)(object)0);
														if ((object)phaserSprite12 != null)
														{
															PhaserSprite eye6 = phaserSprite12.setTintFill(isEnabled: true, 0u);
															_eye6 = eye6;
															GameObject gameObject7 = base.gameObject;
															PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject7, pos, "vfx", "eyeanim_0");
															if ((object)phaserSprite13 != null)
															{
																PhaserSprite phaserSprite14 = phaserSprite13.setScale(0.5f, (float?)(object)0);
																if ((object)phaserSprite14 != null)
																{
																	PhaserSprite eye7 = phaserSprite14.setTintFill(isEnabled: true, 0u);
																	_eye7 = eye7;
																	TweenConfig tweenConfig = new TweenConfig();
																	Dictionary<string, object> dictionary = new Dictionary<string, object>();
																	object obj3 = obj2 + 40;
																	_ = 1057635696;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																	if (dictionary != null)
																	{
																		object value = default(object);
																		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_Radius1", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																		if (tweenConfig != null)
																		{
																			_ = 1148993536;
																			_ = 1;
																			_ = 4294967295L;
																			object[] array = new object[1];
																			if (array != null)
																			{
																				void* value2 = ((IntPtr*)(&array))->m_value;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																				object obj4 = default(object);
																				bool flag3 = obj4 == null;
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																				((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
																				MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
																				TweenConfig tweenConfig2 = new TweenConfig();
																				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
																				object obj5 = obj2 + 40;
																				_ = 1057635696;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																				if (dictionary2 != null)
																				{
																					object value3 = default(object);
																					bool flag4 = ((Dictionary<object, object>)(object)dictionary2).TryInsert((object)"_Radius2", value3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																					if (tweenConfig2 != null)
																					{
																						_ = 1150820352;
																						_ = 1;
																						_ = 4294967295L;
																						object[] array2 = new object[1];
																						if (array2 != null)
																						{
																							void* value4 = ((IntPtr*)(&array2))->m_value;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																							object obj6 = default(object);
																							bool flag5 = obj6 == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																							((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
																							MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
																							TweenConfig tweenConfig3 = new TweenConfig();
																							Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
																							object obj7 = obj2 + 40;
																							_ = 1057635696;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																							if (dictionary3 != null)
																							{
																								object value5 = default(object);
																								bool flag6 = ((Dictionary<object, object>)(object)dictionary3).TryInsert((object)"_Radius3", value5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																								if (tweenConfig3 != null)
																								{
																									_ = 1153048576;
																									_ = 1;
																									_ = 4294967295L;
																									object[] array3 = new object[1];
																									if (array3 != null)
																									{
																										void* value6 = ((IntPtr*)(&array3))->m_value;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																										object obj8 = default(object);
																										bool flag7 = obj8 == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																										((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
																										MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
																										TweenConfig tweenConfig4 = new TweenConfig();
																										Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
																										object obj9 = obj2 + 40;
																										_ = 1057635696;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																										if (dictionary4 != null)
																										{
																											object value7 = default(object);
																											bool flag8 = ((Dictionary<object, object>)(object)dictionary4).TryInsert((object)"_Radius4", value7, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																											if (tweenConfig4 != null)
																											{
																												_ = 1154113536;
																												_ = 1;
																												_ = 4294967295L;
																												object[] array4 = new object[1];
																												if (array4 != null)
																												{
																													void* value8 = ((IntPtr*)(&array4))->m_value;
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																													object obj10 = default(object);
																													bool flag9 = obj10 == null;
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																													((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
																													MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																													TweenConfig tweenConfig5 = new TweenConfig();
																													Dictionary<string, object> dictionary5 = new Dictionary<string, object>();
																													object obj11 = obj2 + 40;
																													_ = 1057635696;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																													if (dictionary5 != null)
																													{
																														object value9 = default(object);
																														bool flag10 = ((Dictionary<object, object>)(object)dictionary5).TryInsert((object)"_Radius5", value9, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																														if (tweenConfig5 != null)
																														{
																															_ = 1156096000;
																															_ = 1;
																															_ = 4294967295L;
																															object[] array5 = new object[1];
																															if (array5 != null)
																															{
																																void* value10 = ((IntPtr*)(&array5))->m_value;
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																object obj12 = default(object);
																																bool flag11 = obj12 == null;
																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																((UnityEngine.Object)(object)tweenConfig5).m_CachedPtr = (IntPtr)array5;
																																MultiTargetTween multiTargetTween5 = Tweens.Add(tweenConfig5);
																																TweenConfig tweenConfig6 = new TweenConfig();
																																Dictionary<string, object> dictionary6 = new Dictionary<string, object>();
																																object obj13 = obj2 + 40;
																																_ = 1057635696;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																if (dictionary6 != null)
																																{
																																	object value11 = default(object);
																																	bool flag12 = ((Dictionary<object, object>)(object)dictionary6).TryInsert((object)"_Radius6", value11, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																	if (tweenConfig6 != null)
																																	{
																																		_ = 1157836800;
																																		_ = 1;
																																		_ = 4294967295L;
																																		object[] array6 = new object[1];
																																		if (array6 != null)
																																		{
																																			void* value12 = ((IntPtr*)(&array6))->m_value;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																			object obj14 = default(object);
																																			bool flag13 = obj14 == null;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																			((UnityEngine.Object)(object)tweenConfig6).m_CachedPtr = (IntPtr)array6;
																																			MultiTargetTween multiTargetTween6 = Tweens.Add(tweenConfig6);
																																			TweenConfig tweenConfig7 = new TweenConfig();
																																			Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
																																			object obj15 = obj2 + 40;
																																			_ = 1057635696;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																																			if (dictionary7 != null)
																																			{
																																				object value13 = default(object);
																																				bool flag14 = ((Dictionary<object, object>)(object)dictionary7).TryInsert((object)"_Radius7", value13, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																																				if (tweenConfig7 != null)
																																				{
																																					_ = 1158828032;
																																					_ = 1;
																																					_ = 4294967295L;
																																					object[] array7 = new object[1];
																																					if (array7 != null)
																																					{
																																						void* value14 = ((IntPtr*)(&array7))->m_value;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																						object obj16 = default(object);
																																						bool flag15 = obj16 == null;
																																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																						((UnityEngine.Object)(object)tweenConfig7).m_CachedPtr = (IntPtr)array7;
																																						MultiTargetTween multiTargetTween7 = Tweens.Add(tweenConfig7);
																																						TweenConfig tweenConfig8 = new TweenConfig();
																																						_ = 0;
																																						_ = 1056964608;
																																						_ = 1;
																																						if (tweenConfig8 != null)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																							_ = 0;
																																							_ = 1148993536;
																																							_ = 1;
																																							_ = 4294967295L;
																																							object[] array8 = new object[1];
																																							if (array8 != null)
																																							{
																																								if ((object)_eye1 != null)
																																								{
																																									void* value15 = ((IntPtr*)(&array8))->m_value;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																									object obj17 = default(object);
																																									bool flag16 = obj17 == null;
																																								}
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																								((UnityEngine.Object)(object)tweenConfig8).m_CachedPtr = (IntPtr)array8;
																																								MultiTargetTween multiTargetTween8 = Tweens.Add(tweenConfig8);
																																								TweenConfig tweenConfig9 = new TweenConfig();
																																								_ = 0;
																																								_ = 1061158912;
																																								_ = 1;
																																								if (tweenConfig9 != null)
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																									_ = 0;
																																									_ = 1150820352;
																																									_ = 1;
																																									_ = 4294967295L;
																																									object[] array9 = new object[1];
																																									if (array9 != null)
																																									{
																																										if ((object)_eye2 != null)
																																										{
																																											void* value16 = ((IntPtr*)(&array9))->m_value;
																																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																											object obj18 = default(object);
																																											bool flag17 = obj18 == null;
																																										}
																																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																										((UnityEngine.Object)(object)tweenConfig9).m_CachedPtr = (IntPtr)array9;
																																										MultiTargetTween multiTargetTween9 = Tweens.Add(tweenConfig9);
																																										TweenConfig tweenConfig10 = new TweenConfig();
																																										_ = 0;
																																										_ = 1065353216;
																																										_ = 1;
																																										if (tweenConfig10 != null)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																											_ = 0;
																																											_ = 1153048576;
																																											_ = 1;
																																											_ = 4294967295L;
																																											object[] array10 = new object[1];
																																											if (array10 != null)
																																											{
																																												if ((object)_eye3 != null)
																																												{
																																													void* value17 = ((IntPtr*)(&array10))->m_value;
																																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																													object obj19 = default(object);
																																													bool flag18 = obj19 == null;
																																												}
																																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																												((UnityEngine.Object)(object)tweenConfig10).m_CachedPtr = (IntPtr)array10;
																																												MultiTargetTween multiTargetTween10 = Tweens.Add(tweenConfig10);
																																												TweenConfig tweenConfig11 = new TweenConfig();
																																												_ = 0;
																																												_ = 1067450368;
																																												_ = 1;
																																												if (tweenConfig11 != null)
																																												{
																																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																													_ = 0;
																																													_ = 1154113536;
																																													_ = 1;
																																													_ = 4294967295L;
																																													object[] array11 = new object[1];
																																													if (array11 != null)
																																													{
																																														if ((object)_eye4 != null)
																																														{
																																															void* value18 = ((IntPtr*)(&array11))->m_value;
																																															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																															object obj20 = default(object);
																																															bool flag19 = obj20 == null;
																																														}
																																														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																														((UnityEngine.Object)(object)tweenConfig11).m_CachedPtr = (IntPtr)array11;
																																														MultiTargetTween multiTargetTween11 = Tweens.Add(tweenConfig11);
																																														TweenConfig tweenConfig12 = new TweenConfig();
																																														_ = 0;
																																														_ = 1069547520;
																																														_ = 1;
																																														if (tweenConfig12 != null)
																																														{
																																															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																															_ = 0;
																																															_ = 1156096000;
																																															_ = 1;
																																															_ = 4294967295L;
																																															object[] array12 = new object[1];
																																															if (array12 != null)
																																															{
																																																if ((object)_eye5 != null)
																																																{
																																																	void* value19 = ((IntPtr*)(&array12))->m_value;
																																																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																	object obj21 = default(object);
																																																	bool flag20 = obj21 == null;
																																																}
																																																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																((UnityEngine.Object)(object)tweenConfig12).m_CachedPtr = (IntPtr)array12;
																																																MultiTargetTween multiTargetTween12 = Tweens.Add(tweenConfig12);
																																																TweenConfig tweenConfig13 = new TweenConfig();
																																																_ = 0;
																																																_ = 1071644672;
																																																_ = 1;
																																																if (tweenConfig13 != null)
																																																{
																																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																																	_ = 0;
																																																	_ = 1157836800;
																																																	_ = 1;
																																																	_ = 4294967295L;
																																																	object[] array13 = new object[1];
																																																	if (array13 != null)
																																																	{
																																																		if ((object)_eye6 != null)
																																																		{
																																																			void* value20 = ((IntPtr*)(&array13))->m_value;
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																			object obj22 = default(object);
																																																			bool flag21 = obj22 == null;
																																																		}
																																																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																		((UnityEngine.Object)(object)tweenConfig13).m_CachedPtr = (IntPtr)array13;
																																																		MultiTargetTween multiTargetTween13 = Tweens.Add(tweenConfig13);
																																																		TweenConfig tweenConfig14 = new TweenConfig();
																																																		_ = 0;
																																																		_ = 1073741824;
																																																		_ = 1;
																																																		if (tweenConfig14 != null)
																																																		{
																																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
																																																			_ = 0;
																																																			_ = 1158828032;
																																																			_ = 1;
																																																			_ = 4294967295L;
																																																			object[] array14 = new object[1];
																																																			if (array14 != null)
																																																			{
																																																				if ((object)_eye7 != null)
																																																				{
																																																					void* value21 = ((IntPtr*)(&array14))->m_value;
																																																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																																					object obj23 = default(object);
																																																					bool flag22 = obj23 == null;
																																																				}
																																																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																																																				((UnityEngine.Object)(object)tweenConfig14).m_CachedPtr = (IntPtr)array14;
																																																				MultiTargetTween multiTargetTween14 = Tweens.Add(tweenConfig14);
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
		throw new NullReferenceException();
	}

	public override void SetData(ItemType itemType)
	{
		//IL_0084: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		base.SetData(itemType);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		base.GoToPlayer = true;
		base._003CIsStationary_003Ek__BackingField = true;
		SetFrame("Healer");
		base._003CResRosary_003Ek__BackingField = 1f;
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		CheckRenderer();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(((ArcadeSprite)this)._spriteRenderer, 4f);
	}

	public override void InternalUpdate()
	{
		//IL_09aa: Expected I4, but got O
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected I4, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected I4, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected I4, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected I4, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected I4, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected I4, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected I4, but got Unknown
		//IL_0961->IL08db: Incompatible stack heights: 1 vs 0
		//IL_0039->IL08db: Incompatible stack heights: 1 vs 0
		//IL_005b->IL08db: Incompatible stack heights: 1 vs 0
		//IL_008a->IL08db: Incompatible stack heights: 1 vs 0
		//IL_09c8->IL08db: Incompatible stack heights: 2 vs 0
		//IL_00d4->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0114->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0154->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0194->IL08db: Incompatible stack heights: 2 vs 0
		//IL_01d4->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0214->IL08db: Incompatible stack heights: 2 vs 0
		//IL_03c2->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0421->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0480->IL08db: Incompatible stack heights: 2 vs 0
		//IL_04df->IL08db: Incompatible stack heights: 2 vs 0
		//IL_053e->IL08db: Incompatible stack heights: 2 vs 0
		//IL_059d->IL08db: Incompatible stack heights: 2 vs 0
		//IL_05fc->IL08db: Incompatible stack heights: 2 vs 0
		//IL_065b->IL08db: Incompatible stack heights: 2 vs 0
		//IL_06ba->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0719->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0778->IL08db: Incompatible stack heights: 2 vs 0
		//IL_07d7->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0836->IL08db: Incompatible stack heights: 2 vs 0
		//IL_0895->IL08db: Incompatible stack heights: 2 vs 0
		base.InternalUpdate();
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
					Transform transform2 = gameSessionData._activeCharacter.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
						ArcadeSprite arcadeSprite = setDepth((int)transform2);
						if ((object)_eye1 != null)
						{
							int num = transform2 + 2;
							PhaserSprite phaserSprite = _eye1.setDepth(num);
							if ((object)_eye2 != null)
							{
								int num2 = transform2 + 2;
								PhaserSprite phaserSprite2 = _eye2.setDepth(num2);
								if ((object)_eye3 != null)
								{
									int num3 = transform2 + 2;
									PhaserSprite phaserSprite3 = _eye3.setDepth(num3);
									if ((object)_eye4 != null)
									{
										int num4 = transform2 + 2;
										PhaserSprite phaserSprite4 = _eye4.setDepth(num4);
										if ((object)_eye5 != null)
										{
											int num5 = transform2 + 2;
											PhaserSprite phaserSprite5 = _eye5.setDepth(num5);
											if ((object)_eye6 != null)
											{
												int num6 = transform2 + 2;
												PhaserSprite phaserSprite6 = _eye6.setDepth(num6);
												if ((object)_eye7 != null)
												{
													int num7 = transform2 + 2;
													PhaserSprite phaserSprite7 = _eye7.setDepth(num7);
													float2 float5 = SafeXY();
													base.position = float5;
													float deltaTime = PauseSystem.DeltaTime;
													float num8 = deltaTime * 1000f;
													float num9 = num8 * (-(float)Math.PI / 180f);
													float num10 = num8 * (-(float)Math.PI / 180f);
													float myAngle = num9 + _myAngle1;
													float myAngle2 = num10 + _myAngle3;
													_myAngle1 = myAngle;
													float num11 = num8 * (-(float)Math.PI / 180f);
													_myAngle3 = myAngle2;
													float num12 = num8 * (-(float)Math.PI / 180f);
													float myAngle3 = num11 + _myAngle2;
													float myAngle4 = num12 + _myAngle5;
													_myAngle2 = myAngle3;
													float num13 = num8 * (-(float)Math.PI / 180f);
													_myAngle5 = myAngle4;
													float myAngle5 = num13 + _myAngle4;
													_myAngle4 = myAngle5;
													float num14 = num8 * (-(float)Math.PI / 180f);
													float num15 = num8 * (-(float)Math.PI / 180f);
													float myAngle6 = num14 + _myAngle6;
													float myAngle7 = num15 + _myAngle7;
													_myAngle6 = myAngle6;
													_myAngle7 = myAngle7;
													float2 float6 = base.position;
													if ((object)_eye1 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
														float num16 = _myAngle1 * _Radius1;
														float x = num16 + (float)float6;
														_eye1.X = x;
														if ((object)_eye1 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
															float num17 = _myAngle1 * _Radius2;
															object obj = default(object);
															float y = num17 + (float)obj;
															_eye1.Y = y;
															if ((object)_eye2 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																float num18 = _myAngle2 * _Radius3;
																float x2 = num18 + (float)float6;
																_eye2.X = x2;
																if ((object)_eye2 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																	float num19 = _myAngle2 * _Radius4;
																	float y2 = num19 + (float)obj;
																	_eye2.Y = y2;
																	if ((object)_eye3 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																		float num20 = _myAngle3 * _Radius5;
																		float x3 = num20 + (float)float6;
																		_eye3.X = x3;
																		if ((object)_eye3 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																			float num21 = _myAngle3 * _Radius6;
																			float y3 = num21 + (float)obj;
																			_eye3.Y = y3;
																			if ((object)_eye4 != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																				float num22 = _myAngle4 * _Radius7;
																				float x4 = num22 + (float)float6;
																				_eye4.X = x4;
																				if ((object)_eye4 != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																					float num23 = _myAngle4 * _Radius1;
																					float y4 = num23 + (float)obj;
																					_eye4.Y = y4;
																					if ((object)_eye5 != null)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																						float num24 = _myAngle5 * _Radius2;
																						float x5 = num24 + (float)float6;
																						_eye5.X = x5;
																						if ((object)_eye5 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																							float num25 = _myAngle5 * _Radius3;
																							float y5 = num25 + (float)obj;
																							_eye5.Y = y5;
																							if ((object)_eye6 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																								float num26 = _myAngle6 * _Radius4;
																								float x6 = num26 + (float)float6;
																								_eye6.X = x6;
																								if ((object)_eye6 != null)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																									float num27 = _myAngle6 * _Radius5;
																									float y6 = num27 + (float)obj;
																									_eye6.Y = y6;
																									if ((object)_eye7 != null)
																									{
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																										float num28 = _myAngle7 * _Radius6;
																										float x7 = num28 + (float)float6;
																										_eye7.X = x7;
																										if ((object)_eye7 != null)
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																											float num29 = _myAngle7 * _Radius7;
																											float y7 = num29 + (float)obj;
																											_eye7.Y = y7;
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
		throw new NullReferenceException();
	}

	public unsafe override void GetTaken()
	{
		//IL_00d7: Expected O, but got Ref
		//IL_00d7: Expected O, but got I
		if (!base._003CDisableGet_003Ek__BackingField)
		{
			PhaserSprite phaserSprite = _eye1.setVisible(visible: false);
			PhaserSprite phaserSprite2 = _eye2.setVisible(visible: false);
			PhaserSprite phaserSprite3 = _eye3.setVisible(visible: false);
			PhaserSprite phaserSprite4 = _eye4.setVisible(visible: false);
			PhaserSprite phaserSprite5 = _eye5.setVisible(visible: false);
			PhaserSprite phaserSprite6 = _eye6.setVisible(visible: false);
			PhaserSprite phaserSprite7 = _eye7.setVisible(visible: false);
			object core = GM.Core;
			Action<VampireSurvivors.Objects.Characters.CharacterController, Dictionary<string, object>> action = GM.Core.EnterHealer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rsi_v4 (System.Object)+1F0]");
			object obj = default(object);
			((List<UiTransition>)0).Add((UiTransition)(&obj));
			base.GetTaken();
		}
	}
}
