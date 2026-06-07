using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace DV
{
	public class CabinRenderOrdering : MonoBehaviour
	{
		[Serializable]
		public struct OrderingRenderer
		{
			public SortingGroup group;

			public short initialOrder;

			public short whenInside;

			public OrderingRenderer(SortingGroup group, short initialOrder, short whenInside)
			{
				this.group = group;
				this.initialOrder = initialOrder;
				this.whenInside = whenInside;
			}

			public void SetState(bool inside)
			{
				if (group == null)
				{
					Debug.LogError("CabinRenderOrdering is missing a renderer reference!");
				}
				else
				{
					group.sortingOrder = (inside ? whenInside : initialOrder);
				}
			}
		}

		[Tooltip("This component can be used externally without a trigger.")]
		public CameraTrigger triggerNullable;

		public List<OrderingRenderer> ordering = new List<OrderingRenderer>();

		private void Start()
		{
			if (triggerNullable == null)
			{
				TrainCar trainCar = TrainCar.Resolve(base.gameObject);
				if (trainCar != null)
				{
					triggerNullable = trainCar.GetComponentInChildren<CameraTrigger>();
				}
			}
			if (!(triggerNullable == null))
			{
				triggerNullable.OnMainCameraEnter += SetStateInside;
				triggerNullable.OnMainCameraExit += SetStateDefault;
				SetState(triggerNullable.IsMainCameraInside);
			}
		}

		public void SetState(bool inside)
		{
			for (int i = 0; i < ordering.Count; i++)
			{
				ordering[i].SetState(inside);
			}
		}

		public void SetStateDefault()
		{
			SetState(inside: false);
		}

		public void SetStateInside()
		{
			SetState(inside: true);
		}
	}
}
