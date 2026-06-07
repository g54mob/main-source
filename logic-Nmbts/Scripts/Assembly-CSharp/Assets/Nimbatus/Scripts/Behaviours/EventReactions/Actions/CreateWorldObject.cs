using System;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class CreateWorldObject : CustomTransformAction
	{
		public InteractiveWorldObject ObjectToSpawn;

		public bool InheritRotation = true;

		public override void Execute()
		{
			if (ObjectToSpawn != null)
			{
				Transform transform = (HasCustomTransform ? CustomTransform : OwnWorldObject.transform);
				InteractiveWorldObject interactiveWorldObject = UnityEngine.Object.Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
				if (InheritRotation)
				{
					interactiveWorldObject.transform.rotation = OwnWorldObject.transform.rotation;
				}
				int seed = new System.Random().Next(int.MinValue, int.MaxValue);
				interactiveWorldObject.InitSpawn(seed);
			}
		}
	}
}
