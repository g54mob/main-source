using UnityEngine;

public class WaterColor : MonoBehaviour
{
	public Color SurfaceColor = new Color(0.55f, 0.55f, 0.55f, 0.44f);

	public Color UnderColor = new Color(0.55f, 0.55f, 0.45f, 0.56f);

	[Header("Resources")]
	public MeshRenderer surface;

	public MeshRenderer under;

	private Material matSurf;

	private Material matUnd;

	private Vector2 offset1;

	private Vector2 offset2;

	private void Awake()
	{
		matSurf = new Material(surface.material);
		matUnd = new Material(under.material);
		matSurf.color = SurfaceColor;
		matUnd.color = UnderColor;
		surface.material = matSurf;
		under.material = matUnd;
	}

	private void Update()
	{
		offset1 = new Vector2(offset1.x + Time.deltaTime * 0.01f, offset1.y + Time.deltaTime * 0.02f);
		offset2 = new Vector2(offset2.x - Time.deltaTime * 0.02f, offset2.y - Time.deltaTime * 0.015f);
		surface.material.SetTextureOffset("_MainTex", offset1);
		surface.material.SetTextureOffset("_DetailAlbedoMap", offset2);
		under.material.SetTextureOffset("_MainTex", offset1);
		under.material.SetTextureOffset("_DetailAlbedoMap", offset2);
	}
}
