using System;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetAmpLimiter : ExternallySwitchableGadget
	{
		private const string KEY_MODE = "mode";

		[SerializeField]
		private float[] limits = new float[8] { 0f, 1600f, 1300f, 1000f, 800f, 600f, 400f, 200f };

		private int modeIndex;

		public bool IsEnabled
		{
			get
			{
				if (base.PowerState && limits[modeIndex] > 0f)
				{
					return !float.IsPositiveInfinity(limits[modeIndex]);
				}
				return false;
			}
		}

		public bool IsLimiting { get; private set; }

		public int ModeCount => limits.Length;

		public float EffectiveLimit
		{
			get
			{
				if (base.PowerState && !(limits[modeIndex] <= 0f))
				{
					return limits[modeIndex];
				}
				return float.PositiveInfinity;
			}
		}

		public int ModeIndex
		{
			get
			{
				return modeIndex;
			}
			set
			{
				value = Mathf.Clamp(value, 0, limits.Length - 1);
				if (modeIndex != value)
				{
					modeIndex = value;
					UpdateLimit();
				}
			}
		}

		public event Action OnStateUpdated;

		protected override void OnBeforeUnlinked()
		{
			TryWritePort(STDSimPort.TractionMotorAmpLimit, float.PositiveInfinity);
			base.OnBeforeUnlinked();
		}

		private void Update()
		{
			float value;
			bool flag = TryReadPort(STDSimPort.TractionMotorAmpLimitEffect, out value) && value > 0f;
			if (IsLimiting != flag)
			{
				IsLimiting = flag;
				this.OnStateUpdated?.Invoke();
			}
		}

		protected override void OnPowerStateChanged(bool newState)
		{
			UpdateLimit();
		}

		private void UpdateLimit()
		{
			TryWritePort(STDSimPort.TractionMotorAmpLimit, EffectiveLimit);
			this.OnStateUpdated?.Invoke();
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("mode", modeIndex);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			ModeIndex = src.GetInt("mode") ?? 0;
		}
	}
}
