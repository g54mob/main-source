using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class SurvarotsDisplayContainer : MonoBehaviour, IArcanaDisplayContainer
	{
		[SerializeField]
		private ArcanaCardUI _ArcanaCardPrefab;

		[SerializeField]
		private RectTransform _ArcanaCardContainer;

		[SerializeField]
		private CardInfoUI _cardInfoPanel;

		[SerializeField]
		private float _ArcanaInfoScaleInDuration;

		[SerializeField]
		private float _ArcanaPortraitInfoPanelOffset;

		private DataManager _dataManager;

		private GameManager _gameManager;

		private List<ArcanaCardUI> _spawnedCards;

		private List<Tween> _spawnedCardTimers;

		private CharacterSkillCard_Base _currentShowingCard;

		private bool _ignoreNextArcanaClick;

		public Selectable FirstCardSelectable => null;

		[Inject]
		private void Construct(DataManager dataManager, GameManager game)
		{
		}

		private void Start()
		{
		}

		public void SetCardDetails()
		{
		}

		public void ShowSelf()
		{
		}

		public void HideSelf()
		{
		}

		private void CardOnBecameSelected(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform)
		{
		}

		private void CardOnBecameDeselected(ArcanaType arcanaType)
		{
		}

		public void ToggleArcanaInfoPanel(SelectableUI arcanaCardUI, ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform, bool toggleFromClick, bool toggleFromSelectionChange)
		{
		}

		public void ShowArcanaInfoPanel(CharacterSkillCard_Base card, Transform cardTransform, ArcanaData arcanaData)
		{
		}

		public void HideArcanaInfoPanel()
		{
		}

		public void ConfigureNavigationForCharacterCards(Selectable down = null, Selectable left = null, Selectable right = null, Selectable up = null)
		{
		}
	}
}
