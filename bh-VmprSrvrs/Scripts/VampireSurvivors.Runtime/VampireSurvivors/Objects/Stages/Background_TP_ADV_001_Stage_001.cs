using System.Collections.Generic;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Stages
{
	public class Background_TP_ADV_001_Stage_001 : BackgroundManager
	{
		private const string PizzasPoolName = "PizzaCircles";

		private List<PizzaCircle> _bossPizzas;

		private Timer _checkBossPizzasTimer;

		public override void Create()
		{
		}

		private void CreateBossPizzas()
		{
		}

		private void CheckBossPizzas()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
