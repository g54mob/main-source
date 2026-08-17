using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace VampireSurvivors.UI;

public class MultiplayerCharacterBanner : MultiplayerCharacterDisplay
{
	private SpriteReel _Reel;

	public override void Show()
	{
		base.Show();
		Sprite characterSprite = CharacterSprite;
		if ((object)CharacterSprite != null && ((UnityEngine.Object)characterSprite).m_CachedPtr != (IntPtr)0)
		{
			_Reel.Build(CharacterSprite);
		}
		Transform transform = base.transform;
		RectTransform component = transform.GetComponent<RectTransform>();
		Transform transform2 = base.transform;
		RectTransform component2 = transform2.GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		Vector2 sizeDelta = component.sizeDelta;
		Vector2 anchoredPosition2 = default(Vector2);
		component.anchoredPosition = anchoredPosition2;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPosY(component, 0f, 0.3f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
		Vector2 anchoredPosition3 = component2.anchoredPosition;
		Vector2 sizeDelta2 = component2.sizeDelta;
		component2.anchoredPosition = anchoredPosition2;
		TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosY(component2, 0f, 0.3f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rax_v22 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 4;
				_ = 0;
			}
		}
	}

	public MultiplayerCharacterBanner()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
