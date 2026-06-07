using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreNodeHealthbar : MonoBehaviour
{
	[Header("Segments")]
	[SerializeField]
	private List<Image> segments = new List<Image>();

	[Header("Colors")]
	[SerializeField]
	private Color filledColor;

	[SerializeField]
	private Color emptyColor;

	[Header("Runtime")]
	[SerializeField]
	private int maxHealth = 5;

	[SerializeField]
	private int currentHealth = 5;

	public void SetMaxHealth(int value)
	{
		if (segments == null || segments.Count == 0)
		{
			return;
		}
		maxHealth = Mathf.Clamp(value, 0, segments.Count);
		for (int i = 0; i < segments.Count; i++)
		{
			if (!(segments[i] == null))
			{
				segments[i].gameObject.SetActive(i < maxHealth);
			}
		}
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		UpdateVisual();
	}

	public void SetCurrentHealth(int value)
	{
		if (segments != null && segments.Count != 0)
		{
			currentHealth = Mathf.Clamp(value, 0, maxHealth);
			UpdateVisual();
		}
	}

	private void UpdateVisual()
	{
		for (int i = 0; i < maxHealth; i++)
		{
			Image image = segments[i];
			if (!(image == null))
			{
				image.color = ((i < currentHealth) ? filledColor : emptyColor);
			}
		}
	}
}
