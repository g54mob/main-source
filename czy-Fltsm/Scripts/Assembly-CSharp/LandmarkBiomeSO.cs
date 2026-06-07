using PajamaLlama.Flotsam.Landmarks.Generator;
using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkBiomeAsset", menuName = "Flotsam/Landmarks/Assets/LandmarkBiomeAsset")]
public class LandmarkBiomeSO : ScriptableObject
{
	[Header("Buildings")]
	public LandmarkSO[] Buildings;

	public LandmarkSO[] CornerBuildings;

	[Header("Roads")]
	public LandmarkRoadTileset RoadTileset;

	public LandmarkSO[] StraightRoads;

	public LandmarkSO[] CornerRoads;

	public LandmarkSO[] TRoads;

	public LandmarkSO[] FourWayRoads;

	[Header("Foliage")]
	public LandmarkSO[] Foliage;

	[Header("Mooringpoints")]
	public LandmarkSO[] MooringConnections;
}
