using System;
using System.Collections.Generic;

[Serializable]
public class ReturnWwiseObjects : JsonSerializable
{
	public List<WwiseObjectInfoJsonObject> @return;
}
[Serializable]
public class ReturnWwiseObjects<T> : JsonSerializable
{
	public List<T> @return;
}
