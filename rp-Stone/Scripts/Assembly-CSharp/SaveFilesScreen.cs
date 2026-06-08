using System.Collections.Generic;
using UnityEngine;

public class SaveFilesScreen : DialogNineSlice
{
	private enum SaveFilesScreenState
	{
		Normal = 0,
		DeleteConfirmation = 1,
		FileFromFutureConfirmation = 2,
		ExportNotification = 3,
		ImportConfirmation = 4
	}

	public AsciiString title;

	public ScrollContainer scrollContainer;

	public SaveFilesRow rowPrefab;

	public SaveFilesRow tallRowPrefab;

	public DialogButton closeButton;

	public AsciiSprite deleteBGLeft;

	public AsciiSprite deleteBGRight;

	public DialogButton deleteButton;

	public SaveFilesDeleteConfirmationDialog deleteFileConfirmationDialog;

	public SaveFilesDeleteConfirmationDialog fileFromFutureConfirmationDialog;

	public DialogButton exportButton;

	public DialogButton importButton;

	public TwoChoiceDialog exportNotificationDialog;

	public TwoChoiceDialog importConfirmationDialog;

	private int defaultY;

	private int defaultHeight;

	private SaveFilesRow deleteTarget;

	private int deleteTargetY;

	private bool hideDeletePending;

	private float pressDownStartTime;

	private DialogButton pressDownTarget;

	private string exportData;

	private string importData;

	private SaveFilesScreenState currentSaveFilesScreenState;

	private List<SaveFilesRow> rows = new List<SaveFilesRow>();

	private Stack<SaveFilesRow> pool = new Stack<SaveFilesRow>();

	private Stack<SaveFilesRow> tallPool = new Stack<SaveFilesRow>();

	public SaveFiles.SaveFileMeta selectedSaveFile { get; set; }

	private void _SetState(SaveFilesScreenState newState)
	{
		switch (newState)
		{
		case SaveFilesScreenState.DeleteConfirmation:
			deleteFileConfirmationDialog.saveFileRow = deleteTarget;
			deleteFileConfirmationDialog.Show();
			deleteTarget = null;
			break;
		case SaveFilesScreenState.ExportNotification:
			base.SetState(State.In);
			base.UpdateTic();
			exportNotificationDialog.Show();
			break;
		case SaveFilesScreenState.ImportConfirmation:
			base.SetState(State.In);
			base.UpdateTic();
			importConfirmationDialog.Show();
			break;
		}
		currentSaveFilesScreenState = newState;
	}

	private void Setup()
	{
		selectedSaveFile = null;
		List<SaveFiles.SaveFileMeta> sorted = SaveFiles.singleton.GetSorted();
		RecycleAllRows();
		for (int i = 0; i < sorted.Count; i++)
		{
			SaveFiles.SaveFileMeta saveFileMeta = sorted[i];
			AddRow(saveFileMeta.bigHead).saveFile = saveFileMeta;
		}
		if (sorted.Count < 10)
		{
			AddRow(tall: false).saveFile = null;
		}
		if (rows.Count < 3)
		{
			Height = defaultHeight - rowPrefab.Height + 1;
			PositionY = defaultY + rowPrefab.Height / 2;
		}
		else
		{
			Height = defaultHeight;
			PositionY = defaultY;
		}
		scrollContainer.PositionY = scrollContainer.scrollBar.PositionY;
		scrollContainer.Height = scrollContainer.scrollBar.Height;
		if (rows.Count < 4)
		{
			scrollContainer.PositionY += 2;
			scrollContainer.Height -= 2;
		}
		deleteTarget = null;
		deleteButton.label.SetValue(Te.xt("Delete"));
		deleteButton.Width = deleteButton.label.Length + 4;
		deleteBGRight.pivotX = deleteBGLeft.pivotX - deleteButton.Width + 7;
		exportButton.PositionY = Height;
		importButton.PositionY = Height;
		if (sorted.Count > 0)
		{
			exportData = SaveFiles.singleton.storage.ExportAsString();
			exportButton.enabled = exportData != null;
		}
		else
		{
			exportButton.enabled = false;
		}
		UpdateImportDataAndButtonState();
	}

