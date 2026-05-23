using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonShortcut : MonoBehaviour
{
	public string inputId;

	public bool triggerOnRelease;

	public Button selectAfterClick;

	private bool ignoredFirstFrame;

	private bool ignoreUntilRelease;

	private int actionIndex = -1;

	private void OnEnable()
	{
		ignoredFirstFrame = false;
		ignoreUntilRelease = true;
		actionIndex = RInput.GetActionIndex(inputId);
	}

	private void Update()
	{
		if (EventSystem.current == null)
		{
			return;
		}
		if (!ignoredFirstFrame)
		{
			ignoredFirstFrame = true;
			return;
		}
		if (ignoreUntilRelease)
		{
			if (!RInput.GetButton(actionIndex))
			{
				ignoreUntilRelease = false;
			}
			return;
		}
		Button component = GetComponent<Button>();
		if (!(component != null) || !component.interactable)
		{
			return;
		}
		if (triggerOnRelease)
		{
			if (RInput.GetButtonDown(actionIndex))
			{
				component.Select();
			}
			else if (EventSystem.current.currentSelectedGameObject == base.gameObject && RInput.GetButtonUp(actionIndex))
			{
				Debug.LogFormat("ButtonShortcut: {0} from {1}", inputId, Util.GetObjectPath(component.gameObject));
				component.onClick.Invoke();
				if (selectAfterClick != null)
				{
					selectAfterClick.Select();
				}
			}
		}
		else if (RInput.GetButtonDown(actionIndex))
		{
			Debug.LogFormat("ButtonShortcut: {0} from {1}", inputId, Util.GetObjectPath(component.gameObject));
			component.Select();
			component.onClick.Invoke();
			if (selectAfterClick != null)
			{
				selectAfterClick.Select();
			}
		}
	}
}
