namespace Items
{
	public interface IProgressable
	{
		bool CanProgress { get; }

		ProgressToolType ProgressTool { get; }

		float CurrentProgress { get; }

		void AddProgress(float value);

		void SetProgress(float value);
	}
}
