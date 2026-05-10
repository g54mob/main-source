using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.PunBasics
{
	public class PlayerUI : MonoBehaviour
	{
		[Tooltip("Pixel offset from the player target")]
		[SerializeField]
		private Vector3 screenOffset;

		[Tooltip("UI Text to display Player's Name")]
		[SerializeField]
		private Text playerNameText;

		[Tooltip("UI Slider to display Player's Health")]
		[SerializeField]
		private Slider playerHealthSlider;

		private PlayerManager target;

		private float characterControllerHeight;

		private Transform targetTransform;

		private Renderer targetRenderer;

		private CanvasGroup _canvasGroup;

		private Vector3 targetPosition;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void SetTarget(PlayerManager _target)
		{
		}
	}
}
