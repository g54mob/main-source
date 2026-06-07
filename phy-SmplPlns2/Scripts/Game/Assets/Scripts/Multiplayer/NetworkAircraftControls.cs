using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Input;
using Assets.Scripts.Multiplayer.Extensions;
using FishNet.Serializing;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkAircraftControls
	{
		private AircraftControls _controls;

		public float Brake { get; set; }

		public bool FireGuns { get; set; }

		public bool FireWeapons { get; set; }

		public float Flaps { get; set; }

		public bool LandingGearDown { get; set; }

		public bool LaunchCountermeasures { get; set; }

		public float Pitch { get; set; }

		public float Roll { get; set; }

		public float Throttle { get; set; }

		public float Trim { get; set; }

		public float Vtol { get; set; }

		public float Yaw { get; set; }

		public void SerializeRead(Reader reader)
		{
			Brake = reader.ReadFloatAsShort(-1f);
			Flaps = reader.ReadFloatAsShort(-1f);
			Pitch = reader.ReadFloatAsShort(-1f);
			Roll = reader.ReadFloatAsShort(-1f);
			Throttle = reader.ReadFloatAsShort(-1f);
			Trim = reader.ReadFloatAsShort(-1f);
			Vtol = reader.ReadFloatAsShort(-1f);
			Yaw = reader.ReadFloatAsShort(-1f);
			BitArray bitArray = reader.ReadBitArray();
			FireGuns = bitArray[0];
			FireWeapons = bitArray[1];
			LandingGearDown = bitArray[2];
			LaunchCountermeasures = bitArray[3];
			BitArray bitArray2 = reader.ReadBitArray();
			for (int i = 0; i < 8; i++)
			{
				bool flag = bitArray2[i];
				if (_controls.GetActivationState(i + 1) != flag)
				{
					_controls.ActivateGroup(i);
				}
			}
		}

		public void SerializeWrite(Writer writer)
		{
			writer.WriteFloatAsShort(_controls.Brake, -1f);
			writer.WriteFloatAsShort(_controls.Flaps, -1f);
			writer.WriteFloatAsShort(_controls.Pitch, -1f);
			writer.WriteFloatAsShort(_controls.Roll, -1f);
			writer.WriteFloatAsShort(_controls.Throttle, -1f);
			writer.WriteFloatAsShort(_controls.Trim, -1f);
			writer.WriteFloatAsShort(_controls.Vtol, -1f);
			writer.WriteFloatAsShort(_controls.Yaw, -1f);
			writer.WriteBitArray(new BitArray
			{
				[0] = _controls.FireGuns,
				[1] = _controls.FireWeapons,
				[2] = _controls.LandingGearDown,
				[3] = _controls.LaunchCountermeasures
			});
			BitArray bits = default(BitArray);
			for (int i = 0; i < 8; i++)
			{
				bits[i] = _controls.GetActivationState(i + 1);
			}
			writer.WriteBitArray(bits);
		}

		public void SetControls(AircraftControls controls, bool overrideInputs)
		{
			if (_controls != null)
			{
				throw new NotImplementedException();
			}
			_controls = controls;
			if (overrideInputs)
			{
				_controls.ShowInputStatusMessages = false;
				GameInputs instance = GameInputs.Instance;
				_controls.SetInputOverride(instance.Brake, () => Brake);
				_controls.SetInputOverride(instance.Flaps, () => Flaps);
				_controls.SetInputOverride(instance.Pitch, () => Pitch);
				_controls.SetInputOverride(instance.Roll, () => Roll);
				_controls.SetInputOverride(instance.Throttle, () => Throttle);
				_controls.SetInputOverride(instance.Trim, () => Trim);
				_controls.SetInputOverride(instance.Vtol, () => Vtol);
				_controls.SetInputOverride(instance.Yaw, () => Yaw);
				_controls.SetInputOverride(instance.FireGuns, () => FireGuns ? 1 : 0);
				_controls.SetInputOverride(instance.FireWeapons, () => FireWeapons ? 1 : 0);
				_controls.SetInputOverride(instance.LandingGear, () => LandingGearDown ? 1 : 0);
				_controls.SetInputOverride(instance.LaunchCountermeasures, () => LaunchCountermeasures ? 1 : 0);
			}
		}
	}
}
