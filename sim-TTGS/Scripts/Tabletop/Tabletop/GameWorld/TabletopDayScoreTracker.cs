using System.Collections.Generic;
using Simulator;
using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class TabletopDayScoreTracker : DayScoreTracker
	{
		private List<int> m_miniaturesSold = new List<int>();

		private List<float> m_miniaturesIncomes = new List<float>();

		private List<float> m_paintTimes = new List<float>();

		private List<float> m_paintIncomes = new List<float>();

		private List<float> m_wargameTimes = new List<float>();

		private List<float> m_wargameIncomes = new List<float>();

		public int MiniaturesSold => m_miniaturesSold.Sum();

		public float MiniaturesIncome => m_miniaturesIncomes.Sum();

		public float PaintTime => m_paintTimes.Sum();

		public float PaintIncome => m_paintIncomes.Sum();

		public float WargameTime => m_wargameTimes.Sum();

		public float WargameIncome => m_wargameIncomes.Sum();

		public int ClientPainting => m_paintTimes.Count;

		public int ClientWargame => m_wargameTimes.Count;

		public int EventSubscriptions { get; private set; }

		public override void Init()
		{
			base.Init();
			m_miniaturesSold.Clear();
			m_miniaturesIncomes.Clear();
			m_paintTimes.Clear();
			m_paintIncomes.Clear();
			m_wargameTimes.Clear();
			m_wargameIncomes.Clear();
			EventSubscriptions = 0;
		}

		protected override void Load()
		{
			base.Load();
			SaveClass_TabletopDayScore tabletopDayScore = SaveManager.GetCurrentSaveAs<TabletopSave>().tabletopDayScore;
			m_miniaturesSold.AddRange(tabletopDayScore.miniaturesSold);
			m_miniaturesIncomes.AddRange(tabletopDayScore.miniaturesIncomes);
			m_paintTimes.AddRange(tabletopDayScore.paintTimes);
			m_paintIncomes.AddRange(tabletopDayScore.paintIncomes);
			m_wargameTimes.AddRange(tabletopDayScore.warGameTimes);
			m_wargameIncomes.AddRange(tabletopDayScore.warGameIncomes);
			EventSubscriptions = tabletopDayScore.eventSubscriptions;
		}

		public override void Save()
		{
			base.Save();
			SaveClass_TabletopDayScore tabletopDayScore = SaveManager.GetCurrentSaveAs<TabletopSave>().tabletopDayScore;
			tabletopDayScore.StartSaveProcess();
			tabletopDayScore.miniaturesSold.AddRange(m_miniaturesSold);
			tabletopDayScore.miniaturesIncomes.AddRange(m_miniaturesIncomes);
			tabletopDayScore.paintTimes.AddRange(m_paintTimes);
			tabletopDayScore.paintIncomes.AddRange(m_paintIncomes);
			tabletopDayScore.warGameTimes.AddRange(m_wargameTimes);
			tabletopDayScore.warGameIncomes.AddRange(m_wargameIncomes);
			tabletopDayScore.eventSubscriptions = EventSubscriptions;
		}

		protected override void Register()
		{
			base.Register();
			TabletopClientBehaviour.CompletedPainting += OnClientCompletePainting;
			TabletopClientBehaviour.CompletedWargame += OnClientCompleteWargame;
		}

		public override void Unregister()
		{
			base.Unregister();
			TabletopClientBehaviour.CompletedPainting -= OnClientCompletePainting;
			TabletopClientBehaviour.CompletedWargame -= OnClientCompleteWargame;
		}

		protected override void OnClientCheckedOut(List<Product> products, float totalCost)
		{
			base.OnClientCheckedOut(products, totalCost);
			int num = 0;
			int num2 = 0;
			float num3 = 0f;
			foreach (Product product in products)
			{
				if (!(product is MiniatureProduct))
				{
					if (product is MiniatureBoxProduct)
					{
						num2++;
					}
				}
				else
				{
					num++;
					num3 += product.Price;
				}
			}
			m_miniaturesSold.Add(num);
			m_miniaturesIncomes.Add(num3);
			if (num != 0)
			{
				GameAnalytics.NewOrAddDesignEvent("id_analytics_figsold", num);
			}
			if (num2 != 0)
			{
				GameAnalytics.NewOrAddDesignEvent("id_analytics_figboxsold", num2);
			}
		}

		private void OnClientCompletePainting(float duration, float moneyProduced)
		{
			m_paintIncomes.Add(moneyProduced);
			m_paintTimes.Add(duration);
		}

		private void OnClientCompleteWargame(float duration, float moneyProduced)
		{
			m_wargameIncomes.Add(moneyProduced);
			m_wargameTimes.Add(duration);
		}
	}
}
