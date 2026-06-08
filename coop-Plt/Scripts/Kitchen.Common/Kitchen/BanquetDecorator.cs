using JetBrains.Annotations;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class BanquetDecorator : Decorator
	{
		[UsedImplicitly]
		public class DecorationsConfiguration : IDecorationConfiguration
		{
			public Appliance LargeShed;

			public Appliance MediumShed;

			public Appliance SmallShed;

			public Appliance Tree;

			public Appliance SpecialTree;

			public Appliance Sled;

			public Appliance Ground;

			public Appliance TreeSetLeft;

			public Appliance TreeSetRight;

			public IDecorator Decorator => new BanquetDecorator();
		}

		public override bool Decorate(Room _)
		{
			if (!(Configuration is DecorationsConfiguration decorationsConfiguration))
			{
				return false;
			}
			Bounds bounds = Blueprint.GetBounds();
			NewPiece(decorationsConfiguration.LargeShed, bounds.min.x - 3.4f, bounds.max.y + 2f, Quaternion.AngleAxis(150f, Vector3.up));
			NewPiece(decorationsConfiguration.MediumShed, bounds.max.x + 3.4f, bounds.max.y + 2.5f, Quaternion.AngleAxis(225f, Vector3.up));
			NewPiece(decorationsConfiguration.SmallShed, bounds.max.x + 2.7f, bounds.min.y + 1.3f, Quaternion.AngleAxis(105f, Vector3.up));
			NewPiece(decorationsConfiguration.Sled, bounds.min.x - 3f, bounds.max.y - 3f, Quaternion.AngleAxis(-60f, Vector3.up));
			NewPiece(decorationsConfiguration.SpecialTree, bounds.min.x - 1.8f, bounds.min.y + 0.3f, Quaternion.AngleAxis(-60f, Vector3.up));
			NewPiece(decorationsConfiguration.SpecialTree, bounds.max.x + 1.5f, bounds.max.y - 2.6f, Quaternion.AngleAxis(0f, Vector3.up));
			NewPiece(decorationsConfiguration.TreeSetLeft, bounds.min.x + 0.6f, bounds.min.y - 3.4f, Quaternion.AngleAxis(0f, Vector3.up));
			NewPiece(decorationsConfiguration.TreeSetRight, bounds.max.x - 0.6f, bounds.min.y - 2.4f, Quaternion.AngleAxis(0f, Vector3.up));
			NewPiece(decorationsConfiguration.Ground, 0f, 0f);
			for (float num = bounds.min.x + 1f; num <= bounds.max.x - 1f; num += 1f)
			{
				if (Random.value < 0.75f)
				{
					NewPiece(decorationsConfiguration.Tree, num, bounds.max.y + 1f + (float)Random.Range(2, 6) * 0.5f);
				}
			}
			return true;
		}
	}
}
