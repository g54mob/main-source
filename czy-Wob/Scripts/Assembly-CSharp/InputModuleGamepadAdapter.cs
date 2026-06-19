using InControl;
using UnityEngine;

[RequireComponent(typeof(InControlInputModule))]
public class InputModuleGamepadAdapter : MonoBehaviour
{
	public class InputModuleActions : PlayerActionSet
	{
		public PlayerAction Submit;

		public PlayerAction Cancel;

		public InputModuleActions()
		{
			Submit = CreatePlayerAction("Submit");
			Cancel = CreatePlayerAction("Cancel");
		}
	}

	private InputModuleActions actions;

	private void OnEnable()
	{
		CreateActions();
		InControlInputModule component = GetComponent<InControlInputModule>();
		if (component != null)
		{
			component.SubmitAction = actions.Submit;
			component.CancelAction = actions.Cancel;
		}
	}

	private void OnDisable()
	{
		DestroyActions();
	}

	private void CreateActions()
	{
		actions = new InputModuleActions();
		actions.Submit.AddDefaultBinding(InputControlType.Action1);
		actions.Submit.AddDefaultBinding(Mouse.LeftButton);
		actions.Cancel.AddDefaultBinding(InputControlType.Action2);
		actions.Cancel.AddDefaultBinding(Key.Escape);
	}

	private void DestroyActions()
	{
		actions.Destroy();
	}
}
