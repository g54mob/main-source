using System;
using NaughtyAttributes;
using UnityEngine;

public class ChangelogCollection : DataBlockCollection<ChangelogEntryDataBlock>
{
	[Serializable]
	public class EntryData : CollectionEntryData
	{
		public const int INDEX_OFFSET = 1000;

		public const int NOT_INITIALIZED = -1;

		[ReadOnly]
		[AllowNesting]
		public int orderInSection = -1;
	}

	public bool locked;

	[ScriptableDataDefaultHeader("Changelog Entries")]
	public DataBlockRef<TextDataBlock> summary;

	[ScriptableDataDefaultHeader("Changelog Entries")]
	[Tooltip("Optional fallback text to show if no localization is found for the current language. Primarily intended for hotfixes where the detailed changelog might not get translated before release.")]
	public DataBlockRef<TextDataBlock> ifNotTranslated;

	public override Type entryDataType => typeof(EntryData);
}
