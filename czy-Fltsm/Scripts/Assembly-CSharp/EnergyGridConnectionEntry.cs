using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGridConnectionEntry : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private TextMeshProUGUI _name;

	private EnergyGridConnector _currentComponent;

	private EnergyGridConnector _connectedComponent;

	public void Initialize(EnergyGridConnector current, EnergyGridConnector connected, Sprite icon, LocalizedString name)
	{
		base.gameObject.SetActive(value: true);
		_currentComponent = current;
		_connectedComponent = connected;
		_icon.sprite = icon;
		_name.text = name;
	}

	public void Disconnect()
	{
		HideConnection();
		EnergyGrid.Disconnect(_currentComponent, _connectedComponent);
	}

	public void ShowConnection()
	{
		SelectionLink componentInChildren = _connectedComponent.GetComponentInChildren<SelectionLink>();
		GameManager.HighlightManager.HighlightObject(componentInChildren.OutlineRenderer);
	}

	public void HideConnection()
	{
		_connectedComponent.GetComponentInChildren<SelectionLink>().OutlineRenderer.ResetHighlightOutline();
	}

	public void SelectConnection()
	{
		_currentComponent.GetComponentInChildren<SelectionLink>().OutlineRenderer.ResetHighlightOutline();
		SelectionLink componentInChildren = _connectedComponent.GetComponentInChildren<SelectionLink>();
		Selector.Select(_connectedComponent.gameObject, componentInChildren.Type);
	}
}
