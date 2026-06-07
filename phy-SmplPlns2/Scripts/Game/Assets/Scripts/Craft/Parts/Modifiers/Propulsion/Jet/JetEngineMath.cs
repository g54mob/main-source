using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEngineMath
	{
		public class Inputs
		{
			public double AfterburnerTemp { get; set; }

			public double AmbientPressure { get; set; }

			public double AmbientTemperature { get; set; }

			public double BurnerTemp { get; set; }

			public double BypassRatio { get; set; }

			public double CompressorPressureRatio { get; set; }

			public double CoreInletArea { get; set; }

			public double FanPressureRatio { get; set; }

			public double MachNumber { get; set; }

			public double Throttle { get; set; }

			public double ThrottleAfterburner { get; set; }

			public double TurbinePressureRatio { get; set; }

			public Inputs()
			{
				BurnerTemp = 1388.0;
				AfterburnerTemp = 2000.0;
				FanPressureRatio = 1.5;
				TurbinePressureRatio = 1.0;
			}
		}

		public class Outputs
		{
			public double ExitVelocityCore { get; set; }

			public double ExitVelocityFan { get; set; }

			public double FuelFlow { get; set; }

			public double FuelToAirRatio { get; set; }

			public double InletVelocity { get; set; }

			public double Isp { get; set; }

			public double MassFlowCore { get; set; }

			public double MassFlowFan { get; set; }

			public double P01 { get; set; }

			public double P02 { get; set; }

			public double P03 { get; set; }

			public double P04 { get; set; }

			public double P05 { get; set; }

			public double P06 { get; set; }

			public double P08 { get; set; }

			public double RamDrag { get; set; }

			public double SpecificThrust { get; set; }

			public double T01 { get; set; }

			public double T02 { get; set; }

			public double T03 { get; set; }

			public double T04 { get; set; }

			public double T05 { get; set; }

			public double T06 { get; set; }

			public double T08 { get; set; }

			public double ThrustCore { get; set; }

			public double ThrustFan { get; set; }

			public double ThrustNet { get; set; }

			public float ThrustNetScaled => (float)ThrustNet * 0.01f;

			public double ThrustSpecificFuelConsumption { get; set; }
		}

		public class Params
		{
			public Inputs Inputs { get; set; }

			public Outputs Output { get; set; }

			public Params()
			{
				Inputs = new Inputs();
				Output = new Outputs();
			}
		}

		public const double R = 287.00248878149813;

		private static bool _loggingEnabled;

		public static double CalculateAirPressure(double airDensity, double temperature)
		{
			return airDensity * 287.00248878149813 * temperature;
		}

		public static void ProcessParams(Params p)
		{
			Outputs output = p.Output;
			Inputs inputs = p.Inputs;
			if (inputs.CompressorPressureRatio < 1.0)
			{
				inputs.CompressorPressureRatio = 1.0;
			}
			double num = Mathd.Clamp(inputs.AmbientPressure, 0.0, 100000.0);
			double num2 = Mathd.Clamp(inputs.AmbientTemperature, 0.0, 350.0);
			output.InletVelocity = inputs.MachNumber * Math.Sqrt(401.80348429409736 * num2);
			double num3 = 1.0;
			if (inputs.MachNumber > 1.0)
			{
				num3 = Mathd.Clamp(1.0 - 0.075 * Math.Pow(inputs.MachNumber - 1.0, 1.35), 0.0, 1.0);
			}
			double num4 = Math.Min(inputs.MachNumber, 1.399999976158142);
			output.T01 = num2 * (1.0 + 0.19999999999999996 * num4 * num4);
			output.P01 = num * num3 * Math.Pow(1.0 + (output.T01 / num2 - 1.0), 3.5000000000000004);
			output.P01 = Math.Min(output.P01, 200000.0);
			output.T02 = output.T01 * (1.0 + (Math.Pow(inputs.FanPressureRatio, 0.28571428571428564) - 1.0));
			output.P02 = output.P01 * inputs.FanPressureRatio;
			output.P03 = output.P02 * inputs.CompressorPressureRatio;
			output.T03 = output.T02 * (1.0 + (Math.Pow(inputs.CompressorPressureRatio, 0.28571428571428564) - 1.0));
			double num5 = inputs.BurnerTemp - output.T03;
			output.T04 = output.T03 + num5 * inputs.Throttle;
			output.P04 = output.P03 * inputs.TurbinePressureRatio * 0.8799999952316284;
			output.P08 = output.P02;
			output.T08 = output.T02 * (1.0 + (Math.Pow(inputs.FanPressureRatio, 0.28571428571428564) - 1.0));
			output.T05 = output.T04 - (output.T03 - output.T02) - inputs.BypassRatio * (output.T08 - output.T02);
			output.P05 = output.P04 * Math.Pow(1.0 - (1.0 - output.T05 / output.T04), 3.5000000000000004);
			if (inputs.ThrottleAfterburner > 0.0)
			{
				double afterburnerTemp = inputs.AfterburnerTemp;
				double num6 = 700.0;
				double num7 = Math.Max(Math.Min(afterburnerTemp, output.T05 + num6), output.T05 + 200.0) - output.T05;
				output.T06 = output.T05 + inputs.ThrottleAfterburner * num7;
				output.T08 = output.T06;
			}
			else
			{
				output.T06 = output.T05;
			}
			output.P06 = output.P05;
			double num8 = (output.T06 - output.T05) * 4.5 + (output.T04 - output.T03);
			double num9 = 42806.99563921794 - (output.T04 + output.T06 - output.T05);
			if (num8 > 0.0 && num9 > 0.0)
			{
				output.FuelToAirRatio = num8 / num9;
			}
			else
			{
				output.FuelToAirRatio = 0.0;
			}
			output.ExitVelocityCore = SafeSqrt(2009.017421470487 * output.T06 * (1.0 - Math.Pow(num / output.P06, 0.28571428571428564)));
			output.ExitVelocityFan = SafeSqrt(2009.017421470487 * output.T08 * (1.0 - Math.Pow(num / output.P08, 0.28571428571428564)));
			output.SpecificThrust = (1.0 + output.FuelToAirRatio) * output.ExitVelocityCore + inputs.BypassRatio * output.ExitVelocityFan - (1.0 + inputs.BypassRatio) * output.InletVelocity;
			if (output.SpecificThrust > 0.0)
			{
				output.ThrustSpecificFuelConsumption = output.FuelToAirRatio / output.SpecificThrust;
			}
			else
			{
				output.ThrustSpecificFuelConsumption = 0.0;
			}
			double d = output.T06 / output.T01;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			if (output.P01 > 0.0)
			{
				num10 = output.P06 / output.P01;
				num11 = Math.Min(0.75 * Math.Sqrt(d) / num10, 1.0);
				num12 = inputs.CoreInletArea * num11;
			}
			double num13 = Math.Sqrt(0.004878006479817858) * Math.Pow(1.2, -3.0000000000000004);
			output.MassFlowCore = num12 * output.P06 / Math.Sqrt(output.T06) * num13;
			output.MassFlowFan = inputs.BypassRatio * output.MassFlowCore;
			output.ThrustCore = output.MassFlowCore * (output.ExitVelocityCore - output.InletVelocity);
			output.ThrustFan = output.MassFlowFan * (output.ExitVelocityFan - output.InletVelocity);
			output.RamDrag = output.MassFlowCore * output.InletVelocity * (1.0 + inputs.BypassRatio);
			if (output.ThrustCore < 0.0)
			{
				output.ThrustCore = 0.0;
			}
			if (output.ThrustFan < 0.0)
			{
				output.ThrustFan = 0.0;
			}
			output.ThrustNet = output.ThrustCore + output.ThrustFan;
			if (output.ThrustNet < 0.0)
			{
				output.ThrustNet = 0.0;
			}
			output.FuelFlow = output.ThrustSpecificFuelConsumption * output.ThrustNet;
			if (output.FuelFlow > 0.0)
			{
				output.Isp = output.ThrustNet / (output.FuelFlow * 9.8100004196167);
			}
			else
			{
				output.Isp = 0.0;
			}
			if (_loggingEnabled)
			{
				Debug.Log($"thrust: {output.ThrustNet / 1000.0:n1}kN and mach: {inputs.MachNumber:n2}\n" + $"p01: {output.P01 / 100000.0:n2} bar\n" + $"t01: {output.T01:n0}K\n" + $"p02: {output.P02 / 100000.0:n2} bar\n" + $"t02: {output.T02:n0}K\n" + $"p03: {output.P03 / 100000.0:n2} bar\n" + $"t03: {output.T03:n0}K\n" + $"p04: {output.P04 / 100000.0:n2} bar\n" + $"t04: {output.T04:n0}K\n" + $"p05: {output.P05 / 100000.0:n2} bar\n" + $"t05: {output.T05:n0}K\n" + $"p06: {output.P06 / 100000.0:n2} bar\n" + $"t06: {output.T06:n0}K\n" + $"p08: {output.P08 / 100000.0:n2} bar\n" + $"t08: {output.T08:n0}K\n");
			}
		}

		private static double SafeSqrt(double x)
		{
			if (x > 0.0)
			{
				return Math.Sqrt(x);
			}
			return 0.0;
		}
	}
}
