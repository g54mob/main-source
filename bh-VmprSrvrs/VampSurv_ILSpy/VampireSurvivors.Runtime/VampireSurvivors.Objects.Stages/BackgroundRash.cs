using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.Blitters;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundRash : BackgroundManager
{
	private bool _canShowPizzas = true;

	private bool _pizzaTriggered;

	private bool _arePizzasVisible;

	private MultiTargetTween _pizzaTween;

	private object[] _pizzaSprites;

	private Blitter _blitter;

	private bool _spawnAtlasRelic;

	public override void Create()
	{
		//IL_079f: Invalid comparison between F4 and O
		//IL_02a8: Expected I4, but got I8
		//IL_0305: Expected I, but got O
		//IL_01ed->IL06d2: Incompatible stack heights: 1 vs 0
		//IL_0224->IL06d2: Incompatible stack heights: 1 vs 0
		//IL_0761->IL06d2: Incompatible stack heights: 2 vs 0
		//IL_0291->IL06d2: Incompatible stack heights: 3 vs 0
		//IL_02f8->IL06d2: Incompatible stack heights: 3 vs 0
		//IL_0362->IL06d2: Incompatible stack heights: 4 vs 0
		//IL_037c->IL07bc: Incompatible stack heights: 4 vs 0
		base.Create();
		MakeBlitters();
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				List<PizzaCircle> pizzaCircles = stage._pizzaCircles;
				if (stage._pizzaCircles != null)
				{
					object[] pizzaSprites = new object[pizzaCircles._size];
					_pizzaSprites = pizzaSprites;
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						int num = 0;
						int num2 = 0;
						int num3 = 0;
						Vector2 pos = default(Vector2);
						object obj = default(object);
						float yMax = default(float);
						bool skipInverseCalculation = default(bool);
						object obj2 = default(object);
						object obj3 = default(object);
						while (true)
						{
							Stage stage2 = core2._stage;
							if ((object)core2._stage == null)
							{
								break;
							}
							List<PizzaCircle> pizzaCircles2 = stage2._pizzaCircles;
							if (stage2._pizzaCircles == null)
							{
								break;
							}
							if (num3 < pizzaCircles2._size)
							{
								GameManager core3 = GM.Core;
								if ((object)GM.Core == null)
								{
									break;
								}
								Stage stage3 = core3._stage;
								if ((object)core3._stage == null)
								{
									break;
								}
								List<PizzaCircle> pizzaCircles3 = stage3._pizzaCircles;
								if (stage3._pizzaCircles == null)
								{
									break;
								}
								bool flag = num2 >= pizzaCircles3._size;
								PizzaCircle[] items = pizzaCircles3._items;
								if (pizzaCircles3._items == null)
								{
									break;
								}
								SpriteRenderer spriteRenderer = (SpriteRenderer)(object)items[num2];
								if ((object)items[num2] == null)
								{
									break;
								}
								bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
								IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr);
								Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
								if ((object)transform == null)
								{
									break;
								}
								bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
								bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)10.24f) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret);
								string spriteName = "PizzaTime";
								if (!flag4)
								{
									spriteName = "PizzaBoss";
								}
								Transform pizzaSprites2 = (Transform)(object)_pizzaSprites;
								SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(this, pos, "items", spriteName);
								SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0f);
								if ((object)spriteRenderer3 == null)
								{
									break;
								}
								spriteRenderer3.sortingOrder = -1;
								string text = num.ToString();
								string text2 = "PizzaSprite_" + text;
								((UnityEngine.Object)spriteRenderer3).SetName(text2);
								if (_pizzaSprites == null)
								{
									break;
								}
								nint num4 = (nint)pizzaSprites2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag5 = obj == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								num2++;
								core2 = GM.Core;
								if ((object)GM.Core == null)
								{
									break;
								}
								num = num2;
								num3 = num2;
								continue;
							}
							if ((object)GM.Core == null)
							{
								break;
							}
							GM.Core.SetHardBoundsMinMax(512f, 512f, 1536f, yMax, skipInverseCalculation);
							GameManager core4 = GM.Core;
							if ((object)GM.Core == null)
							{
								break;
							}
							PlayerOptions playerOptions = core4._playerOptions;
							if (core4._playerOptions == null)
							{
								break;
							}
							PlayerOptionsData playerOptionsData;
							if (playerOptions._onlineClientWithRunDataConfig == null)
							{
								if (playerOptions._hostGameConfig == null)
								{
									if (playerOptions._currentAdventureSaveData != null)
									{
										PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
										if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
										{
											playerOptionsData = currentAdventureSaveData;
											goto IL_084f;
										}
									}
									playerOptionsData = playerOptions._mainGameConfig;
									if (playerOptions._mainGameConfig == null)
									{
										break;
									}
								}
								else
								{
									playerOptionsData = playerOptions._hostGameConfig;
								}
							}
							else
							{
								playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
							}
							goto IL_084f;
							IL_087e:
							PlayerOptionsData playerOptionsData2;
							List<ItemType> list = playerOptionsData2._003CCollectedItems_003Ek__BackingField;
							if (playerOptionsData2._003CCollectedItems_003Ek__BackingField == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v35 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
								if ((nint)obj2 != -1)
								{
									return;
								}
							}
							_spawnAtlasRelic = true;
							return;
							IL_084f:
							List<ItemType> list2 = playerOptionsData._003CCollectedItems_003Ek__BackingField;
							if (playerOptionsData._003CCollectedItems_003Ek__BackingField == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rcx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
							if ((nint)0 == 0)
							{
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
							if ((nint)obj3 == -1)
							{
								return;
							}
							GameManager core5 = GM.Core;
							if ((object)GM.Core == null)
							{
								break;
							}
							PlayerOptions playerOptions2 = core5._playerOptions;
							if (core5._playerOptions == null)
							{
								break;
							}
							if (playerOptions2._onlineClientWithRunDataConfig == null)
							{
								if (playerOptions2._hostGameConfig == null)
								{
									if (playerOptions2._currentAdventureSaveData != null)
									{
										PlayerOptionsData currentAdventureSaveData2 = playerOptions2._currentAdventureSaveData;
										if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
										{
											playerOptionsData2 = currentAdventureSaveData2;
											goto IL_087e;
										}
									}
									playerOptionsData2 = playerOptions2._mainGameConfig;
									if (playerOptions2._mainGameConfig == null)
									{
										break;
									}
								}
								else
								{
									playerOptionsData2 = playerOptions2._hostGameConfig;
								}
							}
							else
							{
								playerOptionsData2 = playerOptions2._onlineClientWithRunDataConfig;
							}
							goto IL_087e;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void CheckMinute(int minute)
	{
		if (minute == 7 && _spawnAtlasRelic)
		{
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt(10.24f, -10.24f);
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.RELIC, WeaponType.VOID, value, relicType, validatePickups);
		}
	}

	protected override void OnDestroy()
	{
		//IL_0013: Expected O, but got I4
		base.OnDestroy();
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	protected override void OnUpdate()
	{
		//IL_03c7: Expected I, but got O
		//IL_0020: Invalid comparison between I and F4
		//IL_004e: Expected I, but got O
		//IL_0069: Invalid comparison between F4 and I
		//IL_0090: Invalid comparison between F4 and I4
		//IL_00d6: Expected I, but got O
		//IL_036b: Expected O, but got I4
		//IL_0247: Expected O, but got I4
		base.OnUpdate();
		UpdateBlitter();
		nint num = (nint)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
			bool canShowPizzas;
			if (0f < 30f)
			{
				canShowPizzas = false;
			}
			else
			{
				num = (nint)GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
				bool flag = 600f < 0f;
				float num2 = 600f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v6 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+3E0]");
				float num3 = num2 - 0f;
				bool flag2 = num3 == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				canShowPizzas = flag4 & flag3;
			}
			if ((object)this != null)
			{
				_canShowPizzas = canShowPizzas;
				nint num4 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rax_v10 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				num = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._characters != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
					while (enumerator.MoveNext())
					{
						if (!_canShowPizzas)
						{
							if (~(_pizzaTriggered ? 1u : 0u) == 0)
							{
								_pizzaTriggered = false;
							}
						}
						else if (!_pizzaTriggered)
						{
							CheckPizzas(null);
						}
					}
					if (_canShowPizzas)
					{
						if (!_arePizzasVisible && !_pizzaTriggered)
						{
							if (_pizzaTween != null)
							{
								_pizzaTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							if (tweenConfig != null)
							{
								tweenConfig.targets = _pizzaSprites;
								tweenConfig.alpha = (float?)(object)1;
								tweenConfig.duration = 300f;
								MultiTargetTween pizzaTween = Tweens.Add(tweenConfig);
								_pizzaTween = pizzaTween;
								_arePizzasVisible = true;
								return;
							}
							goto IL_03a6;
						}
						if (_canShowPizzas)
						{
							goto IL_02ca;
						}
					}
					if (!_arePizzasVisible)
					{
						goto IL_02ca;
					}
					goto IL_046a;
				}
			}
		}
		goto IL_03a6;
		IL_03a6:
		throw new NullReferenceException();
		IL_046a:
		if (_pizzaTween != null)
		{
			_pizzaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		if (tweenConfig2 != null)
		{
			tweenConfig2.targets = _pizzaSprites;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = 300f;
			MultiTargetTween pizzaTween2 = Tweens.Add(tweenConfig2);
			_pizzaTween = pizzaTween2;
			_arePizzasVisible = false;
			return;
		}
		goto IL_03a6;
		IL_02ca:
		if (_pizzaTriggered && _arePizzasVisible)
		{
			goto IL_046a;
		}
	}

	private void ShowPizzas()
	{
		//IL_0054: Expected O, but got I4
		if (_pizzaTween != null)
		{
			_pizzaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = _pizzaSprites;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween pizzaTween = Tweens.Add(tweenConfig);
		_pizzaTween = pizzaTween;
		_arePizzasVisible = true;
	}

	private void HidePizzas()
	{
		//IL_0054: Expected O, but got I4
		if (_pizzaTween != null)
		{
			_pizzaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		tweenConfig.targets = _pizzaSprites;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween pizzaTween = Tweens.Add(tweenConfig);
		_pizzaTween = pizzaTween;
		_arePizzasVisible = false;
	}

	private void CheckPizzas(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_03ac->IL044a: Incompatible stack heights: 15 vs 4
		//IL_0313->IL0399: Incompatible stack heights: 19 vs 20
		//IL_039f->IL0419: Incompatible stack heights: 20 vs 14
		bool flag = (object)character == null;
		Transform transform = character.transform;
		bool flag2 = (object)transform == null;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		GameManager core = GM.Core;
		bool flag4 = (object)GM.Core == null;
		Transform transform2 = null;
		Transform transform3 = null;
		Vector2 vector = default(Vector2);
		while (true)
		{
			Stage stage = core._stage;
			bool flag5 = (object)core._stage == null;
			List<PizzaCircle> pizzaCircles = stage._pizzaCircles;
			bool flag6 = stage._pizzaCircles == null;
			if ((nint)transform2 >= pizzaCircles._size)
			{
				break;
			}
			GameManager core2 = GM.Core;
			bool flag7 = (object)GM.Core == null;
			Stage stage2 = core2._stage;
			bool flag8 = (object)core2._stage == null;
			List<PizzaCircle> pizzaCircles2 = stage2._pizzaCircles;
			bool flag9 = stage2._pizzaCircles == null;
			bool flag10 = (nint)transform3 >= pizzaCircles2._size;
			PizzaCircle[] items = pizzaCircles2._items;
			bool flag11 = pizzaCircles2._items == null;
			bool flag12 = (nint)transform3 >= items.Length;
			PizzaCircle pizzaCircle = items[(object)transform3];
			bool flag13 = (object)items[(object)transform3] == null;
			bool flag14 = pizzaCircle._circle == null;
			if (pizzaCircle._circle.Contains(vector))
			{
				_pizzaTriggered = true;
				GameManager core3 = GM.Core;
				bool flag15 = (object)GM.Core == null;
				bool flag16 = (object)core3._stage == null;
				core3._stage.ShowPizzaWarning(items[(object)transform3]);
				Transform transform4 = items[(object)transform3].transform;
				bool flag17 = (object)transform4 == null;
				if (!(10.24f > transform4.position.x))
				{
					GameManager core4 = GM.Core;
					bool flag18 = (object)GM.Core == null;
					bool flag19 = (object)core4._stage == null;
					core4._stage.SpawnBoss();
				}
				else
				{
					bool flag20 = (object)GM.Core == null;
					GM.Core.MakeGem(vector, 5f);
					GameManager core5 = GM.Core;
					bool flag21 = (object)GM.Core == null;
					bool flag22 = (object)core5._stage == null;
					core5._stage.DebugNextMinute();
				}
			}
			transform3 = (Transform)(transform3 + 1);
			core = GM.Core;
			bool flag23 = (object)GM.Core == null;
			transform2 = transform3;
		}
	}

	private void MakeBlitters()
	{
		//IL_0472: Expected O, but got I4
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fef: Expected I4, but got Unknown
		//IL_1018: Expected O, but got F4
		//IL_1408: Expected O, but got F4
		//IL_0504: Expected O, but got F4
		//IL_051b: Expected O, but got I8
		//IL_1056: Expected O, but got F4
		//IL_1081: Expected O, but got F4
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Expected O, but got Unknown
		//IL_06da: Expected F4, but got I
		//IL_0700: Expected O, but got I4
		//IL_10b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bc: Expected I4, but got Unknown
		//IL_10e5: Expected O, but got F4
		//IL_145e: Expected O, but got F4
		//IL_0792: Expected O, but got F4
		//IL_1123: Expected O, but got F4
		//IL_114e: Expected O, but got F4
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Expected O, but got Unknown
		//IL_0950: Expected F4, but got I
		//IL_0976: Expected O, but got I4
		//IL_1184: Unknown result type (might be due to invalid IL or missing references)
		//IL_1189: Expected I4, but got Unknown
		//IL_11b2: Expected O, but got F4
		//IL_14b4: Expected O, but got F4
		//IL_09fb: Expected O, but got F4
		//IL_11f0: Expected O, but got F4
		//IL_1218: Invalid comparison between F4 and O
		//IL_123a: Expected O, but got I4
		//IL_1249: Unknown result type (might be due to invalid IL or missing references)
		//IL_124e: Expected O, but got Unknown
		//IL_1257: Unknown result type (might be due to invalid IL or missing references)
		//IL_125c: Expected O, but got Unknown
		//IL_0a13: Invalid comparison between O and F4
		//IL_0c06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0b: Expected O, but got Unknown
		//IL_0c20: Expected F4, but got I
		//IL_0c46: Expected O, but got I4
		//IL_12b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ba: Expected I4, but got Unknown
		//IL_12e3: Expected O, but got F4
		//IL_150a: Expected O, but got F4
		//IL_0ccb: Expected O, but got F4
		//IL_1321: Expected O, but got F4
		//IL_1349: Invalid comparison between F4 and O
		//IL_136b: Expected O, but got I4
		//IL_137a: Unknown result type (might be due to invalid IL or missing references)
		//IL_137f: Expected O, but got Unknown
		//IL_1388: Unknown result type (might be due to invalid IL or missing references)
		//IL_138d: Expected O, but got Unknown
		//IL_0ce3: Invalid comparison between O and F4
		//IL_0ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edb: Expected O, but got Unknown
		//IL_0ef0: Expected F4, but got I
		//IL_0f46: Expected O, but got I
		//IL_03f8->IL0f75: Incompatible stack heights: 1 vs 0
		//IL_041f->IL0f75: Incompatible stack heights: 1 vs 0
		//IL_0455->IL0f75: Incompatible stack heights: 1 vs 0
		//IL_04a1->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_04c0->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_1450->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_1073->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_109e->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_05bc->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_060d->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_065e->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_06b2->IL0f75: Incompatible stack heights: 2 vs 0
		//IL_06f2->IL10a3: Incompatible stack heights: 2 vs 1
		//IL_072f->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_074e->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_14a6->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_1140->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_116b->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_0832->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_0883->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_08d4->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_0928->IL0f75: Incompatible stack heights: 3 vs 0
		//IL_0968->IL1170: Incompatible stack heights: 3 vs 2
		//IL_09a5->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_09c4->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_14fc->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_129c->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0aa6->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0b02->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0b53->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0ba4->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0bf8->IL0f75: Incompatible stack heights: 4 vs 0
		//IL_0c38->IL12a1: Incompatible stack heights: 4 vs 3
		//IL_0c75->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0c94->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_1552->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_13cd->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0d76->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0dd2->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0e23->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0e74->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0ec8->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0f08->IL13d2: Incompatible stack heights: 5 vs 4
		//IL_0f31->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_0f66->IL0f75: Incompatible stack heights: 5 vs 0
		//IL_13ff->IL13ff: Incompatible stack heights: 6 vs 2
		if ((object)GM.Core != null)
		{
			Vector2 vector = default(Vector2);
			Blitter blitter = GM.Core.CreateBlitter(vector, "Boss Rash Crowd Blitter");
			_blitter = blitter;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._playerOptions != null)
			{
				PlayerOptionsData config = core._playerOptions.Config;
				if (config != null)
				{
					List<Sprite> list2;
					string textureName;
					string spriteName;
					if (!config._003CSelectedInverse_003Ek__BackingField)
					{
						List<Sprite> list = new List<Sprite>();
						Sprite sprite = SpriteManager.GetSprite("stklAntonio_0", "enemies3");
						if (list == null)
						{
							goto IL_0f75;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite2 = SpriteManager.GetSprite("stklArca_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite3 = SpriteManager.GetSprite("stklChristine_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite4 = SpriteManager.GetSprite("stklConcetta_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite5 = SpriteManager.GetSprite("stklDommario_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite6 = SpriteManager.GetSprite("stklGennaro_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite7 = SpriteManager.GetSprite("stklGiovanna_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite8 = SpriteManager.GetSprite("stklImelda_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite9 = SpriteManager.GetSprite("stklKrochi_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite10 = SpriteManager.GetSprite("stklLama_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite11 = SpriteManager.GetSprite("stklOld3_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite12 = SpriteManager.GetSprite("stklPasqualina_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite13 = SpriteManager.GetSprite("stklPoppea_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite14 = SpriteManager.GetSprite("stklPorta_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						Sprite sprite15 = SpriteManager.GetSprite("stklPugnala_0", "enemies3");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						list2 = list;
						textureName = "enemies3";
						spriteName = "stklSuora_0";
					}
					else
					{
						List<Sprite> list3 = new List<Sprite>();
						Sprite sprite16 = SpriteManager.GetSprite("Migno1_0", "enemies");
						if (list3 == null)
						{
							goto IL_0f75;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
						list2 = list3;
						textureName = "enemies";
						spriteName = "Werewolf1_0";
					}
					Sprite sprite17 = SpriteManager.GetSprite(spriteName, textureName);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
					bool flag = list2._size <= 0;
					Sprite[] items = list2._items;
					if (list2._items != null && (object)items[0] != null)
					{
						Texture2D texture = items[0].texture;
						if ((object)_blitter != null)
						{
							_blitter.SetAtlasTexture(texture);
							object obj = 0;
							while (true)
							{
								IL_0fdb:
								int num = obj % list2._size;
								bool flag2 = num >= list2._size;
								Sprite[] items2 = list2._items;
								if (list2._items == null || (object)_blitter == null)
								{
									break;
								}
								Bob bob = _blitter.CreateBob(vector, items2[num]);
								object obj2 = UnityEngine.Random.value;
								float num2 = (float)vector * 256f;
								float num3 = num2 + 320f;
								float num4 = num3 * 0.01f;
								while (true)
								{
									object obj3 = UnityEngine.Random.value;
									float num5 = (float)vector * 1024f;
									float num6 = num5 + 384f;
									float num7 = num6 * 0.01f;
									if (bob == null)
									{
										break;
									}
									BobData bobData = bob._bobData;
									bob._position = (float2)num4;
									bob._scale = (float2)3212836864L;
									_ = 1065353216;
									object obj4 = UnityEngine.Random.value;
									if (bob._bobData == null)
									{
										break;
									}
									float num8 = num7 - 0.5f;
									float num9 = (bobData._003CVx_003Ek__BackingField = num8 * 0.01f);
									BobData bobData2 = bob._bobData;
									object obj5 = UnityEngine.Random.value;
									if (bob._bobData == null)
									{
										break;
									}
									float num10 = num9 - 0.5f;
									float num11 = num10 * 0.01f;
									bobData2._003CVy_003Ek__BackingField = num11;
									BobData bobData3 = bob._bobData;
									if (bob._bobData == null)
									{
										break;
									}
									float num12 = (float)bob._position + 0.02f;
									bobData3._003CRight_003Ek__BackingField = num12;
									BobData bobData4 = bob._bobData;
									if (bob._bobData == null)
									{
										break;
									}
									float num13 = (float)bob._position - 0.02f;
									bobData4._003CLeft_003Ek__BackingField = num13;
									BobData bobData5 = bob._bobData;
									if (bob._bobData == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2056 @ rax_v73 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
									float num14 = 0f + 0.04f;
									bobData5._003CTop_003Ek__BackingField = num14;
									BobData bobData6 = bob._bobData;
									if (bob._bobData == null)
									{
										break;
									}
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2056 @ rax_v73 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
									bobData6._003CBottom_003Ek__BackingField = 0f;
									if ((nint)obj >= 500)
									{
										object obj6 = 0;
										while (true)
										{
											int num15 = obj6 % list2._size;
											bool flag3 = num15 >= list2._size;
											Sprite[] items3 = list2._items;
											if (list2._items == null || (object)_blitter == null)
											{
												break;
											}
											Bob bob2 = _blitter.CreateBob(vector, items3[num15]);
											object obj7 = UnityEngine.Random.value;
											float num16 = (float)vector * 256f;
											float num17 = num16 + 1440f;
											float num18 = num17 * 0.01f;
											object obj8 = UnityEngine.Random.value;
											float num19 = (float)vector * 1024f;
											float num20 = num19 + 384f;
											float num21 = num20 * 0.01f;
											if (bob2 == null)
											{
												break;
											}
											BobData bobData7 = bob2._bobData;
											bob2._position = (float2)num18;
											object obj9 = UnityEngine.Random.value;
											if (bob2._bobData == null)
											{
												break;
											}
											float num22 = num21 - 0.5f;
											float num23 = (bobData7._003CVx_003Ek__BackingField = num22 * 0.01f);
											BobData bobData8 = bob2._bobData;
											object obj10 = UnityEngine.Random.value;
											if (bob2._bobData == null)
											{
												break;
											}
											float num24 = num23 - 0.5f;
											float num25 = num24 * 0.01f;
											bobData8._003CVy_003Ek__BackingField = num25;
											BobData bobData9 = bob2._bobData;
											if (bob2._bobData == null)
											{
												break;
											}
											float num26 = (float)bob2._position + 0.02f;
											bobData9._003CRight_003Ek__BackingField = num26;
											BobData bobData10 = bob2._bobData;
											if (bob2._bobData == null)
											{
												break;
											}
											float num27 = (float)bob2._position - 0.02f;
											bobData10._003CLeft_003Ek__BackingField = num27;
											BobData bobData11 = bob2._bobData;
											if (bob2._bobData == null)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v96 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
											float num28 = 0f + 0.04f;
											bobData11._003CTop_003Ek__BackingField = num28;
											BobData bobData12 = bob2._bobData;
											if (bob2._bobData == null)
											{
												break;
											}
											obj6++;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2617 @ rax_v96 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
											bobData12._003CBottom_003Ek__BackingField = 0f;
											if ((nint)obj6 >= 500)
											{
												goto IL_096d;
											}
										}
										break;
									}
									goto IL_0fdb;
									IL_096d:
									object obj11 = 0;
									while (true)
									{
										int num29 = obj11 % list2._size;
										bool flag4 = num29 >= list2._size;
										Sprite[] items4 = list2._items;
										if (list2._items == null || (object)_blitter == null)
										{
											break;
										}
										Bob bob3 = _blitter.CreateBob(vector, items4[num29]);
										object obj12 = UnityEngine.Random.value;
										float num30 = (float)vector * 1408f;
										float num31 = num30 + 288f;
										float num32 = num31 * 0.01f;
										object obj13 = UnityEngine.Random.value;
										float num33 = (float)vector * 128f;
										float num34 = num33 + 384f;
										float num35 = num34 * 0.01f;
										if (bob3 == null)
										{
											break;
										}
										bob3._position = (float2)num32;
										object obj14 = UnityEngine.Random.value;
										bool flag5 = num35 < 0.5f;
										bool flag6 = !flag5;
										float2 position = bob3._position;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)8.32f) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position))
										{
											if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref bob3._position) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)16f))
											{
												flag6 = false;
											}
										}
										else
										{
											flag6 = true;
										}
										object obj15 = (flag6 ? 1 : 0) ^ 1;
										_ = 1065353216;
										object obj16 = obj15 * 2;
										float2 scale = (float2)(obj16 - 1);
										bob3._scale = scale;
										BobData bobData13 = bob3._bobData;
										float value = UnityEngine.Random.value;
										if (bob3._bobData == null)
										{
											break;
										}
										float num36 = value - 0.5f;
										float num37 = num36 * 0.01f;
										bobData13._003CVx_003Ek__BackingField = num37;
										BobData bobData14 = bob3._bobData;
										float value2 = UnityEngine.Random.value;
										if (bob3._bobData == null)
										{
											break;
										}
										float num38 = value2 - 0.5f;
										float num39 = num38 * 0.01f;
										bobData14._003CVy_003Ek__BackingField = num39;
										BobData bobData15 = bob3._bobData;
										if (bob3._bobData == null)
										{
											break;
										}
										float num40 = (float)bob3._position + 0.02f;
										bobData15._003CRight_003Ek__BackingField = num40;
										BobData bobData16 = bob3._bobData;
										if (bob3._bobData == null)
										{
											break;
										}
										float num41 = (float)bob3._position - 0.02f;
										bobData16._003CLeft_003Ek__BackingField = num41;
										BobData bobData17 = bob3._bobData;
										if (bob3._bobData == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2770 @ rax_v119 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
										float num42 = 0f + 0.04f;
										bobData17._003CTop_003Ek__BackingField = num42;
										BobData bobData18 = bob3._bobData;
										if (bob3._bobData == null)
										{
											break;
										}
										obj11++;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2770 @ rax_v119 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
										bobData18._003CBottom_003Ek__BackingField = 0f;
										if ((nint)obj11 >= 500)
										{
											goto IL_0c3d;
										}
									}
									break;
									IL_0f0d:
									string blitter2 = (string)(object)_blitter;
									if ((object)_blitter == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rbx_v34 (System.String)+30]");
									string text = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rbx_v34 (System.String)+30]");
									if ((nint)0 == 0)
									{
										break;
									}
									bool flag7 = text._stringLength == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
									continue;
									IL_0c3d:
									object obj17 = 0;
									while (true)
									{
										int num43 = obj17 % list2._size;
										bool flag8 = num43 >= list2._size;
										Sprite[] items5 = list2._items;
										if (list2._items == null || (object)_blitter == null)
										{
											break;
										}
										Bob bob4 = _blitter.CreateBob(vector, items5[num43]);
										object obj18 = UnityEngine.Random.value;
										float num44 = (float)vector * 1408f;
										float num45 = num44 + 320f;
										float num46 = num45 * 0.01f;
										object obj19 = UnityEngine.Random.value;
										float num47 = (float)vector * 128f;
										float num48 = num47 + 1424f;
										float num49 = num48 * 0.01f;
										if (bob4 == null)
										{
											break;
										}
										bob4._position = (float2)num46;
										object obj20 = UnityEngine.Random.value;
										bool flag9 = num49 < 0.5f;
										bool flag10 = !flag9;
										float2 position2 = bob4._position;
										if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)8.32f) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position2))
										{
											if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref bob4._position) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)16f))
											{
												flag10 = false;
											}
										}
										else
										{
											flag10 = true;
										}
										object obj21 = (flag10 ? 1 : 0) ^ 1;
										_ = 1065353216;
										object obj22 = obj21 * 2;
										float2 scale2 = (float2)(obj22 - 1);
										bob4._scale = scale2;
										BobData bobData19 = bob4._bobData;
										float value3 = UnityEngine.Random.value;
										if (bob4._bobData == null)
										{
											break;
										}
										float num50 = value3 - 0.5f;
										float num51 = num50 * 0.01f;
										bobData19._003CVx_003Ek__BackingField = num51;
										BobData bobData20 = bob4._bobData;
										float value4 = UnityEngine.Random.value;
										if (bob4._bobData == null)
										{
											break;
										}
										float num52 = value4 - 0.5f;
										float num53 = num52 * 0.01f;
										bobData20._003CVy_003Ek__BackingField = num53;
										BobData bobData21 = bob4._bobData;
										if (bob4._bobData == null)
										{
											break;
										}
										float num54 = (float)bob4._position + 0.02f;
										bobData21._003CRight_003Ek__BackingField = num54;
										BobData bobData22 = bob4._bobData;
										if (bob4._bobData == null)
										{
											break;
										}
										float num55 = (float)bob4._position - 0.02f;
										bobData22._003CLeft_003Ek__BackingField = num55;
										BobData bobData23 = bob4._bobData;
										if (bob4._bobData == null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2958 @ rax_v145 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
										float num56 = 0f + 0.04f;
										bobData23._003CTop_003Ek__BackingField = num56;
										BobData bobData24 = bob4._bobData;
										if (bob4._bobData == null)
										{
											break;
										}
										obj17++;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2958 @ rax_v145 (VampireSurvivors.Graphics.Blitters.Bob)+14]");
										bobData24._003CBottom_003Ek__BackingField = 0f;
										if ((nint)obj17 >= 500)
										{
											goto IL_0f0d;
										}
									}
									break;
								}
								break;
							}
						}
					}
				}
			}
		}
		goto IL_0f75;
		IL_0f75:
		throw new NullReferenceException();
	}

	private unsafe void UpdateBlitter()
	{
		//IL_003c: Expected O, but got I4
		//IL_0044: Expected O, but got Ref
		List<Bob>.Enumerator enumerator = default(List<Bob>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<Bob>.Enumerator enumerator2 = (List<Bob>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}
}
