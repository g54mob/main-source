using System.Collections;
using System.Collections.Generic;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.CoreAudioApi
{
	public class MMDeviceCollection : IEnumerable<MMDevice>, IEnumerable
	{
		private IMMDeviceCollection _MMDeviceCollection;

		public int Count => 0;

		public MMDevice this[int index] => null;

		internal MMDeviceCollection(IMMDeviceCollection parent)
		{
		}

		public IEnumerator<MMDevice> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
