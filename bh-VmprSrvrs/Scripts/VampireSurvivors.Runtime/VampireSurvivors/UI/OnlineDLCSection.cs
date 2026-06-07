using System.Collections.Generic;
using Coherence.Cloud;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class OnlineDLCSection : MonoBehaviour
	{
		[SerializeField]
		private List<OnlineDLCIcon> _OnlineDLCIcons;

		[SerializeField]
		private GameObject _DLCIconContainer;

		[SerializeField]
		private OnlineDLCIcon _DLCIconPrefab;

		[SerializeField]
		private GameObject _DLCInfoContainer;

		[SerializeField]
		private TextMeshProUGUI _DLCInfoTitle;

		[SerializeField]
		private TextMeshProUGUI _DLCInfoMessage;

		private bool _isPopulated;

		private Dictionary<LobbyPlayer, List<DlcType>> _playerOwnedDLCs;

		private List<DlcType> _availableDLCs;

		private void OnEnable()
		{
		}

		private void Populate()
		{
		}

		public void UpdateUI(List<DlcType> availableDLCs, Dictionary<LobbyPlayer, List<DlcType>> playerOwnedDLCs)
		{
		}

		public void UpdateDlcInfoPanel()
		{
		}

		public void PopulateInfoPanel(DlcType dlcType)
		{
		}

		public void HideInfoPanel()
		{
		}
	}
}
