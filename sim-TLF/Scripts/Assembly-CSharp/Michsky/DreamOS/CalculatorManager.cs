using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class CalculatorManager : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI displayText;

		[SerializeField]
		private TextMeshProUGUI displayOperator;

		[SerializeField]
		private TextMeshProUGUI displayResult;

		[SerializeField]
		private TextMeshProUGUI displayPreview;

		private float rememberValue;

		private string previousAction;

		private bool pressedOperators;

		private bool enableDot = true;

		private bool isResetted = true;

		private void Awake()
		{
			try
			{
				displayText.text = "0";
				displayResult.text = "0";
				displayPreview.text = "";
			}
			catch
			{
				Debug.LogError("Calculator - Display resources are not assigned.", this);
			}
		}

		public void ButtonNumber(int number)
		{
			if (displayText.text != "0")
			{
				displayText.text += number;
			}
			else
			{
				displayText.text = number.ToString();
			}
			if (pressedOperators)
			{
				displayText.text = number.ToString();
				pressedOperators = false;
				enableDot = true;
			}
		}

		public void ButtonDot()
		{
			if (enableDot)
			{
				displayText.text += ".";
				enableDot = false;
			}
		}

		public void ButtonDelete()
		{
			if (displayText.text.Length >= 2)
			{
				displayText.text = displayText.text.Remove(displayText.text.Length - 1);
				return;
			}
			displayText.text = "0";
			enableDot = true;
		}

		public void ButtonDivision()
		{
			if (!isResetted)
			{
				if (rememberValue == 0f)
				{
					float num = float.Parse(displayResult.text) / float.Parse(displayText.text);
					displayResult.text = num.ToString();
					displayOperator.text = "÷";
					previousAction = "ButtonDivision";
					pressedOperators = true;
					displayPreview.text = "";
				}
				else
				{
					float num2 = rememberValue / float.Parse(displayText.text);
					displayResult.text = num2.ToString();
					displayOperator.text = "÷";
					previousAction = "ButtonDivision";
					pressedOperators = true;
					displayPreview.text = "";
					rememberValue = 0f;
				}
			}
			else
			{
				rememberValue = float.Parse(displayText.text);
				displayPreview.text = rememberValue + " ÷";
				displayOperator.text = "÷";
				previousAction = "ButtonDivision";
				pressedOperators = true;
				isResetted = false;
			}
		}

		public void ButtonMultiply()
		{
			if (!isResetted)
			{
				if (rememberValue == 0f)
				{
					float num = float.Parse(displayResult.text) * float.Parse(displayText.text);
					displayResult.text = num.ToString();
					displayOperator.text = "×";
					previousAction = "ButtonMultiply";
					pressedOperators = true;
					displayPreview.text = "";
				}
				else
				{
					float num2 = rememberValue * float.Parse(displayText.text);
					displayResult.text = num2.ToString();
					displayOperator.text = "×";
					previousAction = "ButtonMultiply";
					pressedOperators = true;
					displayPreview.text = "";
					rememberValue = 0f;
				}
			}
			else
			{
				rememberValue = float.Parse(displayText.text);
				displayPreview.text = rememberValue + " ×";
				displayOperator.text = "×";
				previousAction = "ButtonMultiply";
				pressedOperators = true;
				isResetted = false;
			}
		}

		public void ButtonSubtraction()
		{
			if (!isResetted)
			{
				if (rememberValue == 0f)
				{
					float num = float.Parse(displayResult.text) - float.Parse(displayText.text);
					displayResult.text = num.ToString();
					displayOperator.text = "-";
					previousAction = "ButtonSubtraction";
					pressedOperators = true;
					displayPreview.text = "";
				}
				else
				{
					float num2 = rememberValue - float.Parse(displayText.text);
					displayResult.text = num2.ToString();
					displayOperator.text = "-";
					previousAction = "ButtonSubtraction";
					pressedOperators = true;
					displayPreview.text = "";
					rememberValue = 0f;
				}
			}
			else
			{
				rememberValue = float.Parse(displayText.text);
				displayPreview.text = rememberValue + " -";
				displayOperator.text = "-";
				previousAction = "ButtonSubtraction";
				pressedOperators = true;
				isResetted = false;
			}
		}

		public void ButtonAddition()
		{
			if (!isResetted)
			{
				if (rememberValue == 0f)
				{
					float num = float.Parse(displayResult.text) + float.Parse(displayText.text);
					displayResult.text = num.ToString();
					displayOperator.text = "+";
					previousAction = "ButtonAddition";
					pressedOperators = true;
					displayPreview.text = "";
				}
				else
				{
					float num2 = rememberValue + float.Parse(displayText.text);
					displayResult.text = num2.ToString();
					displayOperator.text = "+";
					previousAction = "ButtonAddition";
					pressedOperators = true;
					displayPreview.text = "";
					rememberValue = 0f;
				}
			}
			else
			{
				rememberValue = float.Parse(displayText.text);
				displayPreview.text = rememberValue + " +";
				displayOperator.text = "+";
				previousAction = "ButtonAddition";
				pressedOperators = true;
				isResetted = false;
			}
		}

		public void ButtonEqual()
		{
			Invoke(previousAction, 0f);
		}

		public void ButtonAC()
		{
			displayText.text = "0";
			displayResult.text = "0";
			displayPreview.text = "";
			enableDot = true;
			isResetted = true;
		}
	}
}
