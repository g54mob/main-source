using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetSwitchSetter : ExternallySwitchableGadget
	{
		private const string KEY_MODE = "mode";

		private const string KEY_SIDE = "sideCorrection";

		private const string KEY_DIRECTION = "dir";

		[SerializeField]
		private float[] ranges = new float[6] { 50f, 100f, 150f, 200f, 250f, 300f };

		private int mode;

		public int ModeCount => ranges.Length;

		public int Mode
		{
			get
			{
				return mode;
			}
			set
			{
				value = Mathf.Clamp(value, 0, ranges.Length - 1);
				if (mode != value)
				{
					mode = value;
				}
			}
		}

		public bool SideCorrectRegime { get; set; }

		public int DirectionMode { get; set; } = 1;

		public float GetRange()
		{
			return ranges[mode];
		}

		public float GetMaxRange()
		{
			return ranges[ranges.Length - 1];
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("mode", Mode);
			dst.SetBool("sideCorrection", SideCorrectRegime);
			dst.SetInt("dir", DirectionMode);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			DirectionMode = src.GetInt("dir") ?? 1;
			SideCorrectRegime = src.GetBool("sideCorrection") ?? false;
			Mode = src.GetInt("mode") ?? 0;
		}
	}
}
