using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ambient_data", menuName = "Audio/Ambient Zone")]
public class AmbientZone : SoCustomComparison
{
	[Header("Audio")]
	public AudioEvent mainEvent;

	[Tooltip("If true, this zone can be active and heard outside of the assigned room.")]
	[Header("Occlusion")]
	public bool useOcclusion;

	[EnableIf("useOcclusion")]
	public float maxRange;

	[EnableIf("useOcclusion")]
	[Tooltip("If true this sound can penetrate closed doors")]
	public bool canPenetrateClosedDoors;

	[EnableIf("useOcclusion")]
	[Space(7f)]
	[Tooltip("Overrides default occlusion value sound in the audio controller")]
	public bool overrideOcclusionModifier;

	[EnableIf("overrideOcclusionModifier")]
	[Tooltip("Each occlusion unit will decrease volume by this amount...")]
	public float occlusionUnitVolumeModifier;

	[Header("Special Cases")]
	public bool isAirDuctAmbience;

	[Header("Params")]
	[Tooltip("Pass time of day")]
	public bool passTimeOfDay;

	[Tooltip("Pass walla amount")]
	public bool passWalla;

	[Tooltip("Pass player in vent")]
	public bool passPlayerInVent;

	[Tooltip("Pass player vent ext/int")]
	public bool passPlayerVentExtInt;

	[Tooltip("Pass the player's distance to the nearest vent")]
	public bool passDistanceToVent;

	[Tooltip("Pass rain")]
	public bool passRain;

	[Tooltip("Pass basement")]
	public bool passBasement;

	[Tooltip("Pass combination of height and wind speed")]
	public bool passHeightWindSpeed;

	[Tooltip("Pass city edge distance")]
	public bool passEdgeDistance;

	[Tooltip("The range to sample crowds")]
	[EnableIf("passWalla")]
	public float maxWallaRange;

	[EnableIf("passWalla")]
	[Tooltip("The number of people present per node for maximum walla")]
	public float maxWallaCrowd;
}
