using Data.Save;
using Player.Stats;
using Services.Enemy;
using UnityEngine;
using Zenject;

namespace Services.Save.Player
{
	public class PlayerSaveHandler : MonoBehaviour
	{
		[Inject]
		private IPlayerStatsService _playerStatsService;

		[Inject]
		private IMoneyService _moneyService;

		[Inject]
		private PlayerSaveService _playerSaveService;

		[Inject]
		private ILoyaltyService _loyaltyService;

		private void OnEnable()
		{
			_playerSaveService.OnLoadCompleted += RenewSaved;
			_playerSaveService.OnSaveStarted += SaveStarted;
		}

		private void OnDisable()
		{
			_playerSaveService.OnLoadCompleted -= RenewSaved;
			_playerSaveService.OnSaveStarted -= SaveStarted;
		}

		private void SaveStarted()
		{
			_playerSaveService.PlayerData.Alcohol = _playerStatsService.AlcoholStat;
			_playerSaveService.PlayerData.Nicotine = _playerStatsService.NicotineStat;
			_playerSaveService.PlayerData.Position = base.transform.position;
			_playerSaveService.PlayerData.Rotation = base.transform.rotation.eulerAngles;
			_playerSaveService.PlayerData.MoneyData.FlyCoinsBalance = _moneyService.CurrencyBalance.FlyCoinsBalance;
		}

		private void RenewSaved()
		{
			PlayerSaveData playerData = _playerSaveService.PlayerData;
			if (playerData.Position == Vector3.zero)
			{
				_moneyService.SetCurrency(6.699999809265137);
				return;
			}
			base.transform.position = playerData.Position;
			base.transform.rotation = Quaternion.Euler(playerData.Rotation);
			_playerStatsService.SetAlcoholStat(playerData.Alcohol);
			_playerStatsService.SetNicotineStat(playerData.Nicotine);
			_moneyService.AddCurrency(playerData.MoneyData.FlyCoinsBalance);
			_loyaltyService.SetStressValue(playerData.GameData.EnemyLoyalty);
		}
	}
}
