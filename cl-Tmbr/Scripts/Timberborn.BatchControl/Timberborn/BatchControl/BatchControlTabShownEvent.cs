namespace Timberborn.BatchControl
{
	internal class BatchControlTabShownEvent
	{
		public BatchControlTab BatchControlTab { get; }

		public BatchControlTabShownEvent(BatchControlTab batchControlTab)
		{
			BatchControlTab = batchControlTab;
		}
	}
}
