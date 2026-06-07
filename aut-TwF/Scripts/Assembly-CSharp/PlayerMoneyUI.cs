using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI moneyText;

	private void Start()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onMoneyChanged += OnMoneyChanged;
	}

	private void OnEnable()
	{
		OnMoneyChanged(LTFunctionLibrary.GetPlayerUpgradesManager().Money);
	}

	private void OnDestroy()
	{
		LTFunctionLibrary.GetPlayerUpgradesManager().onMoneyChanged -= OnMoneyChanged;
	}

	private void OnMoneyChanged(int newMoneyAmount)
	{
		if (base.gameObject.activeInHierarchy)
		{
			moneyText.text = newMoneyAmount.ToString();
			if (TryGetComponent<AutoTransformRebuild>(out var component))
			{
				component.RebuildTransform();
				return;
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(moneyText.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		}
	}
}
