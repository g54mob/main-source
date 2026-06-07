namespace ModApi.Craft.Parts
{
	public class PartConnectedEventData
	{
		public bool IsNewConnection { get; private set; }

		public bool IsProcessedFirst { get; private set; }

		public bool IsProcessingSymmetry { get; private set; }

		public AttachPoint TargetAttachPoint { get; private set; }

		public PartData TargetPart { get; private set; }

		public AttachPoint ThisAttachPoint { get; private set; }

		public PartConnectedEventData(AttachPoint thisAttachPoint, PartData targetPart, AttachPoint targetAttachPoint, bool processingSymmetry, bool newConnection, bool processedFirst)
		{
			ThisAttachPoint = thisAttachPoint;
			TargetPart = targetPart;
			TargetAttachPoint = targetAttachPoint;
			IsProcessingSymmetry = processingSymmetry;
			IsNewConnection = newConnection;
			IsProcessedFirst = processedFirst;
		}
	}
}
