using Events.WorldMap;
using TMPro;
using UnityEngine;

namespace Presentation.UI.WorldMap
{
	public class WorldMapHUD : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _playerFametext;

		[SerializeField]
		private PlayerFameChangedEvent _playerFameChangedEvent;

		private void Start()
		{
		}

		private void Awake()
		{
			_playerFameChangedEvent.Register(OnPlayerFameChanged);
		}

		private void OnDestroy()
		{
			_playerFameChangedEvent.UnRegister(OnPlayerFameChanged);
		}

		private void OnPlayerFameChanged(int newFame)
		{
			_playerFametext.SetText("Fame: " + newFame);
		}
	}
}
