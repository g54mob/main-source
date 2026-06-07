using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialEditorWindow : MonoBehaviour
{
	public Button ButtonPrefab;

	public GUIWindow Window;

	[NonSerialized]
	private RoomMaterialPack _activePack;

	[NonSerialized]
	private RoomMaterialController.WallMaterial _activeMat;

	public Transform ButtonPanel;

	public RawImage MainImg;

	public RawImage NormalImg;

	public RawImage OcclusionImg;

	public RawImage SmoothImg;

	public RawImage ColorImg;

	public RawImage SnowRainImg;

	private Texture2D MainTex;

	private Texture2D NormalTex;

	private Texture2D OcclusionTex;

	private Texture2D SmoothTex;

	private Texture2D ColorTex;

	private Texture2D SnowRainTex;

	public Material PreviewMat;

	public Material HeightMapper;

	public GameObject MaterialCamera;

	public Toggle OcclusionImage;

	public Toggle SmoothImage;

	public Toggle SnowRainImage;

	public Toggle Skirt;

	public Slider OcclusionSlider;

	public Slider SnowRainSlider;

	public Slider SmoothSlider;

	public Slider ActiveSnowSlider;

	public Slider ActiveRainSlider;

	private string[] Files = new string[7];

	public GUICombobox TypeBox;

	public GUICombobox SFXBox;

	public Image Color;

	private bool _init;

	public InputField[] InputFields;

	public MeshRenderer PreviewObject;

	public MeshRenderer ExtraObject;

	public Image ActiveButton;

	public float RotX;

	public float RotY;

	public string[] MeshCats;

	public Mesh[] MainMeshes;

	public Mesh[] ExtraMeshes;

	private Dictionary<string, Mesh[]> _meshes = new Dictionary<string, Mesh[]>();

	public GameObject SettingsPanel;

	public GameObject PreviewPanel;

	private bool _isDragging;

	private Vector3 _lastMousePos;

	private void Init()
	{
		if (_init)
		{
			return;
		}
		_init = true;
		for (int i = 0; i < MeshCats.Length; i++)
		{
			_meshes[MeshCats[i]] = new Mesh[2]
			{
				MainMeshes[i],
				ExtraMeshes[i]
			};
		}
		PreviewMat = new Material(PreviewMat);
		PreviewObject.sharedMaterial = PreviewMat;
		Window.OnClose = delegate
		{
			MaterialCamera.SetActive(false);
			RoomMaterialController.WallMaterial activeMat = _activeMat;
			if (activeMat != null)
			{
				activeMat.Unload();
			}
			UnloadExtras();
		};
		TypeBox.UpdateContent(RoomMaterialPack.Categories);
		SFXBox.UpdateContent(Enum.GetValues(typeof(Room.FloorType)).OfType<Room.FloorType>());
	}

	private void Update()
	{
		if (_isDragging)
		{
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
			else
			{
				Vector3 vector = _lastMousePos - Input.mousePosition;
				_lastMousePos = Input.mousePosition;
				RotX += vector.x;
				RotY -= vector.y;
			}
		}
		PreviewObject.transform.rotation = Quaternion.Euler(RotY, RotX, 0f);
	}

	public void Scroll(BaseEventData e)
	{
		PointerEventData pointerEventData = (PointerEventData)e;
		PreviewObject.transform.position = new Vector3(0f, 0f, Mathf.Clamp(PreviewObject.transform.position.z - pointerEventData.scrollDelta.y / 10f, 0.5f, 4f));
	}

	public void StartDrag()
	{
		_isDragging = true;
		_lastMousePos = Input.mousePosition;
	}

	public void PickColor()
	{
		WindowManager.SpawnColorDialog(delegate(Color c)
		{
			PreviewMat.SetColor("_Color", c);
			Color.color = c;
		}, Color.color);
	}

	public void Show(RoomMaterialPack pack)
	{
		Init();
		SettingsPanel.SetActive(false);
		PreviewPanel.SetActive(false);
		for (int i = 1; i < ButtonPanel.childCount; i++)
		{
			UnityEngine.Object.Destroy(ButtonPanel.GetChild(i).gameObject);
		}
		_activePack = pack;
		RoomMaterialController.WallMaterial[] materials = _activePack.Materials;
		foreach (RoomMaterialController.WallMaterial mat in materials)
		{
			CreateButton(mat);
		}
		MaterialCamera.SetActive(true);
		Window.Show();
	}

	private Button CreateButton(RoomMaterialController.WallMaterial mat)
	{
		Button b = UnityEngine.Object.Instantiate(ButtonPrefab);
		b.onClick.AddListener(delegate
		{
			SetActiveTexture(mat);
			if (ActiveButton != null)
			{
				ActiveButton.color = UnityEngine.Color.white;
			}
			ActiveButton = b.image;
			ActiveButton.color = new Color(0.6f, 1f, 0.6f, 1f);
		});
		b.GetComponentInChildren<Text>().text = mat.Name;
		b.transform.SetParent(ButtonPanel, false);
		return b;
	}

	private void UnloadExtras()
	{
		if (OcclusionTex != null)
		{
			UnityEngine.Object.Destroy(OcclusionTex);
		}
		if (SmoothTex != null)
		{
			UnityEngine.Object.Destroy(SmoothTex);
		}
		if (ColorTex != null)
		{
			UnityEngine.Object.Destroy(ColorTex);
		}
		if (SnowRainTex != null)
		{
			UnityEngine.Object.Destroy(SnowRainTex);
		}
	}

	private void SetActiveTexture(RoomMaterialController.WallMaterial mat)
	{
		RotX = 0f;
		RotY = 0f;
		SettingsPanel.SetActive(true);
		PreviewPanel.SetActive(true);
		RoomMaterialController.WallMaterial activeMat = _activeMat;
		if (activeMat != null)
		{
			activeMat.Unload();
		}
		UnloadExtras();
		_activeMat = mat;
		_activeMat.Load();
		TypeBox.SelectedItem = _activeMat.Category;
		SFXBox.SelectedItem = _activeMat.SFXType;
		Skirt.isOn = _activeMat.AddSkirting;
		Toggle occlusionImage = OcclusionImage;
		Toggle smoothImage = SmoothImage;
		bool flag = (SnowRainImage.isOn = _activeMat.Extra != null);
		bool isOn = (smoothImage.isOn = flag);
		occlusionImage.isOn = isOn;
		InputFields[0].text = (Files[0] = _activeMat._baseTexFile);
		Files[2] = _activeMat._extraTexFile;
		InputFields[1].text = (Files[1] = _activeMat._bumpTexFile);
		UpdateTexture(_activeMat.Base, ref MainTex, MainImg, "_MainTex");
		UpdateTexture(_activeMat.Bump, ref NormalTex, NormalImg, "_BumpTex");
		if (_activeMat.Extra != null)
		{
			SplitExtra((Texture2D)_activeMat.Extra);
		}
		UpdateOptions();
		UpdateSliders();
		UpdatePreviewOptions();
		UpdateSkirt();
	}

	public void UpdateTexture(Texture nTex, ref Texture2D oldTex, RawImage thumb, string mat)
	{
		if (oldTex != nTex && oldTex != null)
		{
			UnityEngine.Object.Destroy(oldTex);
		}
		oldTex = (Texture2D)nTex;
		thumb.texture = oldTex;
		PreviewMat.SetTexture(mat, oldTex);
	}

	public void UpdateOptions()
	{
		PreviewMat.SetVector("_Options", new Vector4(OcclusionImage.isOn ? 1 : 0, SmoothImage.isOn ? 1 : 0, SnowRainImage.isOn ? 1 : 0, HasSkirt() ? 1 : 0));
	}

	public void UpdateSliders()
	{
		PreviewMat.SetFloat("_OcclusionFactor", OcclusionSlider.value);
		PreviewMat.SetFloat("_SmoothFactor", SmoothSlider.value);
		PreviewMat.SetFloat("_SnowRainFactor", SnowRainSlider.value);
	}

	public void UpdatePreviewOptions()
	{
		PreviewMat.SetFloat("_ActiveRain", ActiveRainSlider.value);
		PreviewMat.SetFloat("_ActiveSnow", ActiveSnowSlider.value);
	}

	public void UpdateType()
	{
		if (_activeMat != null)
		{
			_activeMat.Category = TypeBox.SelectedItemString;
			Mesh[] array = _meshes[_activeMat.Category];
			PreviewObject.GetComponent<MeshFilter>().sharedMesh = array[0];
			ExtraObject.GetComponent<MeshFilter>().sharedMesh = array[1];
		}
		UpdateSkirt();
	}

	public void UpdateSound()
	{
		if (_activeMat != null)
		{
			_activeMat.SFXType = (Room.FloorType)SFXBox.SelectedItem;
		}
	}

	private bool HasSkirt()
	{
		if (_activeMat != null && _activeMat.AddSkirting)
		{
			return _activeMat.Category.Equals("Interior");
		}
		return false;
	}

	public void UpdateSkirt()
	{
		if (_activeMat != null)
		{
			_activeMat.AddSkirting = Skirt.isOn;
		}
		UpdateOptions();
	}

	public void RefreshTexture(int i)
	{
		LoadImage(Files[i], i);
	}

	public void CreateMaterial()
	{
		WindowManager.SpawnInputDialog("EnterNamePrompt".Loc(), "Name".Loc(), "", delegate(string x)
		{
			RoomMaterialController.WallMaterial wallMaterial = new RoomMaterialController.WallMaterial(x, "Interior", null, null, null, false, false, UnityEngine.Color.black, Room.FloorType.Carpet, new List<RoomMaterialController.WallMaterial.ColorPreset>(), _activePack);
			_activePack.Materials = _activePack.Materials.Concate(wallMaterial).ToArray();
			CreateButton(wallMaterial).onClick.Invoke();
		});
	}

	public void LoadImage(string file, int i)
	{
		if (!File.Exists(file))
		{
			return;
		}
		Texture2D texture2D = new Texture2D(256, 256);
		try
		{
			texture2D.LoadImage(File.ReadAllBytes(file));
			texture2D.Apply();
			texture2D.ScaleDown(256, 256);
			switch (i)
			{
			case 0:
				UpdateTexture(texture2D, ref MainTex, MainImg, "_MainTex");
				break;
			case 1:
				UpdateTexture(texture2D, ref NormalTex, NormalImg, "_BumpTex");
				break;
			case 2:
				SplitExtra(texture2D);
				break;
			case 3:
				UpdateTexture(texture2D, ref OcclusionTex, OcclusionImg, "_OcclusionTex");
				break;
			case 4:
				UpdateTexture(texture2D, ref SmoothTex, SmoothImg, "_SmoothTex");
				break;
			case 5:
				UpdateTexture(texture2D, ref ColorTex, ColorImg, "_ColorTex");
				break;
			case 6:
				UpdateTexture(texture2D, ref SnowRainTex, SnowRainImg, "_SnowRainTex");
				break;
			}
			Files[i] = file;
		}
		catch (Exception exception)
		{
			UnityEngine.Object.Destroy(texture2D);
			Debug.LogException(exception);
		}
	}

	public void LoadImage(int i)
	{
		LoadImage(InputFields[i].text, i);
	}

	private void SplitExtra(Texture2D extra)
	{
		Color32[] pixels = extra.GetPixels32();
		OcclusionTex = new Texture2D(256, 256);
		OcclusionTex.SetPixels32(GetPixel(pixels, (Color32 x) => x.r));
		OcclusionTex.Apply();
		SmoothTex = new Texture2D(256, 256);
		SmoothTex.SetPixels32(GetPixel(pixels, (Color32 x) => x.g));
		SmoothTex.Apply();
		ColorTex = new Texture2D(256, 256);
		ColorTex.SetPixels32(GetPixel(pixels, (Color32 x) => x.b));
		ColorTex.Apply();
		SnowRainTex = new Texture2D(256, 256);
		SnowRainTex.SetPixels32(GetPixel(pixels, (Color32 x) => (byte)(255 - x.a)));
		SnowRainTex.Apply();
		UpdateTexture(OcclusionTex, ref OcclusionTex, OcclusionImg, "_OcclusionTex");
		UpdateTexture(SmoothTex, ref SmoothTex, SmoothImg, "_SmoothTex");
		UpdateTexture(ColorTex, ref ColorTex, ColorImg, "_ColorTex");
		UpdateTexture(SnowRainTex, ref SnowRainTex, SnowRainImg, "_SnowRainTex");
	}

	private Color32[] GetPixel(Color32[] input, Func<Color32, byte> output)
	{
		Color32[] array = new Color32[input.Length];
		for (int i = 0; i < input.Length; i++)
		{
			byte b = output(input[i]);
			array[i] = new Color32(b, b, b, 1);
		}
		return array;
	}
}
