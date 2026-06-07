using System.Text;
using TMPro;
using UnityEngine;

public class FileListItem : SelectableButton, IPooledListItem
{
	public CanvasGroup canvas;

	public TextMeshProUGUI slotLabel;

	public TextMeshProUGUI townNameLabel;

	public TextMeshProUGUI lastModifiedLabel;

	public FileMetadata fileMetadata;

	public GameDataContainer container;

	public void SetVisible(bool visible)
	{
		if (null != canvas)
		{
			canvas.alpha = (visible ? 1f : 0f);
			canvas.interactable = visible;
			canvas.blocksRaycasts = visible;
		}
	}

	public void LoadContainer(FileMetadata f, GameDataContainer c)
	{
		fileMetadata = f;
		container = c;
		slotLabel.text = f.displayName;
		if (c != null)
		{
			StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
			pooledStringBuilder.Append(c.townName);
			pooledStringBuilder.Append(' ');
			pooledStringBuilder.AppendFormat(TextDisplay.LevelFormatShort, TextDisplay.LocalizedNumber(c.townLevel));
			townNameLabel.text = GameUtility.ResultOfPooledStringBuilder(pooledStringBuilder);
		}
		else
		{
			townNameLabel.text = string.Empty;
		}
		lastModifiedLabel.text = f.dateLastWritten.ToShortDateString();
	}

	public void OnAssignedObjectChanged()
	{
		UpdateSelectionState();
		AnimateInstant();
	}

	public void OnSelected()
	{
		if (isSelected && MenuManager.Instance.fileListPanel.inputField.text == fileMetadata.displayName)
		{
			MenuManager.Instance.fileListPanel.OnActionButtonClicked();
			return;
		}
		PerformSelection();
		MenuManager.Instance.fileListPanel.inputField.text = fileMetadata.displayName;
	}

	public void OnRightClicked()
	{
		PopupMenu popupMenu = MenuManager.Instance.ShowPopupMenu((RectTransform)base.transform);
		string text = "Delete".Localized();
		popupMenu.AddLabelButton(text, fileMetadata, OnDeleteFileClicked);
		popupMenu.ResizeHeight();
	}

	public void OnDeleteFileClicked(PopupMenuItem sender)
	{
		MenuManager.Instance.popupMenu.Hide();
		if (sender.loadedObject is FileMetadata fileMetadata)
		{
			Platform.Instance.DeleteFile(fileMetadata);
			MenuManager.Instance.fileListPanel.CreateLayout();
		}
	}
}
