using System;

namespace Noesis
{
	public struct Batch
	{
		public readonly Shader Shader;

		public readonly RenderState RenderState;

		public readonly byte StencilRef;

		public readonly uint VertexOffset;

		public readonly uint NumVertices;

		public readonly uint StartIndex;

		public readonly uint NumIndices;

		private readonly IntPtr pattern;

		private readonly IntPtr ramps;

		private readonly IntPtr image;

		private readonly IntPtr glyphs;

		private readonly IntPtr shadow;

		public readonly SamplerState PatternSampler;

		public readonly SamplerState RampsSampler;

		public readonly SamplerState ImageSampler;

		public readonly SamplerState GlyphsSampler;

		public readonly SamplerState ShadowSampler;

		public readonly UniformData VertexUniform0;

		public readonly UniformData VertexUniform1;

		public readonly UniformData PixelUniform0;

		public readonly UniformData PixelUniform1;

		public readonly IntPtr PixelShader;

		public Texture Pattern => null;

		public Texture Ramps => null;

		public Texture Image => null;

		public Texture Glyphs => null;

		public Texture Shadow => null;
	}
}
