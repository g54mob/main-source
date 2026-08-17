using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Glyphs.UnityUI;

internal class UnityUIDefaultGlyphOrTextTMProPrefabProvider
{
	private static void Initialize()
	{
		Func<GameObject> s_defaultGlyphOrTextPrefabProvider = CreateDefaultGlyphOrTextPrefab;
		UnityUIControllerElementGlyphBase.s_defaultGlyphOrTextPrefabProvider = s_defaultGlyphOrTextPrefabProvider;
	}

	private static GameObject CreateDefaultGlyphOrTextPrefab()
	{
		GameObject gameObject = new GameObject("Glyph or text prefab");
		if ((object)gameObject != null)
		{
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			UnityUIGlyphOrTextTMPro unityUIGlyphOrTextTMPro = gameObject.AddComponent<UnityUIGlyphOrTextTMPro>();
			VerticalLayoutGroup verticalLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
			if ((object)verticalLayoutGroup != null)
			{
				verticalLayoutGroup.childControlHeight = true;
				verticalLayoutGroup.childControlWidth = true;
				verticalLayoutGroup.childForceExpandHeight = true;
				verticalLayoutGroup.childForceExpandWidth = true;
				GameObject gameObject2 = new GameObject("Glyph");
				if ((object)gameObject2 != null)
				{
					gameObject2.hideFlags = HideFlags.HideAndDontSave;
					Transform transform = gameObject2.transform;
					Transform transform2 = gameObject.transform;
					if ((object)transform != null)
					{
						transform.SetParent(transform2, worldPositionStays: false);
						Image image = gameObject2.AddComponent<Image>();
						if ((object)image != null)
						{
							image.preserveAspect = true;
							if ((object)unityUIGlyphOrTextTMPro != null)
							{
								GameObject gameObject3 = new GameObject("Text");
								if ((object)gameObject3 != null)
								{
									gameObject3.hideFlags = HideFlags.HideAndDontSave;
									Transform transform3 = gameObject3.transform;
									Transform transform4 = gameObject.transform;
									if ((object)transform3 != null)
									{
										transform3.SetParent(transform4, worldPositionStays: false);
										TextMeshProUGUI textMeshProUGUI = gameObject3.AddComponent<TextMeshProUGUI>();
										if ((object)textMeshProUGUI != null)
										{
											textMeshProUGUI.alignment = TextAlignmentOptions.Center;
											textMeshProUGUI.fontSize = 32f;
											textMeshProUGUI.enableAutoSizing = true;
											textMeshProUGUI.fontSizeMin = 10f;
											textMeshProUGUI.fontSizeMax = 32f;
											textMeshProUGUI.raycastTarget = false;
											return gameObject;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}
}
