using UnityEngine;
using UnityEngine.UI;

public class CityEditorStreetsEditListElement : MonoBehaviour
{
	[Header("References")]
	public CityEditorStreetEdit streetEdit;

	public StreetController street;

	public ButtonController selectButton;

	public ButtonController editNameButton;

	public ButtonController randomNameButton;

	public Image selectionImg;

	public void Setup(StreetController newStreet, CityEditorStreetEdit controller)
	{
	}

	public void UpdateSelection()
	{
	}

	public void OnSelectButton()
	{
	}

	public void OnRandomNameButton()
	{
	}

	public void OnEditNameButton()
	{
	}

	public void OnChangeStreetNameButton()
	{
	}

	private void OnChangeStreetNamePopupCancel()
	{
	}

	private void OnChangeStreetNamePopupConfirm()
	{
	}
}
