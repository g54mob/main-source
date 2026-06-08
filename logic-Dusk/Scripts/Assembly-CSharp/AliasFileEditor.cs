using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class AliasFileEditor : NoteBaseWindow
{
	public AliasFileEditor()
		: base(new char[1] { ':' }, (float)Screen.width * 0.8f, (float)Screen.height * 0.8f)
	{
		base.windowTitle = "Alias File";
		Rect inputArea = noteEditor.InputArea;
		inputArea.x = (float)(Screen.width / 2) - windowRect.width / 2f;
		inputArea.y = (float)(Screen.height / 2) - windowRect.height / 2f;
		windowRect = inputArea;
		noteEditor.InputArea = new Rect(5f, 15f, windowRect.width - 15f, windowRect.height - 60f);
		base.showValidateButton = true;
	}

	public override void Initialize()
	{
		base.Initialize();
		string text = string.Empty;
		string[] array = File.ReadAllLines(GameFileHelper.AliasFullPath());
		if (array.Length > 0)
		{
			char[] separator = new char[1] { '=' };
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string text2 = array[i];
				string[] array2 = text2.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + text2 + "\n";
				}
			}
		}
		noteEditor.SetText(text);
	}

	protected override bool ValidateButtonPressed()
	{
		return ValidateButtonPressed(false);
	}

	protected bool ValidateButtonPressed(bool validateOnClose)
	{
		string[] array = noteEditor.Text.Split(new char[1] { '\n' }, StringSplitOptions.None);
		int num = array.Length;
		List<int> errorIndexList = new List<int>();
		string firstError = string.Empty;
		for (int i = 0; i < num; i++)
		{
			bool flag = false;
			string text = array[i];
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			string[] array2 = text.Split(new char[1] { '=' }, StringSplitOptions.RemoveEmptyEntries);
			if (array2.Length == 2)
			{
				if (array2[0].Trim() == string.Empty || array2[1].Trim() == string.Empty)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				errorIndexList.Add(i);
				if (firstError == string.Empty)
				{
					firstError = text;
				}
			}
		}
		if (errorIndexList.Count > 0)
		{
			if (!validateOnClose)
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} validation errors.", errorIndexList.Count), ModalWindowType.OK, delegate
				{
					HighlightInvalidRow(firstError, errorIndexList[0]);
				});
			}
			else
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} validation errors.\r\n\r\nReturn to the file to fix them?", errorIndexList.Count), ModalWindowType.YesNoCancel, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.No)
					{
						CloseButtonPressed(true);
					}
					else
					{
						HighlightInvalidRow(firstError, errorIndexList[0]);
					}
				});
			}
			return false;
		}
		for (int num2 = 0; num2 < num - 1; num2++)
		{
			if (!(array[num2].Trim() != string.Empty))
			{
				continue;
			}
			string[] array3 = array[num2].Split(new char[1] { '=' }, StringSplitOptions.RemoveEmptyEntries);
			for (int num3 = num2 + 1; num3 < num; num3++)
			{
				if (!(array[num3].Trim() != string.Empty))
				{
					continue;
				}
				string[] array4 = array[num3].Split(new char[1] { '=' }, StringSplitOptions.RemoveEmptyEntries);
				if (array3[0] == array4[0])
				{
					errorIndexList.Add(num3);
					if (firstError == string.Empty)
					{
						firstError = array[num3];
					}
				}
			}
		}
		if (errorIndexList.Count > 0)
		{
			if (!validateOnClose)
			{
				DialogUI.Instance.ShowDialog("Validation Errors - Duplicates", string.Format("There are {0} duplicate key errors.\r\n\r\nOnly the first one will be available in the game.", errorIndexList.Count), ModalWindowType.OK, delegate
				{
					HighlightInvalidRow(errorIndexList[0], 0);
				});
			}
			else
			{
				DialogUI.Instance.ShowDialog("Validation Errors", string.Format("There are {0} duplicate key errors.\r\n\r\nOnly the first one will be available in the game.\r\n\r\nReturn to the file to fix them?", errorIndexList.Count), ModalWindowType.YesNoCancel, delegate(ModalWindowResult result, string inputString)
				{
					if (result == ModalWindowResult.No)
					{
						CloseButtonPressed(true);
					}
					else
					{
						HighlightInvalidRow(errorIndexList[0], 0);
					}
				});
			}
			return false;
		}
		if (!validateOnClose)
		{
			DialogUI.Instance.ShowDialog("No Validation Errors", "The file looks OK.\r\n\r\nKeep in mind that only the structure, and not the contents, have been evaluated.", ModalWindowType.OK, delegate
			{
			});
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
		noteEditor.SelectRow(rowIndex, colIndex);
	}

	protected override void CloseButtonPressed()
	{
		CloseButtonPressed(false);
	}

	protected void CloseButtonPressed(bool skipValidation)
	{
		if (!skipValidation && !ValidateButtonPressed(true))
		{
			return;
		}
		base.CloseButtonPressed();
		string[] array = noteEditor.Text.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
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

	protected override void UndoButtonPressed()
	{
		base.UndoButtonPressed();
		noteEditor.UndoEditor();
	}

	protected override void CancelButtonPressed()
	{
		base.CancelButtonPressed();
		if (noteEditor.CancelEditor())
		{
			DungeonManager.Instance.CloseAliasWindow();
		}
	}

	protected override void CanceledEditor()
	{
		base.CanceledEditor();
		DungeonManager.Instance.CloseAliasWindow();
	}
}
