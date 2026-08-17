using System;
using Cpp2ILInjected;
using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.VFX;

public class SpellcastingCursorVFX : PoolableMonoBehaviour
{
	private Transform _originalParent;

	private PhaserSprite _cursor;

	private MultiTargetTween _cursorTween;

	private PhaserSprite _cursorAdd;

	private MultiTargetTween _cursorAddTween;

	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite cursor = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Fire18");
		_cursor = cursor;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Fire18");
		PhaserSprite cursorAdd = phaserSprite.setBlendMode(BlendMode.Add);
		_cursorAdd = cursorAdd;
		PhaserSprite phaserSprite2 = _cursor.setDepth(1);
		PhaserSprite phaserSprite3 = _cursorAdd.setDepth(2);
	}

	public void SetParent(Transform newParent)
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		_originalParent = parent;
		Transform transform2 = base.transform;
		transform2.SetParent(newParent, worldPositionStays: true);
	}

	public unsafe void Display(int _times, float _duration, Vector3 position, float angle, string texture, string frame, bool flip = false)
	{
		//IL_009e: Expected O, but got Ref
		//IL_0137: Expected O, but got Ref
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_0257: Expected I, but got O
		//IL_02ca: Expected O, but got I4
		//IL_0301: Expected O, but got I4
		//IL_0419: Expected I, but got O
		//IL_047f: Expected O, but got I4
		//IL_04b6: Expected O, but got I4
		//IL_0571->IL051b: Incompatible stack heights: 1 vs 0
		//IL_027a->IL027a: Incompatible stack heights: 3 vs 2
		//IL_043c->IL043c: Incompatible stack heights: 5 vs 4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		float num;
		if ((object)_cursor != null)
		{
			Sprite frame2 = default(Sprite);
			PhaserSprite phaserSprite = _cursor.setFrame(frame2);
			if ((object)_cursor != null)
			{
				Transform transform = _cursor.transform;
				if ((object)transform != null)
				{
					object obj = default(object);
					transform.localEulerAngles = (Vector3)(&obj);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
					if ((object)_cursorAdd != null)
					{
						Sprite frame3 = default(Sprite);
						PhaserSprite phaserSprite2 = _cursorAdd.setFrame(frame3);
						if ((object)_cursorAdd != null)
						{
							Transform transform2 = _cursorAdd.transform;
							if ((object)transform2 != null)
							{
								transform2.localEulerAngles = (Vector3)(&obj);
								Transform transform3 = base.transform;
								if ((object)transform3 != null)
								{
									bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									float value = default(float);
									Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value));
									if ((object)_cursor != null)
									{
										bool flipX = default(bool);
										PhaserSprite phaserSprite3 = _cursor.setFlipX(flipX);
										if (!(250f > _duration))
										{
											object obj2 = _duration & -2147483649L;
											bool flag2 = (nint)obj2 <= 2139095040;
											num = 250f;
											if (flag2)
											{
												goto IL_0576;
											}
										}
										num = _duration;
										goto IL_0576;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0576:
		float repeatDelay = _duration - num;
		if (_cursorTween != null)
		{
			_cursorTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		bool flag3 = array == null;
		if ((object)_cursor != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag4 = obj3 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag5 = tweenConfig == null;
		tweenConfig.targets = array;
		tweenConfig.repeatDelay = repeatDelay;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = num;
		tweenConfig.yoyo = true;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.scale = (float?)(object)1;
		int repeat = _times + 1;
		tweenConfig.repeat = repeat;
		TweenCallback onStart = delegate
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite4 = _cursor.setAlpha(0.65f);
			PhaserSprite phaserSprite5 = _cursor.setScale(1f, (float?)(object)0);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = StartDespawn;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween cursorTween = Tweens.Add(tweenConfig);
		_cursorTween = cursorTween;
		if (_cursorAddTween != null)
		{
			_cursorAddTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		bool flag6 = array2 == null;
		if ((object)_cursorAdd != null)
		{
			nint num3 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag7 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		bool flag8 = tweenConfig2 == null;
		tweenConfig2.targets = array2;
		tweenConfig2.alpha = (float?)(object)1;
		tweenConfig2.duration = _duration;
		tweenConfig2.yoyo = true;
		tweenConfig2.ease = Ease.InOutSine;
		tweenConfig2.scale = (float?)(object)1;
		int repeat2 = _times + 1;
		tweenConfig2.repeat = repeat2;
		TweenCallback onStart2 = delegate
		{
			//IL_002e: Expected O, but got I4
			PhaserSprite phaserSprite4 = _cursorAdd.setAlpha(0f);
			PhaserSprite phaserSprite5 = _cursorAdd.setScale(1f, (float?)(object)0);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween cursorAddTween = Tweens.Add(tweenConfig2);
		_cursorAddTween = cursorAddTween;
	}

	private void StartDespawn()
	{
		//IL_008d: Expected I, but got O
		//IL_00e5: Expected I, but got O
		//IL_0149: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		if (_cursorTween != null)
		{
			_cursorTween.Kill();
		}
		if (_cursorAddTween != null)
		{
			_cursorAddTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_cursor != null)
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
		if ((object)_cursorAdd != null)
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
		TweenCallback onComplete = Cleanup;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween cursorTween = Tweens.Add(tweenConfig);
		_cursorTween = cursorTween;
	}

	private void Cleanup()
	{
		PhaserSprite phaserSprite = _cursor.setAlpha(0f);
		PhaserSprite phaserSprite2 = _cursorAdd.setAlpha(0f);
		_cursorTween.Kill();
		_cursorAddTween.Kill();
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private void ResetParent()
	{
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
	}

	public SpellcastingCursorVFX()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CDisplay_003Eb__7_0()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _cursor.setAlpha(0.65f);
		PhaserSprite phaserSprite2 = _cursor.setScale(1f, (float?)(object)0);
	}

	private void _003CDisplay_003Eb__7_1()
	{
		//IL_002e: Expected O, but got I4
		PhaserSprite phaserSprite = _cursorAdd.setAlpha(0f);
		PhaserSprite phaserSprite2 = _cursorAdd.setScale(1f, (float?)(object)0);
	}
}
