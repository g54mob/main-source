using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class RocketEngineMath
	{
		public class DynamicPerformance
		{
			public double AirPressure { get; internal set; }

			public double ExhaustVelocity { get; set; }

			public double ExitArea { get; set; }

			public double ExitMachNumber { get; set; }

			public double ExitPressure { get; set; }

			public double Power => 0.5 * ThrustNet * ExhaustVelocity;

			public double ThrustCore { get; set; }

			public double ThrustNet { get; set; }

			public float ThrustNetScaled => (float)ThrustNet * 0.01f;

			public double ThrustPower => ThrustNet * ExhaustVelocity * 0.5;

			public double ThrustPressure { get; set; }
		}

		public class Inputs
		{
			public float AltitudeCompensation { get; set; }

			public float ChamberPressure { get; set; }

			public float ChamberTemperature { get; set; }

			public float Efficiency { get; set; }

			public float ExitArea { get; set; }

			public float ExitRadius => Mathf.Sqrt(ExitArea / MathF.PI);

			public float FuelMolecularWeight { get; set; }

			public float FuelSpecificHeatRatio { get; set; }

			public float ThroatArea { get; set; }

			public float ThroatRadius => Mathf.Sqrt(ThroatArea / MathF.PI);
		}

		public class Params
		{
			public DynamicPerformance Dynamic { get; private set; }

			public Inputs Inputs { get; private set; }

			public StaticPerformance Static { get; private set; }

			public Params()
			{
				Inputs = new Inputs();
				Static = new StaticPerformance();
				Dynamic = new DynamicPerformance();
			}

			public override string ToString()
			{
				Inputs inputs = Inputs;
				StaticPerformance staticPerformance = Static;
				DynamicPerformance dynamic = Dynamic;
				return $"Mass Flow: {staticPerformance.MassFlow:n2}kg/s, Chamber Pressure: {inputs.ChamberPressure / 1000f:n2}kPa, Mach Number: {dynamic.ExitMachNumber:n2}, Exhaust Velocity: {dynamic.ExhaustVelocity:n2}m/s, Air Pressure: {dynamic.AirPressure / 1000.0:n2}kPa, Exit Pressure: {dynamic.ExitPressure / 1000.0:n2}kPa, Core Thrust: {dynamic.ThrustCore / 1000.0:n2}kN, Pressure Thrust: {dynamic.ThrustPressure / 1000.0:n2}kN, Nozzle Area: {inputs.ThroatArea:n2}m2, Exit Area: {dynamic.ExitArea:n2}m2,Throat Radius: {inputs.ThroatRadius:n4}m Exit Radius: {inputs.ExitRadius:n4}m ";
			}
		}

		public class StaticPerformance
		{
			public double MassFlow { get; set; }

			public double NormalizedMassFlow { get; set; }
		}

		private const double R = 8314.46;

		public static void CalculateDynamicPerformance(Params p, double airPressure)
		{
			Inputs inputs = p.Inputs;
			StaticPerformance staticPerformance = p.Static;
			DynamicPerformance dynamic = p.Dynamic;
			if (inputs.AltitudeCompensation > 0f)
			{
				dynamic.ExitPressure = Mathd.Lerp(inputs.ChamberPressure, airPressure, inputs.AltitudeCompensation);
				if (dynamic.ExitPressure < 0.009999999776482582)
				{
					dynamic.ExitPressure = 0.009999999776482582;
				}
				dynamic.ExitMachNumber = CalculateNozzleExitMachNumberFromPressure(inputs.ChamberPressure, dynamic.ExitPressure, inputs.FuelSpecificHeatRatio);
				dynamic.ExitArea = CalculateNozzleExitArea(dynamic.ExitMachNumber, inputs.ThroatArea, inputs.FuelSpecificHeatRatio);
				dynamic.ExhaustVelocity = CalculateExhaustVelocity(inputs.ChamberPressure, dynamic.ExitPressure, inputs.ChamberTemperature, inputs.FuelMolecularWeight, inputs.FuelSpecificHeatRatio) * (double)inputs.Efficiency;
			}
			dynamic.ThrustCore = staticPerformance.MassFlow * dynamic.ExhaustVelocity;
			dynamic.ThrustPressure = (dynamic.ExitPressure - airPressure) * dynamic.ExitArea;
			double num = (0.0 - dynamic.ThrustCore) * 0.949999988079071;
			if (dynamic.ThrustPressure < num)
			{
				dynamic.ThrustPressure = num;
			}
			dynamic.ThrustNet = dynamic.ThrustCore + dynamic.ThrustPressure;
			dynamic.AirPressure = airPressure;
		}

		public static double CalculateExhaustVelocity(double pc, double pe, double tc, double m, double k)
		{
			if (pe > pc)
			{
				pe = pc;
			}
			return Math.Sqrt(2.0 * k / (k - 1.0) * (8314.46 * tc / m) * (1.0 - Math.Pow(pe / pc, (k - 1.0) / k)));
		}

		public static double CalculateExitPressure(double pc, double nm, double k)
		{
			return pc * Math.Pow(1.0 + (k - 1.0) / 2.0 * nm * nm, (0.0 - k) / (k - 1.0));
		}

		public static double CalculateMassFlow(double at, double pt, double tt, double m, double k)
		{
			return at * pt / Math.Sqrt(8314.46 * tt / (m * k));
		}

		public static double CalculateMassFlowFromChamber(double at, double pc, double tc, double m, double k)
		{
			double pt = CalculateThroatPressure(pc, k);
			double tt = CalculateThroatTemperature(tc, k);
			return CalculateMassFlow(at, pt, tt, m, k);
		}

		public static double CalculateNozzleExitArea(double nm, double at, double k)
		{
			double num = 1.0 + (k - 1.0) / 2.0 * (nm * nm);
			double num2 = (k + 1.0) / 2.0;
			return at / nm * Math.Pow(num / num2, (k + 1.0) / (2.0 * (k - 1.0)));
		}

		public static double CalculateNozzleExitMachNumber(double at, double ae, double k)
		{
			double num = 10.0;
			double num2 = 1.0;
			double num3 = 0.0;
			int num4 = 0;
			double num5 = 9999.0;
			while (num5 > 0.0001 && ++num4 < 100)
			{
				num3 = (num + num2) / 2.0;
				double num6 = CalculateNozzleExitArea(num3, at, k);
				num5 = Math.Abs(ae - num6);
				if (num6 > ae)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			return num3;
		}

		public static double CalculateNozzleExitMachNumberFromPressure(double pc, double pa, double k)
		{
			double b = 2.0 / (k - 1.0) * (Math.Pow(pc / pa, (k - 1.0) / k) - 1.0);
			return Math.Sqrt(Mathd.Max(1.0, b));
		}

		public static double CalculateProductGenerationRate(double a, double pc, double n, double d, double ab)
		{
			double num = a * Math.Pow(pc, n);
			return d * ab * num;
		}

		public static void CalculateStaticPerformance(Params p)
		{
			Inputs inputs = p.Inputs;
			StaticPerformance staticPerformance = p.Static;
			DynamicPerformance dynamic = p.Dynamic;
			staticPerformance.MassFlow = CalculateMassFlowFromChamber(inputs.ThroatArea, inputs.ChamberPressure, inputs.ChamberTemperature, inputs.FuelMolecularWeight, inputs.FuelSpecificHeatRatio);
			staticPerformance.NormalizedMassFlow = CalculateMassFlowFromChamber(inputs.ThroatArea, inputs.ChamberPressure, 3304.0, 11.8, 1.21);
			if (inputs.AltitudeCompensation == 0f)
			{
				dynamic.ExitArea = inputs.ExitArea;
				dynamic.ExitMachNumber = CalculateNozzleExitMachNumber(inputs.ThroatArea, dynamic.ExitArea, inputs.FuelSpecificHeatRatio);
				dynamic.ExitPressure = CalculateExitPressure(inputs.ChamberPressure, dynamic.ExitMachNumber, inputs.FuelSpecificHeatRatio);
				dynamic.ExhaustVelocity = CalculateExhaustVelocity(inputs.ChamberPressure, dynamic.ExitPressure, inputs.ChamberTemperature, inputs.FuelMolecularWeight, inputs.FuelSpecificHeatRatio) * (double)inputs.Efficiency;
			}
			else
			{
				dynamic.ExitArea = 0.0;
				dynamic.ExitMachNumber = 0.0;
				dynamic.ExitPressure = 0.0;
				dynamic.ExhaustVelocity = 0.0;
			}
		}

		public static double CalculateThroatArea(double q, double pt, double tt, double m, double k)
		{
			return q / pt * Math.Sqrt(8314.46 * tt / (m * k));
		}

		public static double CalculateThroatPressure(double pc, double k)
		{
			return pc * Math.Pow(1.0 + (k - 1.0) / 2.0, (0.0 - k) / (k - 1.0));
		}

		public static double CalculateThroatTemperature(double tc, double k)
		{
			return tc / (1.0 + (k - 1.0) / 2.0);
		}
	}
}
