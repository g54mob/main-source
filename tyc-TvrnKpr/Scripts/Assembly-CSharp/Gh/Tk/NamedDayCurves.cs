using System;
using UnityEngine;

namespace Gh.Tk
{
	public class NamedDayCurves : SingletonMonoBehaviour<NamedDayCurves>
	{
		[Serializable]
		public class NamedDayCurve
		{
			public string name;

			public AnimationCurve animationCurve;
		}

		public NamedDayCurve[] curves;
	}
}
