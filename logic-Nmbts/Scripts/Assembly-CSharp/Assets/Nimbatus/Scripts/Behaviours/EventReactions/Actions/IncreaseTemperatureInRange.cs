using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class IncreaseTemperatureInRange : NimbatusAction
	{
		public float Radius;

		public bool DistanceFalloff;

		public bool AffectSelf;

		public float TemperatureChange;

		public bool CustomLayers;

		[ShowIf("CustomLayers", true)]
		public LayerMask Layers;

		public override void Execute()
		{
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			LayerMask layerMask = -1;
			if (CustomLayers)
			{
				layerMask = Layers;
			}
			Collider[] array = Physics.OverlapSphere(OwnWorldObject.transform.position, Radius, layerMask);
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = array[i].gameObject;
				if ((AffectSelf || !(gameObject == OwnWorldObject.gameObject)) && !hashSet.Contains(gameObject))
				{
					float num = 1f;
					if (DistanceFalloff)
					{
						float num2 = Vector2.Distance(gameObject.transform.position, OwnWorldObject.transform.position);
						num = 1f / Radius * Mathf.Max(0f, Radius - num2);
					}
					gameObject.SendMessage("ChangeTemperatureBy", TemperatureChange * num, SendMessageOptions.DontRequireReceiver);
					hashSet.Add(gameObject);
				}
			}
		}
	}
}
