using System;
using System.Collections.Generic;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class PropellerPhysics
	{
		public class BladeSegment
		{
			public float Area { get; set; }

			public float Chord { get; set; }

			public float LiftMagnitude { get; set; }

			public float Radius { get; set; }

			public float TorqueMagnitude { get; set; }

			public float TwistDeg { get; set; }

			public float Width { get; set; }
		}

		private Aerofoil _aerofoil;

		private float _bladeChord;

		private int _bladeCount;

		private float _bladeLength;

		private int _segmentCount;

		private List<BladeSegment> _segments = new List<BladeSegment>();

		public static bool LoggingEnabled => false;

		public float AverageAngleOfAttack { get; private set; }

		public float CalculatedDragTorque { get; private set; }

		public Vector3 CalculatedThrustVector { get; private set; }

		public float DragScalar { get; set; } = 1f;

		public List<BladeSegment> Segments => _segments;

		public float ThrustScalar { get; set; } = 1f;

		public void Initialize(Aerofoil aerofoil, int bladeCount, float bladeLength, float bladeChord, float twistAngleRoot, int segmentCount)
		{
			_segmentCount = segmentCount;
			_bladeCount = bladeCount;
			_aerofoil = aerofoil;
			_bladeLength = bladeLength;
			_bladeChord = bladeChord;
			_segments.Clear();
			float num = _bladeLength * 0.2f;
			float num2 = _bladeLength - num;
			float num3 = num2 / (float)_segmentCount;
			string text = string.Empty;
			if (LoggingEnabled)
			{
				text = $"Blade Radius: {_bladeLength}, segment width: {num3}, maxChord: {bladeChord}\n";
			}
			for (int i = 0; i < _segmentCount; i++)
			{
				float num4 = ((float)i + 0.5f) / (float)_segmentCount;
				float num5 = num + num4 * num2;
				float num6 = (num4 - 0.5f) * 2f;
				float num7 = Mathf.Sqrt(1f - num6 * num6);
				float num8 = bladeChord * num7;
				if (num8 < bladeChord * 0.2f)
				{
					num8 = bladeChord * 0.2f;
				}
				float twistDeg = Mathf.Lerp(twistAngleRoot, 0f, num4);
				BladeSegment bladeSegment = new BladeSegment
				{
					Radius = num5,
					Width = num3,
					Chord = num8,
					Area = num8 * num3,
					TwistDeg = twistDeg
				};
				if (LoggingEnabled)
				{
					text += $"Blade {i} => Radius: {bladeSegment.Radius:n2}, Width: {bladeSegment.Width:n2}, Chord: {bladeSegment.Chord:n2}, Area: {bladeSegment.Area:n2}, TwistDeg: {bladeSegment.TwistDeg:n2}, r_actual: {num5:n2}, r_norm: {num4:n2}, x: {num6:n3}, chordFactor: {num7:n2}, localChord: {num8:n2}\n";
				}
				_segments.Add(bladeSegment);
			}
			if (LoggingEnabled)
			{
				Debug.Log(text);
			}
		}

		public void Simulate(Vector3 aircraftVel, float rpm, float bladePitch, float density, Vector3 forward, float speedOfSound)
		{
			float num = rpm * MathF.PI / 30f;
			float num2 = Vector3.Dot(aircraftVel, forward);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			string text = string.Empty;
			if (LoggingEnabled)
			{
				text = $"RPM: {rpm:n0}, Omega: {num}, velAxial: {num2}, basePitch: {bladePitch}, density: {density}\n";
			}
			float num7 = 0f;
			for (int i = 0; i < _segments.Count; i++)
			{
				BladeSegment bladeSegment = _segments[i];
				num6 += bladeSegment.Area;
				float num8 = Mathf.Abs(num * bladeSegment.Radius);
				if (num8 < 0.1f)
				{
					num8 = 0.1f;
				}
				float num9 = num2 * num2 + num8 * num8;
				float num10 = Mathf.Atan2(num2, num8);
				float num11 = bladePitch + bladeSegment.TwistDeg;
				float num12 = (num11 * (MathF.PI / 180f) - num10) * 57.29578f;
				num5 += num12;
				float num13 = _aerofoil.CL.Evaluate(num12);
				float num14 = _aerofoil.CD.Evaluate(num12);
				float num15 = Mathf.Sqrt(num9);
				float num16 = num15 / speedOfSound;
				num7 = Mathf.Max(num7, num16);
				float num17 = 0.85f;
				if (num16 > num17)
				{
					float t = Mathf.InverseLerp(num17, 1.1f, num16);
					float num18 = Mathf.Lerp(1f, 0.3f, t);
					num13 *= num18;
					float t2 = Mathf.InverseLerp(num17, 1.25f, num16);
					float num19 = Mathf.Lerp(0f, 0.2f, t2);
					num14 += num19;
				}
				float num20 = 0.5f * density * num9 * bladeSegment.Area;
				float num21 = num13 * num20 * ThrustScalar;
				float num22 = num14 * num20 * DragScalar;
				float num23 = Mathf.Cos(num10);
				float num24 = Mathf.Sin(num10);
				float num25 = num21 * num23 - num22 * num24;
				float num26 = (num21 * num24 + num22 * num23) * bladeSegment.Radius;
				num3 += num25;
				num4 += num26;
				bladeSegment.TorqueMagnitude = num26;
				bladeSegment.LiftMagnitude = num25;
				if (LoggingEnabled)
				{
					text += $"Segment {i} => velTangent: {num8:n2}, velTotal: {num15:n2}, mach: {num16:n2}, phi_deg: {num10 * 57.29578f:n2}, theta_deg: {num11:n2}, alpha_deg: {num12:n2}, cL: {num13:n2}, cD: {num14:n2}, q_area: {num20:n2}, lift: {num21:n2}, drag: {num22:n2}, segmentThrust: {num25:n2}, segmentTorqueForce: {num26:n2}\n";
				}
			}
			float num27 = num3 * (float)_bladeCount * 1.15f;
			float num28 = num4 * (float)_bladeCount * 0.9f;
			CalculatedThrustVector = forward * (num27 * 0.01f);
			CalculatedDragTorque = num28 * 0.01f;
			AverageAngleOfAttack = num5 / (float)_segmentCount;
			if (LoggingEnabled && Time.frameCount % 30 == 0)
			{
				Debug.Log($"BET Sim | RPM: {rpm:F0} | Thrust: {num27:F0} N | Torque: {num28:F0} Nm | Avg AoA: {AverageAngleOfAttack:F1} | maxMach: {num7:n2}\n{text}");
			}
		}
	}
}
