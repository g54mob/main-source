using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;

namespace VampireSurvivors.Objects;

public class PizzaCircle : GameMonoBehaviour
{
	public EnemyType EnemyTag;

	private SpriteRenderer _pizzaSprite;

	private SpriteRenderer _warningSprite;

	private Circle _circle;

	private MapToken _mapToken;

	public Circle Circle => _circle;

	private void Awake()
	{
		//IL_01ed: Expected I4, but got I8
		//IL_0156->IL00de: Incompatible stack heights: 1 vs 0
		//IL_0070->IL00de: Incompatible stack heights: 1 vs 0
		//IL_00ce->IL00de: Incompatible stack heights: 2 vs 0
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				string spriteName = default(string);
				SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, vector, vector, "UI", spriteName);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
				if ((object)spriteRenderer != null)
				{
					bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, 9000);
					((UnityEngine.Object)spriteRenderer).SetName("WarningSprite");
					_warningSprite = spriteRenderer;
					GameObject gameObject2 = base.gameObject;
					SpriteRenderer spriteRenderer2 = RenderingExtensions.AddSprite(gameObject2, vector, "items", "Pizza");
					SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0f);
					if ((object)spriteRenderer3 != null)
					{
						bool flag3 = ((UnityEngine.Object)spriteRenderer3).m_CachedPtr == (IntPtr)0;
						Renderer.set_sortingOrder_Injected(((UnityEngine.Object)spriteRenderer3).m_CachedPtr, -1);
						((UnityEngine.Object)spriteRenderer3).SetName("PizzaSprite");
						_pizzaSprite = spriteRenderer3;
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void OnDrawGizmos()
	{
		Circle circle = _circle;
		VSDebug.DrawDebugCircle(circle._x, circle._y, circle._radius);
	}

	public void SetSprite(string texture, string frameName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_pizzaSprite != null)
		{
			Sprite sprite = default(Sprite);
			_pizzaSprite.sprite = sprite;
			SpriteRenderer pizzaSprite = _pizzaSprite;
			if ((object)_pizzaSprite != null)
			{
				bool flag = ((UnityEngine.Object)pizzaSprite).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 114 ConditionalJump @-1, v176 @ ZF_v10 (System.Boolean) --- -1 Phi v190 @ rbx_v2 (UnityEngine.SpriteRenderer), v115 @ rbx_v3 (UnityEngine.SpriteRenderer), v73 @ rbx_v5 (UnityEngine.SpriteRenderer)");
				/*Error: End of method reached without returning.*/;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetMapToken(string texture, string frameName)
	{
		//IL_0145->IL00a6: Incompatible stack heights: 1 vs 0
		//IL_0074->IL00a6: Incompatible stack heights: 2 vs 0
		//IL_0096->IL00a6: Incompatible stack heights: 2 vs 0
		MapToken mapToken = new MapToken();
		if (mapToken != null)
		{
			mapToken.texture = texture;
			string frameName2 = default(string);
			mapToken.frameName = frameName2;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				bool flag = ((string)(object)transform)._stringLength == 0;
				float ret;
				Transform.get_position_Injected((IntPtr)((string)(object)transform)._stringLength, out *(Vector3*)(&ret));
				mapToken.x = ret;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((string)(object)transform2)._stringLength == 0;
					Transform.get_position_Injected((IntPtr)((string)(object)transform2)._stringLength, out *(Vector3*)(&ret));
					float y = default(float);
					mapToken.y = y;
					_mapToken = mapToken;
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._mapTokens != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1340");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void CleanUp()
	{
		if (_mapToken != null)
		{
			GameManager core = GM.Core;
			bool flag = ((List<object>)(object)core._mapTokens).Remove((object)_mapToken);
		}
	}

	public unsafe void Init(float radius)
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float ret;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
		Circle circle = new Circle();
		float radius2 = radius * 0.01f;
		circle._radius = radius2;
		circle._x = ret;
		float y = default(float);
		circle._y = y;
		_circle = circle;
	}

	public bool CheckPizzaOverlap(Vector2 point)
	{
		//IL_0045: Expected I4, but got O
		if (_circle != null)
		{
			return _circle.Contains(point);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe void ShowWarning()
	{
		//IL_02c8: Expected O, but got Ref
		//IL_030d: Expected O, but got Ref
		Sequence sequence = DOTween.Sequence();
		Transform target = _warningSprite.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&vector), 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 0.2f);
		Transform target2 = _warningSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, (Vector3)(&vector), 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
		Sequence sequence5 = DOTween.Sequence();
		Transform target3 = _pizzaSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(target3, 1.25f, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t3, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence5, (Tween)t3, 0f);
		}
		TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(_pizzaSprite, 1f, 0.5f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t4, false))
		{
			Sequence sequence7 = Sequence.DoInsert(sequence5, (Tween)t4, 0f);
		}
		if (sequence5 != null && ((Tween)sequence5)._003Cactive_003Ek__BackingField && !((Tween)sequence5).creationLocked)
		{
			((Tween)sequence5).loops = 2;
			((Tween)sequence5).loopType = LoopType.Yoyo;
			if (((ABSSequentiable)sequence5).tweenType == TweenType.Tweener)
			{
				float fullDuration = ((Tween)sequence5).duration + ((Tween)sequence5).duration;
				((Tween)sequence5).fullDuration = fullDuration;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence5.stringId = "DefaultGameTweenId";
	}

	public unsafe void ShowFinalWarning()
	{
		//IL_03fd: Expected O, but got Ref
		//IL_0443: Expected O, but got Ref
		//IL_04e6: Expected O, but got Ref
		//IL_01ca: Expected O, but got I
		//IL_02c3: Expected O, but got I
		Sequence sequence = DOTween.Sequence();
		Transform target = _warningSprite.transform;
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target, (Vector3)(&vector), 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		Sequence sequence3 = TweenSettingsExtensions.AppendInterval(sequence, 0.2f);
		Transform target2 = _warningSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t2 = ShortcutExtensions.DOScale(target2, (Vector3)(&vector), 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t2, ((Tween)sequence).duration);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
		Sequence sequence5 = DOTween.Sequence();
		Transform target3 = _pizzaSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target3, 1.25f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
						object obj = num + 0;
					}
				}
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)tweenerCore, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence5, (Tween)tweenerCore, 0f);
		}
		TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_pizzaSprite, 1f, 0.3f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 2;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v593 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						object obj2 = num2 + 0;
					}
				}
			}
		}
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)tweenerCore2, false))
		{
			Sequence sequence7 = Sequence.DoInsert(sequence5, (Tween)tweenerCore2, 0f);
		}
		Sequence sequence8 = TweenSettingsExtensions.AppendInterval(sequence5, 0.2f);
		Transform target4 = _pizzaSprite.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t3 = ShortcutExtensions.DOScale(target4, (Vector3)(&vector), 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t3, false))
		{
			Sequence sequence9 = Sequence.DoInsert(sequence5, (Tween)t3, ((Tween)sequence5).duration);
		}
		TweenerCore<Color, Color, ColorOptions> t4 = DOTweenModuleSprite.DOFade(_pizzaSprite, 0f, 0.2f);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence5, (Tween)t4, false))
		{
			Sequence sequence10 = Sequence.DoInsert(sequence5, (Tween)t4, ((Tween)sequence5).duration);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence5.stringId = "DefaultGameTweenId";
	}

	public void SetAlpha(float alpha)
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_pizzaSprite, alpha);
	}

	public void SetMapTokenHidden(bool isHidden)
	{
		if (_mapToken != null)
		{
			MapToken mapToken = _mapToken;
			mapToken.Hidden = isHidden;
		}
	}

	public PizzaCircle()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
