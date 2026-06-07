using System;
using NAudio.CoreAudioApi.Interfaces;

namespace NAudio.Dmo
{
	public class DmoResampler : IDisposable
	{
		private MediaObject mediaObject;

		private IPropertyStore propertyStoreInterface;

		private IWMResamplerProps resamplerPropsInterface;

		private ResamplerMediaComObject mediaComObject;

		public MediaObject MediaObject => null;

		public void Dispose()
		{
		}
	}
}
