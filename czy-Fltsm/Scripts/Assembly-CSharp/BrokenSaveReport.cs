using System;
using System.Collections.Generic;
using System.IO;
using AeLa.EasyFeedback;
using AeLa.EasyFeedback.APIs;
using UnityEngine;

public class BrokenSaveReport : FormField
{
	[SerializeField]
	private string _reportTitle = "Broken Save File";

	[SerializeField]
	[Min(0f)]
	private int _trelloListIndex = 2;

	private static readonly HashSet<string> _reportedBrokenSaveFiles = new HashSet<string>(4);

	private Action _onSucceededCallback;

	private Action _onFailedCallback;

	private bool _formWasSubmitted;

	private void OnDestroy()
	{
		if ((bool)Form)
		{
			Form.OnSubmissionSucceeded.RemoveListener(OnReportSucceeded);
			Form.OnSubmissionFailed.RemoveListener(OnReportFailed);
		}
		_onSucceededCallback = null;
		_onFailedCallback = null;
	}

	public bool CanReportSave(string saveName)
	{
		return !_reportedBrokenSaveFiles.Contains(saveName);
	}

	public void Submit(Action onSucceededCallback = null, Action onFailedCallback = null)
	{
		_formWasSubmitted = false;
		_onSucceededCallback = onSucceededCallback;
		_onFailedCallback = onFailedCallback;
		Form.Show();
	}

	protected override void FormOpened()
	{
		Form.OnSubmissionSucceeded.AddListener(OnReportSucceeded);
		Form.OnSubmissionFailed.AddListener(OnReportFailed);
		Report currentReport = Form.CurrentReport;
		currentReport.Title = _reportTitle;
		if (Form.Config != null && Form.Config.Board.Labels.TryFind(out var foundItem, (Label label) => label.name == "High Priority"))
		{
			currentReport.AddLabel(foundItem);
		}
		currentReport.List.id = Form.Config.Board.CategoryIds.GetValueClamped(_trelloListIndex);
		currentReport.List.name = Form.Config.Board.CategoryNames.GetValueClamped(_trelloListIndex);
		currentReport.AddSection("Detail");
		currentReport["Detail"].SetText("The attached Save File was unable to be loaded.\nPlease see the attached logs and stack trace for more information.");
	}

	protected override void FormSubmitted()
	{
		SaveMetaInfo saveMetaInfo = PersistenceManager.SaveMetaInfo;
		_formWasSubmitted = true;
		if (saveMetaInfo != null)
		{
			try
			{
				Form.CurrentReport.AttachFile("[Broken - " + saveMetaInfo.CommunityName + "] " + saveMetaInfo.Name + ".fs", File.ReadAllBytes(saveMetaInfo.Path));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	private void OnReportSucceeded()
	{
		if (PersistenceManager.SaveMetaInfo != null)
		{
			_reportedBrokenSaveFiles.Add(PersistenceManager.SaveMetaInfo.Name);
		}
		_onSucceededCallback.SafeInvoke();
		_onSucceededCallback = null;
		_onFailedCallback = null;
	}

	private void OnReportFailed()
	{
		_onFailedCallback.SafeInvoke();
		_onSucceededCallback = null;
		_onFailedCallback = null;
		_formWasSubmitted = false;
	}

	protected override void FormClosed()
	{
		Form.OnSubmissionSucceeded.RemoveListener(OnReportSucceeded);
		Form.OnSubmissionFailed.RemoveListener(OnReportFailed);
		if (!_formWasSubmitted)
		{
			OnReportFailed();
		}
	}
}
