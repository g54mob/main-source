using MyBox;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloatingOrigin : MonoBehaviour
{
	[Tooltip("Point of reference from which to check the distance to origin.")]
	public Transform ReferenceObject;

	[Tooltip("Distance from the origin the reference object must be in order to trigger an origin shift.")]
	public float Threshold = 5000f;

	[Header("Options")]
	[Tooltip("When true, origin shifts are considered only from the horizontal distance to orign.")]
	public bool Use2DDistance;

	[Tooltip("When true, updates ALL open scenes. When false, updates only the active scene.")]
	public bool UpdateAllScenes = true;

	[Tooltip("Should ParticleSystems be moved with an origin shift.")]
	public bool UpdateParticles = true;

	[Tooltip("Should TrailRenderers be moved with an origin shift.")]
	public bool UpdateTrailRenderers = true;

	[Tooltip("Should LineRenderers be moved with an origin shift.")]
	public bool UpdateLineRenderers = true;

	private ParticleSystem.Particle[] parts;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private Vector3 _totalOffset;

	private void LateUpdate()
	{
		if (ReferenceObject == null)
		{
			return;
		}
		Vector3 position = ReferenceObject.position;
		if (Use2DDistance)
		{
			position.y = 0f;
		}
		if (position.magnitude > Threshold)
		{
			Physics.simulationMode = SimulationMode.Script;
			Physics2D.simulationMode = SimulationMode2D.Script;
			MoveRootTransforms(position);
			_totalOffset += position;
			if (UpdateParticles)
			{
				MoveParticles(position);
			}
			if (UpdateTrailRenderers)
			{
				MoveTrailRenderers(position);
			}
			if (UpdateLineRenderers)
			{
				MoveLineRenderers(position);
			}
			Physics.Simulate(0f);
			Physics.SyncTransforms();
			Physics.simulationMode = SimulationMode.FixedUpdate;
			Physics2D.simulationMode = SimulationMode2D.FixedUpdate;
		}
	}

	private void MoveRootTransforms(Vector3 offset)
	{
		if (UpdateAllScenes)
		{
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				GameObject[] rootGameObjects = SceneManager.GetSceneAt(i).GetRootGameObjects();
				for (int j = 0; j < rootGameObjects.Length; j++)
				{
					rootGameObjects[j].transform.position -= offset;
				}
			}
		}
		else
		{
			GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
			for (int j = 0; j < rootGameObjects.Length; j++)
			{
				rootGameObjects[j].transform.position -= offset;
			}
		}
	}

	private void MoveRigidbodiesInHierarchy(Transform root, Vector3 offset)
	{
		Rigidbody component = root.GetComponent<Rigidbody>();
		if (component != null && !component.isKinematic)
		{
			component.position -= offset;
			component.linearVelocity = component.linearVelocity;
			component.angularVelocity = component.angularVelocity;
		}
	}

	private void MoveTrailRenderers(Vector3 offset)
	{
		TrailRenderer[] array = Object.FindObjectsOfType<TrailRenderer>();
		foreach (TrailRenderer trailRenderer in array)
		{
			Vector3[] array2 = new Vector3[trailRenderer.positionCount];
			int positions = trailRenderer.GetPositions(array2);
			for (int j = 0; j < positions; j++)
			{
				array2[j] -= offset;
			}
			trailRenderer.SetPositions(array2);
		}
	}

	private void MoveLineRenderers(Vector3 offset)
	{
		LineRenderer[] array = Object.FindObjectsOfType<LineRenderer>();
		foreach (LineRenderer lineRenderer in array)
		{
			Vector3[] array2 = new Vector3[lineRenderer.positionCount];
			int positions = lineRenderer.GetPositions(array2);
			for (int j = 0; j < positions; j++)
			{
				array2[j] -= offset;
			}
			lineRenderer.SetPositions(array2);
		}
	}

	private void MoveParticles(Vector3 offset)
	{
		ParticleSystem[] array = Object.FindObjectsOfType<ParticleSystem>();
		foreach (ParticleSystem particleSystem in array)
		{
			if (particleSystem.main.simulationSpace != ParticleSystemSimulationSpace.World)
			{
				continue;
			}
			int maxParticles = particleSystem.main.maxParticles;
			if (maxParticles > 0)
			{
				if (parts == null || parts.Length < maxParticles)
				{
					parts = new ParticleSystem.Particle[maxParticles];
				}
				int particles = particleSystem.GetParticles(parts);
				for (int j = 0; j < particles; j++)
				{
					parts[j].position -= offset;
				}
				particleSystem.SetParticles(parts, particles);
			}
		}
	}
}
