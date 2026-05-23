using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;
using UnityEngine.UI;

public class PaintUI : MonoBehaviour
{
	[SerializeField]
	private GameObject colorPrefab;

	[SerializeField]
	private GameObject decalPrefab;

	[SerializeField]
	private GameObject colorUI;

	[SerializeField]
	private GameObject decalUI;

	[SerializeField]
	private GameObject colorPos;

	[SerializeField]
	private GameObject decalPos;

	[SerializeField]
	private Slider brushSizeSlider;

	[SerializeField]
	private Slider decalRotationSlider;

	[SerializeField]
	private Toggle brushTargetAll;

	[SerializeField]
	private Toggle brushTargetHead;

	[SerializeField]
	private Toggle brushTargeBody;

	[SerializeField]
	private Toggle brushTargeWing;

	[SerializeField]
	private Toggle brushTargeNozzle;

	[SerializeField]
	private GameObject painterGO;

	[SerializeField]
	private CwPaintSphere paintSphere;

	[SerializeField]
	private CwPaintDecal decalSphere;

	private GameObject currentSelectedColorGO;

	private Rocket rocket;

	private List<Color> unlockedColors = new List<Color>();

	private List<Sprite> unlockedDecals = new List<Sprite>();

	private List<Texture2D> activeDecals = new List<Texture2D>();

	private int maxCacheCount = 10;

	private void Awake()
	{
		LoadData();
	}

	private void Start()
	{
		if (brushSizeSlider != null)
		{
			brushSizeSlider.onValueChanged.AddListener(OnSliderValueChangedPaint);
		}
		if (decalRotationSlider != null)
		{
			decalRotationSlider.onValueChanged.AddListener(OnSliderValueChangedDecal);
		}
		brushTargetAll.onValueChanged.AddListener(OnToggleValueChangedTargetAll);
		brushTargetHead.onValueChanged.AddListener(OnToggleValueChangedTargetHead);
		brushTargeBody.onValueChanged.AddListener(OnToggleValueChangedTargetBody);
		brushTargeWing.onValueChanged.AddListener(OnToggleValueChangedTargetWing);
		brushTargeNozzle.onValueChanged.AddListener(OnToggleValueChangedTargetNozzle);
		GameManager.S.OnPaintingTable += S_OnPaintingTable;
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		paintSphere.Radius = 0.05f;
		decalSphere.Radius = 0.15f;
		decalSphere.Angle = 0f;
		StickerMachine.OnNewDecalUnlocked += StickerMachine_OnNewDecalUnlocked;
		Paint.OnNewColorUnlocked += Paint_OnNewColorUnlocked;
		base.gameObject.SetActive(value: false);
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		ES3.Save("unlockedColors", unlockedColors);
		ES3.Save("unlockedDecals", unlockedDecals);
	}

	private void LoadData()
	{
		unlockedColors = ES3.Load("unlockedColors", new List<Color>());
		unlockedDecals = ES3.Load("unlockedDecals", new List<Sprite>());
		foreach (Color unlockedColor in unlockedColors)
		{
			CreateColorUI(unlockedColor);
		}
		foreach (Sprite unlockedDecal in unlockedDecals)
		{
			CreateDecalUI(unlockedDecal);
		}
	}

	private void Paint_OnNewColorUnlocked(Color obj)
	{
		if (!unlockedColors.Contains(obj))
		{
			unlockedColors.Add(obj);
			CreateColorUI(obj);
		}
	}

	private void StickerMachine_OnNewDecalUnlocked(Sprite obj)
	{
		if (!unlockedDecals.Contains(obj))
		{
			unlockedDecals.Add(obj);
			CreateDecalUI(obj);
		}
	}

	private void CreateColorUI(Color color)
	{
		GameObject colorGO = Object.Instantiate(colorPrefab, colorPos.transform);
		colorGO.GetComponent<Image>().color = color;
		colorGO.GetComponent<Button>().onClick.AddListener(delegate
		{
			ColorSelected(colorGO);
		});
	}

