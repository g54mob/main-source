using System;
using System.Collections.Generic;
using Gh.Tk.Story;
using LitJson;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class StoryGiverTrait : GameObjectXTrait, ILateRestoreState, INameTagAIComponent
	{
		[PersistenceOptIn]
		private bool _isActive;

		protected const float PATIENCE_MODIFIER = 4.375f;

		private bool _isCountdownActive;

		private const float DefaultTimeoutSeconds = 90f;

		private const float FocusGoxWhenTimerReaches = 5f;

		private const float BufferTime = 20f;

		private bool _hasFocusedGox;

		[PersistenceOptIn]
		private float _secondsRemaining;

		[JsonIgnore]
		private CameraEvent _eventCameraEvent;

		public static List<StoryGiverTrait> AllStoryGivers { get; }

		public bool ContinueStoryWhenReady { get; set; }

		[PersistenceOptIn]
		public StoryGiverConfig Config { get; set; }

		public bool IsActive => false;

		[PersistenceOptIn]
		public int EventCameraEventId { get; private set; }

		[JsonIgnore]
		private CameraEvent EventCameraEvent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnAiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		[Preserve]
		protected StoryGiverTrait()
		{
		}

		public StoryGiverTrait(GameObjectX owner, StoryGiverConfig config)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		private void OnOwnerDestroyed(object sender, EventArgs e)
		{
		}

		private static void OnStoryRemoved(object sender, EventArgs<ActiveStory> e)
		{
		}

		private bool ShouldBeActiveNow()
		{
			return false;
		}

		public override void Update()
		{
		}

		private void ShowStoryGiver()
		{
		}

		private void OnStoryActivated()
		{
		}

		private void CleanUp()
		{
		}

		private float GetTimeoutSeconds()
		{
			return 0f;
		}

		private void UpdateCountdown()
		{
		}

		private void ApplyCountdownBufferTime()
		{
		}

		public void OnTimedOut()
		{
		}

		private void ShowEventCamera()
		{
		}

		private void UpdateEventCamera()
		{
		}

		private void CleanUpEventCamera()
		{
		}

		public void LateRestoreState(IDataStore data)
		{
		}

		public PatronStoryGiverWaitJob CreatePatronWaitJob()
		{
			return null;
		}

		public bool ShouldShowNameTag()
		{
			return false;
		}

		public string GetNameModifier()
		{
			return null;
		}
	}
}
