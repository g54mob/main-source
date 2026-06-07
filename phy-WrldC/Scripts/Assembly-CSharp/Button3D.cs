using UnityEngine;

public abstract class Button3D : MonoBehaviourBaseView
{
	protected Color originalColor;

	protected Color highlightedColor;

	protected Color selectedColor;

	private bool isOriginalColor;

	private bool isSelected;

	public string Id { get; set; }

	protected virtual void Start()
	{
		originalColor = Color.yellow;
		highlightedColor = Color.green;
		selectedColor = Color.red;
		isSelected = false;
		isOriginalColor = true;
	}

	public void SetHighlightedColor()
	{
		if (isOriginalColor && !isSelected)
		{
			SetColor(highlightedColor);
			isOriginalColor = false;
		}
	}

	public void SetOriginalColor()
	{
		if (!isOriginalColor && !isSelected)
		{
			SetColor(originalColor);
			isOriginalColor = true;
		}
	}

	public void SetSelectedColor()
	{
		SetColor(selectedColor);
		isSelected = true;
		isOriginalColor = false;
	}

	public void UnSelectedColor()
	{
		isSelected = false;
		SetOriginalColor();
	}

	protected abstract void SetColor(Color color);
}
