using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Fuselage")]
	public class FuselageData : PartModifierData, IFuselageData
	{
		public enum FuselageColliderType
		{
			Auto = 0,
			Basic = 1,
			ConvexMesh = 2,
			NonConvexMesh = 3
		}

		public struct FillParameters : IEquatable<FillParameters>
		{
			public static readonly FillParameters Full = new FillParameters
			{
				Top = 1f,
				Bottom = 1f,
				Left = 1f,
				Right = 1f
			};

			public float Bottom;

			public float Left;

			public float Right;

			public float Top;

			public bool AnyCut
			{
				get
				{
					if (Mathf.Approximately(Top, 1f) && Mathf.Approximately(Bottom, 1f) && Mathf.Approximately(Left, 1f))
					{
						return !Mathf.Approximately(Right, 1f);
					}
					return true;
				}
			}

			public FillParameters(string parse)
			{
				if (!string.IsNullOrWhiteSpace(parse))
				{
					string[] array = parse.Split(',');
					if (array.Length == 4 && float.TryParse(array[0], out Top) && float.TryParse(array[1], out Bottom) && float.TryParse(array[2], out Left) && float.TryParse(array[3], out Right))
					{
						return;
					}
					if (array.Length == 1 && float.TryParse(parse, out Top))
					{
						Bottom = 1f;
						Left = 1f;
						Right = 1f;
						return;
					}
				}
				Top = 1f;
				Bottom = 1f;
				Left = 1f;
				Right = 1f;
			}

			public static bool operator !=(FillParameters a, FillParameters b)
			{
				if (a.Top == b.Top && a.Bottom == b.Bottom && a.Left == b.Left)
				{
					return a.Right != b.Right;
				}
				return true;
			}

			public static bool operator ==(FillParameters a, FillParameters b)
			{
				if (a.Top == b.Top && a.Bottom == b.Bottom && a.Left == b.Left)
				{
					return a.Right == b.Right;
				}
				return false;
			}

			public FillParameters Average(FillParameters other)
			{
				return new FillParameters
				{
					Top = (Top + other.Top) * 0.5f,
					Bottom = (Bottom + other.Bottom) * 0.5f,
					Left = (Left + other.Left) * 0.5f,
					Right = (Right + other.Right) * 0.5f
				};
			}

			public bool DeletesAll(FillParameters with)
			{
				if (!(Top + Bottom <= 1f) || !(with.Top + with.Bottom <= 1f))
				{
					if (Left + Right <= 1f)
					{
						return with.Left + with.Right <= 1f;
					}
					return false;
				}
				return true;
			}

			public override bool Equals(object obj)
			{
				if (obj is FillParameters other)
				{
					return Equals(other);
				}
				return false;
			}

			public bool Equals(FillParameters other)
			{
				if (other.Top == Top && other.Bottom == Bottom && other.Left == Left)
				{
					return other.Right == Right;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return 17 + Top.GetHashCode() * 827 + Bottom.GetHashCode() * 109 + Left.GetHashCode() * 53 + Right.GetHashCode() * 241;
			}

			public override string ToString()
			{
				return $"{Top},{Bottom},{Left},{Right}";
			}
		}

		public const float MaxDeadWeight = 453.59293f;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Buoyancy", Order = 2)]
		private float _buoyancy;

		[DesignerPropertySlider(0f, 453.59293f, 21, Label = "Dead Weight", Order = 3)]
		private float _deadWeight;

		[DesignerPropertyButton(Label = "Edit Fuselage Shape", Style = ButtonStyle.Primary, Order = 0)]
		private bool _editShape;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Fuel", Order = 1)]
		private float _fuelPercentage;

		[DesignerPropertySlider(-1f, 1f, 21, Label = "Angle", Order = 10)]
		private float _inletSlant;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Thickness", Order = 12)]
		private float _inletThicknessFront;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Trim Size", Order = 11)]
		private float _inletTrimSize;

		[DesignerPropertyToggleButton(new string[] { "Off", "On" }, Label = "Smooth Back", Order = 4)]
		private bool _smoothBack;

		[DesignerPropertyToggleButton(new string[] { "Off", "On" }, Label = "Smooth Front", Order = 4)]
		private bool _smoothFront;

		public bool AutoSizeOnConnected { get; set; }

		public float Buoyancy
		{
			get
			{
				return _buoyancy;
			}
			set
			{
				_buoyancy = value;
			}
		}

		public FuselageColliderType ColliderType { get; set; }

		public int[] CornerTypes { get; private set; }

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

		public FillParameters FillBack { get; set; } = FillParameters.Full;

		public bool FillCutFace { get; set; }

		public FillParameters FillFront { get; set; } = FillParameters.Full;

		public Vector2 FrontScale { get; set; }

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

		public float FuelVolume
		{
			get
			{
				float num = 0.25f;
				float height = Mathf.Abs(Offset.z) * 2f * num;
				float num2 = num * 0.5f;
				return FrustumVolume(height, 2f * FrontScale.x * num - num2, 2f * FrontScale.y * num - num2, 2f * RearScale.x * num - num2, 2f * RearScale.y * num - num2);
			}
		}

		public FuselageType FuselageType { get; set; }

		public float InletSlant
		{
			get
			{
				return _inletSlant;
			}
			set
			{
				_inletSlant = value;
			}
		}

		public float InletThicknessFront
		{
			get
			{
				return _inletThicknessFront;
			}
			set
			{
				_inletThicknessFront = value;
			}
		}

		public float InletThicknessRear { get; set; }

		public float InletTrimSize
		{
			get
			{
				return _inletTrimSize;
			}
			set
			{
				_inletTrimSize = value;
			}
		}

		public override float Mass => base.Mass;

		public Vector3 Offset { get; set; }

		public Vector2 RearScale { get; set; }

		public FuselageScript Script { get; private set; }

		public bool SmoothBack
		{
			get
			{
				return _smoothBack;
			}
			set
			{
				_smoothBack = value;
			}
		}

		public bool SmoothFront
		{
			get
			{
				return _smoothFront;
			}
			set
			{
				_smoothFront = value;
			}
		}

		public bool UseCutting
		{
			get
			{
				if (FillFront.AnyCut || FillBack.AnyCut)
				{
					return !FillFront.DeletesAll(FillBack);
				}
				return false;
			}
		}

		public int Version { get; set; }

		public float Volume
		{
			get
			{
				float num = 0.25f;
				float height = Mathf.Abs(Offset.z) * 2f * num;
				float num2 = FrustumVolume(height, 2f * FrontScale.x * num, 2f * FrontScale.y * num, 2f * RearScale.x * num, 2f * RearScale.y * num);
				float num3 = num * 4f;
				float num4 = FrustumVolume(height, 2f * FrontScale.x * num - num3, 2f * FrontScale.y * num - num3, 2f * RearScale.x * num - num3, 2f * RearScale.y * num - num3);
				return num2 - num4;
			}
		}

		AttachPointData IFuselageData.FrontAttachPoint
		{
			get
			{
				if ((FuselageType & FuselageType.Cone) != 0)
				{
					return null;
				}
				return base.Part.AttachPoints[0];
			}
		}

		AttachPointData IFuselageData.RearAttachPoint => base.Part.AttachPoints[((FuselageType & FuselageType.Cone) == 0) ? 1 : 0];

		bool IFuselageData.IsHollow => FuselageType.HasFlag(FuselageType.Hollow);

		bool IFuselageData.IsTransparent => FuselageType.HasFlag(FuselageType.Glass);

		public event Action OnMeshRegenerated;

		public FuselageData(XElement element)
			: base(element)
		{
			CornerTypes = new int[8];
			switch (element.GetStringAttribute("type", "body"))
			{
			case "cone":
				FuselageType = FuselageType.Cone;
				break;
			case "inlet":
				FuselageType = FuselageType.Inlet;
				break;
			case "hollow":
				FuselageType = FuselageType.Hollow;
				break;
			case "glass":
				FuselageType = FuselageType.Glass;
				break;
			case "hollowglass":
				FuselageType = FuselageType.HollowGlass;
				break;
			default:
				FuselageType = FuselageType.Body;
				break;
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("version", Version));
			xElement.Add(new XAttribute("frontScale", FrontScale.ToXAttributeValue()));
			xElement.Add(new XAttribute("rearScale", RearScale.ToXAttributeValue()));
			xElement.Add(new XAttribute("offset", Offset.ToXAttributeValue()));
			xElement.Add(new XAttribute("deadWeight", DeadWeight.ToString()));
			xElement.Add(new XAttribute("buoyancy", Buoyancy.ToString()));
			xElement.Add(new XAttribute("fuelPercentage", FuelPercentage.ToString()));
			xElement.Add(new XAttribute("smoothFront", SmoothFront.ToString()));
			xElement.Add(new XAttribute("smoothBack", SmoothBack.ToString()));
			xElement.Add(new XAttribute("fillCutFace", FillCutFace));
			if (FillFront.AnyCut)
			{
				xElement.Add(new XAttribute("fillFront", FillFront));
			}
			if (FillBack.AnyCut)
			{
				xElement.Add(new XAttribute("fillBack", FillBack));
			}
			if (InletSlant != 0f)
			{
				xElement.SetAttributeValue("inletSlant", InletSlant.ToString());
			}
			if ((FuselageType & (FuselageType.Inlet | FuselageType.Hollow)) != 0)
			{
				xElement.SetAttributeValue("inletTrimSize", InletTrimSize.ToString());
				xElement.SetAttributeValue("inletThicknessFront", InletThicknessFront.ToString());
				xElement.SetAttributeValue("inletThicknessRear", InletThicknessRear.ToString());
			}
			if (!AutoSizeOnConnected)
			{
				xElement.SetAttributeValue("autoSizeOnConnected", AutoSizeOnConnected);
			}
			if (ColliderType != FuselageColliderType.Auto)
			{
				xElement.SetAttributeValue("collider", ColliderType);
			}
			string text = string.Empty;
			int[] cornerTypes = CornerTypes;
			foreach (int num in cornerTypes)
			{
				text = text + num + ",";
			}
			text = text.TrimEnd(',');
			xElement.Add(new XAttribute("cornerTypes", text));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_deadWeight")
			{
				if (sliderValue <= 0.05f)
				{
					return "None";
				}
				float num = 2.20462f * sliderValue;
				return $"{num:n0}lbs";
			}
			if (propertyName == "_fuelPercentage")
			{
				return Utilities.GetFuelPercentageString(Script.MaxFuelCapacity, sliderValue);
			}
			return Utilities.FormatPercentage(sliderValue);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_inletTrimSize")
			{
				return () => Script.IsInlet;
			}
			if (property.Member.Name == "_inletThicknessFront")
			{
				return () => Script.IsInlet || Script.IsHollow;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = parentGameObject.transform.Find("Mesh").gameObject;
			Script = gameObject.AddComponent<FuselageScript>();
			Script.Fuselage = this;
			return Script;
		}

		public override bool IsSymmetricMatch(PartModifierData otherModifier, SymmetryConfig symmetry)
		{
			if (!(otherModifier is FuselageData fuselageData))
			{
				return false;
			}
			bool flag = symmetry.Mode == SymmetryMode.Mirrored;
			if (Utilities.CompareVector2s(FrontScale, fuselageData.FrontScale, 0.001f) && Utilities.CompareVector2s(RearScale, fuselageData.RearScale, 0.001f) && Utilities.CompareFloats(Offset.x, flag ? (0f - fuselageData.Offset.x) : fuselageData.Offset.x, 0.001f) && Utilities.CompareFloats(Offset.y, fuselageData.Offset.y, 0.001f) && Utilities.CompareFloats(Offset.z, fuselageData.Offset.z, 0.001f) && Utilities.CompareFloats(FillFront.Left, flag ? fuselageData.FillFront.Right : fuselageData.FillFront.Left, 0.001f) && Utilities.CompareFloats(FillFront.Right, flag ? fuselageData.FillFront.Left : fuselageData.FillFront.Right, 0.001f) && Utilities.CompareFloats(FillFront.Top, fuselageData.FillFront.Top, 0.001f) && Utilities.CompareFloats(FillFront.Bottom, fuselageData.FillFront.Bottom, 0.001f) && Utilities.CompareFloats(FillBack.Left, flag ? fuselageData.FillBack.Right : fuselageData.FillBack.Left, 0.001f) && Utilities.CompareFloats(FillBack.Right, flag ? fuselageData.FillBack.Left : fuselageData.FillBack.Right, 0.001f) && Utilities.CompareFloats(FillBack.Top, fuselageData.FillBack.Top, 0.001f) && Utilities.CompareFloats(FillBack.Bottom, fuselageData.FillBack.Bottom, 0.001f))
			{
				return Utilities.CompareFloats(InletSlant, fuselageData.InletSlant, 0.001f);
			}
			return false;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_editShape")
			{
				Designer.Instance.Tools.StartFuselageTool();
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_smoothFront":
			case "_smoothBack":
				Script.SyncNormals(updateConnected: true);
				break;
			case "_inletSlant":
			case "_inletTrimSize":
				Script.UpdateMeshes();
				break;
			case "_fuelPercentage":
			case "_deadWeight":
				Script.UpdateFuel();
				Designer.Instance.OnAircraftStructureChanged();
				break;
			case "_inletThicknessFront":
				if (Script.IsInlet)
				{
					InletThicknessRear = InletThicknessFront * 1.1f;
				}
				else
				{
					InletThicknessRear = InletThicknessFront;
				}
				Script.UpdateMeshes();
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Version = stateElement.GetIntAttribute("version", 1);
			FrontScale = stateElement.GetVector2Attribute("frontScale", Vector2.one);
			RearScale = stateElement.GetVector2Attribute("rearScale", Vector2.one);
			Offset = stateElement.GetVector3Attribute("offset", Vector3.one);
			float floatAttribute = stateElement.GetFloatAttribute("deadWeight");
			DeadWeight = Mathf.Clamp(floatAttribute, 0f, 453.59293f);
			FuelPercentage = stateElement.GetFloatAttribute("fuelPercentage");
			AutoSizeOnConnected = stateElement.GetBoolAttribute("autoSizeOnConnected", defaultValue: true);
			SmoothFront = stateElement.GetBoolAttribute("smoothFront");
			SmoothBack = stateElement.GetBoolAttribute("smoothBack");
			FillFront = new FillParameters((string)stateElement.Attribute("fillFront"));
			FillBack = new FillParameters((string)stateElement.Attribute("fillBack"));
			FillCutFace = stateElement.GetBoolAttribute("fillCutFace", (FuselageType & FuselageType.Glass) == 0);
			ColliderType = stateElement.GetEnumAttribute("collider", FuselageColliderType.Auto);
			InletSlant = stateElement.GetFloatAttribute("inletSlant");
			if ((FuselageType & (FuselageType.Inlet | FuselageType.Hollow)) != 0)
			{
				InletTrimSize = stateElement.GetFloatAttribute("inletTrimSize", 0.2f);
				InletThicknessFront = stateElement.GetFloatAttribute("inletThicknessFront", 0.2f);
				InletThicknessRear = stateElement.GetFloatAttribute("inletThicknessRear", 0.2f);
			}
			Buoyancy = stateElement.GetFloatAttribute("buoyancy");
			List<int> intListAttribute = stateElement.GetIntListAttribute("cornerTypes");
			for (int i = 0; i < intListAttribute.Count && i < CornerTypes.Length; i++)
			{
				CornerTypes[i] = intListAttribute[i];
			}
		}

		public bool ShapeMatches(IFuselageData other, bool thisFront, bool otherFront)
		{
			if (!(other is FuselageData fuselageData))
			{
				return false;
			}
			Quaternion rotation = ((base.Part.PartScript != null) ? base.Part.PartScript.transform.rotation : Quaternion.Euler(base.Part.Rotation));
			Quaternion quaternion = ((fuselageData.Part.PartScript != null) ? fuselageData.Part.PartScript.transform.rotation : Quaternion.Euler(fuselageData.Part.Rotation));
			Vector3 vector = Quaternion.Inverse(rotation) * (quaternion * Vector3.up);
			int num = 0;
			if (Utilities.CompareFloats(vector.x, 1f, 0.01f))
			{
				num = 1;
			}
			else if (Utilities.CompareFloats(vector.y, -1f, 0.01f))
			{
				num = 2;
			}
			else if (Utilities.CompareFloats(vector.x, -1f, 0.01f))
			{
				num = 3;
			}
			Vector2 vector2 = (otherFront ? fuselageData.FrontScale : fuselageData.RearScale);
			Vector2 vector3 = (thisFront ? FrontScale : RearScale);
			if (num == 1 || num == 3)
			{
				vector2 = new Vector2(vector2.y, vector2.x);
			}
			if (!Mathf.Approximately(vector3.x, vector2.x) || !Mathf.Approximately(vector3.y, vector2.y))
			{
				return false;
			}
			bool flag = thisFront == otherFront;
			for (int i = 0; i < 4; i++)
			{
				int num2 = (thisFront ? i : (i + 4));
				int j;
				for (j = (i - num) % 4; j < 0; j += 4)
				{
				}
				if (flag)
				{
					j = 3 - j;
				}
				if (!otherFront)
				{
					j += 4;
				}
				if (CornerTypes[num2] != fuselageData.CornerTypes[j])
				{
					return false;
				}
			}
			return true;
		}

		public void ValidateParameters()
		{
			Vector2 one = Vector2.one;
			one.x = Mathf.Clamp(FrontScale.x, 0f, 10f);
			one.y = Mathf.Clamp(FrontScale.y, 0f, 10f);
			Vector2 one2 = Vector2.one;
			one2.x = Mathf.Clamp(RearScale.x, 0f, 10f);
			one2.y = Mathf.Clamp(RearScale.y, 0f, 10f);
			if (one.x < 0.01f && one2.x < 0.01f)
			{
				one.x = 0.5f;
			}
			if (one.y < 0.01f && one2.y < 0.01f)
			{
				one.y = 0.5f;
			}
			Vector3 one3 = Vector3.one;
			one3.x = Mathf.Clamp(Offset.x, -5f, 5f);
			one3.y = Mathf.Clamp(Offset.y, -5f, 5f);
			one3.z = Mathf.Clamp(Offset.z, 0.01f, 10f);
			FrontScale = one;
			RearScale = one2;
			Offset = one3;
		}

		internal void InvokeOnMeshRegenerated()
		{
			this.OnMeshRegenerated?.Invoke();
		}

		protected override float CalculateMass()
		{
			float num = 0.125f;
			return Volume / num * 7f * 0.01f + DeadWeight * 0.01f;
		}

		private static float FrustumVolume(float height, float width1, float height1, float width2, float height2)
		{
			height = Mathf.Max(height, 0f);
			width1 = Mathf.Max(width1, 0f);
			width2 = Mathf.Max(width2, 0f);
			height1 = Mathf.Max(height1, 0f);
			height2 = Mathf.Max(height2, 0f);
			float num = height;
			float num2 = width1 * height1;
			float num3 = width2 * height2;
			return 1f / 3f * num * (num2 + num3 + Mathf.Sqrt(num2 * num3));
		}
	}
}
