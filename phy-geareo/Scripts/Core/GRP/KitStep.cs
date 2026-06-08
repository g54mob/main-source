using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class KitStep
	{
		public Texture2D image;

		public Exhibit exhibit;

		public Quaternion cameraRotation;

		public List<KitStepPart> parts;

		public KitStepData Serialize()
		{
			return null;
		}

		public static KitStep FromData(KitStepData data, EntityManagerConfig parts)
		{
			return null;
		}
	}
}
