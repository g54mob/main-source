using UnityEngine;

namespace EpicToonFX
{
	public class ETFXRotation : MonoBehaviour
	{
		public enum spaceEnum
		{
			Local = 0,
			World = 1
		}

		public Vector3 rotateVector = Vector3.zero;

		public spaceEnum rotateSpace;

		private void Update()
		{
			if (rotateSpace == spaceEnum.Local)
			{
				base.transform.Rotate(rotateVector * Time.deltaTime);
			}
			if (rotateSpace == spaceEnum.World)
			{
				base.transform.Rotate(rotateVector * Time.deltaTime, Space.World);
			}
		}
	}
}
