public static class TOD_Extensions
{
	public static TOD_CycleParameters CopyTo(this TOD_CycleParameters value, TOD_CycleParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_CycleParameters();
		}
		other.Day = value.Day;
		other.Hour = value.Hour;
		other.Month = value.Month;
		other.Year = value.Year;
		return other;
	}

	public static TOD_WorldParameters CopyTo(this TOD_WorldParameters value, TOD_WorldParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_WorldParameters();
		}
		other.Latitude = value.Latitude;
		other.Longitude = value.Longitude;
		other.UTC = value.UTC;
		return other;
	}

	public static TOD_AtmosphereParameters CopyTo(this TOD_AtmosphereParameters value, TOD_AtmosphereParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_AtmosphereParameters();
		}
		other.Brightness = value.Brightness;
		other.Contrast = value.Contrast;
		other.Directionality = value.Directionality;
		other.Fogginess = value.Fogginess;
		other.MieMultiplier = value.MieMultiplier;
		other.RayleighMultiplier = value.RayleighMultiplier;
		return other;
	}

	public static TOD_DayParameters CopyTo(this TOD_DayParameters value, TOD_DayParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_DayParameters();
		}
		other.AmbientColor = value.AmbientColor;
		other.AmbientMultiplier = value.AmbientMultiplier;
		other.CloudColor = value.CloudColor;
		other.FogColor = value.FogColor;
		other.LightColor = value.LightColor;
		other.LightIntensity = value.LightIntensity;
		other.RayColor = value.RayColor;
		other.ReflectionMultiplier = value.ReflectionMultiplier;
		other.ShadowStrength = value.ShadowStrength;
		other.SkyColor = value.SkyColor;
		other.SunColor = value.SunColor;
		return other;
	}

	public static TOD_NightParameters CopyTo(this TOD_NightParameters value, TOD_NightParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_NightParameters();
		}
		other.AmbientColor = value.AmbientColor;
		other.AmbientMultiplier = value.AmbientMultiplier;
		other.CloudColor = value.CloudColor;
		other.FogColor = value.FogColor;
		other.LightColor = value.LightColor;
		other.LightIntensity = value.LightIntensity;
		other.MoonColor = value.MoonColor;
		other.RayColor = value.RayColor;
		other.ReflectionMultiplier = value.ReflectionMultiplier;
		other.ShadowStrength = value.ShadowStrength;
		other.SkyColor = value.SkyColor;
		return other;
	}

	public static TOD_SunParameters CopyTo(this TOD_SunParameters value, TOD_SunParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_SunParameters();
		}
		other.MeshBrightness = value.MeshBrightness;
		other.MeshContrast = value.MeshContrast;
		other.MeshSize = value.MeshSize;
		return other;
	}

	public static TOD_MoonParameters CopyTo(this TOD_MoonParameters value, TOD_MoonParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_MoonParameters();
		}
		other.HaloBrightness = value.HaloBrightness;
		other.HaloSize = value.HaloSize;
		other.MeshBrightness = value.MeshBrightness;
		other.MeshContrast = value.MeshContrast;
		other.MeshSize = value.MeshSize;
		other.Position = value.Position;
		return other;
	}

	public static TOD_StarParameters CopyTo(this TOD_StarParameters value, TOD_StarParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_StarParameters();
		}
		other.Brightness = value.Brightness;
		other.Position = value.Position;
		other.Size = value.Size;
		return other;
	}

	public static TOD_CloudParameters CopyTo(this TOD_CloudParameters value, TOD_CloudParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_CloudParameters();
		}
		other.Attenuation = value.Attenuation;
		other.Brightness = value.Brightness;
		other.Coverage = value.Coverage;
		other.Opacity = value.Opacity;
		other.Saturation = value.Saturation;
		other.Scattering = value.Scattering;
		other.Sharpness = value.Sharpness;
		other.Size = value.Size;
		return other;
	}

	public static TOD_LightParameters CopyTo(this TOD_LightParameters value, TOD_LightParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_LightParameters();
		}
		other.MinimumHeight = value.MinimumHeight;
		other.UpdateInterval = value.UpdateInterval;
		return other;
	}

	public static TOD_FogParameters CopyTo(this TOD_FogParameters value, TOD_FogParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_FogParameters();
		}
		other.HeightBias = value.HeightBias;
		other.Mode = value.Mode;
		return other;
	}

	public static TOD_AmbientParameters CopyTo(this TOD_AmbientParameters value, TOD_AmbientParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_AmbientParameters();
		}
		other.Mode = value.Mode;
		other.Saturation = value.Saturation;
		other.UpdateInterval = value.UpdateInterval;
		return other;
	}

	public static TOD_ReflectionParameters CopyTo(this TOD_ReflectionParameters value, TOD_ReflectionParameters other = null)
	{
		if (other == null)
		{
			other = new TOD_ReflectionParameters();
		}
		other.ClearFlags = value.ClearFlags;
		other.CullingMask = value.CullingMask;
		other.Mode = value.Mode;
		other.TimeSlicing = value.TimeSlicing;
		other.UpdateInterval = value.UpdateInterval;
		return other;
	}
}
