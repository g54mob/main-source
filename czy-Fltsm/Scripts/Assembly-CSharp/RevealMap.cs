using System.Collections;
using UnityEngine;

public class RevealMap : TaskBase
{
	[SerializeField]
	private ScoutingState _scoutingState;

	[SerializeField]
	private float _range;

	public override TaskType Type => TaskType.RevealMap;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		LandmarkLookout componentInChildren = project.Target.GetComponentInChildren<LandmarkLookout>();
		if ((bool)componentInChildren)
		{
			yield return MoveAgentCoroutine(componentInChildren.Target);
		}
		agent.UpdateActivity(Activity.Working);
		Debug.Log("Revealing Map in:");
		float time = 0f;
		int count = 5;
		int num = 0;
		float duration = count;
		while (time < duration)
		{
			if (num != count)
			{
				count = num;
				Debug.Log(count);
			}
			yield return null;
			time += Time.deltaTime;
			num = Mathf.CeilToInt(duration - time);
		}
		if ((bool)GameManager.WorldManager && GameManager.WorldManager.CurrentRegion != null)
		{
			GameManager.WorldManager.CurrentRegion.Scout(agent);
		}
		Debug.Log("Reveal Map Option 1!");
	}

	protected override void OnGUI()
	{
		Header("Reveal Map", 2, Color.yellow);
		_scoutingState = (ScoutingState)(object)EditorGUI_EnumField("ScoutingState to set", _scoutingState);
		_range = EditorGUI_FloatField("Range", _range);
		EditorGUI_HelpBox("Reveals nodes on the map up to the given reveal depth.");
	}
}
