namespace Items
{
	public interface IConsumeDecremental : IConsumeChangeProgressable
	{
		int MaxQuantity { get; }

		int CurrentQuantity { get; }

		float ProgressOfOne { get; }

		void ChangeQuantity(int quantity);

		void ResetCurrentProgress();
	}
}
