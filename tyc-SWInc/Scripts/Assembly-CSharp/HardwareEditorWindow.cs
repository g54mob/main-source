using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Achievements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HardwareEditorWindow : MonoBehaviour
{
	public GUIWindow Window;

	public RawImage MainView;

	public Toggle TogglePrefab;

	public Transform TogglePanel;

	public ToggleGroup TGroup;

	public float Horz;

	public float Vert;

	public float SpinSpeed = 45f;

	public float Drag = 5f;

	public float MorphHandleScale = 0.1f;

	public float MorphFadeSpeed = 4f;

	public GameObject[] ColorButtons;

	public Mesh MorphHandleMesh;

	public Mesh SphereMesh;

	public Material MorphHandleMaterial;

	public Material Outline;

	public Image[] ColorAccents;

	public Text MainLabel;

	public Text StyleLabel;

	public GameObject StyleSelector;

	public GameObject ObjectButtonPrefab;

	public RectTransform ThumbnailPanel;

	public RectTransform RemoveObjectButton;

	private RectTransform _objectDrag;

	private HardwareDesign.MeshObject _moDrag;

	private Vector2 _momentum;

	public bool Spin = true;

	private bool _dragging;

	private Vector2 _lastMouse;

	[NonSerialized]
	private HardwareDesignInstance _instance;

	[NonSerialized]
	private HardwareDesign.AttachmentPoint _active;

	[NonSerialized]
	private HardwareDesign.AttachmentPoint _activeSelect;

	[NonSerialized]
	private List<Matrix4x4> morphHandles = new List<Matrix4x4>();

	[NonSerialized]
	private List<Vector3> attachmentPoints = new List<Vector3>();

	private bool _showMorph;

	private float _morphAlpha;

	private int? _activeHandle;

	private Vector3 _handleStart;

	private Vector3 _handleEnd;

	private int[] _tris;

	private Vector3[] _vertices;

	private Vector3[] _normals;

	private Mesh _activeMesh;

	private bool _destroyActiveMesh;

	private Action<byte[]> _onClose;

	public InputField CamX;

	public InputField CamY;

	public InputField CamZ;

	public InputField CamZoom;

	public InputField RotX;

	public InputField RotY;

	public InputField WorldScale;

	[NonSerialized]
	private List<Toggle> _toggles = new List<Toggle>();

	[NonSerialized]
	private HashSet<string> _disallowed = new HashSet<string>();

	[NonSerialized]
	private IList<FeatureBase> _features;

	[NonSerialized]
	private Manufacturing _manufacturing;

	[NonSerialized]
	private List<RenderTexture> _tempTextures = new List<RenderTexture>();

	[NonSerialized]
	private HashSet<HardwareDesign.AttachmentPoint> _ignoreMorph = new HashSet<HardwareDesign.AttachmentPoint>();

	private bool _enableCamChange = true;

	[NonSerialized]
	private byte[] _serialized;

	[NonSerialized]
	private bool _init;

	private int _lastClosest = -1;

	[NonSerialized]
	private List<RaycastResult> _raycastCache = new List<RaycastResult>();

	private float _clicked;

	private bool _tooltip;

	public void CamSettingsChanged()
	{
		if (_enableCamChange)
		{
			HardwareDesign design = _instance.Design;
			Vector3 vector = new Vector3(CamX.text.ConvertToFloatDef(design.ThumbnailOffset.x), CamY.text.ConvertToFloatDef(design.ThumbnailOffset.y), CamZ.text.ConvertToFloatDef(design.ThumbnailOffset.z));
			float num = CamZoom.text.ConvertToFloatDef(design.ZoomOffset);
			float num2 = WorldScale.text.ConvertToFloatDef(design.WorldScale);
			if (HardwareDesignEditor.Instance != null && (design.ThumbnailOffset != vector || design.ZoomOffset != num || design.WorldScale != num2))
			{
				HardwareDesignEditor.Instance.MarkAsChanged();
			}
			design.ThumbnailOffset = vector;
			design.ZoomOffset = num;
			design.WorldScale = num2;
			HardwareDesignRenderer.Instance.LoadCamPos(design);
		}
	}

	public void RotChanged()
	{
		if (_enableCamChange)
		{
			Spin = false;
			HardwareDesign design = _instance.Design;
			float num = RotX.text.ConvertToFloatDef(design.RotOffsetX);
			float num2 = RotY.text.ConvertToFloatDef(design.RotOffset);
			if (HardwareDesignEditor.Instance != null && (design.RotOffsetX != num || design.RotOffset != num2))
			{
				HardwareDesignEditor.Instance.MarkAsChanged();
			}
			design.RotOffsetX = num;
			design.RotOffset = num2;
			Horz = design.RotOffsetX - 60f;
			Vert = design.RotOffset + 10f;
			UpdateRot();
		}
	}

	public void Save()
	{
		_serialized = _instance.Serialize();
		Debug.Log("Saved design: " + _serialized.Length + " bytes");
	}

	public void Load()
	{
		if (_serialized != null)
		{
			_instance = HardwareDesignRenderer.Instance.BeginRend(HardwareDesignInstance.Deserialize(_serialized, 9));
		}
	}

	public void UpdateAttachmentPanel()
	{
		if (_active == null)
		{
			StyleSelector.SetActive(_instance.BaseObject.AtlasCount > 1);
			if (_instance.BaseObject.AtlasCount > 1)
			{
				StyleLabel.text = "Style".Loc() + " (" + (_instance.Style + 1) + "/" + _instance.BaseObject.AtlasCount + ")";
			}
			return;
		}
		HardwareDesign.MeshObject activeObject = GetActiveObject();
		int num = ((activeObject == null) ? 1 : activeObject.AtlasCount);
		StyleSelector.SetActive(num > 1);
		if (num > 1)
		{
			StyleLabel.text = "Style".Loc() + " (" + (_instance.Styles.GetOrDefault(_active, 0) + 1) + "/" + num + ")";
		}
	}

	public void ChangeStyle(int i)
	{
		HardwareDesign.MeshObject activeObject = GetActiveObject();
		_instance.OffsetAtlas(GetActiveRend(), activeObject, _active, i);
		if (_active == null)
		{
			StyleLabel.text = "Style".Loc() + " (" + (_instance.Style + 1) + "/" + _instance.BaseObject.AtlasCount + ")";
		}
		else
		{
			int num = ((activeObject == null) ? 1 : activeObject.AtlasCount);
			StyleLabel.text = "Style".Loc() + " (" + (_instance.Styles.GetOrDefault(_active, 0) + 1) + "/" + num + ")";
		}
	}

	public void SetColor(int i)
	{
		ColorWindow colorWindow = WindowManager.SpawnColorDialog(delegate(Color x)
		{
			_instance.SetColor(i, x);
			ColorAccents[i].color = x;
		}, _instance.Colors[i], _instance.Design.GetDefaults(i).ToHashSet());
		colorWindow.Window.SetParentWindow(Window, true);
		colorWindow.Window.HideBlockPanel = false;
	}

	public void Randomize()
	{
		_instance.Randomize(_disallowed);
		for (int i = 0; i < ColorAccents.Length; i++)
		{
			if (ColorButtons[i].activeSelf)
			{
				ColorAccents[i].color = _instance.Colors[i];
			}
		}
		_active = null;
		RemoveObjectButton.gameObject.SetActive(false);
		_activeSelect = null;
		_activeHandle = null;
		RefreshBaseMesh(true);
		UpdateAttachmentPanel();
		RefreshHandles();
		UpdateActiveMesh(null);
		_ignoreMorph.Clear();
	}

	public void RandomizeColors()
	{
		HardwareDesign.ColorSet random = _instance.Design.ColorSets.GetRandom();
		if (_instance.Design.ColorPrimary)
		{
			_instance.SetColor(0, random.Primaries.GetRandom());
		}
		if (_instance.Design.ColorSecondary)
		{
			_instance.SetColor(1, random.Secondaries.GetRandom());
		}
		if (_instance.Design.ColorTertiary)
		{
			_instance.SetColor(2, random.Tertieries.GetRandom());
		}
		for (int i = 0; i < ColorAccents.Length; i++)
		{
			if (ColorButtons[i].activeSelf)
			{
				ColorAccents[i].color = _instance.Colors[i];
			}
		}
	}

	public Transform GetActiveTransform()
	{
		if (_active != null)
		{
			Renderer orDefault = _instance.Objects.GetOrDefault(_active);
			if (orDefault != null)
			{
				return orDefault.transform;
			}
		}
		return _instance.transform;
	}

	private void RefreshBaseMesh(bool first)
	{
		Renderer renderer = _instance.Base;
		if (renderer is SkinnedMeshRenderer)
		{
			Mesh mesh = new Mesh();
			((SkinnedMeshRenderer)renderer).BakeMesh(mesh);
			_vertices = mesh.vertices;
			_normals = mesh.normals;
			_tris = mesh.triangles;
			UnityEngine.Object.Destroy(mesh);
		}
		else if (first)
		{
			Mesh sharedMesh = renderer.GetComponent<MeshFilter>().sharedMesh;
			_vertices = sharedMesh.vertices;
			_normals = sharedMesh.normals;
			_tris = sharedMesh.triangles;
		}
		attachmentPoints.Clear();
		for (int i = 0; i < _instance.Design.Attachments.Count; i++)
		{
			HardwareDesign.AttachmentPoint att = _instance.Design.Attachments[i];
			attachmentPoints.Add(GetPoint(att, Matrix4x4.identity));
		}
	}

	private void SetHandlePos(int idx)
	{
		HardwareDesign.MeshObject activeObject = GetActiveObject();
		HardwareDesign.MorphInfo morphInfo = activeObject.MorphTargets[idx];
		if (morphInfo.UseCustomHandle)
		{
			_handleStart = morphInfo.CustomHandle + morphInfo.CustomHandleDir * MorphHandleScale * 2f;
			_handleEnd = morphInfo.CustomHandle + morphInfo.CustomHandleDir + morphInfo.CustomHandleDir * MorphHandleScale * 2f;
		}
		else
		{
			SkinnedMeshRenderer activeSkin = GetActiveSkin();
			int actualMorphIndex = activeObject.GetActualMorphIndex(idx);
			Mesh mesh = new Mesh();
			float blendShapeWeight = activeSkin.GetBlendShapeWeight(actualMorphIndex);
			float value = 0f;
			activeSkin.SetBlendShapeWeight(actualMorphIndex, 0f);
			if (morphInfo.DoubleMorph)
			{
				value = activeSkin.GetBlendShapeWeight(actualMorphIndex + 1);
				activeSkin.SetBlendShapeWeight(actualMorphIndex + 1, 0f);
			}
			activeSkin.BakeMesh(mesh);
			Vector3[] vertices = mesh.vertices;
			UnityEngine.Object.Destroy(mesh);
			activeSkin.SetBlendShapeWeight(actualMorphIndex, blendShapeWeight);
			if (morphInfo.DoubleMorph)
			{
				activeSkin.SetBlendShapeWeight(actualMorphIndex + 1, value);
			}
			if (morphInfo.DoubleMorph)
			{
				Vector3[] blendVertices = activeObject.Mesh.GetBlendVertices(actualMorphIndex);
				Vector3 vector = blendVertices[morphInfo.VertexIndex];
				activeObject.Mesh.GetBlendVertices(actualMorphIndex + 1, blendVertices);
				Vector3 vector2 = blendVertices[morphInfo.VertexIndex];
				Vector3 normalized = (vector2 - vector).normalized;
				_handleStart = vertices[morphInfo.VertexIndex] + vector + normalized * MorphHandleScale * 2f;
				_handleEnd = vertices[morphInfo.VertexIndex] + vector2 + normalized * MorphHandleScale * 2f;
			}
			else
			{
				Vector3[] blendVertices2 = activeObject.Mesh.GetBlendVertices(actualMorphIndex);
				Vector3 normalized2 = blendVertices2[morphInfo.VertexIndex].normalized;
				_handleStart = vertices[morphInfo.VertexIndex] + normalized2 * MorphHandleScale * 2f;
				_handleEnd = vertices[morphInfo.VertexIndex] + blendVertices2[morphInfo.VertexIndex] + normalized2 * MorphHandleScale * 2f;
			}
		}
		_handleEnd = _handleStart + (_handleEnd - _handleStart) * morphInfo.HandleMagnitude;
	}

	private HardwareDesign.MeshObject GetActiveObject()
	{
		if (_active != null)
		{
			return _instance.MeshObjects.GetOrDefault(_active);
		}
		return _instance.BaseObject;
	}

	private Renderer GetActiveRend()
	{
		if (_active != null)
		{
			return _instance.Objects[_active];
		}
		return _instance.Base;
	}

	private SkinnedMeshRenderer GetActiveSkin()
	{
		return ((_active == null) ? _instance.Base : _instance.Objects[_active]) as SkinnedMeshRenderer;
	}

	private void RefreshHandles()
	{
		HardwareDesign.MeshObject activeObject = GetActiveObject();
		morphHandles.Clear();
		if (activeObject == null || activeObject.MorphTargets == null || activeObject.MorphTargets.Length == 0)
		{
			return;
		}
		SkinnedMeshRenderer activeSkin = GetActiveSkin();
		if (!(activeSkin != null))
		{
			return;
		}
		Mesh mesh = new Mesh();
		activeSkin.BakeMesh(mesh);
		Vector3[] vertices = mesh.vertices;
		UnityEngine.Object.Destroy(mesh);
		Vector3[] array = new Vector3[vertices.Length];
		int num = 0;
		for (int i = 0; i < activeObject.MorphTargets.Length; i++)
		{
			HardwareDesign.MorphInfo morphInfo = activeObject.MorphTargets[i];
			if (morphInfo.UseCustomHandle)
			{
				int actualMorphIndex = activeObject.GetActualMorphIndex(i);
				float num2;
				if (morphInfo.DoubleMorph)
				{
					float blendShapeWeight = activeSkin.GetBlendShapeWeight(actualMorphIndex);
					num2 = ((!(blendShapeWeight > 0f)) ? (0.5f + activeSkin.GetBlendShapeWeight(actualMorphIndex + 1) / 200f) : ((100f - blendShapeWeight) / 200f));
				}
				else
				{
					num2 = activeSkin.GetBlendShapeWeight(actualMorphIndex) / 100f;
				}
				morphHandles.Add(Matrix4x4.TRS(morphInfo.CustomHandle + morphInfo.CustomHandleDir * morphInfo.HandleMagnitude * num2 + morphInfo.CustomHandleDir * MorphHandleScale * 2f, Quaternion.LookRotation(morphInfo.CustomHandleDir), Vector3.one * MorphHandleScale));
				continue;
			}
			Vector3 normalized;
			if (morphInfo.DoubleMorph)
			{
				activeObject.Mesh.GetBlendVertices(num, array);
				Vector3 vector = array[morphInfo.VertexIndex];
				activeObject.Mesh.GetBlendVertices(num + 1, array);
				normalized = (array[morphInfo.VertexIndex] - vector).normalized;
				num += 2;
			}
			else
			{
				activeObject.Mesh.GetBlendVertices(num, array);
				normalized = array[morphInfo.VertexIndex].normalized;
				num++;
			}
			morphHandles.Add(Matrix4x4.TRS(vertices[morphInfo.VertexIndex] + normalized * MorphHandleScale * 2f, normalized.LookDir(), Vector3.one * MorphHandleScale));
		}
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			HardwareDesignRenderer.Instance.StopRend();
			_tempTextures.ForEach(UnityEngine.Object.Destroy);
			_tempTextures.Clear();
			UpdateActiveMesh(null);
			_active = null;
			RemoveObjectButton.gameObject.SetActive(false);
			_activeHandle = null;
		};
	}

	public void Close(bool callOnClose)
	{
		if (callOnClose && _onClose != null)
		{
			_onClose(_instance.Serialize());
			_onClose = null;
		}
		Window.Close();
	}

	private void ResetToggles()
	{
		for (int i = 0; i < _toggles.Count; i++)
		{
			UnityEngine.Object.Destroy(_toggles[i].gameObject);
		}
		_toggles.Clear();
	}

	public void Show(HardwareDesign d, SoftwareProduct sequelTo, SoftwareAddOn addon, Action<byte[]> onClose, byte[] previousDesign, IManufacturable man, GUIWindow parent, IList<FeatureBase> features)
	{
		_onClose = onClose;
		_manufacturing = man.GetManufacturing();
		if (previousDesign != null)
		{
			_instance = HardwareDesignInstance.Deserialize(previousDesign, 9);
			HardwareDesignRenderer.Instance.BeginRend(_instance);
			d = _instance.Design;
			_disallowed = _manufacturing.GetDisallowed(d.ID, features);
		}
		else if (sequelTo != null)
		{
			byte[] stream = HardwareDesignInstance.GenerateRandomDesign(man.GetManufacturing(), sequelTo, sequelTo.Sequel, addon, features, GameSettings.Instance.MyCompany);
			d = HardwareDesignInstance.GetHardwareDesign(stream);
			_instance = HardwareDesignInstance.Deserialize(stream, 9);
			_disallowed = _manufacturing.GetDisallowed(d.ID, features);
			HardwareDesignRenderer.Instance.BeginRend(_instance);
		}
		else
		{
			_disallowed = _manufacturing.GetDisallowed(d.ID, features);
			_instance = d.CreateRandomInstance(9, _disallowed);
			HardwareDesignRenderer.Instance.BeginRend(_instance);
		}
		InnerShow(d);
		List<HardwareDesign> list = man.GetManufacturing().GetValidDesigns(SDateTime.Now().Year).ToList();
		if (list.Count > 1)
		{
			_init = true;
			for (int i = 0; i < list.Count; i++)
			{
				HardwareDesign dd = list[i];
				Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
				toggle.group = TGroup;
				toggle.GetComponentInChildren<Text>().text = ("HARDWARE" + dd.ID).Loc();
				toggle.transform.SetParent(TogglePanel, false);
				toggle.onValueChanged.AddListener(delegate(bool x)
				{
					if (x && !_init)
					{
						_disallowed = _manufacturing.GetDisallowed(dd.ID, features);
						_instance = dd.CreateRandomInstance(9, _disallowed);
						UpdateActiveMesh(null);
						_active = null;
						RemoveObjectButton.gameObject.SetActive(false);
						_activeHandle = null;
						HardwareDesignRenderer.Instance.BeginRend(_instance);
						InitDesignParams(dd);
					}
				});
				_toggles.Add(toggle);
			}
			for (int num = 0; num < _toggles.Count; num++)
			{
				_toggles[num].isOn = d == list[num];
			}
			_init = false;
		}
		Window.SetParentWindow(parent);
		AchievementController.SetInteraction(AchievementController.Mechanics.HardwareDesigner);
	}

	public void Show(HardwareDesign d)
	{
		_disallowed.Clear();
		_manufacturing = null;
		_features = null;
		_instance = d.CreateRandomInstance(9, _disallowed);
		HardwareDesignRenderer.Instance.BeginRend(_instance);
		InnerShow(d);
	}

	private void InitDesignParams(HardwareDesign d)
	{
		Horz = d.RotOffsetX - 60f;
		Vert = d.RotOffset + 10f;
		UpdateRot();
		Spin = true;
		ColorButtons[0].SetActive(d.ColorPrimary);
		ColorButtons[1].SetActive(d.ColorSecondary);
		ColorButtons[2].SetActive(d.ColorTertiary);
		for (int i = 0; i < ColorAccents.Length; i++)
		{
			if (ColorButtons[i].activeSelf)
			{
				ColorAccents[i].color = _instance.Colors[i];
			}
		}
		RefreshHandles();
		RefreshBaseMesh(true);
		MainLabel.text = "DesignPostFix".Loc(("HARDWARE" + d.ID).Loc());
		UpdateAttachmentPanel();
		_enableCamChange = false;
		CamX.text = d.ThumbnailOffset.x.ToString();
		CamY.text = d.ThumbnailOffset.y.ToString();
		CamZ.text = d.ThumbnailOffset.z.ToString();
		CamZoom.text = d.ZoomOffset.ToString();
		WorldScale.text = d.WorldScale.ToString();
		RotX.text = d.RotOffsetX.ToString();
		RotY.text = d.RotOffset.ToString();
		_enableCamChange = true;
		_tempTextures.ForEach(UnityEngine.Object.Destroy);
		_tempTextures.Clear();
		int childCount = ThumbnailPanel.childCount;
		for (int j = 0; j < childCount; j++)
		{
			UnityEngine.Object.Destroy(ThumbnailPanel.GetChild(j).gameObject);
		}
		HardwareDesign.MeshObject[] objects = d.Objects;
		foreach (HardwareDesign.MeshObject o in objects)
		{
			if (o.ID != d.BaseMesh && !_disallowed.Contains(o.ID) && d.Attachments.Any((HardwareDesign.AttachmentPoint x) => (x.CanBeEmpty || x.CanRemove || x.Attachments.Count > 1) && x.Attachments.Any((HardwareDesign.Attachment z) => z.Object.Equals(o.ID))))
			{
				RenderTexture rt = new RenderTexture(64, 64, 0);
				HardwareDesignRenderer.Instance.RenderPart(d, o, rt);
				_tempTextures.Add(rt);
				GameObject obj = UnityEngine.Object.Instantiate(ObjectButtonPrefab);
				RawImage componentInChildren = obj.GetComponentInChildren<RawImage>();
				GUIToolTipper component = obj.GetComponent<GUIToolTipper>();
				obj.AddComponent<EventTrigger>().AddTrigger(EventTriggerType.PointerDown, delegate
				{
					BeginDragObject(rt, o);
				});
				component.ToolTipValue = ("HARDWARE" + o.Name).LocDef(o.Name);
				component.Localize = false;
				componentInChildren.texture = rt;
				obj.transform.SetParent(ThumbnailPanel, false);
			}
		}
	}

	public void BeginDragObject(RenderTexture img, HardwareDesign.MeshObject mo)
	{
		GameObject gameObject = new GameObject("DragItem");
		RawImage rawImage = gameObject.AddComponent<RawImage>();
		rawImage.texture = img;
		rawImage.raycastTarget = false;
		_objectDrag = gameObject.GetComponent<RectTransform>();
		_objectDrag.SetParent(WindowManager.Instance.Canvas.transform, false);
		_objectDrag.sizeDelta = new Vector2(64f, 64f);
		RectTransform objectDrag = _objectDrag;
		Vector2 anchorMax = (_objectDrag.anchorMin = new Vector2(0f, 1f));
		objectDrag.anchorMax = anchorMax;
		_moDrag = mo;
		Spin = false;
		_momentum = Vector2.zero;
		UpdateToolTip(null);
	}

	private void InnerShow(HardwareDesign d)
	{
		ResetToggles();
		_ignoreMorph.Clear();
		MainView.texture = HardwareDesignRenderer.Instance.MainTex;
		InitDesignParams(d);
		Window.Show();
		StartCoroutine(GreatJobUnity());
	}

	public void RemoveSelectedMeshObject()
	{
		_ignoreMorph.Remove(_active);
		_instance.ReplaceMesh(_active, null);
		_active = null;
		RemoveObjectButton.gameObject.SetActive(false);
		_activeSelect = null;
		UpdateActiveMesh(null);
		UpdateAttachmentPanel();
		UpdateActiveMesh(_active);
		RefreshHandles();
	}

	private IEnumerator GreatJobUnity()
	{
		yield return new WaitForEndOfFrame();
		LayoutRebuilder.MarkLayoutForRebuild(MainLabel.rectTransform);
	}

	private void UpdateRot()
	{
		_instance.transform.rotation = Quaternion.Euler(Vert, Horz, 0f);
	}

	private void UpdateActiveMesh(HardwareDesign.AttachmentPoint p)
	{
		if (_activeMesh != null && _destroyActiveMesh)
		{
			UnityEngine.Object.Destroy(_activeMesh);
		}
		if (p != null)
		{
			GetActiveMesh(p);
		}
		else
		{
			_activeMesh = null;
		}
	}

	private void GetActiveMesh(HardwareDesign.AttachmentPoint p)
	{
		Renderer orDefault = _instance.Objects.GetOrDefault(p);
		if (orDefault != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = orDefault as SkinnedMeshRenderer;
			if (skinnedMeshRenderer != null)
			{
				_activeMesh = new Mesh();
				skinnedMeshRenderer.BakeMesh(_activeMesh);
				_destroyActiveMesh = true;
			}
			else
			{
				_activeMesh = orDefault.GetComponent<MeshFilter>().sharedMesh;
				_destroyActiveMesh = false;
			}
		}
		else
		{
			_activeMesh = SphereMesh;
			_destroyActiveMesh = false;
		}
	}

	private void Update()
	{
		if (_objectDrag != null)
		{
			_objectDrag.anchoredPosition = new Vector2(Input.mousePosition.x, 0f - ((float)Screen.height - Input.mousePosition.y));
			Vector2 v;
			bool localMousePos = GetLocalMousePos(out v);
			if (Input.GetMouseButtonUp(0))
			{
				if (_lastClosest != -1)
				{
					_activeSelect = (_active = _instance.Design.Attachments[_lastClosest]);
					_ignoreMorph.Remove(_active);
					_activeHandle = null;
					RemoveObjectButton.gameObject.SetActive(_active.CanBeEmpty || _active.CanRemove);
					_instance.ReplaceMesh(_active, _moDrag);
					UpdateAttachmentPanel();
					UpdateActiveMesh(_active);
					RefreshHandles();
					UISoundFX.PlaySFX("ServerConnect");
				}
				UnityEngine.Object.Destroy(_objectDrag.gameObject);
				return;
			}
			Matrix4x4 localToWorldMatrix = _instance.transform.localToWorldMatrix;
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			int num = -1;
			float num2 = 32f;
			if (localMousePos)
			{
				Matrix4x4 localToWorldMatrix2 = _instance.transform.localToWorldMatrix;
				for (int i = 0; i < attachmentPoints.Count; i++)
				{
					HardwareDesign.AttachmentPoint attachmentPoint = _instance.Design.Attachments[i];
					if (attachmentPoint.Attachments.Any((HardwareDesign.Attachment x) => x.Object.Equals(_moDrag.ID)))
					{
						float magnitude = (GetHandleScreenPosition(GetPoint(attachmentPoint, localToWorldMatrix2)) - v).magnitude;
						if (magnitude < num2)
						{
							num2 = magnitude;
							num = i;
						}
					}
				}
			}
			for (int num3 = 0; num3 < attachmentPoints.Count; num3++)
			{
				if (_instance.Design.Attachments[num3].Attachments.Any((HardwareDesign.Attachment x) => x.Object.Equals(_moDrag.ID)))
				{
					materialPropertyBlock.SetColor("_OutlineColor", (num == num3) ? Color.green : Color.yellow);
					Graphics.DrawMesh(SphereMesh, Matrix4x4.TRS(localToWorldMatrix.MultiplyPoint(attachmentPoints[num3]), Quaternion.identity, Vector3.one * MorphHandleScale * 2f), Outline, 9, HardwareDesignRenderer.Instance.Cam, 0, materialPropertyBlock, ShadowCastingMode.Off, false);
				}
			}
			if (_lastClosest != num && num != -1)
			{
				UISoundFX.PlaySFX("Tick");
			}
			_lastClosest = num;
			return;
		}
		if (_active != null && RemoveObjectButton.gameObject.activeSelf)
		{
			Matrix4x4 localToWorldMatrix3 = _instance.transform.localToWorldMatrix;
			Vector2 handleScreenPosition = GetHandleScreenPosition(GetPoint(_active, localToWorldMatrix3));
			RemoveObjectButton.anchoredPosition = new Vector2(handleScreenPosition.x + 32f, 0f - handleScreenPosition.y - 32f);
		}
		if (HardwareDesignRenderer.Instance.IsActive())
		{
			_morphAlpha = 0f;
		}
		else if (!_showMorph)
		{
			if (_morphAlpha > 0f)
			{
				_morphAlpha -= Time.deltaTime * MorphFadeSpeed;
			}
		}
		else if (_morphAlpha < 1f)
		{
			_morphAlpha = Mathf.Min(1f, _morphAlpha + Time.deltaTime * MorphFadeSpeed);
		}
		if (_morphAlpha > 0f && (!_dragging || !_activeHandle.HasValue))
		{
			Transform activeTransform = GetActiveTransform();
			MaterialPropertyBlock materialPropertyBlock2 = new MaterialPropertyBlock();
			materialPropertyBlock2.SetColor("_Color", Color.cyan.Alpha(_morphAlpha));
			for (int num4 = 0; num4 < morphHandles.Count; num4++)
			{
				if (!_activeHandle.HasValue || _activeHandle != num4)
				{
					Graphics.DrawMesh(MorphHandleMesh, activeTransform.localToWorldMatrix * morphHandles[num4], MorphHandleMaterial, 9, HardwareDesignRenderer.Instance.Cam, 0, materialPropertyBlock2, ShadowCastingMode.Off, false);
				}
			}
			if (_activeHandle.HasValue)
			{
				materialPropertyBlock2 = new MaterialPropertyBlock();
				materialPropertyBlock2.SetColor("_Color", Color.yellow.Alpha(_morphAlpha));
				Graphics.DrawMesh(MorphHandleMesh, activeTransform.localToWorldMatrix * morphHandles[_activeHandle.Value], MorphHandleMaterial, 9, HardwareDesignRenderer.Instance.Cam, 0, materialPropertyBlock2, ShadowCastingMode.Off, false);
			}
			else if (_active == null && _activeSelect == null)
			{
				Matrix4x4 localToWorldMatrix4 = _instance.transform.localToWorldMatrix;
				for (int num5 = 0; num5 < attachmentPoints.Count; num5++)
				{
					if (_instance.MeshObjects.GetOrNull(_instance.Design.Attachments[num5]) != null)
					{
						materialPropertyBlock2 = new MaterialPropertyBlock();
						materialPropertyBlock2.SetColor("_Color", Color.yellow.Alpha(_morphAlpha));
						Graphics.DrawMesh(SphereMesh, Matrix4x4.TRS(localToWorldMatrix4.MultiplyPoint(attachmentPoints[num5]), Quaternion.identity, Vector3.one * MorphHandleScale), MorphHandleMaterial, 9, HardwareDesignRenderer.Instance.Cam, 0, materialPropertyBlock2, ShadowCastingMode.Off, false);
					}
				}
			}
		}
		if (_activeSelect != null || _active != null)
		{
			HardwareDesign.AttachmentPoint attachmentPoint2 = _activeSelect ?? _active;
			Renderer orDefault = _instance.Objects.GetOrDefault(attachmentPoint2);
			Mesh activeMesh = _activeMesh;
			Matrix4x4 matrix = ((!(orDefault != null)) ? Matrix4x4.TRS(GetPoint(attachmentPoint2, _instance.transform.localToWorldMatrix), Quaternion.identity, Vector3.one * MorphHandleScale * 2f) : orDefault.transform.localToWorldMatrix);
			Graphics.DrawMesh(activeMesh, matrix, Outline, 9, HardwareDesignRenderer.Instance.Cam, 0, null, ShadowCastingMode.Off, false);
		}
		if (!_dragging && !Spin)
		{
			if (_activeHandle.HasValue)
			{
				HardwareDesign.MeshObject activeObject = GetActiveObject();
				if (activeObject != null)
				{
					HardwareDesign.MorphInfo morphInfo = activeObject.MorphTargets[_activeHandle.Value];
					UpdateToolTip(("HARDWARE" + morphInfo.Label).LocDef(morphInfo.Label));
				}
				else
				{
					UpdateToolTip(null);
				}
			}
			else
			{
				UpdateToolTip(null);
			}
		}
		else
		{
			UpdateToolTip(null);
		}
		Vector2 v2;
		if (_dragging)
		{
			Spin = false;
			if (Input.GetMouseButtonUp(0))
			{
				_dragging = false;
				if (_activeHandle.HasValue)
				{
					RefreshHandles();
					if (_active == null)
					{
						RefreshBaseMesh(true);
					}
					else
					{
						UpdateActiveMesh(_active);
					}
				}
				else if (Time.realtimeSinceStartup - _clicked < 0.2f)
				{
					if (!_activeHandle.HasValue && _active != null)
					{
						_active = null;
						RemoveObjectButton.gameObject.SetActive(false);
						_activeSelect = null;
						UpdateActiveMesh(null);
						RefreshHandles();
						UpdateAttachmentPanel();
					}
					return;
				}
			}
			if (_activeHandle.HasValue)
			{
				HardwareDesign.MeshObject activeObject2 = GetActiveObject();
				SkinnedMeshRenderer activeSkin = GetActiveSkin();
				int actualMorphIndex = activeObject2.GetActualMorphIndex(_activeHandle.Value);
				Vector3 pos;
				if (activeObject2.MorphTargets[_activeHandle.Value].DoubleMorph)
				{
					float num6 = activeSkin.GetBlendShapeWeight(actualMorphIndex) / 100f;
					pos = Vector3.Lerp(t: (num6 != 0f) ? ((1f - num6) * 0.5f) : (0.5f + activeSkin.GetBlendShapeWeight(actualMorphIndex + 1) / 200f), a: _handleStart, b: _handleEnd);
				}
				else
				{
					float t = activeSkin.GetBlendShapeWeight(actualMorphIndex) / 100f;
					pos = Vector3.Lerp(_handleStart, _handleEnd, t);
				}
				MaterialPropertyBlock materialPropertyBlock3 = new MaterialPropertyBlock();
				materialPropertyBlock3.SetColor("_Color", Color.yellow.Alpha(_morphAlpha));
				Transform activeTransform2 = GetActiveTransform();
				Graphics.DrawMesh(MorphHandleMesh, activeTransform2.localToWorldMatrix * Matrix4x4.TRS(pos, Quaternion.LookRotation(_handleEnd - _handleStart), Vector3.one * MorphHandleScale), MorphHandleMaterial, 9, HardwareDesignRenderer.Instance.Cam, 0, materialPropertyBlock3, ShadowCastingMode.Off, false);
				if (!GetLocalMousePos(out v2))
				{
					return;
				}
				Vector2 handleScreenPosition2 = GetHandleScreenPosition(activeTransform2.localToWorldMatrix.MultiplyPoint(_handleStart));
				Vector2 handleScreenPosition3 = GetHandleScreenPosition(activeTransform2.localToWorldMatrix.MultiplyPoint(_handleEnd));
				float val = Mathf.Clamp01(Utilities.ProjectToLineEndlessMag(v2, handleScreenPosition2, handleScreenPosition3, false));
				bool flag = activeObject2.ID.Equals(_instance.Design.BaseMesh);
				if (!flag && _active != null && activeObject2.MorphTargets[_activeHandle.Value].GroupID > -1)
				{
					_ignoreMorph.Add(_active);
				}
				if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
				{
					if (_instance.UpdateBlend(val, activeObject2, activeSkin, actualMorphIndex, activeObject2.MorphTargets[_activeHandle.Value], true, new HashSet<HardwareDesign.AttachmentPoint>()))
					{
						_instance.UpdateSubPositions();
					}
				}
				else if (_instance.UpdateBlend(val, activeObject2, activeSkin, actualMorphIndex, activeObject2.MorphTargets[_activeHandle.Value], flag, _ignoreMorph))
				{
					_instance.UpdateSubPositions();
				}
			}
			else
			{
				Vector2 vector = Input.mousePosition;
				_momentum = _lastMouse - vector;
				Horz = (Horz + _momentum.x) % 360f;
				Vert = Mathf.Clamp(Vert - _momentum.y, -90f + _instance.Design.RotOffset, 90f + _instance.Design.RotOffset);
				UpdateRot();
				_lastMouse = vector;
				_showMorph = false;
			}
		}
		else if (Spin)
		{
			Horz = (Horz + Time.deltaTime * SpinSpeed) % 360f;
			UpdateRot();
			_showMorph = true;
		}
		else if (_momentum != Vector2.zero)
		{
			_momentum = Vector2.Lerp(_momentum, Vector2.zero, Time.deltaTime * Drag);
			Horz = (Horz + _momentum.x) % 360f;
			Vert = Mathf.Clamp(Vert - _momentum.y, -90f + _instance.Design.RotOffset, 90f + _instance.Design.RotOffset);
			UpdateRot();
			_showMorph = true;
		}
		else if (IsOnView() && GetLocalMousePos(out v2))
		{
			_activeHandle = null;
			HardwareDesign.AttachmentPoint activeSelect = _activeSelect;
			HardwareDesign.AttachmentPoint attachmentPoint3 = null;
			float num7 = 1024f;
			if (_active == null)
			{
				_activeSelect = null;
				Matrix4x4 localToWorldMatrix5 = _instance.transform.localToWorldMatrix;
				for (int num8 = 0; num8 < _instance.Design.Attachments.Count; num8++)
				{
					HardwareDesign.AttachmentPoint attachmentPoint4 = _instance.Design.Attachments[num8];
					if (_instance.MeshObjects.GetOrNull(attachmentPoint4) != null)
					{
						float sqrMagnitude = (GetHandleScreenPosition(GetPoint(attachmentPoint4, localToWorldMatrix5)) - v2).sqrMagnitude;
						if (sqrMagnitude < num7)
						{
							num7 = sqrMagnitude;
							attachmentPoint3 = attachmentPoint4;
						}
					}
				}
			}
			Transform activeTransform3 = GetActiveTransform();
			num7 = 256f;
			for (int num9 = 0; num9 < morphHandles.Count; num9++)
			{
				float sqrMagnitude2 = (GetHandleScreenPosition((activeTransform3.localToWorldMatrix * morphHandles[num9]).MultiplyPoint(Vector3.zero)) - v2).sqrMagnitude;
				if (sqrMagnitude2 < num7)
				{
					num7 = sqrMagnitude2;
					_activeHandle = num9;
					attachmentPoint3 = null;
				}
			}
			if (attachmentPoint3 != null)
			{
				_activeSelect = attachmentPoint3;
				if (attachmentPoint3 != activeSelect)
				{
					UpdateActiveMesh(_activeSelect);
				}
			}
			else if (activeSelect != null && _active == null)
			{
				UpdateActiveMesh(null);
			}
			_showMorph = _activeSelect == null || _active != null;
		}
		else
		{
			_showMorph = false;
		}
	}

	private bool IsOnView()
	{
		_raycastCache.Clear();
		EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		}, _raycastCache);
		if (_raycastCache.Count > 0)
		{
			return _raycastCache[0].gameObject == MainView.gameObject;
		}
		return false;
	}

	private Vector3 GetPoint(HardwareDesign.AttachmentPoint att, Matrix4x4 mat)
	{
		Vector3 p;
		Vector3 n;
		Vector3 u;
		HardwareDesign.GetPoint(att.Index, att.Type, _vertices, _normals, _tris, mat, false, out p, out n, out u);
		return Matrix4x4.TRS(p, Quaternion.LookRotation(n, u), Vector3.one).MultiplyPoint(att.AreaOffset);
	}

	private Vector2 GetHandleScreenPosition(Vector3 p)
	{
		Vector2 vector = HardwareDesignRenderer.Instance.Cam.WorldToViewportPoint(p);
		return new Vector2(vector.x * MainView.rectTransform.rect.width, (1f - vector.y) * MainView.rectTransform.rect.height);
	}

	private bool GetLocalMousePos(out Vector2 v)
	{
		RectTransform rectTransform = MainView.rectTransform;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, UICamSize.GetUICam(), out v))
		{
			v = new Vector2(v.x, 0f - v.y);
			if (v.x >= 0f && v.y >= 0f && v.x <= rectTransform.rect.width && v.y <= rectTransform.rect.height)
			{
				return true;
			}
		}
		return false;
	}

	public void StartDrag()
	{
		_clicked = Time.realtimeSinceStartup;
		if (_active == null && _activeSelect != null)
		{
			_active = _activeSelect;
			RemoveObjectButton.gameObject.SetActive(_active.CanBeEmpty || _active.CanRemove);
			UpdateAttachmentPanel();
			RefreshHandles();
			return;
		}
		_dragging = true;
		_lastMouse = Input.mousePosition;
		if (_activeHandle.HasValue)
		{
			SetHandlePos(_activeHandle.Value);
		}
	}

	private void UpdateToolTip(string val)
	{
		if (_tooltip)
		{
			if (Tooltip.CurrentRect != MainView.rectTransform)
			{
				_tooltip = false;
			}
			else if (val != null)
			{
				Tooltip.SetToolTip(val, null, MainView.rectTransform);
			}
			else
			{
				Tooltip.Hide();
			}
		}
	}

	public void PointerEnter()
	{
		if (_objectDrag == null)
		{
			Tooltip.SetToolTip(" ", null, MainView.rectTransform);
			_tooltip = true;
		}
	}
}
