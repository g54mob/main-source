using System;
using MalbersAnimations.Controller;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Malbers/Animal/Teleport", 0)]
	public class TeleportReaction : MReaction
	{
		public TransformReference Destination;

		public BoolReference UseRotation;

		protected override bool _TryReact(Component component)
		{
			if (Destination.Value == null)
			{
				Debug.Log("Destination in Teleport Reaction is Null");
				return false;
			}
			MAnimal mAnimal = component as MAnimal;
			if (UseRotation.Value)
			{
				mAnimal.TeleportRot(Destination.Value);
			}
			else
			{
				mAnimal.Teleport(Destination.Value);
			}
			return true;
		}
	}
}
