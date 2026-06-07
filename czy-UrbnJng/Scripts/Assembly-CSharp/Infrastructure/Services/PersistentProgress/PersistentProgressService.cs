namespace Infrastructure.Services.PersistentProgress
{
	public class PersistentProgressService : IPersistentProgressService, IService
	{
		public PlayerProgress Progress { get; set; }
	}
}
