using System.Collections.Generic;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class Background_TP_ADV_001_Stage_005 : BackgroundManager
	{
		private const string PizzasPoolName = "PizzaCircles";

		private List<PizzaCircle> _bossPizzas;

		private Timer _checkBossPizzasTimer;

		private TileSprite _adventureBackground;

		public override void Create()
		{
		}

		public override void CheckMinute(int minute)
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

		private void SpawnBackground()
		{
		}

		private void RemoveBackground()
		{
		}
	}
}
