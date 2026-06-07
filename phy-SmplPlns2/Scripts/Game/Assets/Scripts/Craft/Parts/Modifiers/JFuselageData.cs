using System;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Fuselage")]
	public class JFuselageData : PartModifierData, IFuselageData
	{
		public struct CuttingParams : IEquatable<CuttingParams>
		{
			public decimal? x;

			public decimal? y;

			public decimal? z;

			public decimal? w;

			public unsafe decimal? this[int i]
			{
				get
				{
					if (i < 0 || i > 3)
					{
						throw new IndexOutOfRangeException($"Index {i} is out of range of CuttingParams");
					}
					fixed (decimal?* ptr = &x)
					{
						return ptr[i];
					}
				}
				set
				{
					if (i < 0 || i > 3)
					{
						throw new IndexOutOfRangeException($"Index {i} is out of range of CuttingParams");
					}
					fixed (decimal?* ptr = &x)
					{
						ptr[i] = value;
					}
				}
			}

			public CuttingParams(decimal? x, decimal? y, decimal? z, decimal? w)
			{
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}

			public static explicit operator float4(CuttingParams vector)
			{
				return new float4(ToFloat(vector.x), ToFloat(vector.y), ToFloat(vector.z), ToFloat(vector.w));
			}

			public static explicit operator Vector4(CuttingParams vector)
			{
				return new Vector4(ToFloat(vector.x), ToFloat(vector.y), ToFloat(vector.z), ToFloat(vector.w));
			}

			public static explicit operator CuttingParams(Vector4 vector)
			{
				return new CuttingParams(FromFloat(vector.x), FromFloat(vector.y), FromFloat(vector.z), FromFloat(vector.w));
				static decimal? FromFloat(float v)
				{
					try
					{
						return float.IsFinite(v) ? new decimal?((decimal)v) : ((decimal?)null);
					}
					catch (OverflowException)
					{
						return null;
					}
				}
			}

			public static bool operator !=(CuttingParams lhs, CuttingParams rhs)
			{
				if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
				{
					return !(lhs.w == rhs.w);
				}
				return true;
			}

			public static bool operator ==(CuttingParams lhs, CuttingParams rhs)
			{
				if (lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z)
				{
					return lhs.w == rhs.w;
				}
				return false;
			}

			public static bool TryParse(string text, out CuttingParams result)
			{
				result = default(CuttingParams);
				if (text == null)
				{
					return false;
				}
				int num = -1;
				StringUtility.StringSplitEnumerator enumerator = StringUtility.SpanSplit(text, ',', removeEmptyEntries: false).GetEnumerator();
				while (enumerator.MoveNext())
				{
					StringUtility.StringSplitEntry current = enumerator.Current;
					decimal? value;
					if (current.Span.Length == 0)
					{
						value = null;
					}
					else
					{
						if (!decimal.TryParse(current.Span, DataIO.NumberStyleDouble, DataIO.NumberFormat, out var result2))
						{
							return false;
						}
						value = result2;
					}
					num = current.Index;
					result[num] = value;
					if (current.Index == 3)
					{
						return true;
					}
				}
				if (text.EndsWith(',') && num == 2)
				{
					result[3] = null;
					return true;
				}
				return false;
			}

			public void Mirror()
			{
				decimal? num = w;
				decimal? num2 = y;
				y = num;
				w = num2;
			}

			public override readonly string ToString()
			{
				return $"{x},{y},{z},{w}";
			}

			public override readonly bool Equals(object obj)
			{
				if (obj is CuttingParams cuttingParams)
				{
					return this == cuttingParams;
				}
				return false;
			}

			public override readonly int GetHashCode()
			{
				return HashCode.Combine(x, y, z, w);
			}

			public readonly bool Equals(CuttingParams other)
			{
				return other == this;
			}

			private static float ToFloat(decimal? value)
			{
				if (!value.HasValue)
				{
					return float.NegativeInfinity;
				}
				return (float)value.Value;
			}
		}

		private const int CurrentVersion = 3;

		private const int DefaultColliderCornerSamples = 5;

		private const int DefaultColliderCount = 8;

		private const int DefaultCornerSamples = 7;

		private const int DefaultEdgeSamples = 7;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Buoyancy", Order = 11)]
		private float _buoyancy;

		private int _colliderCornerSamples;

		private float3 _com;

		private CuttingParams _cuttingA;

		private CuttingParams _cuttingB;

		[DesignerPropertySlider(Label = "Dead Weight", MinValue = 0f, MaxValue = 500f, NumberOfSteps = 51, Order = 10)]
		private float _deadMassKg;

		private float _defaultThicknessFront;

		private float _defaultThicknessRear;

		[DesignerPropertyButton(Label = "Edit Fuselage Shape", Style = ButtonStyle.Primary, Order = 0)]
		private bool _editButton;

		private float _fuelCapacity;

		[DesignerPropertySlider(Label = "Fuel", MinValue = 0f, MaxValue = 1f, NumberOfSteps = 51, Order = 9)]
		private float _fuelProportion;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Glass", Order = 99)]
		private bool _isGlass;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Hollow", Order = 98)]
		private bool _isHollow;

		private bool _legacyThickness;

		private float _mass;

		private float _noseconeRoundness;

		private int _numColliders;

		private Vector3 _offset;

		private FuselageColliderType? _overrideColliderType;

		private SectionParams _sectionA;

		private SectionParams _sectionB;

		private bool _smoothingA = true;

		private bool _smoothingB = true;

		private FuselageStyle _style;

		private bool _syncSliceA;

		private bool _syncSliceB;

		public bool AutoResizeOnConnected { get; set; }

		public float Buoyancy => _buoyancy;

		public bool BuoyancyPermitted
		{
			get
			{
				if (!OverrideColliderType.HasValue)
				{
					return !IsHollow;
				}
				return OverrideColliderType != FuselageColliderType.ConvexSegments;
			}
		}

		public int ColliderCornerSamples
		{
			get
			{
				return _colliderCornerSamples;
			}
			set
			{
				_colliderCornerSamples = value;
				RaiseChange();
			}
		}

		public override Vector3 CoM => _com;

		AttachPointData IFuselageData.FrontAttachPoint => GetAttachPoint(1);

		public float FuelCapacity => _fuelCapacity;

		public float FuelProportion => _fuelProportion;

		public bool IsCone
		{
			get
			{
				if (Style != FuselageStyle.Cone)
				{
					return Style == FuselageStyle.HollowCone;
				}
				return true;
			}
		}

		public bool IsHollow
		{
			get
			{
				if (Style != FuselageStyle.Hollow)
				{
					return Style == FuselageStyle.HollowCone;
				}
				return true;
			}
		}

		public bool IsTransparent => _isGlass;

		public JFuselageScript JFuselageScript { get; private set; }

		public override float Mass => _mass + _deadMassKg * 0.01f;

		public float NoseconeRoundness
		{
			get
			{
				return _noseconeRoundness;
			}
			set
			{
				_noseconeRoundness = value;
				RaiseChange();
			}
		}

		public int NumColliders
		{
			get
			{
				return _numColliders;
			}
			set
			{
				_numColliders = Math.Clamp(value, 3, 16);
				RaiseChange();
			}
		}

		public int NumSections => 2;

		public Vector3 Offset
		{
			get
			{
				return _offset;
			}
			set
			{
				_offset = value;
				RaiseChange();
			}
		}

		public FuselageColliderType? OverrideColliderType
		{
			get
			{
				return _overrideColliderType;
			}
			set
			{
				_overrideColliderType = value;
				RaiseChange();
			}
		}

		AttachPointData IFuselageData.RearAttachPoint => GetAttachPoint(0);

		public SectionParams SectionA
		{
			get
			{
				return _sectionA;
			}
			set
			{
				_sectionA = value;
				RaiseChange();
			}
		}

		public SectionParams SectionB
		{
			get
			{
				return _sectionB;
			}
			set
			{
				_sectionB = value;
				RaiseChange();
			}
		}

		public FuselageStyle Style
		{
			get
			{
				return _style;
			}
			set
			{
				_style = value;
				RaiseChange();
			}
		}

		public bool SupportsThickness => StyleHasThickness(Style);

		public SectionParams this[int index]
		{
			get
			{
				return index switch
				{
					0 => _sectionA, 
					1 => _sectionB, 
					_ => throw new IndexOutOfRangeException(), 
				};
			}
			set
			{
				switch (index)
				{
				case 0:
					_sectionA = value;
					break;
				case 1:
					_sectionB = value;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
				RaiseChange();
			}
		}

		public event Action<int> OnCuttingDataChanged;

		public event Action<float> OnFuelProportionChanged;

		public event Action<bool> OnGlassStateChanged;

		public event Action OnMeshRegenerated;

		public event Action<float4[]> OnMinCuttingUpdated;

		public event Action OnShapeDataChanged;

		public event Action<int> OnSmoothingDataChanged;

		public JFuselageData(XElement element)
			: base(element)
		{
			_defaultThicknessFront = element.GetFloatAttribute("defaultThicknessFront", 0.1f);
			_defaultThicknessRear = element.GetFloatAttribute("defaultThicknessRear", 0.1f);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("version", 3);
			xElement.SetAttribute("offset", Offset);
			xElement.SetAttributeValue("style", Style);
			xElement.SetAttributeValue("glass", IsTransparent);
			xElement.SetAttribute("mass", new Vector4(_com.x, _com.y, _com.z, _mass));
			xElement.SetAttributeValue("deadMassKg", DataIO.ToString(_deadMassKg));
			xElement.SetAttributeValue("buoyancy", DataIO.ToString(_buoyancy));
			xElement.SetAttributeValue("fuelProportion", DataIO.ToString(_fuelProportion));
			if (_legacyThickness)
			{
				xElement.SetAttributeValue("legacyThickness", true);
			}
			xElement.Add(NumColliders.ToXAttributeOrNull("numColliders", 8));
			xElement.Add(ColliderCornerSamples.ToXAttributeOrNull("colliderCornerSamples", 5));
			xElement.Add(SerializeSection(SectionA, "SectionA", Style, _smoothingA, _cuttingA, _syncSliceA));
			xElement.Add(SerializeSection(SectionB, "SectionB", Style, _smoothingB, _cuttingB, _syncSliceB));
			if (OverrideColliderType.HasValue)
			{
				xElement.SetAttributeValue("colliderType", OverrideColliderType.Value);
			}
			if (IsCone)
			{
				xElement.SetAttributeValue("noseconeRoundness", _noseconeRoundness);
			}
			if (AutoResizeOnConnected)
			{
				xElement.SetAttributeValue("autoResize", true);
			}
			return xElement;
		}

		public AttachPointData GetAttachPoint(int sliceIndex)
		{
			if (IsCone && sliceIndex == 1)
			{
				return null;
			}
			int? num = sliceIndex switch
			{
				0 => 0, 
				1 => 1, 
				_ => null, 
			};
			if (!num.HasValue)
			{
				return null;
			}
			return base.Part.AttachPoints[num.Value];
		}

		public CuttingParams GetCutting(int index)
		{
			return index switch
			{
				0 => _cuttingA, 
				1 => _cuttingB, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public bool GetEndAttachPoints(int sectionIndex, out AttachPointData back, out AttachPointData front)
		{
			if (sectionIndex == 0)
			{
				back = base.Part.AttachPoints[0];
				if (IsCone)
				{
					front = null;
				}
				else
				{
					front = base.Part.AttachPoints[1];
				}
				return true;
			}
			front = null;
			back = null;
			return false;
		}

		public int GetEndSlice(bool front)
		{
			if (!front)
			{
				return 0;
			}
			return 1;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return propertyName switch
			{
				"_deadMassKg" => sliderValue.Format(UnitType.Mass), 
				"_fuelProportion" => $"{sliderValue:P0} ({(sliderValue * _fuelCapacity).Format(UnitType.Volume)})", 
				"_buoyancy" => sliderValue.ToString("P0"), 
				_ => base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue), 
			};
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			switch (property.Member.Name)
			{
			case "_isHollow":
			case "_isGlass":
				return () => true;
			case "_fuelProportion":
				return () => _fuelCapacity > 0f;
			case "_buoyancy":
				return () => BuoyancyPermitted;
			default:
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
		}

		public int? GetSliceIndex(AttachPointData attachPoint)
		{
			return base.Part.AttachPoints.IndexOf(attachPoint) switch
			{
				0 => 0, 
				1 => 1, 
				_ => null, 
			};
		}

		public ref SectionParams GetSliceRefUntracked(int index)
		{
			return index switch
			{
				0 => ref _sectionA, 
				1 => ref _sectionB, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public bool GetSmoothing(int index)
		{
			return index switch
			{
				0 => _smoothingA, 
				1 => _smoothingB, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			JFuselageScript jFuselageScript = parentGameObject.AddComponent<JFuselageScript>();
			jFuselageScript.Init(this, partCreationInfo);
			JFuselageScript = jFuselageScript;
			return jFuselageScript;
		}

		public override bool IsSymmetricMatch(PartModifierData otherModifier, SymmetryConfig symmetry)
		{
			if (otherModifier is JFuselageData jFuselageData && NumSections == jFuselageData.NumSections && Style == jFuselageData.Style)
			{
				bool flag = true;
				for (int i = 0; i < NumSections; i++)
				{
					SectionParams sectionParams = this[i];
					SectionParams sectionParams2 = jFuselageData[i];
					CuttingParams cutting = GetCutting(i);
					CuttingParams cutting2 = jFuselageData.GetCutting(i);
					ref decimal? y = ref cutting2.y;
					ref decimal? w = ref cutting2.w;
					decimal? w2 = cutting2.w;
					decimal? y2 = cutting2.y;
					y = w2;
					w = y2;
					flag &= sectionParams.Size.x == sectionParams2.Size.x && sectionParams.Size.y == sectionParams2.Size.y && cutting == cutting2;
				}
				return flag;
			}
			return false;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_editButton")
			{
				Designer.Instance.Tools.SelectTool(Designer.Instance.Tools.JFuselageTool);
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_isHollow" && Style != FuselageStyle.Inlet)
			{
				Style = ((!_isHollow) ? (IsCone ? FuselageStyle.Cone : FuselageStyle.Body) : ((!IsCone) ? FuselageStyle.Hollow : FuselageStyle.HollowCone));
			}
			else if (propertyName == "_isGlass")
			{
				this.OnGlassStateChanged?.Invoke(_isGlass);
			}
			else if (propertyName == "_deadMassKg" && Designer.Instance != null)
			{
				Designer.Instance.SetAircraftStructureChanged();
			}
			else if (propertyName == "_fuelProportion")
			{
				this.OnFuelProportionChanged?.Invoke(_fuelProportion);
			}
		}

		public void OnMeshGenerated(float4 volume, float4 area, bool isInit, float fuelCapacity)
		{
			float4 float5 = 20f * volume + 0.1f * area;
			_mass = float5.w * 0.01f;
			_com = float5.xyz / float5.w;
			_fuelCapacity = fuelCapacity;
			if (!isInit)
			{
				this.OnMeshRegenerated?.Invoke();
			}
		}

		public void RaiseChange()
		{
			this.OnShapeDataChanged?.Invoke();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			float4 float5 = stateElement.GetVector4Attribute("mass");
			int intAttribute = stateElement.GetIntAttribute("version", 1);
			int defaultValue = ((intAttribute < 3) ? 4 : 8);
			_legacyThickness = stateElement.GetBoolAttribute("legacyThickness", intAttribute < 3);
			_com = float5.xyz;
			_mass = float5.w;
			Offset = stateElement.GetVector3Attribute("offset", new Vector3(0f, 0f, 1f));
			if (math.any(math.isnan(Offset)))
			{
				Offset = new Vector3(0f, 0f, 1f);
			}
			Style = stateElement.GetEnumAttribute("style", FuselageStyle.Body);
			_isHollow = _style == FuselageStyle.Hollow || _style == FuselageStyle.HollowCone;
			_isGlass = stateElement.GetBoolAttribute("glass");
			OverrideColliderType = stateElement.GetEnumAttributeOrNull<FuselageColliderType>("colliderType");
			NumColliders = stateElement.GetIntAttribute("numColliders", defaultValue);
			_deadMassKg = stateElement.GetFloatAttribute("deadMassKg");
			_fuelProportion = stateElement.GetFloatAttribute("fuelProportion");
			_buoyancy = stateElement.GetFloatAttribute("buoyancy");
			ColliderCornerSamples = stateElement.GetIntAttribute("colliderCornerSamples", 5);
			AutoResizeOnConnected = stateElement.GetBoolAttribute("autoResize");
			SectionA = DeserailizeSection(stateElement.Element("SectionA"), _defaultThicknessRear, intAttribute, out _smoothingA, out _cuttingA, out _syncSliceA, _legacyThickness);
			SectionB = DeserailizeSection(stateElement.Element("SectionB"), _defaultThicknessFront, intAttribute, out _smoothingB, out _cuttingB, out _syncSliceB, _legacyThickness);
			if (IsCone)
			{
				_noseconeRoundness = stateElement.GetFloatAttribute("noseconeRoundness", 0.5f);
			}
			RaiseChange();
		}

		public void SetCutting(int index, CuttingParams cutting)
		{
			ref CuttingParams reference = ref GetRef();
			if (reference != cutting)
			{
				reference = cutting;
				this.OnCuttingDataChanged?.Invoke(index);
			}
			ref CuttingParams GetRef()
			{
				return index switch
				{
					0 => ref _cuttingA, 
					1 => ref _cuttingB, 
					_ => throw new IndexOutOfRangeException(), 
				};
			}
		}

		public void SetSmoothing(int index, bool enabled)
		{
			ref bool reference = ref GetRef();
			if (reference != enabled)
			{
				reference = enabled;
				this.OnSmoothingDataChanged?.Invoke(index);
			}
			ref bool GetRef()
			{
				return index switch
				{
					0 => ref _smoothingA, 
					1 => ref _smoothingB, 
					_ => throw new IndexOutOfRangeException(), 
				};
			}
		}

		public bool ShapeMatches(JFuselageData other, int thisIndex, int otherIndex)
		{
			SectionParams sliceRefUntracked = GetSliceRefUntracked(thisIndex);
			SectionParams sliceRefUntracked2 = other.GetSliceRefUntracked(otherIndex);
			CuttingParams cutting = GetCutting(thisIndex);
			CuttingParams cutting2 = other.GetCutting(otherIndex);
			bool supportsThickness = SupportsThickness;
			bool supportsThickness2 = other.SupportsThickness;
			if (SliceIsFront(thisIndex) == other.SliceIsFront(otherIndex))
			{
				sliceRefUntracked2.Mirror();
				cutting2.Mirror();
			}
			if (Approx(sliceRefUntracked.Size, sliceRefUntracked2.Size) && math.all(sliceRefUntracked.CornersStretch == sliceRefUntracked2.CornersStretch) && Approx4(sliceRefUntracked.CornerRadii, sliceRefUntracked2.CornerRadii) && Approx4(sliceRefUntracked.EdgeCurvature, sliceRefUntracked2.EdgeCurvature) && cutting == cutting2 && Mathf.Approximately(sliceRefUntracked.Trapezium, sliceRefUntracked2.Trapezium) && supportsThickness == supportsThickness2)
			{
				if (supportsThickness)
				{
					return Mathf.Approximately(sliceRefUntracked.Thickness, sliceRefUntracked2.Thickness);
				}
				return true;
			}
			return false;
			static bool Approx(float2 a, float2 b)
			{
				return math.all(math.abs(b - a) < math.max(1E-06f * math.max(math.abs(a), math.abs(b)), 1.1E-44f));
			}
			static bool Approx4(float4 a, float4 b)
			{
				return math.all(math.abs(b - a) < math.max(1E-06f * math.max(math.abs(a), math.abs(b)), 1.1E-44f));
			}
		}

		bool IFuselageData.ShapeMatches(IFuselageData otherPart, bool thisFront, bool otherFront)
		{
			if (!(otherPart is JFuselageData jFuselageData))
			{
				return false;
			}
			return ShapeMatches(jFuselageData, GetEndSlice(thisFront), jFuselageData.GetEndSlice(otherFront));
		}

		public bool SliceIsFront(int index)
		{
			return index != 0;
		}

		public Pose GetLocalSlicePose(int slice)
		{
			return slice switch
			{
				0 => new Pose(_offset * -0.5f, Quaternion.identity), 
				1 => new Pose(_offset * 0.5f, Quaternion.identity), 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public void AlignToSlice(int sliceIndex, JFuselageData targetFuselage, int targetSlice, bool tryMoveSliceOnly = false)
		{
			bool num = SliceIsFront(sliceIndex) == targetFuselage.SliceIsFront(targetSlice);
			Pose parent = targetFuselage.Part.GetPartPose().TransformPose(targetFuselage.GetLocalSlicePose(targetSlice));
			if (num)
			{
				parent.rotation *= Quaternion.AngleAxis(180f, Vector3.up);
			}
			Pose localSlicePose = GetLocalSlicePose(sliceIndex);
			Pose pose = parent.TransformPose(localSlicePose.Inverse());
			if (tryMoveSliceOnly)
			{
				Pose partPose = base.Part.GetPartPose();
				if (Vector3.Dot(partPose.forward, pose.forward) > 0.99f)
				{
					float num2 = (SliceIsFront(sliceIndex) ? (-1f) : 1f);
					Vector3 point = _offset * (0.5f * num2);
					Vector3 vector = partPose.TransformPoint(point) - pose.TransformPoint(point);
					Vector3 vector2 = Quaternion.Inverse(pose.rotation) * vector;
					pose.position += vector * 0.5f;
					Offset += vector2 * num2;
				}
			}
			base.Part.SetPartPose(pose);
		}

		public bool SliceSupportsThickness(int index)
		{
			if (SupportsThickness)
			{
				if (Style == FuselageStyle.HollowCone)
				{
					return index == 0;
				}
				return true;
			}
			return false;
		}

		public ref bool SyncSlice(int sliceIndex)
		{
			return sliceIndex switch
			{
				0 => ref _syncSliceA, 
				1 => ref _syncSliceB, 
				_ => throw new IndexOutOfRangeException(), 
			};
		}

		public bool TryGetNeighbour(int sliceIndex, out JFuselageData neighbourFuselage, out int neighbourSliceIndex)
		{
			neighbourFuselage = null;
			neighbourSliceIndex = 0;
			int index = sliceIndex switch
			{
				0 => 0, 
				1 => 1, 
				_ => throw new IndexOutOfRangeException(), 
			};
			AttachPointData attachPointData = base.Part.AttachPoints[index];
			foreach (PartConnection partConnection in attachPointData.PartConnections)
			{
				if (partConnection.GetOtherPart(base.Part).TryGetModifier<JFuselageData>(out var result))
				{
					AttachPointData otherAttachPoint = partConnection.GetOtherAttachPoint(attachPointData);
					int? sliceIndex2 = result.GetSliceIndex(otherAttachPoint);
					if (sliceIndex2.HasValue)
					{
						neighbourFuselage = result;
						neighbourSliceIndex = sliceIndex2.Value;
						return true;
					}
				}
			}
			return false;
		}

		internal void InvokeOnUpdateMinCutting(float4[] minCutting)
		{
			this.OnMinCuttingUpdated?.Invoke(minCutting);
		}

		protected override float CalculateMass()
		{
			return _mass * (_deadMassKg * 0.01f);
		}

		private static bool CanGenerateMultiColliders(FuselageStyle style, FuselageColliderType colliderType)
		{
			if (StyleHasThickness(style))
			{
				return colliderType == FuselageColliderType.ConvexSegments;
			}
			return false;
		}

		private static SectionParams DeserailizeSection(XElement xml, float defaultThickness, int version, out bool enableSmoothing, out CuttingParams cutting, out bool syncSlices, bool legacyThickness)
		{
			enableSmoothing = xml.GetBoolAttribute("smoothing", defaultValue: true);
			if (version < 2)
			{
				cutting = (CuttingParams)xml.GetVector4Attribute("cutting", new Vector4(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity));
			}
			else if (!CuttingParams.TryParse((string)xml.Attribute("cutting"), out cutting))
			{
				cutting = default(CuttingParams);
			}
			syncSlices = xml.GetBoolAttribute("syncSlices", defaultValue: true);
			SectionParams result = new SectionParams
			{
				Size = xml.GetVector2Attribute("size", new Vector2(1f, 1f)),
				CornerRadii = xml.GetVector4Attribute("cornerRadii", Vector4.one),
				CornersStretch = (float4)xml.GetBool4Attribute("cornerStretch"),
				CornerSamples = xml.GetInt4Attribute("cornerSamples", 7),
				Thickness = xml.GetFloatAttribute("thickness", defaultThickness),
				EdgeCurvature = xml.GetVector4Attribute("edgeCurvature", Vector4.zero),
				EdgeSamples = xml.GetInt4Attribute("edgeSamples", 7),
				Trapezium = xml.GetFloatAttribute("trapezium"),
				AbsoluteThickness = !legacyThickness
			};
			if (math.any(result.Size <= 0f))
			{
				result.Size = math.select(result.Size, 0f, result.Size <= 0f);
				result.EdgeCurvature = 0f;
			}
			return result;
		}

		private static XElement SerializeSection(in SectionParams section, XName name, FuselageStyle style, bool enableSmoothing, CuttingParams cutting, bool syncSlices)
		{
			XElement xElement = new XElement(name);
			xElement.SetAttribute("size", section.Size);
			xElement.SetAttribute("cornerRadii", section.CornerRadii);
			xElement.SetAttribute("cornerStretch", section.CornersStretch > 0.5f);
			xElement.SetAttribute("cornerSamples", section.CornerSamples);
			xElement.SetAttributeValue("trapezium", section.Trapezium);
			xElement.SetAttribute("edgeCurvature", section.EdgeCurvature);
			xElement.SetAttribute("edgeSamples", section.EdgeSamples);
			xElement.SetAttribute("smoothing", enableSmoothing);
			xElement.SetAttributeValue("cutting", cutting.ToString());
			if (StyleHasThickness(style))
			{
				xElement.SetAttributeValue("thickness", section.Thickness);
			}
			if (!syncSlices)
			{
				xElement.SetAttributeValue("syncSlices", false);
			}
			return xElement;
		}

		private static bool StyleHasThickness(FuselageStyle style)
		{
			if (style != FuselageStyle.Hollow && style != FuselageStyle.Inlet)
			{
				return style == FuselageStyle.HollowCone;
			}
			return true;
		}
	}
}
