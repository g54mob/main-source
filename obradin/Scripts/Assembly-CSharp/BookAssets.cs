using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BookAssets
{
	public Font finalFont;

	public Font guessFont;

	public DialogLib dialogLib;

	public Material faceBlurMaterial;

	public AudioClip revealAudioClip;

	public AudioClip revealVeryShortAudioClip;

	public AudioClip revealLeadinAudioClip;

	public Sprite chapterTallyDieSprite;

	public Sprite chapterTallyDisappearSprite;

	public List<Sprite> difficultySprites;

	public List<Sprite> folioIconSprites;

	public List<Sprite> chapterSketchSprites;

	private Dictionary<string, Sprite> folioIconSpritesDict;

	private Dictionary<string, Sprite> chapterSketchSpritesDict;

	public Font GetFont(bool shownCorrect)
	{
		return (!shownCorrect) ? guessFont : finalFont;
	}

	public Sprite GetFolioIconSprite(string name)
	{
		if (folioIconSpritesDict == null || folioIconSpritesDict.Count == 0)
		{
			folioIconSpritesDict = new Dictionary<string, Sprite>();
			foreach (Sprite folioIconSprite in folioIconSprites)
			{
				folioIconSpritesDict.Add(folioIconSprite.name, folioIconSprite);
			}
		}
		Sprite value = null;
		folioIconSpritesDict.TryGetValue(name, out value);
		return value;
	}

	public Sprite GetChapterSketchSprite(string name)
	{
		if (chapterSketchSpritesDict == null || chapterSketchSpritesDict.Count == 0)
		{
			chapterSketchSpritesDict = new Dictionary<string, Sprite>();
			foreach (Sprite chapterSketchSprite in chapterSketchSprites)
			{
				chapterSketchSpritesDict.Add(chapterSketchSprite.name, chapterSketchSprite);
			}
		}
		Sprite value = null;
		chapterSketchSpritesDict.TryGetValue(name, out value);
		return value;
	}
}
