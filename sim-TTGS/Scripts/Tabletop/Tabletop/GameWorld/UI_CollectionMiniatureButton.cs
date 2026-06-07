using System;
using Dhs5.Utility.Updates;
using Simulator;
using Simulator.Preview3D;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionMiniatureButton : NavButton, IActivable
	{
		[SerializeField]
		private GameObject m_container;

		[Header("UI Components")]
		[SerializeField]
		private UI_CollectionMiniatureHoldButton m_holdButton;

		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private Image m_rarityImage;

		[SerializeField]
		private Image m_armyImage;

		[SerializeField]
		private GenericTooltipDisplayer m_armyTooltip;

		[SerializeField]
		private Image m_unavailabilityImage;

		[SerializeField]
		private Graphic m_undiscoveredGraphic;

		[SerializeField]
		private GameObject m_newIcon;

		[SerializeField]
		private SimulatorText m_nameText;

		[SerializeField]
		private UI_CollectedPiecesIndicator m_collectedPiecesIndicator;

		[SerializeField]
		private NavButton m_assembleButton;

		[SerializeField]
		private UI_MiniaturePaintButton m_paintButton;

		[SerializeField]
		private UI_WargameMiniatureTooltip m_wargameSkillTooltip;

		[SerializeField]
		private RectTransform m_armyAndPossessedContainer;

		[Header("Parameters")]
		[SerializeField]
		private int m_index;

		private DelayedCallHandle m_hoverDelayedCall;

		public MiniatureData Data { get; private set; }

		public bool IsDiscovered { get; private set; }

		public bool IsAvailable { get; private set; }

		public static event Action<int> Clicked;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Application.isPlaying)
			{
				UI_CollectionMiniatureHoldButton holdButton = m_holdButton;
				holdButton.SubmitHoldCompleteEvent = (Action)Delegate.Combine(holdButton.SubmitHoldCompleteEvent, new Action(OnSubmitHoldComplete));
				UI_CollectionMiniatureHoldButton holdButton2 = m_holdButton;
				holdButton2.SubmitEvent = (Action)Delegate.Combine(holdButton2.SubmitEvent, new Action(Click));
				m_assembleButton.Button.onClick.AddListener(OnAssemble);
				m_paintButton.Pressed += OnPaint;
				Collection.StartAssembleMiniature += OnAssembledMiniature;
				UI_CollectionSquadEditionScreen.SquadModified += OnSquadModified;
				UpdateImageRect();
				m_undiscoveredGraphic.color = CollectionSettings.UndiscoveredColor;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Application.isPlaying)
			{
				UI_CollectionMiniatureHoldButton holdButton = m_holdButton;
				holdButton.SubmitHoldCompleteEvent = (Action)Delegate.Remove(holdButton.SubmitHoldCompleteEvent, new Action(OnSubmitHoldComplete));
				UI_CollectionMiniatureHoldButton holdButton2 = m_holdButton;
				holdButton2.SubmitEvent = (Action)Delegate.Remove(holdButton2.SubmitEvent, new Action(Click));
				m_assembleButton.Button.onClick.RemoveListener(OnAssemble);
				m_paintButton.Pressed -= OnPaint;
				Collection.StartAssembleMiniature -= OnAssembledMiniature;
				UI_CollectionSquadEditionScreen.SquadModified -= OnSquadModified;
			}
		}

		public override bool IsActive()
		{
			if (base.IsActive())
			{
				return m_container.activeSelf;
			}
			return false;
		}

		public void SetContent(CollectionElement collectionElement)
		{
			Data = collectionElement.data;
			IsDiscovered = collectionElement.discovered;
			SetActive(active: true);
			m_miniatureImage.enabled = IsDiscovered;
			m_undiscoveredGraphic.enabled = !IsDiscovered;
			Sprite collectionSpriteFromRarity = MiniatureSettings.GetCollectionSpriteFromRarity(Data.Type);
			m_rarityImage.sprite = collectionSpriteFromRarity;
			m_rarityImage.enabled = collectionSpriteFromRarity != null;
			m_armyImage.sprite = MiniatureSettings.GetArmySprite(Data.Army);
			m_armyTooltip.SetTerm(MiniatureSettings.GetArmyTerm(Data.Army));
			m_newIcon.SetActive(Collection.MiniatureHasNewPiece(Data.UID));
			m_nameText.SetTerm(Data.NameLocaKey);
			m_nameText.Text.enabled = IsDiscovered;
			m_wargameSkillTooltip.SetContent(Data.Skill, showLifePoints: false);
			switch (Collection.Mode)
			{
			case ECollectionMode.BROWSE:
				SetAvailable(available: true);
				m_paintButton.SetActive(active: false);
				m_collectedPiecesIndicator.Total = Data.NecessaryPiecesCount;
				m_collectedPiecesIndicator.Value = collectionElement.piecesCount;
				m_assembleButton.gameObject.SetActive(m_collectedPiecesIndicator.CanAssemble());
				m_holdButton.SetAvailable(m_assembleButton.IsActive());
				m_collectedPiecesIndicator.SetCompletedValue(collectionElement.totalAssembled);
				m_armyAndPossessedContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 272f);
				m_wargameSkillTooltip.gameObject.SetActive(value: false);
				break;
			case ECollectionMode.PAINTING:
				SetAvailable(available: true);
				m_paintButton.SetActive(active: true);
				m_paintButton.SetContent(collectionElement.completed);
				m_holdButton.SetAvailable(m_paintButton.IsActive());
				m_assembleButton.gameObject.SetActive(value: false);
				m_collectedPiecesIndicator.SetCompletedValue(collectionElement.totalAssembled);
				m_armyAndPossessedContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 272f);
				m_wargameSkillTooltip.gameObject.SetActive(value: false);
				break;
			case ECollectionMode.SELLING:
				SetAvailable(available: true);
				m_paintButton.SetActive(active: false);
				m_holdButton.SetAvailable(available: false);
				m_collectedPiecesIndicator.SetCompletedValue(collectionElement.totalAssembled);
				m_armyAndPossessedContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 272f);
				m_wargameSkillTooltip.gameObject.SetActive(value: false);
				break;
			case ECollectionMode.SQUAD_EDITION:
				SetAvailable(Collection.IsMiniatureAvailableForSquad(UI_CollectionSquadEditionScreen.CurrentlyEditedSquad, Data));
				m_paintButton.SetActive(active: false);
				m_holdButton.SetAvailable(available: false);
				m_collectedPiecesIndicator.SetCompletedValue(collectionElement.painted);
				m_armyAndPossessedContainer.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 95f);
				m_wargameSkillTooltip.gameObject.SetActive(value: true);
				break;
			}
		}

		public void RefreshContent()
		{
			SetContent(Collection.GetCollectionElement(Data));
		}

		private void UpdateImageRect()
		{
			m_miniatureImage.uvRect = Preview3DManager.Instance.GetImageRectAtIndex(m_index);
		}

		private void SetAvailable(bool available)
		{
			IsAvailable = available;
			m_unavailabilityImage.enabled = !IsAvailable;
		}

		private void OnBeginHover()
		{
			m_newIcon.SetActive(value: false);
			if (Data != null)
			{
				Collection.MiniaturePiecesHaveBeenLookedAt(Data.UID);
			}
			Updater.CallInXSeconds(0.8f, OnLongHover, out m_hoverDelayedCall);
		}

		private void OnEndHover()
		{
			m_hoverDelayedCall.Kill();
		}

		private void OnLongHover()
		{
		}

		private void Click()
		{
			if (IsDiscovered && IsAvailable)
			{
				UI_CollectionMiniatureButton.Clicked?.Invoke(Data.UID);
			}
		}

		private void OnAssemble()
		{
			Collection.Assemble(Data.UID);
			m_collectedPiecesIndicator.Assemble();
		}

		private void OnPaint()
		{
			Collection.StartPainting(Data.UID);
		}

		private void OnAssembledMiniature(int uid, bool newMiniature)
		{
			if (Data != null && uid == Data.UID)
			{
				RefreshContent();
			}
		}

		private void OnSquadModified(CollectionWargameSquad squad)
		{
			if (Data != null)
			{
				SetAvailable(Collection.IsMiniatureAvailableForSquad(squad, Data));
			}
		}

		public void SetActive(bool active)
		{
			m_container.SetActive(active);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.gameObject.activeSelf)
			{
				base.OnPointerEnter(eventData);
				OnBeginHover();
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			OnEndHover();
		}

		private void OnSubmitHoldComplete()
		{
			if (m_paintButton.IsActive() && m_paintButton.IsInteractable())
			{
				OnPaint();
			}
			else if (m_assembleButton.IsActive() && m_assembleButton.IsInteractable())
			{
				OnAssemble();
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			OnBeginHover();
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			OnEndHover();
		}
	}
}
