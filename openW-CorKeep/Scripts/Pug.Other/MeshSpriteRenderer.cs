using Pug.UnityExtensions;
using UnityEngine;

public class MeshSpriteRenderer : MonoBehaviour
{
	public Sprite sprite;

	public Color spriteColor;

	public int sortingLayerID;

	public int sortingOrder;

	public MeshRenderer meshRenderer;

	private Sprite prevSprite;

	private Color prevColor;

	private void Update()
	{
		UpdateMaterial();
	}

	private void OnEnable()
	{
		meshRenderer.enabled = true;
	}

	private void OnDisable()
	{
		meshRenderer.enabled = false;
	}

	private void UpdateMaterial()
	{
		if (!(meshRenderer == null))
		{
			meshRenderer.sortingLayerID = sortingLayerID;
			meshRenderer.sortingOrder = sortingOrder;
			if (spriteColor != prevColor)
			{
				meshRenderer.material.SetColor("_Color", spriteColor);
				prevColor = spriteColor;
			}
			if (sprite != null && sprite != prevSprite)
			{
				prevSprite = sprite;
				meshRenderer.material.SetTexture("_MainTex", sprite.texture);
				Vector2 value = sprite.textureRect.size / sprite.texture.GetSize();
				meshRenderer.material.SetTextureScale("_MainTex", value);
				meshRenderer.material.SetTextureOffset("_MainTex", sprite.textureRect.min / sprite.texture.GetSize());
				float width = sprite.textureRect.width;
				float height = sprite.textureRect.height;
				base.transform.localScale = new Vector3(width * 0.0625f, height * 0.0625f, 1f);
				meshRenderer.sharedMaterial.renderQueue = 2000;
			}
			else if (sprite == null)
			{
				meshRenderer.material.SetTexture("_MainTex", null);
			}
		}
	}
}
