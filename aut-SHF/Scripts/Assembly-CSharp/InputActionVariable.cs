using UnityEngine.InputSystem;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

internal struct InputActionVariable : IVariable
{
	private InputAction m_Action;

	private string m_Type;

	public object GetSourceValue(ISelectorInfo _)
	{
		return null;
	}

	public InputActionVariable(InputAction action, string type = "")
	{
		m_Action = null;
		m_Type = null;
	}

	private string GetSpriteFont(InputBinding binding)
	{
		return null;
	}

	private string GetInputForPath(string path)
	{
		return null;
	}

	private string GetInputForBinding(InputBinding binding)
	{
		return null;
	}
}
