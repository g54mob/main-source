using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.State.MapView;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Options
{
	public class MapOptionsScript : MonoBehaviour, IMapOptions, ITargetingOptions, INodeNavOptions, ICraftOptions, IManeuverNodeOptions
	{
		private const string DebugGroupCraft = "Craft Options";

		private const string DebugGroupManeuverNodes = "Maneuver Node Options";

		private const string DebugGroupNodeNav = "Node Nav Options";

		private const string DebugGroupTargeting = "Targeting Options";

		private const int XmlVersion = 2;

		[SerializeField]
		private bool _autoDeleteCompletedManeuverNodes = true;

		[SerializeField]
		private bool _autoWarpToNextNode;

		[SerializeField]
		private bool _changeCameraWhenWarping;

		[SerializeField]
		private bool _cheatAutoBurns;

		[SerializeField]
		private bool _continuouslyUpdateChain;

		[SerializeField]
		[Range(10000f, 5000000f)]
		private double _craftSoiDistance;

		[SerializeField]
		private bool _displayInfoWhenAdjusting = true;

		private MapViewFontSize _fontSize;

		private GizmoAlignmentType _gizmoAlignment;

		private double _maneuverNodeSensitivityExpo;

		[SerializeField]
		[Range(0f, 5f)]
		private double _maneuverNodeSensitivityLinear;

		[SerializeField]
		private double _maxBurnTimePerPass = 120.0;

		[SerializeField]
		[Range(0f, 10f)]
		private float _maxManeuverNodeGizmoMultiplier = 1f;

		private AdjustmentSpaceType _nodeAdjustmentSpace;

		[SerializeField]
		[Range(0f, 1f)]
		private double _offsetWithinPeriod;

		private OrbitUiVerbosity _orbitUiVerbosity;

		[SerializeField]
		[Range(0f, 10f)]
		private int _periodsInFutureToBegin;

		[SerializeField]
		private bool _searchWholeOrbit;

		[SerializeField]
		private bool _showAutoBurnVectors;

		[SerializeField]
		private bool _showBurnAccuracyDebugGizmos;

		[SerializeField]
		[Range(0.1f, 10f)]
		private double _soiEntryResolutionModifier = 1.0;

		[SerializeField]
		[Range(0.0005f, 10f)]
		private float _thrustScale = 1f;

		[SerializeField]
		private bool _useBinarySearch;

		[SerializeField]
		[Range(0f, 120f)]
		private double _warpBufferSeconds = 3.0;

		[SerializeField]
		[Range(0f, 10f)]
		private double _warpSpeedModifier = 10.0;

		bool INodeNavOptions.AutoDeleteManeuverNodes => _autoDeleteCompletedManeuverNodes;

		bool INodeNavOptions.AutoWarpToNextNode => _autoWarpToNextNode;

		GizmoAlignmentType IMapOptions.BurnGizmoAlignment
		{
			get
			{
				return _gizmoAlignment;
			}
			set
			{
				_gizmoAlignment = value;
			}
		}

		bool INodeNavOptions.ChangeCameraWhenWarping => _changeCameraWhenWarping;

		bool INodeNavOptions.CheatAutoBurns => _cheatAutoBurns;

		bool ICraftOptions.ContinuouslyUpdateChain => _continuouslyUpdateChain;

		ICraftOptions IMapOptions.Craft => this;

		double ITargetingOptions.CraftSoiDistance
		{
			get
			{
				return _craftSoiDistance;
			}
			set
			{
				_craftSoiDistance = value;
			}
		}

		bool IManeuverNodeOptions.DisplayInfoWhenAdjusting
		{
			get
			{
				return _displayInfoWhenAdjusting;
			}
			set
			{
				_displayInfoWhenAdjusting = value;
			}
		}

		public MapViewFontSize FontSize
		{
			get
			{
				return _fontSize;
			}
			set
			{
				_fontSize = value;
				switch (_fontSize)
				{
				case MapViewFontSize.Small:
					FontSizeValue = 10f;
					break;
				case MapViewFontSize.Large:
					FontSizeValue = 18f;
					break;
				case MapViewFontSize.ExtraLarge:
					FontSizeValue = 24f;
					break;
				default:
					FontSizeValue = 14f;
					break;
				}
			}
		}

		public float FontSizeValue { get; private set; }

		IManeuverNodeOptions IMapOptions.ManeuverNodes => this;

		double INodeNavOptions.MaxBurnTimePerPass
		{
			get
			{
				return _maxBurnTimePerPass;
			}
			set
			{
				_maxBurnTimePerPass = value;
			}
		}

		float IManeuverNodeOptions.MaxGizmoMultiplier => _maxManeuverNodeGizmoMultiplier;

		AdjustmentSpaceType IMapOptions.NodeAdjustmentSpace
		{
			get
			{
				return _nodeAdjustmentSpace;
			}
			set
			{
				_nodeAdjustmentSpace = value;
			}
		}

		INodeNavOptions IMapOptions.NodeNav => this;

		OrbitUiVerbosity IMapOptions.OrbitUiVerbosity
		{
			get
			{
				return _orbitUiVerbosity;
			}
			set
			{
				_orbitUiVerbosity = value;
			}
		}

		double ITargetingOptions.PeriodsInFutureToBegin => (double)_periodsInFutureToBegin + _offsetWithinPeriod;

		bool ITargetingOptions.SearchWholeOrbit
		{
			get
			{
				return _searchWholeOrbit;
			}
			set
			{
				_searchWholeOrbit = value;
			}
		}

		double IManeuverNodeOptions.SensitivityExpo => _maneuverNodeSensitivityExpo;

		double IManeuverNodeOptions.SensitivityLinear
		{
			get
			{
				return _maneuverNodeSensitivityLinear;
			}
			set
			{
				_maneuverNodeSensitivityLinear = value;
				_maneuverNodeSensitivityExpo = Mathd.Pow(value, 1.5);
			}
		}

		bool INodeNavOptions.ShowAutoBurnVectors => _showAutoBurnVectors;

		bool IManeuverNodeOptions.ShowBurnAccuracyDebugGizmos
		{
			get
			{
				return _showBurnAccuracyDebugGizmos;
			}
			set
			{
				_showBurnAccuracyDebugGizmos = value;
			}
		}

		double ITargetingOptions.SoiEntryLocalMinimaModifier
		{
			get
			{
				return _soiEntryResolutionModifier;
			}
			set
			{
				_soiEntryResolutionModifier = value;
			}
		}

		ITargetingOptions IMapOptions.Targeting => this;

		float ICraftOptions.ThrustScale => _thrustScale;

		bool ITargetingOptions.UseBinarySearch
		{
			get
			{
				return _useBinarySearch;
			}
			set
			{
				_useBinarySearch = value;
			}
		}

		double INodeNavOptions.WarpBufferSeconds => _warpBufferSeconds;

		double INodeNavOptions.WarpSpeedModifier => _warpSpeedModifier;

		public static MapOptionsScript Create(IIocContainer ioc, GameObject parent)
		{
			MapOptionsScript mapOptionsScript = parent.AddComponent<MapOptionsScript>();
			mapOptionsScript.Initialize(ioc);
			return mapOptionsScript;
		}

		XElement IMapOptions.GenerateXml()
		{
			return new XElement("MapOptions", new XAttribute("gizmoAlignment", _gizmoAlignment), new XAttribute("maneuverNodeSensitivityLinear", _maneuverNodeSensitivityLinear), new XAttribute("orbitUiVerbosity", _orbitUiVerbosity), new XAttribute("fontSize", _fontSize), new XAttribute("version", 2));
		}

		void IMapOptions.ResetDefaults()
		{
			_gizmoAlignment = GizmoAlignmentType.ReferenceOrbit;
			((IManeuverNodeOptions)this).SensitivityLinear = 0.5;
			_orbitUiVerbosity = OrbitUiVerbosity.High;
			FontSize = MapViewFontSize.Default;
		}

		void IMapOptions.RestoreFromXml(XElement mapOptionsContainerElement)
		{
			if (mapOptionsContainerElement == null)
			{
				mapOptionsContainerElement = new XElement("MapOptions");
			}
			int intAttribute = Utilities.GetIntAttribute(mapOptionsContainerElement, "version", 1);
			_gizmoAlignment = Utilities.GetEnumAttribute(mapOptionsContainerElement, "gizmoAlignment", GizmoAlignmentType.ReferenceOrbit);
			((IManeuverNodeOptions)this).SensitivityLinear = Utilities.GetFloatAttribute(mapOptionsContainerElement, "maneuverNodeSensitivityLinear", 0.5f);
			_orbitUiVerbosity = Utilities.GetEnumAttribute(mapOptionsContainerElement, "orbitUiVerbosity", OrbitUiVerbosity.Medium);
			FontSize = Utilities.GetEnumAttribute(mapOptionsContainerElement, "fontSize", MapViewFontSize.Default);
			if (intAttribute < 2)
			{
				((IMapOptions)this).ResetDefaults();
			}
		}

		private void Initialize(IIocContainer ioc)
		{
			ioc.Register((IMapOptions)this);
			if (Game.InFlightScene)
			{
				MapViewData mapView = ((FlightSceneScript)Game.Instance.FlightScene).FlightState.MapView;
				((IMapOptions)this).RestoreFromXml(mapView.MapOptionsContainerElement);
			}
			else
			{
				((IMapOptions)this).ResetDefaults();
			}
		}

		private void OnValidate()
		{
			EngineCommon.GlobalDebugThrustScale = _thrustScale;
		}
	}
}
