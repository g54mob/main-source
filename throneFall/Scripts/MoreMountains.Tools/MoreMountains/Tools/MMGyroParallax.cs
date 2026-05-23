using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMGyroParallax : MMGyroscope
	{
		[Header("Cameras")]
		public List<MMGyroCam> Cams;

		protected Vector3 _newAngles;
	}
}
