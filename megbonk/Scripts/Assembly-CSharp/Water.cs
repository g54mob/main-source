using System;
using UnityEngine;

public class Water : MonoBehaviour
{
	public MeshRenderer waterUpper;

	public MeshRenderer waterUnder;

	private bool isCameraUnder;

	private bool isPlayerUnder;

	private bool isDamageZone;

	private MapData mapData;

	private StageData stageData;

	public static Action<Water> A_CameraEnterWater;

	public static Action<Water> A_CameraExitWater;

	public static Action<Water> A_PlayerEnterWater;

	public static Action<Water> A_PlayerExitWater;

	private GameObject splashFx;

	public GameObject lavaSplashFx;

	public Material lavaMaterial;

	private float nextDamageTime;

	private float damageInterval;

	private float damage;

	private float threshold;

	private float nextSplashTime;

	private float splashInterval;

	public Color color { get; private set; }

	public void Set(MapData mapData, StageData stageData)
	{
	}

	public void SetFloorIsLava()
	{
	}

	private void FixedUpdate()
	{
	}

	private void Update()
	{
	}
}
