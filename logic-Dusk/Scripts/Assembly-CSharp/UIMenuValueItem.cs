using System;

public class UIMenuValueItem : UIMenuItem
{
	public UISlider slider;

	public bool IsSlider { get; private set; }

	public void SetIsSlider()
	{
		IsSlider = true;
		if (label != null)
		{
			label.gameObject.SetActive(false);
		}
	}

	public override void SetValue<T>(T val)
	{
		if (!IsSlider)
		{
			base.SetValue(val);
		}
		else if (val != null)
		{
			slider.SetValue((float)Convert.ChangeType(val, typeof(float)));
		}
	}

	public override void ShowValue()
	{
		if (!IsSlider)
		{
			base.ShowValue();
		}
		else if (slider != null)
		{
			slider.gameObject.SetActive(true);
		}
	}

	public override void HideValue()
	{
		if (!IsSlider)
		{
			base.HideValue();
		}
		else if (slider != null)
		{
			slider.gameObject.SetActive(false);
		}
	}

	public override void SetFocus()
	{
		if (IsSlider)
		{
			slider.SetFocus();
		}
		base.SetFocus();
	}

	public override void LoseFocus()
	{
		if (IsSlider)
		{
			slider.LoseFocus();
		}
		base.LoseFocus();
	}
}
