namespace Items
{
	public interface IConsumeChangeProgressable
	{
		float CurrentProgress { get; }

		void ChangeConsumableProgress();

		void SetCurrentProgress(float progress);
	}
}
