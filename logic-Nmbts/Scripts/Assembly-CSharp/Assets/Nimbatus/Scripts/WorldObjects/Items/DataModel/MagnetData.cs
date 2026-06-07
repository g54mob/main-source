using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class MagnetData : BindableDronePartData
	{
		public int Force { get; set; }

		public int Radius { get; set; }
	}
}
