using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ES3Slot : MonoBehaviour
{
	[Tooltip("The text label containing the slot name.")]
	public TMP_Text nameLabel;

	[Tooltip("The text label containing the last updated timestamp for the slot.")]
	public TMP_Text timestampLabel;

	[Tooltip("The confirmation dialog to show if showConfirmationIfExists is true.")]
	public GameObject confirmationDialog;

	public ES3SlotManager mgr;

	[Tooltip("The button for selecting this slot.")]
	public Button selectButton;

	[Tooltip("The button for deleting this slot.")]
	public Button deleteButton;

	[Tooltip("The button for undoing the deletion of this slot.")]
	public Button undoButton;

	public bool markedForDeletion;

	public virtual void OnEnable()
	{
	}

	public virtual void OnDisable()
	{
	}

	protected virtual void TrySelectSlot()
	{
	}

	public virtual void SelectSlot()
	{
	}

	protected virtual void MarkSlotForDeletion()
	{
	}

	protected virtual void UnmarkSlotForDeletion()
	{
	}

	protected virtual void OverwriteThenSelectSlot()
	{
	}

	public virtual void DeleteSlot()
	{
	}

	public virtual string GetSlotPath()
	{
		return null;
	}

	public void MoveToTop()
	{
	}
}
