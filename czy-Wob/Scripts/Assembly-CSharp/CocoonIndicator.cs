using TMPro;
using UnityEngine;

public class CocoonIndicator : WorldSpaceBillboard
{
	public TextMeshProUGUI dogNameText;

	public GameObject mainGUIHolder;

	public Color defaultDogNameColor = Color.white;

	public Color selectedDogNameColor;

	private Canvas canvasRef;

	private void Awake()
	{
		base.AwakeBehavior();
		canvasRef = GetComponentInChildren<Canvas>();
	}

	private void Update()
	{
		if (PauseController.IsUIEnabled())
		{
			if (!canvasRef.enabled)
			{
				canvasRef.enabled = true;
			}
		}
		else
		{
			canvasRef.enabled = false;
		}
	}

	public void SetName(string dogName)
	{
		dogNameText.text = dogName;
		dogNameText.color = Color.white;
	}

	public void OnDogSelected()
	{
		dogNameText.color = selectedDogNameColor;
	}

	public void OnDogDeselected()
	{
		dogNameText.color = defaultDogNameColor;
	}
}
