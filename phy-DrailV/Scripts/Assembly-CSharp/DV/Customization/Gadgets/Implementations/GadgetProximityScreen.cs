using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetProximityScreen : GadgetBase
	{
		public const int CHANNEL_COUNT = 9;

		private const string KEY_CHANNEL = "channel";

		private const string KEY_MODE = "mode";

		private int channel;

		private int mode;

		public int CurrentChannel
		{
			get
			{
				return channel;
			}
			set
			{
				if (channel != value)
				{
					channel = value;
				}
			}
		}

		public int CurrentMode
		{
			get
			{
				return mode;
			}
			set
			{
				if (mode != value)
				{
					mode = value;
				}
			}
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			CurrentChannel = src.GetInt("channel") ?? 0;
			CurrentMode = src.GetInt("mode") ?? 0;
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("channel", CurrentChannel);
			dst.SetInt("mode", CurrentMode);
			base.SaveDataRequested(dst);
		}
	}
}
