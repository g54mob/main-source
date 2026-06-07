using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class VtolManagerScript : MonoBehaviour
	{
		private AircraftScript _aircraftScript;

		private int _vtolEngineCount;

		private List<JetEngineScript> _vtolEngines;

		private List<EngineThrustPortScript> _vtolNozzles;

		private int _vtolNozzlesCount;

		public float CurrentMaxDuctedEngineThrottle { get; set; }

		public bool IsAircraftVtolCapable => VtolNozzleCount > 0;

		public int ReactionControlNozzleCount { get; private set; }

		public int VtolEngineCount => _vtolEngineCount;

		public int VtolNozzleCount => _vtolNozzlesCount;

		public void GetThrustInfo(out float totalThrust, out Vector3 weightedThrustVector)
		{
			totalThrust = 0f;
			foreach (JetEngineScript vtolEngine in _vtolEngines)
			{
				totalThrust += vtolEngine.Engine.Power;
			}
			float num = totalThrust / (float)_vtolNozzlesCount;
			weightedThrustVector = Vector3.zero;
			foreach (EngineThrustPortScript vtolNozzle in _vtolNozzles)
			{
				weightedThrustVector += vtolNozzle.transform.position * num;
			}
		}

		public void Initialize()
		{
			_vtolNozzles = new List<EngineThrustPortScript>();
			_vtolEngines = new List<JetEngineScript>();
			ReactionControlNozzleCount = 0;
			Refresh();
		}

		public void Refresh()
		{
			_vtolNozzlesCount = 0;
			_vtolNozzles.Clear();
			EngineThrustPortScript[] componentsInChildren = GetComponentsInChildren<EngineThrustPortScript>(includeInactive: true);
			if (componentsInChildren != null && componentsInChildren.Length != 0)
			{
				_vtolNozzles.AddRange(componentsInChildren);
				_vtolNozzlesCount = _vtolNozzles.Count;
			}
			_vtolEngines.Clear();
			JetEngineScript[] componentsInChildren2 = GetComponentsInChildren<JetEngineScript>(includeInactive: true);
			if (componentsInChildren2 != null)
			{
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					if (componentsInChildren2[i].Engine.DuctedThrust)
					{
						_vtolEngines.Add(componentsInChildren2[i]);
					}
				}
			}
			_aircraftScript = GetComponent<AircraftScript>();
			_vtolEngineCount = _vtolEngines.Count;
		}

		public void RegisterRcn(ReactionControlNozzleScript reactionControlNozzleScript)
		{
			int reactionControlNozzleCount = ReactionControlNozzleCount + 1;
			ReactionControlNozzleCount = reactionControlNozzleCount;
		}

		protected virtual void FixedUpdate()
		{
			if (_aircraftScript.LoadContext != CraftLoadContext.Flight || _aircraftScript.RemoteAircraft || PauseManager.Paused)
			{
				return;
			}
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < _vtolEngines.Count; i++)
			{
				JetEngineScript jetEngineScript = _vtolEngines[i];
				float magnitude = jetEngineScript.GetCurrentEngineForce().magnitude;
				num += magnitude;
				jetEngineScript.Thrust = magnitude / 0.01f;
				num2 = Mathf.Max(num2, jetEngineScript.EngineThrottle);
			}
			CurrentMaxDuctedEngineThrottle = num2;
			if (_vtolNozzlesCount <= 0)
			{
				return;
			}
			float forceMagnitude = num / (float)_vtolNozzlesCount;
			foreach (EngineThrustPortScript vtolNozzle in _vtolNozzles)
			{
				vtolNozzle.FixedUpdateWithEnforcedOrder(forceMagnitude);
			}
		}
	}
}
