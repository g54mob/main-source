using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
	public CreditsASlide[] slides;

	private int slideIndex;

	private CreditsASlide currentSlide;

	public bool isDone { get; private set; }

	public bool waitingForFinalPress { get; private set; }

	public void Activate()
	{
		isDone = false;
		currentSlide = null;
		waitingForFinalPress = false;
	}

	public void UpdateTic()
	{
		if (waitingForFinalPress && AsciiMouse.singleton.down0)
		{
			isDone = true;
			return;
		}
		if (currentSlide == null)
		{
			slideIndex = -1;
			NextSlide();
			return;
		}
		currentSlide.UpdateTic();
		if (!isDone && currentSlide.IsDone())
		{
			NextSlide();
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (currentSlide != null)
		{
			currentSlide.Draw(r, offsetX, offsetY);
		}
	}

	private void NextSlide()
	{
		slideIndex++;
		if (slideIndex < slides.Length)
		{
			currentSlide = slides[slideIndex];
			currentSlide.Reset();
		}
		else
		{
			isDone = true;
		}
	}
}
