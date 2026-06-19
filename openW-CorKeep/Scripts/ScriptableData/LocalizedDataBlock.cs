using UnityEngine;
using UnityEngine.Serialization;

public abstract class LocalizedDataBlock : ScriptableDataBlock
{
	[Header("Localization")]
	[FormerlySerializedAs("text")]
	[FormerlySerializedAs("titleAndDesc")]
	[FormerlySerializedAs("localization")]
	public DataBlockRef<TextDataBlock> text;
}
