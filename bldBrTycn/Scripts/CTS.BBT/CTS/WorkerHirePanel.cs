using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorkerHirePanel : AbsAgentPanel
	{
		[Header("Engage")]
		[SerializeField]
		private TMP_Text engageCostText;

		[SerializeField]
		private Button _engageButton;

		private Dictionary<Worker, Coroutine> _routines = new Dictionary<Worker, Coroutine>();

		private HashSet<MonoTimer> _vfx = new HashSet<MonoTimer>();

		private static Resource<MonoTimer> _engageVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_Dismiss");

		private Worker _worker;

		private int _workerCostValue;

		public static event Action<Agent> Hiring;

		protected override void Awake()
		{
			base.Awake();
			InterimAgency.OnAgencyQuit += OnAgencyQuit;
			InterimAgency.OnInterimHiringAlterationChanged += UpdateWorkerCost;
		}

		private void Start()
		{
			_engageButton.onClick.AddListener(OnEngagementClick);
		}

		protected override void OnDestroy()
		{
			InterimAgency.OnAgencyQuit -= OnAgencyQuit;
			InterimAgency.OnInterimHiringAlterationChanged -= UpdateWorkerCost;
		}

		public override void SetAgentInfo()
		{
			if (!(base._agent == null) && base._agent is Worker worker)
			{
				_worker = worker;
				UpdateWorkerCost();
			}
		}

		private void OnAgencyQuit()
		{
			foreach (KeyValuePair<Worker, Coroutine> routine in _routines)
			{
				StaticCoroutines.StopStaticCoroutine(routine.Value);
				DoEngageWorker(routine.Key);
			}
			foreach (MonoTimer item in _vfx)
			{
				Pooler.Push(item);
			}
			_vfx.Clear();
			_routines.Clear();
		}

		private void OnEngagementClick()
		{
			if (!(base._agent == null) && base._agent is Worker worker && InterimAgency.GetWorkerCost(worker) <= MonoSingleton<MoneyHandler>.Instance.CurrentMoney)
			{
				if (InterimAgency.IsWorkerSalaryFree)
				{
					worker.WorkerSalary.CurrentSalary = 0;
				}
				WorkerHirePanel.Hiring?.Invoke(worker);
				UpdateWorkerCost();
				EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, -_workerCostValue);
				MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, _workerCostValue, TransactionTag.Exceptional);
				MonoSingleton<InterimAgency>.Instance.RemoveWorker(worker);
				WorldSelector.Deselect(worker.Selection.SelectableObject);
				MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
				Coroutine value = StaticCoroutines.StartStaticCoroutine(EngagementAnim(worker));
				_routines.TryAdd(worker, value);
			}
		}

		private void UpdateWorkerCost()
		{
			_workerCostValue = InterimAgency.GetWorkerCost(_worker);
			engageCostText.text = _workerCostValue.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			_engageButton.interactable = _workerCostValue <= MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
		}

		private IEnumerator EngagementAnim(Worker worker)
		{
			worker.Selection.Selectable = false;
			worker.Animator.PlayPunctual(AgentAnim.Spin);
			yield return Coroutines.WaitForSecondsRealtime(0.6f);
			MonoTimer monoTimer = Pooler.Pull((MonoTimer)_engageVFXPrefab, false);
			if (monoTimer.TryGetComponent<VFXBehavior>(out var component))
			{
				foreach (AgentVisualUpdater item in component.Updaters<AgentVisualUpdater>())
				{
					item.SetAgent(worker);
				}
			}
			monoTimer.transform.SetPositionAndRotation(worker.transform);
			_vfx.Add(monoTimer);
			yield return monoTimer.Play();
			_routines.Remove(worker);
			DoEngageWorker(worker);
		}

		public override void ClearAgentInfo()
		{
		}

		private void DoEngageWorker(Worker worker)
		{
			worker.Engage();
			Transform currentBarSpawnpoint = MonoSingleton<InterimAgency>.Instance.GetCurrentBarSpawnpoint();
			worker.transform.SetPositionAndRotation(currentBarSpawnpoint);
		}
	}
}
