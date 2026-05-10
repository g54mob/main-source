using UnityEngine;

namespace PG
{
	[RequireComponent(typeof(CharacterController))]
	public class SimpleCharacterController : MonoBehaviour
	{
		public Camera Camera;

		public Transform CameraParent;

		public Transform CameraParentInCar;

		public CharacterInput Input;

		public float ChangeCameraSpeed;

		public float CameraSensitivity;

		public float MaxSpeed;

		public PlayerController PlayerControllerForCar;

		private CharacterController CharacterController;

		private float CameraVerticlaAngle;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void TryEnterCar()
		{
		}

		public void OnExitFromCar(CarController car)
		{
		}
	}
}
