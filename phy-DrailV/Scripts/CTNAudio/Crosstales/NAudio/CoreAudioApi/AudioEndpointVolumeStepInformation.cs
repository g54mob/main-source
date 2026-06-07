using System.Runtime.InteropServices;
using Crosstales.NAudio.CoreAudioApi.Interfaces;

namespace Crosstales.NAudio.CoreAudioApi
{
	public class AudioEndpointVolumeStepInformation
	{
		private readonly uint step;

		private readonly uint stepCount;

		public uint Step => step;

		public uint StepCount => stepCount;

		internal AudioEndpointVolumeStepInformation(IAudioEndpointVolume parent)
		{
			Marshal.ThrowExceptionForHR(parent.GetVolumeStepInfo(out step, out stepCount));
		}
	}
}
