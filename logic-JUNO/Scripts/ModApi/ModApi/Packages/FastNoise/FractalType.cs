using ModApi.Common.Attributes;

namespace ModApi.Packages.FastNoise
{
	public enum FractalType
	{
		FBM = 0,
		[DisplayName("FBM Power V1")]
		FBMPowerV1 = 1,
		[DisplayName("FBM Power V2")]
		FBMPowerV2 = 2,
		[DisplayName("FBM Power V3")]
		FBMPowerV3 = 3,
		Billow = 4,
		[DisplayName("Billow Power V1")]
		BillowPowerV1 = 5,
		[DisplayName("Billow Power V2")]
		BillowPowerV2 = 6,
		[DisplayName("Billow Power V3")]
		BillowPowerV3 = 7,
		[DisplayName("Ridged Multi")]
		RigidMulti = 8,
		[DisplayName("Ridged Multi Power V1")]
		RigidMultiPowerV1 = 9,
		[DisplayName("Ridged Multi Power V2")]
		RigidMultiPowerV2 = 10,
		[DisplayName("Ridged Multi Power V3")]
		RigidMultiPowerV3 = 11,
		[DisplayName("Ridged Multi V2")]
		RigidMultiV2 = 12
	}
}
