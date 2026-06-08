using UnityEngine;
using UnityEngine.UI;

public class UITextLabel : MonoBehaviour
{
	public Text label;

	public Image border;

	protected Color activeBorderColor = Color.blue;

	protected Color inactiveBorderColor = Color.gray;

	protected Color activeTextColor = Color.blue;

	protected Color inactiveTextColor = Color.gray;

	protected Color errorTextColor = Color.red;

	protected Color errorBorderColor = Color.red;

	public bool IsError { get; private set; }

	public bool IsActive { get; private set; }

	public Image backgroundImage { get; protected set; }

	protected virtual void Awake()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
	}

	protected virtual void OnDestroy()
	{
		label = null;
		border = null;
		backgroundImage = null;
	}

	protected virtual void Start()
	{
	}

	public void SetActive()
	{
		IsError = false;
		IsActive = true;
		if (border != null)
		{
			border.color = activeBorderColor;
		}
		else
		{
			backgroundImage.color = activeBorderColor;
		}
		label.color = activeTextColor;
	}

	public void SetInactive()
	{
		IsError = false;
		IsActive = false;
		if (border != null)
		{
			border.color = inactiveBorderColor;
		}
		else
		{
			backgroundImage.color = inactiveBorderColor;
		}
		label.color = inactiveTextColor;
	}

	public void SetError()
	{
		IsError = true;
		if (border != null)
		{
			border.color = errorTextColor;
		}
		else
		{
			backgroundImage.color = errorTextColor;
		}
		label.color = ModificationUI.Instance.errorTextColor;
	}
}
