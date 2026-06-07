using TMPro;
using UnityEngine;

public class ControllerSymbol : MonoBehaviour
{
	public bool shouldUseControllerButton;

	public ControllerButton controllerButton;

	public RectTransform baseRectTransform;

	public GameObject textControllerSymbol;

	public GameObject defaultControllerSymbol;

	private GameObject _symbol;

	public bool IsUsingDefaultSymbol => defaultControllerSymbol.activeInHierarchy;

	public void Initialize(IControllerButtonToSymbolService controllerButtonToSymbolService)
	{
		if (!shouldUseControllerButton || !controllerButtonToSymbolService.HasMappings)
		{
			UseDefaultSymbol();
			return;
		}
		string textMeshProSymbolTextForControllerButton = controllerButtonToSymbolService.GetTextMeshProSymbolTextForControllerButton(controllerButton);
		if (!string.IsNullOrEmpty(textMeshProSymbolTextForControllerButton))
		{
			UseTextSymbol(textMeshProSymbolTextForControllerButton);
		}
		else
		{
			UseDefaultSymbol();
		}
	}

	public void UseDefaultSymbol()
	{
		defaultControllerSymbol.SetActive(value: true);
		if (_symbol != null)
		{
			_symbol.SetActive(value: false);
		}
	}

	public void UseTextSymbol(string symbolCharacter)
	{
		if (_symbol == null)
		{
			_symbol = Object.Instantiate(textControllerSymbol, baseRectTransform);
			_symbol.transform.SetAsFirstSibling();
			RectTransform component = _symbol.GetComponent<RectTransform>();
			RectTransform component2 = defaultControllerSymbol.GetComponent<RectTransform>();
			component.anchorMin = component2.anchorMin;
			component.anchorMax = component2.anchorMax;
			component.anchoredPosition = component2.anchoredPosition;
			component.sizeDelta = component2.sizeDelta;
		}
		if (defaultControllerSymbol != null)
		{
			defaultControllerSymbol.SetActive(value: false);
		}
		_symbol.SetActive(value: true);
		_symbol.GetComponent<TextMeshProUGUI>().text = symbolCharacter;
	}
}
