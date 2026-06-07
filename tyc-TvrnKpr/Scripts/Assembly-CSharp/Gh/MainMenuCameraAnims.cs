using UnityEngine;

namespace Gh
{
	public class MainMenuCameraAnims : MonoBehaviour
	{
		public int[] supportedLevels;

		public Animator animator;

		public Camera camera;

		private int _currentLevel;

		private const float ClippingPlaneOverride = 1f;

		private float _originalClippingPlane;

		public static bool IsAnimating { get; private set; }

		public void EnableAnimation(int level)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateIsAnimating()
		{
		}
	}
}
