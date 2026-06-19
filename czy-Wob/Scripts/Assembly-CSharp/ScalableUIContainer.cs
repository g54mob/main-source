using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScalableUIContainer
{
	public enum AnchorType
	{
		TOP = 0,
		RIGHT = 1,
		BOTTOM = 2,
		LEFT = 3
	}

	[HideInInspector]
	public delegate void LoadCallback();

	public Material bgMat;

	public Material barMat;

	public GameObject mainUIObjectPrefab;

	public bool sphericalBG;

	public bool containSelf;

	public List<AnchorType> anchors = new List<AnchorType>();

	private Transform selfTransform;

	private GameObject container;

	private GameObject bgObject;

	private GameObject barObjectTop;

	private GameObject barObjectBot;

	private GameObject barObjectLeft;

	private GameObject barObjectRight;

	private GameObject mainUIObject;

	private float baseZScale = 0.1f;

	private float baseZPosOffset = 5f;

	private float barZPos = -2f;

	private Vector3 UIPrefabScale = Vector3.one;

	private float sphericalBGScaleMultiplier = 1.3f;

	private Vector3 defaultScale = Vector3.zero;

	private int objsEasedIn;

	private int objsNeeded = 5;

	private float bgScaleInTime = 0.15f;

	private float bgScaleOutTime = 0.1f;

	private float barEaseInTime = 0.15f;

	private float barEaseOutTime = 0.1f;

	private LoadCallback loadedCallback;

	private LoadCallback unloadedCallback;

	private LoadCallback currentMainUIObjectCreatedCallback;

	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private Vector2 previousScreenSize = Vector2.zero;

	public void LoadSelfContainer(Transform selfTransform)
	{
		this.selfTransform = selfTransform;
		Load(null);
	}

	public void SetBaseZPosOffset(float newOffset)
	{
		baseZPosOffset = newOffset;
	}

	public GameObject GetMainUIObject()
	{
		return mainUIObject;
	}

	public Transform GetBGTransform()
	{
		return bgObject.transform;
	}

	public float GetDistanceScale(float defaultDist, Transform refTransform)
	{
		if (refTransform == null)
		{
			return 1f;
		}
		return (Vector3.Distance(Camera.main.transform.position, refTransform.position) - defaultDist) / defaultDist + 1f;
	}

	public void CheckCamScale(float defaultDist, Transform refTransform)
	{
		if (!(refTransform == null))
		{
			float distanceScale = GetDistanceScale(defaultDist, refTransform);
			bgObject.transform.localScale = defaultScale / distanceScale;
		}
	}

	public void CheckResize(bool forceResize = false)
	{
		if (currentStatus != ElementStatus.LOADED || (GUIManagerBase.GetAbsoluteScreenSize() == previousScreenSize && !forceResize))
		{
			return;
		}
		previousScreenSize = GUIManagerBase.GetAbsoluteScreenSize();
		Vector2 aspectSize = GUIManagerBase.GetAspectSize();
		Vector2 resolutionClampedAspectSize = GUIManagerBase.GetResolutionClampedAspectSize();
		Vector3 localScale = new Vector3(resolutionClampedAspectSize.x, resolutionClampedAspectSize.y, baseZScale);
		if (sphericalBG)
		{
			float num = Mathf.Max(resolutionClampedAspectSize.x, resolutionClampedAspectSize.y) * sphericalBGScaleMultiplier;
			localScale = new Vector3(num, num, baseZScale);
		}
		bgObject.transform.localScale = localScale;
		float num2 = Mathf.Max((aspectSize.x - resolutionClampedAspectSize.x) / 2f, 0f);
		float num3 = Mathf.Max((aspectSize.y - resolutionClampedAspectSize.y) / 2f, 0f);
		if (!containSelf)
		{
			barObjectTop.transform.localScale = new Vector3(resolutionClampedAspectSize.x, num3, baseZScale);
			barObjectBot.transform.localScale = new Vector3(resolutionClampedAspectSize.x, num3, baseZScale);
			barObjectLeft.transform.localScale = new Vector3(num2, resolutionClampedAspectSize.y, baseZScale);
			barObjectRight.transform.localScale = new Vector3(num2, resolutionClampedAspectSize.y, baseZScale);
			barObjectTop.transform.localPosition = new Vector3(0f, resolutionClampedAspectSize.y / 2f + num3 / 2f, barZPos);
			barObjectBot.transform.localPosition = new Vector3(0f, (0f - resolutionClampedAspectSize.y) / 2f - num3 / 2f, barZPos);
			barObjectLeft.transform.localPosition = new Vector3(resolutionClampedAspectSize.x / 2f + num2 / 2f, 0f, barZPos);
			barObjectRight.transform.localPosition = new Vector3((0f - resolutionClampedAspectSize.x) / 2f - num2 / 2f, 0f, barZPos);
		}
		else if (anchors.Count > 0)
		{
			float x = bgObject.transform.localPosition.x;
			float y = bgObject.transform.localPosition.y;
			float z = bgObject.transform.localPosition.z;
			if (anchors.Contains(AnchorType.TOP))
			{
				y = num3;
			}
			if (anchors.Contains(AnchorType.RIGHT))
			{
				x = num2;
			}
			if (anchors.Contains(AnchorType.BOTTOM))
			{
				y = 0f - num3;
			}
			if (anchors.Contains(AnchorType.LEFT))
			{
				x = 0f - num2;
			}
			bgObject.transform.localPosition = new Vector3(x, y, z);
		}
	}

	public void Load(LoadCallback callback, LoadCallback mainUIObjectCreatedCallback = null)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Cannot load an element container if it isn't unloaded.");
			return;
		}
		currentStatus = ElementStatus.LOADING;
		loadedCallback = callback;
		currentMainUIObjectCreatedCallback = mainUIObjectCreatedCallback;
		LoadBGGraphics();
	}

	public void Unload(LoadCallback callback = null)
	{
		if (currentStatus != ElementStatus.LOADED)
		{
			Debug.LogError("Cannot unload an element container if it isn't loaded.");
			return;
		}
		currentStatus = ElementStatus.UNLOADING;
		unloadedCallback = callback;
		UnloadElements();
	}

	private GameObject CreateRectOfColor(Material mat)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		gameObject.layer = LayerMask.NameToLayer("UI");
		UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
		gameObject.GetComponent<MeshRenderer>().material = mat;
		gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
		gameObject.transform.Rotate(0f, 180f, 0f);
		return gameObject;
	}

	private GameObject CreateSphereOfColor(Material mat)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		gameObject.layer = LayerMask.NameToLayer("UI");
		UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
		gameObject.GetComponent<MeshRenderer>().material = mat;
		gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
		gameObject.transform.Rotate(0f, 180f, 0f);
		return gameObject;
	}

	private void LoadBGGraphics()
	{
		container = new GameObject("ScalableUI_Container");
		if (!containSelf)
		{
			if (sphericalBG)
			{
				bgObject = CreateSphereOfColor(bgMat);
			}
			else
			{
				bgObject = CreateRectOfColor(bgMat);
			}
			barObjectTop = CreateRectOfColor(barMat);
			barObjectBot = CreateRectOfColor(barMat);
			barObjectLeft = CreateRectOfColor(barMat);
			barObjectRight = CreateRectOfColor(barMat);
			bgObject.transform.SetParent(container.transform);
			barObjectTop.transform.SetParent(container.transform);
			barObjectBot.transform.SetParent(container.transform);
			barObjectLeft.transform.SetParent(container.transform);
			barObjectRight.transform.SetParent(container.transform);
			bgObject.transform.localScale = Vector3.zero;
		}
		else
		{
			container.transform.SetParent(selfTransform.parent);
			bgObject = new GameObject("bgObject");
			bgObject.transform.SetParent(container.transform);
		}
		Vector2 aspectSize = GUIManagerBase.GetAspectSize();
		Vector2 resolutionClampedAspectSize = GUIManagerBase.GetResolutionClampedAspectSize();
		Vector3 position = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA).transform.position;
		Vector3 targetScale = new Vector3(resolutionClampedAspectSize.x, resolutionClampedAspectSize.y, baseZScale);
		if (sphericalBG)
		{
			float num = Mathf.Max(resolutionClampedAspectSize.x, resolutionClampedAspectSize.y) * sphericalBGScaleMultiplier;
			targetScale = new Vector3(num, num, baseZScale);
		}
		if (!containSelf)
		{
			float num2 = Mathf.Max((aspectSize.x - resolutionClampedAspectSize.x) / 2f, 0f);
			float num3 = Mathf.Max((aspectSize.y - resolutionClampedAspectSize.y) / 2f, 0f);
			barObjectTop.transform.localScale = new Vector3(resolutionClampedAspectSize.x, num3, baseZScale);
			barObjectBot.transform.localScale = new Vector3(resolutionClampedAspectSize.x, num3, baseZScale);
			barObjectLeft.transform.localScale = new Vector3(num2, resolutionClampedAspectSize.y, baseZScale);
			barObjectRight.transform.localScale = new Vector3(num2, resolutionClampedAspectSize.y, baseZScale);
			barObjectTop.transform.localPosition = new Vector3(0f, resolutionClampedAspectSize.y / 2f + num3 / 2f, barZPos);
			barObjectBot.transform.localPosition = new Vector3(0f, (0f - resolutionClampedAspectSize.y) / 2f - num3 / 2f, barZPos);
			barObjectLeft.transform.localPosition = new Vector3(resolutionClampedAspectSize.x / 2f + num2 / 2f, 0f, barZPos);
			barObjectRight.transform.localPosition = new Vector3((0f - resolutionClampedAspectSize.x) / 2f - num2 / 2f, 0f, barZPos);
		}
		container.transform.position = position + new Vector3(0f, 0f, baseZPosOffset);
		float num4 = GUIManagerBase.imagePPU / GUIManagerBase.UIAspectResolution.y * resolutionClampedAspectSize.y;
		UIPrefabScale = new Vector3(num4, num4, baseZScale);
		if (containSelf)
		{
			Vector2 idealAspectSize = GUIManagerBase.GetIdealAspectSize();
			bgObject.transform.localScale = new Vector3(idealAspectSize.x, idealAspectSize.y, baseZScale);
			selfTransform.SetParent(bgObject.transform);
		}
		if (!containSelf)
		{
			Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
			List<GameObject> objectsToEase = new List<GameObject> { barObjectTop };
			List<GameObject> objectsToEase2 = new List<GameObject> { barObjectBot };
			List<GameObject> objectsToEase3 = new List<GameObject> { barObjectLeft };
			List<GameObject> objectsToEase4 = new List<GameObject> { barObjectRight };
			globalComponent.RequestEaseToScale(bgObject, targetScale, bgScaleInTime, Inchworm.EaseStyle.QuadraticOut, OnBGGraphicEasedIn);
			globalComponent.RequestEase(objectsToEase, new Vector3(0f, 0f - barObjectTop.transform.localScale.y, 0f), barEaseInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedIn);
			globalComponent.RequestEase(objectsToEase2, new Vector3(0f, barObjectBot.transform.localScale.y, 0f), barEaseInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedIn);
			globalComponent.RequestEase(objectsToEase3, new Vector3(0f - barObjectLeft.transform.localScale.x, 0f, 0f), barEaseInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedIn);
			globalComponent.RequestEase(objectsToEase4, new Vector3(barObjectRight.transform.localScale.x, 0f, 0f), barEaseInTime, adjustStartingPos: true, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedIn);
		}
		else
		{
			LoadElements();
		}
		if (!containSelf)
		{
			previousScreenSize = GUIManagerBase.GetAbsoluteScreenSize();
		}
		CheckResize(forceResize: true);
		defaultScale = bgObject.transform.localScale;
	}

	private void OnBGGraphicEasedIn()
	{
		objsEasedIn++;
		if (objsEasedIn >= objsNeeded)
		{
			OnBGGraphicsLoaded();
		}
	}

	private void OnBGGraphicsLoaded()
	{
		LoadElements();
	}

	private void UnloadBGGraphics()
	{
		Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		List<GameObject> objectsToEase = new List<GameObject> { barObjectTop };
		List<GameObject> objectsToEase2 = new List<GameObject> { barObjectBot };
		List<GameObject> objectsToEase3 = new List<GameObject> { barObjectLeft };
		List<GameObject> objectsToEase4 = new List<GameObject> { barObjectRight };
		globalComponent.RequestEaseToScale(bgObject, Vector3.zero, bgScaleOutTime, Inchworm.EaseStyle.QuadraticOut, OnBGGraphicEasedOut);
		globalComponent.RequestEase(objectsToEase, new Vector3(0f, barObjectTop.transform.localScale.y, 0f), barEaseOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedOut);
		globalComponent.RequestEase(objectsToEase2, new Vector3(0f, 0f - barObjectBot.transform.localScale.y, 0f), barEaseOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedOut);
		globalComponent.RequestEase(objectsToEase3, new Vector3(barObjectLeft.transform.localScale.x, 0f, 0f), barEaseOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedOut);
		globalComponent.RequestEase(objectsToEase4, new Vector3(0f - barObjectRight.transform.localScale.x, 0f, 0f), barEaseOutTime, adjustStartingPos: false, Inchworm.EaseStyle.QuadraticOut, Inchworm.EaseType.Position, OnBGGraphicEasedOut);
	}

	private void OnBGGraphicEasedOut()
	{
		objsEasedIn--;
		if (objsEasedIn <= 0)
		{
			BGGraphicsEasedOutCallback();
		}
	}

	private void BGGraphicsEasedOutCallback()
	{
		UnityEngine.Object.Destroy(bgObject);
		UnityEngine.Object.Destroy(barObjectTop);
		UnityEngine.Object.Destroy(barObjectBot);
		UnityEngine.Object.Destroy(barObjectLeft);
		UnityEngine.Object.Destroy(barObjectRight);
		UnityEngine.Object.Destroy(container);
		currentStatus = ElementStatus.UNLOADED;
		if (unloadedCallback != null)
		{
			unloadedCallback();
			unloadedCallback = null;
		}
	}

	private void LoadElements()
	{
		if (!containSelf)
		{
			mainUIObject = UnityEngine.Object.Instantiate(mainUIObjectPrefab);
			mainUIObject.transform.localScale = UIPrefabScale;
			mainUIObject.transform.SetParent(bgObject.transform);
			mainUIObject.transform.localPosition = new Vector3(0f, 0f, baseZPosOffset);
			MainObjectCreatedCallback();
			mainUIObject.GetComponentInChildren<UICoreBase>().Load(AllElementsLoadedCallback);
		}
		else
		{
			mainUIObject = new GameObject("MainUIObject");
			mainUIObject.transform.localScale = UIPrefabScale;
			mainUIObject.transform.SetParent(bgObject.transform);
			MainObjectCreatedCallback();
			AllElementsLoadedCallback();
		}
	}

	private void UnloadElements()
	{
		mainUIObject.GetComponentInChildren<UICoreBase>().Unload(AllElementsUnloadedCallback);
	}

	private void AllElementsLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
		if (loadedCallback != null)
		{
			loadedCallback();
			loadedCallback = null;
		}
	}

	private void MainObjectCreatedCallback()
	{
		if (currentMainUIObjectCreatedCallback != null)
		{
			currentMainUIObjectCreatedCallback();
			currentMainUIObjectCreatedCallback = null;
		}
	}

	private void AllElementsUnloadedCallback()
	{
		UnityEngine.Object.Destroy(mainUIObject);
		UnloadBGGraphics();
	}
}
