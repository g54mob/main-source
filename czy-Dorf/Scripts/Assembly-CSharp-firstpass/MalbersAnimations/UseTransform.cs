using UnityEngine;

namespace MalbersAnimations
{
	public class UseTransform : MonoBehaviour
	{
		public enum UpdateMode
		{
			Update = 1,
			FixedUpdate = 2,
			LateUpdate = 4
		}

		public Transform Reference;

		public bool rotation = true;

		public bool position = true;

		public UpdateMode updateMode = UpdateMode.LateUpdate;

		private void Update()
		{
			if (updateMode == UpdateMode.Update)
			{
				SetTransformReference();
			}
		}

		private void LateUpdate()
		{
			if (updateMode == UpdateMode.LateUpdate)
			{
				SetTransformReference();
			}
		}

		private void FixedUpdate()
		{
			if (updateMode == UpdateMode.FixedUpdate)
			{
				SetTransformReference();
			}
		}

		private void SetTransformReference()
		{
			if ((bool)Reference)
			{
				if (position)
				{
					base.transform.position = Reference.position;
				}
				if (rotation)
				{
					base.transform.rotation = Reference.rotation;
				}
			}
		}
	}
}
