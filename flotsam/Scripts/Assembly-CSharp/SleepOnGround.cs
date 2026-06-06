using System.Collections;
using UnityEngine;

public class SleepOnGround : TaskBase
{
	[Tooltip("Icon to display in game world.")]
	public IconProperties IconProperties;

	public float MinimumTime;

	public override TaskType Type => TaskType.SleepOnGround;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		agent.UpdateActivity(Activity.Sleeping);
		if (IconProperties != null)
		{
			agent.WorldIconHandler.AddIcon(IconProperties);
		}
		TimeManager timeManager = GameManager.TimeManager;
		float timer = 0f;
		while (timeManager.CurrentDay.DayTime == Day.E_DayTime.Night || timer <= MinimumTime)
		{
			timer += timeManager.DeltaTime;
			yield return null;
		}
		new AgentEvent(GameEventType.AgentSleptOnGround, agent).Dispatch();
		if (IconProperties != null)
		{
			agent.WorldIconHandler.RemoveIcon(IconProperties);
		}
	}

	protected override void OnGUI()
	{
		Header("Sleep on ground", 2, Color.cyan);
		EditorGUI_PropertyField("IconProperties", "Icon Properties");
		MinimumTime = EditorGUI_FloatField("Day Sleep Time", MinimumTime);
		EditorGUI_HelpBox("Sleep on the ground until the sun comes up.");
	}
}
