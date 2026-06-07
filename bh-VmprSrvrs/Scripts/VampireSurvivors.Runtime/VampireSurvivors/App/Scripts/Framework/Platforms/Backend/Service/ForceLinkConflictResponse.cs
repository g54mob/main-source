using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service
{
	public class ForceLinkConflictResponse : ForceLinkResponse
	{
		public PlayerOptionsData CurrentAccountSaveData;

		public PlayerOptionsData LinkingAccountSaveData;
	}
}
