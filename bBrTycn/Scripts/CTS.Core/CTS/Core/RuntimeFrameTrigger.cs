using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class RuntimeFrameTrigger : ILateUpdatable
	{
		private static RuntimeFrameTrigger _instance;

		private readonly HashSet<StringKey> _usedKeys = new HashSet<StringKey>();

		private RuntimeFrameTrigger()
		{
			UpdateSpreader.AddLateUpdate(this, 9999);
			Application.quitting += OnApplicationQuit;
		}

		public void OnLateUpdate()
		{
			_usedKeys.Clear();
		}

		private static RuntimeFrameTrigger GetInstance()
		{
			if (!Application.isPlaying)
			{
				throw new Exception("Cannot use RuntimeFrameTrigger outside of the play mode.");
			}
			return _instance ?? (_instance = new RuntimeFrameTrigger());
		}

		private void OnApplicationQuit()
		{
			Application.quitting -= OnApplicationQuit;
			UpdateSpreader.RemoveLateUpdate(this);
			_instance = null;
		}

		public static bool TryUse(StringKey key)
		{
			RuntimeFrameTrigger instance = GetInstance();
			if (instance._usedKeys.Contains(key))
			{
				return false;
			}
			instance._usedKeys.Add(key);
			return true;
		}
	}
	public class RuntimeFrameTrigger<T> : ILateUpdatable
	{
		private static RuntimeFrameTrigger<T> _instance;

		private static bool _triggeredThisFrame;

		private RuntimeFrameTrigger()
		{
			Application.quitting += OnApplicationQuit;
		}

		public void OnLateUpdate()
		{
			_triggeredThisFrame = false;
			UpdateSpreader.RemoveLateUpdate(this);
		}

		private static RuntimeFrameTrigger<T> GetInstance()
		{
			if (!Application.isPlaying)
			{
				throw new Exception("Cannot use RuntimeFrameTrigger outside of the play mode.");
			}
			return _instance ?? (_instance = new RuntimeFrameTrigger<T>());
		}

		public static bool TryUse()
		{
			RuntimeFrameTrigger<T> instance = GetInstance();
			if (_triggeredThisFrame)
			{
				return false;
			}
			_triggeredThisFrame = true;
			UpdateSpreader.AddLateUpdate(instance, 9999);
			return true;
		}

		private void OnApplicationQuit()
		{
			_triggeredThisFrame = false;
			UpdateSpreader.RemoveLateUpdate(this);
		}
	}
}
