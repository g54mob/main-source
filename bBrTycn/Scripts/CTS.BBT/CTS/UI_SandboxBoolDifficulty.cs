namespace CTS
{
	public abstract class UI_SandboxBoolDifficulty : UI_SandboxBool<DifficultyData>
	{
		protected override DifficultyData GetObject()
		{
			return _profileCreator.DifficultyData;
		}
	}
}
