using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	[Serializable]
	public class InputWingSlice
	{
		public const string XmlTag = "Slice";

		private bool _chordSamplesOverrode;

		private bool _colliderSamplesOverrode;

		public string Airfoil { get; set; }

		public float Bend { get; set; }

		public float BendRadiusMultiplier { get; set; }

		public int ChordSamples { get; set; }

		public int ColliderSamples { get; set; }

		public bool IsSmoothJoin { get; set; }

		public WingSlice LastDerivedSliceRoot { get; set; }

		public WingSlice LastDerivedSliceTip { get; set; }

		public float Offset { get; set; }

		public float Position { get; set; }

		public float Scale { get; set; }

		public bool UseOffset { get; set; }

		public bool UseScale { get; set; }

		public InputWingSlice()
		{
			BendRadiusMultiplier = 1f;
		}

		public InputWingSlice(XElement xml, int defaultChordSamples, int defaultColliderSamples)
		{
			LoadFromXml(xml, defaultChordSamples, defaultColliderSamples);
		}

		public static int FindSliceAtPos(IList<InputWingSlice> slices, float spanPos, out float t)
		{
			if (slices.Count < 2 || spanPos < slices[0].Position)
			{
				t = -1f;
				return -1;
			}
			for (int i = 0; i < slices.Count; i++)
			{
				_ = slices[i].Position;
				if (slices[i].ApproximatelyEqualPosition(spanPos))
				{
					t = 0f;
					return i;
				}
				if (spanPos < slices[i].Position)
				{
					t = math.unlerp(slices[i - 1].Position, slices[i].Position, spanPos);
					return i - 1;
				}
			}
			t = -1f;
			return slices.Count;
		}

		public bool ApproximatelyEqualPosition(float position)
		{
			return math.abs(position - Position) < 0.001f;
		}

		public InputWingSlice Clone()
		{
			return MemberwiseClone() as InputWingSlice;
		}

		public void LoadFromXml(XElement xml, int defaultChordSamples, int defaultColliderSamples)
		{
			Position = xml.GetFloatAttributeOrNull("position") ?? throw new ArgumentException("<Slice> element missing required float parameter position");
			Airfoil = xml.GetStringAttributeOrNullIfWhitespace("airfoil");
			IsSmoothJoin = xml.GetBoolAttribute("smoothJoin", defaultValue: true);
			float? floatAttributeOrNull = xml.GetFloatAttributeOrNull("offset");
			UseOffset = floatAttributeOrNull.HasValue;
			Offset = floatAttributeOrNull.GetValueOrDefault();
			float? floatAttributeOrNull2 = xml.GetFloatAttributeOrNull("scale");
			UseScale = floatAttributeOrNull2.HasValue;
			Scale = floatAttributeOrNull2.GetValueOrDefault();
			int? intAttributeOrNull = xml.GetIntAttributeOrNull("chordSamples");
			ChordSamples = intAttributeOrNull ?? defaultChordSamples;
			_chordSamplesOverrode = intAttributeOrNull.HasValue;
			int? intAttributeOrNull2 = xml.GetIntAttributeOrNull("colliderSamples");
			ColliderSamples = intAttributeOrNull2 ?? defaultColliderSamples;
			_colliderSamplesOverrode = intAttributeOrNull2.HasValue;
			Bend = xml.GetFloatAttribute("bend");
			BendRadiusMultiplier = xml.GetFloatAttribute("bendRadiusMultiplier", 1f);
		}

		public void SaveToXml(XElement xml)
		{
			xml.SetAttributeValue("position", DataIO.ToString(Position));
			SetAttributeIfDefined("airfoil", Airfoil);
			xml.SetAttributeValue("smoothJoin", IsSmoothJoin);
			if (UseOffset)
			{
				xml.SetAttributeValue("offset", DataIO.ToString(Offset));
			}
			if (UseScale)
			{
				xml.SetAttributeValue("scale", DataIO.ToString(Scale));
			}
			if (_chordSamplesOverrode)
			{
				xml.SetAttributeValue("chordSamples", ChordSamples);
			}
			if (_colliderSamplesOverrode)
			{
				xml.SetAttributeValue("colliderSamples", ColliderSamples);
			}
			if (Bend != 0f)
			{
				xml.SetAttributeValue("bend", DataIO.ToString(Bend));
			}
			if (BendRadiusMultiplier != 1f)
			{
				xml.SetAttributeValue("bendRadiusMultiplier", DataIO.ToString(BendRadiusMultiplier));
			}
			void SetAttributeIfDefined(string attr, object value)
			{
				if (value != null)
				{
					xml.SetAttributeValue(attr, value);
				}
			}
		}

		public WingSlice GetDerivedSlice(bool toRoot)
		{
			if (!toRoot)
			{
				return LastDerivedSliceTip;
			}
			return LastDerivedSliceRoot;
		}
	}
}
