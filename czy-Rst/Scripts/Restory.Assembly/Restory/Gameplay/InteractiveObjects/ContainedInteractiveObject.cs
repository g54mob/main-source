using System;
using Restory.Data.Devices.Condition;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public class ContainedInteractiveObject
	{
		[SerializeField]
		private IInteractiveObjectInfo interactiveObjectInfo;

		[SerializeField]
		private InteractiveObjectAdditionalProperties properties;

		public IInteractiveObjectInfo InteractiveObjectInfo => interactiveObjectInfo;

		public InteractiveObjectAdditionalProperties Properties => properties;

		public ContainedInteractiveObject(IInteractiveObjectInfo interactiveObjectInfo, params InteractiveObjectAdditionalProperty[] additionalProperties)
		{
			this.interactiveObjectInfo = interactiveObjectInfo;
			properties = new InteractiveObjectAdditionalProperties(additionalProperties);
		}
	}
}
