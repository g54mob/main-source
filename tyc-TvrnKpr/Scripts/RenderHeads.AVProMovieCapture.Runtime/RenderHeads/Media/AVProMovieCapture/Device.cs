namespace RenderHeads.Media.AVProMovieCapture
{
	public class Device : IMediaApiItem
	{
		private DeviceType _deviceType;

		private int _index;

		private string _name;

		private MediaApi _api;

		public DeviceType DeviceType => default(DeviceType);

		public int Index => 0;

		public string Name => null;

		public MediaApi MediaApi => default(MediaApi);

		internal Device(DeviceType deviceType, int index, string name, MediaApi api)
		{
		}
	}
}
