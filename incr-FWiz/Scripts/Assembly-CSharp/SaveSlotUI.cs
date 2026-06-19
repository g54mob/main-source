using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class SaveSlotUI : MonoBehaviour
{
	private SaveSlotsMenu _slotsMenu;

	private int _slotIndex;

	[SerializeField]
	private LocalizeStringEvent _titleText;

	[SerializeField]
	private LocalizedString _slotEmptyString;

	[SerializeField]
	private LocalizedString _progressString;

	[SerializeField]
	private LocalizeStringEvent _stateText;

	[SerializeField]
	private CanvasGroup _deleteButtonCanvasGroup;

	[SerializeField]
	private float _deleteButtonDisabledAlpha;

	[SerializeField]
	private float _deleteButtonEnabledAlpha;

	[SerializeField]
	private CanvasGroup _slotButtonCanvasGroup;

	private int Index;

	private WorldMetaData WorldMetaData;

	public void Initiate(SaveSlotsMenu slotsMenu, int index)
	{
	}

	public void RetrieveWorldSlotData()
	{
	}

	public void Render()
	{
	}

	public void SelectSlot()
	{
	}

	public void DeleteSlot()
	{
	}
}
