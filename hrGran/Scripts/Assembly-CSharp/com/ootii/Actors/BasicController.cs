using UnityEngine;
using com.ootii.Input;

namespace com.ootii.Actors
{
	public class BasicController : MonoBehaviour
	{
		public GameObject InputSourceOwner;

		public Transform Camera;

		public bool UseGamepad;

		public bool MovementRelative;

		public float MovementSpeed;

		public bool RotationEnabled;

		public bool RotateToInput;

		public float RotationSpeed;

		protected Transform mTransform;

		protected IInputSource mInputSource;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		private bool GetKey(KeyCode rKey)
		{
			return false;
		}

		private float GetAxis(string rAction)
		{
			return 0f;
		}
	}
}
