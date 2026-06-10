using System.Collections.Generic;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;

namespace NSMedieval.BuildingComponents
{
	public class DecorationComponentRepository : DynamicJsonRepository<DecorationComponentRepository, DecorationComponentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/DecorationComponentRepository.json";
		}

		public override void Deserialize()
		{
			base.Deserialize();
			CreateQualityItems();
		}

		private void CreateQualityItems()
		{
			Queue<DecorationComponentBlueprint> queue = new Queue<DecorationComponentBlueprint>();
			Queue<DecorationComponentBlueprint> queue2 = new Queue<DecorationComponentBlueprint>();
			foreach (DecorationComponentBlueprint allItem in base.AllItems)
			{
				if (!allItem.GenerateQualityVersions)
				{
					continue;
				}
				queue2.Enqueue(allItem);
				foreach (ConstructableQuality allItem2 in Repository<ConstructableQualitySettingsRepository, ConstructableQuality>.Instance.GetAllItems())
				{
					DecorationComponentBlueprint qualityClone = allItem.GetQualityClone(allItem2.Quality);
					queue.Enqueue(qualityClone);
				}
			}
			while (queue.Count > 0)
			{
				Add(queue.Dequeue());
			}
			while (queue2.Count > 0)
			{
				Remove(queue2.Dequeue());
			}
		}
	}
}
