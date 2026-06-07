using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GametimeTimer : ICustomSaveState
	{
		private static List<GametimeTimer> _timers;

		private static Dictionary<string, GametimeTimer> _timerDict;

		public float intervalInSeconds;

		private string _key;

		private Action _elapsed;

		private float _elapsedTime;

		private bool _isActive;

		public bool IsDead;

		private UnityEngine.Object _target;

		private bool _isTargetSet;

		public float Elapsed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool AutoDestroy { get; set; }

		public UnityEngine.Object Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static GametimeTimer AddTimerForKey(string key, float intervalInSeconds, Action elapsed, UnityEngine.Object target)
		{
			return null;
		}

		public GametimeTimer(float intervalInSeconds, Action elapsed, UnityEngine.Object target)
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		public void Destroy()
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public bool IsActive()
		{
			return false;
		}

		public void Reset()
		{
		}

		public static void Update()
		{
		}
	}
}
