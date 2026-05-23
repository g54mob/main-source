using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
[DisplayName("Input Action Formatter", null)]
public class InputActionFormatter : FormatterBase, IVariableValueChanged, IVariable
{
	private static MstGameActionSpriteFont mst;

	private Dictionary<string, string> _spriteFontCache;

	private Dictionary<string, InputAction> _actionCache;

	private Dictionary<string, string> _formatResultCache;

	private Dictionary<string, string> _inputPathCache;

	private int _lastTriggerFrame;

	private readonly int _minTriggerFrameInterval;

	public override string[] DefaultNames => null;

	public event Action<IVariable> ValueChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
	{
		return false;
	}

	public void TriggerChange()
	{
	}

	private void AppendBindingOutput(StringBuilder sb, InputBinding binding, InputBinding fallbackBinding)
	{
	}

	private void VariableTriggerRegistration(IFormattingInfo formattingInfo)
	{
	}

	public InputAction GetAction(string actionName)
	{
		return null;
	}

	public object GetSourceValue(ISelectorInfo selector)
	{
		return null;
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

	public void ClearCache()
	{
	}
}
