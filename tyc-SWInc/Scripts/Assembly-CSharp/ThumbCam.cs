using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThumbCam : MonoBehaviour
{
	public Camera ThumbnailCam;

	public Camera MainCam;

	public RenderTexture Target;

	public Material BlitMat;

	public Material ThumbGlass;

	public Vector3 lastMouse;

	public Transform PivotTransform;

	public Transform ThumbnailPivot;

	public Transform MainCamTransform;

	public float RotX;

	public float RotY;

	public GameObject GroundPlane;

	public GameObject ArrowPlane;

	public GameObject WallCube;

	public Slider AngleSlider;

	public Slider ScaleSlider;

	public Slider YSlider;

	public Slider XSlider;

	public Image CamBackColor;

	public Transform DirectLight;

	public GameObject SideWall1;

	public GameObject SideWall2;

	public GameObject UpperWall;

	private bool _isDragging;

	public void SetBackColor()
	{
		WindowManager.SpawnColorDialog(delegate(Color x)
		{
			ThumbnailCam.backgroundColor = x.Alpha(0f);
			CamBackColor.color = x.Alpha(1f);
			Preview();
		}, ThumbnailCam.backgroundColor);
	}

	public void SetPerspective()
	{
		MainCam.orthographic = false;
		PivotTransform.rotation = Quaternion.Euler(RotX, RotY, 0f);
		MainCamTransform.localPosition = new Vector3(0f, 0f, -10f);
	}

	public void SetOrthoFront(bool forward)
	{
		MainCam.orthographic = true;
		PivotTransform.rotation = Quaternion.Euler(0f, forward ? 180 : 0, 0f);
		MainCamTransform.localPosition = new Vector3(0f, 0f, -10f);
	}

	public void SetOrthoRight(bool forward)
	{
		MainCam.orthographic = true;
		PivotTransform.rotation = Quaternion.Euler(0f, forward ? 90 : (-90), 0f);
		MainCamTransform.localPosition = new Vector3(0f, 0f, -10f);
	}

	public void SetOrthoUp(bool forward)
	{
		MainCam.orthographic = true;
		PivotTransform.rotation = Quaternion.Euler(forward ? 90 : (-90), 180f, 0f);
		MainCamTransform.localPosition = new Vector3(0f, 0f, -10f);
	}

	private void Awake()
	{
		ThumbnailCam.targetTexture = Target;
	}

	private void Start()
	{
		RotX = PivotTransform.rotation.eulerAngles.x;
		RotY = PivotTransform.rotation.eulerAngles.y;
	}

	private void Update()
	{
		if (FurnitureModdingTool.Instance.BoundaryEditor.DoUpdate())
		{
			return;
		}
		if (!EventSystem.current.IsPointerOverGameObject() && (FurnitureModdingTool.Instance.CurrentGizmo == null || !FurnitureModdingTool.Instance.CurrentGizmo.IsDragging))
		{
			if (!MainCam.orthographic)
			{
				if (Input.GetMouseButtonDown(0))
				{
					lastMouse = Input.mousePosition;
					_isDragging = true;
				}
				MainCamTransform.localPosition = new Vector3(0f, 0f, Mathf.Clamp(MainCamTransform.localPosition.z + Input.mouseScrollDelta.y, -50f, -1f));
			}
			else
			{
				MainCam.orthographicSize = Mathf.Clamp(MainCam.orthographicSize - Input.mouseScrollDelta.y * 0.1f, 1f, 4f);
			}
		}
		if (_isDragging)
		{
			Vector3 vector = Input.mousePosition - lastMouse;
			RotX = Mathf.Clamp(RotX - vector.y, -85f, 85f);
			RotY += vector.x;
			PivotTransform.rotation = Quaternion.Euler(RotX, RotY, 0f);
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
			}
		}
		lastMouse = Input.mousePosition;
	}

	public void Preview()
	{
		ActivateSegmentWall(false);
		bool activeSelf = WallCube.activeSelf;
		bool activeSelf2 = UpperWall.activeSelf;
		SideWall1.SetActive(false);
		SideWall2.SetActive(false);
		UpperWall.SetActive(false);
		WallCube.SetActive(false);
		GroundPlane.SetActive(false);
		ArrowPlane.SetActive(false);
		FurnitureModdingTool.Instance.DisableCutouts();
		if (FurnitureModdingTool.Instance.SnapOnTemp != null)
		{
			FurnitureModdingTool.Instance.SnapOnTemp.gameObject.SetActive(false);
		}
		IEnumerable<Renderer> items = from x in FurnitureModdingTool.Instance.ActiveObject.GetComponentsInChildren<Renderer>(false)
			where x.tag.Equals("HidePlacement") || x.tag.Equals("IgnoreMesh")
			select x;
		items.ForEachEnum(delegate(Renderer x)
		{
			x.gameObject.SetActive(false);
		});
		List<Renderer> list = (from x in FurnitureModdingTool.Instance.ActiveObject.GetComponentsInChildren<Renderer>()
			where x.sharedMaterials.Contains(ObjectDatabase.Instance.GlassMaterial)
			select x).ToList();
		Renderer renderer = FurnitureModdingTool.Instance.ActiveObject.GetComponentsInChildren<Renderer>().FirstOrDefault((Renderer x) => x.sharedMaterials.Length > 1 && x.sharedMaterials[1] == FurnitureModdingTool.Instance.OutlineMat);
		if (renderer != null)
		{
			renderer.sharedMaterials = new Material[1] { renderer.sharedMaterials[0] };
		}
		for (int num = 0; num < list.Count; num++)
		{
			Renderer renderer2 = list[num];
			Material[] array = renderer2.sharedMaterials.ToArray();
			for (int num2 = 0; num2 < array.Length; num2++)
			{
				if (array[num2] == ObjectDatabase.Instance.GlassMaterial)
				{
					array[num2] = ThumbGlass;
				}
			}
			renderer2.sharedMaterials = array;
		}
		Vector3 eulerAngles = ThumbnailPivot.rotation.eulerAngles;
		DirectLight.rotation = Quaternion.Euler(54f, AngleSlider.value * 90f - 255f, 0f);
		ThumbnailPivot.rotation = Quaternion.Euler(eulerAngles.x, AngleSlider.value * 90f + 45f, eulerAngles.z);
		HashSet<MeshFilter> hashSet = new HashSet<MeshFilter>();
		RoomSegment component;
		if (FurnitureModdingTool.Instance.ActiveObject.transform.TryGetComponent<RoomSegment>(out component))
		{
			hashSet.AddRange(component.InsideWallMeshes);
			if (component.WallMask != null)
			{
				hashSet.Add(component.WallMask.GetComponent<MeshFilter>());
			}
		}
		FixPos(FurnitureModdingTool.Instance.ActiveObject, hashSet);
		ThumbnailCam.Render();
		GroundPlane.SetActive(true);
		ArrowPlane.SetActive(true);
		WallCube.SetActive(activeSelf);
		ActivateSegmentWall(true);
		SideWall1.SetActive(activeSelf2);
		SideWall2.SetActive(activeSelf2);
		UpperWall.SetActive(activeSelf2);
		FurnitureModdingTool.Instance.RefreshCutouts();
		if (renderer != null)
		{
			renderer.sharedMaterials = new Material[2]
			{
				renderer.sharedMaterials[0],
				FurnitureModdingTool.Instance.OutlineMat
			};
		}
		items.ForEachEnum(delegate(Renderer x)
		{
			x.gameObject.SetActive(true);
		});
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			Renderer renderer3 = list[num3];
			Material[] array2 = renderer3.sharedMaterials.ToArray();
			for (int num4 = 0; num4 < array2.Length; num4++)
			{
				if (array2[num4] == ThumbGlass)
				{
					array2[num4] = ObjectDatabase.Instance.GlassMaterial;
				}
			}
			renderer3.sharedMaterials = array2;
		}
		if (FurnitureModdingTool.Instance.SnapOnTemp != null)
		{
			FurnitureModdingTool.Instance.SnapOnTemp.gameObject.SetActive(FurnitureModdingTool.Instance.SnapFurnToggle.isOn);
		}
		DirectLight.rotation = Quaternion.Euler(54f, -165f, 0f);
	}

	private void ActivateSegmentWall(bool active)
	{
	}

	public void TakePicture()
	{
		Preview();
		RenderTexture renderTexture = new RenderTexture(Target.width / 2, Target.height / 2, 16, RenderTextureFormat.ARGB32)
		{
			antiAliasing = 1,
			autoGenerateMips = false,
			filterMode = FilterMode.Point
		};
		RenderTexture active = RenderTexture.active;
		BlitMat.SetFloat("_inputSize", 256f);
		Graphics.Blit(Target, renderTexture, BlitMat);
		RenderTexture.active = renderTexture;
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
		texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		Object.Destroy(renderTexture);
		if (FurnitureModdingTool.Instance.ActiveMod != null)
		{
			WallSnap activePrefab = FurnitureModdingTool.Instance.ActivePrefab;
			string text = ((activePrefab.Thumbnail != null) ? activePrefab.Thumbnail.name : null);
			string text2 = ((text != null) ? Path.Combine(FurnitureModdingTool.Instance.ActiveMod.Root, text) : null);
			if (text2 == null || !File.Exists(text2))
			{
				text = activePrefab.name + "Thumb.png";
				text2 = Path.Combine(FurnitureModdingTool.Instance.ActiveMod.Root, text);
			}
			File.WriteAllBytes(text2, texture2D.EncodeToPNG());
			if (activePrefab.Thumbnail != null)
			{
				FurnitureModdingTool.Instance.ActiveMod.Textures.Remove(activePrefab.Thumbnail.texture);
				Object.Destroy(activePrefab.Thumbnail.texture);
			}
			texture2D.Compress(true);
			FurnitureModdingTool.Instance.ActiveMod.Textures.Add(texture2D);
			Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, 128f, 128f), Vector2.zero);
			sprite.name = text;
			activePrefab.Thumbnail = sprite;
			GameObject orNull = FurnitureModdingTool.Instance.Buttons.GetOrNull(activePrefab);
			if (orNull != null)
			{
				orNull.GetComponentsInChildren<Image>()[1].sprite = sprite;
			}
			FurnitureModdingTool.Instance.Thumb.sprite = sprite;
			FurnCompMeta furnCompMeta = FurnitureModdingTool.Instance.CurrentMeta.FirstOrDefaultOf<FurnCompMeta>();
			if (furnCompMeta != null)
			{
				furnCompMeta.Thumbnail = text;
			}
			SegmentCompMeta segmentCompMeta = FurnitureModdingTool.Instance.CurrentMeta.FirstOrDefaultOf<SegmentCompMeta>();
			if (segmentCompMeta != null)
			{
				segmentCompMeta.Thumbnail = text;
			}
			activePrefab.Thumbnail = sprite;
		}
	}

	private void GetAllPoints(Mesh m, Matrix4x4 t, List<Vector3> l)
	{
		if (m != null)
		{
			Vector3[] vertices = m.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				l.Add(t.MultiplyPoint(vertices[i]));
			}
		}
	}

	public void ResetSliders()
	{
		ScaleSlider.value = 1f;
		AngleSlider.value = 1f;
		XSlider.value = 0f;
		YSlider.value = 0f;
	}

	public void FixPos(GameObject target, HashSet<MeshFilter> ignore)
	{
		List<Vector3> list = new List<Vector3>();
		MeshFilter[] componentsInChildren = target.GetComponentsInChildren<MeshFilter>();
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if (!ignore.Contains(meshFilter))
			{
				GetAllPoints(meshFilter.sharedMesh, meshFilter.transform.localToWorldMatrix, list);
			}
		}
		SkinnedMeshRenderer[] componentsInChildren2 = target.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			Mesh mesh = new Mesh();
			skinnedMeshRenderer.BakeMesh(mesh);
			GetAllPoints(mesh, Matrix4x4.TRS(skinnedMeshRenderer.transform.position, skinnedMeshRenderer.transform.rotation, Vector3.one), list);
			Object.DestroyImmediate(mesh);
		}
		Vector2 vector = new Vector2(99f, 99f);
		Vector2 vector2 = new Vector2(-99f, -99f);
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, ThumbnailCam.transform.rotation, Vector3.one);
		Matrix4x4 inverse = matrix4x.inverse;
		for (int j = 0; j < list.Count; j++)
		{
			Debug.DrawLine(list[j], ThumbnailCam.transform.position, Color.red, 5f);
			Vector3 vector3 = inverse.MultiplyPoint(list[j]);
			vector = Vector2.Min(vector, vector3);
			vector2 = Vector2.Max(vector2, vector3);
		}
		Vector3 vector4 = matrix4x.MultiplyPoint((vector + vector2) * 0.5f);
		ThumbnailCam.orthographicSize = Mathf.Max(vector2.x - vector.x, vector2.y - vector.y) * 0.51f * (2f - ScaleSlider.value);
		ThumbnailCam.transform.position = vector4 - 20f * ThumbnailCam.transform.forward + ThumbnailCam.transform.up * XSlider.value + ThumbnailCam.transform.right * YSlider.value;
	}
}
