using System;
using UnityEngine;

[Serializable]
public class SideJobStealBriefcase : SideJob
{
	public struct NodeCompare
	{
		public NewNode node;

		public float score;
	}

	[Header("Serialized Data")]
	public int carrier;

	public Vector3Int meetNodeLocation;

	public bool triggeredSwitch;

	public bool triggeredMeet;

	public float meetTimer;

	[NonSerialized]
	public Human caseCarrier;

	[NonSerialized]
	public NewNode destination;

	private float gwTime;

	private Objective waitObjective;

	public SideJobStealBriefcase(JobPreset newPreset, SideJobController.JobPickData newData, bool immediatePost)
		: base(null, null, immediatePost: false)
	{
	}

	private void PickMeet()
	{
	}

	public override void OnGooseChaseSuccess()
	{
	}

	public void SetupCarrier()
	{
	}

	public override void OnAcquireJobInfo(string infoDialogMessage)
	{
	}

	public NewNode GetLocationNode()
	{
		return null;
	}

	public override Human GetExtraPerson1()
	{
		return null;
	}

	public override void GameWorldLoop()
	{
	}

	public override void UpdateResolveAnswers()
	{
	}

	public override void OnDestroyMissionObject(Interactable destroyed)
	{
	}
}
