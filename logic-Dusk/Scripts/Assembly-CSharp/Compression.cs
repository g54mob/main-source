using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Compression")]
public class Compression : ImageEffectBase
{
	private RenderTexture accumTexture;

	public CCTexture flow;

	public CCTexture stop;

	public Vector2 offset;

	public float fade = 0.9f;

	public bool radial = true;

	public float angle;

	public float anglePerSecond;

	public Transform center;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (accumTexture == null || accumTexture.width != source.width || accumTexture.height != source.height)
		{
			Object.DestroyImmediate(accumTexture);
			accumTexture = new RenderTexture(source.width, source.height, 0);
			accumTexture.hideFlags = HideFlags.HideAndDontSave;
			Graphics.Blit(source, accumTexture);
		}
		accumTexture.MarkRestoreExpected();
		angle += anglePerSecond * Time.deltaTime;
		flow.Update();
		stop.Update();
		Vector3 position = new Vector3(center.position.x, center.position.y, center.position.z);
		position = GetComponent<Camera>().WorldToViewportPoint(position);
		base.material.SetVector("_center", new Vector4(position.x, position.y, position.z, 0f));
		base.material.SetVector("_x", new Vector4(offset.x, offset.y, angle, fade));
		base.material.SetTexture("_Last", accumTexture);
		base.material.SetTexture("_Flow", flow.texture);
		base.material.SetVector("_Flow_ST", flow.scaleTranslate);
		base.material.SetTexture("_Stop", stop.texture);
		base.material.SetVector("_Stop_ST", stop.scaleTranslate);
		if (radial)
		{
			Shader.EnableKeyword("radial");
			Shader.DisableKeyword("nradial");
		}
		else
		{
			Shader.EnableKeyword("nradial");
			Shader.DisableKeyword("radial");
		}
		Graphics.Blit(source, accumTexture, base.material);
		Graphics.Blit(accumTexture, destination);
	}
}
