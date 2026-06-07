using UnityEngine;

namespace VRTK.Examples
{
	public class Whirlygig : VRTK_InteractableObject
	{
		private float spinSpeed;

		private Transform rotator;

		public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
		{
			base.StartUsing(currentUsingObject);
			spinSpeed = 360f;
		}

		public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
		{
			base.StopUsing(previousUsingObject, resetUsingObjectState);
			spinSpeed = 0f;
		}

		protected void Start()
		{
			rotator = base.transform.Find("Capsule");
		}

		protected override void Update()
		{
			base.Update();
			rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
		}
	}
}
