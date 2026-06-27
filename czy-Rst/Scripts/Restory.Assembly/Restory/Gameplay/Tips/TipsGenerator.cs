using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Tips;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.EmailSystems;
using Restory.Gameplay.NPCs;
using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using Restory.Gameplay.WorkshopStatus;
using Restory.Infrastructure.ProjectServices;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tips
{
	public class TipsGenerator : IInitializable, IDisposable
	{
		private readonly Queue<int> queuedTips = new Queue<int>();

		private readonly TipBox tipBox;

		private readonly TipsGeneratorSettings settings;

		private readonly WorkOrdersService workOrdersService;

		private readonly EmailOrdersService emailOrdersService;

		private readonly NpcServiceMain npcServiceMain;

		private readonly ICoroutineRunner coroutineRunner;

		private readonly WorkshopStatusService workshopStatusService;

		private Coroutine sendTipsToTipBoxCoroutine;

		[Inject]
		public TipsGenerator(TipBox tipBox, TipsGeneratorSettings settings, WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService, NpcServiceMain npcServiceMain, ICoroutineRunner coroutineRunner, WorkshopStatusService workshopStatusService)
		{
			this.tipBox = tipBox;
			this.settings = settings;
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
			this.npcServiceMain = npcServiceMain;
			this.coroutineRunner = coroutineRunner;
			this.workshopStatusService = workshopStatusService;
		}

		public void Initialize()
		{
			workOrdersService.OnOrderShipped += ResolveWorkOrderShipped;
			emailOrdersService.OnOrderShipped += ResolveEmailOrderShipped;
			npcServiceMain.OnBeforeNpcStartedMovingToExit += ResolveNpcStartedMovingToExit;
		}

		public void Dispose()
		{
			workOrdersService.OnOrderShipped -= ResolveWorkOrderShipped;
			emailOrdersService.OnOrderShipped -= ResolveEmailOrderShipped;
			npcServiceMain.OnVisitEnded -= ResolveNpcStartedMovingToExit;
			sendTipsToTipBoxCoroutine = null;
		}

		private void ResolveWorkOrderShipped(WorkOrderBase workOrder)
		{
			GenerateTips(workOrder.SavedGivenRewardMoneyAmount);
		}

		private void ResolveEmailOrderShipped(EmailLetterOrderRecord emailOrder)
		{
			GenerateTips(emailOrder.Payment);
		}

		private void ResolveNpcStartedMovingToExit()
		{
			if (queuedTips.Count != 0 && sendTipsToTipBoxCoroutine == null)
			{
				sendTipsToTipBoxCoroutine = coroutineRunner.Run(SendTipsToTipBoxCoroutine());
			}
		}

		private void GenerateTips(int orderPayment)
		{
			if (orderPayment < 1)
			{
				return;
			}
			float num = UnityEngine.Random.Range(settings.MinTipsArgument, settings.MaxTipsArgument);
			StatusInfo[] statusesForMultiplier = settings.StatusesForMultiplier;
			foreach (StatusInfo statusInfo in statusesForMultiplier)
			{
				if (workshopStatusService.HasStatus(statusInfo))
				{
					num *= settings.StatusMultiplier;
					Debug.Log(string.Format("[{0}] Tips multiplied by {1} due to status {2}", "TipsGenerator", settings.StatusMultiplier, statusInfo.ID));
					break;
				}
			}
			queuedTips.Enqueue((int)num);
		}

		public bool ContainsMultiplierStatus()
		{
			return settings.StatusesForMultiplier.Any(workshopStatusService.HasStatus);
		}

		private IEnumerator SendTipsToTipBoxCoroutine()
		{
			yield return new WaitForSeconds(settings.TipsStartAddingDelay);
			while (queuedTips.Count > 0)
			{
				tipBox.TryAddTips(queuedTips.Dequeue());
				yield return new WaitForSeconds(settings.DelayBetweenTipsAdding);
			}
			sendTipsToTipBoxCoroutine = null;
		}
	}
}
