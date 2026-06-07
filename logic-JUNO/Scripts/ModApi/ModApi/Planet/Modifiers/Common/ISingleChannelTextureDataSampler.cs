using System.IO;

namespace ModApi.Planet.Modifiers.Common
{
	public interface ISingleChannelTextureDataSampler
	{
		float SampleBicubic(float u, float v, float[][] preallocatedArray);

		float SampleBilinear(float u, float v);

		void Save(BinaryWriter writer);
	}
}
