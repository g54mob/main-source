using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

[Serializable]
internal class TrackInfo
{
	public AssetReference clipReference;

	public float volume;

	public List<float> startTimeStamps;

	public float length;
}
