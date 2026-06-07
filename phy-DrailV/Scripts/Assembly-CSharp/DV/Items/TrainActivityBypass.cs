using UnityEngine;

namespace DV.Items
{
	[RequireComponent(typeof(TrainItemActivityHandlerOverride))]
	public class TrainActivityBypass : MonoBehaviour
	{
		public Transform target;

		private Transform targetParent;

		private void Awake()
		{
			targetParent = target.parent;
			GetComponent<TrainItemActivityHandlerOverride>().AboutToChangeActiveStatus += delegate(bool active)
			{
				target.SetParent(active ? targetParent : base.transform.parent);
			};
		}
	}
}
