public interface IItemConsumer
{
	ItemProperties ItemToConsumeProperties { get; }

	float ConsumptionPerDay { get; }

	float Progress { get; }

	float Consume(float available);
}
