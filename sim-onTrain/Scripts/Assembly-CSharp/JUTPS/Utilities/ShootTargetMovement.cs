using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/ShootTarget Movement")]
	public class ShootTargetMovement : MonoBehaviour
	{
		public float Speed = 3f;

		private bool rightmovement;

		private void Update()
		{
			if (Physics.Raycast(base.transform.position + base.transform.up * 0.5f, base.transform.right, 0.5f))
			{
				rightmovement = !rightmovement;
			}
			if (Physics.Raycast(base.transform.position + base.transform.up * 0.5f, -base.transform.right, 0.5f))
			{
				rightmovement = !rightmovement;
			}
			if (rightmovement)
			{
				base.transform.Translate(Speed * Time.deltaTime, 0f, 0f);
			}
			else
			{
				base.transform.Translate((0f - Speed) * Time.deltaTime, 0f, 0f);
			}
		}
	}
}
