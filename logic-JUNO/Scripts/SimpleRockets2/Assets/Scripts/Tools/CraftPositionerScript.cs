using System;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Tools
{
	public class CraftPositionerScript : MonoBehaviour
	{
		private const float RegionalRange = 0.05f;

		private const float ZoneRange = 0.005f;

		[SerializeField]
		[Range(0f, 15000f)]
		private double _agl = 1000.0;

		private ICraftScript _craft;

		private ICraftNode _craftNode;

		[SerializeField]
		[Range(MathF.PI * -2f, MathF.PI * 2f)]
		private double _latitudeGlobal;

		[SerializeField]
		[Range(-0.05f, 0.05f)]
		private double _latitudeRegional;

		[SerializeField]
		[Range(-0.005f, 0.005f)]
		private double _latitudeZone;

		[SerializeField]
		[Range(0f, MathF.PI * 2f)]
		private double _longitudeGlobal;

		[SerializeField]
		[Range(-0.05f, 0.05f)]
		private double _longitudeRegional;

		[SerializeField]
		[Range(-0.005f, 0.005f)]
		private double _longitudeZone;

		[SerializeField]
		private bool _printLocation;

		private IReferenceFrame _referenceFrame;

		[SerializeField]
		private bool _updateFieldsFromCraft = true;

		private void Awake()
		{
			_craft = GetComponent<ICraftScript>();
			_craftNode = _craft.CraftNode;
			_agl = _craft.FlightData.AltitudeAboveGroundLevel;
		}

		private void OnValidate()
		{
			if (_updateFieldsFromCraft)
			{
				_updateFieldsFromCraft = false;
				UpdateFieldsFromCraft();
			}
			else if (_printLocation)
			{
				_printLocation = false;
				UpdateFieldsFromCraft();
				Debug.Log($"Latitude: {_latitudeGlobal:G17}, Longitude: {_longitudeGlobal:G17}, Altitude: {_agl:G17})");
			}
			else if (Game.Instance.FlightScene.TimeManager.Paused)
			{
				double latitude = _latitudeGlobal + _latitudeRegional + _latitudeZone;
				double longitude = _longitudeGlobal + _longitudeRegional + _longitudeZone;
				Vector3d surfacePosition = _craftNode.Parent.GetSurfacePosition(latitude, longitude, AltitudeType.AboveGroundLevel, _agl);
				Vector3d position = _craftNode.Parent.SurfaceVectorToPlanetVector(surfacePosition);
				_craftNode.SetStateVectorsAtDefaultTime(position, Vector3d.zero);
				_craftNode.RecalculateFrameState(Game.Instance.FlightScene.ViewManager.GameView.ReferenceFrame);
			}
			else
			{
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Pause the game before positioning craft...the craft would likely blow up.");
			}
		}

		private void UpdateFieldsFromCraft()
		{
			Vector3d surfacePosition = _craftNode.Parent.PlanetVectorToSurfaceVector(_craftNode.Position);
			_craftNode.Parent.GetSurfaceCoordinates(surfacePosition, out _latitudeGlobal, out _longitudeGlobal);
			_longitudeRegional = (_latitudeRegional = (_latitudeZone = (_longitudeZone = 0.0)));
		}
	}
}
