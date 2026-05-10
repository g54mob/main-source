using UnityEngine;

namespace MyBox
{
	[ExecuteAlways]
	public class Billboard : MonoBehaviour
	{
		public Transform FacedObject;

		private static Camera _camera;

		private Transform ActiveFacedObject => null;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
		}

		private void Update()
		{
		}
	}
}
