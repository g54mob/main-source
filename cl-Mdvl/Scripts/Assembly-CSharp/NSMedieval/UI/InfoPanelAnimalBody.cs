using System.Collections.Generic;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class InfoPanelAnimalBody : InfoPanelCreatureBody
	{
		public AnimalInstance Animal { get; }

		public InfoPanelAnimalBody(AnimalInstance animal, List<InfoPanelStat> stats = null, List<string> infos = null)
			: base(stats, infos)
		{
			Animal = animal;
		}
	}
}
