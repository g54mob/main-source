using System;
using System.Collections.Generic;
using UnityEngine;

public class Walkway : MonoBehaviour
{
	[Serializable]
	public class BuildStats
	{
		public float time;

		public int numPoints;

		public int numColliders;

		public int numFloorTris;

		public int numFloorMeshes;
	}

	public struct Sample
	{
		public Walkway walkway;

		public bool valid;

		public float worldY;

		public Vector3 normal;

		public Sample(Walkway walkway_, bool valid_, float worldY_, Vector3 normal_)
		{
			walkway = walkway_;
			valid = valid_;
			worldY = worldY_;
			normal = normal_;
		}

		public WalkwayFloor.Hit ToWalkwayFloorHit()
		{
			return new WalkwayFloor.Hit
			{
				valid = valid,
				worldY = worldY,
				normal = normal
			};
		}
	}

	public string id;

	public WalkwaySettings settings;

	public Transform airSpotTransform;

	[WalkwayBuilt]
	public Vector2 offset;

	[WalkwayBuilt]
	public WalkwayPhysical physical;

	[WalkwayBuilt]
	public WalkwayFloor floor = new WalkwayFloor();

	[WalkwayBuilt]
	public BuildStats buildStats = new BuildStats();

	[WalkwayBuilt]
	[SerializeField]
	public List<WalkwayPortal> portals = new List<WalkwayPortal>();

	[WalkwayBuilt]
	[SerializeField]
	public List<WalkwayTrapdoor> trapdoors = new List<WalkwayTrapdoor>();

	public static bool showDebugInGame;

	private static bool noclip;

	public Matrix4x4 debugBaseMatrix
	{
		get
		{
			Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
			localToWorldMatrix.SetRow(0, new Vector4(1f, 0f, 0f, 0f));
			localToWorldMatrix.SetRow(2, new Vector4(0f, 0f, 1f, 0f));
			return localToWorldMatrix;
		}
	}

	public static bool drawAllGizmos
	{
		get
		{
			return false;
		}
	}

	private void Awake()
	{
		DebugMenu.Add("Show/Walkways", KeyCode.None, ToggleShowDebugInGame);
		DebugMenu.Add("NoClip", KeyCode.None, ToggleNoClip);
	}

	private static void ToggleNoClip()
	{
		noclip = !noclip;
		WalkwayMotor[] array = UnityEngine.Object.FindObjectsOfType<WalkwayMotor>();
		foreach (WalkwayMotor walkwayMotor in array)
		{
			walkwayMotor.physical.noclip = noclip;
		}
	}

	private static void ToggleShowDebugInGame()
	{
		showDebugInGame = !showDebugInGame;
	}

	private void OnEnable()
	{
		if (physical != null)
		{
			physical.gameObject.SetActive(true);
		}
	}

	private void OnDisable()
	{
		if (physical != null)
		{
			physical.gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (showDebugInGame)
		{
			DebugLiner.CallAndFlush(DrawDebug, false);
		}
	}

	public Sample GetSample(Vector2 pos)
	{
		WalkwayFloor.Hit b = floor.GetBestHit(pos);
		foreach (WalkwayTrapdoor trapdoor in trapdoors)
		{
			if (trapdoor.isActiveAndEnabled)
			{
				b = WalkwayFloor.Hit.GetBest(trapdoor.floor.GetBestHit(pos), b);
			}
		}
		if (b.valid)
		{
			return new Sample(this, true, b.worldY, b.normal);
		}
		return new Sample(this, false, base.transform.position.y, Vector3.up);
	}

	public Walkway GetPortalDestination(Vector2 pos)
	{
		foreach (WalkwayPortal portal in portals)
		{
			if (portal.isActiveAndEnabled && portal.worldRect.Contains(pos))
			{
				return portal.toWalkway;
			}
		}
		return null;
	}

	public void DrawDebug(DebugLiner liner)
	{
		liner.matrix = debugBaseMatrix;
		Vector3 vector = new Vector3(airSpotTransform.position.x, 0f, airSpotTransform.position.z);
		float num = 0.5f;
		liner.color = Color.white;
		liner.DrawLine(vector + new Vector3(num, 0f, num), vector + new Vector3(0f - num, 0f, 0f - num));
		liner.DrawLine(vector + new Vector3(num, 0f, 0f - num), vector + new Vector3(0f - num, 0f, num));
		foreach (WalkwayTrapdoor trapdoor in trapdoors)
		{
			if (trapdoor.enabled && trapdoor.gameObject.activeInHierarchy)
			{
				liner.color = new Color(0f, 0.5f, 1f, 1f);
				trapdoor.floor.DrawDebug(liner);
			}
		}
		liner.color = Color.black;
		floor.DrawDebug(liner);
	}
}
