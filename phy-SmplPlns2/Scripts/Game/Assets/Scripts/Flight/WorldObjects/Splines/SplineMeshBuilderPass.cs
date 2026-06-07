using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[Serializable]
	public class SplineMeshBuilderPass
	{
		[SerializeField]
		public SplineMeshBuilderPassType Type;

		[SerializeField]
		public List<SplineMeshBuilderChannel> Channels;
	}
}
