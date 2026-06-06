using System;
using System.IO;
using AeLa.EasyFeedback;
using M4.Session;
using UnityEngine;

namespace PajamaLlama.Flotsam.EasyFeedback
{
	public class FlotsamFields : FormField
	{
		private UIState _uiState;

		private byte[] _snapshotData;

		public void InitializeSaveData()
		{
			PersistenceManager.TryGetSaveData(out _snapshotData);
		}

		protected override void FormOpened()
		{
			InitializeSaveData();
			_uiState = UIManager.State;
			UIManager.SetState(UIState.Typing);
		}

		protected override void FormSubmitted()
		{
			PlayerRun activeRun = Session.Profile.ActiveRun;
			string communityName = activeRun.CommunityName;
			if (TryGetSaveData(activeRun.LoadedSave, out var data))
			{
				Form.CurrentReport.AttachFile(activeRun.LoadedSave.Name + ".fs", data);
			}
			if (activeRun.TryGetMostRecentSave(out var save, SaveType.Autosave) && TryGetSaveData(save, out var data2))
			{
				Form.CurrentReport.AttachFile(communityName + "_" + save.Name + ".fs", data2);
			}
			if (!_snapshotData.IsNullOrEmpty())
			{
				Form.CurrentReport.AttachFile(communityName + "_snapshot.fs", _snapshotData);
			}
		}

		protected override void FormClosed()
		{
			_snapshotData = null;
			UIManager.SetState(_uiState);
		}

		private bool TryGetSaveData(SaveInfo saveInfo, out byte[] data)
		{
			if (saveInfo != null)
			{
				try
				{
					data = File.ReadAllBytes(saveInfo.Path);
					return true;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
			data = null;
			return false;
		}
	}
}
