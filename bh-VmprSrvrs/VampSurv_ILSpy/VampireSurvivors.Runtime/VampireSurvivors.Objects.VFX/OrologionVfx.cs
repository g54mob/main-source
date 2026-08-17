using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.VFX;

public class OrologionVfx : PoolableMonoBehaviour
{
	private SpriteRenderer _ScreenFillRenderer;

	private SpriteRenderer _ShockwaveRenderer;

	private float _worldScreenHeight;

	private float _worldScreenWidth;

	private Transform _originalParent;

	private void Awake()
	{
	}

	public void SetParent(Transform newParent)
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		_originalParent = parent;
		Transform transform2 = base.transform;
		transform2.SetParent(newParent, worldPositionStays: true);
	}

	public void Play()
	{
		//IL_001c: Expected O, but got I4
		Init();
		PerformScreenFill();
		PerformShockwave();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 2f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Orologion, soundConfig, 500f, 5, time);
	}

	private void Init()
	{
		//IL_0236: Expected O, but got I4
		//IL_0328: Expected O, but got I4
		Camera main = Camera.main;
		if ((object)main != null && ((UnityEngine.Object)main).m_CachedPtr != (IntPtr)0)
		{
			Camera main2 = Camera.main;
			if ((object)main2 == null)
			{
				goto IL_01b5;
			}
			float orthographicSize = main2.orthographicSize;
			float num = (_worldScreenHeight = orthographicSize + orthographicSize);
			Camera camera = (Camera)Screen.height;
			object obj = Screen.width;
			float num2 = num / (float)camera;
			float worldScreenWidth = (float)obj * num2;
			_worldScreenWidth = worldScreenWidth;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tweenerCore != null)
		{
			TweenExtensions.Complete(tweenerCore, withCallbacks: false);
			TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_ShockwaveRenderer, 1f, 0f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore2 != null)
			{
				TweenExtensions.Complete(tweenerCore2, withCallbacks: false);
				if ((object)_ShockwaveRenderer != null)
				{
					Transform transform = _ShockwaveRenderer.transform;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Quaternion value2 = default(Quaternion);
					Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
					Camera shockwaveRenderer = (Camera)(object)_ShockwaveRenderer;
					bool flag3 = (object)_ShockwaveRenderer == null;
					bool flag4 = ((UnityEngine.Object)shockwaveRenderer).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)shockwaveRenderer).m_CachedPtr, 1000);
					Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
					bool flag5 = (object)_ScreenFillRenderer == null;
					((Renderer)_ScreenFillRenderer).SetMaterial(material);
					return;
				}
			}
		}
		goto IL_01b5;
		IL_01b5:
		throw new NullReferenceException();
	}

	private unsafe void PerformScreenFill()
	{
		//IL_015f: Expected F4, but got I
		//IL_024c: Expected F4, but got I
		//IL_0361: Expected F4, but got I
		//IL_0168->IL0168: Incompatible stack heights: 11 vs 10
		//IL_0273->IL02ae: Incompatible stack heights: 11 vs 10
		SpriteRenderer screenFillRenderer = _ScreenFillRenderer;
		bool flag = ((UnityEngine.Object)screenFillRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.get_color_Injected(((UnityEngine.Object)screenFillRenderer).m_CachedPtr, out Color ret);
		SpriteRenderer screenFillRenderer2 = _ScreenFillRenderer;
		bool flag2 = (object)_ScreenFillRenderer == null;
		bool flag3 = ((UnityEngine.Object)screenFillRenderer2).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)screenFillRenderer2).m_CachedPtr, ref value);
		bool flag4 = (object)_ScreenFillRenderer == null;
		Sprite sprite = _ScreenFillRenderer.sprite;
		bool flag5 = (object)_ScreenFillRenderer == null;
		Transform transform = _ScreenFillRenderer.transform;
		bool flag6 = (object)sprite == null;
		bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Bounds*)(&ret));
		bool flag8 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
		Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Bounds _);
		bool flag9 = (object)transform == null;
		bool flag10 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0.2f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1186 @ rax_v58 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
		{
			bool flag11 = sequence == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v57 (DG.Tweening.Sequence)+A0]");
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)tweenerCore, 0f);
		}
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 9.5f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_ScreenFillRenderer, 0f, 0.5f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ rax_v63 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		TweenCallback tweenCallback2;
		object message;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore2, false))
		{
			bool flag12 = sequence == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v57 (DG.Tweening.Sequence)+A0]");
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)tweenerCore2, 0f);
			TweenCallback tweenCallback = Cleanup;
			tweenCallback2 = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback3 = Cleanup;
			bool flag13 = sequence == null;
			tweenCallback2 = tweenCallback3;
			if (flag13)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to a NULL Sequence";
				goto IL_05b4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v57 (DG.Tweening.Sequence)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v57 (DG.Tweening.Sequence)+100]");
			if ((nint)0 == 0)
			{
				if (tweenCallback2 != null)
				{
					TweenCallback callback = tweenCallback2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1183 @ rax_v57 (DG.Tweening.Sequence)+A0]");
					Sequence sequence5 = Sequence.DoInsertCallback(sequence, callback, 0f);
				}
				goto IL_03d0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_05b4;
		IL_03d0:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag14 = sequence == null;
		return;
		IL_05b4:
		Debugger.LogWarning(message);
		goto IL_03d0;
	}

	private unsafe void PerformShockwave()
	{
		//IL_009e: Expected O, but got Ref
		//IL_047d: Expected O, but got Ref
		//IL_0466->IL0325: Incompatible stack heights: 7 vs 0
		//IL_04b6->IL0325: Incompatible stack heights: 7 vs 0
		if ((object)_ShockwaveRenderer != null)
		{
			Sprite sprite = _ShockwaveRenderer.sprite;
			if ((object)_ShockwaveRenderer != null)
			{
				Transform transform = _ShockwaveRenderer.transform;
				if ((object)sprite != null)
				{
					if (((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
					{
						Vector3 ret;
						Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Bounds*)(&ret));
						bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Bounds ret2);
						bool flag2 = (object)transform == null;
						bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
						bool flag4 = (object)_ShockwaveRenderer == null;
						Transform target = _ShockwaveRenderer.transform;
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&ret), 1f, RotateMode.FastBeyond360);
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 1;
								_ = 0;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
								if ((nint)0 == 0)
								{
									_ = 4294967295L;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
									if ((nint)0 == 0)
									{
										_ = 2139095040;
									}
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag5 = tweenerCore == null;
						TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_ShockwaveRenderer, 0f, 1f);
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(t, 9f);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ rax_v48 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 != 0)
							{
								_ = 1;
								_ = 0;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag6 = tweenerCore2 == null;
						bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
						Sprite.get_bounds_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out ret2);
						if ((object)_ShockwaveRenderer != null)
						{
							Transform target2 = _ShockwaveRenderer.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target2, (Vector3)(&ret), 0.2f);
							if (tweenerCore3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1405 @ rax_v60 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									_ = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore3 != null)
							{
								return;
							}
						}
					}
					else
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(sprite);
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Cleanup()
	{
		float optionalFloat = default(float);
		object optionalObj = default(object);
		object[] optionalArray = default(object[]);
		if ((object)_ScreenFillRenderer != null)
		{
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)_ScreenFillRenderer, false, optionalFloat, optionalObj, optionalArray);
		}
		if ((object)_ShockwaveRenderer != null)
		{
			int num2 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)_ShockwaveRenderer, false, optionalFloat, optionalObj, optionalArray);
		}
		Transform transform = _ShockwaveRenderer.transform;
		if ((object)transform != null)
		{
			int num3 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, optionalFloat, optionalObj, optionalArray);
		}
		Transform transform2 = base.transform;
		transform2.SetParent(_originalParent, worldPositionStays: true);
		GameObject obj = base.gameObject;
		base._parentPool.Release(obj);
	}

	private void ResetParent()
	{
		Transform transform = base.transform;
		transform.SetParent(_originalParent, worldPositionStays: true);
	}

	public OrologionVfx()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
