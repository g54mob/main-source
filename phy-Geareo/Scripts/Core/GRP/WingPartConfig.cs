using Rhizomatic;
using UnityEngine;

namespace GRP
{
	public class WingPartConfig : PartConfig
	{
		public Material material;

		public float thickness;

		public float liftK;

		public float dragK;

		public float stallAoa;

		public override Thing CreateThing()
		{
			return null;
		}
	}
}
