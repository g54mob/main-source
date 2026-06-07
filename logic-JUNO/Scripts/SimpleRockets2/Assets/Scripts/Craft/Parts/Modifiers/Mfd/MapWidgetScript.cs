using Assets.Scripts.Flight.UI.Navball;
using ModApi.Craft;
using ModApi.Craft.Program.Craft;
using ModApi.Flight.Sim;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Planet;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class MapWidgetScript : WidgetScript, IMapWidget, IFlightUpdate, IGameLoopItem
	{
		private NavballRendererControllerScript _controller;

		private ICraftScript _craft;

		private PlanetCubemapsRequest _cubemapsRequest;

		private IPlanetNode _planet;

		public Vector2d Coordinates { get; set; }

		public float Heading { get; set; }

		public bool ManualMode { get; set; }

		public bool NorthUp { get; set; }

		public string PlanetName { get; set; }

		public float Zoom
		{
			get
			{
				return _controller.MapZoom;
			}
			set
			{
				_controller.MapZoom = Mathf.Clamp(value, 1f, 7f);
			}
		}

		public void FlightUpdate(in FlightFrameData frame)
		{
			Vector3d vector3d;
			if (!ManualMode)
			{
				Heading = (NorthUp ? 0f : ((float)_craft.FlightData.Heading));
				OnPlanetChanged(_craft.CraftNode.Parent);
				_planet.GetSurfaceCoordinates(_planet.PlanetVectorToSurfaceVector(_craft.CraftNode.Position), out var latitude, out var longitude);
				latitude *= 57.29578;
				longitude *= 57.29578;
				Coordinates = new Vector2d(latitude, longitude);
				vector3d = _craft.CraftNode.Position;
			}
			else
			{
				if (_planet == null || _planet.Name != PlanetName)
				{
					IPlanetNode planet = frame.FlightScene.FlightState.RootNode.FindPlanet(PlanetName) ?? _craft.CraftNode.Parent;
					OnPlanetChanged(planet);
				}
				Vector2d vector2d = Coordinates * 0.01745329;
				vector3d = _planet.SurfaceVectorToPlanetVector(_planet.GetSurfacePosition(vector2d.x, vector2d.y, AltitudeType.AboveSeaLevel, 0.0));
			}
			Quaternion mapRotation = Quaternion.LookRotation(Quaternion.Inverse(_planet.Rotation.ToQuaternion()) * vector3d.ToVector3()) * Quaternion.AngleAxis(Heading, Vector3.forward);
			_controller.MapRotation = mapRotation;
		}

		public override void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			base.transform.localPosition = Vector3.zero;
			_craft = mfdScript.PartScript.CraftScript;
			_controller = GetComponent<NavballRendererControllerScript>();
			_controller.StencilValue = mfdScript.StencilValue;
			base.Initialize(mfdScript, name, widgetType);
			_controller.MapEnabled = true;
			_controller.MapZoom = 1f;
		}

		protected virtual void OnDestroy()
		{
			_cubemapsRequest?.Cancel();
			_cubemapsRequest = null;
		}

		private void OnCubemapsUpdated(PlanetCubemapsRequest request)
		{
			_controller.SetCubemap(request.CubemapColor);
		}

		private void OnPlanetChanged(IPlanetNode planet)
		{
			if (_planet != planet)
			{
				_planet = planet;
				PlanetName = _planet.Name;
				TerrainQualitySettings.CubemapQualitySettings cubemapSettings = Game.Instance.QualitySettings.Terrain.CubemapSettings;
				_cubemapsRequest?.Cancel();
				_cubemapsRequest = planet.PlanetData.RequestCubemaps("Map Widget", cubemapSettings.NavMapSize, OnCubemapsUpdated);
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			FlightUpdate(in frame);
		}
	}
}
