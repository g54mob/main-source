using System.Collections.Generic;
using UnityEngine;

public class ChangelogEntryDataBlock : ScriptableDataBlock
{
	[ScriptableDataDefaultHeader("Changelog Entries")]
	public DataBlockRef<TextDataBlock> text;

	public DataBlockRef<ChangelogCategoryDataBlock> category;

	[ScriptableDataDefaultHeader("Changelog Entries")]
	[Tooltip("Sub-entries that appear under the main entry in the changelog, e.g. itemized list of new items.")]
	public List<DataBlockRef<TextDataBlock>> subEntries = new List<DataBlockRef<TextDataBlock>>();

	[Tooltip("Leave empty if applicable to all platforms")]
	public List<DataBlockRef<ChangelogTargetPlatformDataBlock>> affectedPlatforms = new List<DataBlockRef<ChangelogTargetPlatformDataBlock>>();

	[ScriptableDataDefaultHeader("Changelog Entries")]
	[Tooltip("Optional fallback text to show if no localization is found for the current language. Primarily intended for hotfixes where the detailed changelog might not get translated before release.")]
	public DataBlockRef<TextDataBlock> ifNotTranslated;

	[Header("Formatting Options")]
	public bool spoilerTagMainText;

	public bool spoilerTagSubEntries;
}
