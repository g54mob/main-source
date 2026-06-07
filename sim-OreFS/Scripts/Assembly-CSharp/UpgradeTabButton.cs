using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeTabButton : MonoBehaviour
{
	[SerializeField]
	private UpgradeCategory category;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private TextMeshProUGUI tabText;

	[SerializeField]
	private Color activeColor = new Color(1f, 0.6f, 0f, 1f);

	[SerializeField]
	private Color inactiveColor = new Color(0.2f, 0.2f, 0.2f, 1f);

	public UpgradeCategory Category => category;

	public void SetActive(bool isActive)
	{
		if (backgroundImage != null)
		{
			backgroundImage.color = (isActive ? activeColor : inactiveColor);
		}
	}

	public void SetOnClick(UnityAction action)
	{
		if (!(button == null))
		{
			button.onClick.RemoveAllListeners();
			button.onClick.AddListener(action);
		}
	}
}
