using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPipController : ButtonController
{
	public Image img;

	public Color unfilledColour;

	public Color filledColour;

	public Color secondaryColour;

	public ProgressBarController bar;

	public bool filled;

	public bool secondaryFilled;

	private void Awake()
	{
	}

	public override void OnHoverStart()
	{
	}

	public override void OnHoverEnd()
	{
	}

	public void SetFilled(bool newVal, bool secondaryFilled)
	{
	}

	public int GetPipNumber()
	{
		return 0;
	}
}
