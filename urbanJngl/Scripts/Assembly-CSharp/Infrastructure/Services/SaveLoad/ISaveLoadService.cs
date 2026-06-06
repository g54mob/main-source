using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.SaveLoad
{
	public interface ISaveLoadService : IService
	{
		string Version { get; }

		void SaveProgress();

		PlayerProgress LoadProgress();
	}
}
