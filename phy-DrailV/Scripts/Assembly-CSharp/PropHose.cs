using System.Collections;
using DV.Utils;
using UnityEngine;
using VerletRope;

public class PropHose : MonoBehaviour
{
	[Header("Components")]
	public Transform hoseStationOrigin;

	public PlugSocket stationSocket;

	[Tooltip("Floor level is required for rope/hose physics. If the station happens to have a collider that touches the floor, you can assign that here. If not, you can set it manually in RopeBehaviour component.")]
	public Collider floorTouchingCollider;

	public PluggableObject plug;

	[Header("Parameters")]
	public float maxLengthMultiplier = 1.25f;

	public float yankInwardForce = 10f;

	public bool resetOnEnable = true;

	private RopeBehaviour rope;

	private VerletSolver solver;

	private Rigidbody plugBody;

	private float timeOutside;

	private void Awake()
	{
		solver = GetComponent<VerletSolver>();
		rope = GetComponent<RopeBehaviour>();
		plugBody = plug.GetComponent<Rigidbody>();
		if (floorTouchingCollider != null)
		{
			float num = floorTouchingCollider.bounds.min.y - rope.transform.position.y - rope.meshGenerator.thickness * 0.5f;
			rope.ropeParams.floorLevel = num / rope.transform.lossyScale.y;
		}
		solver.enabled = false;
		SingletonBehaviour<CoroutineManager>.Instance.Run(SetCameraWhenAvailable());
	}

	private IEnumerator SetCameraWhenAvailable()
	{
		while (PlayerManager.ActiveCamera == null)
		{
			yield return null;
		}
		solver.camera = PlayerManager.ActiveCamera;
		solver.enabled = true;
		PlayerManager.CameraChanged += OnCameraChange;
	}

	private void OnDestroy()
	{
		PlayerManager.CameraChanged -= OnCameraChange;
	}

	private void OnCameraChange()
	{
		solver.camera = PlayerManager.ActiveCamera;
	}

	private void OnEnable()
	{
		if (resetOnEnable && stationSocket != null)
		{
			plug.InstantSnapTo(stationSocket);
		}
	}

	private void Update()
	{
		if (Vector3.Distance(hoseStationOrigin.position, plug.transform.position) > rope.ropeParams.ropeLength * maxLengthMultiplier)
		{
			if (plug.State == PluggableObject.PluggableState.PluggedIn || plug.IsHeldInHand)
			{
				plug.Unplug();
				plug.YankOutOfHand();
				if (plugBody != null && yankInwardForce > 0f)
				{
					Vector3 force = (hoseStationOrigin.position - plug.transform.position).normalized * yankInwardForce;
					plugBody.AddForce(force, ForceMode.Impulse);
				}
			}
			else
			{
				timeOutside += Time.deltaTime;
				if (timeOutside > 2f && stationSocket != null)
				{
					timeOutside = 0f;
					plug.InstantSnapTo(stationSocket);
				}
			}
		}
		else
		{
			timeOutside = 0f;
		}
	}
}
