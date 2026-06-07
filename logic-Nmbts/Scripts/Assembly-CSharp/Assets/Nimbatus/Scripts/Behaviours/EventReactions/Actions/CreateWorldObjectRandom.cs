using System;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class CreateWorldObjectRandom : CustomTransformAction
	{
		public InteractiveWorldObject[] ObjectToSpawn;

		public bool InheritRotation = true;

		public override void Execute()
		{
			if (ObjectToSpawn != null)
			{
				int seed = new System.Random().Next(int.MinValue, int.MaxValue);
				Transform transform = CustomTransform ?? OwnWorldObject.transform;
				InteractiveWorldObject interactiveWorldObject = UnityEngine.Object.Instantiate(ObjectToSpawn.ToList().RandomItem(), transform.position, Quaternion.identity);
				if (InheritRotation)
				{
					interactiveWorldObject.transform.rotation = OwnWorldObject.transform.rotation;
				}
				interactiveWorldObject.InitSpawn(seed);
			}
		}
	}
}
