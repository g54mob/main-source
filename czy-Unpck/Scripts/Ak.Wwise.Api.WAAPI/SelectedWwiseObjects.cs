using System;
using System.Collections.Generic;

[Serializable]
public class SelectedWwiseObjects : JsonSerializable
{
	public List<WwiseObjectInfoJsonObject> objects;
}
