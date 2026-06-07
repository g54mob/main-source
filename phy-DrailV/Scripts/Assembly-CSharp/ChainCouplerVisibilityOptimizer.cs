using UnityEngine;

[DisallowMultipleComponent]
public class ChainCouplerVisibilityOptimizer : MonoBehaviour
{
	private const float DISTANCE_THRESHOLD_SQR = 2500f;

	private const float LOD_FACTOR = 0.3f;

	public ChainCouplerInteraction chainScript;

	public TrainBufferController buffersScript;

	[Header("Things to enable/disable")]
	public CouplingScanner couplingScanner;

	public GameObject chain;

	public GameObject hoses;

	private Renderer probeRenderer;

	private static Mesh probeMesh;

	public bool IsLODLocked { get; private set; }

	private void Awake()
	{
		MakeProbeRenderer();
	}

	private void Start()
	{
		if (probeRenderer.isVisible)
		{
			Enable();
		}
		else
		{
			CheckDisable();
		}
	}

	private void MakeProbeRenderer()
	{
		MeshFilter meshFilter = base.gameObject.AddComponent<MeshFilter>();
		if (probeMesh == null)
		{
			probeMesh = new Mesh();
			probeMesh.bounds = new Bounds(Vector3.zero, new Vector3(4f, 2f, 1.5f));
		}
		meshFilter.sharedMesh = probeMesh;
		probeRenderer = base.gameObject.AddComponent<MeshRenderer>();
		base.gameObject.AddComponent<LODGroup>().SetLODs(new LOD[1]
		{
			new LOD(0.3f, new Renderer[1] { probeRenderer })
		});
	}

	public bool IsVisible()
	{
		return probeRenderer.isVisible;
	}

	public void LockLOD()
	{
		IsLODLocked = true;
		if (!base.enabled)
		{
			chainScript.enabled = true;
			Enable();
		}
	}

	public void UnlockLOD()
	{
		IsLODLocked = false;
	}

	public void Disable()
	{
		if (!IsLODLocked)
		{
			base.enabled = false;
			chain.SetActive(value: false);
			couplingScanner.enabled = false;
		}
	}

	public void Enable()
	{
		chain.SetActive(value: true);
		if (!hoses.activeSelf)
		{
			hoses.SetActive(value: true);
		}
		couplingScanner.enabled = true;
		base.enabled = true;
	}

	private void OnBecameVisible()
	{
		if (!base.enabled)
		{
			Enable();
		}
	}

	private void Update()
	{
		chainScript.UpdateVisible();
		buffersScript.UpdateVisible();
		if (!probeRenderer.isVisible && Vector3.SqrMagnitude(PlayerManager.ActiveCamera.transform.position - base.transform.position) > 2500f)
		{
			CheckDisable();
		}
	}

	private void LateUpdate()
	{
		chainScript.LateUpdateVisible();
	}

	private void CheckDisable()
	{
		if (IsLODLocked)
		{
			return;
		}
		if ((bool)couplingScanner.nearbyScanner && couplingScanner.nearbyScanner.TryGetComponent<ChainCouplerVisibilityOptimizer>(out var component))
		{
			if (!component.IsVisible())
			{
				component.Disable();
				Disable();
			}
		}
		else
		{
			Disable();
		}
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireCube(probeRenderer.bounds.center, probeRenderer.bounds.size);
		}
	}
}
