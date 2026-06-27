using System.Collections.Generic;
using Restory.Data.Tutorials;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Tutorials.Settings;
using Restory.Gameplay.Work.StateMachine;
using Restory.UI.Presenters.RegularPayment;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class BillOpenTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly RegularPaymentObjectRegistry regularPaymentObjectRegistry;

		private readonly GUI_RegularPayment regularPayment;

		private readonly WorkStateMachine workStateMachine;

		private readonly Transform tutorialIconsCanvas;

		private readonly BillOpenTutorialSettings settings;

		private GUI_MouseTooltip mouseTooltip;

		[Inject]
		public BillOpenTutorialHandler(DiContainer diContainer, RegularPaymentObjectRegistry regularPaymentObjectRegistry, WorkStateMachine workStateMachine, GUI_RegularPayment regularPayment, TooltipContainer tooltipContainer, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, BillOpenTutorial tutorial)
			: base(tutorial)
		{
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			this.diContainer = diContainer;
			this.regularPaymentObjectRegistry = regularPaymentObjectRegistry;
			this.workStateMachine = workStateMachine;
			this.regularPayment = regularPayment;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			regularPaymentObjectRegistry.OnRegistered += ResolveRegularPaymentObjectRegistered;
			regularPayment.OnIsVisibleChanged += ResolveRegularPaymentIsVisibleChanged;
			workStateMachine.OnStateChanged.AddListener(ResolveWorkStateChanged);
			CreateTooltipForAnyRegularPaymentObjectIfExists();
		}

		public override void Cleanup()
		{
			regularPaymentObjectRegistry.OnRegistered -= ResolveRegularPaymentObjectRegistered;
			regularPayment.OnIsVisibleChanged -= ResolveRegularPaymentIsVisibleChanged;
			workStateMachine.OnStateChanged.RemoveListener(ResolveWorkStateChanged);
			DestroyMouseTooltip();
		}

		private void CreateTooltipForAnyRegularPaymentObjectIfExists()
		{
			if (base.IsCompleted || (bool)mouseTooltip || !(workStateMachine.ActiveState is DetectionWorkState))
			{
				return;
			}
			using IEnumerator<RegularPaymentObject> enumerator = regularPaymentObjectRegistry.All.GetEnumerator();
			if (enumerator.MoveNext())
			{
				RegularPaymentObject current = enumerator.Current;
				mouseTooltip = CreateMouseTooltip(current.transform);
				mouseTooltip.PlayLeftClickAnimation();
			}
		}

		private void ResolveRegularPaymentObjectRegistered(RegularPaymentObject _)
		{
			if (!base.IsCompleted)
			{
				CreateTooltipForAnyRegularPaymentObjectIfExists();
			}
		}

		private void ResolveWorkStateChanged()
		{
			if (!base.IsCompleted)
			{
				DestroyMouseTooltip();
				if (workStateMachine.ActiveState is DetectionWorkState)
				{
					CreateTooltipForAnyRegularPaymentObjectIfExists();
				}
			}
		}

		private void ResolveRegularPaymentIsVisibleChanged()
		{
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}

		private GUI_MouseTooltip CreateMouseTooltip(Transform target)
		{
			DestroyMouseTooltip();
			GUI_MouseTooltip gUI_MouseTooltip = diContainer.InstantiatePrefabForComponent<GUI_MouseTooltip>(settings.MouseTooltipPrefab.gameObject, tutorialIconsCanvas.transform);
			gUI_MouseTooltip.Init(target);
			return gUI_MouseTooltip;
		}

		private void DestroyMouseTooltip()
		{
			if ((bool)mouseTooltip)
			{
				Object.Destroy(mouseTooltip.gameObject);
			}
		}
	}
}
