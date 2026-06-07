using UnityEngine;

[DisallowMultipleComponent]
public class CouplingHoseOptimizer : MonoBehaviour
{
	private const float DISTANCE_THRESHOLD = 60f;

	private const float LOD_FACTOR = 0.3f;

	public CouplingHoseRig rig;

	public GameObject hoseBase;

	public HoseAudioBase hoseAudio;

	private Renderer probeRenderer;

	private static Mesh probeMesh;

	private void Awake()
	{
		MakeProbeRenderer();
	}

	private void OnBecameVisible()
	{
		EnableObjects();
		base.enabled = true;
	}

	private void MakeProbeRenderer()
	{
		MeshFilter meshFilter = base.gameObject.AddComponent<MeshFilter>();
		if (probeMesh == null)
		{
			probeMesh = new Mesh();
			probeMesh.bounds = new Bounds(Vector3.zero, new Vector3(3f, 1.8f, 1.4f));
		}
		meshFilter.sharedMesh = probeMesh;
		probeRenderer = base.gameObject.AddComponent<MeshRenderer>();
		base.gameObject.AddComponent<LODGroup>().SetLODs(new LOD[1]
		{
			new LOD(0.3f, new Renderer[1] { probeRenderer })
		});
	}

	private void DisableObjects()
	{
		rig.SetLODForDistance(float.PositiveInfinity);
		rig.adapter.enabled = false;
		if (hoseBase != null)
		{
			hoseBase.SetActive(value: false);
		}
		if ((bool)hoseAudio)
		{
			hoseAudio.enabled = false;
		}
	}

	private void EnableObjects()
	{
		rig.SetLODForDistance(GetPlayerDistance());
		rig.adapter.enabled = true;
		if (hoseBase != null)
		{
			hoseBase.SetActive(value: true);
		}
		if ((bool)hoseAudio)
		{
			hoseAudio.enabled = true;
		}
	}

	private float GetPlayerDistance()
	{
		if ((bool)PlayerManager.ActiveCamera)
		{
			return Vector3.Magnitude(PlayerManager.ActiveCamera.transform.position - base.transform.position);
		}
		return float.PositiveInfinity;
	}

	private bool IsPlayerInRange(float playerDistance)
	{
		return playerDistance < 60f;
	}

	private void Update()
	{
		float playerDistance = GetPlayerDistance();
		if (IsPlayerInRange(playerDistance))
		{
			rig.SetLODForDistance(playerDistance);
			return;
		}
		DisableObjects();
		base.enabled = false;
	}

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (!base.enabled)
		{
			Gizmos.color = Color.gray;
		}
		else
		{
			switch (rig.LODManager.CurrentLODLevel)
			{
			case CouplingHoseLODManager.LODLevel.Unloaded:
				Gizmos.color = Color.black;
				break;
			case CouplingHoseLODManager.LODLevel.Visible_And_Reduced_Simulation:
				Gizmos.color = Color.yellow;
				break;
			case CouplingHoseLODManager.LODLevel.Visible_And_Full_Simulation:
				Gizmos.color = Color.cyan;
				break;
			default:
				Gizmos.color = Color.red;
				break;
			}
		}
		Gizmos.DrawWireCube(probeRenderer.bounds.center, probeRenderer.bounds.size);
	}
}
