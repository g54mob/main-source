using TMPro;
using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Tools
{
	public class Cheats : GameMonoBehaviour
	{
		private SignalBus _signalBus;

		private GameSessionData _gameSessionData;

		private LevelUpFactory _levelUpFactory;

		private GameManager _gameManager;

		[SerializeField]
		private GameObject _automationCancel;

		[SerializeField]
		private TextMeshProUGUI _spawnedEnemyCount;

		[SerializeField]
		private TextMeshProUGUI _temporaryEnemyCount;

		[SerializeField]
		private TextMeshProUGUI _permanentEnemyCount;

		[SerializeField]
		private TextMeshProUGUI _currentTimeText;

		[Inject]
		private void Construct(SignalBus signalBus, GameSessionData gameSessionData, LevelUpFactory levelUpFactory, GameManager gameManager)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void ForceTreasure(int level)
		{
		}

		public void FindRelic()
		{
		}

		public void FindItem()
		{
		}

		public void ForceLevelUp()
		{
		}

		public void Pause()
		{
		}

		public void KillPlayer()
		{
		}

		public void AddRandomExperience()
		{
		}

		public void PickupCoinBag()
		{
		}

		public void CancelAutomation()
		{
		}
	}
}
