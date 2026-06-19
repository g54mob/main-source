using UnityEngine;
using UnityEngine.UI;

public class ES3SlotDialog : MonoBehaviour
{
	[Tooltip("The UnityEngine.UI.Button Component for the Confirm button.")]
	public Button confirmButton;

	[Tooltip("The UnityEngine.UI.Button Component for the Cancel button.")]
	public Button cancelButton;

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}
}
