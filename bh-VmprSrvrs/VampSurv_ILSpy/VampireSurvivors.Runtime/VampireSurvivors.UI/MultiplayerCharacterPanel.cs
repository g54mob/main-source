using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class MultiplayerCharacterPanel : MultiplayerCharacterDisplay
{
	private Image _Image;

	public unsafe override void Show()
	{
		//IL_00e8: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_02c1: Expected O, but got Ref
		//IL_01ff->IL0182: Incompatible stack heights: 1 vs 0
		//IL_0147->IL0182: Incompatible stack heights: 1 vs 0
		//IL_024d->IL0182: Incompatible stack heights: 2 vs 0
		base.Show();
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, optionalFloat, optionalObj, optionalArray);
		}
		if ((object)_Image != null)
		{
			_Image.sprite = CharacterSprite;
			if ((object)_Image != null)
			{
				RectTransform rectTransform = _Image.rectTransform;
				Transform image = (Transform)(object)_Image;
				if ((object)_Image != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdi_v10 (UnityEngine.Transform)+E0]");
					Transform transform2 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdi_v10 (UnityEngine.Transform)+E0]");
					if ((nint)0 != 0)
					{
						bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Rect ret);
						Transform image2 = (Transform)(object)_Image;
						if ((object)_Image != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v12 (UnityEngine.Transform)+E0]");
							Transform transform3 = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdi_v12 (UnityEngine.Transform)+E0]");
							if ((nint)0 != 0)
							{
								bool flag2 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 ret2;
								Sprite.get_rect_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Rect*)(&ret2));
								if ((object)rectTransform != null)
								{
									Vector2 sizeDelta = default(Vector2);
									rectTransform.sizeDelta = sizeDelta;
									Transform transform4 = base.transform;
									bool flag3 = (object)transform4 == null;
									bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
									Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref ret2);
									Transform target = base.transform;
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&ret), 0.15f);
									Transform target2 = base.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 1f, 0.15f);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public MultiplayerCharacterPanel()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
