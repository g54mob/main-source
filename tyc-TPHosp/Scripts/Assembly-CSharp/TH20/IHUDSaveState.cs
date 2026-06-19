namespace TH20
{
	internal interface IHUDSaveState
	{
		void SaveState(HUDSavedState saveState);

		void RestoreState(HUDSavedState saveState);
	}
}
