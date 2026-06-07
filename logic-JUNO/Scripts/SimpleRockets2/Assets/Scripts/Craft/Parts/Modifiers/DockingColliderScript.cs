using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DockingColliderScript : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			PartScript componentInParent = other.GetComponentInParent<PartScript>();
			if (componentInParent != null)
			{
				DockingPortScript modifier = GetComponentInParent<PartScript>().GetModifier<DockingPortScript>();
				DockingPortScript modifier2 = componentInParent.GetModifier<DockingPortScript>();
				if (modifier2 != null && Mathf.Approximately(modifier.Data.Scale, modifier2.Data.Scale))
				{
					modifier.OnTouchDockingPort(modifier2);
				}
			}
		}
	}
}
