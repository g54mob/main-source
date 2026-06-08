using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HorizontalScreenSlideTransition
{
	public enum Direction
	{
		RightToLeft = 0,
		LeftToRight = 1
	}

	public float lerpSpeed = 0.2f;

	public List<AsciiObject> screens;

	private Direction direction;

	private float translatedX;

	private AsciiObject currentScreen;

	private AsciiObject prevScreen;

	private AsciiObject nextScreen;

	private int index;

	public AsciiObject CurrentScreen => currentScreen;

	public void Next()
	{
		SetIndex(Mathf.Min(index + 1, screens.Count - 1));
	}

	public void Previous()
	{
		SetIndex(Mathf.Max(index - 1, 0));
	}

	public void SetIndex(int i)
	{
		currentScreen = screens[i];
		prevScreen = ((i > 0) ? screens[i - 1] : null);
		nextScreen = ((i < screens.Count - 1) ? screens[i + 1] : null);
		if (index != i)
		{
			if (i > index)
			{
				translatedX = GameStates.Singleton.asciiRenderer.width;
			}
			else
			{
				translatedX = 0f - (float)GameStates.Singleton.asciiRenderer.width;
			}
			index = i;
		}
		if (currentScreen is IActivatable activatable)
		{
			activatable.Activate();
		}
		ScrollContainerScreen scrollContainerScreen = currentScreen as ScrollContainerScreen;
		if (scrollContainerScreen != null)
		{
			scrollContainerScreen.header.prevButton.enabled = prevScreen != null;
			scrollContainerScreen.header.nextButton.enabled = nextScreen != null;
		}
	}

	public void SetScreen(AsciiObject screen)
	{
		int num = screens.IndexOf(screen);
		if (num >= 0)
		{
			SetIndex(num);
			return;
		}
		Utils.LogWarning("Screen " + screen?.ToString() + " is not currently part of the collection. Adding it to the end. Revise.");
		screens.Add(screen);
		SetIndex(screens.Count - 1);
	}

	public void UpdateTic()
	{
		currentScreen.UpdateTic();
		translatedX = Mathf.Lerp(translatedX, 0f, lerpSpeed);
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		currentScreen.Draw(r, offsetX + (int)translatedX, offsetY);
		if (translatedX > 0.01f && prevScreen != null)
		{
			prevScreen.Draw(r, offsetX + (int)translatedX - r.width, offsetY);
		}
		if (translatedX < -0.01f && nextScreen != null)
		{
			nextScreen.Draw(r, offsetX + (int)translatedX + r.width, offsetY);
		}
	}
}
