using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialTestController : MonoBehaviour
{
	public enum StyleType
	{
		Floor = 0,
		Interior = 1,
		Exterior = 2,
		Path = 3,
		Roof = 4
	}

	public Renderer Floor;

	public Renderer Interior;

	public Renderer Exterior;

	public Renderer Path;

	public Renderer Roof;

	public RoomStyle RoomStyle;

	public RoomStyle PathStyle;

	public RoomStyle RoofStyle;

	public Slider Snow;

	public Slider Rain;

	public Slider Sun;

	public Transform SunPos;

	public RectTransform TextureContent;

	public RectTransform DefaultStyleContent;

	public GameObject TexturePanel;

	public GameObject ColorButton;

	public GameObject ColorButton2;

	public GameObject CloseButton;

	public GameObject PresetButton;

	public GameObject SecondaryForceSave;

	public Toggle SecondaryEnabled;

	private Renderer _activeRend;

	private Dictionary<RoomMaterialController.WallMaterial, GameObject> _texButtons = new Dictionary<RoomMaterialController.WallMaterial, GameObject>();

	private GameObject _defaultStylePrefab;

	private Dictionary<Renderer, ValueTuple<string, Color, Color>> _lastUsedStyles = new Dictionary<Renderer, ValueTuple<string, Color, Color>>();

	private bool _disableSecondaryChanges;

	private void InitTextureButtons()
	{
		GameObject original = TextureContent.GetChild(0).gameObject;
		foreach (KeyValuePair<string, RoomMaterialController.WallMaterial> mat in RoomMaterialController.Instance.AllMaterials)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(original);
			gameObject.GetComponentInChildren<RawImage>(true).texture = mat.Value.Base;
			gameObject.GetComponentInChildren<Text>(true).text = mat.Key;
			gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				SetStyle(_activeRend, mat.Key, _activeRend.material.GetColor("_Color"), mat.Value.SecondaryColorEnabled ? _activeRend.material.GetColor("_Color2") : mat.Value.ForcedSecondaryColor);
				SetButtonColor(ColorButton, _activeRend.material.GetColor("_Color"));
				SetButtonColor(ColorButton2, _activeRend.material.GetColor("_Color2"));
				InitDefaultStyles(mat.Key);
			});
			gameObject.transform.SetParent(TextureContent, false);
			_texButtons[mat.Value] = gameObject;
		}
	}

	private void InitDefaultStyles(string mat)
	{
	}

	public void CreateColorButton(RoomMaterialController controller, RoomMaterialController.WallMaterial.ColorPreset preset, RoomMaterialController.WallMaterial m)
	{
		GameObject pre = UnityEngine.Object.Instantiate(_defaultStylePrefab);
		Image[] componentsInChildren = pre.GetComponentsInChildren<Image>();
		componentsInChildren[0].color = preset.Color1;
		componentsInChildren[1].color = preset.Color2;
		Button[] componentsInChildren2 = pre.GetComponentsInChildren<Button>();
		componentsInChildren2[0].onClick.AddListener(delegate
		{
			_activeRend.material.SetColor("_Color", preset.Color1);
			SetButtonColor(ColorButton, preset.Color1);
			_activeRend.material.SetColor("_Color2", preset.Color2);
			SetButtonColor(ColorButton2, preset.Color2);
		});
		componentsInChildren2[1].onClick.AddListener(delegate
		{
			m.ColorPresets.Remove(preset);
			UnityEngine.Object.Destroy(pre);
		});
		pre.transform.SetParent(DefaultStyleContent, false);
		pre.SetActive(true);
	}

	public RoomMaterialController.WallMaterial GetCurrentMat()
	{
		return RoomMaterialController.Instance.AllMaterials.Values.FirstOrDefault((RoomMaterialController.WallMaterial x) => x.ID == _activeRend.material.GetInt("_TexIdx"));
	}

	public void SaveSecondaryColorChanges()
	{
		bool disableSecondaryChange = _disableSecondaryChanges;
	}

	public void SaveAsPreset()
	{
	}

	public void ToggleTexturPanel(bool on)
	{
		TexturePanel.SetActive(on);
		ColorButton.SetActive(on);
		ColorButton2.SetActive(on);
		CloseButton.SetActive(on);
		PresetButton.SetActive(on);
		SecondaryEnabled.gameObject.SetActive(on);
		SecondaryForceSave.gameObject.SetActive(on);
		DefaultStyleContent.gameObject.SetActive(on);
	}

	public void ChangeColor(int i)
	{
		string c = ((i == 0) ? "_Color" : "_Color2");
		GameObject b = ((i == 0) ? ColorButton : ColorButton2);
		WindowManager.SpawnColorDialog(delegate(Color x)
		{
			_activeRend.material.SetColor(c, x);
			SetButtonColor(b, x);
		}, _activeRend.material.GetColor(c));
	}

	private void ActivateRend(Renderer rend)
	{
		foreach (KeyValuePair<RoomMaterialController.WallMaterial, GameObject> texButton in _texButtons)
		{
			texButton.Value.SetActive(texButton.Key.Category.Equals(rend.name));
		}
		SetButtonColor(ColorButton, rend.material.GetColor("_Color"));
		SetButtonColor(ColorButton2, rend.material.GetColor("_Color2"));
		ToggleTexturPanel(true);
		InitDefaultStyles(GetCurrentMat().Name);
	}

	public void SetButtonColor(GameObject button, Color c)
	{
		button.GetComponent<Image>().color = c.Alpha(1f);
		button.GetComponentInChildren<Text>().color = Color.white - c.Alpha(0f);
	}

	public void ReloadTextures()
	{
		RoomMaterialController.Instance.InitializeTextures(false);
		InitMaterials();
		foreach (KeyValuePair<Renderer, ValueTuple<string, Color, Color>> lastUsedStyle in _lastUsedStyles)
		{
			SetStyle(lastUsedStyle.Key, lastUsedStyle.Value.Item1, lastUsedStyle.Value.Item2, lastUsedStyle.Value.Item3, false);
		}
	}

	private void InitMaterials()
	{
		Floor.material = RoomMaterialController.Instance.PreviewMat;
		SetStyle(Floor, RoomStyle, StyleType.Floor);
		Interior.material = RoomMaterialController.Instance.PreviewMat;
		SetStyle(Interior, RoomStyle, StyleType.Interior);
		Exterior.material = RoomMaterialController.Instance.PreviewMat;
		SetStyle(Exterior, RoomStyle, StyleType.Exterior);
		Path.material = RoomMaterialController.Instance.PreviewMat;
		SetStyle(Path, PathStyle, StyleType.Path);
		Roof.material = RoomMaterialController.Instance.PreviewMat;
		SetStyle(Roof, RoofStyle, StyleType.Roof);
	}

	public void UpdateSnow()
	{
		Floor.material.SetFloat("_Snow", Snow.value);
		Interior.material.SetFloat("_Snow", Snow.value);
		Exterior.material.SetFloat("_Snow", Snow.value);
		Path.material.SetFloat("_Snow", Snow.value);
		Roof.material.SetFloat("_Snow", Snow.value);
	}

	public void UpdateRain()
	{
		Floor.material.SetFloat("_Rain", Rain.value);
		Interior.material.SetFloat("_Rain", Rain.value);
		Exterior.material.SetFloat("_Rain", Rain.value);
		Path.material.SetFloat("_Rain", Rain.value);
		Roof.material.SetFloat("_Rain", Rain.value);
	}

	public void UpdateSun()
	{
		Vector3 eulerAngles = SunPos.eulerAngles;
		SunPos.rotation = Quaternion.Euler(eulerAngles.x, Sun.value, eulerAngles.z);
	}

	private void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject() || !Input.GetMouseButtonDown(0))
		{
			return;
		}
		RaycastHit[] array = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition), 50f);
		foreach (RaycastHit raycastHit in array)
		{
			Renderer component = raycastHit.collider.GetComponent<Renderer>();
			if (component != null)
			{
				_activeRend = component;
				ActivateRend(component);
				break;
			}
		}
	}

	private void Start()
	{
		InitMaterials();
		InitTextureButtons();
		UpdateSun();
		ToggleTexturPanel(false);
		_defaultStylePrefab = DefaultStyleContent.GetChild(1).gameObject;
	}

	public void SetStyle(Renderer rend, RoomStyle style, StyleType type)
	{
		string mat = style.FloorMat;
		SVector3 sVector = style.FloorColor;
		SVector3 sVector2 = style.FloorColor2;
		switch (type)
		{
		case StyleType.Interior:
			mat = style.InsideMat;
			sVector = style.InsideColor;
			sVector2 = style.InsideColor2;
			break;
		case StyleType.Exterior:
		case StyleType.Path:
			mat = style.OutsideMat;
			sVector = style.OutsideColor;
			sVector2 = style.OutsideColor2;
			break;
		}
		SetStyle(rend, mat, sVector, sVector2, false);
	}

	public void SetStyle(Renderer rend, string mat, Color color1, Color color2, bool save = true)
	{
		if (save)
		{
			_lastUsedStyles[rend] = new ValueTuple<string, Color, Color>(mat, color1, color2);
		}
		ValueTuple<int, bool> materialIDAndSkirtBool = RoomMaterialController.GetMaterialIDAndSkirtBool(mat, false);
		int item = materialIDAndSkirtBool.Item1;
		bool item2 = materialIDAndSkirtBool.Item2;
		rend.material.SetColor("_Color", color1);
		rend.material.SetColor("_Color2", color2);
		rend.material.SetInt("_Skirt", item2 ? 1 : 0);
		rend.material.SetInt("_TexIdx", item);
	}
}
