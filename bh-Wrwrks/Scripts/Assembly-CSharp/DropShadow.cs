using UnityEngine;

public class DropShadow : MonoBehaviour
{
	private SpriteRenderer parent;

	public SpriteRenderer spriteRenderer;

	public Vector3 offset = new Vector3(-0.125f, -0.125f);

	private GameObject shadow;

	public bool enableCustomColor;

	public Color customColor = new Color(0.05490196f, 0.02745098f, 0.1058824f, 1f);

	public int layerGap = 1;

	public string customLayer = "";

	public bool jonn;

	private Vector3 o;

	private void Start()
	{
		parent = GetComponent<SpriteRenderer>();
		shadow = new GameObject("dropshadow_" + base.gameObject.name);
		spriteRenderer = shadow.AddComponent<SpriteRenderer>();
		spriteRenderer.enabled = parent.enabled;
		if (jonn)
		{
			spriteRenderer.sortingLayerName = "Widget";
		}
		else
		{
			spriteRenderer.sortingLayerName = parent.sortingLayerName;
		}
		spriteRenderer.sortingOrder = parent.sortingOrder - layerGap;
		spriteRenderer.material = Dungeon.Instance.shadowMat;
		spriteRenderer.color = new Color(0.05490196f, 0.02745098f, 0.1058824f, parent.color.a);
		if (enableCustomColor)
		{
			spriteRenderer.color = new Color(customColor.r, customColor.g, customColor.b, parent.color.a);
		}
		spriteRenderer.maskInteraction = parent.maskInteraction;
		spriteRenderer.drawMode = parent.drawMode;
		shadow.transform.parent = base.transform;
		shadow.transform.position = base.transform.position + offset;
		spriteRenderer.transform.localEulerAngles = Vector3.zero;
		shadow.transform.localScale = Vector3.one;
		if (spriteRenderer.drawMode == SpriteDrawMode.Tiled || spriteRenderer.drawMode == SpriteDrawMode.Sliced)
		{
			spriteRenderer.size = parent.size;
		}
	}

	private void Update()
	{
		o = offset;
		if (jonn)
		{
			spriteRenderer.sortingLayerName = "Widget";
		}
		if (jonn)
		{
			Dungeon.Instance.waveText.text = spriteRenderer.sortingLayerName + " " + spriteRenderer.sortingOrder;
		}
		if (customLayer != "")
		{
			spriteRenderer.sortingLayerName = customLayer;
		}
		else
		{
			spriteRenderer.sortingLayerName = parent.sortingLayerName;
		}
		shadow.transform.position = base.transform.position + o;
		spriteRenderer.sprite = parent.sprite;
		spriteRenderer.enabled = parent.enabled;
		if (enableCustomColor)
		{
			spriteRenderer.color = new Color(customColor.r, customColor.g, customColor.b, parent.color.a);
		}
		else
		{
			spriteRenderer.color = new Color(0.05490196f, 0.02745098f, 0.1058824f, parent.color.a);
		}
		spriteRenderer.flipX = parent.flipX;
		spriteRenderer.flipY = parent.flipY;
		spriteRenderer.sortingOrder = parent.sortingOrder - layerGap;
		if (spriteRenderer.drawMode == SpriteDrawMode.Tiled || spriteRenderer.drawMode == SpriteDrawMode.Sliced)
		{
			spriteRenderer.size = parent.size;
		}
	}
}
