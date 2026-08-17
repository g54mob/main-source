using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Jiangshi_Character : CharacterController
{
	private SpriteRenderer _sparkSprite;

	private SpriteRenderer _ringSprite;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private int _firingIndex;

	private int jumpsCounter;

	private int jumpsTrigger = 13;

	public override bool DrainWeaponsImmunity => true;

	protected unsafe override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		Action<string> frameKey = delegate(string text)
		{
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CAB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
			{
				object obj = "TP_JiangShi_i04";
				if ((object)text != "TP_JiangShi_i04")
				{
					if (text == null || "TP_JiangShi_i04" == null)
					{
						return;
					}
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v3+10]");
					if ((nint)stringLength != 0)
					{
						return;
					}
					ref byte first = ref *(byte*)(text + 20);
					ulong length = (ulong)(text._stringLength + text._stringLength);
					if (!System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("TP_JiangShi_i04" + 20), length))
					{
						return;
					}
				}
				if (++jumpsCounter % jumpsTrigger == 0)
				{
					FireWeapons();
				}
			}
		};
		((TP_Jiangshi_Character)(object)_spriteAnimation)._003CMakeLevelOne_003Eb__9_0((string)(object)frameKey);
		SpriteRenderer sparkSprite = _sparkSprite;
		Vector2 pos = default(Vector2);
		if ((object)_sparkSprite == null || ((UnityEngine.Object)sparkSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float5 = base.cachedPosition;
			GameObject gameObject = base.gameObject;
			SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "blurredSharpStar");
			SpriteRenderer component = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)spriteRenderer2).SetMaterial(material);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int sortingOrder = default(int);
			spriteRenderer2.sortingOrder = sortingOrder;
			_sparkSprite = spriteRenderer2;
		}
		SpriteRenderer ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			float2 float6 = base.cachedPosition;
			GameObject gameObject2 = base.gameObject;
			SpriteRenderer spriteRenderer3 = RenderingExtensions.AddSprite(gameObject2, pos, "vfx", "sPFX_ring_64");
			SpriteRenderer component2 = RenderingExtensions.SetAlpha(spriteRenderer3, 0f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(component2, 0f);
			Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
			((Renderer)spriteRenderer4).SetMaterial(material2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			int sortingOrder2 = default(int);
			spriteRenderer4.sortingOrder = sortingOrder2;
			_ringSprite = spriteRenderer4;
		}
	}

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		UpdateWalkRate();
	}

	private unsafe void PlaySparkle()
	{
		//IL_0070: Expected I, but got O
		//IL_00c8: Expected I, but got O
		//IL_012c: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		//IL_0156: Expected O, but got I4
		//IL_0229: Expected I, but got O
		//IL_0281: Expected I, but got O
		//IL_02d7: Expected O, but got I4
		//IL_02e5: Expected O, but got I4
		//IL_02f3: Expected O, but got I4
		//IL_031d: Expected O, but got I4
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		Transform transform = _ringSprite.transform;
		if ((object)transform != null)
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
		if ((object)_ringSprite != null)
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
		tweenConfig.duration = 250f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		Transform transform2 = _sparkSprite.transform;
		if ((object)transform2 != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sparkSprite != null)
		{
			nint num4 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.scaleX = (float?)(object)1;
		tweenConfig2.scaleY = (float?)(object)1;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = 250f;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.angle = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			//IL_0053: Expected O, but got Ref
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
			Transform transform3 = _sparkSprite.transform;
			object obj5 = default(object);
			transform3.localEulerAngles = (Vector3)(&obj5);
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onUpdate = delegate
		{
			Transform cachedTransform = base._cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)_sparkSprite == null;
			Transform transform3 = _sparkSprite.transform;
			bool flag3 = (object)transform3 == null;
			bool flag4 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
			bool flag5 = (object)_ringSprite == null;
			Transform transform4 = _ringSprite.transform;
			bool flag6 = (object)transform4 == null;
			bool flag7 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value2);
		};
		tweenConfig2.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig2);
		_sparkTween = sparkTween;
	}

	private unsafe void FireWeapons()
	{
		//IL_030a: Expected O, but got Ref
		//IL_0042: Expected O, but got I4
		//IL_01e9->IL024d: Incompatible stack heights: 1 vs 0
		//IL_038f->IL024c: Incompatible stack heights: 1 vs 0
		List<Weapon> list = new List<Weapon>();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		if ((object)base._weaponsManager != null)
		{
			List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField;
			if (((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
			{
				List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj = 0;
				}
				bool flag = list == null;
				List<Weapon> list3 = (List<Weapon>)(&enumerator);
				if (!flag)
				{
					if (list._size == 0)
					{
						return;
					}
					int num = (_firingIndex = UnityEngine.Random.RandomRangeInt(0, list._size));
					bool flag2 = num >= list._size;
					Weapon[] items = list._items;
					bool flag3 = list._items == null;
					list3 = null;
					if (!flag3)
					{
						Weapon weapon = items[num];
						if ((object)items[num] != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
						{
							items[num].Fire();
						}
						PlaySparkle();
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void UpdateWalkRate()
	{
		//IL_0161: Invalid comparison between O and F4
		//IL_0170: Expected O, but got I4
		//IL_0191: Invalid comparison between O and F4
		//IL_0127: Expected O, but got I4
		//IL_003c: Expected O, but got I4
		//IL_0139: Expected I4, but got O
		//IL_0054: Invalid comparison between O and F4
		//IL_0119: Expected O, but got I4
		//IL_007e: Invalid comparison between O and F4
		//IL_010b: Expected O, but got I4
		//IL_00a8: Invalid comparison between O and F4
		//IL_00fd: Expected O, but got I4
		//IL_00d2: Invalid comparison between O and F4
		//IL_00ef: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CA9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		float num = base.PMoveSpeed();
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.7f);
		object obj2 = 4;
		if (!flag)
		{
			obj2 = 10;
		}
		float num2 = base.PMoveSpeed();
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.6f))
		{
			float num3 = base.PMoveSpeed();
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.5f))
			{
				float num4 = base.PMoveSpeed();
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.4f))
				{
					float num5 = base.PMoveSpeed();
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.3f))
					{
						float num6 = base.PMoveSpeed();
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1.2f))
						{
							obj2 = 5;
						}
					}
					else
					{
						obj2 = 6;
					}
				}
				else
				{
					obj2 = 7;
				}
			}
			else
			{
				obj2 = 8;
			}
		}
		else
		{
			obj2 = 9;
		}
		int frameRate = (int)(obj2 + obj2);
		_spriteAnimation.Play("walk", frameRate);
	}

	public unsafe override void LevelUp()
	{
		base.LevelUp();
		UpdateWalkRate();
		Action action = UpdateWalkRate;
		action._002Ector(this, (nint)__ldftn(TP_Jiangshi_Character.UpdateWalkRate));
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void _003CMakeLevelOne_003Eb__9_0(string frameKey)
	{
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Ref, but got Unknown
		//IL_00fd: Expected I8, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5CAB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (base._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		object obj = "TP_JiangShi_i04";
		if ((object)frameKey != "TP_JiangShi_i04")
		{
			if (frameKey == null || "TP_JiangShi_i04" == null)
			{
				return;
			}
			int stringLength = frameKey._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rdx_v3+10]");
			if ((nint)stringLength != 0)
			{
				return;
			}
			ref byte first = ref *(byte*)(frameKey + 20);
			ulong length = (ulong)(frameKey._stringLength + frameKey._stringLength);
			if (!System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("TP_JiangShi_i04" + 20), length))
			{
				return;
			}
		}
		if (++jumpsCounter % jumpsTrigger == 0)
		{
			FireWeapons();
		}
	}

	private void _003CPlaySparkle_003Eb__11_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_ringSprite, 1f);
	}

	private unsafe void _003CPlaySparkle_003Eb__11_1()
	{
		//IL_0053: Expected O, but got Ref
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_sparkSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__11_2()
	{
		Transform cachedTransform = base._cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		bool flag2 = (object)_sparkSprite == null;
		Transform transform = _sparkSprite.transform;
		bool flag3 = (object)transform == null;
		bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag5 = (object)_ringSprite == null;
		Transform transform2 = _ringSprite.transform;
		bool flag6 = (object)transform2 == null;
		bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
	}

	private void _003CPlaySparkle_003Eb__11_3()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ringSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_sparkSprite, 0f);
	}
}
