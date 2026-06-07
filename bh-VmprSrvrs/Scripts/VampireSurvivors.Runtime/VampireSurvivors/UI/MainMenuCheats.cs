using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MainMenuCheats : MonoBehaviour
	{
		[SerializeField]
		private GameObject _CheatButtonPrefab;

		[SerializeField]
		private RectTransform _CharacterContainer;

		[SerializeField]
		private RectTransform _StageContainer;

		[SerializeField]
		private RectTransform _RelicContainer;

		[SerializeField]
		private RectTransform _PowerUpContainer;

		[SerializeField]
		private RectTransform _WeaponContainer;

		private PlayerOptions _playerOptions;

		private SignalBus _signalBus;

		private DataManager _dataManager;

		[Inject]
		private void Construct(SignalBus signal, PlayerOptions player, DataManager data)
		{
		}

		private void Start()
		{
		}

		private void Populate()
		{
		}

		public void AddCoins()
		{
		}
	}
}
