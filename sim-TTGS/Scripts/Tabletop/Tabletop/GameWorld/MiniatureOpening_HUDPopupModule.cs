using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Dhs5.Utility.Updates;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class MiniatureOpening_HUDPopupModule : TabletopHUDPopupModule
	{
		[SerializeField]
		private ObjectActivator m_activator;

		[SerializeField]
		private Transform m_cardsContainer;

		[SerializeField]
		private GameObject m_newPieceCardPrefab;

		[SerializeField]
		private Image m_eventHandlerImage;

		[SerializeField]
		private Image m_timerImage;

		[Header("Tutorial")]
		[SerializeField]
		private TutorialData m_miniatureAssemblingTutorialData;

		private Queue<UI_MiniatureNewPieceCard> m_newPieceQueue = new Queue<UI_MiniatureNewPieceCard>();

		private UpdateTimelineInstanceHandle m_updateHandle;

		private float m_timeSinceLastSkip;

		private bool m_isSkipAvailable = true;

		private Tween m_delayActionLeftClick;

		private bool m_speedSkipping;

		private bool m_pointerDown;

		public override ETabletopHUDPopupModuleType ActualType => ETabletopHUDPopupModuleType.MINIATURE_OPENING;

		public static event Action<int> OnNewPiece;

		protected override void OnSetActive()
		{
			base.OnSetActive();
			ICancelInputReceiver.SetCurrent(null);
			EventSystem.current.SetSelectedGameObject(base.gameObject);
			m_eventHandlerImage.enabled = true;
			m_newPieceQueue.Clear();
			int num = 0;
			foreach (MiniaturePieceData newPiece in Collection.NewPieces)
			{
				CreateNewPieceCard(newPiece, num);
				num++;
			}
			OnSkip();
			Updater.CreateTimelineInstance(EUpdateChannel.CLASSIC, (float)Collection.NewPieces.Count * 5f, out m_updateHandle);
			m_updateHandle.Updated += OnUpdate;
			m_updateHandle.Play();
			InputActionMap map = TransientManager<InputManager>.Instance.GetMap(InputManager.EMap.UI);
			InputAction inputAction = map.FindAction("Submit");
			map.FindAction("Click").performed += OnClickAction;
			inputAction.performed += OnSubmitAction;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_eventHandlerImage.enabled = false;
			InputActionMap map = TransientManager<InputManager>.Instance.GetMap(InputManager.EMap.UI);
			InputAction inputAction = map.FindAction("Submit");
			map.FindAction("Click").performed -= OnClickAction;
			inputAction.performed -= OnSubmitAction;
		}

		private void CreateNewPieceCard(MiniaturePieceData pieceData, int index)
		{
			UI_MiniatureNewPieceCard component = UnityEngine.Object.Instantiate(m_newPieceCardPrefab, m_cardsContainer).GetComponent<UI_MiniatureNewPieceCard>();
			component.Init(pieceData, index);
			m_newPieceQueue.Enqueue(component);
			MiniatureOpening_VFXBox.CurrentlyPlaying.OnCreateCard(pieceData, index);
		}

		private float GetTimeToSkip()
		{
			if (!m_speedSkipping)
			{
				return CollectionSettings.UnpackingBaseDelay;
			}
			return CollectionSettings.UnpackingSpeedDelay;
		}

		private void OnUpdate(float deltaTime)
		{
			m_timeSinceLastSkip += deltaTime;
			float timeToSkip = GetTimeToSkip();
			float fillAmount = Mathf.Clamp01(m_timeSinceLastSkip / timeToSkip);
			m_timerImage.fillAmount = fillAmount;
			if (m_timeSinceLastSkip >= timeToSkip)
			{
				OnSkip();
			}
		}

		private void OnSkip()
		{
			m_timeSinceLastSkip = 0f;
			if (m_newPieceQueue.TryDequeue(out var result))
			{
				m_activator.Activate(result);
				OnShowNewPiece(result);
				MiniatureOpening_VFXBox.CurrentlyPlaying.OnSkip();
			}
			else
			{
				MiniatureOpening_VFXBox.CurrentlyPlaying.OnEnd(OnCompleteOpening);
			}
		}

		private void OnShowNewPiece(UI_MiniatureNewPieceCard card)
		{
			MiniatureOpening_HUDPopupModule.OnNewPiece?.Invoke(card.Data.MiniatureData.Rarity);
		}

		private void OnCompleteOpening()
		{
			Updater.KillTimelineInstance(m_updateHandle);
			Validate();
			UnityEngine.Object.Destroy((World.PlayerCharacter.GiveStackable() as Component).gameObject);
			if (Collection.GetCollectionElementsWithNewPieces().Any(Collection.CanAssemble))
			{
				Tutorial.TryShow(m_miniatureAssemblingTutorialData, TryOpenCollectionModePostUnpacking);
			}
			else
			{
				TryOpenCollectionModePostUnpacking();
			}
			static void TryOpenCollectionModePostUnpacking()
			{
				if (!World.PlayerCharacter.HasStackable(out var _))
				{
					Collection.Open(ECollectionMode.BROWSE);
				}
			}
		}

		public void LockLeftClickForXSeconds(float seconds = 0.6f)
		{
			m_delayActionLeftClick?.Kill();
			m_isSkipAvailable = false;
			m_delayActionLeftClick = DOVirtual.DelayedCall(seconds, delegate
			{
				m_isSkipAvailable = true;
			});
			m_delayActionLeftClick.Play();
		}

		public void OnSubmitAction(InputAction.CallbackContext context)
		{
			if (m_isSkipAvailable)
			{
				OnSkip();
			}
		}

		public void OnClickAction(InputAction.CallbackContext context)
		{
			if (m_isSkipAvailable && context.phase == InputActionPhase.Performed)
			{
				OnSkip();
			}
		}
	}
}
