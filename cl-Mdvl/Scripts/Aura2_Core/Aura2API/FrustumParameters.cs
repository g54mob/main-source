using System;

namespace Aura2API
{
	[Flags]
	public enum FrustumParameters
	{
		EnableNothing = 0,
		EnableOcclusionCulling = 1,
		EnableTemporalReprojection = 2,
		EnableVolumes = 4,
		EnableVolumesNoiseMask = 8,
		EnableVolumesTexture2DMask = 0x10,
		EnableVolumesTexture3DMask = 0x20,
		EnableAmbientLighting = 0x40,
		EnableLightProbes = 0x80,
		EnableDirectionalLights = 0x100,
		EnableDirectionalLightsShadows = 0x200,
		DirectionalLightsShadowsOneCascade = 0x400,
		DirectionalLightsShadowsTwoCascades = 0x800,
		DirectionalLightsShadowsFourCascades = 0x1000,
		EnableSpotLights = 0x2000,
		EnableSpotLightsShadows = 0x4000,
		EnablePointLights = 0x8000,
		EnablePointLightsShadows = 0x10000,
		EnableLightsCookies = 0x20000,
		EnableDenoisingFilter = 0x40000,
		EnableBlurFilter = 0x80000
	}
}
