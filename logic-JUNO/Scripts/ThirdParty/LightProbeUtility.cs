using System;
using UnityEngine;

public static class LightProbeUtility
{
	private static int[] _idSHA = new int[3]
	{
		Shader.PropertyToID("unity_SHAr"),
		Shader.PropertyToID("unity_SHAg"),
		Shader.PropertyToID("unity_SHAb")
	};

	private static int[] _idSHB = new int[3]
	{
		Shader.PropertyToID("unity_SHBr"),
		Shader.PropertyToID("unity_SHBg"),
		Shader.PropertyToID("unity_SHBb")
	};

	private static int _idSHC = Shader.PropertyToID("unity_SHC");

	private static int[] Particle_idSHA = new int[3]
	{
		Shader.PropertyToID("Particle_SHAr"),
		Shader.PropertyToID("Particle_SHAg"),
		Shader.PropertyToID("Particle_SHAb")
	};

	private static int[] Particle_idSHB = new int[3]
	{
		Shader.PropertyToID("Particle_SHBr"),
		Shader.PropertyToID("Particle_SHBg"),
		Shader.PropertyToID("Particle_SHBb")
	};

	private static int Particle_idSHC = Shader.PropertyToID("Particle_SHC");

	public static void SetSHCoefficients(Vector3 position, MaterialPropertyBlock properties)
	{
		LightProbes.GetInterpolatedProbe(position, null, out var probe);
		for (int i = 0; i < 3; i++)
		{
			properties.SetVector(_idSHA[i], new Vector4(probe[i, 3], probe[i, 1], probe[i, 2], probe[i, 0] - probe[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			properties.SetVector(_idSHB[j], new Vector4(probe[j, 4], probe[j, 6], probe[j, 5] * 3f, probe[j, 7]));
		}
		properties.SetVector(_idSHC, new Vector4(probe[0, 8], probe[2, 8], probe[1, 8], 1f));
	}

	public static void SetSHCoefficients(Vector3 position, Material material)
	{
		LightProbes.GetInterpolatedProbe(position, null, out var probe);
		for (int i = 0; i < 3; i++)
		{
			material.SetVector(_idSHA[i], new Vector4(probe[i, 3], probe[i, 1], probe[i, 2], probe[i, 0] - probe[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			material.SetVector(_idSHB[j], new Vector4(probe[j, 4], probe[j, 6], probe[j, 5] * 3f, probe[j, 7]));
		}
		material.SetVector(_idSHC, new Vector4(probe[0, 8], probe[2, 8], probe[1, 8], 1f));
	}

	public static void SetParticleSHCoefficients(Vector3 position, Material material)
	{
		LightProbes.GetInterpolatedProbe(position, null, out var probe);
		for (int i = 0; i < 3; i++)
		{
			material.SetVector(Particle_idSHA[i], new Vector4(probe[i, 3], probe[i, 1], probe[i, 2], probe[i, 0] - probe[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			material.SetVector(Particle_idSHB[j], new Vector4(probe[j, 4], probe[j, 6], probe[j, 5] * 3f, probe[j, 7]));
		}
		material.SetVector(Particle_idSHC, new Vector4(probe[0, 8], probe[2, 8], probe[1, 8], 1f));
	}

	public static void SetParticleSHCoefficientsWithAdustments(Vector3 position, Material material)
	{
		LightProbes.GetInterpolatedProbe(position, null, out var probe);
		probe = RenderSettings.ambientProbe;
		float num = Mathf.Sqrt(MathF.PI);
		float num2 = 1f / (2f * num);
		float num3 = Mathf.Sqrt(3f) / (3f * num);
		float num4 = Mathf.Sqrt(15f) / (8f * num);
		float num5 = Mathf.Sqrt(5f) / (16f * num);
		float num6 = 0.5f * num4;
		for (int i = 0; i < 3; i++)
		{
			material.SetVector(Particle_idSHA[i], new Vector4((0f - num3) * probe[i, 3], (0f - num3) * probe[i, 1], num3 * probe[i, 2], num2 * probe[i, 0] - probe[i, 6]));
		}
		for (int j = 0; j < 3; j++)
		{
			material.SetVector(Particle_idSHB[j], new Vector4(num4 * probe[j, 4], (0f - num4) * probe[j, 6], 3f * num5 * probe[j, 5] * 3f, (0f - num4) * probe[j, 7]));
		}
		material.SetVector(Particle_idSHC, new Vector4(num6 * probe[0, 8], num6 * probe[2, 8], num6 * probe[1, 8], 1f));
	}

	public static void SetParticleSHCoefficientsStraitPass(Vector3 position, Material material)
	{
		LightProbes.GetInterpolatedProbe(position, null, out var probe);
		for (int i = 0; i < 3; i++)
		{
			material.SetVector(Particle_idSHA[i], new Vector4(probe[i, 0], probe[i, 1], probe[i, 2], probe[i, 3]));
		}
		for (int j = 0; j < 3; j++)
		{
			material.SetVector(Particle_idSHB[j], new Vector4(probe[j, 4], probe[j, 5], probe[j, 6], probe[j, 7]));
		}
		material.SetVector(Particle_idSHC, new Vector4(probe[0, 8], probe[1, 8], probe[2, 8], 1f));
	}
}
