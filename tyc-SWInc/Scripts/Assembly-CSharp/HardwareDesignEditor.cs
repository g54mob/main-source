using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevConsole;
using Steamworks;
using Tyd;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HardwareDesignEditor : MonoBehaviour
{
	public enum State
	{
		None = 0,
		AddAttachment = 1,
		Launch = 2,
		FixAttachment = 3,
		Preview = 4,
		MeshObjectEdit = 5,
		MorphTargetEdit = 6,
		MoveAttachmentOffset = 7
	}

	public static HardwareDesignEditor Instance;

	public static string LoadDesign;

	public Button ButtonPrefab;

	public Button ColorButtonPrefab;

	public GameObject SliderPrefab;

	public GameObject PrimaryColorAdd;

	public GameObject SecondaryColorAdd;

	public GameObject TertiaryColorAdd;

	public GameObject[] ActiveButtons;

	public Text LabelPrefab;

	public Text ColorSetLabel;

	public InputField InputPrefab;

	public HardwareAttachmentPoint AtPointPrefab;

	public RectTransform StartPanel;

	public RectTransform SliderPanel;

	public RectTransform AttPanel;

	public RectTransform SubSliderPanel;

	public RectTransform MeshObjectPanel;

	public RectTransform PrimaryColorPanel;

	public RectTransform SecondaryColorPanel;

	public RectTransform TertiaryColorPanel;

	public Toggle PrimaryColorToggle;

	public Toggle SecondaryColorToggle;

	public Toggle TertiaryColorToggle;

	public InputField AtlasCount;

	public InputField MeshName;

	public Slider AtlasX;

	public Slider AtlasY;

	public Slider AtlasPreview;

	public HardwareDesign ActiveDesign;

	public Material WireMat;

	public HardwareMorphWindow MorphWindow;

	public State CurrentState = State.Launch;

	public float RotSpeed = 0.5f;

	public Toggle GlobalToggle;

	public Toggle PivotToggle;

	public Text HelpText;

	public UVRenderer UVRend;

	public Mesh Circle;

	public Mesh Arrow;

	public Mesh Sphere;

	public Material GizmoMat;

	public GameObject StartPanelObject;

	public GameObject MainPanel;

	public GameObject MeshPanel;

	public Transform Root;

	public Transform VertexHighlight;

	public Transform CameraT;

	public int ColorSet;

	private bool _isDragging;

	private bool _isSkinned;

	private Vector2 _lastMouse;

	private MeshFilter _activeBase;

	private SkinnedMeshRenderer _activeBaseSkin;

	private Renderer _activeRend;

	private Renderer _meshObjectRend;

	private Vector3[] _vertices;

	private Vector3[] _normals;

	private int[] _tris;

	private Material _activeMat;

	private HardwareDesign.Attachment _activeAtt;

	private HardwareDesign.AttachmentPoint _activeAttPoint;

	private GameObject _activeAttObj;

	private GameObject _activeAttRoot;

	private TransformGizmo _activeGizmo;

	private List<Vector3> _attP = new List<Vector3>();

	private List<Vector3> _attN = new List<Vector3>();

	private List<Vector3> _attU = new List<Vector3>();

	private HardwareDesignInstance _activePreview;

	private HardwareDesign.MeshObject _activeMeshObject;

	private float Horz;

	private float Vert;

	public HardwareEditorWindow EditorWindow;

	public HardwareGroupWindow GroupWindow;

	public GameObject AttachmentOffset;

	public bool Changed;

	private int[] _subTrisMin;

	private Vector3[] _subVertsMin;

	private Vector3[] _subVertsMax;

	private int _meshObjectMorphVert;

	private int _morphTagetIndex;

	private float _morphMagnitude;

	private bool _customMorphHandle;

	public Transform CustomMorphPos;

	private TransformGizmo _customMorphGizmo;

	public GUIWindow CreationWindow;

	public RectTransform CreationMeshPanel;

	public Text[] CreationTextureLabels;

	public bool IsCreation;

	private ModPackage _creationParent;

	private string _creationRoot;

	private string _creationName;

	private string _creationMainTex;

	private string _creationExtraTex;

	private string _creationNormalTex;

	private string _creationBaseMesh;

	public void MeshNameChange()
	{
		if (_activeMeshObject != null)
		{
			_activeMeshObject.Name = MeshName.text;
		}
	}

	public void MoveRotUpdate()
	{
		if (_activeGizmo != null)
		{
			_activeGizmo.Global = GlobalToggle.isOn;
			_activeGizmo.Pivot = PivotToggle.isOn;
		}
		if (_customMorphGizmo != null)
		{
			_customMorphGizmo.Global = GlobalToggle.isOn;
			_customMorphGizmo.Pivot = PivotToggle.isOn;
		}
	}

	public void MarkAsChanged()
	{
		bool builtIn = ActiveDesign.BuiltIn;
		Changed = true;
	}

	public void ChangeColorSet(int change)
	{
		ColorSet += change;
		RefreshColorSet();
	}

	public void DeleteColorSet()
	{
		if (ActiveDesign.ColorSets.Count > 0)
		{
			ActiveDesign.ColorSets.RemoveAt(ColorSet);
		}
		RefreshColorSet();
		MarkAsChanged();
	}

	public void AddColorSet()
	{
		ActiveDesign.ColorSets.Add(new HardwareDesign.ColorSet());
		ColorSet = ActiveDesign.ColorSets.Count - 1;
		RefreshColorSet();
		MarkAsChanged();
	}

	public void RefreshColorSet()
	{
		ColorSet = Mathf.Clamp(ColorSet, 0, Mathf.Max(0, ActiveDesign.ColorSets.Count - 1));
		int childCount = PrimaryColorPanel.childCount;
		for (int i = 0; i < childCount; i++)
		{
			UnityEngine.Object.Destroy(PrimaryColorPanel.GetChild(i).gameObject);
		}
		childCount = SecondaryColorPanel.childCount;
		for (int j = 0; j < childCount; j++)
		{
			UnityEngine.Object.Destroy(SecondaryColorPanel.GetChild(j).gameObject);
		}
		childCount = TertiaryColorPanel.childCount;
		for (int k = 0; k < childCount; k++)
		{
			UnityEngine.Object.Destroy(TertiaryColorPanel.GetChild(k).gameObject);
		}
		if (ActiveDesign.ColorSets.Count > 0)
		{
			ColorSetLabel.text = ColorSet + 1 + " / " + ActiveDesign.ColorSets.Count;
			HardwareDesign.ColorSet colorSet = ActiveDesign.ColorSets[ColorSet];
			for (int l = 0; l < colorSet.Primaries.Count; l++)
			{
				AddColorButton(colorSet.Primaries[l], 0, false);
			}
			for (int m = 0; m < colorSet.Secondaries.Count; m++)
			{
				AddColorButton(colorSet.Secondaries[m], 1, false);
			}
			for (int n = 0; n < colorSet.Tertieries.Count; n++)
			{
				AddColorButton(colorSet.Tertieries[n], 2, false);
			}
		}
		else
		{
			ColorSetLabel.text = "0 / 0";
		}
	}

	public void SaveAndExit()
	{
		TydDocument node = ActiveDesign.SaveDesign();
		File.WriteAllText(ActiveDesign.FileLocation, TydToText.Write(node, true));
		WindowManager.Instance.ShowMessageBox("Saved file successfully", true, DialogWindow.DialogType.Information);
		Changed = false;
	}

	public void Exit()
	{
		if (Changed)
		{
			WindowManager.Instance.ShowMessageBox("You have unsaved changes!\nAre you sure you want to exit?", true, DialogWindow.DialogType.Question, ActualExit);
		}
		else
		{
			ActualExit();
		}
	}

	private void ActualExit()
	{
		if (IsCreation)
		{
			ObjectDatabase.Instance.HardwareDesigns.Remove(ActiveDesign.ID);
			Utilities.RemoveElement(ref _creationParent.HardwareDesigns, ActiveDesign);
			ActiveDesign.CleanUp(true, true, true, true);
			UnityEngine.Object.Destroy(ActiveDesign);
		}
		FrameTransition.StartTransition(true);
		ErrorLogging.FirstOfScene = true;
		ErrorLogging.SceneChanging = true;
		DevConsole.Console.SaveConsole();
		SceneManager.LoadScene("MainMenu");
	}

	public void CalculateMorphHandles()
	{
		ActiveDesign.CalculateMorphHandles(_activeMeshObject);
		MarkAsChanged();
	}

	public void ShowGroups()
	{
		GroupWindow.Show(ActiveDesign);
	}

	public void BeginMoveOffset(HardwareDesign.AttachmentPoint att)
	{
		ClearCurrentState(true);
		ChangeState(State.MoveAttachmentOffset);
		AttachmentOffset.SetActive(true);
		_activeGizmo = AttachmentOffset.AddComponent<TransformGizmo>();
		_activeGizmo.Circle = Circle;
		_activeGizmo.Arrow = Arrow;
		_activeGizmo.Mat = GizmoMat;
		_activeGizmo.Scale = 0.5f;
		MoveRotUpdate();
		Vector3 n;
		Vector3 u;
		Vector3 p;
		HardwareDesign.GetPoint(att.Index, att.Type, _vertices, _normals, _tris, Root.localToWorldMatrix, false, out p, out n, out u);
		Quaternion quaternion = Quaternion.LookRotation(n, u);
		p = Matrix4x4.TRS(p, quaternion, Vector3.one).MultiplyPoint(att.AreaOffset);
		AttachmentOffset.transform.position = p;
		AttachmentOffset.transform.rotation = quaternion;
		_activeAttPoint = att;
	}

	public void ChangeColorActive(int i)
	{
		switch (i)
		{
		case 0:
			if (ActiveDesign.ColorPrimary != PrimaryColorToggle.isOn)
			{
				MarkAsChanged();
			}
			ActiveDesign.ColorPrimary = PrimaryColorToggle.isOn;
			PrimaryColorPanel.gameObject.SetActive(PrimaryColorToggle.isOn);
			PrimaryColorAdd.SetActive(PrimaryColorToggle.isOn);
			break;
		case 1:
			if (ActiveDesign.ColorSecondary != SecondaryColorToggle.isOn)
			{
				MarkAsChanged();
			}
			ActiveDesign.ColorSecondary = SecondaryColorToggle.isOn;
			SecondaryColorPanel.gameObject.SetActive(SecondaryColorToggle.isOn);
			SecondaryColorAdd.SetActive(SecondaryColorToggle.isOn);
			break;
		case 2:
			if (ActiveDesign.ColorTertiary != TertiaryColorToggle.isOn)
			{
				MarkAsChanged();
			}
			ActiveDesign.ColorTertiary = TertiaryColorToggle.isOn;
			TertiaryColorPanel.gameObject.SetActive(TertiaryColorToggle.isOn);
			TertiaryColorAdd.SetActive(TertiaryColorToggle.isOn);
			break;
		}
	}

	public void AddNewColor(int panel)
	{
		WindowManager.SpawnColorDialog(delegate(Color x)
		{
			AddColorButton(x, panel, true);
		}, Color.white, null, null, false);
	}

	public void RemoveColor(Color c, int panel)
	{
		List<Color> list = null;
		switch (panel)
		{
		case 0:
			list = ActiveDesign.ColorSets[ColorSet].Primaries;
			break;
		case 1:
			list = ActiveDesign.ColorSets[ColorSet].Secondaries;
			break;
		case 2:
			list = ActiveDesign.ColorSets[ColorSet].Tertieries;
			break;
		}
		list.Remove(c);
		MarkAsChanged();
	}

	public void AddColorButton(Color c, int panel, bool reflect)
	{
		if (reflect)
		{
			if (ActiveDesign.ColorSets.Count == 0)
			{
				ActiveDesign.ColorSets.Add(new HardwareDesign.ColorSet());
				ColorSet = 0;
			}
			List<Color> list = null;
			switch (panel)
			{
			case 0:
				list = ActiveDesign.ColorSets[ColorSet].Primaries;
				break;
			case 1:
				list = ActiveDesign.ColorSets[ColorSet].Secondaries;
				break;
			case 2:
				list = ActiveDesign.ColorSets[ColorSet].Tertieries;
				break;
			}
			if (!list.Contains(c))
			{
				list.Add(c);
			}
			MarkAsChanged();
		}
		RectTransform parent = null;
		switch (panel)
		{
		case 0:
			parent = PrimaryColorPanel;
			break;
		case 1:
			parent = SecondaryColorPanel;
			break;
		case 2:
			parent = TertiaryColorPanel;
			break;
		}
		Button button = UnityEngine.Object.Instantiate(ColorButtonPrefab);
		button.GetComponent<Image>().color = c;
		button.onClick.AddListener(delegate
		{
			UnityEngine.Object.Destroy(button.gameObject);
			RemoveColor(c, panel);
		});
		button.transform.SetParent(parent, false);
	}

	public void CreateDoubleMorph(HardwareDesign.MeshObject o, HardwareDesign.MorphInfo m, bool bMesh)
	{
		int num = o.MorphTargets.FindIndex(m);
		if (num < 0)
		{
			return;
		}
		if (m.DoubleMorph)
		{
			HardwareDesign.MorphInfo obj = new HardwareDesign.MorphInfo(m.Label + " 2");
			m.DoubleMorph = false;
			Utilities.AddElement(ref o.MorphTargets, num + 1, obj);
			ActiveDesign.CalculateMorphHandle(o, num);
			ActiveDesign.CalculateMorphHandle(o, num + 1);
		}
		else
		{
			Utilities.RemoveElement(ref o.MorphTargets, o.MorphTargets[num + 1]);
			m.DoubleMorph = true;
		}
		MarkAsChanged();
		if (bMesh)
		{
			int childCount = SliderPanel.childCount;
			for (int i = 2; i < childCount; i++)
			{
				UnityEngine.Object.Destroy(SliderPanel.GetChild(i).gameObject);
			}
			InitBaseMorphs(ActiveDesign.GetObject(ActiveDesign.BaseMesh));
		}
		else
		{
			EditMeshObject(o);
		}
	}

	public void EditMeshObject(HardwareDesign.MeshObject obj)
	{
		ClearCurrentState(true);
		_activeMeshObject = null;
		MeshName.text = obj.Name;
		AtlasCount.text = obj.AtlasCount.ToString();
		AtlasPreview.maxValue = obj.AtlasCount - 1;
		AtlasPreview.value = 0f;
		AtlasX.value = obj.AtlasX;
		AtlasY.value = obj.AtlasY;
		_activeMeshObject = obj;
		bool skinned;
		_meshObjectRend = ActiveDesign.SpawnObject(obj, out skinned).GetComponent<Renderer>();
		_meshObjectRend.sharedMaterial = new Material(_activeMat);
		int childCount = SubSliderPanel.childCount;
		for (int i = 3; i < childCount; i++)
		{
			UnityEngine.Object.Destroy(SubSliderPanel.GetChild(i).gameObject);
		}
		bool flag = obj.ID.Equals(ActiveDesign.BaseMesh);
		if (skinned)
		{
			SkinnedMeshRenderer skinRend = _meshObjectRend.GetComponent<SkinnedMeshRenderer>();
			int num = 0;
			for (int j = 0; j < obj.MorphTargets.Length; j++)
			{
				HardwareDesign.MorphInfo mo = obj.MorphTargets[j];
				if (flag)
				{
					Text text = UnityEngine.Object.Instantiate(LabelPrefab);
					text.text = mo.Label;
					text.transform.SetParent(SubSliderPanel);
				}
				else
				{
					InputField inputField = UnityEngine.Object.Instantiate(InputPrefab);
					inputField.text = mo.Label;
					inputField.transform.SetParent(SubSliderPanel);
					inputField.onEndEdit.AddListener(delegate(string x)
					{
						mo.Label = x;
						MarkAsChanged();
					});
				}
				GameObject obj2 = UnityEngine.Object.Instantiate(SliderPrefab);
				Slider componentInChildren = obj2.GetComponentInChildren<Slider>();
				Button[] componentsInChildren = obj2.GetComponentsInChildren<Button>();
				componentsInChildren[0].onClick.AddListener(delegate
				{
					MorphWindow.Show(mo);
				});
				int i2 = j;
				componentsInChildren[1].onClick.AddListener(delegate
				{
					BeginMorphHandleState(i2);
				});
				if (flag || (!mo.DoubleMorph && j == obj.MorphTargets.Length - 1))
				{
					componentsInChildren[2].gameObject.SetActive(false);
				}
				else
				{
					componentsInChildren[2].onClick.AddListener(delegate
					{
						CreateDoubleMorph(obj, mo, true);
					});
				}
				componentInChildren.value = (mo.DoubleMorph ? 0.5f : 0f);
				componentInChildren.maxValue = 1f;
				int k1 = num;
				componentInChildren.onValueChanged.AddListener(delegate(float x)
				{
					HardwareDesignInstance.SetBlend(x, skinRend, k1, mo);
				});
				num = ((!mo.DoubleMorph) ? (num + 1) : (num + 2));
				obj2.transform.SetParent(SubSliderPanel);
			}
		}
		ChangeState(State.MeshObjectEdit);
		MainPanel.SetActive(false);
		MeshPanel.SetActive(true);
		Root.gameObject.SetActive(false);
		UVRend.BaseImage.texture = _activeMat.mainTexture;
		UVRend.SetMesh(obj.Mesh);
		UVRend.SetAtlasParams(obj.AtlasOffset, obj.AtlasCount);
	}

	public void RandomizeMorphs(bool bMesh)
	{
		if (bMesh)
		{
			HardwareDesign.MorphInfo[] morphTargets = ActiveDesign.GetObject(ActiveDesign.BaseMesh).MorphTargets;
			int num = 0;
			for (int i = 0; i < SliderPanel.childCount; i++)
			{
				Slider componentInChildren = SliderPanel.GetChild(i).GetComponentInChildren<Slider>();
				if (!(componentInChildren != null))
				{
					continue;
				}
				if (morphTargets != null && num < morphTargets.Length)
				{
					HardwareDesign.MorphInfo morphInfo = morphTargets[num];
					if (morphInfo.Chance >= 1f || Utilities.RandomValue < morphInfo.Chance)
					{
						componentInChildren.value = (morphInfo.Gauss ? Utilities.RandomGaussClamped(morphInfo.Mean, morphInfo.Deviation) : Utilities.RandomValue);
					}
					else
					{
						componentInChildren.value = 0f;
					}
				}
				num++;
			}
			return;
		}
		HardwareDesign.MorphInfo[] morphTargets2 = _activeMeshObject.MorphTargets;
		int num2 = 0;
		for (int j = 0; j < SubSliderPanel.childCount; j++)
		{
			Slider componentInChildren2 = SubSliderPanel.GetChild(j).GetComponentInChildren<Slider>();
			if (!(componentInChildren2 != null))
			{
				continue;
			}
			if (morphTargets2 != null && num2 < morphTargets2.Length)
			{
				HardwareDesign.MorphInfo morphInfo2 = morphTargets2[num2];
				if (morphInfo2.Chance >= 1f || Utilities.RandomValue < morphInfo2.Chance)
				{
					componentInChildren2.value = (morphInfo2.Gauss ? Utilities.RandomGaussClamped(morphInfo2.Mean, morphInfo2.Deviation) : Utilities.RandomValue);
				}
				else
				{
					componentInChildren2.value = 0f;
				}
			}
			num2++;
		}
	}

	public void ResetMorphs(bool bMesh)
	{
		if (bMesh)
		{
			HardwareDesign.MorphInfo[] morphTargets = ActiveDesign.GetObject(ActiveDesign.BaseMesh).MorphTargets;
			int num = 0;
			for (int i = 0; i < SliderPanel.childCount; i++)
			{
				Slider componentInChildren = SliderPanel.GetChild(i).GetComponentInChildren<Slider>();
				if (componentInChildren != null)
				{
					if (morphTargets != null && num < morphTargets.Length && morphTargets[num].DoubleMorph)
					{
						componentInChildren.value = 0.5f;
					}
					else
					{
						componentInChildren.value = 0f;
					}
					num++;
				}
			}
			return;
		}
		HardwareDesign.MorphInfo[] morphTargets2 = _activeMeshObject.MorphTargets;
		int num2 = 0;
		for (int j = 0; j < SubSliderPanel.childCount; j++)
		{
			Slider componentInChildren2 = SubSliderPanel.GetChild(j).GetComponentInChildren<Slider>();
			if (componentInChildren2 != null)
			{
				if (morphTargets2 != null && num2 < morphTargets2.Length && morphTargets2[num2].DoubleMorph)
				{
					componentInChildren2.value = 0.5f;
				}
				else
				{
					componentInChildren2.value = 0f;
				}
				num2++;
			}
		}
	}

	public void AtlasOffsetChange()
	{
		if (_activeMeshObject != null)
		{
			if (_activeMeshObject.AtlasX != AtlasX.value || _activeMeshObject.AtlasY != AtlasY.value)
			{
				MarkAsChanged();
			}
			_activeMeshObject.AtlasX = AtlasX.value;
			_activeMeshObject.AtlasY = AtlasY.value;
			UVRend.SetAtlasParams(_activeMeshObject.AtlasOffset, _activeMeshObject.AtlasCount);
			PreviewChange();
		}
	}

	public void AtlasCountChange()
	{
		if (_activeMeshObject != null)
		{
			int num = Mathf.Clamp(AtlasCount.text.ConvertToIntDef(1), 1, 100);
			if (_activeMeshObject.AtlasCount != num)
			{
				MarkAsChanged();
			}
			_activeMeshObject.AtlasCount = num;
			AtlasPreview.maxValue = num - 1;
			UVRend.SetAtlasParams(_activeMeshObject.AtlasOffset, _activeMeshObject.AtlasCount);
		}
	}

	public void PreviewChange()
	{
		if (_meshObjectRend != null)
		{
			_meshObjectRend.sharedMaterial.mainTextureOffset = new Vector2(_activeMeshObject.AtlasOffset.x, 0f - _activeMeshObject.AtlasOffset.y) * AtlasPreview.value;
		}
	}

	public void ChangeState(State state)
	{
		CurrentState = state;
		HelpText.text = "";
		switch (CurrentState)
		{
		case State.AddAttachment:
			HelpText.text = "Click on a triangle or vertex on the base mesh to attach the point to it\nRight click to cancel";
			break;
		case State.FixAttachment:
			HelpText.text = "Hold ctrl to change rotation\nPress X, Y or Z to flip model\nPress Enter to save your changes\nRight click to cancel";
			break;
		case State.MorphTargetEdit:
			HelpText.text = "Click on a vertex on the mesh to attach the morph handle to it\nPress space to toggle between custom handle\nHold ctrl to change rotation\nPress backspace to clear position\nPress up or down to change length\nPress enter to save changes\nRight click to cancel";
			break;
		case State.MoveAttachmentOffset:
			HelpText.text = "Press enter to save changes\nPress backspace to clear position\nRight click to cancel";
			break;
		case State.Launch:
		case State.Preview:
		case State.MeshObjectEdit:
			break;
		}
	}

	public void AddAttachment()
	{
		EditAttachment(null);
	}

	public void EditAttachment(HardwareDesign.AttachmentPoint ap)
	{
		ClearCurrentState(true);
		_activeRend.sharedMaterials = new Material[2]
		{
			_activeRend.sharedMaterials[0],
			WireMat
		};
		ChangeState(State.AddAttachment);
		_activeAttPoint = ap;
	}

	public void ReloadMeshData()
	{
		if (_activeMeshObject == null)
		{
			return;
		}
		_activeMeshObject.Reload(Path.GetDirectoryName(ActiveDesign.FileLocation));
		if (_activeMeshObject.ID.Equals(ActiveDesign.BaseMesh))
		{
			if (_isSkinned)
			{
				_activeBaseSkin.sharedMesh = _activeMeshObject.Mesh;
			}
			else
			{
				_activeBase.sharedMesh = _activeMeshObject.Mesh;
			}
		}
		EditMeshObject(_activeMeshObject);
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	private void Start()
	{
		Instance = this;
		MainPanel.SetActive(false);
		MeshPanel.SetActive(false);
		ActiveButtons.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(false);
		});
		StartPanelObject.SetActive(true);
		if (LoadDesign != null)
		{
			HardwareDesign orNull = ObjectDatabase.Instance.HardwareDesigns.GetOrNull(LoadDesign);
			LoadDesign = null;
			if (orNull != null)
			{
				SetActive(orNull);
				return;
			}
		}
		bool flag = false;
		foreach (HardwareDesign design in ObjectDatabase.Instance.HardwareDesigns.Values)
		{
			if (!design.BuiltIn && (design.Parent == null || design.Parent.CanUpload))
			{
				Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
				button.GetComponentInChildren<Text>().text = design.Name;
				button.onClick.AddListener(delegate
				{
					SetActive(design);
				});
				button.transform.SetParent(StartPanel, false);
				flag |= !design.BuiltIn;
			}
		}
		foreach (ModPackage mP in GameData.ModPackages)
		{
			if (mP.CanUpload && Directory.Exists(Path.Combine(mP.Root, "HardwareDesign")))
			{
				Button button2 = UnityEngine.Object.Instantiate(ButtonPrefab);
				button2.GetComponentInChildren<Text>().text = ("Create new for " + mP.ItemTitle).BlueHighlight();
				button2.onClick.AddListener(delegate
				{
					ShowCreationDialog(mP);
				});
				button2.transform.SetParent(StartPanel, false);
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		Button button3 = UnityEngine.Object.Instantiate(ButtonPrefab);
		button3.GetComponentInChildren<Text>().text = "NoModsToEdit".Loc();
		string url = "https://swinc.net/wiki/index.php/Hardware_Design";
		button3.onClick.AddListener(delegate
		{
			if (SteamManager.Initialized && SteamUtils.IsOverlayEnabled())
			{
				SteamFriends.ActivateGameOverlayToWebPage(url);
			}
			else
			{
				Application.OpenURL(url);
			}
		});
		button3.transform.SetParent(StartPanel, false);
		button3.GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 64f);
		GUIToolTipper component = button3.GetComponent<GUIToolTipper>();
		component.Localize = false;
		component.TooltipDescription = url;
	}

	private void UpdateMeshData(bool first)
	{
		bool flag = false;
		if (_isSkinned)
		{
			Mesh mesh = new Mesh();
			_activeBaseSkin.BakeMesh(mesh);
			_vertices = mesh.vertices;
			_normals = mesh.normals;
			_tris = mesh.triangles;
			UnityEngine.Object.Destroy(mesh);
			flag = true;
		}
		else if (first)
		{
			Mesh sharedMesh = _activeBase.sharedMesh;
			_vertices = sharedMesh.vertices;
			_normals = sharedMesh.normals;
			_tris = sharedMesh.triangles;
			flag = true;
		}
		if (flag)
		{
			RefreshAttachmentPoints();
		}
	}

	private void RefreshAttachmentPoints()
	{
		_attP.Clear();
		_attN.Clear();
		_attU.Clear();
		foreach (HardwareDesign.AttachmentPoint attachment in ActiveDesign.Attachments)
		{
			Vector3 p;
			Vector3 n;
			Vector3 u;
			HardwareDesign.GetPoint(attachment.Index, attachment.Type, _vertices, _normals, _tris, Matrix4x4.identity, true, out p, out n, out u);
			_attP.Add(p);
			_attN.Add(n);
			_attU.Add(u);
		}
		if (CurrentState == State.FixAttachment)
		{
			HardwareDesign.AttachmentPoint activeAttPoint = _activeAttPoint;
			Vector3 p2;
			Vector3 n2;
			Vector3 u2;
			HardwareDesign.GetPoint(activeAttPoint.Index, activeAttPoint.Type, _vertices, _normals, _tris, Matrix4x4.identity, _activeAtt.Roll, out p2, out n2, out u2);
			_activeAttRoot.transform.SetParent(Root, false);
			_activeAttRoot.transform.localPosition = p2;
			_activeAttRoot.transform.localRotation = Quaternion.LookRotation(n2, u2);
			UpdateAttachmentFlip();
		}
	}

	private void RenderAtts()
	{
		int num = ActiveDesign.Attachments.IndexOf(_activeAttPoint);
		for (int i = 0; i < _attP.Count; i++)
		{
			if (CurrentState != State.FixAttachment || i == num)
			{
				Vector3 pos = Root.localToWorldMatrix.MultiplyPoint(_attP[i]);
				Vector3 forward = Root.localToWorldMatrix.MultiplyVector(_attN[i]);
				Vector3 upwards = Root.localToWorldMatrix.MultiplyVector(_attU[i]);
				Matrix4x4 matrix = Matrix4x4.TRS(s: (CurrentState == State.AddAttachment && i != num) ? new Vector3(0.25f, 0.25f, 0.12f) : new Vector3(0.5f, 0.5f, 0.25f), pos: pos, q: Quaternion.LookRotation(forward, upwards));
				Graphics.DrawMesh(Arrow, matrix, GizmoMat, 0, Camera.main, 0, null, false, false);
			}
		}
	}

	public void Preview()
	{
		EditorWindow.Show(ActiveDesign);
	}

	private void DuplicateMorph(int groupID, float value)
	{
		if (CurrentState != State.FixAttachment)
		{
			return;
		}
		SkinnedMeshRenderer component = _activeAttObj.GetComponent<SkinnedMeshRenderer>();
		if (!(component != null))
		{
			return;
		}
		HardwareDesign.MeshObject meshObject = ActiveDesign.GetObject(_activeAtt.Object);
		for (int i = 0; i < meshObject.MorphTargets.Length; i++)
		{
			if (meshObject.MorphTargets[i].GroupID == groupID)
			{
				component.SetBlendShapeWeight(i, value);
			}
		}
	}

	public void BeginMove(HardwareDesign.AttachmentPoint at, HardwareDesign.Attachment att)
	{
		HardwareDesign.MeshObject meshObject = ActiveDesign.GetObject(att.Object);
		if (meshObject == null)
		{
			return;
		}
		bool skinned;
		_activeAttObj = ActiveDesign.SpawnObject(meshObject, out skinned);
		ClearCurrentState(true);
		if (skinned)
		{
			SkinnedMeshRenderer component = _activeAttObj.GetComponent<SkinnedMeshRenderer>();
			Dictionary<int, float> dictionary = new Dictionary<int, float>();
			HardwareDesign.MeshObject meshObject2 = ActiveDesign.GetObject(ActiveDesign.BaseMesh);
			for (int i = 0; i < meshObject2.MorphTargets.Length; i++)
			{
				HardwareDesign.MorphInfo morphInfo = meshObject2.MorphTargets[i];
				if (morphInfo.GroupID >= 0)
				{
					dictionary[morphInfo.GroupID] = _activeBaseSkin.GetBlendShapeWeight(i);
				}
			}
			for (int j = 0; j < meshObject.MorphTargets.Length; j++)
			{
				HardwareDesign.MorphInfo morphInfo2 = meshObject.MorphTargets[j];
				float value;
				if (morphInfo2.GroupID >= 0 && dictionary.TryGetValue(morphInfo2.GroupID, out value))
				{
					component.SetBlendShapeWeight(j, value);
				}
			}
		}
		Vector3 p;
		Vector3 n;
		Vector3 u;
		HardwareDesign.GetPoint(at.Index, at.Type, _vertices, _normals, _tris, Matrix4x4.identity, att.Roll, out p, out n, out u);
		_activeAttRoot = new GameObject(att.Object);
		_activeAttRoot.transform.SetParent(Root, false);
		_activeAttRoot.transform.localPosition = p;
		_activeAttRoot.transform.localRotation = Quaternion.LookRotation(n, u);
		_activeAttObj.transform.SetParent(_activeAttRoot.transform, false);
		_activeAttObj.transform.localPosition = att.Offset;
		_activeAttObj.transform.localRotation = Quaternion.Euler(att.Rotation);
		_activeAttObj.GetComponent<Renderer>().sharedMaterial = _activeMat;
		_activeGizmo = _activeAttObj.AddComponent<TransformGizmo>();
		_activeGizmo.Circle = Circle;
		_activeGizmo.Arrow = Arrow;
		_activeGizmo.Mat = GizmoMat;
		_activeGizmo.Scale = 0.5f;
		MoveRotUpdate();
		ChangeState(State.FixAttachment);
		_activeAtt = att;
		_activeAttPoint = at;
		UpdateAttachmentFlip();
	}

	private void InitBaseMorphs(HardwareDesign.MeshObject baseMesh)
	{
		int num = 0;
		for (int i = 0; i < baseMesh.MorphTargets.Length; i++)
		{
			HardwareDesign.MorphInfo mo = baseMesh.MorphTargets[i];
			InputField inputField = UnityEngine.Object.Instantiate(InputPrefab);
			inputField.text = mo.Label;
			inputField.transform.SetParent(SliderPanel);
			inputField.onEndEdit.AddListener(delegate(string x)
			{
				mo.Label = x;
				MarkAsChanged();
			});
			GameObject obj = UnityEngine.Object.Instantiate(SliderPrefab);
			Slider componentInChildren = obj.GetComponentInChildren<Slider>();
			Button[] componentsInChildren = obj.GetComponentsInChildren<Button>();
			componentsInChildren[0].onClick.AddListener(delegate
			{
				MorphWindow.Show(mo);
			});
			componentsInChildren[1].gameObject.SetActive(false);
			if (!mo.DoubleMorph && i == baseMesh.MorphTargets.Length - 1)
			{
				componentsInChildren[2].gameObject.SetActive(false);
			}
			else
			{
				componentsInChildren[2].onClick.AddListener(delegate
				{
					CreateDoubleMorph(baseMesh, mo, true);
				});
			}
			componentInChildren.value = (mo.DoubleMorph ? 0.5f : 0f);
			componentInChildren.maxValue = 1f;
			int k1 = num;
			componentInChildren.onValueChanged.AddListener(delegate(float x)
			{
				HardwareDesignInstance.SetBlend(x, _activeBaseSkin, k1, mo);
				if (mo.GroupID >= 0)
				{
					DuplicateMorph(mo.GroupID, x);
				}
				UpdateMeshData(false);
			});
			num = ((!mo.DoubleMorph) ? (num + 1) : (num + 2));
			obj.transform.SetParent(SliderPanel);
		}
	}

	private void SetActive(HardwareDesign design)
	{
		ActiveDesign = design;
		string text = ActiveDesign.CheckForErrors();
		if (text != null)
		{
			WindowManager.Instance.ShowMessageBox(text, true, DialogWindow.DialogType.Error);
		}
		HardwareDesign.MeshObject meshObject = design.GetObject(design.BaseMesh);
		if (meshObject != null)
		{
			GameObject gameObject = design.SpawnObject(meshObject, out _isSkinned);
			gameObject.transform.SetParent(Root);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			if (_isSkinned)
			{
				_activeBaseSkin = gameObject.GetComponent<SkinnedMeshRenderer>();
				_activeRend = _activeBaseSkin;
				InitBaseMorphs(meshObject);
			}
			else
			{
				_activeBase = gameObject.GetComponent<MeshFilter>();
				_activeRend = gameObject.GetComponent<Renderer>();
			}
			UpdateMeshData(true);
			_activeMat = new Material(design.Mat);
			if (design.ColorSets.Count > 0)
			{
				if (design.ColorPrimary && design.ColorSets[0].Primaries.Count > 0)
				{
					_activeMat.SetColor("_Color1", design.ColorSets[0].Primaries[0]);
				}
				if (design.ColorSecondary && design.ColorSets[0].Secondaries.Count > 0)
				{
					_activeMat.SetColor("_Color2", design.ColorSets[0].Secondaries[0]);
				}
				if (design.ColorTertiary && design.ColorSets[0].Tertieries.Count > 0)
				{
					_activeMat.SetColor("_Color3", design.ColorSets[0].Tertieries[0]);
				}
			}
			_activeRend.sharedMaterial = _activeMat;
			ClearCurrentState(true);
			for (int i = 0; i < design.Objects.Length; i++)
			{
				HardwareDesign.MeshObject obj = design.Objects[i];
				Button button = UnityEngine.Object.Instantiate(ButtonPrefab);
				button.GetComponentInChildren<Text>().text = obj.ID;
				button.onClick.AddListener(delegate
				{
					EditMeshObject(obj);
				});
				button.transform.SetParent(MeshObjectPanel, false);
			}
			for (int num = 0; num < design.Attachments.Count; num++)
			{
				HardwareDesign.AttachmentPoint ap = design.Attachments[num];
				HardwareAttachmentPoint hardwareAttachmentPoint = UnityEngine.Object.Instantiate(AtPointPrefab);
				hardwareAttachmentPoint.Init(this, ap);
				hardwareAttachmentPoint.transform.SetParent(AttPanel);
			}
			PrimaryColorToggle.isOn = design.ColorPrimary;
			SecondaryColorToggle.isOn = design.ColorSecondary;
			TertiaryColorToggle.isOn = design.ColorTertiary;
			RefreshColorSet();
			Root.rotation = Quaternion.Euler(Vert, Horz, 0f);
			HardwareDesign.MeshObject meshObject2 = ActiveDesign.Objects.FirstOrDefault((HardwareDesign.MeshObject x) => x.Mesh.blendShapeCount != x.MorphTargets.SumSafe((HardwareDesign.MorphInfo z) => (!z.DoubleMorph) ? 1 : 2));
			if (meshObject2 != null)
			{
				WindowManager.Instance.ShowMessageBox(meshObject2.ID + " doesn't have the same number of morph targets defined as available in mesh", true, DialogWindow.DialogType.Warning);
			}
			ActiveButtons.ForEachEnum(delegate(GameObject x)
			{
				x.SetActive(true);
			});
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("Design is missing base mesh!", true, DialogWindow.DialogType.Error);
		}
	}

	private int RaycastTriangle(int[] tris, Vector3[] verts, Matrix4x4 mat)
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float num = float.MaxValue;
		int result = -1;
		for (int i = 0; i < tris.Length; i += 3)
		{
			Vector3 p = mat.MultiplyPoint(verts[tris[i]]);
			Vector3 p2 = mat.MultiplyPoint(verts[tris[i + 1]]);
			Vector3 p3 = mat.MultiplyPoint(verts[tris[i + 2]]);
			float dist;
			if (Utilities.TestTriangleIntersection(p, p2, p3, ray, out dist) && dist < num)
			{
				num = dist;
				result = i;
			}
		}
		return result;
	}

	private HardwareDesign.AttachmentType GetBestFit(ref int tr, int[] tris, Vector3[] verts, Matrix4x4 mat, bool onlyVertex)
	{
		Vector3 vector = mat.MultiplyPoint(verts[tris[tr]]);
		Vector3 vector2 = mat.MultiplyPoint(verts[tris[tr + 1]]);
		Vector3 vector3 = mat.MultiplyPoint(verts[tris[tr + 2]]);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane plane = new Plane(Vector3.Cross(vector2 - vector, vector3 - vector).normalized, vector);
		float enter;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		float num = (onlyVertex ? float.MaxValue : (point - (vector + vector2 + vector3) * (1f / 3f)).sqrMagnitude);
		int num2 = tr;
		enter = (point - vector).sqrMagnitude;
		HardwareDesign.AttachmentType result = HardwareDesign.AttachmentType.Triangle;
		if (enter < num)
		{
			num2 = tris[tr];
			num = enter;
			result = HardwareDesign.AttachmentType.Vertex;
		}
		enter = (point - vector2).sqrMagnitude;
		if (enter < num)
		{
			num2 = tris[tr + 1];
			num = enter;
			result = HardwareDesign.AttachmentType.Vertex;
		}
		enter = (point - vector3).sqrMagnitude;
		if (enter < num)
		{
			num2 = tris[tr + 2];
			result = HardwareDesign.AttachmentType.Vertex;
		}
		tr = num2;
		return result;
	}

	private void AttachmentState()
	{
		int tr = RaycastTriangle(_tris, _vertices, Root.localToWorldMatrix);
		if (tr >= 0)
		{
			HardwareDesign.AttachmentType bestFit = GetBestFit(ref tr, _tris, _vertices, Root.localToWorldMatrix, false);
			Vector3 p;
			Vector3 n;
			Vector3 u;
			HardwareDesign.GetPoint(tr, bestFit, _vertices, _normals, _tris, Root.localToWorldMatrix, true, out p, out n, out u);
			VertexHighlight.position = p;
			VertexHighlight.rotation = Quaternion.LookRotation(n, u);
			VertexHighlight.gameObject.SetActive(true);
			if (!Input.GetMouseButtonUp(0))
			{
				return;
			}
			if (_activeAttPoint != null)
			{
				HardwareDesign.GetPoint(tr, bestFit, _vertices, _normals, _tris, Matrix4x4.identity, true, out p, out n, out u);
				Vector3 p2;
				Vector3 n2;
				Vector3 u2;
				HardwareDesign.GetPoint(_activeAttPoint.Index, _activeAttPoint.Type, _vertices, _normals, _tris, Matrix4x4.identity, true, out p2, out n2, out u2);
				foreach (HardwareDesign.Attachment attachment in _activeAttPoint.Attachments)
				{
					Matrix4x4 matrix4x = Matrix4x4.TRS(p2, Quaternion.LookRotation(n2, u2), Vector3.one);
					Matrix4x4 inverse = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one).inverse;
					attachment.Offset = inverse.MultiplyPoint(matrix4x.MultiplyPoint(attachment.Offset));
					attachment.Rotation = (inverse.rotation * matrix4x.rotation * Quaternion.Euler(attachment.Rotation)).eulerAngles;
				}
				_activeAttPoint.Index = tr;
				_activeAttPoint.Type = bestFit;
			}
			else
			{
				HardwareDesign.AttachmentPoint attachmentPoint = new HardwareDesign.AttachmentPoint(tr, bestFit);
				ActiveDesign.Attachments.Add(attachmentPoint);
				HardwareAttachmentPoint hardwareAttachmentPoint = UnityEngine.Object.Instantiate(AtPointPrefab);
				hardwareAttachmentPoint.Init(this, attachmentPoint);
				hardwareAttachmentPoint.transform.SetParent(AttPanel);
				LayoutRebuilder.ForceRebuildLayoutImmediate(AttPanel);
			}
			MarkAsChanged();
			RefreshAttachmentPoints();
			ClearCurrentState(true);
		}
		else
		{
			VertexHighlight.gameObject.SetActive(false);
		}
	}

	public void ClearCurrentState(bool canExitMeshObjectEdit)
	{
		switch (CurrentState)
		{
		case State.AddAttachment:
			_activeRend.sharedMaterials = new Material[1] { _activeRend.sharedMaterials[0] };
			VertexHighlight.gameObject.SetActive(false);
			break;
		case State.FixAttachment:
			UnityEngine.Object.Destroy(_activeAttRoot);
			break;
		case State.Preview:
			UnityEngine.Object.Destroy(_activePreview.gameObject);
			Root.gameObject.SetActive(true);
			break;
		case State.MeshObjectEdit:
			if (canExitMeshObjectEdit)
			{
				if (_meshObjectRend != null)
				{
					UnityEngine.Object.Destroy(_meshObjectRend.gameObject);
				}
				_activeMeshObject = null;
				Root.gameObject.SetActive(true);
			}
			break;
		case State.MorphTargetEdit:
			_meshObjectRend.sharedMaterials = new Material[1] { _meshObjectRend.sharedMaterials[0] };
			CustomMorphPos.transform.SetParent(null);
			CustomMorphPos.gameObject.SetActive(false);
			if (_customMorphGizmo != null)
			{
				UnityEngine.Object.Destroy(_customMorphGizmo);
			}
			break;
		case State.MoveAttachmentOffset:
			UnityEngine.Object.Destroy(_activeGizmo);
			AttachmentOffset.SetActive(false);
			_activeAttPoint = null;
			break;
		}
		StartPanelObject.SetActive(false);
		if (canExitMeshObjectEdit)
		{
			ChangeState(State.None);
			MeshPanel.SetActive(false);
			MainPanel.SetActive(true);
		}
		else if (CurrentState == State.MorphTargetEdit)
		{
			ChangeState(State.MeshObjectEdit);
		}
		else if (CurrentState != State.MeshObjectEdit)
		{
			ChangeState(State.None);
			MeshPanel.SetActive(false);
			MainPanel.SetActive(true);
		}
	}

	private void UpdateAttachmentFlip()
	{
		_activeAttObj.transform.localScale = new Vector3((!_activeAtt.FlipX) ? 1 : (-1), (!_activeAtt.FlipY) ? 1 : (-1), (!_activeAtt.FlipZ) ? 1 : (-1));
	}

	public void BeginMorphHandleState(int idx)
	{
		ClearCurrentState(false);
		ChangeState(State.MorphTargetEdit);
		HardwareDesign.MorphInfo morphInfo = _activeMeshObject.MorphTargets[idx];
		_morphTagetIndex = idx;
		_morphMagnitude = morphInfo.HandleMagnitude;
		_customMorphHandle = morphInfo.UseCustomHandle;
		CustomMorphPos.gameObject.SetActive(_customMorphHandle);
		if (_customMorphHandle)
		{
			_customMorphGizmo = CustomMorphPos.gameObject.AddComponent<TransformGizmo>();
			_customMorphGizmo.Circle = Circle;
			_customMorphGizmo.Arrow = Arrow;
			_customMorphGizmo.Mat = GizmoMat;
			_customMorphGizmo.Scale = 0.5f;
			MoveRotUpdate();
		}
		CustomMorphPos.SetParent(_meshObjectRend.transform, false);
		CustomMorphPos.transform.position = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(morphInfo.CustomHandle);
		CustomMorphPos.rotation = _meshObjectRend.transform.localToWorldMatrix.MultiplyVector(morphInfo.CustomHandleDir).LookDir();
		CustomMorphPos.localScale = new Vector3(0.5f, 0.5f, _morphMagnitude);
		_meshObjectRend.sharedMaterials = new Material[2]
		{
			_meshObjectRend.sharedMaterials[0],
			WireMat
		};
		_meshObjectMorphVert = morphInfo.VertexIndex;
		int actualMorphIndex = _activeMeshObject.GetActualMorphIndex(idx);
		SkinnedMeshRenderer skinnedMeshRenderer = _meshObjectRend as SkinnedMeshRenderer;
		Mesh mesh = new Mesh();
		if (morphInfo.DoubleMorph)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex, 0f);
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex + 1, 100f);
			skinnedMeshRenderer.BakeMesh(mesh);
			_subVertsMax = mesh.vertices;
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex, 100f);
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex + 1, 0f);
			skinnedMeshRenderer.BakeMesh(mesh);
			_subTrisMin = mesh.triangles;
			_subVertsMin = mesh.vertices;
		}
		else
		{
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex, 100f);
			skinnedMeshRenderer.BakeMesh(mesh);
			_subVertsMax = mesh.vertices;
			skinnedMeshRenderer.SetBlendShapeWeight(actualMorphIndex, 0f);
			skinnedMeshRenderer.BakeMesh(mesh);
			_subTrisMin = mesh.triangles;
			_subVertsMin = mesh.vertices;
		}
		UnityEngine.Object.Destroy(mesh);
		MainPanel.SetActive(false);
		MeshPanel.SetActive(true);
	}

	private void EndMorphHandleState()
	{
		HardwareDesign.MorphInfo morphInfo = _activeMeshObject.MorphTargets[_morphTagetIndex];
		morphInfo.HandleMagnitude = _morphMagnitude;
		morphInfo.UseCustomHandle = _customMorphHandle;
		if (_customMorphHandle)
		{
			morphInfo.CustomHandle = _meshObjectRend.transform.worldToLocalMatrix.MultiplyPoint(CustomMorphPos.transform.position);
			morphInfo.CustomHandleDir = _meshObjectRend.transform.worldToLocalMatrix.MultiplyVector(CustomMorphPos.transform.rotation * Vector3.forward);
		}
		else
		{
			morphInfo.VertexIndex = _meshObjectMorphVert;
		}
		MarkAsChanged();
		ClearCurrentState(false);
	}

	private void MorphHandleState()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (_customMorphHandle)
			{
				UnityEngine.Object.Destroy(_customMorphGizmo);
			}
			else
			{
				Vector3 vector = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(_subVertsMin[_meshObjectMorphVert]);
				Vector3 vector2 = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(_subVertsMax[_meshObjectMorphVert]);
				CustomMorphPos.position = vector;
				CustomMorphPos.rotation = Quaternion.LookRotation(vector2 - vector);
				CustomMorphPos.localScale = new Vector3(0.5f, 0.5f, _morphMagnitude);
				_customMorphGizmo = CustomMorphPos.gameObject.AddComponent<TransformGizmo>();
				_customMorphGizmo.Circle = Circle;
				_customMorphGizmo.Arrow = Arrow;
				_customMorphGizmo.Mat = GizmoMat;
				_customMorphGizmo.Scale = 0.5f;
				MoveRotUpdate();
			}
			_customMorphHandle = !_customMorphHandle;
			CustomMorphPos.gameObject.SetActive(_customMorphHandle);
		}
		if (_customMorphHandle)
		{
			_customMorphGizmo.CurrentAction = (Input.GetKey(KeyCode.LeftControl) ? TransformGizmo.Action.Rotate : TransformGizmo.Action.Move);
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				CustomMorphPos.localPosition = Vector3.zero;
				CustomMorphPos.localRotation = Quaternion.identity;
			}
		}
		else
		{
			int tr = RaycastTriangle(_subTrisMin, _subVertsMin, _meshObjectRend.transform.localToWorldMatrix);
			if (tr >= 0 && GetBestFit(ref tr, _subTrisMin, _subVertsMin, _meshObjectRend.transform.localToWorldMatrix, true) == HardwareDesign.AttachmentType.Vertex)
			{
				_meshObjectMorphVert = tr;
				if (Input.GetMouseButtonDown(0))
				{
					EndMorphHandleState();
				}
			}
			Vector3 vector3 = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(_subVertsMin[_meshObjectMorphVert]);
			Vector3 vector4 = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(_subVertsMax[_meshObjectMorphVert]);
			Graphics.DrawMesh(Arrow, Matrix4x4.TRS(vector3, (vector4 - vector3).LookDir(), new Vector3(0.5f, 0.5f, (vector3 - vector4).magnitude * _morphMagnitude)), GizmoMat, 0, Camera.main, 0, null, false, false);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			_morphMagnitude += 0.1f;
			CustomMorphPos.localScale = new Vector3(0.5f, 0.5f, _morphMagnitude);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			_morphMagnitude = Mathf.Max(0.1f, _morphMagnitude - 0.1f);
			CustomMorphPos.localScale = new Vector3(0.5f, 0.5f, _morphMagnitude);
		}
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			EndMorphHandleState();
		}
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetColor("_Color", Color.cyan);
		for (int i = 0; i < _activeMeshObject.MorphTargets.Length; i++)
		{
			if (i != _morphTagetIndex)
			{
				HardwareDesign.MorphInfo morphInfo = _activeMeshObject.MorphTargets[i];
				Vector3 pos = _meshObjectRend.transform.localToWorldMatrix.MultiplyPoint(_subVertsMin[morphInfo.VertexIndex]);
				Graphics.DrawMesh(Sphere, Matrix4x4.TRS(pos, Quaternion.identity, Vector3.one * 0.02f), GizmoMat, 0, Camera.main, 0, materialPropertyBlock, false, false);
			}
		}
	}

	private void ChangeSlider(Slider s, float change)
	{
		if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
		{
			s.value += change * 0.1f;
		}
		else
		{
			s.value += change;
		}
	}

	private void Update()
	{
		if (CurrentState == State.Launch)
		{
			return;
		}
		if (Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.Escape))
		{
			ClearCurrentState(CurrentState != State.MorphTargetEdit);
		}
		if (CurrentState == State.AddAttachment)
		{
			AttachmentState();
		}
		if (CurrentState != State.Preview && CurrentState != State.MeshObjectEdit && CurrentState != State.MorphTargetEdit)
		{
			RenderAtts();
		}
		if (CurrentState == State.MorphTargetEdit)
		{
			MorphHandleState();
		}
		if (CurrentState == State.MeshObjectEdit)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				ChangeSlider(AtlasX, -0.001f);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				ChangeSlider(AtlasX, 0.001f);
			}
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				ChangeSlider(AtlasY, -0.001f);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				ChangeSlider(AtlasY, 0.001f);
			}
		}
		if (CurrentState == State.MoveAttachmentOffset)
		{
			if (Input.GetKeyDown(KeyCode.Backspace))
			{
				Vector3 p;
				Vector3 n;
				Vector3 u;
				HardwareDesign.GetPoint(_activeAttPoint.Index, _activeAttPoint.Type, _vertices, _normals, _tris, Root.localToWorldMatrix, false, out p, out n, out u);
				Matrix4x4 matrix4x = Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one);
				AttachmentOffset.transform.position = matrix4x.MultiplyPoint(Vector3.zero);
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				Vector3 p2;
				Vector3 n2;
				Vector3 u2;
				HardwareDesign.GetPoint(_activeAttPoint.Index, _activeAttPoint.Type, _vertices, _normals, _tris, Root.localToWorldMatrix, false, out p2, out n2, out u2);
				Matrix4x4 matrix4x2 = Matrix4x4.TRS(p2, Quaternion.LookRotation(n2, u2), Vector3.one);
				_activeAttPoint.AreaOffset = matrix4x2.inverse.MultiplyPoint(AttachmentOffset.transform.position);
				ClearCurrentState(true);
				MarkAsChanged();
			}
		}
		if (CurrentState == State.FixAttachment)
		{
			_activeGizmo.CurrentAction = (Input.GetKey(KeyCode.LeftControl) ? TransformGizmo.Action.Rotate : TransformGizmo.Action.Move);
			if (Input.GetKeyUp(KeyCode.X))
			{
				_activeAtt.FlipX = !_activeAtt.FlipX;
				UpdateAttachmentFlip();
				MarkAsChanged();
			}
			if (Input.GetKeyUp(KeyCode.Y))
			{
				_activeAtt.FlipY = !_activeAtt.FlipY;
				UpdateAttachmentFlip();
				MarkAsChanged();
			}
			if (Input.GetKeyUp(KeyCode.Z))
			{
				_activeAtt.FlipZ = !_activeAtt.FlipZ;
				UpdateAttachmentFlip();
				MarkAsChanged();
			}
			if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
			{
				_activeAtt.Offset = _activeAttObj.transform.localPosition;
				_activeAtt.Rotation = _activeAttObj.transform.localRotation.eulerAngles;
				ClearCurrentState(true);
				MarkAsChanged();
			}
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		float z = CameraT.transform.localPosition.z;
		CameraT.transform.localPosition = new Vector3(0f, 0f, Mathf.Clamp(z + Input.mouseScrollDelta.y * 0.5f, -10f, -1f));
		if ((CurrentState != State.FixAttachment || !_activeGizmo.IsDragging) && CurrentState != State.MoveAttachmentOffset && (_customMorphGizmo == null || !_customMorphGizmo.IsDragging))
		{
			if (Input.GetMouseButtonDown(0))
			{
				_isDragging = true;
				_lastMouse = Input.mousePosition;
			}
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
			if (_isDragging)
			{
				Vector2 vector = Input.mousePosition;
				Vector2 vector2 = (_lastMouse - vector) * RotSpeed;
				Horz = (Horz + vector2.x) % 360f;
				Vert = Mathf.Clamp(Vert - vector2.y, -90f + ActiveDesign.RotOffset, 90f + ActiveDesign.RotOffset);
				((CurrentState == State.Preview) ? _activePreview.transform : ((CurrentState == State.MeshObjectEdit || CurrentState == State.MorphTargetEdit) ? _meshObjectRend.transform : Root)).rotation = Quaternion.Euler(Vert, Horz, 0f);
				_lastMouse = vector;
			}
		}
		else
		{
			_isDragging = false;
		}
	}

	public void ReloadDesign()
	{
		if (Changed)
		{
			WindowManager.Instance.ShowMessageBox("Are you sure you want to reload?\nAny unsaved changes will be lost", true, DialogWindow.DialogType.Question, ActuallyReloadDesign);
		}
		else
		{
			ActuallyReloadDesign();
		}
	}

	private void ActuallyReloadDesign()
	{
		ModPackage parent = ActiveDesign.Parent;
		if (parent != null)
		{
			ModPackage item;
			try
			{
				item = ModPackage.Load(parent.Root);
			}
			catch (Exception ex)
			{
				WindowManager.Instance.ShowMessageBox("Failed reloading mod:\n" + ex.ToString(), true, DialogWindow.DialogType.Error);
				return;
			}
			parent.Unload();
			ModWindow.RemoveMod(parent);
			GameData.ModPackages.Remove(parent);
			GameData.ModPackages.Add(item);
			LoadDesign = ActiveDesign.ID;
			FrameTransition.StartTransition(true);
			ErrorLogging.FirstOfScene = true;
			ErrorLogging.SceneChanging = true;
			DevConsole.Console.SaveConsole();
			SceneManager.LoadScene("HardwareDesignEditor");
		}
	}

	public void ShowCreationDialog(ModPackage parent)
	{
		_creationParent = parent;
		_creationRoot = Path.Combine(parent.Root, "HardwareDesign");
		WindowManager.SpawnInputDialog("Pick your hardware design's name", "Hardware design", "New hardware design", delegate(string x)
		{
			_creationName = x;
			CreationWindow.NonLocTitle = x;
			CreationWindow.Show();
			CreationWindow.OnClose = delegate
			{
				StartPanelObject.SetActive(true);
			};
			StartPanelObject.SetActive(false);
		});
	}

	public void SelectTex(int type)
	{
		string[] textures = Directory.GetFiles(_creationRoot, "*.png", SearchOption.AllDirectories).SelectInPlace((string x) => FurnitureModdingTool.ReplaceRoot(_creationRoot, x));
		WindowManager.Instance.MultiWindow.Show("Texture", textures, delegate(int i)
		{
			string text = ((i < 0) ? null : textures[i]);
			CreationTextureLabels[type].text = text;
			switch (type)
			{
			case 0:
				_creationMainTex = text;
				break;
			case 1:
				_creationExtraTex = text;
				break;
			case 2:
				_creationNormalTex = text;
				break;
			}
		}, true);
	}

	public void FinishCreation()
	{
		if (_creationBaseMesh != null && _creationMainTex != null)
		{
			List<string> list = new List<string> { _creationBaseMesh };
			for (int i = 3; i < CreationMeshPanel.childCount - 1; i++)
			{
				list.Add(CreationMeshPanel.GetChild(i).GetComponentInChildren<Text>().text);
			}
			string error = null;
			HardwareDesign hardwareDesign = HardwareDesign.CreateDesign(_creationName, Path.Combine(_creationRoot, _creationName + ".tyd"), _creationBaseMesh, list.ToArray(), _creationMainTex, _creationExtraTex, _creationNormalTex, out error);
			if (hardwareDesign == null)
			{
				WindowManager.Instance.ShowMessageBox("Failed creating design with error:\n" + error, true, DialogWindow.DialogType.Error, CreationWindow);
				return;
			}
			hardwareDesign.Parent = _creationParent;
			Utilities.AddElement(ref _creationParent.HardwareDesigns, hardwareDesign);
			ObjectDatabase.Instance.HardwareDesigns[hardwareDesign.ID] = hardwareDesign;
			IsCreation = true;
			CreationWindow.OnClose = null;
			CreationWindow.Close();
			SetActive(hardwareDesign);
		}
	}

	public void AddNewMesh(bool baseMesh)
	{
		string[] meshes = (from x in Directory.GetFiles(_creationRoot, "*.obj", SearchOption.AllDirectories).Concat(Directory.GetFiles(_creationRoot, "*.gltf", SearchOption.AllDirectories)).Concat(Directory.GetFiles(_creationRoot, "*.glb", SearchOption.AllDirectories))
			select FurnitureModdingTool.ReplaceRoot(_creationRoot, x)).ToArray();
		WindowManager.Instance.MultiWindow.Show("Mesh", meshes, delegate(int i)
		{
			if (baseMesh)
			{
				HardwareDesignEditor hardwareDesignEditor = this;
				string creationBaseMesh = (CreationMeshPanel.GetChild(1).GetComponentInChildren<Text>().text = meshes[i]);
				hardwareDesignEditor._creationBaseMesh = creationBaseMesh;
			}
			else
			{
				Button b = UnityEngine.Object.Instantiate(ButtonPrefab);
				b.GetComponentInChildren<Text>().text = meshes[i];
				b.onClick.AddListener(delegate
				{
					UnityEngine.Object.Destroy(b.gameObject);
				});
				b.transform.SetParent(CreationMeshPanel);
				b.transform.SetSiblingIndex(CreationMeshPanel.childCount - 2);
			}
		}, false);
	}
}
