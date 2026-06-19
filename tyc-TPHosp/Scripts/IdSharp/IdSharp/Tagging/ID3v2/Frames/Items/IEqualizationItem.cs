namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IEqualizationItem
	{
		VolumeAdjustmentDirection VolumeAdjustment { get; set; }

		short Frequency { get; set; }

		int Adjustment { get; set; }
	}
}
