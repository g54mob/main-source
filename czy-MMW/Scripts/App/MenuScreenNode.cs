using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class MenuScreenNode : MonoBehaviour
{
	[Serializable]
	public class Transition
	{
		public float duration = 1f;

		public Vector3 entryHandle;

		public Vector3 exitHandle;

		public MenuScreenNode endNode;

		public TransitionCameraControl cameraControl = TransitionCameraControl.Transform;

		public Vector3 EndPosition => endNode.transform.position;
	}

	public ScreenStack.MotorwaysScreen screen;

	public bool IsInGameScreen;

	public float zoom = 15f;

	public List<Transition> transitions;

	[Button(null)]
	public void AddMatchingRecipicalConnections()
	{
		foreach (Transition transition in transitions)
		{
			if (!transition.endNode.HasConnectionFor(this))
			{
				transition.endNode.transitions.Add(new Transition
				{
					entryHandle = transition.exitHandle,
					exitHandle = transition.entryHandle,
					endNode = this,
					duration = transition.duration
				});
			}
		}
	}

	public void UpdateMatchingConnection(int index)
	{
		if (transitions.Count <= index)
		{
			return;
		}
		Transition transition = transitions[index];
		foreach (Transition transition2 in transition.endNode.transitions)
		{
			if (transition2.endNode == this)
			{
				transition2.entryHandle = transition.exitHandle;
				transition2.exitHandle = transition.entryHandle;
				transition2.duration = transition.duration;
			}
		}
	}

	public bool HasConnectionFor(MenuScreenNode node)
	{
		foreach (Transition transition in transitions)
		{
			if (transition.endNode == node)
			{
				return true;
			}
		}
		return false;
	}

	public Transition GetTransitionFor(ScreenStack.MotorwaysScreen screen)
	{
		foreach (Transition transition in transitions)
		{
			if (transition.endNode.screen == screen)
			{
				return transition;
			}
		}
		return null;
	}
}
