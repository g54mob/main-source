using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinimapThumbnailMaker : MonoBehaviour
{
	public enum ThumbSize
	{
		Big = 0,
		Small = 1
	}

	public Camera Cam;

	public static MinimapThumbnailMaker Instance;

	public MiniMapMaker MinimapMaker;

	public Material BlitMat;

	public Light light;

	private RenderTexture BigTex;

	private RenderTexture SmallTex;

	public GameObject MapRoot;

	public GameObject City;

	public GameObject Town;

	public GameObject Rural;

	public GameObject SmallDensTemperate;

	public GameObject SmallDensWarm;

	public GameObject SmallDensCold;

	public GameObject HighDensTemperate;

	public GameObject HighDensWarm;

	public GameObject HighDensCold;

	public GameObject Snow;

	public GameObject Grass;

	public GameObject Desert;

	private void Awake()
	{
		if (Instance != null)
		{
			Instance.light.intensity = light.intensity;
			Object.Destroy(base.gameObject);
			return;
		}
		BigTex = new RenderTexture(512, 512, 16)
		{
			antiAliasing = 1,
			autoGenerateMips = false,
			filterMode = FilterMode.Point
		};
		SmallTex = new RenderTexture(256, 256, 16)
		{
			antiAliasing = 1,
			autoGenerateMips = false,
			filterMode = FilterMode.Point
		};
		Object.DontDestroyOnLoad(base.gameObject);
		Instance = this;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Color Blend(int x, int y, int size, int w, int h, Color[] cs)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		int num5 = 0;
		for (int i = x - size / 2; i < x + size / 2; i++)
		{
			for (int j = y - size / 2; j < y + size / 2; j++)
			{
				if (i >= 0 && i < w && j >= 0 && j < h)
				{
					Color color = cs[i + j * w];
					num += color.a;
					num2 += color.r;
					num3 += color.g;
					num4 += color.b;
					num5++;
				}
			}
		}
		return new Color(num2 / num, num3 / num, num4 / num, num / (float)num5);
	}

	public void RenderMap(GameData.ClimateType cli, GameData.EnvironmentType env, Texture2D tex)
	{
		MapRoot.SetActive(true);
		City.SetActive(env == GameData.EnvironmentType.City);
		Town.SetActive(env == GameData.EnvironmentType.Town);
		Rural.SetActive(env == GameData.EnvironmentType.Rural);
		SmallDensTemperate.SetActive(env != GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Temperate);
		SmallDensWarm.SetActive(env != GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Warm);
		SmallDensCold.SetActive(env != GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Cold);
		HighDensTemperate.SetActive(env == GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Temperate);
		HighDensWarm.SetActive(env == GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Warm);
		HighDensCold.SetActive(env == GameData.EnvironmentType.Rural && cli == GameData.ClimateType.Cold);
		Snow.SetActive(cli == GameData.ClimateType.Cold);
		Grass.SetActive(cli == GameData.ClimateType.Temperate);
		Desert.SetActive(cli == GameData.ClimateType.Warm);
		RenderObject(MapRoot.gameObject, ThumbSize.Big, tex);
		MapRoot.SetActive(false);
	}

	public void RenderObject(GameObject obj, ThumbSize size, RenderTexture rendTex)
	{
		light.enabled = true;
		RenderTexture active = RenderTexture.active;
		Cam.targetTexture = (RenderTexture.active = ((size == ThumbSize.Big) ? BigTex : SmallTex));
		Dictionary<Renderer, KeyValuePair<int, bool>> dictionary = obj.GetComponentsInChildren<Renderer>().ToDictionary((Renderer x) => x, (Renderer x) => new KeyValuePair<int, bool>(x.gameObject.layer, x.enabled));
		foreach (KeyValuePair<Renderer, KeyValuePair<int, bool>> item in dictionary)
		{
			item.Key.gameObject.layer = 9;
			item.Key.enabled = true;
		}
		Cam.Render();
		Cam.Render();
		foreach (KeyValuePair<Renderer, KeyValuePair<int, bool>> item2 in dictionary)
		{
			item2.Key.gameObject.layer = item2.Value.Key;
			item2.Key.enabled = item2.Value.Value;
		}
		int num = ((size == ThumbSize.Big) ? 256 : 128);
		BlitMat.SetFloat("_inputSize", num * 2);
		Graphics.Blit(Cam.targetTexture, rendTex, BlitMat);
		RenderTexture.active = active;
		light.enabled = false;
	}

	public Texture2D RenderObject(GameObject obj, ThumbSize size, Texture2D finalTex = null)
	{
		light.enabled = true;
		RenderTexture active = RenderTexture.active;
		Cam.targetTexture = (RenderTexture.active = ((size == ThumbSize.Big) ? BigTex : SmallTex));
		Dictionary<Renderer, KeyValuePair<int, bool>> dictionary = obj.GetComponentsInChildren<Renderer>().ToDictionary((Renderer x) => x, (Renderer x) => new KeyValuePair<int, bool>(x.gameObject.layer, x.enabled));
		foreach (KeyValuePair<Renderer, KeyValuePair<int, bool>> item in dictionary)
		{
			item.Key.gameObject.layer = 9;
			item.Key.enabled = true;
		}
		Cam.Render();
		Cam.Render();
		foreach (KeyValuePair<Renderer, KeyValuePair<int, bool>> item2 in dictionary)
		{
			item2.Key.gameObject.layer = item2.Value.Key;
			item2.Key.enabled = item2.Value.Value;
		}
		int num = ((size == ThumbSize.Big) ? 256 : 128);
		RenderTexture renderTexture2 = new RenderTexture(num, num, 16, RenderTextureFormat.ARGB32);
		BlitMat.SetFloat("_inputSize", num * 2);
		Graphics.Blit(Cam.targetTexture, renderTexture2, BlitMat);
		if (finalTex == null)
		{
			finalTex = new Texture2D(num, num, TextureFormat.ARGB32, false);
		}
		RenderTexture.active = renderTexture2;
		finalTex.ReadPixels(new Rect(0f, 0f, num, num), 0, 0);
		finalTex.Apply(false);
		RenderTexture.active = active;
		Object.Destroy(renderTexture2);
		light.enabled = false;
		return finalTex;
	}
}
