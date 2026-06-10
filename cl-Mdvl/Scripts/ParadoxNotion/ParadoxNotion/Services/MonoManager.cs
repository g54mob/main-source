using System;
using UnityEngine;

namespace ParadoxNotion.Services
{
	public class MonoManager : MonoBehaviour
	{
		public enum UpdateMode
		{
			NormalUpdate = 0,
			LateUpdate = 1,
			FixedUpdate = 2
		}

		private static bool isQuiting;

		private static MonoManager _current;

		public static MonoManager current
		{
			get
			{
				if (_current == null && Threader.applicationIsPlaying && !isQuiting)
				{
					_current = UnityEngine.Object.FindAnyObjectByType<MonoManager>();
					if (_current == null)
					{
						_current = new GameObject("_MonoManager").AddComponent<MonoManager>();
					}
				}
				return _current;
			}
		}

		public event Action onUpdate;

		public event Action onLateUpdate;

		public event Action onFixedUpdate;

		public event Action onApplicationQuit;

		public event Action<bool> onApplicationPause;

		public event Action onGUI;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Purge()
		{
			isQuiting = false;
		}

		public static void Create()
		{
			_current = current;
		}

		public void AddUpdateCall(UpdateMode mode, Action call)
		{
			switch (mode)
			{
			case UpdateMode.NormalUpdate:
				onUpdate += call;
				break;
			case UpdateMode.LateUpdate:
				onLateUpdate += call;
				break;
			case UpdateMode.FixedUpdate:
				onFixedUpdate += call;
				break;
			}
		}

		public void RemoveUpdateCall(UpdateMode mode, Action call)
		{
			switch (mode)
			{
			case UpdateMode.NormalUpdate:
				onUpdate -= call;
				break;
			case UpdateMode.LateUpdate:
				onLateUpdate -= call;
				break;
			case UpdateMode.FixedUpdate:
				onFixedUpdate -= call;
				break;
			}
		}

		protected void Awake()
		{
			if (_current != null && _current != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			_current = this;
		}

		protected void OnApplicationQuit()
		{
			isQuiting = true;
			if (this.onApplicationQuit != null)
			{
				this.onApplicationQuit();
			}
		}

		protected void OnApplicationPause(bool isPause)
		{
			if (this.onApplicationPause != null)
			{
				this.onApplicationPause(isPause);
			}
		}

		protected void Update()
		{
			if (this.onUpdate != null)
			{
				this.onUpdate();
			}
		}

		protected void LateUpdate()
		{
			if (this.onLateUpdate != null)
			{
				this.onLateUpdate();
			}
		}

		protected void FixedUpdate()
		{
			if (this.onFixedUpdate != null)
			{
				this.onFixedUpdate();
			}
		}
	}
}
