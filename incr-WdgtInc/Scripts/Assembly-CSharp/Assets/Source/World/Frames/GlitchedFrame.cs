using System;
using System.Collections.Generic;
using Assets.Source.Item;
using Assets.Source.Player;

namespace Assets.Source.World.Frames
{
	public class GlitchedFrame : WorldFrame
	{
		public override int AutoWorkerMax => 0;

		public override TechNode RequiredTech => "t12f_glitched_frame";

		public override int Tier => 1;

		public override bool IsUnlocked => false;

		public override bool Movable => false;

		public override bool Buildable => false;

		public override bool Deconstructable => false;

		public GlitchedFrame()
		{
			base.IconName = "Items_7";
			base.MusicName = "SlightlyAcross";
			_baseCost = new List<ItemType> { "capacitor_widget" };
			_extraCostMultiplier = 8.0;
		}

		public override AutoWorker CreateAutoWorker(WorldAnchor slot)
		{
			throw new NotImplementedException();
		}
	}
}
