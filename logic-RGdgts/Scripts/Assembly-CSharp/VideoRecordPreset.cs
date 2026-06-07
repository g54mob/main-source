using System.Collections.Generic;
using Cinemachine;
using SE.EvilLib.Core;
using UnityEngine;

public class VideoRecordPreset : MonoBehaviour
{
	[Separator]
	public VideoRecordPresetId id;

	public Vector2Int resolution;

	public int fps;

	public string fileExtension;

	[Separator]
	public CinemachineVirtualCamera vCamDefault;

	public bool camDefaultFollowsCamMain;

	private bool isEnabled;

	private List<VideoCameraZone> zones;

	private CinemachineVirtualCamera vCamLast;

	private Transform trCamMain;

	private int castLayerZone;

	private int castHitCount;

	private bool hasCastHit;

	private bool isStillInZone;

	private VideoCameraZone castZoneLast;

	private VideoCameraZone castCurZone;

	private Collider2D[] collHits;

	private Collider2D castCurColl;

	private const int PRIORITY_HIGH = 100;

	private const int PRIORITY_LOW = 0;

	public void Init()
	{
	}

	private void Update()
	{
	}

	public void SetEnabled(bool val)
	{
	}

	public void OnZoneEnter(VideoCameraZone zone)
	{
	}

	public void OnZoneExit(VideoCameraZone zone)
	{
	}

	public void CastZoneChange(Vector3 mousePosWorld)
	{
	}
}
