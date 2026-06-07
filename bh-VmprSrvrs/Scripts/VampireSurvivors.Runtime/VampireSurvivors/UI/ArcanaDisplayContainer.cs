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
	public class ArcanaDisplayContainer : MonoBehaviour, IArcanaDisplayContainer
	{
		[SerializeField]
		private ArcanaCardUI _ArcanaCardPrefab;

		[SerializeField]
		private RectTransform _ArcanaCardContainer;

		[SerializeField]
		private ArcanaInfoPanel _ArcanaInfoPanel;

		[SerializeField]
		private float _ArcanaInfoScaleInDuration;

		[SerializeField]
		private float _ArcanaPortraitInfoPanelOffset;

		private DataManager _dataManager;

		private GameManager _gameManager;

		private List<ArcanaCardUI> _spawnedCards;

		private List<Tween> _spawnedCardTimers;

		private ArcanaType _currentShowingArcana;

		private bool _ignoreNextArcanaClick;

		public Selectable FirstCardSelectable => null;

		[Inject]
		private void Construct(DataManager dataManager, GameManager game)
		{
		}

		private void Start()
		{
		}

		public void SetArcanaInfoPanelControllingPlayer(VampireSurvivors.Objects.Characters.CharacterController characterController)
		{
		}

		public void SetArcanaDetails()
		{
		}

		private void OnEnable()
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

		public void ShowArcanaInfoPanel(ArcanaData arcanaData, ArcanaType arcanaType, Transform cardTransform)
		{
		}

		public void HideArcanaInfoPanel()
		{
		}

		public void ConfigureNavigationForArcanaCards(Selectable down = null, Selectable left = null, Selectable right = null, Selectable up = null)
		{
		}
	}
}
