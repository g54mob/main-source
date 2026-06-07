using UnityEngine;

namespace JBooth.MicroSplat
{
	public class ShaderID
	{
		public static int _GMSTraxBuffer = Shader.PropertyToID("_GMSTraxBuffer");

		public static int _Offset = Shader.PropertyToID("_Offset");

		public static int _DepthRT = Shader.PropertyToID("_DepthRT");

		public static int _RepairDelay = Shader.PropertyToID("_RepairDelay");

		public static int _RepairRate = Shader.PropertyToID("_RepairRate");

		public static int _UseTime = Shader.PropertyToID("_UseTime");

		public static int _RepairTotal = Shader.PropertyToID("_RepairTotal");

		public static int _BufferBlend = Shader.PropertyToID("_BufferBlend");

		public static int _SinkStrength = Shader.PropertyToID("_SinkStrength");

		public static int _GMSTraxBufferPosition = Shader.PropertyToID("_GMSTraxBufferPosition");

		public static int _GMSTraxBufferWorldSize = Shader.PropertyToID("_GMSTraxBufferWorldSize");

		public static int _GMSTraxFudgeFactor = Shader.PropertyToID("_GMSTraxFudgeFactor");

		public static int _CamCaptureHeight = Shader.PropertyToID("_CamCaptureHeight");

		public static int _CamFarClipPlane = Shader.PropertyToID("_CamFarClipPlane");
	}
}
