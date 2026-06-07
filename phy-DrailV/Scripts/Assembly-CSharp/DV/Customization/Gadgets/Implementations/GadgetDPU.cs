using System;
using DV.JObjectExtstensions;
using DV.MultipleUnit;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetDPU : ExternallySwitchableGadget
	{
		public enum WirelessMode : byte
		{
			Transmit = 0,
			Off = 1,
			Receive = 2
		}

		private const string KEY_REGIME = "regime";

		private const string KEY_REVERSE = "reverse";

		private const string KEY_CHANNEL = "channel";

		private WirelessMode regime = WirelessMode.Off;

		private int channel;

		public bool On
		{
			get
			{
				if (base.PowerState)
				{
					return regime != WirelessMode.Off;
				}
				return false;
			}
		}

		public WirelessMode Regime
		{
			get
			{
				return regime;
			}
			set
			{
				if (regime != value)
				{
					regime = value;
					RaisePowerStateChanged();
				}
			}
		}

		public bool ReverseOrientation
		{
			get
			{
				if (!base.ArePlacementRequirementsMet)
				{
					return false;
				}
				return base.TrainCar.muModule.RemoteOrientationReversed;
			}
			set
			{
				if (base.ArePlacementRequirementsMet)
				{
					base.TrainCar.muModule.RemoteOrientationReversed = value;
				}
			}
		}

		public int Channel
		{
			get
			{
				return channel;
			}
			set
			{
				value = Mathf.Clamp(value, 0, 7);
				if (channel != value)
				{
					channel = value;
					UpdateRadioChannel();
				}
			}
		}

		public override bool IsValidTarget(Customization target, Collider hitCollider)
		{
			if (target is TrainCarCustomization trainCarCustomization && trainCarCustomization.TrainCar.muModule != null)
			{
				return base.IsValidTarget(target, hitCollider);
			}
			return false;
		}

		protected override void OnPowerStateChanged(bool newState)
		{
			UpdateRadioChannel();
		}

		private void UpdateRadioChannel()
		{
			if (base.ArePlacementRequirementsMet)
			{
				base.TrainCar.muModule.SetRadioChannel(On ? SingletonBehaviour<MultipleUnitChannels>.Instance.Channels[channel] : null, regime == WirelessMode.Transmit);
			}
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("regime", (int)Regime);
			if (base.IsOnTrainCar)
			{
				dst.SetBool("reverse", ReverseOrientation);
			}
			dst.SetInt("channel", Channel);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			Channel = src.GetInt("channel") ?? 0;
			if (base.IsOnTrainCar)
			{
				ReverseOrientation = src.GetBool("reverse") ?? false;
			}
			WirelessMode wirelessMode = (WirelessMode)(((byte?)src.GetInt("regime")) ?? 1);
			if (!Enum.IsDefined(typeof(WirelessMode), wirelessMode))
			{
				wirelessMode = WirelessMode.Off;
			}
			Regime = wirelessMode;
		}
	}
}
