using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
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

			public Inputs()
			{
				BurnerTemp = 1388.0;
				AfterburnerTemp = 2000.0;
				FanPressureRatio = 1.5;
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
			output.T01 = num2 * (1.0 + 0.19999999999999996 * inputs.MachNumber * inputs.MachNumber);
			output.P01 = num * num3 * Math.Pow(1.0 + (output.T01 / num2 - 1.0), 3.5000000000000004);
			output.T02 = output.T01 * (1.0 + (Math.Pow(inputs.FanPressureRatio, 0.28571428571428564) - 1.0));
			output.P02 = output.P01 * inputs.FanPressureRatio;
			output.P03 = output.P02 * inputs.CompressorPressureRatio;
			output.T03 = output.T02 * (1.0 + (Math.Pow(inputs.CompressorPressureRatio, 0.28571428571428564) - 1.0));
			double num4 = inputs.BurnerTemp - output.T03;
			output.T04 = output.T03 + num4 * inputs.Throttle;
			output.P04 = output.P03;
			output.P08 = output.P02;
			output.T08 = output.T02 * (1.0 + (Math.Pow(inputs.FanPressureRatio, 0.28571428571428564) - 1.0));
			output.T05 = output.T04 - (output.T03 - output.T02) - inputs.BypassRatio * (output.T08 - output.T02);
			output.P05 = output.P04 * Math.Pow(1.0 - (1.0 - output.T05 / output.T04), 3.5000000000000004);
			if (inputs.ThrottleAfterburner > 0.0)
			{
				double num5 = inputs.AfterburnerTemp - output.T05;
				output.T06 = output.T05 + inputs.ThrottleAfterburner * num5;
			}
			else
			{
				output.T06 = output.T05;
			}
			output.P06 = output.P05;
			double num6 = output.T06 - output.T05 + (output.T04 - output.T03);
			double num7 = 42806.99563921794 - (output.T04 + output.T06 - output.T05);
			if (num6 > 0.0 && num7 > 0.0)
			{
				output.FuelToAirRatio = num6 / num7;
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
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			if (output.P01 > 0.0)
			{
				num8 = output.P06 / output.P01;
				num9 = Math.Min(0.75 * Math.Sqrt(d) / num8, 1.0);
				num10 = inputs.CoreInletArea * num9;
			}
			double num11 = Math.Sqrt(0.004878006479817858) * Math.Pow(1.2, -3.0000000000000004);
			output.MassFlowCore = num10 * output.P06 / Math.Sqrt(output.T06) * num11;
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
				output.Isp = output.ThrustNet / (output.FuelFlow * 9.806650161743164);
			}
			else
			{
				output.Isp = 0.0;
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
