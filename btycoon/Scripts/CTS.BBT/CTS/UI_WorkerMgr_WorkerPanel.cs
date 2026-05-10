using System;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_WorkerPanel : CTSBehaviour
	{
		[SerializeField]
		private SerializableDictionary<StringKey, GameObject[]> _modeObjects;

		[field: SerializeField]
		[field: Inject(false)]
		public UI_WorkerMgr_SorterReferences SorterReferences { get; private set; }

		public StringKey CurrentMode { get; private set; }

		public Worker AssignedWorker { get; private set; }

		public event Action<EventChange<Worker>> WorkerChanged;

		public event Action<Worker> NameWorkerChanged;

		public event Action<StringKey> DisplayModeChanged;

		public void SetDisplayMode(StringKey key)
		{
			if (!(key == CurrentMode))
			{
				SetCurrentModeActive(value: false);
				CurrentMode = key;
				SetCurrentModeActive(value: true);
				this.DisplayModeChanged?.Invoke(CurrentMode);
			}
		}

		private void SetCurrentModeActive(bool value)
		{
			if (CurrentMode.IsValid() && _modeObjects.TryGetValue(CurrentMode, out var value2))
			{
				GameObject[] array = value2;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value);
				}
			}
		}

		public void RenameWorker(Worker worker)
		{
			if (!(AssignedWorker != worker))
			{
				this.NameWorkerChanged?.Invoke(worker);
			}
		}

		public void SetWorker(Worker worker)
		{
			if (!(AssignedWorker == worker))
			{
				Worker assignedWorker = AssignedWorker;
				AssignedWorker = worker;
				this.WorkerChanged?.Invoke(new EventChange<Worker>(assignedWorker, AssignedWorker));
			}
		}
	}
}
