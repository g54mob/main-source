namespace Spine
{
	public struct BoneMatrix
	{
		public float a;

		public float b;

		public float c;

		public float d;

		public float x;

		public float y;

		public static BoneMatrix CalculateSetupWorld(BoneData boneData)
		{
			return default(BoneMatrix);
		}

		private static BoneMatrix GetInheritedInternal(BoneData boneData, BoneMatrix parentMatrix)
		{
			return default(BoneMatrix);
		}

		public BoneMatrix(BoneData boneData)
		{
			a = 0f;
			b = 0f;
			c = 0f;
			d = 0f;
			x = 0f;
			y = 0f;
		}

		public BoneMatrix(Bone bone)
		{
			a = 0f;
			b = 0f;
			c = 0f;
			d = 0f;
			x = 0f;
			y = 0f;
		}

		public BoneMatrix TransformMatrix(BoneMatrix local)
		{
			return default(BoneMatrix);
		}
	}
}
