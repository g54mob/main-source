using UnityEngine;

public class RewiredActionInfoBarContext : MonoBehaviour
{
	[SerializeField]
	[Tooltip("[OPTIONAL] The info bar the actions should be displayed in. When the info bar is not set the UIManager info bar will be used with this Object as context.")]
	private RewiredActionInfoBar _actionInfoBar;

	private void OnDisable()
	{
		Disable();
	}

	public void Disable()
	{
		if ((bool)_actionInfoBar)
		{
			_actionInfoBar.DisableContext(this);
		}
		else
		{
			UIManager.DisableRewiredActionInfoContext(this);
		}
	}

	public void AddActions(params IRewiredAction[] actions)
	{
		if ((bool)_actionInfoBar)
		{
			_actionInfoBar.AddActions(actions);
		}
		else
		{
			UIManager.AddRewiredActionInfoToContext(this, actions);
		}
	}

	public void RemoveActions(params IRewiredAction[] actions)
	{
		if ((bool)_actionInfoBar)
		{
			_actionInfoBar.RemoveActions(actions);
		}
		else
		{
			UIManager.RemoveActionInfoFromContext(this, actions);
		}
	}
}
