using System;

namespace UMA
{
	[Serializable]
	public class PropertyHolder
	{
		public UMAOverlayTransformProperty p12;

		public UMAFloatProperty p11;

		public UMAColorProperty p10;

		public UMAVectorProperty p9;

		public UMAVectorArrayProperty p8;

		public UMATextureProperty p7;

		public UMAFloatArrayProperty p6;

		public UMAIntProperty p5;

		public UMAMatrixProperty p4;

		public UMAMatrixArrayProperty p3;

		public UMAComputeBufferProperty p2;

		public UMAConstantComputeBufferProperty p1;

		public string propertType;

		public UMAProperty property
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PropertyHolder(UMAProperty prop)
		{
		}

		private UMAProperty Get()
		{
			return null;
		}
	}
}
