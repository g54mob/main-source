using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

[Serializable]
public class ElementOptionCollection
{
	public ElementType elementType;

	[FormerlySerializedAs("defaultElementColorSets")]
	public List<ColorSet> defaultColors;

	public List<CollectionElementOption> elementOptions;
}
