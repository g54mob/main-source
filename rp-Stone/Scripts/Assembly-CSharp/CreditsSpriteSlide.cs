using System;
using UnityEngine;

public class CreditsSpriteSlide : CreditsASlide
{
	[Serializable]
	public class SpriteEntry
	{
		public AsciiSprite sprite;

		public int anmPlayDelay;

		public int ticDuration = 30;

		public int x;

		public int y;
	}

	public bool showAllTogether = true;

	public SpriteEntry[] spriteEntries;

	private int elapsedTics;

	private int spriteIndex;

	private SpriteEntry currentSpriteEntry;

	public override void Reset()
	{
		elapsedTics = 0;
		spriteIndex = -1;
		currentSpriteEntry = null;
	}

	public override void UpdateTic()
	{
		if (currentSpriteEntry == null)
		{
			NextSprite();
			return;
		}
		if (AsciiMouse.singleton.down0)
		{
			if (spriteIndex >= spriteEntries.Length - 1)
			{
				elapsedTics = currentSpriteEntry.ticDuration;
				return;
			}
			for (int i = 0; i < 12; i++)
			{
				NextSprite();
			}
			return;
		}
		elapsedTics++;
		if (spriteIndex < spriteEntries.Length - 1 && elapsedTics >= currentSpriteEntry.ticDuration)
		{
			elapsedTics = 0;
			NextSprite();
		}
		else if (currentSpriteEntry.anmPlayDelay == elapsedTics)
		{
			PlayAnimation(currentSpriteEntry);
		}
	}

	private void NextSprite()
	{
		spriteIndex = Mathf.Min(spriteIndex + 1, spriteEntries.Length - 1);
		currentSpriteEntry = spriteEntries[spriteIndex];
		if (currentSpriteEntry.sprite != null)
		{
			currentSpriteEntry.sprite.Load();
		}
		if (currentSpriteEntry.anmPlayDelay == 0)
		{
			PlayAnimation(currentSpriteEntry);
		}
	}

	private void PlayAnimation(SpriteEntry entry)
	{
		if (entry.sprite != null)
		{
			AsciiAnimation[] componentsInChildren = entry.sprite.GetComponentsInChildren<AsciiAnimation>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Stop();
				componentsInChildren[i].Play();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (showAllTogether)
		{
			for (int i = 0; i <= spriteIndex && i < spriteEntries.Length; i++)
			{
				SpriteEntry spriteEntry = spriteEntries[i];
				if (spriteEntry.sprite != null)
				{
					spriteEntry.sprite.Draw(r, offsetX + spriteEntry.x, offsetY + spriteEntry.y);
				}
			}
		}
		else if (spriteIndex >= 0 && spriteIndex < spriteEntries.Length)
		{
			SpriteEntry spriteEntry2 = spriteEntries[spriteIndex];
			if (spriteEntry2.sprite != null)
			{
				spriteEntry2.sprite.Draw(r, offsetX + spriteEntry2.x, offsetY + spriteEntry2.y);
			}
		}
	}

	public override bool IsDone()
	{
		if (spriteIndex >= spriteEntries.Length - 1 && currentSpriteEntry != null)
		{
			return elapsedTics >= currentSpriteEntry.ticDuration;
		}
		return false;
	}
}
