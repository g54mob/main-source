using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveGameRow : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TMP_Text _nameText;

	[SerializeField]
	private TMP_Text _dateText;

	[SerializeField]
	private Image _background;

	private SaveGameUI _parent;

	private SaveGameFile _file;

	private void Start()
	{
		_parent = GetComponentInParent<SaveGameUI>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.clickCount == 2)
		{
			_parent.DoExecuteAction();
		}
		else
		{
			_parent.ShowSaveGame(_file);
		}
	}

	public void SetSave(SaveGameFile file)
	{
		_file = file;
		_nameText.text = file.Name;
		_dateText.text = file.File.LastWriteTime.ToString("dd/MM/yyyy HH:mm:ss");
	}

	public void SetHighlighted(SaveGameFile file)
	{
		_background.color = ((_file == file) ? new Color(0.5f, 0.5f, 0.5f, 0.8f) : new Color(0f, 0f, 0f, 0.8f));
	}
}
