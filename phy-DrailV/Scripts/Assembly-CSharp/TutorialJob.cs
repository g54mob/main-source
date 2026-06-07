using UnityEngine;

public class TutorialJob : MonoBehaviour
{
	public bool jobDone;

	public bool isCurrentJob;

	public double jobValue;

	public GameObject reportDonePrefab;

	public GameObject reportNotDonePrefab;

	private void Start()
	{
		if (!VRManager.IsVREnabled())
		{
			base.gameObject.AddComponent<TutorialJobUseNonVr>();
		}
	}

	public GameObject RequestJobReportPrefab()
	{
		if (!jobDone)
		{
			return reportNotDonePrefab;
		}
		return reportDonePrefab;
	}
}
