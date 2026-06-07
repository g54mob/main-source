using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_MiniatureNewPieceCard : MonoBehaviour, IActivable
	{
		[SerializeField]
		private GameObject m_container;

		[Header("UI Components")]
		[SerializeField]
		private Image m_licenseImage;

		[SerializeField]
		private Image m_armyImage;

		[SerializeField]
		private TextMeshProUGUI m_armyText;

		[SerializeField]
		private TextMeshProUGUI m_miniatureNameText;

		[SerializeField]
		private Image m_miniatureImage;

		[SerializeField]
		private TextMeshProUGUI m_miniatureCollectedText;

		[SerializeField]
		private TextMeshProUGUI m_miniatureCompletionText;

		[SerializeField]
		private TextMeshProUGUI m_miniaturePriceText;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_piecesInCollectionText;

		[SerializeField]
		private TextMeshProUGUI m_pieceIndexText;

		public MiniaturePieceData Data { get; private set; }

		public int Index { get; private set; }

		public void Init(MiniaturePieceData pieceData, int index)
		{
			Data = pieceData;
			Index = index;
			MiniatureData miniatureData = pieceData.MiniatureData;
			MiniatureCollectionState miniatureState = Collection.GetMiniatureState(miniatureData.UID);
			m_licenseImage.sprite = MiniatureSettings.GetLicenseSprite(miniatureData.License);
			m_armyImage.sprite = MiniatureSettings.GetArmySprite(miniatureData.Army);
			m_armyText.text = miniatureData.Army.ToString();
			m_miniatureNameText.text = miniatureData.name;
			m_miniatureCollectedText.text = (miniatureState.completedCount + miniatureState.paintedCount).ToString();
			m_miniatureCompletionText.text = miniatureState.currentPiecesCount + "/" + miniatureData.NecessaryPiecesCount;
			m_miniaturePriceText.text = miniatureData.MarketPrice.ToStringMoneyFormat();
			m_piecesInCollectionText.text = Collection.GetPieceCount(pieceData.UID).ToString();
			m_pieceIndexText.text = index + 1 + "/" + Collection.NewPieces.Count;
			if (index != 0)
			{
				SetActive(active: false);
			}
		}

		public void SetActive(bool active)
		{
			m_container.SetActive(active);
		}
	}
}
