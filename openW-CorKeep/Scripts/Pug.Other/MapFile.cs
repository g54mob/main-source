using System;
using MessagePack;
using Pug.UnityExtensions;
using UnityEngine;

[Serializable]
[MessagePackObject(false)]
public class MapFile
{
	[Key(0)]
	public SerializableDictionary<Vector2Int, MapPartSerialized> mapParts;
}
