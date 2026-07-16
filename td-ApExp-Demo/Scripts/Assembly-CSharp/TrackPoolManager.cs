using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class TrackPoolManager : MonoBehaviour
{
	[SerializeField]
	private SerializedDictionary<TrackTypes, GameObject> trackGos;

	[SerializeField]
	private SerializedDictionary<TrackTypes, ObjectPool> trackPools;

	public GameObject GetTrackByType(TrackTypes trackType)
	{
		if (trackPools.TryGetValue(trackType, out var value))
		{
			return value.GetPooledGameObject();
		}
		if (trackGos.TryGetValue(trackType, out var value2))
		{
			return value2;
		}
		Debug.LogError($"No GameObject or Pool found for TrackType: {trackType}");
		return null;
	}

	public GameObject[] GetAllTracks()
	{
		return trackGos.Values.ToArray();
	}
}
