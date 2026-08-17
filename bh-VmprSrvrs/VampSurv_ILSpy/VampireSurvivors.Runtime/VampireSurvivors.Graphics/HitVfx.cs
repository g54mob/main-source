using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Graphics;

public class HitVfx : GameMonoBehaviour
{
	private SpriteRenderer _Hit;

	private SpriteRenderer _Impact;

	private Vector3 _baseHitScale;

	private Vector3 _baseImpactScale;

	private Vector3 _targetHitScale;

	private Vector3 _targetImpactScale;

	private Transform _hitTransform;

	private Transform _impactTransform;

	private Vector3 _targetRotation;

	private HitVFXData _data;

	private Sequence _tweens;

	private bool _tweensInitialised;

	private Sprite _defaultHitSprite;

	private Sprite _defaultImpactSprite;

	private Tween _doTween1;

	private Tween _doTween2;

	private Tween _doTween3;

	public void Awake()
	{
		//IL_022d->IL01c7: Incompatible stack heights: 1 vs 0
		//IL_0282->IL01c7: Incompatible stack heights: 2 vs 0
		//IL_0118->IL01c7: Incompatible stack heights: 2 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite defaultHitSprite = default(Sprite);
		_defaultHitSprite = defaultHitSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite defaultImpactSprite = default(Sprite);
		_defaultImpactSprite = defaultImpactSprite;
		if ((object)_Hit != null)
		{
			Transform hitTransform = _Hit.transform;
			_hitTransform = hitTransform;
			if ((object)_Impact != null)
			{
				Transform impactTransform = _Impact.transform;
				_impactTransform = impactTransform;
				object hitTransform2 = _hitTransform;
				if ((object)_hitTransform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdi_v12 (System.Object)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdi_v12 (System.Object)+10]");
					Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret);
					object impactTransform2 = _impactTransform;
					if ((object)_impactTransform != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdi_v13 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rdi_v13 (System.Object)+10]");
						Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret2);
						if ((object)_Hit != null)
						{
							_Hit.enabled = false;
							if ((object)_Impact != null)
							{
								_Impact.enabled = false;
								float num = 0f * 0.25f;
								Vector3 vector = default(Vector3);
								_baseHitScale = vector;
								float num2 = 0f * 0.25f;
								object hitTransform3 = _hitTransform;
								_baseImpactScale = vector;
								_targetHitScale = vector;
								_ = 0;
								_targetImpactScale = vector;
								_ = 0;
								bool flag3 = (object)_hitTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rsi_v13 (System.Object)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v657 @ rsi_v13 (System.Object)+10]");
								Transform.set_localScale_Injected((IntPtr)0, ref ret);
								object impactTransform3 = _impactTransform;
								bool flag5 = (object)_impactTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rdi_v15 (System.Object)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rdi_v15 (System.Object)+10]");
								Transform.set_localScale_Injected((IntPtr)0, ref ret2);
								_tweensInitialised = false;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CacheDefaultSprites()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite defaultHitSprite = default(Sprite);
		_defaultHitSprite = defaultHitSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite defaultImpactSprite = default(Sprite);
		_defaultImpactSprite = defaultImpactSprite;
	}

	private void Start()
	{
		_Hit.sprite = _defaultHitSprite;
		_Impact.sprite = _defaultImpactSprite;
	}

	public void Play(Vector2 pos, HitVFXData data)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		_data = data;
		HitVFXData data2 = _data;
		_Hit.sprite = data2.HitSprite;
		HitVFXData data3 = _data;
		_Impact.sprite = data3.ImpactSprite;
		PlayAnim();
	}

	private void SetData()
	{
		HitVFXData data = _data;
		_Hit.sprite = data.HitSprite;
		HitVFXData data2 = _data;
		_Impact.sprite = data2.ImpactSprite;
	}

	private unsafe void PlayAnim()
	{
		//IL_00a8: Expected O, but got Ref
		//IL_0137: Expected O, but got Ref
		//IL_01c0: Expected O, but got Ref
		_Hit.enabled = true;
		_Impact.enabled = true;
		if (_tweensInitialised)
		{
			TweenExtensions.Restart(_doTween1);
			TweenExtensions.Restart(_doTween2);
			TweenExtensions.Restart(_doTween3);
			return;
		}
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> doTween = ShortcutExtensions.DOScale(_hitTransform, (Vector3)(&vector), 0.09f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rax_v7 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 0;
			}
		}
		_doTween1 = doTween;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> doTween2 = ShortcutExtensions.DORotate(_hitTransform, (Vector3)(&vector), 0.09f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v13 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 0;
			}
		}
		_doTween2 = doTween2;
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_impactTransform, (Vector3)(&vector), 0.09f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 0;
			}
		}
		Tween tween = TweenSettingsExtensions.SetDelay((Tween)t, 0.030000001f);
		TweenCallback onComplete = Despawn;
		if (tween != null && tween._003Cactive_003Ek__BackingField)
		{
			tween.onComplete = onComplete;
		}
		_doTween3 = tween;
		_tweensInitialised = true;
	}

	private void Despawn()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5641]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_Impact.enabled = false;
		_Hit.enabled = false;
		ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("ImpactVfx");
		GameObject obj = base.gameObject;
		pool.Release(obj);
	}

	public HitVfx()
	{
		//IL_0030: Expected I, but got O
		Vector3 targetRotation = default(Vector3);
		_targetRotation = targetRotation;
		_ = 180f;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