	private void HandleRowPressed(DialogButton btn)
	{
		SaveFilesRow saveFilesRow = (SaveFilesRow)btn;
		if (saveFilesRow.saveFile == null)
		{
			selectedSaveFile = new SaveFiles.SaveFileMeta();
			Hide();
		}
		else if (!string.IsNullOrEmpty(saveFilesRow.saveFile.version) && Version.FromString(saveFilesRow.saveFile.version) > Features.VERSION)
		{
			ShowFileFromTheFuture(saveFilesRow);
		}
		else
		{
			selectedSaveFile = saveFilesRow.saveFile;
			Hide();
		}
	}

	private void HandleRowSecondaryPressed(DialogButton btn)
	{
		deleteTarget = (SaveFilesRow)btn;
		if (deleteTarget != null)
		{
			if (deleteTarget.saveFile != null)
			{
				deleteTargetY = deleteTarget.lastDrawY;
			}
			else
			{
				deleteTarget = null;
			}
		}
	}

	private void HandleRowDown(DialogButton btn)
	{
	}

	public virtual void Show()
	{
		base.SetState(State.In);
		Setup();
	}

	public virtual void Hide()
	{
		base.SetState(State.Out);
	}

	public void HideImmediatly()
	{
		base.SetState(State.Disabled);
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			if (currentSaveFilesScreenState == SaveFilesScreenState.Normal)
			{
				Hide();
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.DeleteConfirmation)
			{
				deleteFileConfirmationDialog.Hide();
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.ExportNotification)
			{
				exportNotificationDialog.Hide();
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.ImportConfirmation)
			{
				importConfirmationDialog.Hide();
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.FileFromFutureConfirmation)
			{
				fileFromFutureConfirmationDialog.Hide();
			}
		}
	}

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (currentSaveFilesScreenState == SaveFilesScreenState.Normal)
		{
			if (base.CurrentState == State.Idle)
			{
				scrollContainer.UpdateTic();
				UpdatePressDownTarget();
			}
			closeButton.UpdateTic();
			if (deleteTarget != null && deleteTargetY != deleteTarget.lastDrawnY)
			{
				deleteTarget = null;
			}
			if (deleteTarget != null)
			{
				deleteButton.UpdateTic();
			}
			if (hideDeletePending)
			{
				hideDeletePending = false;
				deleteTarget = null;
			}
			if (exportButton.enabled)
			{
				exportButton.UpdateTic();
			}
			if (importButton.enabled)
			{
				importButton.UpdateTic();
			}
		}
		else if (currentSaveFilesScreenState == SaveFilesScreenState.DeleteConfirmation)
		{
			deleteFileConfirmationDialog.UpdateTic();
			if (deleteFileConfirmationDialog.CurrentState == State.Disabled)
			{
				_SetState(SaveFilesScreenState.Normal);
			}
		}
		else if (currentSaveFilesScreenState == SaveFilesScreenState.ExportNotification)
		{
			exportNotificationDialog.UpdateTic();
			if (exportNotificationDialog.CurrentState == State.Disabled)
			{
				_SetState(SaveFilesScreenState.Normal);
			}
		}
		else if (currentSaveFilesScreenState == SaveFilesScreenState.ImportConfirmation)
		{
			importConfirmationDialog.UpdateTic();
			if (importConfirmationDialog.CurrentState == State.Disabled)
			{
				_SetState(SaveFilesScreenState.Normal);
			}
		}
		else
		{
			if (currentSaveFilesScreenState != SaveFilesScreenState.FileFromFutureConfirmation)
			{
				return;
			}
			fileFromFutureConfirmationDialog.UpdateTic();
			if (fileFromFutureConfirmationDialog.CurrentState == State.Disabled)
			{
				_SetState(SaveFilesScreenState.Normal);
				if (selectedSaveFile != null)
				{
					Hide();
				}
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (base.CurrentState == State.Idle)
		{
			offsetX += PositionX;
			offsetY += PositionY;
			title.Draw(r, offsetX, offsetY);
			closeButton.Draw(r, offsetX, offsetY);
			scrollContainer.Draw(r, offsetX, offsetY);
			if (exportButton.enabled)
			{
				exportButton.Draw(r, offsetX, offsetY);
			}
			if (importButton.enabled)
			{
				importButton.Draw(r, offsetX, offsetY);
			}
			if (deleteTarget != null)
			{
				int offsetX2 = deleteTarget.lastDrawX;
				int offsetY2 = deleteTarget.lastDrawY;
				deleteBGLeft.Draw(r, offsetX2, offsetY2);
				deleteBGRight.Draw(r, offsetX2, offsetY2);
				deleteButton.Draw(r, offsetX2, offsetY2);
			}
			if (currentSaveFilesScreenState == SaveFilesScreenState.DeleteConfirmation)
			{
				deleteFileConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.FileFromFutureConfirmation)
			{
				fileFromFutureConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.ExportNotification)
			{
				exportNotificationDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
			else if (currentSaveFilesScreenState == SaveFilesScreenState.ImportConfirmation)
			{
				importConfirmationDialog.Draw(r, r.width >> 1, r.height >> 1);
			}
		}
	}

	public void ShowFileFromTheFuture(SaveFiles.SaveFileMeta file)
	{
		for (int i = 0; i < rows.Count; i++)
		{
			SaveFilesRow saveFilesRow = rows[i];
			if (saveFilesRow.saveFile != null && saveFilesRow.saveFile.saveId == file.saveId)
			{
				ShowFileFromTheFuture(saveFilesRow);
				break;
			}
		}
	}

	private void ShowFileFromTheFuture(SaveFilesRow row)
	{
		fileFromFutureConfirmationDialog.saveFileRow = row;
		fileFromFutureConfirmationDialog.Show();
		_SetState(SaveFilesScreenState.FileFromFutureConfirmation);
	}

	private void UpdatePressDownTarget()
	{
		if (pressDownTarget != null)
		{
			if (!pressDownTarget.activated || !pressDownTarget.IsMouseInside())
			{
				pressDownTarget = null;
			}
			else if (Time.realtimeSinceStartup - pressDownStartTime > 0.4f)
			{
				HandleRowSecondaryPressed(pressDownTarget);
				pressDownTarget.activated = false;
				pressDownTarget = null;
			}
		}
	}

	private void UpdateImportDataAndButtonState()
	{
		importData = GUIUtility.systemCopyBuffer;
		if (importData != null && importData.Length > 200)
		{
			importData = importData.Trim();
			if (importData.StartsWith('{') && importData.EndsWith('}'))
			{
				RemoveLineBreaks();
				if (importData.Contains("STRING_KEYS:"))
				{
					importButton.enabled = true;
					return;
				}
			}
		}
		importButton.enabled = false;
		importData = null;
	}

	private void RemoveLineBreaks()
	{
		importData = importData.Replace("\r", "");
		importData = importData.Replace("\n", "");
	}

	private void HandleOnClosePressed(DialogButton button)
	{
		Hide();
	}

	private void HandleOnClickedOutside()
	{
		if (currentSaveFilesScreenState == SaveFilesScreenState.Normal)
		{
			if (deleteTarget != null)
			{
				hideDeletePending = true;
			}
			else
			{
				Hide();
			}
		}
		else if (currentSaveFilesScreenState == SaveFilesScreenState.DeleteConfirmation)
		{
			deleteFileConfirmationDialog.Hide();
		}
		else if (currentSaveFilesScreenState == SaveFilesScreenState.FileFromFutureConfirmation)
		{
			fileFromFutureConfirmationDialog.Hide();
		}
	}

	private void HandleDeletePressed(DialogButton btn)
	{
		if (deleteTarget != null && deleteTarget.saveFile != null)
		{
			_SetState(SaveFilesScreenState.DeleteConfirmation);
		}
	}

	private void HandleDeleteConfirmed(DialogButton btn)
	{
		deleteFileConfirmationDialog.Hide();
		SaveFiles.SaveFileMeta saveFile = deleteFileConfirmationDialog.saveFileRow.saveFile;
		bool num = saveFile == GameSave.selectedSaveFile;
		bool flag = saveFile == GameSave.activeSaveFile;
		SaveFiles.singleton.Delete(saveFile.saveId);
		SaveFiles.singleton.storage.Save();
		if (num)
		{
			GameSave.SelectTopSaveFile();
		}
		if (flag)
		{
			GameSave.activeSaveFile = null;
		}
		deleteTarget = null;
		Setup();
	}

	private void HandleFileFromFutureConfirmed(DialogButton btn)
	{
		selectedSaveFile = fileFromFutureConfirmationDialog.saveFileRow.saveFile;
		fileFromFutureConfirmationDialog.Hide();
	}

	private void HandleExportButtonPressed(DialogButton btn)
	{
		_SetState(SaveFilesScreenState.ExportNotification);
		GUIUtility.systemCopyBuffer = exportData;
	}

	private void HandleImportButtonPressed(DialogButton btn)
	{
		_SetState(SaveFilesScreenState.ImportConfirmation);
	}

	private void HandleImportClickedOutside()
	{
		importConfirmationDialog.Hide();
	}

	private void HandleImportOkButtonPressed(DialogButton btn)
	{
		importConfirmationDialog.Hide();
		SaveFiles.singleton.storage.ImportFromString(importData);
		SaveFiles.singleton.DeleteAllSaves();
		SaveFiles.singleton.Init();
		GameSave.SelectTopSaveFile();
		Setup();
		importButton.enabled = false;
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus && base.CurrentState == State.Idle)
		{
			UpdateImportDataAndButtonState();
		}
	}

	protected override void Start()
	{
		base.Start();
		closeButton.OnPressed += HandleOnClosePressed;
		base.OnClickedOutside += HandleOnClickedOutside;
		deleteButton.OnPressed += HandleDeletePressed;
		deleteFileConfirmationDialog.okButton.OnPressed += HandleDeleteConfirmed;
		fileFromFutureConfirmationDialog.okButton.OnPressed += HandleFileFromFutureConfirmed;
		exportButton.OnPressed += HandleExportButtonPressed;
		importButton.OnPressed += HandleImportButtonPressed;
		importConfirmationDialog.OnClickedOutside += HandleImportClickedOutside;
		importConfirmationDialog.okButton.OnPressed += HandleImportOkButtonPressed;
		defaultHeight = Height;
		defaultY = PositionY;
		base.CurrentState = State.Disabled;
	}

	protected void OnDestroy()
	{
		closeButton.OnPressed -= HandleOnClosePressed;
		base.OnClickedOutside -= HandleOnClickedOutside;
		deleteButton.OnPressed -= HandleDeletePressed;
		deleteFileConfirmationDialog.okButton.OnPressed -= HandleDeleteConfirmed;
		fileFromFutureConfirmationDialog.okButton.OnPressed -= HandleFileFromFutureConfirmed;
		exportButton.OnPressed -= HandleExportButtonPressed;
		importButton.OnPressed -= HandleImportButtonPressed;
		importConfirmationDialog.OnClickedOutside -= HandleImportClickedOutside;
		importConfirmationDialog.okButton.OnPressed -= HandleImportOkButtonPressed;
		RecycleAllRows();
		while (pool.Count > 0)
		{
			SaveFilesRow saveFilesRow = pool.Pop();
			saveFilesRow.OnPressed -= HandleRowPressed;
			saveFilesRow.OnSecondaryPressed -= HandleRowSecondaryPressed;
			saveFilesRow.OnDown -= HandleRowDown;
		}
	}

	private void RecycleAllRows()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			SaveFilesRow saveFilesRow = rows[i];
			if (saveFilesRow.Height == rowPrefab.Height)
			{
				pool.Push(saveFilesRow);
			}
			else
			{
				tallPool.Push(saveFilesRow);
			}
		}
		scrollContainer.Clear();
		rows.Clear();
	}

	private SaveFilesRow AddRow(bool tall)
	{
		Stack<SaveFilesRow> stack = pool;
		SaveFilesRow original = rowPrefab;
		if (tall)
		{
			stack = tallPool;
			original = tallRowPrefab;
		}
		SaveFilesRow saveFilesRow;
		if (stack.Count > 0)
		{
			saveFilesRow = stack.Pop();
		}
		else
		{
			saveFilesRow = Object.Instantiate(original);
			saveFilesRow.OnPressed += HandleRowPressed;
			saveFilesRow.OnSecondaryPressed += HandleRowSecondaryPressed;
			saveFilesRow.OnDown += HandleRowDown;
		}
		rows.Add(saveFilesRow);
		scrollContainer.AddRow(saveFilesRow);
		return saveFilesRow;
	}
}
