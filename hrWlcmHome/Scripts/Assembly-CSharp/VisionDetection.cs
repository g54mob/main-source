using UnityEngine;

public class VisionDetection : MonoBehaviour
{
	[Range(0f, 180f)]
	[SerializeField]
	private float visionAngle = 30f;

	[SerializeField]
	private float visionDistance = 8f;

	private AIFollower AI;

	private NoiseManager noiseManager;

	private GameObject player;

	private bool playerFound;

	public float VisionAngle => visionAngle;

	public float VisionDistance => visionDistance;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		noiseManager = GameObject.FindGameObjectWithTag("NoiseManager").GetComponent<NoiseManager>();
		AI = GetComponent<AIFollower>();
	}

	private void Update()
	{
		if (!playerFound && IsInVisionCone(player))
		{
			Debug.Log("Player found!");
			if (AI == null)
			{
				noiseManager.OnAlertNPCs();
			}
			else if (!(AI.personalNoiseLevel >= 110f) && !player.GetComponent<FirstPersonController>().isHiding && AI.lookingForPlayer)
			{
				AI.noiseManager.OnAlertNPCs();
			}
			playerFound = true;
		}
	}

	private bool IsInVisionCone(GameObject target)
	{
		Vector3 rhs = target.transform.position - base.transform.position;
		if (rhs.magnitude > visionDistance)
		{
			return false;
		}
		rhs.Normalize();
		return Mathf.Acos(Vector3.Dot(base.transform.forward, rhs)) * 57.29578f <= visionAngle;
	}
}
