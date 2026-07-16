using AYellowpaper.SerializedCollections;
using PathCreation;
using UnityEngine;

public class SpecialTrack : Track
{
	[SerializeField]
	public SerializedDictionary<SpecialTrackTurn, PathCreator> turnTypes;
}
