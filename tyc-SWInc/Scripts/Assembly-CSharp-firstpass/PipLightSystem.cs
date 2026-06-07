using System;
using UnityEngine;

public class PipLightSystem
{
	private static PipLightSystem instance;

	private int _lightsCount;

	private int lightsIncrement = 16;

	public PipLight[] lights = new PipLight[16];

	public PipLightRenderer Renderer;

	public static PipLightSystem Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new PipLightSystem();
			}
			return instance;
		}
	}

	public int lightsCount
	{
		get
		{
			return _lightsCount;
		}
	}

	public void Add(PipLight o)
	{
		if (_lightsCount >= lights.Length)
		{
			Array.Resize(ref lights, lights.Length + lightsIncrement);
		}
		lights[_lightsCount++] = o;
	}

	public void Remove(PipLight o)
	{
		int num = Array.IndexOf(lights, o);
		if (num != -1)
		{
			lights[num] = lights[--_lightsCount];
			lights[_lightsCount] = null;
		}
	}

	public void RefreshAll()
	{
		Camera main = Camera.main;
		for (int i = 0; i < lightsCount; i++)
		{
			PipLight obj = lights[i];
			obj.UpdateNextFrame = true;
			obj.UpdateLOD(main);
			obj.UpdateShadowMap();
			lights[i].BeforeRender();
		}
	}
}
