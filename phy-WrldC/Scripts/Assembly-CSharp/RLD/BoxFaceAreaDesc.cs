namespace RLD
{
	public struct BoxFaceAreaDesc
	{
		public BoxFaceAreaType AreaType;

		public float Area;

		public BoxFaceAreaDesc(BoxFaceAreaType areaType, float area)
		{
			AreaType = areaType;
			Area = area;
		}

		public static BoxFaceAreaDesc GetInvalid()
		{
			return new BoxFaceAreaDesc(BoxFaceAreaType.Invalid, 0f);
		}
	}
}
