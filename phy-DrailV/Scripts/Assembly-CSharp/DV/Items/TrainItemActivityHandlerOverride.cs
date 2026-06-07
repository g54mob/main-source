using System;
using UnityEngine;

namespace DV.Items
{
	public class TrainItemActivityHandlerOverride : MonoBehaviour
	{
		[Tooltip("Value of TrainPhysicsLOD to trigger item deactivation while on a car - check TrainPhysicsLOD for distances.")]
		[Range(-1f, 5f)]
		[SerializeField]
		protected int activityThreshold = 1;

		public virtual int ActivityThreshold
		{
			get
			{
				return activityThreshold;
			}
			protected set
			{
				activityThreshold = value;
			}
		}

		public event Action<bool> AboutToChangeActiveStatus;

		public void Fire_AboutToChangeActiveStatus(bool active)
		{
			this.AboutToChangeActiveStatus?.Invoke(active);
		}
	}
}
