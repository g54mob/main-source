using System;
using System.Globalization;
using Dhs5.Utility.Debuggers;
using Dhs5.Utility.Updates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_CardMachine : MonoBehaviour, IUIInputReceiver
	{
		[Header("Main Components")]
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private GraphicRaycaster m_raycaster;

		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private NavBox m_buttonsContainer;

		[Header("UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_totalText;

		[Space(10f)]
		[SerializeField]
		private Button m_1Button;

		[SerializeField]
		private Button m_2Button;

		[SerializeField]
		private Button m_3Button;

		[SerializeField]
		private Button m_4Button;

		[SerializeField]
		private Button m_5Button;

		[SerializeField]
		private Button m_6Button;

		[SerializeField]
		private Button m_7Button;

		[SerializeField]
		private Button m_8Button;

		[SerializeField]
		private Button m_9Button;

		[SerializeField]
		private Button m_0Button;

		[SerializeField]
		private Button m_comaButton;

		[SerializeField]
		private Button m_backButton;

		[SerializeField]
		private Button m_eraseButton;

		[SerializeField]
		private Button m_validateButton;

		[Header("Parameters")]
		[SerializeField]
		private CursorState m_cursor;

		private string m_currentValue;

		private NavButton[] m_inputs;

		private CultureInfo CultureInfo => CultureInfo.InvariantCulture;

		private string NumberDecimalSeparator => CultureInfo.NumberFormat.NumberDecimalSeparator;

		public event Action<int> OnUIButtonSelected;

		public event Action<float> Validated;

		public event Action OnButtonClicked;

		private void OnEnable()
		{
			m_inputs = m_buttonsContainer.GetComponentsInChildren<NavButton>();
			NavButton[] inputs = m_inputs;
			foreach (NavButton obj in inputs)
			{
				obj.SelectElementEvent = (Action<RectTransform>)Delegate.Combine(obj.SelectElementEvent, new Action<RectTransform>(OnChildSelect));
			}
			m_currentValue = "";
			UpdateContent();
			m_1Button.onClick.AddListener(delegate
			{
				OnNumericButton("1");
			});
			m_2Button.onClick.AddListener(delegate
			{
				OnNumericButton("2");
			});
			m_3Button.onClick.AddListener(delegate
			{
				OnNumericButton("3");
			});
			m_4Button.onClick.AddListener(delegate
			{
				OnNumericButton("4");
			});
			m_5Button.onClick.AddListener(delegate
			{
				OnNumericButton("5");
			});
			m_6Button.onClick.AddListener(delegate
			{
				OnNumericButton("6");
			});
			m_7Button.onClick.AddListener(delegate
			{
				OnNumericButton("7");
			});
			m_8Button.onClick.AddListener(delegate
			{
				OnNumericButton("8");
			});
			m_9Button.onClick.AddListener(delegate
			{
				OnNumericButton("9");
			});
			m_0Button.onClick.AddListener(delegate
			{
				OnNumericButton("0");
			});
			m_comaButton.onClick.AddListener(OnComaButton);
			m_backButton.onClick.AddListener(OnBackButton);
			m_eraseButton.onClick.AddListener(OnEraseButton);
			m_validateButton.onClick.AddListener(OnValidateButton);
		}

		private void OnDisable()
		{
			NavButton[] inputs = m_inputs;
			foreach (NavButton obj in inputs)
			{
				obj.SelectElementEvent = (Action<RectTransform>)Delegate.Remove(obj.SelectElementEvent, new Action<RectTransform>(OnChildSelect));
			}
			m_1Button.onClick.RemoveAllListeners();
			m_2Button.onClick.RemoveAllListeners();
			m_3Button.onClick.RemoveAllListeners();
			m_4Button.onClick.RemoveAllListeners();
			m_5Button.onClick.RemoveAllListeners();
			m_6Button.onClick.RemoveAllListeners();
			m_7Button.onClick.RemoveAllListeners();
			m_8Button.onClick.RemoveAllListeners();
			m_9Button.onClick.RemoveAllListeners();
			m_0Button.onClick.RemoveAllListeners();
			m_comaButton.onClick.RemoveListener(OnComaButton);
			m_backButton.onClick.RemoveListener(OnBackButton);
			m_eraseButton.onClick.RemoveListener(OnEraseButton);
			m_validateButton.onClick.RemoveListener(OnValidateButton);
		}

		public void SetActive(bool active)
		{
			m_raycaster.enabled = active;
			RegisterUpdate(active);
			if (active)
			{
				m_canvas.worldCamera = TransientManager<CameraManager>.Instance.Camera;
				IUIInputReceiver.SetCurrent(this);
				CursorManager.SetBaseState(m_cursor);
				m_navBox.Cancelled += OnBackButton;
				m_navBox.RegisterToDeviceChange(register: true);
				m_navBox.SetActive();
			}
			else
			{
				IUIInputReceiver.SetCurrent(null);
				m_navBox.Cancelled -= OnBackButton;
				m_navBox.RegisterToDeviceChange(register: false);
			}
		}

		protected void RegisterUpdate(bool register)
		{
			Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdate);
		}

		protected virtual void OnUpdate(float deltaTime)
		{
			if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
			{
				OnBackButton();
				return;
			}
			string inputString = Input.inputString;
			if (!string.IsNullOrWhiteSpace(inputString))
			{
				if (int.TryParse(inputString, out var _))
				{
					m_currentValue += inputString;
					FormatCurrentValue();
					OnButtonClick();
				}
				else if (!m_currentValue.Contains(NumberDecimalSeparator) && (inputString == "." || inputString == ","))
				{
					m_currentValue += NumberDecimalSeparator;
					OnButtonClick();
				}
			}
		}

		private void UpdateContent()
		{
			string currencySymbol = GameplayApplicationOptions.GetCurrencySymbol();
			if (string.IsNullOrEmpty(m_currentValue))
			{
				m_totalText.text = "0" + NumberDecimalSeparator + "00" + currencySymbol;
			}
			else if (m_currentValue.Contains(NumberDecimalSeparator))
			{
				string text = m_currentValue.TrimStart('0');
				int num = text.IndexOf(NumberDecimalSeparator, StringComparison.InvariantCulture);
				if (num > text.Length - 3)
				{
					text += "00";
				}
				m_totalText.text = text.Substring(0, num + 3) + currencySymbol;
			}
			else
			{
				m_totalText.text = m_currentValue + NumberDecimalSeparator + "00" + currencySymbol;
			}
		}

		private void OnNumericButton(string num)
		{
			m_currentValue += num;
			FormatCurrentValue();
			OnButtonClick();
		}

		private void OnComaButton()
		{
			if (!m_currentValue.Contains(NumberDecimalSeparator))
			{
				m_currentValue += NumberDecimalSeparator;
				OnButtonClick();
			}
		}

		private void OnBackButton()
		{
			if (m_currentValue.Length != 0)
			{
				int num = 1;
				int num2 = m_currentValue.Length - 1;
				if (num2 != 0 && m_currentValue[num2] == NumberDecimalSeparator[0])
				{
					num++;
				}
				string currentValue = m_currentValue;
				int num3 = num;
				m_currentValue = currentValue.Substring(0, currentValue.Length - num3);
				OnButtonClick();
			}
		}

		private void OnEraseButton()
		{
			if (m_currentValue.Length != 0)
			{
				m_currentValue = "";
				OnButtonClick();
			}
		}

		private void OnValidateButton()
		{
			if (float.TryParse(m_currentValue, NumberStyles.Float, CultureInfo, out var result))
			{
				if (CashRegisterTransaction.Current.IsTransactionValid(result))
				{
					this.Validated?.Invoke(result);
				}
				else
				{
					Debugger<EDebugCategory>.LogWarning(EDebugCategory.CASH_REGISTER, "Money amount is not correct, you validated " + result + " when you should validate " + CashRegisterTransaction.Current.CheckedProductsCost, 0, onScreen: true);
				}
			}
		}

		private void OnButtonClick()
		{
			UpdateContent();
			this.OnButtonClicked?.Invoke();
		}

		private void FormatCurrentValue()
		{
			if (m_currentValue.Length != 0)
			{
				if (m_currentValue.Contains(NumberDecimalSeparator))
				{
					string[] array = m_currentValue.Split(NumberDecimalSeparator);
					string text = FormatIntegerPart(array[0]);
					string text2 = FormatDecimalPart(array[1]);
					m_currentValue = text + NumberDecimalSeparator + text2;
				}
				else
				{
					m_currentValue = FormatIntegerPart(m_currentValue);
				}
			}
			static string FormatDecimalPart(string decimalPart)
			{
				if (decimalPart.Length > PaymentSettings.MaxDecimalCount)
				{
					decimalPart = decimalPart.Substring(0, PaymentSettings.MaxDecimalCount);
				}
				return decimalPart;
			}
			static string FormatIntegerPart(string integerPart)
			{
				if (integerPart.Length > PaymentSettings.MaxIntegerCount)
				{
					integerPart = integerPart.Substring(0, PaymentSettings.MaxIntegerCount);
				}
				return integerPart;
			}
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_Space()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				OnValidateButton();
			}
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
		}

		public void OnUIInput_Submit()
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				OnValidateButton();
			}
		}

		public void OnUIInput_GamepadNorthButton()
		{
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
		}

		private void OnChildSelect(RectTransform transform)
		{
			for (int i = 0; i < m_inputs.Length; i++)
			{
				if (m_inputs[i].transform == transform)
				{
					this.OnUIButtonSelected?.Invoke(i);
					break;
				}
			}
		}
	}
}
