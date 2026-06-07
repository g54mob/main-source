using System.Collections.Generic;
using ModApi.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	public class GrapplingHookManagerScript : MonoBehaviour
	{
		private static GrapplingHookManagerScript _instance;

		private List<GrapplingHookScript> _hooks = new List<GrapplingHookScript>();

		private ITimeManager _timeManager;

		public static GrapplingHookManagerScript Instance
		{
			get
			{
				if (_instance == null && Game.Instance.FlightScene != null)
				{
					_instance = Game.Instance.FlightScene.GameObject.AddComponent<GrapplingHookManagerScript>();
					_instance.Initialize();
				}
				return _instance;
			}
		}

		public Vector3d GetWarpVelocity(GrapplingHookScript grapplingHookScript)
		{
			return grapplingHookScript.CraftTo.CraftNode.Orbit.Velocity;
		}

		public void Register(GrapplingHookScript hook)
		{
			_hooks.Add(hook);
		}

		public void UnRegister(GrapplingHookScript hook)
		{
			_hooks.Remove(hook);
		}

		private void Initialize()
		{
			_timeManager = Game.Instance.FlightScene.TimeManager;
			_timeManager.TimeMultiplierModeChanging += OnTimeMultiplierModeChanging;
		}

		private void OnDestroy()
		{
			if (_timeManager != null)
			{
				_timeManager.TimeMultiplierModeChanging += OnTimeMultiplierModeChanging;
			}
		}

		private void OnTimeMultiplierModeChanging(TimeMultiplierModeChangedEvent e)
		{
		}
	}
}
