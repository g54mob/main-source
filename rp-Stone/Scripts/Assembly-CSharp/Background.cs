using System;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	private ParallaxLayer[] parallaxLayers;

	private AsciiSprite[] sprites;

	private void Awake()
	{
		parallaxLayers = GetComponentsInChildren<ParallaxLayer>();
		AsciiSprite[] componentsInChildren = GetComponentsInChildren<AsciiSprite>();
		List<AsciiSprite> list = new List<AsciiSprite>(componentsInChildren.Length);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].includeInQuestBG)
			{
				list.Add(componentsInChildren[i]);
			}
		}
		sprites = list.ToArray();
		for (int j = 0; j < sprites.Length; j++)
		{
			sprites[j].Load();
		}
		Array.Sort(sprites, (AsciiSprite a, AsciiSprite b) => (int)((b.transform.localPosition.z - a.transform.localPosition.z) * 1000f));
	}

	public void Draw(AsciiRenderProcedural r, int screenOffsetX, int screenOffsetY, int parallaxX, int parallaxY)
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		parallaxX += r.width >> 1;
		parallaxX -= 24;
		for (int i = 0; i < parallaxLayers.Length; i++)
		{
			parallaxLayers[i].ParallaxX = parallaxX;
			parallaxLayers[i].ParallaxY = parallaxY;
		}
		int num = r.width - 46 >> 1;
		for (int j = 0; j < sprites.Length; j++)
		{
			if (sprites[j].gameObject.activeSelf)
			{
				if (sprites[j] is TilingAsciiSprite)
				{
					sprites[j].Draw(r, screenOffsetX, screenOffsetY);
				}
				else
				{
					sprites[j].Draw(r, screenOffsetX + num, screenOffsetY);
				}
			}
		}
	}
}
