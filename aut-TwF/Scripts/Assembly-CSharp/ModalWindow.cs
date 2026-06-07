using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ModalWindow : MonoBehaviour
{
	[SerializeField]
	protected GameObject headerGroup;

	[SerializeField]
	protected TextMeshProUGUI headerText;

	[SerializeField]
	protected Button yesButton;

	[SerializeField]
	protected Button noButton;

	protected Action yesAction;

	protected Action noAction;

	public virtual void YesPressed()
	{
		if (yesAction != null)
		{
			yesAction();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual void NoPressed()
	{
		if (noAction != null)
		{
			noAction();
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public virtual void CancelPressed()
	{
		if (noButton.gameObject.activeSelf)
		{
			NoPressed();
		}
		else
		{
			YesPressed();
		}
	}
}
