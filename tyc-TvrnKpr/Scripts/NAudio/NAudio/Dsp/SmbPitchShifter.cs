namespace NAudio.Dsp
{
	public class SmbPitchShifter
	{
		private static int MAX_FRAME_LENGTH;

		private float[] gInFIFO;

		private float[] gOutFIFO;

		private float[] gFFTworksp;

		private float[] gLastPhase;

		private float[] gSumPhase;

		private float[] gOutputAccum;

		private float[] gAnaFreq;

		private float[] gAnaMagn;

		private float[] gSynFreq;

		private float[] gSynMagn;

		private long gRover;

		public void PitchShift(float pitchShift, long numSampsToProcess, float sampleRate, float[] indata)
		{
		}

		public void PitchShift(float pitchShift, long numSampsToProcess, long fftFrameSize, long osamp, float sampleRate, float[] indata)
		{
		}

		public void ShortTimeFourierTransform(float[] fftBuffer, long fftFrameSize, long sign)
		{
		}
	}
}
