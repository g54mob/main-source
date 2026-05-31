using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class SaveEntry : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler, IPointerClickHandler
{
	private const float k_FocusScale = 1.05f;

	[SerializeField]
	private TMP_Text m_Title;

	[SerializeField]
	private TMP_Text m_Modified;

	[SerializeField]
	private TMP_Text m_LevelText;

	[SerializeField]
	private GameObject m_LevelTextContainer;

	[SerializeField]
	private GameObject m_EmptySlotTextContainer;

	[SerializeField]
	private TMP_Text m_SlotHeaderText;

	[SerializeField]
	private LocalizedString m_NewGameEntry;

	[SerializeField]
	private LocalizedString m_EmptySlotEntry;

	private SaveInfo m_SaveInfo;

	private Selectable m_Selectable;

	[SerializeField]
	private Button m_DeleteButton;

	private bool m_IsSlotAvailable;

	[SerializeField]
	private Outline m_SelectionOutline;

	[SerializeField]
	private LocalizedString[] m_SlotNames;

	public SaveInfo SaveInfo
	{
		get
		{
			return default(SaveInfo);
		}
		set
		{
		}
	}

	public Selectable Selectable => null;

	public Selectable DeleteButtonSelectable => null;

	public event Action DeleteRequested
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action Pressed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void UpdateUI()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnDeleteButtonClicked()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OnSubmit(BaseEventData eventData)
	{
	}

	public void SetSlotAvailability(bool value)
	{
	}

	public void OnSelect(BaseEventData eventData)
	{
	}

	public void OnDeselect(BaseEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void PlayFocus()
	{
	}

	private void PlayUnfocus()
	{
	}

	public void SetLocalizedStringEmptySlot()
	{
	}

	public void SetLocalizedStringNewGame()
	{
	}

	public void GamepadConfirm()
	{
	}
}
