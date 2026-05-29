using System;
using System.Collections.Generic;
using UnityEngine;

public class RTPool
{
	private int m_TextureSize;

	private List<RenderTexture> m_RTs;

	private Action<RenderTexture> m_Preprocessor;

	public RTPool(int textureSize)
	{
	}

	public void SetPreprocessor(Action<RenderTexture> preprocessor)
	{
	}

	private RenderTexture CreateRT()
	{
		return null;
	}

	public RenderTexture Get()
	{
		return null;
	}

	public void Release(RenderTexture rt)
	{
	}
}
