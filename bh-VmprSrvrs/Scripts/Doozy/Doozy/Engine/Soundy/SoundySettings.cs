using System;
using UnityEngine;

namespace Doozy.Engine.Soundy
{
	[Serializable]
	public class SoundySettings : ScriptableObject
	{
		public const string FILE_NAME = "SoundySettings";

		private static SoundySettings s_instance;

		[SerializeField]
		private SoundyDatabase database;

		public const bool AUTO_KILL_IDLE_CONTROLLERS_DEFAULT_VALUE = true;

		public const float CONTROLLER_IDLE_KILL_DURATION_DEFAULT_VALUE = 20f;

		public const float CONTROLLER_IDLE_KILL_DURATION_MIN = 0f;

		public const float CONTROLLER_IDLE_KILL_DURATION_MAX = 300f;

		public const float IDLE_CHECK_INTERVAL_DEFAULT_VALUE = 5f;

		public const float IDLE_CHECK_INTERVAL_MIN = 0.1f;

		public const float IDLE_CHECK_INTERVAL_MAX = 60f;

		public const int MINIMUM_NUMBER_OF_CONTROLLERS_DEFAULT_VALUE = 3;

		public const int MINIMUM_NUMBER_OF_CONTROLLERS_MIN = 0;

		public const int MINIMUM_NUMBER_OF_CONTROLLERS_MAX = 20;

		public bool AutoKillIdleControllers;

		public float ControllerIdleKillDuration;

		public float IdleCheckInterval;

		public int MinimumNumberOfControllers;

		private static string ResourcesPath => null;

		public static SoundySettings Instance => null;

		public static SoundyDatabase Database => null;

		public static void UpdateDatabase()
		{
		}

		private void Reset()
		{
		}

		public void Reset(bool saveAssets)
		{
		}

		public void ResetComponent(SoundyPooler pooler)
		{
		}

		public void SetDirty(bool saveAssets)
		{
		}

		public void UndoRecord(string undoMessage)
		{
		}
	}
}
