using System;
using System.Collections.Generic;
using System.Linq;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopClientBehaviour : AIClientBehaviour
	{
		private int m_paintingFurnitureLevel;

		private float m_paintingDuration;

		private float m_paintingMoneyProduced;

		private float m_timeSinceLastPaintingMoneyGeneration;

		private int m_wargameFurnitureLevel;

		private bool m_isPlayingWargame;

		private float m_wargameDuration;

		private float m_wargameMoneyProduced;

		private float m_timeSinceLastWargameMoneyGeneration;

		public static event Action<float, float> CompletedPainting;

		public static event Action<float, float> CompletedWargame;

		protected override void OnEnable()
		{
			base.OnEnable();
			EventManager.OnGameEvent += OnGameEvent;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			EventManager.OnGameEvent -= OnGameEvent;
		}

		protected virtual void OnGameEvent(EGameEvent e)
		{
			switch (e)
			{
			case EGameEvent.NIGHT:
				QuitOptionalStand();
				break;
			case EGameEvent.CLOSE_SHOP:
				QuitOptionalStand();
				break;
			}
		}

		public override void Load(int phase, AISaveState state)
		{
			base.Load(phase, state);
			if (phase == 1)
			{
				SaveClass_TabletopClients.TabletopClientState tabletopClientState = state as SaveClass_TabletopClients.TabletopClientState;
				m_paintingDuration = tabletopClientState.paintingDuration;
				m_paintingMoneyProduced = tabletopClientState.paintingMoneyProduced;
				m_timeSinceLastPaintingMoneyGeneration = tabletopClientState.timeSinceLastPaintingMoneyGeneration;
				m_isPlayingWargame = tabletopClientState.isPlayingWargame;
				m_wargameDuration = tabletopClientState.wargameDuration;
				m_wargameMoneyProduced = tabletopClientState.wargameMoneyProduced;
				m_timeSinceLastWargameMoneyGeneration = tabletopClientState.timeSinceLastWargameMoneyGeneration;
				if (base.ClientState == EClientState.PAINTING)
				{
					base.ClientCharacter.SetSitted(sitted: true);
					base.ClientCharacter.SetPainting(painting: true);
				}
				else if (base.ClientState == EClientState.WARGAMING)
				{
					base.ClientCharacter.SetSitted(sitted: true);
					base.ClientCharacter.SetPlaying(playing: true);
				}
			}
		}

		protected override void OnLoadCurrentStand(Stand stand)
		{
			base.OnLoadCurrentStand(stand);
			switch (base.ClientState)
			{
			case EClientState.PAINTING:
				if (stand is PaintingTableStand paintingTableStand)
				{
					m_paintingFurnitureLevel = paintingTableStand.FurnitureLevel;
				}
				break;
			case EClientState.WARGAMING:
				if (m_isPlayingWargame && stand is WargameStand wargameStand)
				{
					m_wargameFurnitureLevel = wargameStand.FurnitureLevel;
				}
				break;
			}
		}

		public override SaveClass_Clients.ClientState GetSaveClientState()
		{
			return new SaveClass_TabletopClients.TabletopClientState(this, base.ClientCharacter)
			{
				visitedStands = ((m_visitedStands != null) ? new List<Vector2Int>(m_visitedStands) : null),
				currentBuyIterationLeft = m_currentBuyIterationLeft,
				paintingDuration = m_paintingDuration,
				paintingMoneyProduced = m_paintingMoneyProduced,
				timeSinceLastPaintingMoneyGeneration = m_timeSinceLastPaintingMoneyGeneration,
				isPlayingWargame = m_isPlayingWargame,
				wargameDuration = m_wargameDuration,
				wargameMoneyProduced = m_wargameMoneyProduced,
				timeSinceLastWargameMoneyGeneration = m_timeSinceLastWargameMoneyGeneration
			};
		}

		protected override void OnActivityCompleted()
		{
			base.OnActivityCompleted();
			switch (base.ClientState)
			{
			case EClientState.PAINTING:
				OnCompletePainting();
				CompleteCurrentStand();
				break;
			case EClientState.WARGAMING:
				OnCompleteWargame();
				CompleteCurrentStand();
				break;
			case EClientState.BROWSING_STALL:
				if (base.CurrentStand is StallStand stallStand)
				{
					BuyFromStallStand(stallStand);
				}
				else
				{
					CompleteCurrentStand();
				}
				break;
			case EClientState.KILLING_TIME:
				break;
			}
		}

		protected override void OnActivityTimelineUpdated(float deltaTime)
		{
			base.OnActivityTimelineUpdated(deltaTime);
			switch (base.ClientState)
			{
			case EClientState.PAINTING:
				UpdatePainting(deltaTime);
				break;
			case EClientState.WARGAMING:
				UpdateWargame(deltaTime);
				break;
			}
		}

		protected override void OnArriveAtStand(Stand stand)
		{
			base.OnArriveAtStand(stand);
			switch (base.CurrentStand.Type)
			{
			case EStandType.PAINTING:
				base.ClientState = EClientState.PAINTING;
				StartPainting();
				break;
			case EStandType.WARGAME:
				if (stand is WargameStand stand2)
				{
					base.ClientState = EClientState.WARGAMING;
					OnArriveAtWargameStand(stand2);
				}
				break;
			case EStandType.STALL:
				if (CanStillShop())
				{
					base.ClientState = EClientState.BROWSING_STALL;
					DoActivityFor(AIClientSettings.WaitBetweenBuy);
				}
				else
				{
					base.ClientState = EClientState.KILLING_TIME;
					DoActivityFor(AIClientSettings.WaitWithoutBuy);
				}
				break;
			}
		}

		protected override void OnQuitStand(Stand stand, bool completed)
		{
			if (stand.Type == EStandType.PAINTING)
			{
				if (!completed)
				{
					OnCompletePainting();
				}
				KillActivityTimeline();
				GoToExit();
			}
			else if (stand.Type == EStandType.WARGAME)
			{
				if (!completed)
				{
					OnCompleteWargame();
				}
				KillActivityTimeline();
				GoToExit();
			}
			else
			{
				base.OnQuitStand(stand, completed);
			}
		}

		protected override void OnCurrentStandActivated(bool active)
		{
			base.OnCurrentStandActivated(active);
			if (base.CurrentStand != null && !active)
			{
				EStandType type = base.CurrentStand.Type;
				if (type == EStandType.PAINTING || type == EStandType.WARGAME)
				{
					QuitCurrentStandWithoutComplete();
				}
			}
		}

		protected override void OnCheckedOut()
		{
			if (TimeController.IsDay && World.Shop.Open)
			{
				if (World.Shop.TryGetBestStandOfType(EStandType.WARGAME, out var stand) && stand.CanAccess(this) && stand is WargameStand wargameStand && UnityEngine.Random.value < AIClientSettings.WargameProbability + (wargameStand.CanJoinOtherClient() ? AIClientSettings.WargameProbaIncrease : 0f))
				{
					AccessStand(wargameStand);
					return;
				}
				if (UnityEngine.Random.value < AIClientSettings.PaintingProbability && World.Shop.TryGetBestStandOfType(EStandType.PAINTING, out var stand2) && stand2.CanAccess(this))
				{
					AccessStand(stand2);
					return;
				}
			}
			GoToExit();
		}

		protected virtual bool BuyFromStallStand(StallStand stallStand)
		{
			m_visitedStands.Add(new Vector2Int(stallStand.ID.x, stallStand.ID.y));
			List<StallInteractable> collection = stallStand.GetStallInteractablesWithProduct().ToList();
			if (collection.IsValid())
			{
				StallInteractable random = collection.GetRandom();
				float buyProductProbability = AIClientSettings.GetBuyProductProbability(random.GetProductMarketPricePercentage());
				if (UnityEngine.Random.value < buyProductProbability)
				{
					base.Controller.InputReceiver.OnAIInput_SecondaryInteraction(random);
				}
				base.ClientState = EClientState.KILLING_TIME;
				DoActivityFor(AIModelSettings.TakeProductAnimDuration);
				return true;
			}
			CompleteCurrentStand();
			return false;
		}

		protected virtual void QuitOptionalStand()
		{
			if (base.State == EAIBehaviourState.WAITING_IN_LINE)
			{
				EStandType type = base.CurrentStand.Type;
				if (type == EStandType.PAINTING || type == EStandType.WARGAME)
				{
					QuitCurrentStandWithoutComplete();
					return;
				}
			}
			EClientState clientState = base.ClientState;
			if (clientState == EClientState.PAINTING || clientState == EClientState.WARGAMING)
			{
				float completeTasksDuration = AIClientSettings.CompleteTasksDuration;
				if (GetActivityTimelineTimeLeft() > completeTasksDuration)
				{
					KillActivityTimeline();
					DoActivityFor(completeTasksDuration);
				}
			}
		}

		private void StartPainting()
		{
			m_timeSinceLastPaintingMoneyGeneration = 0f;
			m_paintingDuration = 0f;
			m_paintingMoneyProduced = 0f;
			DoActivityFor(AIClientSettings.PaintingTimeRange.GetRandomInRange());
			if (base.CurrentStand is PaintingTableStand paintingTableStand)
			{
				m_paintingFurnitureLevel = paintingTableStand.FurnitureLevel;
				base.NavAgent.enabled = false;
				base.ClientCharacter.SetSitted(sitted: true);
				base.ClientCharacter.SetPainting(painting: true);
			}
		}

		private void UpdatePainting(float deltaTime)
		{
			m_paintingDuration += deltaTime;
			m_timeSinceLastPaintingMoneyGeneration += deltaTime;
			if (m_timeSinceLastPaintingMoneyGeneration >= PaintingSettings.MoneyGenFrequency)
			{
				float moneyGenAmount = PaintingSettings.GetMoneyGenAmount(m_paintingFurnitureLevel);
				m_paintingMoneyProduced += moneyGenAmount;
				World.GameState.GainMoney(moneyGenAmount);
				m_timeSinceLastPaintingMoneyGeneration -= PaintingSettings.MoneyGenFrequency;
			}
			if (m_paintingDuration > AIClientSettings.PaintingTimeRange.y + 2f)
			{
				KillActivityTimeline();
				OnActivityCompleted();
			}
		}

		private void OnCompletePainting()
		{
			base.NavAgent.enabled = true;
			base.ClientCharacter.SetSitted(sitted: false);
			base.ClientCharacter.SetPainting(painting: false);
			TabletopClientBehaviour.CompletedPainting?.Invoke(m_paintingDuration, m_paintingMoneyProduced);
		}

		private void OnArriveAtWargameStand(WargameStand stand)
		{
			TabletopClientBehaviour otherClient;
			if (stand.IsFacingPlayer())
			{
				StartWargameAgainstPlayer();
			}
			else if (stand.TryGetOtherClient(out otherClient))
			{
				StartWargameWithOtherClient(otherClient);
			}
			else
			{
				StartWargameAlone();
			}
		}

		private void StartWargameAlone()
		{
			m_isPlayingWargame = false;
			m_wargameDuration = 0f;
			DoActivityFor(AIClientSettings.WargameTimeRange.GetRandomInRange());
			if (base.CurrentStand is WargameStand wargameStand)
			{
				m_wargameFurnitureLevel = wargameStand.FurnitureLevel;
				base.NavAgent.enabled = false;
				base.ClientCharacter.SetSitted(sitted: true);
				base.ClientCharacter.SetPlaying(playing: true);
			}
		}

		private void StartWargameAgainstPlayer()
		{
			base.State = EAIBehaviourState.ACTIVE;
			m_isPlayingWargame = false;
			m_wargameDuration = 0f;
			if (base.CurrentStand is WargameStand)
			{
				base.NavAgent.enabled = false;
				ForceWalk(walk: false);
				base.ClientCharacter.SetSitted(sitted: true);
				base.ClientCharacter.SetPlaying(playing: true);
				base.ClientCharacter.SetAnimatorUpdateMode(AnimatorUpdateMode.UnscaledTime);
			}
		}

		private void StartWargameWithOtherClient(TabletopClientBehaviour otherClient)
		{
			m_isPlayingWargame = true;
			m_wargameDuration = 0f;
			m_timeSinceLastWargameMoneyGeneration = 0f;
			m_wargameMoneyProduced = 0f;
			float randomInRange = AIClientSettings.WargameTimeRange.GetRandomInRange();
			DoActivityFor(randomInRange);
			if (base.CurrentStand is WargameStand wargameStand)
			{
				m_wargameFurnitureLevel = wargameStand.FurnitureLevel;
				base.NavAgent.enabled = false;
				base.ClientCharacter.SetSitted(sitted: true);
				base.ClientCharacter.SetPlaying(playing: true);
			}
			otherClient.JoinedOnWargame(randomInRange);
		}

		public void JoinedOnWargame(float duration)
		{
			m_isPlayingWargame = true;
			m_timeSinceLastWargameMoneyGeneration = 0f;
			m_wargameMoneyProduced = 0f;
			KillActivityTimeline();
			DoActivityFor(duration);
		}

		public void JoinedOnWargameByPlayer()
		{
			KillActivityTimeline();
			base.ClientCharacter.SetAnimatorUpdateMode(AnimatorUpdateMode.UnscaledTime);
			WargameManager.WargameCompleted += OnPlayerWargameCompleted;
		}

		public void JoinPlayerOnWargame(Stand stand)
		{
			AccessStand(stand);
			WargameManager.WargameCompleted += OnPlayerWargameCompleted;
		}

		private void UpdateWargame(float deltaTime)
		{
			m_wargameDuration += deltaTime;
			if (m_isPlayingWargame)
			{
				m_timeSinceLastWargameMoneyGeneration += deltaTime;
				if (m_timeSinceLastWargameMoneyGeneration >= WargameSettings.MoneyGenFrequency)
				{
					float moneyGenAmount = WargameSettings.GetMoneyGenAmount(m_wargameFurnitureLevel);
					m_wargameMoneyProduced += moneyGenAmount;
					World.GameState.GainMoney(moneyGenAmount);
					m_timeSinceLastWargameMoneyGeneration -= WargameSettings.MoneyGenFrequency;
				}
			}
		}

		private void OnPlayerWargameCompleted()
		{
			WargameManager.WargameCompleted -= OnPlayerWargameCompleted;
			base.ClientCharacter.SetAnimatorUpdateMode(AnimatorUpdateMode.Normal);
			OnCompleteWargame();
			CompleteCurrentStand();
		}

		private void OnCompleteWargame()
		{
			base.NavAgent.enabled = true;
			base.ClientCharacter.SetSitted(sitted: false);
			base.ClientCharacter.SetPlaying(playing: false);
			TabletopClientBehaviour.CompletedWargame?.Invoke(m_wargameDuration, m_wargameMoneyProduced);
		}
	}
}
