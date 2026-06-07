using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class DepthMaskScript : MonoBehaviour
	{
		protected virtual void Start()
		{
			AircraftScript componentInParent = GetComponentInParent<AircraftScript>();
			if ((object)componentInParent != null && componentInParent.LoadContext == CraftLoadContext.Designer)
			{
				base.gameObject.layer = 15;
			}
		}
	}
}
