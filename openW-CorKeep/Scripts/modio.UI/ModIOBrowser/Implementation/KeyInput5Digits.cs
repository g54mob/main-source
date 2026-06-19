using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class KeyInput5Digits : MonoBehaviour
	{
		public bool copyPasteMode;

		public bool debug;

		public string currentInputString;

		public int index;

		private int maxDigits;

		private Action<string> onFinish;

		private Action<string> renderOutput;

		private List<KeyCode> keyCodes = new List<KeyCode>();

		private Dictionary<KeyCode, string> keyCodeOverrides = new Dictionary<KeyCode, string>();

		public void Setup()
		{
			keyCodes.AddRange(GetRelevantKeys(KeyCode.Alpha0, KeyCode.Alpha9));
			keyCodes.AddRange(GetRelevantKeys(KeyCode.Keypad0, KeyCode.Keypad9));
			keyCodes.AddRange(GetRelevantKeys(KeyCode.A, KeyCode.Z));
			SetupKeyCodeStringOverrides();
		}

		private IEnumerable<KeyCode> GetRelevantKeys(KeyCode begin, KeyCode end)
		{
			for (KeyCode k = begin; k <= end; k++)
			{
				yield return k;
			}
		}

		private void SetupKeyCodeStringOverrides()
		{
			keyCodeOverrides.Add(KeyCode.Alpha0, "0");
			keyCodeOverrides.Add(KeyCode.Alpha1, "1");
			keyCodeOverrides.Add(KeyCode.Alpha2, "2");
			keyCodeOverrides.Add(KeyCode.Alpha3, "3");
			keyCodeOverrides.Add(KeyCode.Alpha4, "4");
			keyCodeOverrides.Add(KeyCode.Alpha5, "5");
			keyCodeOverrides.Add(KeyCode.Alpha6, "6");
			keyCodeOverrides.Add(KeyCode.Alpha7, "7");
			keyCodeOverrides.Add(KeyCode.Alpha8, "8");
			keyCodeOverrides.Add(KeyCode.Alpha9, "9");
			keyCodeOverrides.Add(KeyCode.Keypad0, "0");
			keyCodeOverrides.Add(KeyCode.Keypad1, "1");
			keyCodeOverrides.Add(KeyCode.Keypad2, "2");
			keyCodeOverrides.Add(KeyCode.Keypad3, "3");
			keyCodeOverrides.Add(KeyCode.Keypad4, "4");
			keyCodeOverrides.Add(KeyCode.Keypad5, "5");
			keyCodeOverrides.Add(KeyCode.Keypad6, "6");
			keyCodeOverrides.Add(KeyCode.Keypad7, "7");
			keyCodeOverrides.Add(KeyCode.Keypad8, "8");
			keyCodeOverrides.Add(KeyCode.Keypad9, "9");
		}

		public void NewSession(int maxDigits, Action<string> renderOutput, Action<string> onFinish)
		{
			this.maxDigits = maxDigits;
			this.onFinish = onFinish;
			this.renderOutput = renderOutput;
			SetIndex(0);
			currentInputString = new string(' ', maxDigits);
			this.renderOutput(currentInputString);
			base.gameObject.SetActive(value: true);
		}

		public void EndSession()
		{
			base.gameObject.SetActive(value: false);
		}

		private void AddToInput(KeyCode keyCode)
		{
			string toInput = (keyCodeOverrides.ContainsKey(keyCode) ? keyCodeOverrides[keyCode] : keyCode.ToString());
			SetToInput(toInput);
		}

		private void SetToInput(string s)
		{
			StringBuilder stringBuilder = new StringBuilder(currentInputString);
			if (s.Length == 1)
			{
				stringBuilder[index] = s.ToUpper().ToCharArray().First();
				SetIndex(index + 1);
			}
			else
			{
				string text = s.ToUpper();
				foreach (char value in text)
				{
					stringBuilder[index] = value;
					index++;
					if (index >= maxDigits)
					{
						break;
					}
				}
			}
			SetIndex(index);
			currentInputString = stringBuilder.ToString();
			if (currentInputString.Length > maxDigits)
			{
				currentInputString = currentInputString.Substring(0, maxDigits);
			}
			renderOutput(currentInputString);
		}

		private void Update()
		{
			if (CopyPaste() || Backspace() || Enter())
			{
				return;
			}
			foreach (KeyCode keyCode in keyCodes)
			{
				if (GetKeyUp(keyCode))
				{
					AddToInput(keyCode);
				}
			}
		}

		private bool Enter()
		{
			if (GetKeyUp(KeyCode.Return) || GetKeyUp(KeyCode.KeypadEnter))
			{
				onFinish(currentInputString);
				return true;
			}
			return false;
		}

		private bool Backspace()
		{
			if (GetKeyUp(KeyCode.Backspace))
			{
				StringBuilder stringBuilder = new StringBuilder(currentInputString);
				if (index < maxDigits - 1 || stringBuilder[index] == ' ')
				{
					SetIndex(Math.Max(0, index - 1));
				}
				stringBuilder[index] = ' ';
				currentInputString = stringBuilder.ToString();
				renderOutput(currentInputString);
				return true;
			}
			return false;
		}

		public bool CopyPaste()
		{
			if (GetKeyDown(KeyCode.LeftControl) || GetKeyDown(KeyCode.RightControl))
			{
				copyPasteMode = true;
			}
			else if (GetKeyUp(KeyCode.LeftControl) || GetKeyUp(KeyCode.RightControl))
			{
				copyPasteMode = false;
				return false;
			}
			if (!copyPasteMode && (GetKey(KeyCode.LeftControl) || GetKeyDown(KeyCode.RightControl)))
			{
				copyPasteMode = true;
			}
			if (copyPasteMode && GetKeyUp(KeyCode.V))
			{
				SetToInput(GUIUtility.systemCopyBuffer);
				return true;
			}
			return false;
		}

		public string GetValues()
		{
			return currentInputString;
		}

		public void SetIndex(int i)
		{
			index = Math.Min(Math.Max(i, 0), maxDigits - 1);
		}

		public static bool GetKeyDown(KeyCode keyCode)
		{
			return Input.GetKeyDown(keyCode);
		}

		public static bool GetKeyUp(KeyCode keyCode)
		{
			return Input.GetKeyUp(keyCode);
		}

		public static bool GetKey(KeyCode keyCode)
		{
			return Input.GetKey(keyCode);
		}

		public static float GetAxis(string axis)
		{
			return Input.GetAxis(axis);
		}
	}
}
