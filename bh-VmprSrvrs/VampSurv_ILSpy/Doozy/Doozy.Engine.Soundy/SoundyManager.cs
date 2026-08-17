using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy;

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

	public static SoundyManager Instance
	{
		get
		{
			SoundyManager soundyManager = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)soundyManager).m_CachedPtr == (IntPtr)0)
			{
				if (ApplicationIsQuitting)
				{
					return null;
				}
				SoundyManager soundyManager2 = UnityEngine.Object.FindObjectOfType<SoundyManager>();
				s_instance = soundyManager2;
				SoundyManager soundyManager3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)soundyManager3).m_CachedPtr == (IntPtr)0)
				{
					SoundyManager soundyManager4 = DoozyUtils.AddToScene<SoundyManager>("Soundy Manager", isSingleton: true);
					if ((object)soundyManager4 == null)
					{
						return (SoundyManager)(object)new NullReferenceException();
					}
					GameObject target = soundyManager4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	public static SoundyPooler Pooler
	{
		get
		{
			SoundyPooler soundyPooler = s_pooler;
			if ((object)s_pooler != null && ((UnityEngine.Object)soundyPooler).m_CachedPtr != (IntPtr)0)
			{
				return s_pooler;
			}
			SoundyManager instance = Instance;
			if ((object)instance != null)
			{
				GameObject gameObject = instance.gameObject;
				if ((object)gameObject != null)
				{
					SoundyPooler component = gameObject.GetComponent<SoundyPooler>();
					s_pooler = component;
					SoundyPooler soundyPooler2 = s_pooler;
					if ((object)s_pooler != null && ((UnityEngine.Object)soundyPooler2).m_CachedPtr != (IntPtr)0)
					{
						goto IL_0154;
					}
					SoundyManager instance2 = Instance;
					if ((object)instance2 != null)
					{
						GameObject gameObject2 = instance2.gameObject;
						if ((object)gameObject2 != null)
						{
							SoundyPooler soundyPooler3 = gameObject2.AddComponent<SoundyPooler>();
							s_pooler = soundyPooler3;
							goto IL_0154;
						}
					}
				}
			}
			return (SoundyPooler)(object)new NullReferenceException();
			IL_0154:
			return s_pooler;
		}
	}

	public static SoundyDatabase Database => SoundySettings.Database;

	private bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugSoundyManager;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected SoundyManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private static void RunOnStart()
	{
		ApplicationIsQuitting = false;
		s_initialized = false;
		s_pooler = null;
	}

	private void Awake()
	{
		s_initialized = true;
	}

	public static SoundyManager AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<SoundyManager>("Soundy Manager", isSingleton: true, selectGameObjectAfterCreation);
	}

	public static SoundyController GetController()
	{
		return SoundyController.GetController();
	}

	public static string GetSoundDatabaseFilename(string databaseName)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A83]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (databaseName != null)
		{
			string text = databaseName.TrimWhiteSpaceHelper(string.TrimType.Both);
			return "SoundDatabase_" + text;
		}
		return (string)(object)new NullReferenceException();
	}

	public static void Init()
	{
		//IL_0070: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		if (s_initialized)
		{
			return;
		}
		SoundyManager soundyManager = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)soundyManager).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		SoundyManager instance = Instance;
		s_instance = instance;
		SoundySettings instance2 = SoundySettings.Instance;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = instance2.MinimumNumberOfControllers + 1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				SoundyController controllerFromPool = SoundyPooler.GetControllerFromPool();
				controllerFromPool.Stop();
				obj2++;
				instance2 = SoundySettings.Instance;
				obj = obj2;
				continue;
			}
			break;
		}
	}

	public static void KillAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Kill All Controllers", instance3);
		}
		SoundyController.KillAll();
	}

	public static void MuteAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Mute All Controllers", instance3);
		}
		DoozySettings instance4 = DoozySettings.Instance;
		if (instance4.DebugSoundyController)
		{
			DDebug.Log("Mute All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.MuteAllControllers = true;
	}

	public static void MuteAllSounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A87]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Mute All Sounds", instance3);
		}
		SoundyManager instance4 = Instance;
		DoozySettings instance5 = DoozySettings.Instance;
		if (instance5.DebugSoundyManager)
		{
			SoundyManager instance6 = Instance;
			DDebug.Log("Mute All Controllers", instance6);
		}
		DoozySettings instance7 = DoozySettings.Instance;
		if (instance7.DebugSoundyController)
		{
			DDebug.Log("Mute All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.MuteAllControllers = true;
	}

	public static void PauseAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Pause All Controllers", instance3);
		}
		DoozySettings instance4 = DoozySettings.Instance;
		if (instance4.DebugSoundyController)
		{
			DDebug.Log("Pause All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.PauseAllControllers = true;
	}

	public static void PauseAllSounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A89]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Pause All Sounds", instance3);
		}
		SoundyManager instance4 = Instance;
		DoozySettings instance5 = DoozySettings.Instance;
		if (instance5.DebugSoundyManager)
		{
			SoundyManager instance6 = Instance;
			DDebug.Log("Pause All Controllers", instance6);
		}
		DoozySettings instance7 = DoozySettings.Instance;
		if (instance7.DebugSoundyController)
		{
			DDebug.Log("Pause All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.PauseAllControllers = true;
	}

	public unsafe static SoundyController Play(string databaseName, string soundName, Vector3 position)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Ref, but got Unknown
		//IL_010d: Expected I8, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Ref, but got Unknown
		//IL_0351: Expected O, but got Ref
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyDatabase database = SoundySettings.Database;
		if ((object)database == null || ((UnityEngine.Object)database).m_CachedPtr == (IntPtr)0)
		{
			goto IL_035a;
		}
		if (soundName != null)
		{
			object obj = "No Sound";
			if ((object)soundName == "No Sound")
			{
				goto IL_035a;
			}
			if ("No Sound" != null)
			{
				int stringLength = soundName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v5+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(soundName + 20);
					ulong length = (ulong)(soundName._stringLength + soundName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("No Sound" + 20), length))
					{
						goto IL_035a;
					}
				}
			}
			SoundyDatabase database2 = SoundySettings.Database;
			if ((object)database2 != null)
			{
				SoundGroupData audioData = database2.GetAudioData(databaseName, soundName);
				if ((object)audioData == null || ((UnityEngine.Object)audioData).m_CachedPtr == (IntPtr)0)
				{
					goto IL_035a;
				}
				SoundyManager instance2 = Instance;
				if ((object)instance2 != null)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if ((object)instance3 != null)
					{
						float x = default(float);
						if (instance3.DebugSoundyManager)
						{
							string[] array = new string[7];
							if (array == null)
							{
								goto IL_0364;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C466D0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							string message = string.Concat(array);
							SoundyManager instance4 = Instance;
							DDebug.Log(message, instance4);
							x = position.x;
						}
						SoundyDatabase database3 = SoundySettings.Database;
						if ((object)database3 != null)
						{
							SoundDatabase soundDatabase = database3.GetSoundDatabase(databaseName);
							if ((object)soundDatabase != null)
							{
								return audioData.Play((Vector3)(&x), soundDatabase.OutputAudioMixerGroup);
							}
						}
					}
				}
			}
		}
		goto IL_0364;
		IL_0364:
		return (SoundyController)(object)new NullReferenceException();
		IL_035a:
		return null;
	}

	public unsafe static SoundyController Play(AudioClip audioClip, Vector3 position)
	{
		//IL_003b: Expected O, but got Ref
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		object obj = default(object);
		float pitch = default(float);
		bool loop = default(bool);
		float spatialBlend = default(float);
		return Play(audioClip, null, (Vector3)(&obj), 1f, pitch, loop, spatialBlend);
	}

	public unsafe static SoundyController Play(string databaseName, string soundName, Transform followTarget)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Ref, but got Unknown
		//IL_010d: Expected I8, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Ref, but got Unknown
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyDatabase database = SoundySettings.Database;
		if ((object)database == null || ((UnityEngine.Object)database).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0368;
		}
		SoundGroupData audioData;
		if (soundName != null)
		{
			object obj = "No Sound";
			if ((object)soundName == "No Sound")
			{
				goto IL_0368;
			}
			if ("No Sound" != null)
			{
				int stringLength = soundName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v5+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(soundName + 20);
					ulong length = (ulong)(soundName._stringLength + soundName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("No Sound" + 20), length))
					{
						goto IL_0368;
					}
				}
			}
			SoundyDatabase database2 = SoundySettings.Database;
			if ((object)database2 != null)
			{
				audioData = database2.GetAudioData(databaseName, soundName);
				if ((object)audioData == null || ((UnityEngine.Object)audioData).m_CachedPtr == (IntPtr)0)
				{
					goto IL_0368;
				}
				SoundyManager instance2 = Instance;
				if ((object)instance2 != null)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if ((object)instance3 != null)
					{
						if (!instance3.DebugSoundyManager)
						{
							goto IL_02f5;
						}
						string[] array = new string[7];
						if (array != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if ((object)followTarget != null)
							{
								string text = ((UnityEngine.Object)followTarget).GetName();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								string message = string.Concat(array);
								SoundyManager instance4 = Instance;
								DDebug.Log(message, instance4);
								goto IL_02f5;
							}
						}
					}
				}
			}
		}
		goto IL_0372;
		IL_0368:
		return null;
		IL_0372:
		return (SoundyController)(object)new NullReferenceException();
		IL_02f5:
		SoundyDatabase database3 = SoundySettings.Database;
		if ((object)database3 != null)
		{
			SoundDatabase soundDatabase = database3.GetSoundDatabase(databaseName);
			if ((object)soundDatabase != null)
			{
				return audioData.Play(followTarget, soundDatabase.OutputAudioMixerGroup);
			}
		}
		goto IL_0372;
	}

	public static SoundyController Play(AudioClip audioClip, Transform followTarget)
	{
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		float pitch = default(float);
		bool loop = default(bool);
		float spatialBlend = default(float);
		return Play(audioClip, null, followTarget, 1f, pitch, loop, spatialBlend);
	}

	public unsafe static SoundyController Play(string databaseName, string soundName)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Ref, but got Unknown
		//IL_010d: Expected I8, but got I4
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Ref, but got Unknown
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyDatabase database = SoundySettings.Database;
		if ((object)database != null && ((UnityEngine.Object)database).m_CachedPtr != (IntPtr)0)
		{
			if (soundName == null)
			{
				goto IL_035b;
			}
			object obj = "No Sound";
			if ((object)soundName != "No Sound")
			{
				if ("No Sound" != null)
				{
					int stringLength = soundName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rdx_v4+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(soundName + 20);
						ulong length = (ulong)(soundName._stringLength + soundName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("No Sound" + 20), length))
						{
							goto IL_0359;
						}
					}
				}
				if (databaseName != null && databaseName._stringLength > 0)
				{
					string text = databaseName.TrimWhiteSpaceHelper(string.TrimType.Both);
					if (text != null && text._stringLength > 0 && soundName._stringLength > 0)
					{
						string text2 = soundName.TrimWhiteSpaceHelper(string.TrimType.Both);
						if (text2 != null && text2._stringLength > 0)
						{
							SoundyDatabase database2 = SoundySettings.Database;
							if ((object)database2 == null)
							{
								goto IL_035b;
							}
							SoundDatabase soundDatabase = database2.GetSoundDatabase(databaseName);
							if ((object)soundDatabase != null && ((UnityEngine.Object)soundDatabase).m_CachedPtr != (IntPtr)0)
							{
								SoundGroupData data = soundDatabase.GetData(soundName);
								if ((object)data != null && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
								{
									SoundyPooler pooler = Pooler;
									if ((object)pooler != null)
									{
										Transform followTarget = pooler.transform;
										return data.Play(followTarget, soundDatabase.OutputAudioMixerGroup);
									}
									goto IL_035b;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0359;
		IL_0359:
		return null;
		IL_035b:
		return (SoundyController)(object)new NullReferenceException();
	}

	public static SoundyController Play(AudioClip audioClip)
	{
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyPooler pooler = Pooler;
		if ((object)pooler != null)
		{
			Transform followTarget = pooler.transform;
			float pitch = default(float);
			bool loop = default(bool);
			float spatialBlend = default(float);
			return Play(audioClip, null, followTarget, 1f, pitch, loop, spatialBlend);
		}
		return (SoundyController)(object)new NullReferenceException();
	}

	public unsafe static SoundyController Play(AudioClip audioClip, AudioMixerGroup outputAudioMixerGroup, Vector3 position, float volume = 1f, float pitch = 1f, bool loop = false, float spatialBlend = 1f)
	{
		//IL_00b4: Expected O, but got Ref
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyController soundyController;
		if ((object)audioClip != null && ((UnityEngine.Object)audioClip).m_CachedPtr != (IntPtr)0)
		{
			soundyController = SoundyPooler.GetControllerFromPool();
			if ((object)soundyController != null)
			{
				float pitch2 = default(float);
				bool loop2 = default(bool);
				float spatialBlend2 = default(float);
				soundyController.SetSourceProperties(audioClip, volume, pitch2, loop2, spatialBlend2);
				soundyController.SetOutputAudioMixerGroup(outputAudioMixerGroup);
				object obj = default(object);
				soundyController.SetPosition((Vector3)(&obj));
				GameObject gameObject = soundyController.gameObject;
				string text = ((UnityEngine.Object)audioClip).GetName();
				string text2 = "[AudioClip]-(" + text + ")";
				if ((object)gameObject != null)
				{
					((UnityEngine.Object)gameObject).SetName(text2);
					soundyController.Play();
					SoundyManager instance2 = Instance;
					if ((object)instance2 != null)
					{
						DoozySettings instance3 = DoozySettings.Instance;
						if ((object)instance3 != null)
						{
							if (instance3.DebugSoundyManager)
							{
								string text3 = ((UnityEngine.Object)audioClip).GetName();
								string message = "Play '" + text3 + "' AudioClip";
								SoundyManager instance4 = Instance;
								DDebug.Log(message, instance4);
							}
							goto IL_0234;
						}
					}
				}
			}
			return (SoundyController)(object)new NullReferenceException();
		}
		soundyController = null;
		goto IL_0234;
		IL_0234:
		return soundyController;
	}

	public static SoundyController Play(AudioClip audioClip, AudioMixerGroup outputAudioMixerGroup, Transform followTarget = null, float volume = 1f, float pitch = 1f, bool loop = false, float spatialBlend = 1f)
	{
		if (!s_initialized)
		{
			SoundyManager instance = Instance;
			s_instance = instance;
		}
		SoundyController soundyController;
		if ((object)audioClip != null && ((UnityEngine.Object)audioClip).m_CachedPtr != (IntPtr)0)
		{
			soundyController = SoundyPooler.GetControllerFromPool();
			if ((object)soundyController != null)
			{
				float pitch2 = default(float);
				bool loop2 = default(bool);
				float spatialBlend2 = default(float);
				soundyController.SetSourceProperties(audioClip, volume, pitch2, loop2, spatialBlend2);
				soundyController.SetOutputAudioMixerGroup(outputAudioMixerGroup);
				Transform followTarget2;
				if ((object)followTarget != null && ((UnityEngine.Object)followTarget).m_CachedPtr != (IntPtr)0)
				{
					followTarget2 = followTarget;
				}
				else
				{
					SoundyPooler pooler = Pooler;
					if ((object)pooler == null)
					{
						goto IL_0235;
					}
					Transform transform = pooler.transform;
					followTarget2 = transform;
				}
				soundyController.SetFollowTarget(followTarget2);
				GameObject gameObject = soundyController.gameObject;
				string text = ((UnityEngine.Object)audioClip).GetName();
				string text2 = "[AudioClip]-(" + text + ")";
				if ((object)gameObject != null)
				{
					((UnityEngine.Object)gameObject).SetName(text2);
					soundyController.Play();
					SoundyManager instance2 = Instance;
					if ((object)instance2 != null)
					{
						DoozySettings instance3 = DoozySettings.Instance;
						if ((object)instance3 != null)
						{
							if (instance3.DebugSoundyManager)
							{
								string text3 = ((UnityEngine.Object)audioClip).GetName();
								string message = "Play '" + text3 + "' AudioClip";
								SoundyManager instance4 = Instance;
								DDebug.Log(message, instance4);
							}
							goto IL_02d4;
						}
					}
				}
			}
			goto IL_0235;
		}
		soundyController = null;
		goto IL_02d4;
		IL_02d4:
		return soundyController;
		IL_0235:
		return (SoundyController)(object)new NullReferenceException();
	}

	public static SoundyController Play(SoundyData data)
	{
		//IL_0072: Expected O, but got I4
		if (data != null)
		{
			if (!s_initialized)
			{
				SoundyManager instance = Instance;
				s_instance = instance;
			}
			bool flag = data.SoundSource == SoundSource.Soundy;
			if (flag)
			{
				return Play(data.DatabaseName, data.SoundName);
			}
			object obj = data.SoundSource - 1;
			if (flag)
			{
				float pitch = default(float);
				bool loop = default(bool);
				float spatialBlend = default(float);
				return Play(data.AudioClip, data.OutputAudioMixerGroup, null, 1f, pitch, loop, spatialBlend);
			}
			if ((nint)obj == 1)
			{
				SoundyManager instance2 = Instance;
				if ((object)instance2 != null)
				{
					DoozySettings instance3 = DoozySettings.Instance;
					if ((object)instance3 != null)
					{
						if (instance3.DebugSoundyManager)
						{
							string message = "Play '" + data.SoundName + "' with MasterAudio";
							SoundyManager instance4 = Instance;
							DDebug.Log(message, instance4);
						}
						goto IL_014a;
					}
				}
				return (SoundyController)(object)new NullReferenceException();
			}
		}
		goto IL_014a;
		IL_014a:
		return null;
	}

	public static void StopAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Stop All Controllers", instance3);
		}
		SoundyController.StopAll();
	}

	public static void StopAllSounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A94]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Stop All Sounds", instance3);
		}
		SoundyManager instance4 = Instance;
		DoozySettings instance5 = DoozySettings.Instance;
		if (instance5.DebugSoundyManager)
		{
			SoundyManager instance6 = Instance;
			DDebug.Log("Stop All Controllers", instance6);
		}
		SoundyController.StopAll();
	}

	public static void UnmuteAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Unmute All Controllers", instance3);
		}
		DoozySettings instance4 = DoozySettings.Instance;
		if (instance4.DebugSoundyController)
		{
			DDebug.Log("Unmute All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.MuteAllControllers = false;
	}

	public static void UnmuteAllSounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A96]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Unmute All Sounds", instance3);
		}
		SoundyManager instance4 = Instance;
		DoozySettings instance5 = DoozySettings.Instance;
		if (instance5.DebugSoundyManager)
		{
			SoundyManager instance6 = Instance;
			DDebug.Log("Unmute All Controllers", instance6);
		}
		DoozySettings instance7 = DoozySettings.Instance;
		if (instance7.DebugSoundyController)
		{
			DDebug.Log("Unmute All");
		}
		SoundyController.RemoveNullControllersFromDatabase();
		SoundyController.MuteAllControllers = false;
	}

	public static void UnpauseAllControllers()
	{
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Unpause All Controllers", instance3);
		}
		DoozySettings instance4 = DoozySettings.Instance;
		if (instance4.DebugSoundyController)
		{
			DDebug.Log("Unpause All");
		}
		SoundyController.PauseAllControllers = false;
	}

	public static void UnpauseAllSounds()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980A98]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SoundyManager instance = Instance;
		DoozySettings instance2 = DoozySettings.Instance;
		if (instance2.DebugSoundyManager)
		{
			SoundyManager instance3 = Instance;
			DDebug.Log("Unpause All Sounds", instance3);
		}
		SoundyManager instance4 = Instance;
		DoozySettings instance5 = DoozySettings.Instance;
		if (instance5.DebugSoundyManager)
		{
			SoundyManager instance6 = Instance;
			DDebug.Log("Unpause All Controllers", instance6);
		}
		DoozySettings instance7 = DoozySettings.Instance;
		if (instance7.DebugSoundyController)
		{
			DDebug.Log("Unpause All");
		}
		SoundyController.PauseAllControllers = false;
	}
}
