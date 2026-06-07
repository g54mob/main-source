using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using CTS.TechTree;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class SituationnalFeedbackHanlderEvent : MonoBehaviour
	{
		[SerializeField]
		private SituationnalFeedbackManager _situationnalFeedbackManager;

		[SerializeField]
		private int _timeBeforeLaunchFeedbacks;

		private bool _started;

		private int _dayPrestigeOne;

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackSophie Sophie { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackPapaGrenier PapaGrenier { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackVladimir Vladimir { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackAndrea Andrea { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackMaeve Maeve { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackPereRodolphe PereRudolphe { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackVonKopek VonKopek { get; private set; }

		[field: SerializeField]
		[field: Foldout("Personna")]
		public FeedbackYumeko Yumeko { get; private set; }

		private void Awake()
		{
			Prestige.PrestigeLevelUp += Prestige_PrestigeLevelUp;
			Prestige.PrestigeLevelDown += Prestige_PrestigeLevelDown;
			CalendarHandlers.NewDay += CalendarHandlers_NewDay;
			MoneyHandler.MoneyAmountChanged += MoneyHandler_MoneyAmountChanged;
			FinancialUI.FinancialUIOpened += FinancialUI_FinancialUIOpened;
			VigilanceHandlers.VigilanceChanged += VigilanceHandlers_VigilanceChanged;
			UI_PrestigeCanvas.RadicalSolution += UI_PrestigeCanvas_RadicalSolution;
			InterimAgency.OnAgencyEnter += InterimAgency_OnAgencyEnter;
			PanicCounter.PanicActive += PanicCounter_PanicActive;
			Agent.EnteringBar += Customer_EnteringBar;
			AgentBodyAbandoned.FeedbackCorpse += AgentBodyAbandoned_FeedbackCorpse;
			TechTreeNodeSetup.TechnoUnlock += UI_FurnitureTechTree_TechnoUnlock;
			TechTreePoints.OnGainResearchPoints += TechTreePoints_OnGainResearchPoints;
			UI_StockUnderPanelEvent.OnOpenPanel += UI_StockUnderPanelEvent_OnOpenStock;
			UI_StockUnderPanelEvent.OnOpenMaevePanel += UI_StockUnderPanelEvent_OnOpenMaevePanel;
			SeatCounter.SeatCountChanged += SeatCounter_SeatCountChanged;
			CustomerManager.CustomerCountUpdated += CustomerManager_CustomerCountUpdated;
			StartCoroutine(WaitBeforeLaunch());
		}

		private void OnDestroy()
		{
			Prestige.PrestigeLevelUp -= Prestige_PrestigeLevelUp;
			Prestige.PrestigeLevelDown -= Prestige_PrestigeLevelDown;
			CalendarHandlers.NewDay -= CalendarHandlers_NewDay;
			MoneyHandler.MoneyAmountChanged -= MoneyHandler_MoneyAmountChanged;
			FinancialUI.FinancialUIOpened -= FinancialUI_FinancialUIOpened;
			VigilanceHandlers.VigilanceChanged -= VigilanceHandlers_VigilanceChanged;
			UI_PrestigeCanvas.RadicalSolution -= UI_PrestigeCanvas_RadicalSolution;
			InterimAgency.OnAgencyEnter -= InterimAgency_OnAgencyEnter;
			PanicCounter.PanicActive -= PanicCounter_PanicActive;
			Agent.EnteringBar -= Customer_EnteringBar;
			AgentBodyAbandoned.FeedbackCorpse -= AgentBodyAbandoned_FeedbackCorpse;
			TechTreeNodeSetup.TechnoUnlock -= UI_FurnitureTechTree_TechnoUnlock;
			TechTreePoints.OnGainResearchPoints -= TechTreePoints_OnGainResearchPoints;
			UI_StockUnderPanelEvent.OnOpenPanel -= UI_StockUnderPanelEvent_OnOpenStock;
			UI_StockUnderPanelEvent.OnOpenMaevePanel -= UI_StockUnderPanelEvent_OnOpenMaevePanel;
			SeatCounter.SeatCountChanged -= SeatCounter_SeatCountChanged;
			CustomerManager.CustomerCountUpdated -= CustomerManager_CustomerCountUpdated;
		}

		private IEnumerator WaitBeforeLaunch()
		{
			_started = false;
			yield return new WaitForSecondsRealtime(_timeBeforeLaunchFeedbacks);
			_started = true;
		}

		private void MoneyFeedBackSophie(int obj)
		{
			EnqueuFeedback(Sophie.MoneyFeedBack(obj));
		}

		private void Prestige_PrestigeLevelDown()
		{
			EnqueuFeedback(Sophie.PrestigeDown);
		}

		private void Prestige_PrestigeLevelUp()
		{
			EnqueuFeedback(Sophie.PrestigeUp);
		}

		private void SophieNewDay()
		{
			SituationalfeedbackSO situationalfeedbackSO = Sophie.CalendarHandlers_NewDay(_dayPrestigeOne);
			if (situationalfeedbackSO == null)
			{
				_dayPrestigeOne++;
				return;
			}
			_dayPrestigeOne = 0;
			EnqueuFeedback(situationalfeedbackSO);
		}

		private void CustomerManager_CustomerCountUpdated()
		{
			if (CustomerManager.CustomersCount > CTSSingleton<SeatCounter>.Instance.CurrentEveryoneSeatCount)
			{
				EnqueuFeedback(Sophie.Table);
			}
		}

		private void SeatCounter_SeatCountChanged(int obj)
		{
			if (CustomerManager.CustomersCount > CTSSingleton<SeatCounter>.Instance.CurrentEveryoneSeatCount)
			{
				EnqueuFeedback(Sophie.Table);
			}
		}

		private void MoneyFeedBackVonKopek(int obj)
		{
			EnqueuFeedback(VonKopek.MoneyFeedBack(obj));
		}

		private void FinancialUI_FinancialUIOpened()
		{
			EnqueuFeedback(VonKopek.BankMenu);
		}

		private void PereRodolpheVigilance(int obj)
		{
			EnqueuFeedback(PereRudolphe.CheckVigilance(obj));
		}

		private void UI_PrestigeCanvas_RadicalSolution()
		{
			EnqueuFeedback(Maeve.RadicalSolution);
		}

		private void MaeveVigilance(int obj)
		{
			EnqueuFeedback(Maeve.CheckVigilance(obj));
		}

		private void UI_StockUnderPanelEvent_OnOpenMaevePanel(StringKey obj)
		{
			EnqueuFeedback(Maeve.UnderPanelOpen(obj));
		}

		private void MoneyFeedBackYumeko(int obj)
		{
			EnqueuFeedback(Yumeko.MoneyFeedBack(obj));
		}

		private void InterimAgency_OnAgencyEnter()
		{
			MapInfoSO levelInfo = CTSSingleton<GameMode>.Instance.LevelInfo;
			EnqueuFeedback(Yumeko.AgencyFeedBack(levelInfo));
		}

		private void MoneyFeedBackAndre(int obj)
		{
			EnqueuFeedback(Andrea.MoneyFeedBack(obj));
		}

		private void Customer_EnteringBar(Agent obj)
		{
			if (obj.IsHuman && ((Customer)obj).IsHunter)
			{
				EnqueuFeedback(Andrea.HunterRaid);
			}
		}

		private void PanicCounter_PanicActive(bool obj)
		{
			if (obj)
			{
				EnqueuFeedback(Andrea.Incident);
			}
		}

		private void VladimirVigilance(int obj)
		{
			EnqueuFeedback(Vladimir.CheckVigilance(obj));
		}

		private void MoneyFeedBackVladimir(int obj)
		{
			EnqueuFeedback(Vladimir.CheckLevel(obj));
		}

		private void AgentBodyAbandoned_FeedbackCorpse()
		{
			EnqueuFeedback(Vladimir.DeadBody);
		}

		private void UI_FurnitureTechTree_TechnoUnlock()
		{
			Debug.Log("Je trouve une nouvelle technologie ");
			EnqueuFeedback(PapaGrenier.NewTech);
		}

		private void MoneyFeedBackGrenier(int obj)
		{
			EnqueuFeedback(Andrea.MoneyFeedBack(obj));
		}

		private void TechTreePoints_OnGainResearchPoints()
		{
			EnqueuFeedback(PapaGrenier.CheckTechnoPoints(CTSSingleton<TechTreePoints>.Instance.CurrentPoints));
		}

		private void UI_StockUnderPanelEvent_OnOpenStock(StringKey obj)
		{
			EnqueuFeedback(PapaGrenier.UnderPanelOpen(obj));
		}

		private void MoneyFeedBackGrenier()
		{
			EnqueuFeedback(PapaGrenier.NegativeMoney);
		}

		private void MoneyHandler_MoneyAmountChanged(int obj)
		{
			if (!MonoSingleton<FinancialLoaningManager>.InstanceExists())
			{
				return;
			}
			if (obj < 0)
			{
				MoneyFeedBackGrenier();
			}
			else if (MonoSingleton<FinancialLoaningManager>.Instance.ActiveContracts.Count <= 0)
			{
				if (CTSSingleton<GameMode>.InstanceExists())
				{
					MapInfoSO levelInfo = CTSSingleton<GameMode>.Instance.LevelInfo;
					if (Vladimir.LevelForMoney.Contains(levelInfo))
					{
						MoneyFeedBackVladimir(obj);
					}
					if (levelInfo == Sophie.SceneForAlertMoney)
					{
						MoneyFeedBackSophie(obj);
					}
					if (levelInfo == Yumeko.SceneForAlertMoney)
					{
						MoneyFeedBackYumeko(obj);
					}
					if (levelInfo == Andrea.SceneForAlertMoney)
					{
						MoneyFeedBackAndre(obj);
					}
					if (levelInfo == PapaGrenier.SceneForAlertMoney)
					{
						MoneyFeedBackGrenier(obj);
					}
				}
			}
			else
			{
				MoneyFeedBackVonKopek(obj);
			}
		}

		private void VigilanceHandlers_VigilanceChanged(int obj)
		{
			PereRodolpheVigilance(obj);
			MaeveVigilance(obj);
			VladimirVigilance(obj);
		}

		private void CalendarHandlers_NewDay()
		{
			SophieNewDay();
		}

		private void EnqueuFeedback(SituationalfeedbackSO situationalfeedbackSO)
		{
			if (!(_situationnalFeedbackManager == null) && !(situationalfeedbackSO == null) && _started)
			{
				_situationnalFeedbackManager.EnqueueFeedback(situationalfeedbackSO);
			}
		}
	}
}
