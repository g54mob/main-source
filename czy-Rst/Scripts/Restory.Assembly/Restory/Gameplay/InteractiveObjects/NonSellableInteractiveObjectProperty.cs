using System;
using Restory.Data.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	[Serializable]
	public sealed class NonSellableInteractiveObjectProperty : InteractiveObjectAdditionalProperty
	{
		[SerializeField]
		private InteractiveObjectInfo sourceInteractiveObjectInfo;

		public InteractiveObjectInfo SourceInteractiveObjectInfo => sourceInteractiveObjectInfo;

		public NonSellableInteractiveObjectProperty(InteractiveObjectInfo sourceInteractiveObjectInfo)
		{
			this.sourceInteractiveObjectInfo = sourceInteractiveObjectInfo;
		}
	}
}
