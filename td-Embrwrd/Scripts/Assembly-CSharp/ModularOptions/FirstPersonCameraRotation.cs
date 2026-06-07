using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Misc/First Person Camera Rotation")]
	public class FirstPersonCameraRotation : MonoBehaviour
	{
		[SerializeField]
		[Range(0.1f, 9f)]
		private float sensitivity;

		[SerializeField]
		[Range(0f, 90f)]
		[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
		private float yRotationLimit;

		private Vector2 rotation;

		private const string xAxis = "Mouse X";

		private const string yAxis = "Mouse Y";

		public float Sensitivity
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Update()
		{
		}
	}
}
