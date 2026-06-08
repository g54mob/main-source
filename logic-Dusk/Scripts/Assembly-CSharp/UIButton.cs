using UnityEngine;

public class UIButton : UITextLabel
{
	private Color focusButtonColor = Color.blue;

	private Color focusTextColor = Color.blue;

	private Color notFocusedButtonColor = Color.white;

	private Color notFocusedTextColor = Color.white;

	public bool HasFocus { get; private set; }

	public void SetButtonColors(Color focusButtonColor, Color focusTextColor, Color notFocusedButtonColor, Color notFocusedTextColor)
	{
		this.focusButtonColor = focusButtonColor;
		this.focusTextColor = focusTextColor;
		this.notFocusedButtonColor = notFocusedButtonColor;
		this.notFocusedTextColor = notFocusedTextColor;
	}

	public void GotFocus()
	{
		HasFocus = true;
		base.backgroundImage.color = focusButtonColor;
		label.color = focusTextColor;
	}

	public void LostFocus()
	{
		HasFocus = false;
		base.backgroundImage.color = notFocusedButtonColor;
		label.color = notFocusedTextColor;
	}

	public void HideFocus()
	{
		if (HasFocus)
		{
			base.backgroundImage.color = notFocusedButtonColor;
			label.color = notFocusedTextColor;
		}
	}

	public void UnHideFocus()
	{
		if (HasFocus)
		{
			base.backgroundImage.color = focusButtonColor;
			label.color = focusTextColor;
		}
	}
}
