using Brewery.Quest;
using UnityEngine;

namespace AudioSystem
{
	public class QuestAudioController : MonoBehaviour
	{
		[Header("Quest Sounds")]
		[Tooltip("Sound played when a new quest is accepted.")]
		[SerializeField]
		private AudioClip questAcceptedClip;

		[Tooltip("Sounds played when an individual objective is completed. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] objectiveCompletedClips;

		[Tooltip("Sounds played when a quest step is completed (advancing to next step). One is randomly selected.")]
		[SerializeField]
		private AudioClip[] stepCompletedClips;

		[Tooltip("Sounds played when a quest is fully completed. One is randomly selected.")]
		[SerializeField]
		private AudioClip[] questFinishedClips;

		[Header("Objective Panel Sounds")]
		[Tooltip("Sound played when the objective panel slides in (appears).")]
		[SerializeField]
		private AudioClip objectivePanelAppearClip;

		[Tooltip("Sound played when the objective panel slides out (disappears).")]
		[SerializeField]
		private AudioClip objectivePanelDisappearClip;

		[Header("Volume Settings")]
		[Tooltip("Volume for quest accepted sound.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float acceptedVolume;

		[Tooltip("Volume for objective completed sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float objectiveVolume;

		[Tooltip("Volume for step completed sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float stepVolume;

		[Tooltip("Volume for quest finished sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float finishedVolume;

		[Tooltip("Volume for objective panel sounds.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float panelVolume;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private QuestManager _questManager;

		private bool _isSubscribed;

		public static QuestAudioController Instance { get; private set; }

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void TrySubscribeToQuestManager()
		{
		}

		private void UnsubscribeFromQuestManager()
		{
		}

		private void OnQuestAccepted(string questId, QuestChain chain)
		{
		}

		private void OnObjectiveCompleted(string questId, int stepIndex, int objectiveIndex)
		{
		}

		private bool IsStepFullyCompleted(string questId, int stepIndex)
		{
			return false;
		}

		private void OnQuestStepChanged(string questId, int stepIndex, QuestStep step)
		{
		}

		private void OnQuestCompleted(string questId, QuestChain chain)
		{
		}

		public void PlayObjectivePanelAppear()
		{
		}

		public void PlayObjectivePanelDisappear()
		{
		}

		public void PlayFavorStepCompleted()
		{
		}

		public void PlayFavorCompleted()
		{
		}

		private void PlayClip(AudioClip clip, float volume)
		{
		}

		private void PlayRandomClip(AudioClip[] clips, float volume)
		{
		}
	}
}
