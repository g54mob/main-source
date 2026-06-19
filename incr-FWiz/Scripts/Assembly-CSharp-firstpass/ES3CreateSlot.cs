using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ES3CreateSlot : MonoBehaviour
{
	[Tooltip("The button used to bring up the 'Create Slot' dialog.")]
	public Button createButton;

	[Tooltip("The ES3SlotDialog Component of the Create Slot dialog")]
	public ES3SlotDialog createDialog;

	[Tooltip("The TMP_Text input text field of the create slot dialog.")]
	public TMP_InputField inputField;

	[Tooltip("The ES3SlotManager this Create Slot Dialog belongs to.")]
	public ES3SlotManager mgr;

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected void ShowCreateSlotDialog()
	{
	}

	public virtual void TryCreateNewSlot()
	{
	}
}
