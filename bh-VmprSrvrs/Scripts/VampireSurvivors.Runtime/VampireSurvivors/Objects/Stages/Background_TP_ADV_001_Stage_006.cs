using System.Collections.Generic;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class Background_TP_ADV_001_Stage_006 : BackgroundManager
	{
		private const string PizzasPoolName = "PizzaCircles";

		private List<PizzaCircle> _bossPizzas;

		private Timer _checkBossPizzasTimer;

		private TileSprite _bgTile;

		public override void Create()
		{
		}

		protected override void OnUpdate()
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
