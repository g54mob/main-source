using System;
using System.Collections.Generic;

[Serializable]
public class SegmentPresetCollection
{
	public string collectionName;

	public List<GroupTypeConfiguration> groupTypeProbabilities;

	public List<SegmentPresetInfo> segmentPresets;
}
