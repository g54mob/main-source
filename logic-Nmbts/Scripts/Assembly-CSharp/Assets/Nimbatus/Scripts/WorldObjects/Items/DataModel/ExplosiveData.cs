using System;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class ExplosiveData : BindableDronePartData
	{
		public int Radius { get; set; }
	}
}
