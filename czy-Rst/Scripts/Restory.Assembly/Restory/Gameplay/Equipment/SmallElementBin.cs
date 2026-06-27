using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Equipment
{
	public class SmallElementBin : MonoBehaviour
	{
		[SerializeField]
		private Transform dropPoint;

		public void PutElement(ElementBase element)
		{
			element.transform.SetParent(base.transform);
			element.transform.position = dropPoint.position;
			element.transform.rotation = Random.rotation;
			element.BehaviorSwitcher.SetPhysicsLayer(0);
			element.BehaviorSwitcher.SwitchToPlacedBehavior();
		}
	}
}
