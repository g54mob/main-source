using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Repository
{
	public class GameEventSettingsRepository : DynamicJsonRepository<GameEventSettingsRepository, GameEvent>
	{
		public override void Deserialize()
		{
			base.Deserialize();
			foreach (GameEvent allItem in GetAllItems())
			{
				allItem.Validate();
			}
		}

		protected override string JsonFile()
		{
			return "GameEventSystem/GameEventSettingsRepository.json";
		}
	}
}
