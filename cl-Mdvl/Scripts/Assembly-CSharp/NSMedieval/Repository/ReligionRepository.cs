using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class ReligionRepository : DynamicJsonRepository<ReligionRepository, ReligionConfig>
	{
		public ReligionConfig GetConfigForFaith(float value)
		{
			int num = (int)value;
			foreach (ReligionConfig allItem in GetAllItems())
			{
				if ((float)num >= allItem.From && (float)num <= allItem.To)
				{
					return allItem;
				}
			}
			return null;
		}

		protected override string JsonFile()
		{
			return "Data/ReligionConfig.json";
		}
	}
}
