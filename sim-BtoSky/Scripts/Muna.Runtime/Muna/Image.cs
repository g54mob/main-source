using Newtonsoft.Json;

namespace Muna
{
	[Preserve]
	public readonly struct Image
	{
		[JsonIgnore]
		public readonly byte[] data;

		public readonly int width;

		public readonly int height;

		public readonly int channels;

		private unsafe readonly byte* nativeData;

		[JsonProperty("data")]
		[Preserve]
		private string dataPlaceholder
		{
			get
			{
				string text = "?";
				switch (channels)
				{
				case 1:
					text = "R8";
					break;
				case 3:
					text = "RGB888";
					break;
				case 4:
					text = "RGBA8888";
					break;
				}
				return $"<{width}x{height},{text},{data.Length} bytes>";
			}
		}

		public unsafe Image(byte[] data, int width, int height, int channels)
		{
			this.data = data;
			nativeData = null;
			this.width = width;
			this.height = height;
			this.channels = channels;
		}

		public unsafe Image(byte* data, int width, int height, int channels)
		{
			this.data = null;
			nativeData = data;
			this.width = width;
			this.height = height;
			this.channels = channels;
		}

		public unsafe ref byte GetPinnableReference()
		{
			if (nativeData != null)
			{
				return ref *nativeData;
			}
			return ref data[0];
		}
	}
}
