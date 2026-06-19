using Pug.Conversion;

public class EventTerminalAuthoringConverter : SingleAuthoringComponentConverter<EventTerminalAuthoring>
{
	protected override void Convert(EventTerminalAuthoring authoring)
	{
		AddComponentData(new EventTerminalCD
		{
			radius = authoring.radius,
			radiusSq = authoring.radius * authoring.radius,
			duration = authoring.duration,
			lootTable = authoring.lootTable,
			loopIndex = authoring.loopIndex
		});
		EnsureHasComponent<DistanceToPlayerCD>();
		EnsureHasBuffer<EventTerminalSequenceBuffer>();
		foreach (EventTerminalAuthoring.EventTerminalSequence item in authoring.eventSequence)
		{
			AddToBuffer(new EventTerminalSequenceBuffer
			{
				action = item.action,
				target = item.target,
				duration = item.duration
			});
		}
		EnsureHasBuffer<AlwaysActiveConnectionsBuffer>();
		foreach (EventTerminalAuthoring.AlwaysActiveConnection alwaysActiveConnection in authoring.alwaysActiveConnections)
		{
			AddToBuffer(new AlwaysActiveConnectionsBuffer
			{
				connection = alwaysActiveConnection.connection
			});
		}
		EnsureHasBuffer<EventTerminalElectricityEntityBuffer>();
	}
}
