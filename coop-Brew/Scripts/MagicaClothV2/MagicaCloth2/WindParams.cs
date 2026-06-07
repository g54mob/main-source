namespace MagicaCloth2
{
	public struct WindParams : IValid
	{
		public float influence;

		public float frequency;

		public float turbulence;

		public float blend;

		public float synchronization;

		public float depthWeight;

		public float movingWind;

		public void Convert(WindSettings sdata, ClothProcess.ClothType clothType)
		{
		}

		public bool IsValid()
		{
			return false;
		}
	}
}
