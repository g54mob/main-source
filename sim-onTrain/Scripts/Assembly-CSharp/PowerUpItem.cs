using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpItem : MonoBehaviour
{
	public CollectableItemData powerUpData;

	public Gradient barColorGradient;

	public TextMeshProUGUI timerText;

	public Image fillBarImage;

	private float currentDuration;

	private float totalDuration;

	private bool isActive;

	public bool IsActive => isActive;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (isActive)
		{
			currentDuration -= Time.deltaTime;
			if (currentDuration <= 0f)
			{
				DeactivatePowerUp();
			}
			else
			{
				UpdateUI();
			}
		}
	}

	public void ActivatePowerUp(CollectableItemData data, bool addToExisting = false)
	{
		powerUpData = data;
		if (addToExisting && isActive)
		{
			currentDuration += data.powerUpDuration;
			totalDuration += data.powerUpDuration;
		}
		else
		{
			totalDuration = data.powerUpDuration;
			currentDuration = totalDuration;
			isActive = true;
			base.gameObject.SetActive(value: true);
		}
		UpdateUI();
	}

	private void UpdateUI()
	{
		float num = currentDuration / totalDuration;
		if (fillBarImage != null)
		{
			fillBarImage.fillAmount = num;
			if (barColorGradient != null)
			{
				fillBarImage.color = barColorGradient.Evaluate(num);
			}
		}
		if (timerText != null)
		{
			int num2 = Mathf.CeilToInt(currentDuration);
			timerText.text = num2 + "s";
		}
	}

	public void DeactivatePowerUp()
	{
		isActive = false;
		currentDuration = 0f;
		totalDuration = 0f;
		base.transform.SetAsLastSibling();
		base.gameObject.SetActive(value: false);
	}
}
