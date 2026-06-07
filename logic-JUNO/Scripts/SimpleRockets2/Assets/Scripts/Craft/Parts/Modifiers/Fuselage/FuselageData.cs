using System;
using Assets.Scripts.Design;
using Jundroo.ModTools.Serialization.Xml;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Data;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	[Serializable]
	[DesignerPartModifier("Resizable Part")]
	public class FuselageData : PartModifierData<FuselageScript>
	{
		public enum FlattenNormalsOptions
		{
			None = 0,
			Top = 1,
			Bottom = 2,
			Both = 3
		}

		public const float MinimumScale = 0.01f;

		public const float ShellThickness = 0.0075f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Auto Resize", Order = 4, Tooltip = "Determines if the part should automatically attempt to resize itself when connecting to a similar part to match its dimensions.")]
		private bool _autoResize = true;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private Vector2 _bottomScale = new Vector2(1f, 1f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _buoyancy;

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private float[] _clampDistances = new float[8] { -1f, 1f, -1f, 1f, -1f, 1f, -1f, 1f };

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private float[] _cornerRadiuses = new float[8] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _deadWeight;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 101, Label = "Dead Weight", Order = 1, Tooltip = "The amount of dead weight to include with this part, using up it's tank capacity. It can be helpful in adjusting the Center of Mass of your craft or increasing the part's impact resistance.", TechTreeIdForMaxValue = "Fuselage.DeadWeight")]
		private float _deadWeightPercentage = -1f;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private Vector3 _deformations = new Vector3(0f, 0f, 0f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _depthCurve = "0";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _depthCurved;

		private IDesignerPartPropertiesModifierInterface _designerPartProperties;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Seamless Edges", Order = 3, Tooltip = "Attempt to create a seamless joint between parts. This is an experimental feature and in some cases will look worse than expected.")]
		private FlattenNormalsOptions _flattenNormals;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 21, Label = "Fuel", Order = 2, Tooltip = "The amount of fuel to put in this fuel tank.")]
		private float _fuelPercentage;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _meshMassMultiplier = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _meshPriceMultiplier = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private FuselageMeshType _meshType;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _normalSmoothingAngle = 60f;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private Vector3 _offset = new Vector3(0f, 2f, 0f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _shellDensityOverride = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _subpartIndex;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsXZOffset = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolAutoAdaptBottom = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolAutoAdaptTop = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolIgnore;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolResizeBottom = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolResizeHeight = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolResizeRadius = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolResizeTop = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolShapeBottom = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolShapeTop = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _toolSupportsAddSection;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways)]
		private Vector2 _topScale = new Vector2(1f, 1f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _volume = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _volumeInner = -1f;

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private float[] _wallThickness = new float[2] { 1f, 1f };

		public bool AutoResize
		{
			get
			{
				if (_autoResize)
				{
					return Game.Instance.Settings.Game.Designer.EnableAutoResize;
				}
				return false;
			}
			set
			{
				_autoResize = value;
			}
		}

		public Vector2 BottomScale
		{
			get
			{
				return _bottomScale;
			}
			set
			{
				_bottomScale = ClampScale(value, _topScale);
			}
		}

		public float Buoyancy => _buoyancy;

		public float[] ClampDistances => _clampDistances;

		public float[] CornerRadiuses => _cornerRadiuses;

		public float DeadWeight
		{
			get
			{
				return _deadWeight;
			}
			set
			{
				_deadWeight = value;
			}
		}

		public float DeadWeightPercentage
		{
			get
			{
				return _deadWeightPercentage;
			}
			set
			{
				_deadWeightPercentage = value;
			}
		}

		public Vector3 Deformations
		{
			get
			{
				return _deformations;
			}
			set
			{
				_deformations = (_supportsXZOffset ? value : _deformations);
			}
		}

		public AnimationCurve DepthCurve
		{
			get
			{
				if (_depthCurve == "0" || string.IsNullOrEmpty(_depthCurve))
				{
					return null;
				}
				AnimationCurve animationCurve = new AnimationCurve();
				UserCurve.AddKeyframes(animationCurve, _depthCurve);
				if (animationCurve.length <= 0)
				{
					return null;
				}
				return animationCurve;
			}
			set
			{
				_depthCurve = ((value == null) ? "0" : UserCurve.GetKeyframesAsString(value, UserCurve.CurveStyle.Custom));
				base.Script.UpdateMeshes();
			}
		}

		public bool DepthCurved => _depthCurved;

		public FlattenNormalsOptions FlattenNormals => _flattenNormals;

		public float FuelPercentage
		{
			get
			{
				return _fuelPercentage;
			}
			set
			{
				_fuelPercentage = value;
			}
		}

		public float InnerVolume
		{
			get
			{
				return _volumeInner;
			}
			set
			{
				_volumeInner = value;
			}
		}

		public override float MassDry => (((Volume - InnerVolume) * ((_shellDensityOverride < 0f) ? 2500f : _shellDensityOverride) + DeadWeight) * MeshMassMultiplier + (float)((base.Version == 1) ? 1 : 0)) * 0.01f;

		public float MeshMassMultiplier
		{
			get
			{
				return _meshMassMultiplier;
			}
			set
			{
				_meshMassMultiplier = value;
			}
		}

		public float MeshPriceMultiplier
		{
			get
			{
				return _meshPriceMultiplier;
			}
			set
			{
				_meshPriceMultiplier = value;
			}
		}

		public FuselageMeshType MeshType => _meshType;

		public float NormalSmoothingAngle => _normalSmoothingAngle;

		public Vector3 Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
				if (!_supportsXZOffset && (_offset.x != 0f || _offset.z != 0f))
				{
					_offset.x = 0f;
					_offset.z = 0f;
				}
			}
		}

		public override long Price
		{
			get
			{
				FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
				float num = 1f;
				if (modifier != null)
				{
					num = 2f - _deadWeightPercentage;
				}
				return (long)(MeshPriceMultiplier * ((base.Mass * 100f - DeadWeight) * num * 10f + DeadWeight * 1f));
			}
		}

		public int SubpartIndex => _subpartIndex;

		public bool SupportsAddSection => _toolSupportsAddSection;

		public bool SupportsXZOffset => _supportsXZOffset;

		public bool ToolAutoAdaptBottom => _toolAutoAdaptBottom;

		public bool ToolAutoAdaptTop => _toolAutoAdaptTop;

		public bool ToolIgnore => _toolIgnore;

		public bool ToolResizeBottom
		{
			get
			{
				return _toolResizeBottom;
			}
			set
			{
				_toolResizeBottom = value;
			}
		}

		public bool ToolResizeHeight
		{
			get
			{
				return _toolResizeHeight;
			}
			set
			{
				_toolResizeHeight = value;
			}
		}

		public bool ToolResizeRadius => _toolResizeRadius;

		public bool ToolResizeTop
		{
			get
			{
				return _toolResizeTop;
			}
			set
			{
				_toolResizeTop = value;
			}
		}

		public bool ToolShapeBottom => _toolShapeBottom;

		public bool ToolShapeTop => _toolShapeTop;

		public Vector2 TopScale
		{
			get
			{
				return _topScale;
			}
			set
			{
				_topScale = ClampScale(value, _bottomScale);
			}
		}

		public float Volume
		{
			get
			{
				return _volume;
			}
			set
			{
				_volume = value;
			}
		}

		public float[] WallThickness => _wallThickness;

		public static (float, float, Vector3) CalculateVolumeFromMesh(Mesh mesh)
		{
			float num = 0f;
			float num2 = 0f;
			Vector3 zero = Vector3.zero;
			Vector3[] vertices = mesh.vertices;
			int[] triangles = mesh.triangles;
			for (int i = 0; i < triangles.Length; i += 3)
			{
				Vector3 vector = vertices[triangles[i]];
				Vector3 vector2 = vertices[triangles[i + 1]];
				Vector3 vector3 = vertices[triangles[i + 2]];
				float num3 = SignedTetrahedronVolume(vector, vector2, vector3);
				num += num3;
				zero += num3 * (1f / 3f) * (vector + vector2 + vector3);
				Vector3 normalized = Vector3.Cross(vector2 - vector, vector3 - vector).normalized;
				if (Math.Abs(Vector3.Dot(normalized, vector)) > 0.015f)
				{
					normalized *= 0.015f;
					num2 += SignedTetrahedronVolume(vector - normalized, vector2 - normalized, vector3 - normalized);
				}
			}
			return (num, num2, (num > 0f) ? (zero / num) : Vector3.zero);
		}

		private static float SignedTetrahedronVolume(Vector3 p1, Vector3 p2, Vector3 p3)
		{
			float num = p1.x * p2.y * p3.z;
			float num2 = p2.x * p3.y * p1.z;
			float num3 = p3.x * p1.y * p2.z;
			float num4 = p1.x * p3.y * p2.z;
			float num5 = p2.x * p1.y * p3.z;
			float num6 = p3.x * p2.y * p1.z;
			return (num + num2 + num3 - num4 - num5 - num6) * (1f / 6f);
		}

		public Vector3 CalculateCoM()
		{
			float num = Mathf.Abs(TopScale.x * TopScale.y) * (1f - 0.5f * Deformations.x) * Mathf.Lerp(4f, MathF.PI, Mathf.Clamp01((_cornerRadiuses[0] + _cornerRadiuses[1] + _cornerRadiuses[2] + _cornerRadiuses[3]) * 0.25f));
			float num2 = Mathf.Abs(BottomScale.x * BottomScale.y) * (1f - 0.5f * Deformations.z) * Mathf.Lerp(4f, MathF.PI, Mathf.Clamp01((_cornerRadiuses[4] + _cornerRadiuses[5] + _cornerRadiuses[6] + _cornerRadiuses[7]) * 0.25f));
			float num3 = ((!(num > num2)) ? ((num2 > 0f) ? (num / num2) : 0f) : ((num > 0f) ? (num2 / num) : 0f));
			float num4 = (((num > num2) ? 0.4f : (-0.4f)) - 0.3f * Deformations.y) * Mathf.Abs(Offset.y) * (1f - num3);
			Vector2 vector = new Vector2(Offset.x, Offset.z);
			Vector2 b = vector + TopScale * (new Vector2(-1f, 1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[0])) + new Vector2(1f, 1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[1])) + (1f - 0.7f * Deformations.y) * (1f - 0.8f * Deformations.x) * (new Vector2(1f, -1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[2])) + new Vector2(-1f, -1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[3]))));
			vector = Vector2.Lerp(-vector + BottomScale * (new Vector2(-1f, 1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[4])) + new Vector2(1f, 1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[5])) + (new Vector2(1f, -1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[6])) + new Vector2(-1f, -1f) * (0.35f + 0.15f * (1f - _cornerRadiuses[7]))) * (1f - 0.7f * Deformations.z)), b, num4 + 0.5f);
			return new Vector3(vector.x, num4, vector.y);
		}

		public void DesignStart()
		{
			FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
			if (modifier != null)
			{
				modifier.FuelTypeChanged += OnFuelTypeChanged;
			}
		}

		public void OnDesignerCraftStructureChanged()
		{
			_designerPartProperties?.GetProperty(this, "_fuelPercentage")?.RefreshUI();
		}

		public override void OnDesignerPullout(string designerPartName, Assembly assembly, bool skipStartPartScale)
		{
			if (Game.Instance.GameState.Validator.IsCareerMode && !skipStartPartScale)
			{
				float initialPartScale = Game.Instance.GameState.Validator.GetInitialPartScale(IGameStateValidator.InitialPartScaleType.Fuselage);
				Offset *= initialPartScale;
				BottomScale *= initialPartScale;
				TopScale *= initialPartScale;
				base.Script?.UpdateMeshes();
			}
		}

		public void UpdateVolume()
		{
			Volume = CalculateVolume(0f);
			InnerVolume = CalculateVolume(0.0075f);
			base.Part.Config.CenterOfMass = CalculateCoM();
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnVisibilityRequested(() => _fuelPercentage, (bool x) => base.Part.GetModifier<FuelTankData>() != null);
			d.OnVisibilityRequested(() => _deadWeightPercentage, (bool x) => _deadWeightPercentage > -2f);
			d.OnValueLabelRequested(() => _fuelPercentage, (float x) => GetDesignerFuelLabel());
			d.OnValueLabelRequested(() => _deadWeightPercentage, (float x) => Units.GetMassString(_deadWeight * 0.01f));
			d.OnPropertyChanged(() => _deadWeightPercentage, delegate
			{
				OnDeadWeightChanged();
			});
			d.OnPropertyChanged(() => _fuelPercentage, delegate
			{
				OnFuelPercentageChanged();
			});
			d.OnPropertyChanged(() => _flattenNormals, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.QueueDesignerMeshUpdate();
			});
			d.OnPartStyleChanged(delegate
			{
				base.Script.QueueDesignerMeshUpdate();
			});
			d.OnPartTextureStyleChanged(delegate
			{
				base.Script.QueueDesignerMeshUpdate();
			});
			_designerPartProperties = d;
		}

		private static float FrustumVolume(float height, float radiusTopA, float radiusTopB, float radiusBottomA, float radiusBottomB, float topSquareness, float bottomSquareness, float slant, float pinch)
		{
			height = Mathf.Max(height, 0f);
			radiusTopA = Mathf.Max(radiusTopA, 0f);
			radiusBottomA = Mathf.Max(radiusBottomA, 0f);
			radiusTopB = Mathf.Max(radiusTopB, 0f);
			radiusBottomB = Mathf.Max(radiusBottomB, 0f);
			float num = Mathf.Lerp(MathF.PI, 4f, topSquareness) * radiusTopA * radiusTopB;
			float num2 = Mathf.Lerp(MathF.PI, 4f, bottomSquareness) * radiusBottomA * radiusBottomB;
			return (1f - 0.5f * slant) * (1f - 0.5f * pinch) * height * (num + num2 + Mathf.Sqrt(num * num2)) / 3f;
		}

		private float CalculateVolume(float shellThickness)
		{
			float topSquareness = 1f - Mathf.Clamp01((_cornerRadiuses[0] + _cornerRadiuses[1] + _cornerRadiuses[2] + _cornerRadiuses[3]) * 0.25f);
			float bottomSquareness = 1f - Mathf.Clamp01((_cornerRadiuses[4] + _cornerRadiuses[5] + _cornerRadiuses[6] + _cornerRadiuses[7]) * 0.25f);
			return FrustumVolume(2f * (Mathf.Abs(Offset.y) - shellThickness), TopScale.x - shellThickness, TopScale.y - shellThickness, BottomScale.x - shellThickness, BottomScale.y - shellThickness, topSquareness, bottomSquareness, Deformations.y, 0.5f * (Deformations.x + Deformations.z));
		}

		private Vector2 ClampScale(Vector2 scale, Vector2 otherScale)
		{
			if (otherScale.x <= 0f && scale.x < 0.01f)
			{
				scale.x = 0.01f;
			}
			if (otherScale.y <= 0f && scale.y < 0.01f)
			{
				scale.y = 0.01f;
			}
			return scale;
		}

		private string GetDesignerFuelLabel()
		{
			FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
			if (modifier != null)
			{
				return FuelTankScript.GetAmountLabel(modifier.Script, _fuelPercentage);
			}
			return string.Empty;
		}

		private void OnDeadWeightChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.UpdateFuel();
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}

		private void OnFuelPercentageChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.UpdateFuel();
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}

		private void OnFuelTypeChanged(FuelTankData fuelTank)
		{
			base.Script.UpdateFuel();
		}
	}
}
