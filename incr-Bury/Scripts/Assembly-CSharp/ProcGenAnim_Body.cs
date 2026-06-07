using UnityEngine;
using UnityEngine.AI;

public class ProcGenAnim_Body : MonoBehaviour
{
	private Vector3 bodyPosXZ_LastFrame;

	private Vector3 CalcVelocityXZ;

	[SerializeField]
	private NavMeshAgent agent;

	private float maxSpeed;

	private void Start()
	{
		maxSpeed = agent.speed;
	}

	private void Update()
	{
		CalculateVelocityOfBody();
	}

	private void CalculateVelocityOfBody()
	{
		Vector3 vector = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
		CalcVelocityXZ = (vector - bodyPosXZ_LastFrame) / Time.deltaTime;
		bodyPosXZ_LastFrame = vector;
	}

	public Vector3 GetBodyVelocity()
	{
		return CalcVelocityXZ;
	}

	public float GetNormalizedVelocity()
	{
		return CalcVelocityXZ.magnitude / maxSpeed;
	}
}
