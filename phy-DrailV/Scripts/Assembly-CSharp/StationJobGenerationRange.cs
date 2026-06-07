using UnityEngine;

public class StationJobGenerationRange : MonoBehaviour
{
	public float jobOverviewBookletGenerationSqrDistance = 22500f;

	public float generateJobsSqrDistance = 250000f;

	public float destroyGeneratedJobsSqrDistanceRegular = 360000f;

	public float destroyGeneratedJobsSqrDistanceAnyJobTaken = 4000000f;

	public Transform stationCenterAnchor;

	public float PlayerSqrDistanceFromStationCenter
	{
		get
		{
			if (!PlayerManager.PlayerTransform)
			{
				return float.MaxValue;
			}
			return (PlayerManager.PlayerTransform.position - stationCenterAnchor.position).sqrMagnitude;
		}
	}

	public float PlayerSqrDistanceFromStationOffice
	{
		get
		{
			if (!PlayerManager.PlayerTransform)
			{
				return float.MaxValue;
			}
			return (PlayerManager.PlayerTransform.position - base.transform.position).sqrMagnitude;
		}
	}

	private void Awake()
	{
		if (stationCenterAnchor == null)
		{
			Debug.LogError("stationCenterAnchor isn't set! Using this.transform.", this);
			stationCenterAnchor = base.transform;
		}
	}

	public bool IsPlayerInJobGenerationZone(float playerSqrDistanceFromStation)
	{
		return playerSqrDistanceFromStation <= generateJobsSqrDistance;
	}

	public bool IsPlayerOutOfJobDestroyZone(float playerSqrDistanceFromStation, bool anyJobTaken)
	{
		float num = (anyJobTaken ? destroyGeneratedJobsSqrDistanceAnyJobTaken : destroyGeneratedJobsSqrDistanceRegular);
		return playerSqrDistanceFromStation > num;
	}

	public bool IsPlayerInRangeForBookletGeneration(float playerSqrDistanceFromStationOffice)
	{
		return playerSqrDistanceFromStationOffice <= jobOverviewBookletGenerationSqrDistance;
	}

	private void OnValidate()
	{
		if (jobOverviewBookletGenerationSqrDistance >= generateJobsSqrDistance || jobOverviewBookletGenerationSqrDistance == 0f)
		{
			Debug.LogError("jobOverviewBookletGenerationSqrDistance must be lower than generateJobsSqrDistance and not 0!");
			jobOverviewBookletGenerationSqrDistance = Mathf.Max(generateJobsSqrDistance - 1f, 1f);
		}
		if (stationCenterAnchor != null)
		{
			float magnitude = (stationCenterAnchor.transform.position - base.transform.position).magnitude;
			float num = Mathf.Sqrt(generateJobsSqrDistance) - Mathf.Sqrt(jobOverviewBookletGenerationSqrDistance);
			if (magnitude > num)
			{
				Debug.LogError("jobOverviewBookletGenerationSqrDistance circle range is not inside generateJobsSqrDistance circle range! Fix this by changing mentioned distances or moving the stationCenterAnchor");
			}
		}
		if (generateJobsSqrDistance >= destroyGeneratedJobsSqrDistanceRegular || generateJobsSqrDistance == 0f)
		{
			Debug.LogError("generateJobsSqrDistance must be lower than destroyGeneratedJobsSqrDistanceRegular and not 0!");
			generateJobsSqrDistance = Mathf.Max(destroyGeneratedJobsSqrDistanceRegular - 1f, 2f);
		}
		if (destroyGeneratedJobsSqrDistanceRegular > destroyGeneratedJobsSqrDistanceAnyJobTaken || destroyGeneratedJobsSqrDistanceRegular == 0f)
		{
			Debug.LogError("destroyGeneratedJobsSqrDistanceRegular must be lower or equal to destroyGeneratedJobsSqrDistanceAnyJobTaken and not 0!");
			destroyGeneratedJobsSqrDistanceRegular = Mathf.Max(destroyGeneratedJobsSqrDistanceAnyJobTaken - 1f, 3f);
		}
		if (destroyGeneratedJobsSqrDistanceAnyJobTaken == 0f)
		{
			Debug.LogError("destroyGeneratedJobsSqrDistanceAnyJobTaken can't be 0!");
			destroyGeneratedJobsSqrDistanceAnyJobTaken = 4f;
		}
	}

	private void OnDrawGizmosSelected()
	{
	}
}
