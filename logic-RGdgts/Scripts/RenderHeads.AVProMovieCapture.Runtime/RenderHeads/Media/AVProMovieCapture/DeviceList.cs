using System.Collections;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class DeviceList : IEnumerable
	{
		private Device[] _devices;

		public Device[] Devices => null;

		public int Count => 0;

		internal DeviceList(Device[] devices)
		{
		}

		public Device FindDevice(string name, MediaApi mediaApi = MediaApi.Unknown)
		{
			return null;
		}

		public Device GetFirstWithMediaApi(MediaApi api)
		{
			return null;
		}

		public IEnumerator GetEnumerator()
		{
			return null;
		}
	}
}
