using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InteractionSystem
{
	public class InteractionUIManager : MonoBehaviour
	{
		[Header("UI References")]
		[SerializeField]
		private GameObject promptContainer;

		[SerializeField]
		private TextMeshProUGUI promptText;

		[SerializeField]
		private Image promptBackground;

		[SerializeField]
		private Image keyIcon;

		[Header("Settings")]
		[SerializeField]
		private float fadeSpeed;

		[SerializeField]
		private bool autoCreateUI;

		private CanvasGroup canvasGroup;

		private InteractionManager interactionManager;

		private bool isShowing;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void FindInteractionManager()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		private void SetupWithInteractionManager(InteractionManager manager)
		{
		}

		private void Update()
		{
		}

		public void ShowPrompt(string prompt)
		{
		}

		public void HidePrompt()
		{
		}

		private void CreateDefaultUI()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
