using System.Collections.Generic;

namespace Photon.Pun
{
	public class PhotonStreamQueue
	{
		private int m_SampleRate;

		private int m_SampleCount;

		private int m_ObjectsPerSample;

		private float m_LastSampleTime;

		private int m_LastFrameCount;

		private int m_NextObjectIndex;

		private List<object> m_Objects;

		private bool m_IsWriting;

		public PhotonStreamQueue(int sampleRate)
		{
		}

		private void BeginWritePackage()
		{
		}

		public void Reset()
		{
		}

		public void SendNext(object obj)
		{
		}

		public bool HasQueuedObjects()
		{
			return false;
		}

		public object ReceiveNext()
		{
			return null;
		}

		public void Serialize(PhotonStream stream)
		{
		}

		public void Deserialize(PhotonStream stream)
		{
		}
	}
}
