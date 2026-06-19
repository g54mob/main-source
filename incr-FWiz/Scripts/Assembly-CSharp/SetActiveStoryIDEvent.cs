using System.Collections.Generic;
using UnityEngine;

public class SetActiveStoryIDEvent : StoryIDEvent
{
	public List<GameObject> gameObjects;

	public bool Active;

	public override void Trigger()
	{
	}
}
