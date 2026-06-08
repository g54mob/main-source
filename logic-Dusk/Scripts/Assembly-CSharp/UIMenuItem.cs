public class UIMenuItem : UITextLabel
{
	public bool IsEmpty { get; set; }

	public bool IgnoreFocus { get; set; }

	public bool IsHighlighted
	{
		get
		{
			return base.backgroundImage.enabled;
		}
	}

	public DuskersMenuItem underlyingMenuItem { get; set; }

	public void ShowBar()
	{
		if (base.backgroundImage != null)
		{
			base.backgroundImage.enabled = true;
		}
	}

	public void HideBar()
	{
		if (base.backgroundImage != null)
		{
			base.backgroundImage.enabled = false;
		}
	}

	public virtual void SetValue<T>(T val)
	{
		if (label != null)
		{
			label.text = val.ToString();
		}
	}

	public virtual void ShowValue()
	{
		if (label != null)
		{
			label.gameObject.SetActive(true);
		}
	}

	public virtual void HideValue()
	{
		if (label != null)
		{
			label.gameObject.SetActive(false);
		}
	}

	public virtual void SetFocus()
	{
	}

	public virtual void LoseFocus()
	{
	}
}
