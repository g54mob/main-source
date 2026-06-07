using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Brewery.Core;
using Brewery.NPC.Data;
using Brewery.NPC.Simple;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.NPC
{
	public class NPCSpeechBubbleController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private NPCDialogueDatabase dialogueDatabase;

		[Header("NPC Reference")]
		[Tooltip("If null, will try to find SimpleNPCController in parent")]
		[SerializeField]
		private SimpleNPCController npcController;

		[Header("Display Settings")]
		[SerializeField]
		private float showDistance;

		[SerializeField]
		private float displayDuration;

		[SerializeField]
		private float minTimeBetweenBubbles;

		[SerializeField]
		private float randomBubbleChance;

		[Header("Animation Settings")]
		[SerializeField]
		private float popInDuration;

		[SerializeField]
		private float popOutDuration;

		[SerializeField]
		private float pulseScale;

		[SerializeField]
		private float pulseDuration;

		[Header("Sorting")]
		[Tooltip("Sorting order for world-space UI. Higher = renders on top. Speech bubble should be above drink request panel.")]
		[SerializeField]
		private int sortingOrder;

		private VisualElement root;

		private VisualElement bubbleContainer;

		private VisualElement bubbleTail;

		private Label speechText;

		private bool isInitialized;

		private bool isVisible;

		private bool isAnimatingIn;

		private bool isAnimatingOut;

		private float lastBubbleTime;

		private float currentBubbleEndTime;

		private string currentText;

		private int showCounter;

		private Camera localPlayerCamera;

		private float cameraSearchCooldown;

		private const float CAMERA_SEARCH_INTERVAL = 1f;

		private Vector3 baseScale;

		private int pulseTweenId;

		private FactionType cachedFaction;

		private NPCGender cachedGender;

		private SimpleNPCPersonality cachedPersonality;

		private const int MAX_RECENT_TEXTS = 3;

		private Queue<string> recentTexts;

		public bool IsShowingSpeech => false;

		public string CurrentText => null;

		public int ShowCounter => 0;

		public event Action<bool> OnVisibilityChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void Initialize()
		{
		}

		public void InitializeForThief(NPCDialogueDatabase database = null)
		{
		}

		private void CacheNPCProperties()
		{
		}

		private void ApplyFactionStyling()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void ShowText(string text, float duration = -1f)
		{
		}

		public void TriggerDialogue(string trigger, float duration = -1f)
		{
		}

		private void TrackRecentText(string text)
		{
		}

		public void TriggerDialogueRandom(string trigger, float duration = -1f)
		{
		}

		public void HideBubble()
		{
		}

		public void HideImmediate()
		{
		}

		private DrunkLevel GetCurrentDrunkLevel()
		{
			return default(DrunkLevel);
		}

		private void ApplyDrunkStyling(DrunkLevel level)
		{
		}

		private void UpdateDistanceVisibility()
		{
		}

		private float GetDistanceToLocalPlayer()
		{
			return 0f;
		}

		private void FindLocalPlayerCamera()
		{
		}

		private void CancelAllAnimations()
		{
		}

		private void PlayPopIn()
		{
		}

		private void PlayPopOut()
		{
		}

		private void StartPulse()
		{
		}

		private void StopPulse()
		{
		}

		public void PlayWiggle()
		{
		}

		public void PlayExcited()
		{
		}
	}
}
