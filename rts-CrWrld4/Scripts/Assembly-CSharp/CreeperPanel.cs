using System;
using UnityEngine;

public class CreeperPanel : MonoBehaviour
{
	private Panel panel;

	private Mesh mesh;

	private Vector3[] vertices;

	private Vector3[] normals;

	private Vector2[] uvs;

	private Color32[] colors;

	private int[] tris;

	private Color32 deflectColor;

	private Color32 whiteColor;

	private Color32 neutralColor;

	private Color32 blackColor;

	private Color32 purpleColor;

	private Color32 yellowColor;

	private Color32 greenColor;

	private Color32 blueColor;

	private Color32 grayColor;

	private Color32 whiteDarkColor;

	private Color32 neutralDarkColor;

	private Color32 purpleDarkColor;

	private Color32 yellowDarkColor;

	private Color32 greenDarkColor;

	private Color32 blueDarkColor;

	private Color32 acColor1;

	private Color32 purpleColorFog;

	private Color32 acColor1Fog;

	private Color32 blueColorFog;

	private int offsetX;

	private int offsetY;

	[NonSerialized]
	public bool dirty;

	private bool borders;

	private int startVertex1;

	private int startVertex2;

	private int startVertex3;

	private int startVertex4;

	private int startCornerVertex;

	private int width;

	private int height;

	private float[] running;

	private const float threehalfs = 1.5f;

	public bool useRunning;

	public void Init(Panel panel)
	{
	}

	public Vector3 GetVertex(int cellX, int cellY)
	{
		return default(Vector3);
	}

	private float Q_rsqrt(float number)
	{
		return 0f;
	}

	private float GetCreeperScreenHeight(int x, int y)
	{
		return 0f;
	}

	public void Refresh(bool forceRefresh)
	{
	}

	public static float GetCreeperScreenHeightFromCoords(int cx, int cy, bool allowFlatten, bool ignoreAC = false, bool ignoreC = false, float zeroBias = -0.005f)
	{
		return 0f;
	}

	public static float GetCreeperScreenHeight(float c, float t, bool allowFlatten, bool ignoreAC = false, bool ignoreC = false, float zeroBias = -0.005f)
	{
		return 0f;
	}

	private Vector3 GetVertex2(int x, int y)
	{
		return default(Vector3);
	}

	public void DestroyPanel()
	{
	}
}
