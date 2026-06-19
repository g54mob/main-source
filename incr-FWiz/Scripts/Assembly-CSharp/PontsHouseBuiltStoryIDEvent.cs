using System.Collections.Generic;
using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class PontsHouseBuiltStoryIDEvent : StoryIDEvent
{
	public GameObject Building;

	public EventReference BuildSound;

	public ShakeReceiver ShakeReceiver;

	public float Shake;

	public List<MonoBehaviour> EnabledBehaviours;

	public void SetBuilt()
	{
	}

	public override void Trigger()
	{
	}
}
