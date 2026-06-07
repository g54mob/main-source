using System;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteAutoTileScaler : MonoBehaviour
{
	public Vector2 tileScale;

	public bool shouldUpdateAtRuntime;

	private SpriteRenderer spriteRenderer;

	private Vector3 lastLossyScale;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		lastLossyScale = Vector3.zero;
	}

	private void Start()
	{
		UpdateSpriteRenderer();
	}

	private void Update()
	{
		if (shouldUpdateAtRuntime)
		{
			UpdateSpriteRenderer();
		}
	}

	public void UpdateSpriteRenderer()
	{
		try
		{
			if (!(spriteRenderer == null) && !(base.transform.lossyScale == lastLossyScale) && tileScale.x != 0f && tileScale.y != 0f)
			{
				Vector3 vector = new Vector3(base.transform.lossyScale.x / base.transform.localScale.x, base.transform.lossyScale.y / base.transform.localScale.y, 1f);
				if (vector.x != 0f && vector.y != 0f)
				{
					Vector2 vector2 = new Vector2((float)spriteRenderer.sprite.texture.width / spriteRenderer.sprite.pixelsPerUnit, (float)spriteRenderer.sprite.texture.height / spriteRenderer.sprite.pixelsPerUnit);
					Vector2 vector3 = new Vector2(1f / tileScale.x, 1f / tileScale.y);
					Vector3 a = new Vector3(vector3.x / vector2.x, vector3.y / vector2.y, 1f);
					Vector3 b = new Vector3(1f / vector.x, 1f / vector.y, 1f / vector.z);
					base.transform.localScale = Vector3.Scale(a, b);
					Vector2 b2 = new Vector2(vector.x, vector.y);
					Vector2 a2 = new Vector2(vector2.x / vector3.x, vector2.y / vector3.y);
					spriteRenderer.size = Vector2.Scale(a2, b2);
					lastLossyScale = base.transform.lossyScale;
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}
}
