using System;
using System.Collections.Generic;
using Actors.Enemies;
using Cpp2ILInjected;

namespace Assets.Scripts.Game.Spawning.New.Timelines;

[Serializable]
public class TimelineEvent
{
	public ETimelineEvent eTimelineEvent;

	public List<EEnemy> enemies;

	public float timeMinutes;

	public float duration;

	public float GetTimeSeconds()
	{
		float num = timeMinutes * 60f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		float result = default(float);
		return result;
	}
}
