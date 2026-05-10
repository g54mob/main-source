using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class FogOfWarController : MonoBehaviour
{
	public static FogOfWarController instance;

	private const float VISIBLE_PIXEL_TRESHOLD = 0.3f;

	[SerializeField]
	private Camera fowCameraPrefab;

	[SerializeField]
	private RenderTexture fowRenderTexture_in;

	[SerializeField]
	private RenderTexture fowRenderTexture_out;

	[SerializeField]
	private Material fowMaterial;

	[SerializeField]
	private float cameraScale = 200f;

	[SerializeField]
	private Material gaussianBlurMaterial;

	[SerializeField]
	private bool createFowBorders = true;

	[SerializeField]
	private int borderSize = 5;

	[SerializeField]
	private GameObject fowBorderPrefab;

	[SerializeField]
	private GameObject lineRendererBorderPrefab;

	private Camera fowCamera;

	private Texture2D fowTexture;

	private bool wasFowActiveBeforePlay;

	private Coroutine delayedUpdateFOWCoroutine;

	private WaitForEndOfFrame waitEndFrame;

	[Header("Debug")]
	[SerializeField]
	private bool updateAlways;

	[SerializeField]
	private bool disableFog;

	[SerializeField]
	[Tooltip("Disables only the fog shaders but not the gameplay stuff")]
	private bool disableFogOnlyVisuals;

	public event Action<bool> onFogOfWarUpdated;

	private void Awake()
	{
		instance = this;
		wasFowActiveBeforePlay = Convert.ToBoolean(fowMaterial.GetInt("_Active"));
		Vector3 position = new Vector3(cameraScale - (float)borderSize, 20f, cameraScale - (float)borderSize);
		Quaternion rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
		fowCamera = UnityEngine.Object.Instantiate(fowCameraPrefab, position, rotation, base.transform);
		fowCamera.orthographicSize = cameraScale;
		fowCamera.enabled = false;
		ActivateFog(!disableFog);
		Shader.SetGlobalVector("_CameraPosition", new Vector2(fowCamera.transform.position.x, fowCamera.transform.position.z));
		Shader.SetGlobalFloat("_CameraScale", cameraScale);
		fowTexture = new Texture2D(fowRenderTexture_in.width, fowRenderTexture_in.height, GraphicsFormatUtility.GetTextureFormat(fowRenderTexture_in.graphicsFormat), mipChain: false);
		waitEndFrame = new WaitForEndOfFrame();
		UpdateFogOfWarInmediate();
		if (updateAlways)
		{
			StartCoroutine(DebugCoroutine());
		}
	}

	private void Start()
	{
		CreateFowBorders();
		UpdateFogOfWar();
	}

	public void CreateFowBorders()
	{
		if (!createFowBorders)
		{
			return;
		}
		int levelSizeX = LTFunctionLibrary.GetLTLevelController().LevelSizeX;
		int levelSizeZ = LTFunctionLibrary.GetLTLevelController().LevelSizeZ;
		GameObject gameObject = new GameObject("FOWBorders");
		gameObject.transform.SetParent(base.transform);
		float y = 0.2f;
		for (int i = 0; i < 4; i++)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate(fowBorderPrefab, gameObject.transform);
			LineRenderer component = UnityEngine.Object.Instantiate(lineRendererBorderPrefab, gameObject.transform).GetComponent<LineRenderer>();
			switch (i)
			{
			case 0:
				gameObject2.transform.position = new Vector3(levelSizeX, 10f, (float)levelSizeZ * 0.5f);
				gameObject2.transform.localScale = new Vector3(50f, 1f, levelSizeZ * 2);
				component.transform.position = new Vector3(0f, y, 0f);
				component.SetPosition(1, new Vector3(component.GetPosition(1).x, component.GetPosition(1).y, (float)levelSizeZ - 0.5f));
				break;
			case 1:
				gameObject2.transform.position = new Vector3(-1f, 10f, (float)levelSizeZ * 0.5f);
				gameObject2.transform.localScale = new Vector3(50f, 1f, levelSizeZ * 2);
				gameObject2.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
				component.transform.position = new Vector3(0f, y, levelSizeZ - 1);
				component.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
				component.SetPosition(1, new Vector3(component.GetPosition(1).x, component.GetPosition(1).y, (float)levelSizeX - 0.5f));
				break;
			case 2:
				gameObject2.transform.position = new Vector3((float)levelSizeX * 0.5f, 10f, -1f);
				gameObject2.transform.localScale = new Vector3(50f, 1f, levelSizeX * 2);
				gameObject2.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
				component.transform.position = new Vector3(levelSizeX - 1, y, levelSizeZ - 1);
				component.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
				component.SetPosition(1, new Vector3(component.GetPosition(1).x, component.GetPosition(1).y, (float)levelSizeZ - 0.5f));
				break;
			case 3:
				gameObject2.transform.position = new Vector3((float)levelSizeX * 0.5f, 10f, levelSizeZ);
				gameObject2.transform.localScale = new Vector3(50f, 1f, levelSizeX * 2);
				gameObject2.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
				component.transform.position = new Vector3(levelSizeX - 1, y, 0f);
				component.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
				component.SetPosition(1, new Vector3(component.GetPosition(1).x, component.GetPosition(1).y, (float)levelSizeX - 0.5f));
				break;
			}
		}
	}

	public void UpdateFogOfWar(bool importantUpdate = true)
	{
		this.StartCoroutineCheckingVar(DelayedFOWUpdateCoroutine(importantUpdate, instantUpdate: false), ref delayedUpdateFOWCoroutine);
	}

	private void UpdateFogOfWarInmediate(bool importantUpdate = true)
	{
		this.StartCoroutineCheckingVar(DelayedFOWUpdateCoroutine(importantUpdate, instantUpdate: true), ref delayedUpdateFOWCoroutine);
	}

	private IEnumerator DelayedFOWUpdateCoroutine(bool importantUpdate, bool instantUpdate)
	{
		if (!instantUpdate)
		{
			yield return waitEndFrame;
		}
		ActivateFog(activate: false);
		fowCamera.enabled = true;
		fowCamera.targetTexture = fowRenderTexture_in;
		fowCamera.Render();
		fowCamera.targetTexture = null;
		fowCamera.enabled = false;
		ActivateFog(activate: true);
		gaussianBlurMaterial.SetTexture("_Texture", fowRenderTexture_in);
		Graphics.Blit(null, fowRenderTexture_out, gaussianBlurMaterial);
		RenderTexture.active = fowRenderTexture_out;
		fowTexture.ReadPixels(new Rect(0f, 0f, fowRenderTexture_out.width, fowRenderTexture_out.height), 0, 0);
		fowTexture.Apply();
		RenderTexture.active = null;
		this.onFogOfWarUpdated?.Invoke(importantUpdate);
		delayedUpdateFOWCoroutine = null;
	}

	private void OnDestroy()
	{
		ActivateFog(wasFowActiveBeforePlay);
	}

	private void ActivateFog(bool activate)
	{
		if (!disableFog || !activate)
		{
			fowMaterial.SetInt("_Active", Convert.ToInt32(activate));
		}
	}

	public bool IsPositionVisible(Vector3 position)
	{
		if (disableFog && !disableFogOnlyVisuals)
		{
			return true;
		}
		if (GetFowTexturePixelValue(position) > 0.3f)
		{
			return true;
		}
		return false;
	}

	private float GetFowTexturePixelValue(Vector3 position)
	{
		int x = (int)((position.x + (float)borderSize) * (float)fowRenderTexture_in.width / (cameraScale * 2f));
		int y = (int)((position.z + (float)borderSize) * (float)fowRenderTexture_in.height / (cameraScale * 2f));
		return fowTexture.GetPixel(x, y).r;
	}

	private IEnumerator DebugCoroutine()
	{
		while (true)
		{
			UpdateFogOfWar();
			yield return null;
		}
	}
}
