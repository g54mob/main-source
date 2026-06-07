using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.CabControls
{
	[ExecuteBefore(typeof(CustomFirstPersonController))]
	public class WalkableControlOverlapDisabler : MonoBehaviour
	{
		private const float RADIUS_OFFSET = -0.01f;

		[SerializeField]
		private CharacterController controller;

		private readonly List<Collider> disabledColliders = new List<Collider>();

		private void Update()
		{
			if (!controller.enabled)
			{
				return;
			}
			using (PooledArray<Collider> pooledArray = ArrayPool<Collider>.New(10))
			{
				Vector3 up = base.transform.up;
				Vector3 vector = base.transform.TransformPoint(controller.center);
				float num = controller.radius + -0.01f;
				float num2 = controller.height * 0.5f - num;
				int num3 = Physics.OverlapCapsuleNonAlloc(vector - up * num2, vector + up * num2, num, pooledArray, Layers.DVLayerMask.Train_Walkable.ToInt());
				for (int i = 0; i < num3; i++)
				{
					Collider collider = pooledArray[i];
					if ((bool)collider.GetComponentInParent<ControlImplBase>())
					{
						disabledColliders.Add(collider);
						collider.enabled = false;
					}
				}
			}
		}

		private void LateUpdate()
		{
			for (int i = 0; i < disabledColliders.Count; i++)
			{
				disabledColliders[i].enabled = true;
			}
			disabledColliders.Clear();
		}
	}
}
