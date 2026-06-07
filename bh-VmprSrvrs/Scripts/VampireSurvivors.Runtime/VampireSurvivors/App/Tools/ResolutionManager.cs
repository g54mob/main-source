using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

namespace VampireSurvivors.App.Tools
{
	public class ResolutionManager : IInitializable, IDisposable, ITickable
	{
		private static Vector2 _resolution;

		private static DeviceOrientation _orientation;

		private static float _checkTimer;

		private const float CHECK_DELAY = 0.5f;

		public static event Action<Vector2> OnResolutionChange
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

		public static event Action<DeviceOrientation> OnOrientationChange
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

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public void Tick()
		{
		}
	}
}
