using DV.Logic.Job;
using DV.Utils;
using UnityEngine;

public class JobAbandoner : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		JobBooklet component = other.GetComponent<JobBooklet>();
		if (component != null)
		{
			AbandonJob(component);
		}
	}

	public void AbandonJob(JobBooklet jobBooklet)
	{
		if (jobBooklet.job != null && SingletonBehaviour<JobsManager>.Instance.currentJobs.Contains(jobBooklet.job))
		{
			SingletonBehaviour<JobsManager>.Instance.AbandonJob(jobBooklet.job);
		}
	}
}
