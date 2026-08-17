using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class CardEditionInfoUI : MonoBehaviour
{
	private Image _editionImage;

	private TextMeshProUGUI _editionDescription;

	public unsafe void SetData(SkillCardEdition cardEdition)
	{
		//IL_002c: Expected O, but got Ref
		//IL_00ae: Expected I, but got O
		//IL_011a: Expected O, but got Ref
		//IL_00a1->IL019d: Incompatible stack heights: 1 vs 0
		//IL_00d2->IL019d: Incompatible stack heights: 1 vs 0
		//IL_00fe->IL019d: Incompatible stack heights: 1 vs 0
		//IL_013b->IL019d: Incompatible stack heights: 1 vs 0
		//IL_0183->IL019d: Incompatible stack heights: 1 vs 0
		if ((object)_editionDescription != null)
		{
			Transform transform = _editionDescription.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			if (cardEdition == SkillCardEdition.Base)
			{
				return;
			}
			string text = ((Enum)(&value)).ToString();
			Transform editionDescription = (Transform)(object)_editionDescription;
			string term = "arcanaLang/{EDITION_" + text + "}description";
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			if ((object)_editionDescription != null)
			{
				nint num = (nint)editionDescription;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ r9_v8 (Il2CppClass<UnityEngine.Transform>)+558] (should have been resolved before IL gen)");
				if ((object)_editionImage != null)
				{
					GameObject gameObject = _editionImage.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: true);
						IntPtr intPtr = default(IntPtr);
						string text2 = ((Enum)(&intPtr)).ToString();
						if (text2 != null)
						{
							string spriteName = text2.ToUpper();
							Sprite sprite = SpriteManager.GetSprite(spriteName, "randomazzo");
							if ((object)_editionImage != null)
							{
								_editionImage.sprite = sprite;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public CardEditionInfoUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
