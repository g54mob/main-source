using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(SpriteMask))]
[ExecuteInEditMode]
public class SpriteSheetMaskSkin : MonoBehaviour
{
	private readonly int mainTexID = Shader.PropertyToID("_MainTex");

	private MaterialPropertyBlock mpb;

	private SpriteMask sm;

	public Texture2D skin;

	private List<Texture2D> previousSkins = new List<Texture2D>();

	[Conditional("UNITY_EDITOR")]
	private void SafetyCheck()
	{
		if (!(skin == null))
		{
			if (mpb == null || sm == null)
			{
				Awake();
			}
			_ = sm.sprite.texture == null;
		}
	}

	private void Awake()
	{
		mpb = new MaterialPropertyBlock();
		sm = GetComponent<SpriteMask>();
	}

	private void LateUpdate()
	{
		sm.GetPropertyBlock(mpb);
		mpb.SetTexture(mainTexID, skin);
		sm.SetPropertyBlock(mpb);
	}

	public void SetSkin(Texture2D newSkin)
	{
		skin = newSkin;
	}

	public void SetTemporarySkin(Texture2D tmpSkin)
	{
		previousSkins.Add(skin);
		skin = tmpSkin;
	}

	public void ResetTemporarySkin()
	{
		if (previousSkins.Count > 0)
		{
			skin = previousSkins[previousSkins.Count - 1];
			previousSkins.RemoveAt(previousSkins.Count - 1);
		}
	}

	public void SetSprite(Sprite sprite)
	{
		sm.sprite = sprite;
	}
}
