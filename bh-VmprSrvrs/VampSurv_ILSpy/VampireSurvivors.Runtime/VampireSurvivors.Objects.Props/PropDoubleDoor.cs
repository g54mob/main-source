using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Objects.Props;

public class PropDoubleDoor : Destructible
{
	private Stage _stage;

	private bool _hasFired;

	private GameObject _PizzaCircleObj;

	public PizzaCircle PizzaCircle;

	private MultiTargetTween _tween1;

	private Timer _selfCleanTimer;

	private bool hasSprites;

	private PhaserSprite _leftSprite;

	private PhaserSprite _rightSprite;

	private SuperObject _SuperObject;

	private SuperCustomProperties _SuperCustomProperties;

	private int _wallWidth;

	private int _wallHeight;

	private void Construct(Stage stage)
	{
		_stage = stage;
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
	}

	protected override void SetupAnimations()
	{
		_spriteAnimation.CleanAnimations();
	}

	public unsafe override void Init(PropType destructibleType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_016b: Expected O, but got I
		//IL_0d27: Expected O, but got Ref
		//IL_041a: Expected O, but got Ref
		//IL_0428: Expected O, but got Ref
		//IL_0c37: Expected O, but got Ref
		//IL_029b: Expected O, but got I
		//IL_0c8e: Expected O, but got Ref
		//IL_0651: Expected O, but got I4
		//IL_06a2: Expected O, but got I
		//IL_0778: Expected F4, but got I4
		//IL_085c: Expected F4, but got I4
		//IL_0b25: Expected F4, but got I
		//IL_004c->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_00e7->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_0ce7->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_014a->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_0189->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_035a->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_01b5->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_0da3->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0395->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_01fa->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_0407->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0217->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_048b->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_027a->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_04d2->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_02b9->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_04ff->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_03cd->IL04d7: Incompatible stack heights: 5 vs 2
		//IL_02e5->IL0b63: Incompatible stack heights: 1 vs 0
		//IL_0532->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_056f->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_058e->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_05d8->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_05f7->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0637->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0681->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_06c0->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_06ec->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0d5b->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_073a->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_07a6->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_07d2->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0d7a->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0820->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0894->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_08b6->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_08f6->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0918->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_094e->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_097a->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0ae3->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_09c9->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0b3f->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0a51->IL0b63: Incompatible stack heights: 2 vs 0
		//IL_0a84->IL0b63: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Init(destructibleType);
		base._003CIsStationary_003Ek__BackingField = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
		_ = 0;
		BaseBody baseBody = body;
		float2 float5 = default(float2);
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
			bool flag = (nint)0 == 0;
			if (baseBody._transform != null)
			{
				baseBody._transform.setOrigin(float5);
				_hasFired = false;
				if (hasSprites)
				{
					goto IL_0300;
				}
				hasSprites = true;
				PhaserWorld instance = PhaserWorld.Instance;
				PropData propData = _propData;
				if (_propData != null && (object)instance != null)
				{
					PhaserSprite leftSprite = instance.AddPhaserSprite(float5, propData._003CtextureName_003Ek__BackingField, propData._003CframeName_003Ek__BackingField);
					_leftSprite = leftSprite;
					_ = 0;
					_ = 1065353216;
					_ = 1;
					if ((object)_leftSprite != null)
					{
						PhaserSprite leftSprite2 = _leftSprite;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
						PhaserSprite phaserSprite = leftSprite2.setOrigin(0f, (float?)(object)0);
						if ((object)_leftSprite != null)
						{
							GameObject gameObject = _leftSprite.gameObject;
							if ((object)gameObject != null)
							{
								((UnityEngine.Object)gameObject).SetName("PropDoubleDoor - LeftSprite");
								PhaserWorld instance2 = PhaserWorld.Instance;
								PropData propData2 = _propData;
								if (_propData != null && (object)instance2 != null)
								{
									PhaserSprite rightSprite = instance2.AddPhaserSprite(float5, propData2._003CtextureName_003Ek__BackingField, propData2._003CframeName_003Ek__BackingField);
									_rightSprite = rightSprite;
									_ = 0;
									_ = 1065353216;
									_ = 1;
									if ((object)_rightSprite != null)
									{
										PhaserSprite rightSprite2 = _rightSprite;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
										PhaserSprite phaserSprite2 = rightSprite2.setOrigin(0f, (float?)(object)0);
										if ((object)_rightSprite != null)
										{
											GameObject gameObject2 = _rightSprite.gameObject;
											if ((object)gameObject2 != null)
											{
												((UnityEngine.Object)gameObject2).SetName("PropDoubleDoor - RightSprite");
												goto IL_0300;
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
		goto IL_0b63;
		IL_04d7:
		PizzaCircle pizzaCircle;
		pizzaCircle.Init(32f);
		float num;
		if ((object)_leftSprite != null)
		{
			PhaserSprite phaserSprite3 = _leftSprite.setVisible(visible: true);
			if ((object)_rightSprite != null)
			{
				PhaserSprite phaserSprite4 = _rightSprite.setVisible(visible: true);
				PropData propData3 = _propData;
				if (_propData != null && (object)_leftSprite != null)
				{
					PhaserSprite phaserSprite5 = _leftSprite.setFrame(propData3._003CtextureName_003Ek__BackingField, propData3._003CframeName_003Ek__BackingField);
					PropData propData4 = _propData;
					if (_propData != null && (object)_rightSprite != null)
					{
						PhaserSprite phaserSprite6 = _rightSprite.setFrame(propData4._003CtextureName_003Ek__BackingField, propData4._003CframeName_003Ek__BackingField);
						if ((object)_leftSprite != null)
						{
							PhaserSprite phaserSprite7 = _leftSprite.setScale(1f, (float?)(object)0);
							_ = 0;
							_ = 1065353216;
							_ = 1;
							if ((object)_rightSprite != null)
							{
								PhaserSprite rightSprite3 = _rightSprite;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
								PhaserSprite phaserSprite8 = rightSprite3.setScale(-1f, (float?)(object)0);
								if (_playerOptions != null)
								{
									PlayerOptionsData config = _playerOptions.Config;
									if (config != null)
									{
										if (config._003CSelectedInverse_003Ek__BackingField)
										{
											PlayerOptionsData config2 = _playerOptions.Config;
											if (config2 == null)
											{
												goto IL_0b63;
											}
											if (config2._003CVisuallyInvertStages_003Ek__BackingField)
											{
												num = 180f;
												goto IL_0d41;
											}
										}
										num = 0f;
										goto IL_0d41;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b63;
		IL_0aa6:
		float2 float6 = base.position;
		float2 float7 = base.position;
		if ((object)_leftSprite != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float8 = base.position;
			float2 float9 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-5]");
			float num2 = 0f;
			if ((object)_rightSprite != null)
			{
				float2 float10 = float5;
				float2 float11 = float5;
				PhaserSprite rightSprite4 = _rightSprite;
				goto IL_0d7f;
			}
		}
		goto IL_0b63;
		IL_0d60:
		float num3;
		if ((object)_rightSprite != null)
		{
			_rightSprite.angle = num3;
			PhaserSprite leftSprite3 = _leftSprite;
			if ((object)_leftSprite != null && (object)leftSprite3._spriteRenderer != null)
			{
				Vector2 vector = leftSprite3._spriteRenderer.size;
				PhaserSprite rightSprite5 = _rightSprite;
				if ((object)_rightSprite != null && (object)rightSprite5._spriteRenderer != null)
				{
					Vector2 vector2 = rightSprite5._spriteRenderer.size;
					if (_playerOptions != null)
					{
						PlayerOptionsData config3 = _playerOptions.Config;
						if (config3 != null)
						{
							if (!config3._003CSelectedInverse_003Ek__BackingField)
							{
								goto IL_0aa6;
							}
							PlayerOptionsData config4 = _playerOptions.Config;
							if (config4 != null)
							{
								if (!config4._003CVisuallyInvertStages_003Ek__BackingField)
								{
									goto IL_0aa6;
								}
								float2 float12 = base.position;
								float2 float13 = base.position;
								float2 float14 = base.position;
								float2 float15 = base.position;
								if ((object)_leftSprite != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									PhaserSprite rightSprite4 = _rightSprite;
									if ((object)_rightSprite != null)
									{
										float2 float10 = float5;
										float num2 = num3;
										float2 float11 = float5;
										goto IL_0d7f;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b63;
		IL_0d7f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		return;
		IL_0b63:
		throw new NullReferenceException();
		IL_0d41:
		if ((object)_leftSprite != null)
		{
			_leftSprite.angle = num;
			if (_playerOptions != null)
			{
				PlayerOptionsData config5 = _playerOptions.Config;
				if (config5 != null)
				{
					if (config5._003CSelectedInverse_003Ek__BackingField)
					{
						PlayerOptionsData config6 = _playerOptions.Config;
						if (config6 == null)
						{
							goto IL_0b63;
						}
						bool flag2 = config6._003CVisuallyInvertStages_003Ek__BackingField;
						num3 = 180f;
						if (flag2)
						{
							goto IL_0d60;
						}
					}
					num3 = 0f;
					goto IL_0d60;
				}
			}
		}
		goto IL_0b63;
		IL_0300:
		string pizzaCircleObj = (string)(object)_PizzaCircleObj;
		if ((object)_PizzaCircleObj != null && pizzaCircleObj._stringLength != 0)
		{
			if ((object)PizzaCircle != null)
			{
				Transform transform = PizzaCircle.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					_ = 0;
					_ = 0;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)obj3);
					bool flag4 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
					_ = 0;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj4);
					pizzaCircle = PizzaCircle;
					bool flag6 = (object)PizzaCircle == null;
					goto IL_04d7;
				}
			}
		}
		else
		{
			Transform transform3 = base.transform;
			if ((object)transform3 != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v71 (UnityEngine.Transform)+10]");
				bool flag7 = (nint)0 == 0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v71 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj5);
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
				{
					ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
					if ((object)pool != null)
					{
						Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Vector3 vector3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
						_ = 0;
						_ = Quaternion.identityQuaternion;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
						_ = 0;
						GameObject pizzaCircleObj2 = pool.GetObject(vector3, rotation);
						_PizzaCircleObj = pizzaCircleObj2;
						if ((object)_PizzaCircleObj != null)
						{
							PizzaCircle component = _PizzaCircleObj.GetComponent<PizzaCircle>();
							PizzaCircle = component;
							pizzaCircle = PizzaCircle;
							if ((object)PizzaCircle != null)
							{
								goto IL_04d7;
							}
						}
					}
				}
			}
		}
		goto IL_0b63;
	}

	private void SelfClean()
	{
		//IL_010c: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					Vector3 vector = ret;
					Rect containmentScreenRect = stage._containmentScreenRect;
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentScreenRect))
					{
						object obj2 = default(object);
						object obj = obj2 + (object)stage._containmentScreenRect;
						object obj3 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							object obj4 = obj2 + obj2;
							bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							object obj5 = obj4 - obj3;
							bool flag3 = obj5 == null;
							bool flag4 = !flag2;
							bool flag5 = !flag3;
							object obj6 = flag5 & flag4;
							if (obj6 != null)
							{
								return;
							}
						}
					}
					Despawn();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _leftSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _rightSprite.setVisible(visible: false);
		if (_selfCleanTimer != null)
		{
			_selfCleanTimer.Cancel();
		}
		base.Despawn();
	}

	protected unsafe override void OnUpdate()
	{
		//IL_0135: Expected O, but got Ref
		base.OnUpdate();
		if (_hasFired)
		{
			return;
		}
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset = stage2._tilingTileset;
		if ((object)stage2._tilingTileset != null && ((UnityEngine.Object)tilingTileset).m_CachedPtr != (IntPtr)0)
		{
			GameManager core3 = GM.Core;
			Stage stage3 = core3._stage;
			BackgroundManager fancyBg = stage3._fancyBg;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
			if ((object)stage3._fancyBg != null && ((UnityEngine.Object)fancyBg).m_CachedPtr != (IntPtr)0 && enumerator.MoveNext())
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
		}
	}

	public override void OnDestructibleSpawned(SuperObject tiledScriptObject)
	{
		SuperCustomProperties component = tiledScriptObject.GetComponent<SuperCustomProperties>();
		_SuperObject = tiledScriptObject;
		_SuperCustomProperties = component;
		bool flag = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "wallHeight", out var property);
		bool flag2 = CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "wallWidth", out var property2);
		if (property2 != null && property != null)
		{
			int wallWidth = StringExtensions.ToInt(property2.m_Value);
			_wallWidth = wallWidth;
			int wallHeight = StringExtensions.ToInt(property.m_Value);
			_wallHeight = wallHeight;
		}
	}

	protected void OnTriggeredByPlayer()
	{
		//IL_0064: Expected O, but got I4
		//IL_0101: Expected I, but got O
		//IL_0159: Expected I, but got O
		//IL_01af: Expected O, but got I4
		//IL_01cb: Expected O, but got I4
		//IL_01e6: Expected I, but got O
		if (_hasFired)
		{
			return;
		}
		if (_selfCleanTimer != null)
		{
			_selfCleanTimer.Cancel();
		}
		_hasFired = true;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 2f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_leftSprite != null)
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
		if ((object)_rightSprite != null)
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
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.scaleY = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Props.PropDoubleDoor>)+330]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
	}

	protected unsafe void OpenWallTiles()
	{
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_05a6: Expected O, but got Ref
		//IL_0216: Expected I, but got O
		//IL_0224: Expected I, but got O
		//IL_0234: Expected O, but got I
		//IL_02b4: Expected O, but got I4
		//IL_0270: Expected O, but got I
		//IL_02a6: Expected O, but got I4
		//IL_051b: Expected O, but got F8
		//IL_0396: Expected O, but got I
		//IL_0550->IL0599: Incompatible stack heights: 1 vs 0
		//IL_0555->IL03a0: Incompatible stack heights: 1 vs 0
		SuperObject superObject = _SuperObject;
		Tilemap tilemapLayer;
		if ((object)_SuperObject != null)
		{
			SuperObject superObject2 = _SuperObject;
			if ((object)_SuperObject != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbp+150h]\"");
				float num = 0f * 0.5f;
				double num2 = Math.Floor(num);
				float num3 = superObject.m_X * (1f / 32f);
				double num4 = Math.Floor(num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbp+154h]\"");
				double num5 = num4 - num2;
				float num6 = 0f * 0.5f;
				double num7 = Math.Floor(num6);
				float num8 = superObject2.m_Y * (1f / 32f);
				double num9 = Math.Floor(num8);
				GameManager core = GM.Core;
				double num10 = num9 - num7;
				if ((object)GM.Core != null)
				{
					Stage stage = core._stage;
					if ((object)core._stage != null && (object)stage._tilingTileset != null)
					{
						tilemapLayer = stage._tilingTileset.GetTilemapLayer("Walls");
						Tilemap tilemap = tilemapLayer;
						if ((object)tilemapLayer == null || ((UnityEngine.Object)tilemapLayer).m_CachedPtr == (IntPtr)0)
						{
							return;
						}
						bool flag = _wallWidth <= 0;
						object obj = null;
						double num11 = num7;
						if (flag)
						{
							goto IL_03dc;
						}
						nint num13 = default(nint);
						double num14 = default(double);
						double num18 = default(double);
						while (true)
						{
							if (_wallHeight > 0)
							{
								double num12 = 0.0 - num10;
								num13 = num13;
								while (true)
								{
									TileBase tile = tilemapLayer.GetTile((Vector3Int)(&num14));
									object item;
									if ((object)tile == null)
									{
										item = null;
										goto IL_0480;
									}
									num13 = (nint)tile;
									nint num15 = (nint)typeof(SuperTile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rdx_v14 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v8 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+130]");
									nint num16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ rdx_v14 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
									object obj4;
									if (num16 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ r9_v8 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+C8]");
										object obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rax_v44+FFFFFFF8+v825 @ rax_v40*8]");
										if (0 == (nint)typeof(SuperTile))
										{
											obj4 = 1;
											goto IL_04a7;
										}
									}
									obj4 = 0;
									goto IL_04a7;
									IL_04a7:
									bool flag2 = obj4 == null;
									item = null;
									if (!flag2)
									{
										item = tile;
									}
									goto IL_0480;
									IL_0480:
									GameManager core2 = GM.Core;
									if ((object)GM.Core == null)
									{
										break;
									}
									Stage stage2 = core2._stage;
									if ((object)core2._stage == null)
									{
										break;
									}
									BackgroundManager fancyBg = stage2._fancyBg;
									if ((object)stage2._fancyBg == null || fancyBg.dynamicWallTiles == null)
									{
										break;
									}
									((Stack<object>)(object)fancyBg.dynamicWallTiles).Push(item);
									bool flag3 = ((UnityEngine.Object)tilemapLayer).m_CachedPtr == (IntPtr)0;
									nint num17 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rcx_v26 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										((Stack<SuperTile>)0).Push((SuperTile)item);
									}
									Tilemap.SetTileAsset_Injected(((UnityEngine.Object)tilemapLayer).m_CachedPtr, ref *(Vector3Int*)(&num18), (IntPtr)0);
									num11 = num12 + 1.0;
									tilemap = (Tilemap)(num11 + num10);
									bool flag4 = (nint)tilemap < _wallHeight;
									num14 = num5;
									num18 = num5;
									num14 = num5;
									if (flag4)
									{
										continue;
									}
									goto IL_03a0;
								}
								break;
							}
							goto IL_03a0;
							IL_03a0:
							obj++;
							num5++;
							if ((nint)obj < _wallWidth)
							{
								continue;
							}
							goto IL_03dc;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03dc:
		PhaserTilemap component = tilemapLayer.GetComponent<PhaserTilemap>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.RefreshData();
		}
	}

	protected unsafe void CloseWallTiles()
	{
		//IL_01a8: Expected F8, but got O
		//IL_01b1: Expected O, but got I4
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_01db: Expected O, but got I4
		//IL_0297: Expected O, but got Ref
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		Stack<SuperTile> dynamicWallTiles = fancyBg.dynamicWallTiles;
		if (dynamicWallTiles._size == 0)
		{
			return;
		}
		SuperObject superObject = _SuperObject;
		SuperObject superObject2 = _SuperObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rsi+150h]\"");
		float num = 0f * 0.5f;
		double num2 = Math.Floor(num);
		float num3 = superObject.m_X * (1f / 32f);
		double num4 = Math.Floor(num3);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rsi+154h]\"");
		double num5 = num4 - num2;
		float num6 = 0f * 0.5f;
		double num7 = Math.Floor(num6);
		float num8 = superObject2.m_Y * (1f / 32f);
		double num9 = Math.Floor(num8);
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		Tilemap tilemapLayer = stage2._tilingTileset.GetTilemapLayer("Walls");
		if ((object)tilemapLayer == null || ((UnityEngine.Object)tilemapLayer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		bool flag = _wallWidth <= 0;
		double num10 = (double)superObject2;
		object obj = 0;
		if (!flag)
		{
			double num11 = default(double);
			do
			{
				if (_wallHeight > 0)
				{
					num10 = (double)obj + num5;
					object obj2 = 0;
					bool flag2;
					do
					{
						GameManager core3 = GM.Core;
						Stage stage3 = core3._stage;
						BackgroundManager fancyBg2 = stage3._fancyBg;
						Stack<SuperTile> dynamicWallTiles2 = fancyBg2.dynamicWallTiles;
						if (dynamicWallTiles2._size == 0)
						{
							Debug.LogError("Not enough wall tiles to restore.");
						}
						GameManager core4 = GM.Core;
						Stage stage4 = core4._stage;
						BackgroundManager fancyBg3 = stage4._fancyBg;
						object tile = ((Stack<object>)(object)fancyBg3.dynamicWallTiles).Pop();
						tilemapLayer.SetTile((Vector3Int)(&num11), (TileBase)tile);
						obj2++;
						flag2 = (nint)obj2 < _wallHeight;
						num11 = num10;
						num11 = num10;
					}
					while (flag2);
				}
				obj++;
			}
			while ((nint)obj < _wallWidth);
		}
		PhaserTilemap component = tilemapLayer.GetComponent<PhaserTilemap>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			component.RefreshData();
		}
	}

	protected void SpawnEnemyWallColliders()
	{
		float2 float5 = base.position;
		float2 float6 = base.position;
	}

	public override bool DoesAllowVenting()
	{
		return false;
	}

	public PropDoubleDoor()
	{
		//IL_004c: Expected I, but got O
		_wallWidth = 3;
		_wallHeight = 2;
		_hp = 1f;
		base._maxHp = 1f;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
