using System.Collections.Generic;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

public class BoxArtDisplay : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer mesh;

	private MotionHandle _handle;

	private readonly List<BoxArtTexture> _texturesCache = new List<BoxArtTexture>();

	public void Animate(BoxArtTexture texture, float duration)
	{
		if (_handle.IsValid())
		{
			_handle.TryComplete();
		}
		if (duration == 0f)
		{
			DisposeCache();
			mesh.material.SetTexture(Constants.MaterialProperties.TargetTexture, texture);
			mesh.material.SetTexture(Constants.MaterialProperties.CurrentTexture, texture);
			mesh.material.SetFloat(Constants.MaterialProperties.Blend, 1f);
			_texturesCache.Add(texture);
		}
		else
		{
			mesh.material.SetTexture(Constants.MaterialProperties.TargetTexture, texture);
			_handle = LMotion.Create(0f, 1f, duration).WithOnComplete(delegate
			{
				OnAnimationComplete(texture);
			}).BindToMaterialFloat(mesh.material, Constants.MaterialProperties.Blend);
		}
	}

	private void OnAnimationComplete(BoxArtTexture texture)
	{
		DisposeCache();
		mesh.material.SetTexture(Constants.MaterialProperties.CurrentTexture, texture);
		_texturesCache.Add(texture);
	}

	private void DisposeCache()
	{
		foreach (BoxArtTexture item in _texturesCache)
		{
			item.Dispose();
		}
		_texturesCache.Clear();
	}
}
