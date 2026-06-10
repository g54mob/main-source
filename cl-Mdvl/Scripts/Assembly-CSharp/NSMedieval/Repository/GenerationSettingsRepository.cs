using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class GenerationSettingsRepository : DynamicJsonRepository<GenerationSettingsRepository, GenerationSettings>
	{
		private GenerationSettings settings;

		public GenerationSettings Settings
		{
			get
			{
				if (!(settings == null))
				{
					return settings;
				}
				return settings = GetFirst();
			}
		}

		protected override string JsonFile()
		{
			return "Worker/GenerationRules.json";
		}
	}
}
