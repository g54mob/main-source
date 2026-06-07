using Simulator;
using Simulator.Preview3D;
using TMPro;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionMiniaturePopup : UI_CollectionPopup
	{
		[SerializeField]
		private CanvasGroup m_group;

		[Header("UI Components")]
		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private Button m_marketHistoryButton;

		[SerializeField]
		private UI_Preview3DObjectManipulator m_preview3DObjectManipulator;

		[Space(10f)]
		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private Image m_licenseImage;

		[SerializeField]
		private Image m_rarityImage;

		[SerializeField]
		private TextMeshProUGUI m_nameText;

		[SerializeField]
		private TextMeshProUGUI m_marketPriceText;

		[SerializeField]
		private UI_CollectionScoreStar[] m_scoreStars;

		[SerializeField]
		private UI_CollectedPiecesIndicator m_collectedPiecesIndicator;

		[SerializeField]
		private Image[] m_armyImages;

		[SerializeField]
		private TextMeshProUGUI m_armyText;

		[SerializeField]
		private UI_WargameMiniatureTooltip m_wargameSkillTooltip;

		public int MiniatureUID { get; private set; }

		protected override void OnEnable()
		{
			base.OnEnable();
			Collection.StartAssembleMiniature += OnAssembledMiniature;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Collection.StartAssembleMiniature -= OnAssembledMiniature;
		}

		public void Open(int miniatureUID)
		{
			if (Collection.Mode != ECollectionMode.SELLING)
			{
				TabletopPreview3DManager.Instance.FocusMiniature(miniatureUID, highlightMissingPieces: true);
				SetActive(active: true);
				SetContent(miniatureUID);
			}
		}

		public void SetContent(int miniatureUID)
		{
			MiniatureUID = miniatureUID;
			MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
			MiniatureCollectionState miniatureState = Collection.GetMiniatureState(miniatureUID);
			m_preview3DObjectManipulator.Target = Preview3DManager.Instance.GetFocusedObject();
			m_preview3DObjectManipulator.RegisterToUpdate(register: true);
			m_miniatureImage.uvRect = TabletopPreview3DManager.Instance.GetFocusedMiniatureRect();
			m_licenseImage.sprite = MiniatureSettings.GetLicenseSprite(miniatureData.License);
			m_rarityImage.sprite = MiniatureSettings.GetCollectionSpriteFromRarity(miniatureData.Type);
			m_rarityImage.enabled = m_rarityImage.sprite != null;
			m_nameText.text = miniatureData.GetLocalizedName();
			m_marketPriceText.text = miniatureData.MarketPrice.ToStringMoneyFormat();
			m_collectedPiecesIndicator.SetCompletedValue(miniatureState.completedCount + miniatureState.paintedCount);
			SetScoreStars(Collection.GetPaintMaxScore(miniatureUID));
			m_collectedPiecesIndicator.Total = miniatureData.NecessaryPiecesCount;
			m_collectedPiecesIndicator.Value = miniatureState.currentPiecesCount;
			m_wargameSkillTooltip.SetContent(miniatureData.Skill);
			Sprite armySprite = MiniatureSettings.GetArmySprite(miniatureData.Army);
			Image[] armyImages = m_armyImages;
			for (int i = 0; i < armyImages.Length; i++)
			{
				armyImages[i].sprite = armySprite;
			}
			m_armyText.text = miniatureData.GetLocalizedArmy();
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			m_group.alpha = 1f;
			m_group.blocksRaycasts = true;
			m_navBox.SelectFirstChild();
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			m_group.alpha = 0f;
			m_group.blocksRaycasts = false;
			m_preview3DObjectManipulator.RegisterToUpdate(register: false);
			Preview3DManager.Instance.Unfocus();
		}

		public override bool CanBeClosed()
		{
			return true;
		}

		private void OnAssembledMiniature(int uid, bool newMiniature)
		{
			if (uid == MiniatureUID)
			{
				SetContent(MiniatureUID);
			}
		}

		private void SetScoreStars(int score)
		{
			int num = Mathf.CeilToInt((float)score / (float)m_scoreStars.Length);
			for (int i = 0; i < m_scoreStars.Length - 1; i++)
			{
				m_scoreStars[i].SetGained(i < num);
			}
		}
	}
}
