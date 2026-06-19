using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class MaskedFaceCameraComponent : MonoBehaviour
	{
		private Vector3 originRotation;

		private void LateUpdate()
		{
			Camera main = Camera.main;
			if (main != null)
			{
				Vector3 vector = main.transform.position - base.transform.position;
				vector.x = (vector.z = 0f);
				base.transform.LookAt(main.transform.position - vector);
			}
		}
	}
}
