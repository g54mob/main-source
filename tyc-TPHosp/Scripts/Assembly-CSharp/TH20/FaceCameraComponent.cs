using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class FaceCameraComponent : MonoBehaviour
	{
		private void LateUpdate()
		{
			Camera main = Camera.main;
			if (main != null)
			{
				base.transform.LookAt(base.transform.position + main.transform.rotation * Vector3.forward, main.transform.rotation * Vector3.up);
			}
		}
	}
}
