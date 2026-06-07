using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	public class GameLoopRegistrar : IGameLoopRegistrar
	{
		private DesignerGameLoop _designer;

		private FlightGameLoop _flight;

		private GenericGameLoop _generic;

		public DesignerGameLoop Designer => _designer;

		public FlightGameLoop Flight => _flight;

		public GenericGameLoop Generic => _generic;

		public void Register(IGameLoopItem script)
		{
			if ((object)_flight != null)
			{
				_flight.Register(script);
			}
			else if ((object)_designer != null)
			{
				_designer.Register(script);
			}
			else if ((object)_generic != null)
			{
				_generic.Register(script);
			}
		}

		public void Unregister(IGameLoopItem script)
		{
			if ((object)_flight != null)
			{
				_flight.Unregister(script);
			}
			else if ((object)_designer != null)
			{
				_designer.Unregister(script);
			}
			else if ((object)_generic != null)
			{
				_generic.Unregister(script);
			}
		}

		internal IDesignerGameLoop CreateDesignerLoop()
		{
			if (_flight != null)
			{
				Debug.LogError("Attempting to create designer game loop while the flight game loop is still alive. The flight game loop will be destroyed.");
				DestroyFlightLoop();
			}
			if (_generic != null)
			{
				Debug.LogError("Attempting to create designer game loop while the generic game loop is still alive. The generic game loop will be destroyed.");
				DestroyGenericLoop();
			}
			if (_designer != null)
			{
				Debug.LogError("Attempting to create designer game loop while an existing designer game loop is still alive. The existing game loop will be destroyed.");
				DestroyDesignerLoop();
			}
			if (!Game.InDesignerScene)
			{
				Debug.LogError("Attempting to create designer game loop while not in the designer scene.");
			}
			if (Game.Instance.Designer == null)
			{
				Debug.LogError("Attempting to create designer game loop but the designer script is null.");
			}
			_designer = new GameObject("DesignerGameLoop").AddComponent<DesignerGameLoop>();
			_designer.transform.SetParent(Game.Instance.Designer?.GameObject.transform ?? null, worldPositionStays: false);
			return _designer;
		}

		internal IFlightGameLoop CreateFlightLoop()
		{
			if (_designer != null)
			{
				Debug.LogError("Attempting to create flight game loop while the designer game loop is still alive. The designer game loop will be destroyed.");
				DestroyDesignerLoop();
			}
			if (_generic != null)
			{
				Debug.LogError("Attempting to create flight game loop while the generic game loop is still alive. The generic game loop will be destroyed.");
				DestroyGenericLoop();
			}
			if (_flight != null)
			{
				Debug.LogError("Attempting to create flight game loop while an existing flight game loop is still alive. The existing game loop will be destroyed.");
				DestroyFlightLoop();
			}
			if (!Game.InFlightScene)
			{
				Debug.LogError("Attempting to create flight game loop while not in the flight scene.");
			}
			if (Game.Instance.FlightScene == null)
			{
				Debug.LogError("Attempting to create flight game loop but the flight script is null.");
			}
			_flight = new GameObject("FlightGameLoop").AddComponent<FlightGameLoop>();
			_flight.transform.SetParent(Game.Instance.FlightScene?.GameObject.transform ?? null, worldPositionStays: false);
			return _flight;
		}

		internal IGenericGameLoop CreateGenericLoop()
		{
			if (_flight != null)
			{
				Debug.LogError("Attempting to create generic game loop while the flight game loop is still alive. The flight game loop will be destroyed.");
				DestroyFlightLoop();
			}
			if (_designer != null)
			{
				Debug.LogError("Attempting to create generic game loop while the designer game loop is still alive. The designer game loop will be destroyed.");
				DestroyDesignerLoop();
			}
			if (_generic != null)
			{
				Debug.LogError("Attempting to create generic game loop while an existing generic game loop is still alive. The existing game loop will be destroyed.");
				DestroyGenericLoop();
			}
			if (Game.InDesignerScene || Game.InFlightScene)
			{
				Debug.LogError("Attempting to create generic game loop while in the flight or designer scene.");
			}
			_generic = new GameObject("GenericGameLoop").AddComponent<GenericGameLoop>();
			return _generic;
		}

		internal void DestroyDesignerLoop()
		{
			if (_designer != null)
			{
				Object.Destroy(_designer);
			}
			_designer = null;
		}

		internal void DestroyFlightLoop()
		{
			if (_flight != null)
			{
				Object.Destroy(_flight);
			}
			_flight = null;
		}

		internal void DestroyGenericLoop()
		{
			if (_generic != null)
			{
				Object.Destroy(_generic);
			}
			_generic = null;
		}
	}
}
