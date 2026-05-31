using System;

namespace __Project__.Scripts.Data
{
	[Serializable]
	public class DirtSaveData
	{
		public TransformData transformData;

		public int dirtId;

		public float dirtAlpha;

		public DirtSaveData(TransformData transformData, int dirtId, float dirtAlpha)
		{
		}

		public DirtSaveData()
		{
		}
	}
}
