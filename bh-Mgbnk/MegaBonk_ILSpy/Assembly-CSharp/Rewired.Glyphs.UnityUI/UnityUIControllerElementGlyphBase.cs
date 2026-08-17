using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Glyphs.UnityUI;

public abstract class UnityUIControllerElementGlyphBase : ControllerElementGlyphBase
{
	private static GameObject s_defaultGlyphOrTextPrefab;

	private static Func<GameObject> s_defaultGlyphOrTextPrefabProvider;

	public static GameObject defaultGlyphOrTextPrefab
	{
		get
		{
			if (s_defaultGlyphOrTextPrefab != null)
			{
				return s_defaultGlyphOrTextPrefab;
			}
			return s_defaultGlyphOrTextPrefab = CreateDefaultGlyphOrTextPrefab();
		}
		set
		{
			s_defaultGlyphOrTextPrefab = value;
		}
	}

	public static Func<GameObject> defaultGlyphOrTextPrefabProvider
	{
		get
		{
			return s_defaultGlyphOrTextPrefabProvider;
		}
		set
		{
			s_defaultGlyphOrTextPrefabProvider = value;
		}
	}

	protected override GameObject GetDefaultGlyphOrTextPrefab()
	{
		return defaultGlyphOrTextPrefab;
	}

	private static GameObject CreateDefaultGlyphOrTextPrefab()
	{
		GameObject gameObject = default(GameObject);
		if (s_defaultGlyphOrTextPrefabProvider == null)
		{
			gameObject = new GameObject("Glyph or text prefab");
			if ((object)gameObject != null)
			{
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				UnityUIGlyphOrText unityUIGlyphOrText = gameObject.AddComponent<UnityUIGlyphOrText>();
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
						Transform parent = gameObject.transform;
						if ((object)transform != null)
						{
							transform.SetParent(parent, worldPositionStays: false);
							Image image = gameObject2.AddComponent<Image>();
							if ((object)image != null)
							{
								image.preserveAspect = true;
								if ((object)unityUIGlyphOrText != null)
								{
									GameObject gameObject3 = new GameObject("Text");
									if ((object)gameObject3 != null)
									{
										gameObject3.hideFlags = HideFlags.HideAndDontSave;
										Transform transform2 = gameObject3.transform;
										Transform parent2 = gameObject.transform;
										if ((object)transform2 != null)
										{
											transform2.SetParent(parent2, worldPositionStays: false);
											Text text = gameObject3.AddComponent<Text>();
											if ((object)text != null)
											{
												text.alignment = TextAnchor.MiddleCenter;
												text.fontSize = 32;
												text.resizeTextForBestFit = true;
												text.resizeTextMinSize = 10;
												text.resizeTextMaxSize = 32;
												Font builtinResource = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
												text.font = builtinResource;
												text.raycastTarget = false;
												goto IL_0365;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		else
		{
			Func<GameObject> func = s_defaultGlyphOrTextPrefabProvider;
			if (s_defaultGlyphOrTextPrefabProvider != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v51 @ r8_v3 (System.Func`1<UnityEngine.GameObject>)+18] (should have been resolved before IL gen)");
				goto IL_0365;
			}
		}
		return (GameObject)(object)new NullReferenceException();
		IL_0365:
		return gameObject;
	}
}
