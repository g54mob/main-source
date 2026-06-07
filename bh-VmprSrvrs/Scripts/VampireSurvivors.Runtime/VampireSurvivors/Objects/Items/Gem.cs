using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Items
{
	public class Gem : Pickup
	{
		public static List<string> GEMFRAMES;

		private int _prevDepth;

		protected override void Awake()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public void SetDataAndValue(ItemType itemType, float value)
		{
		}

		public void SetValue(float value)
		{
		}

		public override void UpdateDepth()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetTaken()
		{
		}

		public void BlessColor(float value, float index)
		{
		}
	}
}
