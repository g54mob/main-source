using System;
using System.Linq;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Ui.Inspector;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class OrbitModel
	{
		public delegate void OrbitUpdatedHandler();

		private const float SemiMajorAxisFactor = 1000000f;

		private const double SemiMajorAxisSmoothing = 10.0;

		private TextButtonModel _buttonResetSoi;

		private ColorModel _color;

		private IOrbit _currentOrbit;

		private IOrbitNode _currentOrbitNode;

		private double _currentSoi;

		private NumericInputModel _inputAngularVelocity;

		private IIocContainer _ioc;

		private IItemRegistry _itemRegistry;

		private MapPlanet _mapPlanet;

		private IMapViewContext _mapViewContext;

		private SliderModel _sliderArgOfPeriapsis;

		private SliderModel _sliderEccentricity;

		private SliderModel _sliderInclination;

		private SliderModel _sliderRightAscention;

		private SliderModel _sliderRotationAngle;

		private SliderModel _sliderSemiMajorAxis;

		private SliderModel _sliderSoi;

		private SliderModel _sliderTrueAnomaly;

		private float _soiAdjust;

		private TextButtonModel _tidalLockButton;

		public double ApoapsisAltitude { get; private set; }

		public double ApoapsisTime { get; private set; }

		public bool AreSlidersEnabled
		{
			get
			{
				if (_sliderArgOfPeriapsis?.ItemElement == null)
				{
					return false;
				}
				return (_sliderArgOfPeriapsis.ItemElement as SliderElement).Interactable;
			}
		}

		public string ArgumentOfPeriapsis { get; private set; }

		public string Eccentricity { get; private set; }

		public GroupModel Group { get; private set; }

		public string Inclination { get; private set; }

		public string ParentPlanet { get; private set; }

		public double PeriapsisAltitude { get; private set; }

		public double PeriapsisTime { get; private set; }

		public string Period { get; private set; }

		public string RightAscension { get; private set; }

		public string SemiMajorAxis { get; private set; }

		public string TrueAnomaly { get; private set; }

		private bool AllowEditing => Game.InPlanetStudioScene;

		public event OrbitUpdatedHandler OrbitUpdated;

		public OrbitModel(IIocContainer ioc, IMapViewContext mapViewContext)
		{
			_ioc = ioc;
			_mapViewContext = mapViewContext;
			_itemRegistry = ioc.Resolve<IItemRegistry>(mapViewContext);
			Group = new GroupModel("Orbit Details");
			if (AllowEditing)
			{
				Group.Add(new TextModel("Period", () => Period));
				_color = new ColorModel("Color", () => _mapPlanet?.PlanetNode?.PlanetData?.PlanetarySystemDefinedData?.OrbitColor ?? Color.white, delegate(Color c)
				{
					if (_mapPlanet?.PlanetNode?.PlanetData?.PlanetarySystemDefinedData != null)
					{
						_mapPlanet.PlanetNode.PlanetData.PlanetarySystemDefinedData.OrbitColor = c;
						_mapPlanet.OrbitInfo.SetOrbitLineColor(c);
					}
				}, allowTransparency: false, callbackOnPreviewColorChange: true);
				_sliderTrueAnomaly = new SliderModel("True Anomaly", () => (float)(_currentOrbit?.TrueAnomaly ?? 0.0), delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, _currentOrbit.Eccentricity, _currentOrbit.SemiMajorAxis, _currentOrbit.PeriapsisAngle, x, _currentOrbit.Inclination, _currentOrbit.RightAscensionOfAscendingNode);
					}
				}, 0f, MathF.PI * 2f);
				_sliderEccentricity = new SliderModel("Eccentricity", () => (float)(_currentOrbit?.Eccentricity ?? 0.0), delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, x, _currentOrbit.SemiMajorAxis, _currentOrbit.PeriapsisAngle, _currentOrbit.TrueAnomaly, _currentOrbit.Inclination, _currentOrbit.RightAscensionOfAscendingNode);
					}
				}, 0.001f, 0.99999f);
				_sliderInclination = new SliderModel("Inclination", () => (float)(_currentOrbit?.Inclination ?? 0.0), delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, _currentOrbit.Eccentricity, _currentOrbit.SemiMajorAxis, _currentOrbit.PeriapsisAngle, _currentOrbit.TrueAnomaly, x, _currentOrbit.RightAscensionOfAscendingNode);
					}
				}, 0f, MathF.PI * 2f);
				_sliderRightAscention = new SliderModel("Right Ascension", () => (float)(_currentOrbit?.RightAscensionOfAscendingNode ?? 0.0), delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, _currentOrbit.Eccentricity, _currentOrbit.SemiMajorAxis, _currentOrbit.PeriapsisAngle, _currentOrbit.TrueAnomaly, _currentOrbit.Inclination, x);
					}
				}, 0f, MathF.PI * 2f);
				_inputAngularVelocity = new NumericInputModel("Day Length", delegate
				{
					double num = (_mapPlanet?.PlanetNode?.PlanetData?.AngularVelocity).GetValueOrDefault() / (Math.PI * 2.0);
					return 1.0 / (num * 60.0 * 60.0);
				}, delegate(double hoursPerRev)
				{
					if (_mapPlanet?.PlanetNode != null)
					{
						if (Mathd.Abs(hoursPerRev) < 0.1)
						{
							hoursPerRev = Mathd.Sign(hoursPerRev) * 0.1;
						}
						double num = hoursPerRev * 60.0 * 60.0 / (Math.PI * 2.0);
						double value = 1.0 / num;
						_mapPlanet.PlanetNode.PlanetData.PlanetarySystemDefinedData.AngularVelocity = value;
						PlanetarySystemDesignerScript.Instance.HasUnsavedChanges = true;
					}
				});
				_inputAngularVelocity.Tooltip = "The length of a day in hours.";
				_tidalLockButton = new TextButtonModel("Tidal Lock", delegate
				{
					double num = Math.PI * 2.0 / _currentOrbit.Period;
					int num2 = ((_currentOrbit.Inclination < Math.PI / 2.0) ? (-1) : ((!(_currentOrbit.Inclination > 4.71238898038469)) ? 1 : (-1)));
					_mapPlanet.PlanetNode.PlanetData.PlanetarySystemDefinedData.AngularVelocity = (double)num2 * num;
					PlanetarySystemDesignerScript.Instance.HasUnsavedChanges = true;
				});
				_tidalLockButton.Tooltip = "Updates the angular velocity so that the planet is tidally locked in its current orbit. If the orbit is changed, then this button must be used again.";
				_sliderRotationAngle = new SliderModel("Rotation", () => (float)MathUtils.LimitAngle0to2PI((_mapPlanet?.PlanetNode?.RotationAngle).GetValueOrDefault()), delegate(float x)
				{
					if (_mapPlanet?.PlanetNode != null)
					{
						_mapPlanet.PlanetNode.PlanetData.PlanetarySystemDefinedData.InitialRotation = x;
						_mapPlanet.PlanetNode.RotationAngle = x;
						PlanetarySystemDesignerScript.Instance.HasUnsavedChanges = true;
					}
				}, 0f, MathF.PI * 2f);
				_sliderSemiMajorAxis = new SliderModel("Semi-Major Axis", () => (_currentOrbit != null) ? ((float)Math.Pow(_currentOrbit.SemiMajorAxis / _currentOrbitNode.Parent.MaxChildDistance, 0.1)) : 0f, delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, _currentOrbit.Eccentricity, Mathd.Pow(x, 10.0) * (_currentOrbitNode?.Parent?.MaxChildDistance ?? 1.0), _currentOrbit.PeriapsisAngle, _currentOrbit.TrueAnomaly, _currentOrbit.Inclination, _currentOrbit.RightAscensionOfAscendingNode);
					}
				}, (float)Math.Pow(0.001, 0.1));
				_sliderArgOfPeriapsis = new SliderModel("Arg of Periapsis", () => (float)(_currentOrbit?.PeriapsisAngle ?? 0.0), delegate(float x)
				{
					if (_currentOrbit != null)
					{
						UpdateOrbit(_currentOrbit.Time, _currentOrbit.Eccentricity, _currentOrbit.SemiMajorAxis, x, _currentOrbit.TrueAnomaly, _currentOrbit.Inclination, _currentOrbit.RightAscensionOfAscendingNode);
					}
				}, 0f, MathF.PI * 2f);
				_soiAdjust = 0f;
				_sliderSoi = new SliderModel("Sphere Of Influence", () => _soiAdjust, delegate(float x)
				{
					_soiAdjust = x;
					if (_currentOrbit != null)
					{
						_mapPlanet.SetSoi(_currentSoi * (double)GetSoiScalar(x));
					}
				}, -1f);
				_buttonResetSoi = new TextButtonModel("Default Sphere Of Influence", delegate
				{
					if (_currentOrbit != null)
					{
						_mapPlanet.PlanetNode.AutoCalculateSphereOfInfluence();
					}
				});
				_buttonResetSoi.Tooltip = "Reset the sphere of influence of the planet to its default value.  Note: The default value may not be large enough to encompass child planets.  You may need to adjust the size to ensure all children (and their SOI) are within the bounds.";
				_sliderSoi.OnSliderAdjustmentEnded += delegate
				{
					_soiAdjust = 0f;
					_currentSoi = _mapPlanet.PlanetNode.SphereOfInfluence;
					PlanetarySystemDesignerScript.Instance.CurrentPlanetarySystem.Planets.Where((PlanetDataScript y) => y.Name == _mapPlanet.PlanetNode.Name).FirstOrDefault().PlanetarySystemDefinedData.SphereOfInfluence = _currentSoi;
					PlanetarySystemDesignerScript.Instance.HasUnsavedChanges = true;
				};
				_sliderSoi.OnSliderAdjustmentStarted += delegate
				{
					_currentSoi = _mapPlanet.PlanetNode.SphereOfInfluence;
				};
				_sliderSoi.ValueFormatter = (float x) => $"{(int)(GetSoiScalar(x) * 100f)}%";
				_sliderTrueAnomaly.ValueFormatter = (float x) => x.ToString();
				_sliderEccentricity.ValueFormatter = (float x) => x.ToString();
				_sliderInclination.ValueFormatter = (float x) => x.ToString();
				_sliderRightAscention.ValueFormatter = (float x) => x.ToString();
				_sliderArgOfPeriapsis.ValueFormatter = (float x) => x.ToString();
				_sliderRotationAngle.ValueFormatter = (float x) => $"{MathUtils.LimitAngle0to2PI(x):n3}";
				_sliderSemiMajorAxis.ValueFormatter = (float x) => FormatSemiMajorAxis((float)Mathd.Pow(x, 10.0));
				_sliderSemiMajorAxis.AllowManualInput = false;
				_sliderSoi.AllowManualInput = false;
				Group.Add(_color);
				Group.Add(_sliderTrueAnomaly);
				Group.Add(_sliderEccentricity);
				Group.Add(_sliderInclination);
				Group.Add(_sliderRightAscention);
				Group.Add(_sliderArgOfPeriapsis);
				Group.Add(_sliderSemiMajorAxis);
				Group.Add(_sliderSoi);
				Group.Add(_buttonResetSoi);
				Group.Add(_sliderRotationAngle);
				Group.Add(_inputAngularVelocity);
				Group.Add(_tidalLockButton);
			}
			else
			{
				Group.Add(new TextModel("Parent", () => ParentPlanet));
				Group.Add(new TextModel("Period", () => Period));
				Group.Add(new TextModel("Apoapsis", () => Units.GetDistanceString((float)ApoapsisAltitude)));
				Group.Add(new TextModel("Periapsis", () => Units.GetDistanceString((float)PeriapsisAltitude, useAbsoluteValue: false)));
				Group.Add(new TextModel("Time to Apo.", () => Units.GetRelativeTimeString(ApoapsisTime)));
				Group.Add(new TextModel("Time to Per.", () => Units.GetRelativeTimeString(PeriapsisTime)));
				Group.Add(new TextModel("Eccentricity", () => Eccentricity));
				Group.Add(new TextModel("Inclination", () => Inclination));
				Group.Add(new TextModel("Semi-Major Axis", () => SemiMajorAxis));
				Group.Add(new TextModel("Right Ascension", () => RightAscension));
				Group.Add(new TextModel("Arg of Periapsis", () => ArgumentOfPeriapsis));
				Group.Add(new TextModel("True Anomaly", () => TrueAnomaly));
			}
			static float GetSoiScalar(float sliderValue)
			{
				if (sliderValue < 0f)
				{
					return sliderValue * 0.5f + 1f;
				}
				return sliderValue + 1f;
			}
		}

		public void Update(IOrbitNode node)
		{
			_currentOrbitNode = node;
			IOrbit orbit = node.Orbit;
			if (AllowEditing)
			{
				if (node is IPlanetNode planetNode)
				{
					bool num = _itemRegistry.GetPlanet(planetNode) != _mapPlanet;
					_mapPlanet = _itemRegistry.GetPlanet(planetNode);
					if (num)
					{
						_currentSoi = _mapPlanet.PlanetNode.SphereOfInfluence;
					}
				}
				_currentOrbit = orbit;
			}
			else
			{
				_currentOrbit = null;
			}
			if (orbit != null)
			{
				Period = Units.GetRelativeTimeString(orbit.Period);
				if (AllowEditing)
				{
					if (!AreSlidersEnabled)
					{
						SetSlidersEnabled(enabled: true);
					}
					return;
				}
				ParentPlanet = "N/A";
				ApoapsisAltitude = double.NaN;
				PeriapsisAltitude = double.NaN;
				ApoapsisTime = double.NaN;
				PeriapsisTime = double.NaN;
				ICraftNode obj = node as ICraftNode;
				bool flag = (obj != null && obj.InContactWithPlanet) || node is IStructureNode;
				if (node.Parent is PlanetNode planetNode2)
				{
					ParentPlanet = planetNode2.Name;
					double num2 = orbit.ApoapsisDistance - planetNode2.PlanetData.Radius;
					if (num2 > 0.0 && !flag)
					{
						ApoapsisAltitude = num2;
						ApoapsisTime = orbit.GetTimeToApoapsis();
					}
					if (!flag)
					{
						double periapsisAltitude = orbit.PeriapsisDistance - planetNode2.PlanetData.Radius;
						PeriapsisAltitude = periapsisAltitude;
						PeriapsisTime = orbit.GetTimeToPeriapsis();
					}
				}
				Eccentricity = orbit.Eccentricity.ToString("0.00");
				SemiMajorAxis = Units.GetDistanceString(Mathf.Abs((float)orbit.SemiMajorAxis));
				float num3 = 57.29578f;
				string text = "0.00°";
				Inclination = (orbit.Inclination * (double)num3).ToString(text);
				ArgumentOfPeriapsis = (orbit.PeriapsisAngle * (double)num3).ToString(text);
				RightAscension = (orbit.RightAscensionOfAscendingNode * (double)num3).ToString(text);
				TrueAnomaly = (orbit.TrueAnomaly * (double)num3).ToString(text);
				return;
			}
			Period = "N/A";
			if (AllowEditing)
			{
				if (AreSlidersEnabled)
				{
					SetSlidersEnabled(enabled: false);
				}
				return;
			}
			ParentPlanet = "N/A";
			ApoapsisAltitude = double.NaN;
			PeriapsisAltitude = double.NaN;
			ApoapsisTime = double.NaN;
			PeriapsisTime = double.NaN;
			Eccentricity = "N/A";
			Inclination = "N/A";
			SemiMajorAxis = "N/A";
			ArgumentOfPeriapsis = "N/A";
			RightAscension = "N/A";
			TrueAnomaly = "N/A";
		}

		private static void SetSliderEnabled(IItemElement element, bool enabled)
		{
			(element as SliderElement).Interactable = enabled;
		}

		private string FormatSemiMajorAxis(float percentOfParentSoi)
		{
			return Units.GetDistanceString((float)((double)percentOfParentSoi * (_currentOrbitNode?.Parent?.MaxChildDistance ?? 1.0)));
		}

		private void SetSlidersEnabled(bool enabled)
		{
			_color.Visible = enabled;
			SetSliderEnabled(_sliderTrueAnomaly.ItemElement, enabled);
			SetSliderEnabled(_sliderEccentricity.ItemElement, enabled);
			SetSliderEnabled(_sliderInclination.ItemElement, enabled);
			SetSliderEnabled(_sliderRightAscention.ItemElement, enabled);
			SetSliderEnabled(_sliderArgOfPeriapsis.ItemElement, enabled);
			SetSliderEnabled(_sliderSemiMajorAxis.ItemElement, enabled);
			SetSliderEnabled(_sliderRotationAngle.ItemElement, enabled);
			_inputAngularVelocity.Visible = enabled;
			_tidalLockButton.Visible = enabled;
		}

		private void UpdateOrbit(double time, double eccentricity, double semiMajorAxis, double periapsisAngle, double trueAnomaly, double inclination, double rightAscention)
		{
			_currentOrbit?.UpdateFromOrbitalElements(time, eccentricity, semiMajorAxis, periapsisAngle, trueAnomaly, inclination, rightAscention, _currentOrbit.PrimaryMass, _currentOrbit.IsPrograde);
			this.OrbitUpdated?.Invoke();
			PlanetarySystemDesignerScript.Instance.HasUnsavedChanges = true;
		}
	}
}
