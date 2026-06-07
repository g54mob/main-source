using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV.UIFramework;
using DV.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.ItemIconRendering
{
	public class ItemIconRenderer : MonoBehaviour, IRenderJob
	{
		private class IconRenderData
		{
			public Vector3 positionOffset;

			public Vector3 rotationOffset;

			public Texture standardTexture;

			public Texture droppedTexture;

			public IconRenderData(Vector3 positionOffset, Vector3 rotationOffset, Texture standardTexture, Texture droppedTexture)
			{
				this.positionOffset = positionOffset;
				this.rotationOffset = rotationOffset;
				this.standardTexture = standardTexture;
				this.droppedTexture = droppedTexture;
			}

			public void UpdatePositionOffset(Vector3 offset)
			{
				positionOffset = offset;
			}

			public void UpdateRotationOffset(Vector3 offset)
			{
				rotationOffset = offset;
			}

			public void UpdateStandardTexture(Texture standardTexture)
			{
				this.standardTexture = standardTexture;
			}

			public void UpdateDroppedTexture(Texture droppedTexture)
			{
				this.droppedTexture = droppedTexture;
			}
		}

		private const string ICON_SAVE_PATH = "Assets/DV/Items/ItemIcons";

		private const string ICON_NAME_STANDARD_SUFFIX = "_Icon";

		private const string ICON_NAME_DROPPED_SUFFIX = "_Icon_Dropped";

		[Header("Render Settings and References")]
		[SerializeField]
		private ItemsConfig itemConfig;

		[SerializeField]
		private Transform previewPivot;

		[SerializeField]
		private float mipMapBias;

		[SerializeField]
		private Vector2Int iconSize = new Vector2Int(128, 128);

		[SerializeField]
		private int downSampleFactor = 8;

		[SerializeField]
		private Material droppedItemMaterial;

		[SerializeField]
		private Material opaqueMaterial;

		[SerializeField]
		[Header("UI References")]
		private RectTransform rectTransform;

		[SerializeField]
		private TextMeshProUGUI itemLabel;

		[SerializeField]
		private TextMeshProUGUI prefabLabel;

		[SerializeField]
		private TextMeshProUGUI countLabel;

		[SerializeField]
		private SliderDV slider;

		[Header("Preview Manipulation")]
		[SerializeField]
		[Range(-180f, 180f)]
		private float rotationX;

		[SerializeField]
		[Range(-180f, 180f)]
		private float rotationY;

		[SerializeField]
		[Range(-180f, 180f)]
		private float rotationZ;

		[SerializeField]
		[Range(-3f, 3f)]
		private float offsetX;

		[SerializeField]
		[Range(-3f, 3f)]
		private float offsetY;

		[Range(-3f, 3f)]
		[SerializeField]
		private float offsetZ;

		private GameObject itemPrefabToRender;

		private Transform previewTransform;

		private RawImage rawImage;

		[SerializeField]
		private RawImage debugStandardImage;

		[SerializeField]
		private RawImage debugDroppedImage;

		private Bounds frameBounds;

		private Vector3 framePlaneCenter;

		private Vector3 framePlaneEdge;

		private InventoryItemSpec currentSpec;

		private List<InventoryItemSpec> allSpecs = new List<InventoryItemSpec>();

		private Vector3[] cameraFrameVertices = new Vector3[8];

		private float cameraFov;

		private Vector3 pivotInitialPosition;

		private Quaternion pivotInitialRotation;

		private int currentItemIndex;

		[SerializeField]
		private bool renderDroppedOnItemChange = true;

		[SerializeField]
		private bool renderEverything;

		private Texture standardTexture;

		private Texture droppedTexture;

		private Dictionary<InventoryItemSpec, IconRenderData> renderData = new Dictionary<InventoryItemSpec, IconRenderData>();

		private HashSet<Texture> texturesToKeep = new HashSet<Texture>();

		private int frameWait;

		[InspectorButton("NextItem", false, true)]
		[SerializeField]
		private bool nextItem;

		[InspectorButton("PreviousItem", false, true)]
		[SerializeField]
		private bool previousItem;

		[InspectorButton("ResetOffsets", false, true)]
		[SerializeField]
		private bool resetOffsets;

		private int renderCount;

		[InspectorButton("RenderDropped", false, true)]
		public bool renderDropped;

		[InspectorButton("SaveAllIconsDebug", false, true)]
		[Header("SAVE ALL! TAKES TIME")]
		public bool saveAllIconsDebug;

		public bool NeedsAlpha => true;

		private void Awake()
		{
			rawImage = rectTransform.GetComponent<RawImage>();
			pivotInitialPosition = previewPivot.position;
			pivotInitialRotation = previewPivot.rotation;
			offsetX = (offsetY = (offsetZ = 0f));
			Vector3 clampedEulerAngles = GetClampedEulerAngles(previewPivot.eulerAngles);
			rotationX = clampedEulerAngles.x;
			rotationY = clampedEulerAngles.y;
			rotationZ = clampedEulerAngles.z;
		}

		private void Start()
		{
			List<InventoryItemSpec> list = ((itemConfig != null) ? itemConfig.items : null);
			if (list != null && list.Count > 0)
			{
				allSpecs = (from t in list
					where t != null
					where !string.IsNullOrWhiteSpace(t.ItemPrefabName)
					select t).ToList();
			}
			if (allSpecs != null && allSpecs.Count > 0)
			{
				SingletonBehaviour<RenderTextureSystem>.Instance.SetAspectRatio((float)iconSize.x / (float)iconSize.y);
				SingletonBehaviour<RenderTextureSystem>.Instance.SetClippingPlanes(0.001f, 100f);
				SingletonBehaviour<RenderTextureSystem>.Instance.SetOrthographic(orthographic: false);
				SingletonBehaviour<RenderTextureSystem>.Instance.SetRenderPath(RenderingPath.Forward);
				currentItemIndex = 0;
				slider.wholeNumbers = true;
				slider.minValue = 0f;
				slider.maxValue = allSpecs.Count - 1;
				slider.value = currentItemIndex;
				slider.onValueChanged.AddListener(OnSliderValueChanged);
				ChangePrefabToRender();
			}
			else
			{
				Debug.LogError("Could not find any items in itemConfig. Icon rendering process aborted.", this);
			}
		}

		private void OnDestroy()
		{
			if (slider != null)
			{
				slider.onValueChanged.RemoveListener(OnSliderValueChanged);
			}
		}

		private void OnSliderValueChanged(float sliderValue)
		{
			UpdateSpecRenderingOffsets(currentSpec);
			UpdateSpecTextureReferences(currentSpec);
			if (!renderDroppedOnItemChange || renderDropped)
			{
				currentItemIndex = (int)sliderValue;
				ChangePrefabToRender();
			}
			else
			{
				frameWait = 0;
				RenderDropped();
			}
		}

		private void UpdateSpecTextureReferences(InventoryItemSpec spec)
		{
			if (renderData.TryGetValue(spec, out var value))
			{
				if (standardTexture != null)
				{
					value.UpdateStandardTexture(standardTexture);
					texturesToKeep.Add(standardTexture);
				}
				if (droppedTexture != null)
				{
					value.UpdateDroppedTexture(droppedTexture);
					texturesToKeep.Add(droppedTexture);
				}
			}
			else
			{
				Debug.LogError("Could not find IconRenderData for " + currentSpec.ItemPrefabName + ".", this);
			}
		}

		private void NextItem()
		{
			if (Application.isPlaying)
			{
				currentItemIndex++;
				if (currentItemIndex >= allSpecs.Count)
				{
					currentItemIndex = 0;
				}
				if (slider != null)
				{
					slider.value = currentItemIndex;
				}
			}
		}

		private void PreviousItem()
		{
			if (Application.isPlaying)
			{
				currentItemIndex--;
				if (currentItemIndex < 0)
				{
					currentItemIndex = allSpecs.Count - 1;
				}
				if (slider != null)
				{
					slider.value = currentItemIndex;
				}
			}
		}

		private void ResetOffsets()
		{
			previewPivot.position = pivotInitialPosition;
			previewPivot.rotation = pivotInitialRotation;
			offsetX = (offsetY = (offsetZ = 0f));
			Vector3 clampedEulerAngles = GetClampedEulerAngles(previewPivot.eulerAngles);
			rotationX = clampedEulerAngles.x;
			rotationY = clampedEulerAngles.y;
			rotationZ = clampedEulerAngles.z;
		}

		private void ChangePrefabToRender()
		{
			if (currentSpec != null && renderData.TryGetValue(currentSpec, out var value))
			{
				debugDroppedImage.texture = value.droppedTexture;
				debugStandardImage.texture = value.standardTexture;
			}
			SingletonBehaviour<RenderTextureSystem>.Instance.AbortRendering();
			if (previewTransform != null)
			{
				UnityEngine.Object.Destroy(previewTransform.gameObject);
			}
			itemPrefabToRender = Resources.Load(allSpecs[currentItemIndex].ItemPrefabName) as GameObject;
		}

		private void OnDrawGizmos()
		{
			if (Application.isPlaying && !(previewTransform == null))
			{
				Vector3 position = previewTransform.position;
				Gizmos.color = Color.cyan;
				Gizmos.DrawWireCube(position + frameBounds.center, frameBounds.size);
				float radius = 0.01f;
				Gizmos.color = Color.green;
				Vector3[] array = cameraFrameVertices;
				for (int i = 0; i < array.Length; i++)
				{
					Gizmos.DrawWireSphere(array[i] + position, radius);
				}
				Vector3 position2 = SingletonBehaviour<RenderTextureSystem>.Instance.GetCamera().transform.position;
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(position2, framePlaneCenter);
				Gizmos.color = Color.magenta;
				Gizmos.DrawLine(position2, framePlaneEdge);
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(framePlaneCenter, framePlaneEdge);
			}
		}

		private Vector3 GetClampedEulerAngles(Vector3 eulerAngles)
		{
			for (int i = 0; i < 3; i++)
			{
				eulerAngles[i] = Mathf.Repeat(eulerAngles[i] + 180f, 360f) - 180f;
			}
			return eulerAngles;
		}

		private void UpdatePivot()
		{
			Vector3 vector = new Vector3(offsetX, offsetY, offsetZ);
			previewPivot.position = pivotInitialPosition + vector;
			previewPivot.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
		}

		private void Update()
		{
			UpdatePivot();
			previewTransform = PrepareItemPreview(itemPrefabToRender)?.transform;
			if (!(previewTransform == null))
			{
				ScheduleJob();
			}
		}

		private GameObject PrepareItemPreview(GameObject renderTargetGameObject)
		{
			if (renderTargetGameObject == null)
			{
				Debug.LogError("Missing transform to render. ItemIconRenderer will not render.", this);
				return null;
			}
			InventoryItemSpec component = renderTargetGameObject.GetComponent<InventoryItemSpec>();
			if (component == null)
			{
				Debug.LogError("Given transform does not have an InventoryItemSpec component. ItemIconRenderer will not render.", this);
				return null;
			}
			if (component.PreviewPrefab == null)
			{
				Debug.LogError("Given InventoryItemSpec does not have a preview prefab. ItemIconRenderer will not render.", this);
				return null;
			}
			GameObject gameObject = ((previewTransform != null) ? previewTransform.gameObject : null);
			if (gameObject != null && !gameObject.name.StartsWith(component.PreviewPrefab.name))
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			if (gameObject != null)
			{
				return gameObject;
			}
			RemoveRenderedTexturesFromMemory();
			ResetPivot();
			renderDropped = false;
			gameObject = UnityEngine.Object.Instantiate(component.PreviewPrefab, previewPivot);
			previewTransform = gameObject.transform;
			currentSpec = component;
			GenerateFrameDataForItem();
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.Euler(component.PreviewRotation);
			gameObject.SetLayersRecursive("Render_Elements");
			SetupCamera();
			LoadPivotOffsets();
			itemLabel.text = component.LocalizedName;
			prefabLabel.text = component.ItemPrefabName;
			countLabel.text = $"{currentItemIndex + 1}/{allSpecs.Count}";
			return gameObject;
		}

		private void ResetPivot()
		{
			previewPivot.position = pivotInitialPosition;
			previewPivot.rotation = pivotInitialRotation;
			offsetX = (offsetY = (offsetZ = 0f));
			Vector3 clampedEulerAngles = GetClampedEulerAngles(previewPivot.rotation.eulerAngles);
			rotationX = clampedEulerAngles.x;
			rotationY = clampedEulerAngles.y;
			rotationZ = clampedEulerAngles.z;
		}

		private void LoadPivotOffsets()
		{
			Vector3 vector;
			Vector3 euler;
			if (renderData.TryGetValue(currentSpec, out var value))
			{
				vector = value.positionOffset;
				euler = value.rotationOffset;
			}
			else
			{
				vector = currentSpec.iconRenderPositionOffset;
				euler = currentSpec.iconRenderAngleOffset;
			}
			offsetX = vector.x;
			offsetY = vector.y;
			offsetZ = vector.z;
			previewPivot.position += pivotInitialPosition + vector;
			previewPivot.rotation = Quaternion.Euler(euler) * pivotInitialRotation;
			Vector3 clampedEulerAngles = GetClampedEulerAngles(previewPivot.rotation.eulerAngles);
			rotationX = clampedEulerAngles.x;
			rotationY = clampedEulerAngles.y;
			rotationZ = clampedEulerAngles.z;
		}

		private void SetupCamera()
		{
			Camera camera = SingletonBehaviour<RenderTextureSystem>.Instance.GetCamera();
			SingletonBehaviour<RenderTextureSystem>.Instance.SetAspectRatio((float)iconSize.x / (float)iconSize.y);
			SingletonBehaviour<RenderTextureSystem>.Instance.SetClippingPlanes(0.001f, 150f);
			SingletonBehaviour<RenderTextureSystem>.Instance.ResetFov();
			Transform obj = camera.transform;
			Vector3 position = obj.position;
			Vector3 position2 = previewPivot.position;
			position.x = position2.x;
			position.y = position2.y;
			position.z = 0f;
			framePlaneCenter = position2 + frameBounds.center;
			framePlaneCenter.z -= frameBounds.extents.z - offsetZ;
			framePlaneEdge = framePlaneCenter;
			framePlaneEdge.y += frameBounds.extents.y;
			float y = Mathf.Abs(framePlaneEdge.y - framePlaneCenter.y);
			float x = Mathf.Abs(framePlaneCenter.z);
			float num = 2f * Mathf.Atan2(y, x) * 57.29578f;
			obj.position = new Vector3(position.x, position.y + frameBounds.center.y, position.z);
			cameraFov = num;
		}

		private void GenerateFrameDataForItem()
		{
			Quaternion rotation = previewPivot.rotation * Quaternion.Euler(currentSpec.PreviewRotation);
			Bounds rotatedBounds = GetRotatedBounds(currentSpec.PreviewBounds, rotation);
			frameBounds = SquareBounds(rotatedBounds);
		}

		private Bounds GetRotatedBounds(Bounds bounds, Quaternion rotation)
		{
			RotateBoundsVertices(bounds, rotation, ref cameraFrameVertices);
			Vector3 vector = Vector3.negativeInfinity;
			Vector3 vector2 = Vector3.positiveInfinity;
			Vector3[] array = cameraFrameVertices;
			foreach (Vector3 rhs in array)
			{
				vector = Vector3.Max(vector, rhs);
				vector2 = Vector3.Min(vector2, rhs);
			}
			float x = Mathf.Abs(vector.x - vector2.x);
			float y = Mathf.Abs(vector.y - vector2.y);
			float z = Mathf.Abs(vector.z - vector2.z);
			Vector3 center = (vector2 + vector) / 2f;
			Vector3 size = new Vector3(x, y, z);
			return new Bounds(center, size);
		}

		private Bounds SquareBounds(Bounds bounds)
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			float num = Mathf.Abs(max.x - min.x);
			float num2 = Mathf.Abs(max.y - min.y);
			if (num - num2 > 0f)
			{
				float num3 = 0.5f * num / num2;
				min.y = Mathf.Sign(min.y) * num2 * num3;
				max.y = Mathf.Sign(max.y) * num2 * num3;
			}
			else
			{
				float num4 = 0.5f * num2 / num;
				min.x = Mathf.Sign(min.x) * num * num4;
				max.x = Mathf.Sign(max.x) * num * num4;
			}
			Vector3 center = (min + max) / 2f;
			Vector3 size = new Vector3(Mathf.Abs(max.x - min.x), Mathf.Abs(max.y - min.y), Mathf.Abs(max.z - min.z));
			return new Bounds(center, size);
		}

		private void RotateBoundsVertices(Bounds bounds, Quaternion rotation, ref Vector3[] vertices)
		{
			float x = bounds.min.x;
			float y = bounds.min.y;
			float z = bounds.min.z;
			float x2 = bounds.max.x;
			float y2 = bounds.max.y;
			float z2 = bounds.max.z;
			vertices[0] = rotation * new Vector3(x, y, z);
			vertices[1] = rotation * new Vector3(x, y, z2);
			vertices[2] = rotation * new Vector3(x, y2, z);
			vertices[3] = rotation * new Vector3(x, y2, z2);
			vertices[4] = rotation * new Vector3(x2, y, z);
			vertices[5] = rotation * new Vector3(x2, y, z2);
			vertices[6] = rotation * new Vector3(x2, y2, z);
			vertices[7] = rotation * new Vector3(x2, y2, z2);
		}

		private void ScheduleJob()
		{
			SingletonBehaviour<RenderTextureSystem>.Instance.AddRenderJob(this);
		}

		public Vector2Int GetTargetTextureSize()
		{
			return iconSize * downSampleFactor;
		}

		public float GetMipMapBias()
		{
			return mipMapBias;
		}

		public float Prepare(Vector3 suggestedPosition, Quaternion suggestedRotation)
		{
			return cameraFov;
		}

		public static void Resize(ref Texture source, int newWidth, int newHeight)
		{
			source.filterMode = FilterMode.Point;
			RenderTexture renderTexture = new RenderTexture(newWidth, newHeight, 0, RenderTextureFormat.ARGB32);
			renderTexture.filterMode = FilterMode.Point;
			Graphics.Blit(source, renderTexture);
			UnityEngine.Object.Destroy(source);
			source = renderTexture;
		}

		public void OnRenderCompleted(Texture result)
		{
			Resize(ref result, result.width / downSampleFactor, result.height / downSampleFactor);
			if (((itemPrefabToRender != null) ? itemPrefabToRender.GetComponent<InventoryItemSpec>() : null) == null)
			{
				Debug.LogError("ItemIconRenderer): No InventoryItemSpec found on transformToRender. Icon generation failed.");
				return;
			}
			if (renderDropped)
			{
				if (droppedTexture != null && !texturesToKeep.Contains(droppedTexture))
				{
					UnityEngine.Object.Destroy(droppedTexture);
				}
				droppedTexture = result;
			}
			else
			{
				if (standardTexture != null && !texturesToKeep.Contains(standardTexture))
				{
					UnityEngine.Object.Destroy(standardTexture);
				}
				standardTexture = result;
			}
			Texture texture = rawImage.texture;
			if (texture != null && !texturesToKeep.Contains(texture))
			{
				UnityEngine.Object.Destroy(texture);
			}
			rawImage.texture = result;
			if (renderDropped)
			{
				if (renderDroppedOnItemChange && frameWait < 1)
				{
					frameWait++;
					return;
				}
				UpdateSpecTextureReferences(currentSpec);
				currentItemIndex = (int)slider.value;
				if (renderEverything)
				{
					renderCount++;
					if (renderCount >= allSpecs.Count)
					{
						renderEverything = false;
						Debug.LogError("Everything rendered. Click save all.");
					}
					ChangePrefabToRender();
				}
				else if (renderDroppedOnItemChange)
				{
					ChangePrefabToRender();
				}
				frameWait = 0;
			}
			else
			{
				if (renderDropped)
				{
					return;
				}
				if (renderEverything && frameWait < 1)
				{
					frameWait++;
					return;
				}
				UpdateSpecRenderingOffsets(currentSpec);
				UpdateSpecTextureReferences(currentSpec);
				frameWait = 0;
				if (renderEverything)
				{
					NextItem();
				}
			}
		}

		private void SaveAllIconsDebug()
		{
			if (Application.isPlaying)
			{
				SaveIcons();
			}
		}

		private void SaveIcons()
		{
		}

		private void RemoveRenderedTexturesFromMemory()
		{
			if (standardTexture != null && !texturesToKeep.Contains(standardTexture))
			{
				UnityEngine.Object.Destroy(standardTexture);
			}
			if (droppedTexture != null && !texturesToKeep.Contains(droppedTexture))
			{
				UnityEngine.Object.Destroy(droppedTexture);
			}
			if (rawImage.texture != null && !texturesToKeep.Contains(rawImage.texture))
			{
				UnityEngine.Object.Destroy(rawImage.texture);
			}
			rawImage.texture = null;
			standardTexture = null;
			droppedTexture = null;
		}

		private Sprite ReimportIconAsSprite(string path)
		{
			Debug.LogError("This should never be called outside of editor.", this);
			return null;
		}

		private string WriteIconToFile(InventoryItemSpec spec, byte[] textureToWrite, bool standard)
		{
			string text = (standard ? "_Icon" : "_Icon_Dropped");
			string text2 = Path.Combine("Assets/DV/Items/ItemIcons", spec.ItemPrefabName + text + ".png");
			if (File.Exists(text2))
			{
				FileAttributes attributes = File.GetAttributes(text2);
				if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					try
					{
						Debug.LogWarning("Found read-only file at " + text2 + ". Removing read-only attribute.");
						File.SetAttributes(text2, attributes ^ FileAttributes.ReadOnly);
					}
					catch (Exception arg)
					{
						Debug.LogError(string.Format("{0}): Failed to remove read-only attribute from {1}. Icon generation failed. Exception: {2}", "ItemIconRenderer", text2, arg));
						return text2;
					}
				}
			}
			try
			{
				File.WriteAllBytes(text2, textureToWrite);
				return text2;
			}
			catch (Exception arg2)
			{
				Debug.LogError(string.Format("{0}): Failed to write {1}. Icon generation failed. Exception: {2}", "ItemIconRenderer", text2, arg2));
				return text2;
			}
		}

		private void UpdateSpecRenderingOffsets(InventoryItemSpec spec)
		{
			Vector3 vector = new Vector3(offsetX, offsetY, offsetZ);
			Quaternion quaternion = Quaternion.Euler(rotationX, rotationY, rotationZ);
			Vector3 clampedEulerAngles = GetClampedEulerAngles((quaternion * Quaternion.Inverse(pivotInitialRotation)).eulerAngles);
			if (renderData.TryGetValue(spec, out var value))
			{
				value.UpdatePositionOffset(vector);
				value.UpdateRotationOffset(clampedEulerAngles);
			}
			else
			{
				renderData[spec] = new IconRenderData(vector, clampedEulerAngles, null, null);
			}
		}

		private void UpdatePrefabOffsets(InventoryItemSpec spec, IconRenderData data)
		{
			if (spec == null)
			{
				Debug.LogError("Missing spec, can't update offsets.", this);
				return;
			}
			spec.iconRenderPositionOffset = data.positionOffset;
			spec.iconRenderAngleOffset = data.rotationOffset;
		}

		private void UpdatePrefabSprites(InventoryItemSpec spec, Sprite standard, Sprite dropped)
		{
			if (standard == null)
			{
				_ = dropped == null;
			}
		}

		private void SavePrefab(GameObject prefab)
		{
		}

		private void RenderDropped()
		{
			if (!Application.isPlaying || renderDropped || previewTransform == null)
			{
				return;
			}
			if (!renderDropped)
			{
				Renderer[] componentsInChildren = previewTransform.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].material = opaqueMaterial;
				}
			}
			if (currentSpec != null)
			{
				if (renderData.TryGetValue(currentSpec, out var value))
				{
					if (renderDropped)
					{
						value.UpdateDroppedTexture(droppedTexture);
						texturesToKeep.Add(droppedTexture);
					}
					else
					{
						value.UpdateStandardTexture(standardTexture);
						texturesToKeep.Add(standardTexture);
					}
				}
				else
				{
					Vector3 positionOffset = new Vector3(offsetX, offsetY, offsetZ);
					Vector3 clampedEulerAngles = GetClampedEulerAngles((Quaternion.Euler(rotationX, rotationY, rotationZ) * Quaternion.Inverse(pivotInitialRotation)).eulerAngles);
					if (renderDropped)
					{
						texturesToKeep.Add(droppedTexture);
						value = new IconRenderData(positionOffset, clampedEulerAngles, null, droppedTexture);
					}
					else
					{
						texturesToKeep.Add(standardTexture);
						value = new IconRenderData(positionOffset, clampedEulerAngles, standardTexture, null);
					}
					renderData[currentSpec] = value;
				}
			}
			renderDropped = !renderDropped;
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			if (renderDropped)
			{
				Graphics.Blit(src, dest, droppedItemMaterial);
			}
			else
			{
				Graphics.Blit(src, dest);
			}
		}
	}
}
