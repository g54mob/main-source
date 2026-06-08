using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputFieldFileEditor : InputField
{
	private int prevFrameCaretPosition;

	private bool setPosAtNextFrame;

	private bool closeOnNextUpdate;

	private bool setCaratOnNextUpdate;

	private int newCaretPos = -1;

	private int newCaretSelPos = -1;

	public string originalText { get; set; }

	public override void OnMove(AxisEventData eventData)
	{
		base.OnMove(eventData);
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		base.OnSubmit(eventData);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
	}

	public override void OnUpdateSelected(BaseEventData eventData)
	{
		if (closeOnNextUpdate)
		{
			closeOnNextUpdate = false;
			DungeonManager.Instance.CloseAliasWindow();
			return;
		}
		if (setCaratOnNextUpdate)
		{
			base.caretPosition = newCaretPos;
			m_CaretSelectPosition = newCaretSelPos;
			setCaratOnNextUpdate = false;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			DeactivateInputField();
			Input.ResetInputAxes();
			if (!string.Equals(originalText, base.text))
			{
				base.enabled = false;
				DialogUI.Instance.ShowDialog("Are You Sure", "Changes have been made that will be lost if you close the window.\r\n\r\nAre you sure?", ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.Yes)
					{
						DungeonManager.Instance.CloseAliasWindow();
					}
					else
					{
						base.enabled = true;
						SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
						ActivateInputField();
						base.caretPosition = prevFrameCaretPosition;
						m_CaretSelectPosition = prevFrameCaretPosition;
					}
				}, 1);
			}
			else
			{
				DungeonManager.Instance.CloseAliasWindow();
			}
			return;
		}
		base.OnUpdateSelected(eventData);
		if (setPosAtNextFrame)
		{
			UpdateLabel();
			setPosAtNextFrame = false;
		}
		int length = base.text.Length;
		bool flag = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		if (!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.RightAlt))
		{
			if (SceneLevelInput.DisableCtrlOnAlias || (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl)))
			{
				if (Input.GetKeyDown(KeyCode.End))
				{
					ActivateInputField();
					if (prevFrameCaretPosition < length)
					{
						for (int num = prevFrameCaretPosition; num < length; num++)
						{
							char c = base.text[num];
							if (c == '\n')
							{
								setPosAtNextFrame = true;
								base.caretPosition = num;
								if (!flag)
								{
									m_CaretSelectPosition = num;
								}
								else
								{
									m_CaretSelectPosition = prevFrameCaretPosition;
								}
								break;
							}
						}
					}
				}
				else if (Input.GetKeyDown(KeyCode.Home))
				{
					if (prevFrameCaretPosition > 0)
					{
						for (int num2 = prevFrameCaretPosition - 1; num2 >= 0; num2--)
						{
							char c2 = base.text[num2];
							if (c2 == '\n')
							{
								setPosAtNextFrame = true;
								base.caretPosition = num2 + 1;
								if (!flag)
								{
									m_CaretSelectPosition = num2 + 1;
								}
								else
								{
									m_CaretSelectPosition = prevFrameCaretPosition;
								}
								break;
							}
						}
					}
				}
				else if (Input.GetButtonDown("Up") && prevFrameCaretPosition > 0 && prevFrameCaretPosition == length)
				{
					for (int num3 = prevFrameCaretPosition - 1; num3 >= 0; num3--)
					{
						char c3 = base.text[num3];
						if (c3 == '\n')
						{
							setPosAtNextFrame = true;
							base.caretPosition = num3;
							if (!flag)
							{
								m_CaretSelectPosition = num3;
							}
							else
							{
								m_CaretSelectPosition = prevFrameCaretPosition;
							}
							break;
						}
					}
				}
			}
			else if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.S))
			{
				DeactivateInputField();
				if (Input.GetButtonDown("Down"))
				{
					setPosAtNextFrame = true;
					base.caretPosition = length;
					if (!flag)
					{
						m_CaretSelectPosition = base.caretPosition;
					}
					else
					{
						m_CaretSelectPosition = prevFrameCaretPosition;
					}
				}
				else if (Input.GetKeyDown(KeyCode.S))
				{
					SaveAndClose(false);
				}
			}
		}
		else if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.S)))
		{
			DeactivateInputField();
			if (Input.GetKeyDown(KeyCode.V))
			{
				if (ValidateButtonPressed())
				{
					newCaretPos = prevFrameCaretPosition;
					newCaretSelPos = prevFrameCaretPosition;
					DialogUI.Instance.ShowDialog("No Validation Errors", "The file looks OK.\r\n\r\nKeep in mind that only the structure, and not the contents, have been evaluated.", ModalWindowType.OK, delegate
					{
						base.enabled = true;
						SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
						ActivateInputField();
						setCaratOnNextUpdate = true;
					});
				}
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				SaveAndClose(false);
			}
		}
		prevFrameCaretPosition = base.caretPosition;
	}

	private bool ValidateButtonPressed()
	{
		return ValidateButtonPressed(false);
	}

	private bool ValidateButtonPressed(bool validateOnClose)
	{
		int num = 0;
		bool flag = false;
		int idxMissingValue = -1;
		int num2 = 0;
		bool flag2 = false;
		int idxStartDuplicatedKeyValue = -1;
		int num3 = -1;
		int num4 = 0;
		bool flag3 = false;
		int idxStartInvalidLine = -1;
		int num5 = -1;
		int num6 = 0;
		DeactivateInputField();
		base.enabled = false;
		if (base.text.Length == 0)
		{
			return true;
		}
		do
		{
			num = base.text.IndexOf('=', num + 1);
			if (num > 0)
			{
				if (base.text[num - 1] != '\n')
				{
					int num7 = base.text.IndexOf('\n', num);
					if (num7 < 0)
					{
						num7 = base.text.Length;
					}
					if (num7 > num + 1)
					{
						string text = base.text.Substring(num, num7 - num - 1);
						if (string.IsNullOrEmpty(text.Trim()))
						{
							num2++;
							if (!flag)
							{
								flag = true;
								idxMissingValue = num7;
							}
						}
					}
					else
					{
						num2++;
						if (!flag)
						{
							flag = true;
							idxMissingValue = num7;
						}
					}
				}
				else
				{
					num2++;
					if (!flag)
					{
						flag = true;
						idxMissingValue = num;
					}
				}
			}
			else if (num == 0)
			{
				num2++;
				if (!flag)
				{
					flag = true;
					idxMissingValue = num;
				}
			}
		}
		while (num > 0);
		if (flag)
		{
			if (!validateOnClose)
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} validation errors.", num2), ModalWindowType.OK, delegate
				{
					base.enabled = true;
					SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
					ActivateInputField();
					newCaretPos = idxMissingValue;
					newCaretSelPos = idxMissingValue;
					setCaratOnNextUpdate = true;
				}, 0);
			}
			else
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} validation errors.\r\n\r\nReturn to the file to fix them?", num2), ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputResult)
				{
					if (result == ModalWindowResult.No)
					{
						SaveAndClose(true);
					}
					else
					{
						base.enabled = true;
						SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
						ActivateInputField();
						newCaretPos = idxMissingValue;
						newCaretSelPos = idxMissingValue;
						setCaratOnNextUpdate = true;
					}
				}, 0);
			}
			return false;
		}
		string[] array = base.text.Split(new char[1] { '\n' }, StringSplitOptions.None);
		int num8 = array.Length;
		List<string> list = new List<string>(num8);
		for (int num9 = 0; num9 < num8; num9++)
		{
			string[] array2 = array[num9].Split(new char[1] { '=' }, StringSplitOptions.None);
			if (array2.Length == 2)
			{
				if (string.IsNullOrEmpty(array2[0]))
				{
					continue;
				}
				if (!list.Contains(array2[0]))
				{
					list.Add(array2[0]);
					continue;
				}
				num4++;
				if (!flag2)
				{
					flag2 = true;
					int num10 = base.text.IndexOf(array2[0]);
					num3 = (idxStartDuplicatedKeyValue = base.text.IndexOf(array2[0], num10 + 1)) + array2[0].Length;
				}
			}
			else if (array2.Length == 1 && !string.IsNullOrEmpty(array2[0]))
			{
				num6++;
				if (!flag3)
				{
					flag3 = true;
					idxStartInvalidLine = base.text.IndexOf(array2[0]);
					num5 = idxStartInvalidLine + array2[0].Length;
				}
			}
		}
		if (flag2)
		{
			if (!validateOnClose)
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} duplicate key errors.", num2), ModalWindowType.OK, delegate
				{
					base.enabled = true;
					SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
					ActivateInputField();
					newCaretPos = idxStartDuplicatedKeyValue;
					newCaretSelPos = idxStartDuplicatedKeyValue;
					setCaratOnNextUpdate = true;
				}, 0);
			}
			else
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} duplicate key errors.\r\n\r\nOnly the first one of each will be available in the game.\r\n\r\nReturn to the file to fix them?", num4), ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputResult)
				{
					if (result == ModalWindowResult.No)
					{
						SaveAndClose(true);
					}
					else
					{
						base.enabled = true;
						SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
						ActivateInputField();
						newCaretPos = idxStartDuplicatedKeyValue;
						newCaretSelPos = idxStartDuplicatedKeyValue;
						setCaratOnNextUpdate = true;
					}
				}, 0);
			}
			return false;
		}
		if (flag3)
		{
			if (!validateOnClose)
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} invalid rows.", num6), ModalWindowType.OK, delegate
				{
					base.enabled = true;
					SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
					ActivateInputField();
					newCaretPos = idxStartInvalidLine;
					newCaretSelPos = idxStartInvalidLine;
					setCaratOnNextUpdate = true;
				}, 0);
			}
			else
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} invalid rows.\r\n\r\nReturn to the file to fix them?", num6), ModalWindowType.YesNo, delegate(ModalWindowResult result, string inputResult)
				{
					if (result == ModalWindowResult.No)
					{
						SaveAndClose(true);
					}
					else
					{
						base.enabled = true;
						SystemEvents.Instance.eventSystem.SetSelectedGameObject(base.gameObject);
						ActivateInputField();
						newCaretPos = idxStartInvalidLine;
						newCaretSelPos = idxStartInvalidLine;
						setCaratOnNextUpdate = true;
					}
				}, 0);
			}
			return false;
		}
		return true;
	}

	private void HighlightInvalidRow(string line, int rowIndex)
	{
		int num = line.IndexOf('=');
		bool flag = true;
		if (num > -1)
		{
			int num2 = line.IndexOf('=', num + 1);
			if (num2 > -1)
			{
				num = num2;
				flag = false;
			}
		}
		if (flag)
		{
			num = ((num >= 0) ? ((num != 0) ? (num + 1) : (-1)) : 0);
		}
		HighlightInvalidRow(rowIndex, num);
	}

	private void HighlightInvalidRow(int rowIndex, int colIndex)
	{
	}

	private void SaveAndClose(bool skipValidation)
	{
		if (!skipValidation && !ValidateButtonPressed(true))
		{
			return;
		}
		string[] array = base.text.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		FileStream fileStream = null;
		fileStream = File.Open(GameFileHelper.AliasFullPath(), FileMode.Truncate);
		try
		{
			byte[] bytes = Encoding.ASCII.GetBytes(Environment.NewLine);
			string[] array2 = array;
			foreach (string s in array2)
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				int count = bytes2.Length;
				fileStream.Write(bytes2, 0, count);
				fileStream.Write(bytes, 0, bytes.Length);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("Error while writing alias file!  Exception: {0}", ex.Message));
			return;
		}
		finally
		{
			try
			{
				fileStream.Close();
			}
			catch (Exception)
			{
			}
		}
		DungeonManager.Instance.CloseAliasWindow();
	}
}
