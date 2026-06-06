using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Diseases/Project")]
public class ProjectDisease : Disease
{
	public override void StartDisease(Agent agent)
	{
		Debug.LogException(new NotSupportedException("This is no longer functional after Vitals refactor"));
	}
}
