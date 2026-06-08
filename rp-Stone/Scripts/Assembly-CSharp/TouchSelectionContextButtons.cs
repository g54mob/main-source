using System.Collections.Generic;
using UnityEngine;

public class TouchSelectionContextButtons : MonoBehaviour
{
	public DialogButton leftDragHandle;

	public DialogButton rightDragHandle;

	public DialogButton cutButton;

	public DialogButton copyButton;

	public DialogButton pasteButton;

	public DialogButton selectButton;

	public DialogButton selectAllButton;

	private bool _isShowing;

	private List<DialogButton> optionButtons = new List<DialogButton>(6);

	private string lastLanguageId;

	public AsciiTextInputBox inputBox { get; set; }

	public bool skipCopy { get; set; }

	public bool skipPaste { get; set; }

	public bool skipSelectAll { get; set; }

	public bool isShowing
	{
		get
		{
			return _isShowing;
		}
		set
		{
			_isShowing = value;
			ClearSkippedFlags();
			UpdateContents();
		}
	}

	public void ClearSkippedFlags()
	{
		skipCopy = false;
		skipPaste = false;
		skipSelectAll = false;
	}

	public void UpdateContents()
	{
		InitButtons();
		optionButtons.Clear();
		bool flag = inputBox.IsSelected();
		if (flag)
		{
			optionButtons.Add(cutButton);
		}
		if (!skipCopy && flag)
		{
			optionButtons.Add(copyButton);
		}
		bool flag2 = !string.IsNullOrEmpty(GUIUtility.systemCopyBuffer);
		if (!skipPaste && flag2)
		{
			optionButtons.Add(pasteButton);
		}
		if (!flag)
		{
			int num = inputBox.inputBox.selectionAnchorPosition - 1;
			if (num >= 0 && num < inputBox.fullText.Length && !AsciiTextInputBox.IsSpace(inputBox.fullText[num]))
			{
				optionButtons.Add(selectButton);
			}
		}
		if (!skipSelectAll)
		{
			optionButtons.Add(selectAllButton);
		}
	}

	private void InitButtons()
	{
		if (cutButton.Width == 0 || lastLanguageId != Te.id)
		{
			lastLanguageId = Te.id;
			InitButton(cutButton, "Cut");
			InitButton(copyButton, "Copy");
			InitButton(pasteButton, "Paste");
			InitButton(selectButton, "Select");
			InitButton(selectAllButton, "Select All");
		}
	}

	private void InitButton(DialogButton btn, string label)
	{
		string text = Te.xt(label);
		btn.label.SetValue(text);
		btn.Width = text.Length + 4;
	}

	public void UpdateTic()
	{
		if (!(inputBox == null))
		{
			bool flag = inputBox.IsSelected();
			if (flag)
			{
				leftDragHandle.UpdateTic();
				rightDragHandle.UpdateTic();
			}
			for (int i = 0; i < optionButtons.Count; i++)
			{
				optionButtons[i].UpdateTic();
			}
			if (!isShowing && flag)
			{
				isShowing = true;
			}
			if (isShowing && inputBox.HasFocus())
			{
				isShowing = false;
			}
		}
	}

	public void Draw(AsciiRenderProcedural r)
	{
		if (inputBox == null || !isShowing)
		{
			return;
		}
		int lastContainerDrawX = inputBox.lastContainerDrawX;
		int lastContainerDrawY = inputBox.lastContainerDrawY;
		bool flag = inputBox.IsSelected();
		if (flag)
		{
			if (leftDragHandle.PositionY >= lastContainerDrawY && leftDragHandle.PositionY < lastContainerDrawY + inputBox.Height)
			{
				leftDragHandle.Draw(r, 0, 0);
			}
			if (rightDragHandle.PositionY >= lastContainerDrawY && rightDragHandle.PositionY < lastContainerDrawY + inputBox.Height)
			{
				rightDragHandle.Draw(r, 0, 0);
			}
		}
		if (optionButtons.Count <= 0 || leftDragHandle.PositionY >= lastContainerDrawY + inputBox.Height || (leftDragHandle.PositionY < lastContainerDrawY && (!flag || rightDragHandle.PositionY < lastContainerDrawY)))
		{
			return;
		}
		int num = Mathf.Max(lastContainerDrawY, leftDragHandle.PositionY);
		num -= cutButton.Height;
		int num2 = lastContainerDrawX;
		DialogButton dialogButton = null;
		for (int i = 0; i < optionButtons.Count; i++)
		{
			DialogButton dialogButton2 = optionButtons[i];
			dialogButton2.Draw(r, num2, num);
			num2 += dialogButton2.Width - 1;
			if (dialogButton2.activated)
			{
				dialogButton = dialogButton2;
			}
		}
		if (dialogButton != null)
		{
			dialogButton.Draw(r, dialogButton.lastDrawnX, num);
		}
		int num3 = optionButtons[0].Height - 1;
		r.SetCell(lastContainerDrawX, num, SpecialSymbols.Map('┌'));
		r.SetCell(lastContainerDrawX, num + num3, SpecialSymbols.Map('└'));
		r.SetCell(num2, num, SpecialSymbols.Map('┐'));
		r.SetCell(num2, num + num3, SpecialSymbols.Map('┘'));
	}
}
