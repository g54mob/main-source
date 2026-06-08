using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class MindStoneScreen : PopUpModalScreen
{
	private enum DimState
	{
		Off = 0,
		On = 1,
		Enabling = 2,
		Disabling = 3
	}

	public AsciiAnimation highlightsOn;

	public AsciiSprite highlightsOff;

	public SettingsToggleButton powerToggleButton;

	public AsciiString powerLabel;

	public AsciiTextInputBox inputBox;

	public HyperlinkButton helpButton;

	public HyperlinkButton importButtonPrototype;

	private List<HyperlinkButton> importButtons = new List<HyperlinkButton>();

	private Stack<HyperlinkButton> importButtonPool = new Stack<HyperlinkButton>();

	private string baseImportPath;

	public ItemSlot equipPreviewSlot;

	private Weapon equipPreviewWeapon;

	private int equipPreviewOffsetY;

	private bool hasReportedImportAchievement;

	public TouchSelectionContextButtons touchSelectionContextButtons;

	public AsciiString lineNumber;

	private float f_currentOffsetY;

	private float f_targetOffsetY;

	private int lastCaretX;

	private int lastCaretY;

	private int lastDisplayScrollYEquip;

	private int lastDisplayScrollY = -1;

	private bool needsToRebuildImportButtons;

	private Dictionary<string, bool> safePaths = new Dictionary<string, bool>();

	private DimState dimState;

	private float dimElapsedTime;

	private int checkClipboard = -1;

	public static MindStoneScreen singleton { get; private set; }

	public override void Show()
	{
		base.Show();
		bool flag = MindStoneController.singleton.enabled;
		powerToggleButton.isOn = flag;
		inputBox.text = MindStoneController.singleton.program;
		if (flag)
		{
			SetDimState(DimState.On);
		}
		else
		{
			SetDimState(DimState.Off);
		}
		hasReportedImportAchievement = false;
	}

	public override void Hide()
	{
		base.Hide();
		CopyProgramFromInputBox();
	}

	private void CopyProgramFromInputBox()
	{
		string[] text = inputBox.text;
		for (int i = 0; i < text.Length; i++)
		{
			string text2 = SpecialSymbols.NormalizeInputString(text[i]);
			text[i] = text2;
		}
		MindStoneController.singleton.program = text;
	}

	protected override void SetState(State newState)
	{
		base.SetState(newState);
	}

	protected override void Update()
	{
		base.Update();
		UpdateRowDim();
		UpdateAchievement();
		UpdateEquipPreview();
		UpdateImportButtons();
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (base.currentState == State.Out || base.currentState == State.In || base.currentState != State.Idle)
		{
			return;
		}
		powerToggleButton.UpdateTic();
		inputBox.UpdateTic();
		helpButton.UpdateTic();
		foreach (HyperlinkButton importButton in importButtons)
		{
			if (importButton != null)
			{
				importButton.UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY + (int)transitionOffsetY;
		if (base.currentState != State.Disabled)
		{
			powerLabel.Draw(r, offsetX, offsetY);
			powerToggleButton.Draw(r, offsetX, offsetY);
		}
		if (dimState == DimState.Disabling)
		{
			float colorMultiply = Mathf.Lerp(1f, 0.3333f, dimElapsedTime / 2f);
			highlightsOff.Draw(r, offsetX, offsetY, colorMultiply);
		}
		else if (dimState == DimState.Enabling)
		{
			highlightsOn.Sprite.Draw(r, offsetX, offsetY);
		}
		if (base.currentState != State.Disabled)
		{
			inputBox.Draw(r, offsetX, offsetY);
		}
		helpButton.Draw(r, offsetX, offsetY);
		for (int i = 0; i < inputBox.Width; i++)
		{
			for (int j = 0; j < inputBox.Height; j++)
			{
				int x = i + inputBox.lastContainerDrawX;
				int y = j + inputBox.lastContainerDrawY;
				AsciiCellProcedural cell = r.GetCell(x, y);
				if (cell != null)
				{
					Color foreground = cell.GetForeground();
					foreground *= GetDimForRow(j);
					cell.SetForeground(foreground);
				}
			}
		}
		for (int k = 0; k < importButtons.Count; k++)
		{
			if (importButtons[k] != null)
			{
				importButtons[k].Draw(r, offsetX + inputBox.PositionX, offsetY + inputBox.PositionY + k);
			}
		}
		if (equipPreviewWeapon != null)
		{
			int num = offsetX;
			while (num + equipPreviewSlot.PositionX + equipPreviewSlot.Width > r.width)
			{
				num--;
			}
			equipPreviewSlot.Draw(r, num, offsetY + equipPreviewOffsetY);
		}
		if (inputBox.HasFocus())
		{
			if (lastCaretY >= inputBox.DisplayScrollY && lastCaretY < inputBox.DisplayScrollY + inputBox.Height)
			{
				int num2 = lastCaretY + 1;
				if (num2 < 10)
				{
					lineNumber.SetValue("  " + num2);
				}
				else
				{
					lineNumber.SetValue(" " + num2);
				}
				lineNumber.Draw(r, inputBox.lastContainerDrawX - 2, inputBox.lastContainerDrawY + lastCaretY - inputBox.DisplayScrollY);
			}
		}
		else
		{
			if (Features.IS_TOUCH_MACRO && !AsciiMouse.singleton.isDown0)
			{
				return;
			}
			int num3 = AsciiMouse.singleton.y - inputBox.lastContainerDrawY;
			if (num3 < 0 || num3 >= inputBox.Height)
			{
				return;
			}
			int num4 = AsciiMouse.singleton.x - inputBox.lastContainerDrawX;
			if (num4 >= 0 && num4 < inputBox.Width)
			{
				int num5 = num3 + inputBox.DisplayScrollY + 1;
				if (num5 < 10)
				{
					lineNumber.SetValue("  " + num5);
				}
				else
				{
					lineNumber.SetValue(" " + num5);
				}
				lineNumber.Draw(r, inputBox.lastContainerDrawX - 2, AsciiMouse.singleton.y);
			}
		}
	}

	private void UpdateEquipPreview()
	{
		if (!inputBox.HasFocus() || inputBox.IsSelected())
		{
			equipPreviewWeapon = null;
			lastCaretX = -1;
		}
		else if (lastCaretX != inputBox.caretX || lastCaretY != inputBox.caretY)
		{
			lastCaretX = inputBox.caretX;
			lastCaretY = inputBox.caretY;
			lastDisplayScrollYEquip = inputBox.DisplayScrollY;
			List<AsciiStringRow> textInputBoxRows = inputBox.GetTextInputBoxRows();
			int caretY = inputBox.caretY;
			if (caretY >= textInputBoxRows.Count)
			{
				return;
			}
			string commandMessage = textInputBoxRows[caretY].text.Trim();
			commandMessage = MindStoneGameModel.TrimComment(commandMessage);
			Weapon weapon = null;
			if (commandMessage.StartsWith("equip", StringComparison.InvariantCultureIgnoreCase) && commandMessage.Length >= 8)
			{
				commandMessage = commandMessage.Substring(5).TrimStart();
				if (commandMessage.StartsWith("r ", StringComparison.InvariantCultureIgnoreCase))
				{
					commandMessage = commandMessage.Substring(2).TrimStart();
					if (commandMessage != "")
					{
						weapon = Inventory.Singleton.FindBestWeapon(commandMessage, Weapon.HandType.RightOnly);
					}
				}
				else if (commandMessage.StartsWith("l ", StringComparison.InvariantCultureIgnoreCase))
				{
					commandMessage = commandMessage.Substring(2).TrimStart();
					if (commandMessage != "")
					{
						weapon = Inventory.Singleton.FindBestWeapon(commandMessage, Weapon.HandType.LeftOnly);
					}
				}
				else if (commandMessage != "")
				{
					weapon = Inventory.Singleton.FindBestWeapon(commandMessage, Weapon.HandType.LeftOrRight);
				}
				if (weapon != null)
				{
					equipPreviewSlot.SetContent(weapon, 1);
				}
				equipPreviewWeapon = weapon;
				equipPreviewOffsetY = inputBox.caretY - inputBox.DisplayScrollY;
			}
			else
			{
				equipPreviewWeapon = null;
			}
		}
		else if (equipPreviewWeapon != null && lastDisplayScrollYEquip != inputBox.DisplayScrollY)
		{
			lastDisplayScrollYEquip = inputBox.DisplayScrollY;
			equipPreviewOffsetY = inputBox.caretY - inputBox.DisplayScrollY;
		}
	}

	private void UpdateImportButtons()
	{
		if (base.currentState == State.Disabled || (lastDisplayScrollY == inputBox.DisplayScrollY && !needsToRebuildImportButtons))
		{
			return;
		}
		lastDisplayScrollY = inputBox.DisplayScrollY;
		needsToRebuildImportButtons = false;
		RecycleImportButtons();
		List<AsciiStringRow> textInputBoxRows = inputBox.GetTextInputBoxRows();
		for (int i = 0; i < inputBox.Height; i++)
		{
			int num = i + inputBox.DisplayScrollY;
			if (num < 0 || num >= textInputBoxRows.Count)
			{
				break;
			}
			string text = textInputBoxRows[num].text.Trim();
			if (text.Length > 7 && text.StartsWith("import ") && IsSafePath(text))
			{
				HyperlinkButton importButton = GetImportButton();
				importButtons.Add(importButton);
				importButton.name = text;
				if (!hasReportedImportAchievement)
				{
					hasReportedImportAchievement = true;
					AchievementController.singleton.ReportImportTyped();
				}
			}
			else
			{
				importButtons.Add(null);
			}
		}
	}

	private HyperlinkButton GetImportButton()
	{
		if (importButtonPool.Count > 0)
		{
			return importButtonPool.Pop();
		}
		HyperlinkButton hyperlinkButton = UnityEngine.Object.Instantiate(importButtonPrototype);
		hyperlinkButton.OnPressed += HandleImportButtonPressed;
		return hyperlinkButton;
	}

	private void RecycleImportButtons()
	{
		foreach (HyperlinkButton importButton in importButtons)
		{
			if (importButton != null)
			{
				importButtonPool.Push(importButton);
			}
		}
		importButtons.Clear();
	}

	private void HandleImportButtonPressed(DialogButton btn)
	{
		string importPath = btn.name.Substring(6).Trim();
		OpenImportedScript(importPath);
	}

	private void OpenImportedScript(string importPath)
	{
		if (SSSystemProperties.IsLocalFilePath())
		{
			OpenImportedScript_Local(importPath);
		}
		else if (SSSystemProperties.IsRemoteFilePath())
		{
			OpenImportedScript_Remote(importPath);
		}
	}

	private void OpenImportedScript_Local(string importPath)
	{
		if (baseImportPath == null)
		{
			baseImportPath = SaveFiles.singleton.storage.GetStoragePath() + "/Stonescript";
		}
		string text = baseImportPath + "/" + importPath;
		if (File.Exists(text + ".txt"))
		{
			text = Path.GetFullPath(text);
			Process.Start("explorer.exe", string.Format("/select,\"{0}\"", text + ".txt"));
			return;
		}
		int num = text.LastIndexOf('/');
		if (num < 0)
		{
			num = text.LastIndexOf('\\');
		}
		if (num > 0)
		{
			text = text.Substring(0, num);
			Application.OpenURL("file://" + text);
		}
	}

	private void OpenImportedScript_Remote(string importPath)
	{
		importPath = "https://stonestoryrpg.com/stonescript/" + importPath + ".txt";
		Application.OpenURL(importPath);
	}

	private bool IsSafePath(string path)
	{
		if (safePaths.ContainsKey(path))
		{
			return safePaths[path];
		}
		bool flag = !path.Contains(":") && !path.Contains(";") && !path.Contains(".") && !path.Contains("//") && !path.Contains("\\\\");
		safePaths[path] = flag;
		return flag;
	}

	private void SetDimState(DimState newState)
	{
		switch (newState)
		{
		case DimState.Enabling:
			highlightsOn.Stop();
			highlightsOn.Play();
			SfxController.singleton.Play("mindstone_on");
			break;
		case DimState.Disabling:
			SfxController.singleton.Play("mindstone_off");
			break;
		}
		if ((dimState == DimState.Enabling && newState == DimState.Disabling) || (dimState == DimState.Disabling && newState == DimState.Enabling))
		{
			dimElapsedTime = 2f - dimElapsedTime;
		}
		else
		{
			dimElapsedTime = 0f;
		}
		dimState = newState;
	}

	private void UpdateRowDim()
	{
		dimElapsedTime += Time.deltaTime;
		if (dimState == DimState.Enabling)
		{
			if (dimElapsedTime >= 2f)
			{
				SetDimState(DimState.On);
			}
		}
		else if (dimState == DimState.Disabling && dimElapsedTime >= 2f)
		{
			SetDimState(DimState.Off);
		}
	}

	private float GetDimForRow(int rowIndex)
	{
		if (dimState == DimState.Off)
		{
			return 0.5f;
		}
		if (dimState == DimState.Enabling)
		{
			float t = (dimElapsedTime - 0.5f) * 8f - (float)rowIndex * 0.5f;
			return Mathf.Lerp(0.5f, 1f, t);
		}
		if (dimState == DimState.Disabling)
		{
			float t2 = dimElapsedTime / 2f;
			return Mathf.Lerp(1f, 0.5f, t2);
		}
		return 1f;
	}

	private void UpdateAchievement()
	{
		if (base.currentState != State.Idle)
		{
			return;
		}
		if (checkClipboard > 0)
		{
			checkClipboard--;
			if (checkClipboard == 0 && GUIUtility.systemCopyBuffer == inputBox.fullText)
			{
				AchievementController.singleton.ReportStonescriptCopiedAll();
			}
		}
		if (Input.GetKeyDown(KeyCode.C) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftMeta) || Input.GetKey(KeyCode.RightMeta)))
		{
			checkClipboard = 5;
		}
		if (Input.anyKeyDown)
		{
			AchievementController.singleton.ReportStonescriptChanged();
		}
	}

	private void HandleEndEdit(string textValue)
	{
		Utils.LogIfEditor("Handle End Edit: " + textValue);
	}

	private void HandlePowerTogglePressed(DialogButton button)
	{
		bool isOn = powerToggleButton.isOn;
		MindStoneController.singleton.enabled = isOn;
		if (isOn)
		{
			SetDimState(DimState.Enabling);
		}
		else
		{
			SetDimState(DimState.Disabling);
		}
	}

	private void HandleInputBoxChanged()
	{
		needsToRebuildImportButtons = true;
	}

	protected override void Start()
	{
		base.Start();
		powerToggleButton.OnPressed += HandlePowerTogglePressed;
		inputBox.OnLinesChanged += HandleInputBoxChanged;
	}

	protected override void OnDestroy()
	{
		base.Start();
		powerToggleButton.OnPressed -= HandlePowerTogglePressed;
		inputBox.OnLinesChanged -= HandleInputBoxChanged;
	}

	protected override void Awake()
	{
		base.Awake();
		inputBox.touchSelectionContextButtons = touchSelectionContextButtons;
		touchSelectionContextButtons.inputBox = inputBox;
		singleton = this;
	}

	public static bool IsEditing()
	{
		GameStates gameStates = GameStates.Singleton;
		if (gameStates.CurrentState == GameStates.State.PlayMindStoneEdit || (gameStates.CurrentState == GameStates.State.WorkstationScreen && gameStates.workstationScreen.currentState == WorkstationScreen.State.MindStone))
		{
			if (singleton.currentState == State.Idle)
			{
				return singleton.inputBox.HasFocus();
			}
			return false;
		}
		return false;
	}
}
