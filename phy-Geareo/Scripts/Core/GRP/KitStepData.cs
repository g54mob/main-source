using System;
using System.Collections.Generic;

namespace GRP
{
	[Serializable]
	public class KitStepData
	{
		public byte[] image;

		public ExhibitData exhibit;

		public float[] cameraRotation;

		public List<KitStepPartData> parts;
	}
}
