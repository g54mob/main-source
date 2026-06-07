using TMPro;

namespace Presentation.UI.Utils
{
	public class InputFieldWithPastePrevention : TMP_InputField
	{
		protected override void Append(string input)
		{
			if (input.Length <= 1)
			{
				base.Append(input);
			}
		}
	}
}
