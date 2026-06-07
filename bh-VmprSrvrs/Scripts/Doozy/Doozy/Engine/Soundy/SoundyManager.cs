using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy
{
	[AddComponentMenu("Doozy/Soundy/Soundy Manager", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-200)]
	public class SoundyManager : MonoBehaviour
	{
		private static SoundyManager s_instance;

		public const string DATABASE = "Database";

		public const string GENERAL = "General";

		public const string NEW_SOUND_GROUP = "New Sound Group";

		public const string NO_SOUND = "No Sound";

		public const string SOUNDS = "Sounds";

		public const string SOUNDY = "Soundy";

		private static bool ApplicationIsQuitting;

		private static bool s_initialized;

		private static SoundyPooler s_pooler;

		public static SoundyManager Instance => null;

		public static SoundyPooler Pooler => null;

		public static SoundyDatabase Database => null;

		private bool DebugComponent => false;

		protected SoundyManager()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		public static SoundyManager AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		public static SoundyController GetController()
		{
			return null;
		}

		public static string GetSoundDatabaseFilename(string databaseName)
		{
			return null;
		}

		public static void Init()
		{
		}

		public static void KillAllControllers()
		{
		}

		public static void MuteAllControllers()
		{
		}

		public static void MuteAllSounds()
		{
		}

		public static void PauseAllControllers()
		{
		}

		public static void PauseAllSounds()
		{
		}

		public static SoundyController Play(string databaseName, string soundName, Vector3 position)
		{
			return null;
		}

		public static SoundyController Play(AudioClip audioClip, Vector3 position)
		{
			return null;
		}

		public static SoundyController Play(string databaseName, string soundName, Transform followTarget)
		{
			return null;
		}

		public static SoundyController Play(AudioClip audioClip, Transform followTarget)
		{
			return null;
		}

		public static SoundyController Play(string databaseName, string soundName)
		{
			return null;
		}

		public static SoundyController Play(AudioClip audioClip)
		{
			return null;
		}

		public static SoundyController Play(AudioClip audioClip, AudioMixerGroup outputAudioMixerGroup, Vector3 position, float volume = 1f, float pitch = 1f, bool loop = false, float spatialBlend = 1f)
		{
			return null;
		}

		public static SoundyController Play(AudioClip audioClip, AudioMixerGroup outputAudioMixerGroup, Transform followTarget = null, float volume = 1f, float pitch = 1f, bool loop = false, float spatialBlend = 1f)
		{
			return null;
		}

		public static SoundyController Play(SoundyData data)
		{
			return null;
		}

		public static void StopAllControllers()
		{
		}

		public static void StopAllSounds()
		{
		}

		public static void UnmuteAllControllers()
		{
		}

		public static void UnmuteAllSounds()
		{
		}

		public static void UnpauseAllControllers()
		{
		}

		public static void UnpauseAllSounds()
		{
		}
	}
}
