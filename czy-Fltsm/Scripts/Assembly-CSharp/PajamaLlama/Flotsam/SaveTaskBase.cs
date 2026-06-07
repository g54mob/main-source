using System;
using M4.Session;
using UnityEngine;

namespace PajamaLlama.Flotsam
{
	public abstract class SaveTaskBase : ThreadPoolManager.ITask
	{
		private static bool _queued;

		private static float _timeStamp;

		private PlayerProfile _player;

		private Exception _exception;

		public SaveInfo SaveInfo { get; protected set; }

		public bool Completed { get; private set; }

		public bool Success { get; private set; }

		public Exception Exception => _exception;

		protected SaveTaskBase(PlayerProfile player)
		{
			_player = player;
			_queued = false;
		}

		public bool Queue(SaveInfo saveInfo)
		{
			if (_queued || Time.realtimeSinceStartup - _timeStamp < Session.Platform.MinimumSaveInterval)
			{
				return false;
			}
			if (ThreadPoolManager.QueueTask(this))
			{
				_queued = true;
				SaveInfo = saveInfo;
				SaveInfo.Timestamp();
				Completed = false;
				OnQueued();
				return true;
			}
			return false;
		}

		public void ThreadPoolWaitCallback(object state)
		{
			try
			{
				byte[] data = GetData();
				SaveInfo.SetSize(data.Length);
				_player.SaveFile(SaveInfo.Path, data, OnSaveFileResult);
			}
			catch (Exception exception)
			{
				_exception = exception;
				Success = false;
				Completed = true;
			}
		}

		public void UnityCompletedCallback()
		{
			if (Exception != null)
			{
				Debug.LogException(Exception);
			}
			_queued = false;
			_timeStamp = Time.realtimeSinceStartup;
			OnCompleted();
			AsyncSaveEvent.DispatchCompleted(this);
		}

		protected abstract void OnQueued();

		protected abstract void OnCompleted();

		private void OnSaveFileResult(StorageActionResult result)
		{
			Success = result.Succes;
			Completed = true;
		}

		protected abstract byte[] GetData();
	}
}
