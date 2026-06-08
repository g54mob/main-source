using UnityEngine;
using UnityEngine.VFX;

namespace Kitchen
{
	public class VFXWhenChildNonEmpty : MonoBehaviour
	{
		public Transform Transform;

		public VisualEffect VFX;

		private void Update()
		{
			if (!(Transform == null))
			{
				VFX.SetBool("IsHolding", Transform.childCount > 0);
			}
		}
	}
}
