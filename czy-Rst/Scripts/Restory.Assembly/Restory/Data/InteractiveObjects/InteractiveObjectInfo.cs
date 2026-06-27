using Restory.Data.Base;
using Restory.Data.Devices.Condition;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Data.InteractiveObjects
{
	[CreateAssetMenu(menuName = "Restory/InteractiveObjects/InteractiveObjectInfo", fileName = "InteractiveObjectInfo")]
	public class InteractiveObjectInfo : RestoryEntityInfoBase, IInteractiveObjectInfo
	{
		[SerializeField]
		private InteractiveObject prefab;

		public virtual InteractiveObject Prefab => prefab;
	}
}
