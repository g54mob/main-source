using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI
{
	[RequireComponent(typeof(Image))]
	public class CircularProgressBar : MonoBehaviour
	{
		private Image progressImage;

		[Header("Settings")]
		[SerializeField]
		private bool clockwise;

		[SerializeField]
		private float rotationOffset;

		private void Awake()
		{
		}

		public void SetProgress(float value)
		{
		}

		public float GetProgress()
		{
			return 0f;
		}
	}
}