	private void CreateDecalUI(Sprite sprite)
	{
		GameObject newDecalGO = Object.Instantiate(decalPrefab, decalPos.transform);
		Image component = newDecalGO.transform.GetChild(1).GetComponent<Image>();
		component.sprite = sprite;
		component.SetNativeSize();
		newDecalGO.GetComponent<Button>().onClick.AddListener(delegate
		{
			DecalSelected(newDecalGO);
		});
	}

	private void OnDestroy()
	{
		GameManager.S.OnPaintingTable -= S_OnPaintingTable;
		StickerMachine.OnNewDecalUnlocked -= StickerMachine_OnNewDecalUnlocked;
		Paint.OnNewColorUnlocked -= Paint_OnNewColorUnlocked;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void S_OnPaintingTable(Rocket obj)
	{
		rocket = obj;
		OnUI();
	}

	public void OnSliderValueChangedPaint(float value)
	{
		paintSphere.Radius = value * 0.1f;
		decalSphere.Radius = value * 0.3f;
	}

	public void OnSliderValueChangedDecal(float value)
	{
		decalSphere.Angle = value;
	}

	private void OnToggleValueChangedTargetAll(bool isOn)
	{
		if (isOn)
		{
			rocket.rocketBody.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			if (rocket.cameraModule != null)
			{
				rocket.cameraModule.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			}
			rocket.head.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			rocket.rocketNozzle.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			if (rocket.rocketWing == null)
			{
				return;
			}
			{
				foreach (GameObject item in rocket.rocketWing)
				{
					item.GetComponentInChildren<CwPaintableMesh>().enabled = true;
				}
				return;
			}
		}
		if (!brushTargetHead.isOn)
		{
			rocket.head.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
		if (!brushTargeBody.isOn)
		{
			rocket.rocketBody.GetComponentInChildren<CwPaintableMesh>().enabled = false;
			if (rocket.cameraModule != null)
			{
				rocket.cameraModule.GetComponentInChildren<CwPaintableMesh>().enabled = false;
			}
		}
		if (!brushTargeNozzle.isOn)
		{
			rocket.rocketNozzle.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
		if (brushTargeWing.isOn || rocket.rocketWing == null)
		{
			return;
		}
		foreach (GameObject item2 in rocket.rocketWing)
		{
			item2.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
	}

	private void OnToggleValueChangedTargetHead(bool isOn)
	{
		if (isOn)
		{
			rocket.head.GetComponentInChildren<CwPaintableMesh>().enabled = true;
		}
		else if (!brushTargetAll.isOn)
		{
			rocket.head.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
	}

	private void OnToggleValueChangedTargetBody(bool isOn)
	{
		if (isOn)
		{
			rocket.rocketBody.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			if (rocket.cameraModule != null)
			{
				rocket.cameraModule.GetComponentInChildren<CwPaintableMesh>().enabled = true;
			}
		}
		else if (!brushTargetAll.isOn)
		{
			rocket.rocketBody.GetComponentInChildren<CwPaintableMesh>().enabled = false;
			if (rocket.cameraModule != null)
			{
				rocket.cameraModule.GetComponentInChildren<CwPaintableMesh>().enabled = false;
			}
		}
	}

	private void OnToggleValueChangedTargetNozzle(bool isOn)
	{
		if (isOn)
		{
			rocket.rocketNozzle.GetComponentInChildren<CwPaintableMesh>().enabled = true;
		}
		else if (!brushTargetAll.isOn)
		{
			rocket.rocketNozzle.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
	}

	private void OnToggleValueChangedTargetWing(bool isOn)
	{
		if (isOn)
		{
			if (rocket.rocketWing == null)
			{
				return;
			}
			{
				foreach (GameObject item in rocket.rocketWing)
				{
					item.GetComponentInChildren<CwPaintableMesh>().enabled = true;
				}
				return;
			}
		}
		if (brushTargetAll.isOn || rocket.rocketWing == null)
		{
			return;
		}
		foreach (GameObject item2 in rocket.rocketWing)
		{
			item2.GetComponentInChildren<CwPaintableMesh>().enabled = false;
		}
	}

	public void PaintingDong()
	{
		AudioManager.S.PlaySFX(AudioManager.S.craftingTableDone);
		GameManager.S.PaintingDone();
		GameManager.S.OnPlayerUI();
		OffUI();
	}

	private void OnUI()
	{
		base.gameObject.SetActive(value: true);
		CategorySelected(0);
		brushTargetAll.isOn = true;
		brushTargeBody.isOn = true;
		brushTargeNozzle.isOn = false;
		brushTargetHead.isOn = false;
		brushTargeWing.isOn = false;
	}

	public void CategorySelected(int index)
	{
		switch (index)
		{
		case 0:
			colorUI.SetActive(value: true);
			decalUI.SetActive(value: false);
			ColorSelected(colorPos.transform.GetChild(0).gameObject);
			break;
		case 1:
			colorUI.SetActive(value: false);
			decalUI.SetActive(value: true);
			DecalSelected(decalPos.transform.GetChild(0).gameObject);
			break;
		}
	}

	private void OffUI()
	{
		base.gameObject.SetActive(value: false);
	}

	public Texture2D SpriteToCenteredTexture2D(Sprite sprite, int targetWidth, int targetHeight)
	{
		int x = Mathf.FloorToInt(sprite.textureRect.x);
		int y = Mathf.FloorToInt(sprite.textureRect.y);
		int num = Mathf.FloorToInt(sprite.textureRect.width);
		int num2 = Mathf.FloorToInt(sprite.textureRect.height);
		Texture2D texture2D = new Texture2D(targetWidth, targetHeight, TextureFormat.RGBA32, mipChain: false);
		Color[] array = new Color[targetWidth * targetHeight];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Color.clear;
		}
		texture2D.SetPixels(array);
		int b = (targetWidth - num) / 2;
		int b2 = (targetHeight - num2) / 2;
		int blockWidth = Mathf.Min(num, targetWidth);
		int blockHeight = Mathf.Min(num2, targetHeight);
		b = Mathf.Max(0, b);
		b2 = Mathf.Max(0, b2);
		Color[] pixels = sprite.texture.GetPixels(x, y, blockWidth, blockHeight);
		texture2D.SetPixels(b, b2, blockWidth, blockHeight, pixels);
		texture2D.Apply();
		return texture2D;
	}

	public void DecalSelected(GameObject go)
	{
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
		Image component = go.transform.GetChild(1).GetComponent<Image>();
		Texture2D texture2D = SpriteToCenteredTexture2D(component.sprite, 700, 550);
		decalSphere.Texture = texture2D;
		activeDecals.Add(texture2D);
		if (activeDecals.Count > maxCacheCount)
		{
			Texture2D obj = activeDecals[0];
			activeDecals.RemoveAt(0);
			Object.Destroy(obj);
		}
		go.transform.GetChild(0).gameObject.SetActive(value: true);
		if (currentSelectedColorGO != null && currentSelectedColorGO != go)
		{
			currentSelectedColorGO.transform.GetChild(0).gameObject.SetActive(value: false);
		}
		currentSelectedColorGO = go.gameObject;
	}

	public void ColorSelected(GameObject colorGO)
	{
		AudioManager.S.PlaySFX(AudioManager.S.uiClicked);
		Image component = colorGO.GetComponent<Image>();
		Color color = component.color;
		paintSphere.Color = color;
		component.transform.GetChild(0).gameObject.SetActive(value: true);
		if (currentSelectedColorGO != null && currentSelectedColorGO != colorGO)
		{
			currentSelectedColorGO.transform.GetChild(0).gameObject.SetActive(value: false);
		}
		currentSelectedColorGO = colorGO;
	}
}
