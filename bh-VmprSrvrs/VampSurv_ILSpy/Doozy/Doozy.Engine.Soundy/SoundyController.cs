using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy;

public class SoundyController : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SoundyController, bool> _003C_003E9__66_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRemoveNullControllersFromDatabase_003Eb__66_0(SoundyController sc)
		{
			if ((object)sc != null)
			{
				bool flag = ((UnityEngine.Object)sc).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	private static List<SoundyController> s_database;

	private static bool s_pauseAllControllers;

	private static bool s_muteAllControllers;

	private Transform m_transform;

	private Transform m_followTarget;

	private AudioSource m_audioSource;

	private bool m_inUse;

	private float m_playProgress;

	private bool m_isPaused;

	private bool m_isMuted;

	private float m_lastPlayedTime;

	private bool m_isPlaying;

	private bool m_autoPaused;

	private bool m_muted;

	private bool m_paused;

	private static bool DebugComponent
	{
		get
		{
			//IL_003e: Expected I4, but got O
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugSoundyController;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public static bool PauseAllControllers
	{
		get
		{
			return s_pauseAllControllers;
		}
		set
		{
			s_pauseAllControllers = value;
			if (!s_pauseAllControllers)
			{
				RemoveNullControllersFromDatabase();
				List<SoundyController>.Enumerator enumerator = default(List<SoundyController>.Enumerator);
				if (enumerator.MoveNext())
				{
					throw new NullReferenceException();
				}
			}
		}
	}

	public static bool MuteAllControllers
	{
		get
		{
			return s_muteAllControllers;
		}
		set
		{
			s_muteAllControllers = value;
			if (!s_muteAllControllers)
			{
				RemoveNullControllersFromDatabase();
				List<SoundyController>.Enumerator enumerator = default(List<SoundyController>.Enumerator);
				if (enumerator.MoveNext())
				{
					throw new NullReferenceException();
				}
			}
		}
	}

	public AudioSource AudioSource
	{
		get
		{
			return m_audioSource;
		}
		private set
		{
			m_audioSource = value;
		}
	}

	public bool InUse
	{
		get
		{
			return m_inUse;
		}
		private set
		{
			m_inUse = value;
		}
	}

	public float PlayProgress
	{
		get
		{
			return m_playProgress;
		}
		private set
		{
			m_playProgress = value;
		}
	}

	public bool IsPaused
	{
		get
		{
			if (m_isPaused)
			{
				return true;
			}
			return s_pauseAllControllers;
		}
		private set
		{
			m_isPaused = value;
		}
	}

	public bool IsMuted
	{
		get
		{
			if (m_isMuted)
			{
				return true;
			}
			return s_muteAllControllers;
		}
		private set
		{
			m_isMuted = value;
		}
	}

	public float LastPlayedTime
	{
		get
		{
			return m_lastPlayedTime;
		}
		private set
		{
			m_lastPlayedTime = value;
		}
	}

	public float IdleDuration
	{
		get
		{
			//IL_000e: Expected O, but got F4
			object obj = Time.realtimeSinceStartup;
			float num = default(float);
			return num - m_lastPlayedTime;
		}
	}

	private void Reset()
	{
		ResetController();
	}

	private void Awake()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C390");
		Transform transform = base.transform;
		m_transform = transform;
		GameObject gameObject = base.gameObject;
		AudioSource audioSource = gameObject.GetComponent<AudioSource>();
		if ((object)audioSource == null)
		{
			GameObject gameObject2 = base.gameObject;
			audioSource = gameObject2.AddComponent<AudioSource>();
		}
		m_audioSource = audioSource;
		ResetController();
	}

	private void OnDestroy()
	{
		bool flag = ((List<object>)(object)s_database).Remove((object)this);
	}

	private void Update()
	{
		//IL_028c: Expected O, but got F4
		//IL_0193: Invalid comparison between F4 and I4
		//IL_01a4: Invalid comparison between F4 and I4
		//IL_033b->IL02eb: Incompatible stack heights: 1 vs 0
		if (IsMuted || IsPaused || m_audioSource.isPlaying)
		{
			object obj = Time.realtimeSinceStartup;
			float lastPlayedTime = default(float);
			m_lastPlayedTime = lastPlayedTime;
		}
		bool isMuted = IsMuted;
		if (isMuted != m_muted)
		{
			bool isMuted2 = IsMuted;
			m_audioSource.mute = isMuted2;
			bool isMuted3 = IsMuted;
			m_muted = isMuted3;
		}
		bool isPaused = IsPaused;
		if (isPaused != m_paused)
		{
			if (IsPaused && m_audioSource.isPlaying)
			{
				m_audioSource.Pause();
			}
			if (!IsPaused)
			{
				object audioSource = m_audioSource;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v9 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdi_v9 (System.Object)+10]");
				AudioSource.UnPause_Injected((IntPtr)0);
			}
			bool isPaused2 = IsPaused;
			m_paused = isPaused2;
		}
		UpdatePlayProgress();
		if (m_playProgress < 1f)
		{
			bool flag6;
			if (m_inUse && m_isPlaying && !m_audioSource.isPlaying)
			{
				bool flag2 = m_playProgress < 0f;
				bool flag3 = m_playProgress == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				flag6 = flag5 & flag4;
			}
			else
			{
				flag6 = false;
			}
			m_autoPaused = flag6;
			if (m_inUse && !flag6 && !m_audioSource.isPlaying && !IsPaused && !IsMuted)
			{
				Stop();
			}
			else
			{
				FollowTarget();
			}
		}
		else
		{
			Stop();
			m_playProgress = 0f;
		}
	}

	public void Kill()
	{
		Stop();
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Kill '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}

	public void Mute()
	{
		m_isMuted = true;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Mute '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
	}

	public void Pause()
	{
		m_isPaused = true;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Pause '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
	}

	public void Play()
	{
		//IL_0015: Expected I8, but got I4
		m_inUse = true;
		m_isPaused = false;
		m_isPlaying = true;
		AudioSource.PlayHelper(m_audioSource, 0uL);
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Play '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
	}

	public void SetFollowTarget(Transform followTarget)
	{
		m_followTarget = followTarget;
	}

	public void SetOutputAudioMixerGroup(AudioMixerGroup outputAudioMixerGroup)
	{
		if ((object)outputAudioMixerGroup != null && ((UnityEngine.Object)outputAudioMixerGroup).m_CachedPtr != (IntPtr)0)
		{
			m_audioSource.outputAudioMixerGroup = outputAudioMixerGroup;
		}
	}

	public unsafe void SetPosition(Vector3 position)
	{
		Transform transform = m_transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
	}

	public void SetSourceProperties(AudioClip clip, float volume, float pitch, bool loop, float spatialBlend)
	{
		if ((object)clip != null && ((UnityEngine.Object)clip).m_CachedPtr != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1863D0710");
			m_audioSource.volume = volume;
			m_audioSource.pitch = pitch;
			bool loop2 = default(bool);
			m_audioSource.loop = loop2;
			float spatialBlend2 = default(float);
			m_audioSource.spatialBlend = spatialBlend2;
		}
		else
		{
			Stop();
		}
	}

	public void Stop()
	{
		Unpause();
		Unmute();
		object audioSource = m_audioSource;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v1 (System.Object)+10]");
		AudioSource.Stop_Injected((IntPtr)0, true);
		m_isPlaying = false;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Stop '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
		ResetController();
		SoundyPooler.PutControllerInPool(this);
	}

	public void Unmute()
	{
		m_isMuted = false;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Unmute '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
	}

	public void Unpause()
	{
		m_isPaused = false;
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			string text = GetName();
			string message = "Unpause '" + text + "' SoundyController";
			DDebug.Log(message, this);
		}
	}

	private void FollowTarget()
	{
		//IL_00bc->IL0162: Incompatible stack heights: 4 vs 0
		//IL_00e5->IL0128: Incompatible stack heights: 4 vs 0
		//IL_0128->IL0162: Incompatible stack heights: 4 vs 0
		Transform followTarget = m_followTarget;
		if ((object)m_followTarget == null || ((UnityEngine.Object)followTarget).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform followTarget2 = m_followTarget;
		object obj = m_transform;
		if ((object)m_followTarget != null)
		{
			bool flag = ((UnityEngine.Object)followTarget2).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)followTarget2).m_CachedPtr, out Vector3 _);
			bool flag2 = (object)m_transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rsi_v2 (System.Object)+10]");
			bool flag3 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ rsi_v2 (System.Object)+10]");
			Vector3 value = default(Vector3);
			Transform.set_position_Injected((IntPtr)0, ref value);
			DoozySettings instance = DoozySettings.Instance;
			bool flag4 = (object)instance == null;
			if (!instance.DebugSoundyController)
			{
				return;
			}
			string text = GetName();
			if ((object)m_followTarget != null)
			{
				string text2 = ((UnityEngine.Object)m_followTarget).GetName();
				string message = text + " is following the '" + text2 + "' GameObject";
				DDebug.Log(message, this);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void ResetController()
	{
		//IL_0030: Expected O, but got F4
		m_inUse = false;
		m_isPaused = false;
		m_followTarget = null;
		object obj = Time.realtimeSinceStartup;
		float lastPlayedTime = default(float);
		m_lastPlayedTime = lastPlayedTime;
	}

	private void UpdateLastPlayedTime()
	{
		//IL_000e: Expected O, but got F4
		object obj = Time.realtimeSinceStartup;
		float lastPlayedTime = default(float);
		m_lastPlayedTime = lastPlayedTime;
	}

	private void UpdatePlayProgress()
	{
		//IL_00c8: Invalid comparison between I4 and F4
		//IL_0113: Expected F4, but got I4
		AudioSource audioSource = m_audioSource;
		if ((object)m_audioSource == null || ((UnityEngine.Object)audioSource).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		AudioClip clip = m_audioSource.clip;
		if ((object)clip == null || ((UnityEngine.Object)clip).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float time = m_audioSource.time;
		AudioClip clip2 = m_audioSource.clip;
		float length = clip2.length;
		float num = time / length;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		m_playProgress = num;
	}

	public static SoundyController GetController()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_00ab: Expected O, but got I4
		//IL_0071: Expected I, but got O
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0109: Expected I, but got O
		Type[] array = new Type[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		if (obj3 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj8 = default(object);
		object obj7 = obj8 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj9 = default(object);
		bool flag = obj9 == null;
		obj6 = obj9;
		if (!flag)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj10 = default(object);
			bool flag2 = obj10 == null;
			obj6 = obj9;
			if (flag2)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		GameObject gameObject = new GameObject("SoundyController", array);
		return gameObject.GetComponent<SoundyController>();
	}

	public static void KillAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Kill All");
		}
		RemoveNullControllersFromDatabase();
		List<SoundyController>.Enumerator enumerator = default(List<SoundyController>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public static void MuteAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Mute All");
		}
		RemoveNullControllersFromDatabase();
		MuteAllControllers = true;
	}

	public static void PauseAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Pause All");
		}
		RemoveNullControllersFromDatabase();
		PauseAllControllers = true;
	}

	public static void RemoveNullControllersFromDatabase()
	{
		Func<SoundyController, bool> predicate = _003C_003Ec._003C_003E9__66_0;
		if (_003C_003Ec._003C_003E9__66_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__66_0 = delegate(SoundyController sc)
			{
				if ((object)sc != null)
				{
					bool flag = ((UnityEngine.Object)sc).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<SoundyController> enumerable = Enumerable.Where(s_database, predicate);
		if (enumerable != null)
		{
			List<object> list = new List<object>(enumerable);
			s_database = (List<SoundyController>)(object)list;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static void StopAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Stop All");
		}
		RemoveNullControllersFromDatabase();
		List<SoundyController>.Enumerator enumerator = default(List<SoundyController>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public static void UnmuteAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Unmute All");
		}
		RemoveNullControllersFromDatabase();
		MuteAllControllers = false;
	}

	public static void UnpauseAll()
	{
		DoozySettings instance = DoozySettings.Instance;
		if (instance.DebugSoundyController)
		{
			DDebug.Log("Unpause All");
		}
		PauseAllControllers = false;
	}

	public SoundyController()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static SoundyController()
	{
		List<SoundyController> list = new List<SoundyController>();
		s_database = list;
	}
}
