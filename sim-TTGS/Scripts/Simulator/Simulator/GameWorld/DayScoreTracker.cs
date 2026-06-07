using System.Collections.Generic;

namespace Simulator.GameWorld
{
	public class DayScoreTracker
	{
		private int _startLevel;

		private List<int> _productsSold = new List<int>();

		private List<float> _productsIncomes = new List<float>();

		private List<int> _satisfactions = new List<int>();

		private float _startMoney;

		private float m_startMoneySinceLastLoad;

		public int XP { get; private set; }

		public int Levels => GameState.ShopLevel - _startLevel;

		public int ProductsSold => _productsSold.Sum();

		public float ProductsIncome => _productsIncomes.Sum();

		public int Visits => _satisfactions.Count;

		public float Satisfaction => _satisfactions.Average();

		public float AverageProductsBought => _productsSold.Average();

		public float AverageBuy => _productsIncomes.Average();

		public float TotalIncomes { get; private set; }

		public float SupplyCost { get; private set; }

		public float LicenseCost { get; private set; }

		public float TotalBalance => GameState.MoneyAmount - _startMoney;

		private float TotalBalanceSinceLastLoad => GameState.MoneyAmount - m_startMoneySinceLastLoad;

		public DayScoreTracker()
		{
			Register();
			Load();
		}

		public virtual void Init()
		{
			XP = 0;
			_startLevel = GameState.ShopLevel;
			_productsSold.Clear();
			_productsIncomes.Clear();
			_satisfactions.Clear();
			TotalIncomes = 0f;
			SupplyCost = 0f;
			LicenseCost = 0f;
			_startMoney = GameState.MoneyAmount;
			m_startMoneySinceLastLoad = _startMoney;
		}

		protected virtual void Load()
		{
			SaveClass_DayScore dayScore = SaveManager.CurrentSave.dayScore;
			XP = dayScore.XP;
			_startLevel = dayScore.startLevel;
			_startMoney = dayScore.startMoney;
			m_startMoneySinceLastLoad = GameState.MoneyAmount;
			_productsSold.Clear();
			_productsSold.AddRange(dayScore.productsSold);
			_productsIncomes.Clear();
			_productsIncomes.AddRange(dayScore.productsIncomes);
			_satisfactions.Clear();
			_satisfactions.AddRange(dayScore.satisfactions);
			TotalIncomes = dayScore.totalIncomes;
			SupplyCost = dayScore.supplyCost;
			LicenseCost = dayScore.licenseCost;
		}

		public virtual void Save()
		{
			SaveClass_DayScore dayScore = SaveManager.CurrentSave.dayScore;
			dayScore.StartSaveProcess();
			dayScore.XP = XP;
			dayScore.startLevel = _startLevel;
			dayScore.startMoney = _startMoney;
			dayScore.productsSold.AddRange(_productsSold);
			dayScore.productsIncomes.AddRange(_productsIncomes);
			dayScore.satisfactions.AddRange(_satisfactions);
			dayScore.totalIncomes = TotalIncomes;
			dayScore.supplyCost = SupplyCost;
			dayScore.licenseCost = LicenseCost;
		}

		protected virtual void Register()
		{
			GameState.XPGained += OnXPGained;
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
			MarketStore.BoughtLicense += OnLicenseBought;
			MarketStore.BoughtBoxes += OnBoxesBought;
			Shop.ClientVisited += OnClientVisited;
			CashRegisterWorkshop.ClientCheckedOut += OnClientCheckedOut;
			EventManager.OnGameEvent += OnGameEvent;
		}

		public virtual void Unregister()
		{
			GameState.XPGained -= OnXPGained;
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
			MarketStore.BoughtLicense -= OnLicenseBought;
			MarketStore.BoughtBoxes -= OnBoxesBought;
			Shop.ClientVisited -= OnClientVisited;
			CashRegisterWorkshop.ClientCheckedOut -= OnClientCheckedOut;
			EventManager.OnGameEvent -= OnGameEvent;
		}

		protected virtual void OnGameEvent(EGameEvent e)
		{
			if (e == EGameEvent.DAY_END)
			{
				OnDayEnd();
			}
		}

		protected virtual void OnXPGained(int type, int amount)
		{
			if (type == 0)
			{
				XP += amount;
			}
		}

		protected virtual void OnMoneyAmountChanged(float amount)
		{
			if (amount > 0f)
			{
				TotalIncomes += amount;
			}
		}

		protected virtual void OnLicenseBought(float price)
		{
			LicenseCost += price;
		}

		protected virtual void OnBoxesBought(float price)
		{
			SupplyCost += price;
		}

		protected virtual void OnClientVisited(int satisfaction)
		{
			_satisfactions.Add(satisfaction);
		}

		protected virtual void OnClientCheckedOut(List<Product> products, float totalCost)
		{
			_productsSold.Add(products.Count);
			_productsIncomes.Add(totalCost);
		}

		protected virtual void OnDayEnd()
		{
			if (TotalBalance >= 1000f)
			{
				ESteamAchievement.PROFIT_1000.Trigger();
			}
			if (TotalBalance >= 5000f)
			{
				ESteamAchievement.PROFIT_5000.Trigger();
			}
			if (TotalBalance >= 10000f)
			{
				ESteamAchievement.PROFIT_10000.Trigger();
			}
		}

		public virtual void SendAnalytics()
		{
			GameAnalytics.NewDesignEvent("id_analytics_shop_clientsatisfaction", Satisfaction);
			GameAnalytics.NewDesignEvent("id_analytics_moneybonus", TotalBalanceSinceLastLoad);
		}
	}
}
