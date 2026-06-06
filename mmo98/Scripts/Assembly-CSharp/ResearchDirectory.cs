using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchDirectory : MonoBehaviour
{
	private static readonly Color DefaultBackgroundColor = new Color(63f / 106f, 63f / 106f, 63f / 106f);

	private static readonly Color DefaultTextColor = Color.white;

	[SerializeField]
	private ResearchNodeDirectory directory;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private TMP_Text labelText;

	[SerializeField]
	private Color activeColor = new Color(14f / 15f, 0.7490196f, 0.007843138f);

	[SerializeField]
	private Color activeTextColor = Color.black;

	public ResearchNodeDirectory Directory => directory;

	public event Action<ResearchNodeDirectory> Selected;

	private void Awake()
	{
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(directory);
		});
	}

	public void SetActiveTab(bool isActive)
	{
		if (backgroundImage != null)
		{
			backgroundImage.color = (isActive ? activeColor : DefaultBackgroundColor);
		}
		if (labelText != null)
		{
			labelText.color = (isActive ? activeTextColor : DefaultTextColor);
			labelText.fontStyle = (isActive ? FontStyles.Bold : FontStyles.Normal);
		}
	}
}
