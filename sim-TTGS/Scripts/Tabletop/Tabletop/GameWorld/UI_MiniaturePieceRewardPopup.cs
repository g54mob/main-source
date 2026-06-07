using Simulator;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_MiniaturePieceRewardPopup : MonoBehaviour, IActivable
	{
		[SerializeField]
		private RawImage m_pieceRawImage;

		[SerializeField]
		private Image m_rarityImage;

		[SerializeField]
		private SimulatorText m_miniatureText;

		[SerializeField]
		private SimulatorText m_armyText;

		[SerializeField]
		private Button m_okButton;

		private void OnEnable()
		{
			m_okButton.onClick.AddListener(OnButton_Ok);
		}

		private void OnDisable()
		{
			m_okButton.onClick.RemoveListener(OnButton_Ok);
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void SetContent(MiniaturePieceData pieceData)
		{
			TabletopPreview3DManager instance = TabletopPreview3DManager.Instance;
			instance.FocusPiece(pieceData);
			m_pieceRawImage.uvRect = instance.GetFocusedMiniatureRect();
			m_rarityImage.sprite = MiniatureSettings.GetCollectionSpriteFromRarity(pieceData.MiniatureData.Type);
			m_rarityImage.enabled = pieceData.MiniatureData.Type != EMiniatureType.COMMON;
			m_armyText.SetTerm(MiniatureSettings.GetArmyTerm(pieceData.MiniatureData.Army));
			m_miniatureText.SetTerm(pieceData.MiniatureData.NameLocaKey);
		}

		private void OnButton_Ok()
		{
			SetActive(active: false);
		}
	}
}
