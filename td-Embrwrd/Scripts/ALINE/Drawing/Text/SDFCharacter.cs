using Unity.Mathematics;

namespace Drawing.Text
{
	internal struct SDFCharacter
	{
		public char codePoint;

		private float2 uvtopleft;

		private float2 uvbottomright;

		private float2 vtopleft;

		private float2 vbottomright;

		public float advance;

		public float2 uvTopLeft => default(float2);

		public float2 uvTopRight => default(float2);

		public float2 uvBottomLeft => default(float2);

		public float2 uvBottomRight => default(float2);

		public float2 vertexTopLeft => default(float2);

		public float2 vertexTopRight => default(float2);

		public float2 vertexBottomLeft => default(float2);

		public float2 vertexBottomRight => default(float2);

		public SDFCharacter(char codePoint, int x, int y, int width, int height, int originX, int originY, int advance, int textureWidth, int textureHeight, float defaultSize)
		{
			this.codePoint = '\0';
			uvtopleft = default(float2);
			uvbottomright = default(float2);
			vtopleft = default(float2);
			vbottomright = default(float2);
			this.advance = 0f;
		}
	}
}
