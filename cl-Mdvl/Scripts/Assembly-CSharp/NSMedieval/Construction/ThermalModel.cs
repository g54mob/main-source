using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Construction
{
	[Serializable]
	public class ThermalModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int emission;

		[SerializeField]
		private float insulation;

		[SerializeField]
		private float insulationVertical;

		[SerializeField]
		private int emissionRange;

		[SerializeField]
		private byte lightTransmission;

		public int Emission => emission;

		public float Insulation => insulation;

		public float InsulationVertical => insulationVertical;

		public int EmissionRange => emissionRange;

		public byte LightTransmission => lightTransmission;

		public override string GetID()
		{
			return id;
		}

		public override string ToString()
		{
			return $"{GetID()}: emission {emission}, insulation: {insulation}, insulationVertical: {insulationVertical}";
		}
	}
}
