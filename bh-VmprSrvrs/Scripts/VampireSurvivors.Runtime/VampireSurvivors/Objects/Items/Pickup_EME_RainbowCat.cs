using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Items
{
	public class Pickup_EME_RainbowCat : Pickup_EME_Cat
	{
		private List<Sprite> _idleAnimation;

		private const string BlackIdle = "eme_cat_black_i04";

		private const string RedIdle = "eme_cat_red_i04";

		private const string YellowIdle = "eme_cat_yellow_i04";

		private const string BlueIdle = "eme_cat_blue_i04";

		protected override ItemType GetCatType()
		{
			return default(ItemType);
		}

		protected override void GetCatAnimations(out List<Sprite> idle, out List<Sprite> flee, out List<Sprite> dragged)
		{
			idle = null;
			flee = null;
			dragged = null;
		}

		protected override void OnCatPickedUp()
		{
		}
	}
}
