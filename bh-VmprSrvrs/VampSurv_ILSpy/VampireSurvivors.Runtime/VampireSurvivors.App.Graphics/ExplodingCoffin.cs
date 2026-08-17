using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Tools;

namespace VampireSurvivors.App.Graphics;

public class ExplodingCoffin : MonoBehaviour
{
	private SpriteRenderer _lid;

	private SpriteRenderer _base;

	private Sequence _lidTween;

	public unsafe void Explode(Color lidColour)
	{
		//IL_0449: Expected O, but got I4
		//IL_0209: Expected O, but got Ref
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Lid, soundConfig, 150f, 2, time);
		SpriteRenderer lid = _lid;
		bool flag = ((UnityEngine.Object)lid).m_CachedPtr == (IntPtr)0;
		float ret = default(float);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)lid).m_CachedPtr, ref *(Color*)(&ret));
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		bool flag2 = (object)_lid == null;
		Transform transform = _lid.transform;
		bool flag3 = (object)transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v25 (UnityEngine.Transform)+10]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v25 (UnityEngine.Transform)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
		Sequence lidTween = DOTween.Sequence();
		_lidTween = lidTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rax_v24 (UnityEngine.Bounds)+10]");
		float num = 0f * 2f;
		float num2 = num * 0.75f;
		object obj = default(object);
		float endValue = num2 + (float)obj;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOMoveY(transform, endValue, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t, false))
		{
			Sequence sequence = Sequence.DoInsert(_lidTween, (Tween)t, 0f);
		}
		object obj2 = default(object);
		float num3 = (float)obj2 * 2f;
		float num4 = num3 * 0.75f;
		float endValue2 = ret - num4;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOMoveX(transform, endValue2, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t2, false))
		{
			Sequence sequence2 = Sequence.DoInsert(_lidTween, (Tween)t2, 0f);
		}
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(transform, (Vector3)(&ret), 0.5f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)tweenerCore, false))
		{
			Sequence sequence3 = Sequence.DoInsert(_lidTween, (Tween)tweenerCore, 0f);
		}
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScaleX(transform, -1f, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(_lidTween, (Tween)t3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(_lidTween, (Tween)t3, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag5 = _lidTween == null;
		Sequence lidTween2 = _lidTween;
		TweenCallback onComplete = delegate
		{
			GameObject obj3 = base.gameObject;
			UnityEngine.Object.Destroy(obj3, 0f);
		};
		if (_lidTween != null && ((Tween)lidTween2)._003Cactive_003Ek__BackingField)
		{
			lidTween2.onComplete = onComplete;
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_base, 0f, 0.5f);
	}

	public ExplodingCoffin()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CExplode_003Eb__3_0()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}
}
