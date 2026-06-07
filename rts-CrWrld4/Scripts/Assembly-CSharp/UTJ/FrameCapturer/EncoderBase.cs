using System;

namespace UTJ.FrameCapturer
{
	public abstract class EncoderBase
	{
		public EncoderBase()
		{
		}

		public static void WaitAsyncDelete(object sender, EventArgs e)
		{
		}

		public abstract void Release();

		public abstract bool IsValid();
	}
}
