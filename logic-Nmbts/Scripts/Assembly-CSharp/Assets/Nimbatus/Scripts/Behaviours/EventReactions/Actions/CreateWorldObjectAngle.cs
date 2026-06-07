using System;
using Assets.Nimbatus.Scripts.WorldObjects;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class CreateWorldObjectAngle : CustomTransformAction
	{
		public InteractiveWorldObject ObjectToSpawn;

		public float Angle;

		public bool UseSpawnerAsAngleReference;

		public override void Execute()
		{
			Transform transform = (HasCustomTransform ? CustomTransform : OwnWorldObject.transform);
			InteractiveWorldObject interactiveWorldObject = UnityEngine.Object.Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
			if (UseSpawnerAsAngleReference)
			{
				interactiveWorldObject.transform.rotation = OwnWorldObject.transform.rotation;
			}
			else
			{
				float z = Mathf.Atan2(OwnWorldObject.transform.position.y, OwnWorldObject.transform.position.x) * 57.29578f;
				interactiveWorldObject.transform.rotation = Quaternion.Euler(0f, 0f, z);
			}
			interactiveWorldObject.transform.eulerAngles = new Vector3(interactiveWorldObject.transform.eulerAngles.x, interactiveWorldObject.transform.eulerAngles.y, interactiveWorldObject.transform.eulerAngles.z + Angle);
			int seed = new System.Random().Next(int.MinValue, int.MaxValue);
			interactiveWorldObject.InitSpawn(seed);
		}
	}
}
