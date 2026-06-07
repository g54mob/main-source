using System;
using System.Runtime.CompilerServices;
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

		public static MonoManager current => null;

		public event Action onUpdate
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

		public event Action onLateUpdate
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

		public event Action onFixedUpdate
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

		public event Action onApplicationQuit
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

		public event Action<bool> onApplicationPause
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

		public event Action onGUI
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

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Purge()
		{
		}

		public static void Create()
		{
		}

		public void AddUpdateCall(UpdateMode mode, Action call)
		{
		}

		public void RemoveUpdateCall(UpdateMode mode, Action call)
		{
		}

		protected void Awake()
		{
		}

		protected void OnApplicationQuit()
		{
		}

		protected void OnApplicationPause(bool isPause)
		{
		}

		protected void Update()
		{
		}

		protected void LateUpdate()
		{
		}

		protected void FixedUpdate()
		{
		}
	}
}
