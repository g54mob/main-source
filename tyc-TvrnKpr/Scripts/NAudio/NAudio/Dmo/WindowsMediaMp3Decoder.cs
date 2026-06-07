using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.Dmo
{
	public class WindowsMediaMp3Decoder : IDisposable
	{
		private MediaObject mediaObject;

		private IPropertyStore propertyStoreInterface;

		private WindowsMediaMp3DecoderComObject mediaComObject;

		public MediaObject MediaObject => null;

		public void Dispose()
		{
		}
	}
}
