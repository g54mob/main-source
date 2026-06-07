namespace External.Zalgo2462.VoronoiLib.Structures
{
	internal class BeachSection
	{
		internal FortuneSite Site { get; }

		internal VEdge Edge { get; set; }

		internal FortuneCircleEvent CircleEvent { get; set; }

		internal BeachSection(FortuneSite site)
		{
			Site = site;
			CircleEvent = null;
		}
	}
}
