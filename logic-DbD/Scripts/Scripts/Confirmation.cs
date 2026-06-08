using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Confirmation : MonoBehaviour
{
	[SerializeField]
	private Button yes;

	[SerializeField]
	private Button no;

	[SerializeField]
	private Toolbar toolbar;

	[SerializeField]
	private TextMeshProUGUI textBody;

	private InputAction enterActions;

	private void Start()
	{
		enterActions = GetComponent<PlayerInput>().actions["Enter"];
		enterActions.performed += EnterAction;
	}

	public void EnterAction(InputAction.CallbackContext context)
	{
		EnterAction();
	}

	public void EnterAction()
	{
		Transform parent = base.transform.parent;
		if (parent.GetChild(parent.childCount - UIUtils.PANEL_SPAWN_LAYER) == base.transform)
		{
			(yes.IsActive() ? yes : no).onClick.Invoke();
		}
	}

	private void OnDestroy()
	{
		enterActions.performed -= EnterAction;
	}

	public void SetYesButton(UnityAction func)
	{
		yes.onClick.AddListener(func);
	}

	public void SetNoButton(UnityAction func)
	{
		no.onClick.AddListener(func);
	}

	public void SetYesButtonText(string text)
	{
		yes.GetComponentInChildren<TextMeshProUGUI>().text = text;
	}

	public void SetNoButtonText(string text)
	{
		no.GetComponentInChildren<TextMeshProUGUI>().text = text;
	}

	public void SetText(string bodyText)
	{
		textBody.text = bodyText;
	}

	public Toolbar GetToolbar()
	{
		return toolbar;
	}

	public void DisableClose()
	{
		Object.Destroy(toolbar.GetComponentInChildren<Button>().gameObject);
		yes.gameObject.SetActive(value: false);
	}
}
