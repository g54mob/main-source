using UnityEngine.InputSystem;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Core.Extensions;

[DisplayName("Input Action Reference Formatter", null)]
public class InputActionReferenceFormatter : FormatterBase
{
	public override string[] DefaultNames => new string[1] { "inputAction" };

	public override bool TryEvaluateFormat(IFormattingInfo formattingInfo)
	{
		if (formattingInfo.CurrentValue is InputActionReference)
		{
			int bindingIndex = 0;
			try
			{
				bindingIndex = int.Parse(formattingInfo.FormatterOptions);
			}
			catch
			{
			}
			formattingInfo.Write((formattingInfo.CurrentValue as InputActionReference).action.GetBindingDisplayString(bindingIndex));
			return true;
		}
		return false;
	}
}
