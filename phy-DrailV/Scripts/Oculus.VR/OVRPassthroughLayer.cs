using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class OVRPassthroughLayer : MonoBehaviour
{
	public enum ProjectionSurfaceType
	{
		Reconstructed = 0,
		UserDefined = 1
	}

	public enum ColorMapEditorType
	{
		None = 0,
		Controls = 1,
		Custom = 2
	}

	private struct PassthroughMeshInstance
	{
		public ulong meshHandle;

		public ulong instanceHandle;

		public bool updateTransform;
	}

	private struct DeferredPassthroughMeshAddition
	{
		public GameObject gameObject;

		public bool updateTransform;
	}

	public ProjectionSurfaceType projectionSurfaceType;

	public OVROverlay.OverlayType overlayType = OVROverlay.OverlayType.Overlay;

	public int compositionDepth;

	public bool hidden;

	public bool overridePerLayerColorScaleAndOffset;

	public Vector4 colorScale = Vector4.one;

	public Vector4 colorOffset = Vector4.zero;

	[SerializeField]
	private ColorMapEditorType colorMapEditorType_;

	public Gradient colorMapEditorGradient = CreateNeutralColorMapGradient();

	private Gradient colorMapEditorGradientOld = new Gradient();

	public float colorMapEditorContrast;

	private float colorMapEditorContrast_;

	public float colorMapEditorBrightness;

	private float colorMapEditorBrightness_;

	public float colorMapEditorPosterize;

	private float colorMapEditorPosterize_;

	private OVRCameraRig cameraRig;

	private bool cameraRigInitialized;

	private GameObject auxGameObject;

	private OVROverlay passthroughOverlay;

	private Dictionary<GameObject, PassthroughMeshInstance> surfaceGameObjects = new Dictionary<GameObject, PassthroughMeshInstance>();

	private List<DeferredPassthroughMeshAddition> deferredSurfaceGameObjects = new List<DeferredPassthroughMeshAddition>();

	[SerializeField]
	private float textureOpacity_ = 1f;

	[SerializeField]
	private bool edgeRenderingEnabled_;

	[SerializeField]
	private Color edgeColor_ = new Color(1f, 1f, 1f, 1f);

	[SerializeField]
	private OVRPlugin.InsightPassthroughColorMapType colorMapType;

	private byte[] colorMapData;

	private GCHandle colorMapDataHandle;

	private bool styleDirty = true;

	private static readonly Gradient colorMapNeutralGradient = CreateNeutralColorMapGradient();

	public float textureOpacity
	{
		get
		{
			return textureOpacity_;
		}
		set
		{
			if (value != textureOpacity_)
			{
				textureOpacity_ = value;
				styleDirty = true;
			}
		}
	}

	public bool edgeRenderingEnabled
	{
		get
		{
			return edgeRenderingEnabled_;
		}
		set
		{
			if (value != edgeRenderingEnabled_)
			{
				edgeRenderingEnabled_ = value;
				styleDirty = true;
			}
		}
	}

	public Color edgeColor
	{
		get
		{
			return edgeColor_;
		}
		set
		{
			if (value != edgeColor_)
			{
				edgeColor_ = value;
				styleDirty = true;
			}
		}
	}

	public ColorMapEditorType colorMapEditorType
	{
		get
		{
			return colorMapEditorType_;
		}
		set
		{
			if (value != colorMapEditorType_)
			{
				colorMapEditorType_ = value;
				switch (value)
				{
				case ColorMapEditorType.None:
					colorMapType = OVRPlugin.InsightPassthroughColorMapType.None;
					DeallocateColorMapData();
					styleDirty = true;
					break;
				case ColorMapEditorType.Controls:
					colorMapType = OVRPlugin.InsightPassthroughColorMapType.MonoToRgba;
					UpdateColorMapFromControls(forceUpdate: true);
					break;
				case ColorMapEditorType.Custom:
					break;
				}
			}
		}
	}

	private OVROverlay.OverlayShape overlayShape
	{
		get
		{
			if (projectionSurfaceType != ProjectionSurfaceType.UserDefined)
			{
				return OVROverlay.OverlayShape.ReconstructionPassthrough;
			}
			return OVROverlay.OverlayShape.SurfaceProjectedPassthrough;
		}
	}

	public void AddSurfaceGeometry(GameObject obj, bool updateTransform = false)
	{
		if (projectionSurfaceType != ProjectionSurfaceType.UserDefined)
		{
			Debug.LogError("Passthrough layer is not configured for surface projected passthrough.");
			return;
		}
		if (surfaceGameObjects.ContainsKey(obj))
		{
			Debug.LogError("Specified GameObject has already been added as passthrough surface.");
			return;
		}
		if (obj.GetComponent<MeshFilter>() == null)
		{
			Debug.LogError("Specified GameObject does not have a mesh component.");
			return;
		}
		deferredSurfaceGameObjects.Add(new DeferredPassthroughMeshAddition
		{
			gameObject = obj,
			updateTransform = updateTransform
		});
	}

	public void RemoveSurfaceGeometry(GameObject obj)
	{
		if (surfaceGameObjects.TryGetValue(obj, out var value))
		{
			if (OVRPlugin.DestroyInsightPassthroughGeometryInstance(value.instanceHandle) && OVRPlugin.DestroyInsightTriangleMesh(value.meshHandle))
			{
				surfaceGameObjects.Remove(obj);
			}
			else
			{
				Debug.LogError("GameObject could not be removed from passthrough surface.");
			}
		}
		else if (deferredSurfaceGameObjects.RemoveAll((DeferredPassthroughMeshAddition x) => x.gameObject == obj) == 0)
		{
			Debug.LogError("Specified GameObject has not been added as passthrough surface.");
		}
	}

	public bool IsSurfaceGeometry(GameObject obj)
	{
		if (!surfaceGameObjects.ContainsKey(obj))
		{
			return deferredSurfaceGameObjects.Exists((DeferredPassthroughMeshAddition x) => x.gameObject == obj);
		}
		return true;
	}

	public void SetColorMap(Color[] values)
	{
		if (values.Length != 256)
		{
			throw new ArgumentException("Must provide exactly 256 colors");
		}
		colorMapType = OVRPlugin.InsightPassthroughColorMapType.MonoToRgba;
		colorMapEditorType = ColorMapEditorType.Custom;
		AllocateColorMapData();
		for (int i = 0; i < 256; i++)
		{
			WriteColorToColorMap(i, ref values[i]);
		}
		styleDirty = true;
	}

	public void SetColorMapControls(float contrast, float brightness = 0f, float posterize = 0f, Gradient gradient = null)
	{
		colorMapEditorType = ColorMapEditorType.Controls;
		colorMapEditorContrast = contrast;
		colorMapEditorBrightness = brightness;
		colorMapEditorPosterize = posterize;
		if (gradient != null)
		{
			colorMapEditorGradient = gradient;
		}
		else if (!colorMapEditorGradient.Equals(colorMapNeutralGradient))
		{
			colorMapEditorGradient = CreateNeutralColorMapGradient();
		}
	}

	public void SetColorMapMonochromatic(byte[] values)
	{
		if (values.Length != 256)
		{
			throw new ArgumentException("Must provide exactly 256 values");
		}
		colorMapType = OVRPlugin.InsightPassthroughColorMapType.MonoToMono;
		colorMapEditorType = ColorMapEditorType.Custom;
		AllocateColorMapData();
		Buffer.BlockCopy(values, 0, colorMapData, 0, 256);
		styleDirty = true;
	}

	public void DisableColorMap()
	{
		colorMapEditorType = ColorMapEditorType.None;
	}

	private void AddDeferredSurfaceGeometries()
	{
		for (int i = 0; i < deferredSurfaceGameObjects.Count; i++)
		{
			DeferredPassthroughMeshAddition deferredPassthroughMeshAddition = deferredSurfaceGameObjects[i];
			bool flag = false;
			ulong meshHandle;
			ulong instanceHandle;
			if (surfaceGameObjects.ContainsKey(deferredPassthroughMeshAddition.gameObject))
			{
				flag = true;
			}
			else if (CreateAndAddMesh(deferredPassthroughMeshAddition.gameObject, out meshHandle, out instanceHandle))
			{
				surfaceGameObjects.Add(deferredPassthroughMeshAddition.gameObject, new PassthroughMeshInstance
				{
					meshHandle = meshHandle,
					instanceHandle = instanceHandle,
					updateTransform = deferredPassthroughMeshAddition.updateTransform
				});
				flag = true;
			}
			else
			{
				Debug.LogWarning("Failed to create internal resources for GameObject added to passthrough surface.");
			}
			if (flag)
			{
				deferredSurfaceGameObjects.RemoveAt(i--);
			}
		}
	}

	private Matrix4x4 GetTransformMatrixForPassthroughSurfaceObject(GameObject obj)
	{
		Matrix4x4 localToWorldMatrix = obj.transform.localToWorldMatrix;
		if (!cameraRigInitialized)
		{
			cameraRig = OVRManager.instance.GetComponentInParent<OVRCameraRig>();
			cameraRigInitialized = true;
		}
		Matrix4x4 matrix4x = ((cameraRig != null) ? cameraRig.trackingSpace.worldToLocalMatrix : Matrix4x4.identity);
		return Matrix4x4.Scale(new Vector3(1f, 1f, -1f)) * matrix4x * localToWorldMatrix;
	}

	private bool CreateAndAddMesh(GameObject obj, out ulong meshHandle, out ulong instanceHandle)
	{
		meshHandle = 0uL;
		instanceHandle = 0uL;
		MeshFilter component = obj.GetComponent<MeshFilter>();
		if (component == null)
		{
			Debug.LogError("Passthrough surface GameObject does not have a mesh component.");
			return false;
		}
		Mesh sharedMesh = component.sharedMesh;
		Vector3[] vertices = sharedMesh.vertices;
		int[] triangles = sharedMesh.triangles;
		Matrix4x4 transformMatrixForPassthroughSurfaceObject = GetTransformMatrixForPassthroughSurfaceObject(obj);
		if (!OVRPlugin.CreateInsightTriangleMesh(passthroughOverlay.layerId, vertices, triangles, out meshHandle))
		{
			Debug.LogWarning("Failed to create triangle mesh handle.");
			return false;
		}
		if (!OVRPlugin.AddInsightPassthroughSurfaceGeometry(passthroughOverlay.layerId, meshHandle, transformMatrixForPassthroughSurfaceObject, out instanceHandle))
		{
			Debug.LogWarning("Failed to add mesh to passthrough surface.");
			return false;
		}
		return true;
	}

	private void DestroySurfaceGeometries(bool addBackToDeferredQueue = false)
	{
		foreach (KeyValuePair<GameObject, PassthroughMeshInstance> surfaceGameObject in surfaceGameObjects)
		{
			if (surfaceGameObject.Value.meshHandle != 0L)
			{
				OVRPlugin.DestroyInsightPassthroughGeometryInstance(surfaceGameObject.Value.instanceHandle);
				OVRPlugin.DestroyInsightTriangleMesh(surfaceGameObject.Value.meshHandle);
				if (addBackToDeferredQueue)
				{
					deferredSurfaceGameObjects.Add(new DeferredPassthroughMeshAddition
					{
						gameObject = surfaceGameObject.Key,
						updateTransform = surfaceGameObject.Value.updateTransform
					});
				}
			}
		}
		surfaceGameObjects.Clear();
	}

	private void UpdateSurfaceGeometryTransforms()
	{
		foreach (KeyValuePair<GameObject, PassthroughMeshInstance> surfaceGameObject in surfaceGameObjects)
		{
			if (surfaceGameObject.Value.updateTransform && surfaceGameObject.Value.instanceHandle != 0L)
			{
				Matrix4x4 transformMatrixForPassthroughSurfaceObject = GetTransformMatrixForPassthroughSurfaceObject(surfaceGameObject.Key);
				if (!OVRPlugin.UpdateInsightPassthroughGeometryTransform(surfaceGameObject.Value.instanceHandle, transformMatrixForPassthroughSurfaceObject))
				{
					Debug.LogWarning("Failed to update a transform of a passthrough surface");
				}
			}
		}
	}

	private void AllocateColorMapData()
	{
		if (colorMapData == null)
		{
			colorMapData = new byte[4096];
			if (colorMapDataHandle.IsAllocated)
			{
				Debug.LogWarning("Passthrough color map data handle is not expected to be allocated at time of buffer allocation");
			}
			colorMapDataHandle = GCHandle.Alloc(colorMapData, GCHandleType.Pinned);
		}
	}

	private void DeallocateColorMapData()
	{
		if (colorMapData != null)
		{
			if (!colorMapDataHandle.IsAllocated)
			{
				Debug.LogWarning("Passthrough color map data handle is expected to be allocated at time of buffer deallocation");
			}
			else
			{
				colorMapDataHandle.Free();
			}
			colorMapData = null;
		}
	}

	private static Gradient CreateNeutralColorMapGradient()
	{
		Gradient gradient = new Gradient();
		gradient.colorKeys = new GradientColorKey[2]
		{
			new GradientColorKey(new Color(0f, 0f, 0f), 0f),
			new GradientColorKey(new Color(1f, 1f, 1f), 1f)
		};
		gradient.alphaKeys = new GradientAlphaKey[2]
		{
			new GradientAlphaKey(1f, 0f),
			new GradientAlphaKey(1f, 1f)
		};
		return gradient;
	}

	private void UpdateColorMapFromControls(bool forceUpdate = false)
	{
		if (colorMapEditorType != ColorMapEditorType.Controls)
		{
			return;
		}
		AllocateColorMapData();
		if (!forceUpdate && colorMapEditorGradient.Equals(colorMapEditorGradientOld) && colorMapEditorContrast_ == colorMapEditorContrast && colorMapEditorBrightness_ == colorMapEditorBrightness && colorMapEditorPosterize_ == colorMapEditorPosterize)
		{
			return;
		}
		colorMapEditorGradientOld.CopyFrom(colorMapEditorGradient);
		colorMapEditorContrast_ = colorMapEditorContrast;
		colorMapEditorBrightness_ = colorMapEditorBrightness;
		colorMapEditorPosterize_ = colorMapEditorPosterize;
		AllocateColorMapData();
		for (int i = 0; i < 256; i++)
		{
			double num = (double)i / 255.0;
			double num2 = colorMapEditorContrast + 1f;
			num = (num - 0.5) * num2 + 0.5 + (double)colorMapEditorBrightness;
			if (colorMapEditorPosterize > 0f)
			{
				double num3 = (Math.Pow(50.0, colorMapEditorPosterize) - 1.0) / 49.0;
				num = Math.Round(num / num3) * num3;
			}
			num = Math.Min(Math.Max(num, 0.0), 1.0);
			Color color = colorMapEditorGradient.Evaluate((float)num);
			WriteColorToColorMap(i, ref color);
		}
		styleDirty = true;
	}

	private void WriteColorToColorMap(int colorIndex, ref Color color)
	{
		for (int i = 0; i < 4; i++)
		{
			Buffer.BlockCopy(BitConverter.GetBytes(color[i]), 0, colorMapData, colorIndex * 16 + i * 4, 4);
		}
	}

	private void SyncToOverlay()
	{
		passthroughOverlay.currentOverlayType = overlayType;
		passthroughOverlay.compositionDepth = compositionDepth;
		passthroughOverlay.hidden = hidden;
		passthroughOverlay.overridePerLayerColorScaleAndOffset = overridePerLayerColorScaleAndOffset;
		passthroughOverlay.colorScale = colorScale;
		passthroughOverlay.colorOffset = colorOffset;
		if (passthroughOverlay.currentOverlayShape != overlayShape)
		{
			if (passthroughOverlay.layerId > 0)
			{
				Debug.LogWarning("Change to projectionSurfaceType won't take effect until the layer goes through a disable/enable cycle. ");
			}
			if (projectionSurfaceType == ProjectionSurfaceType.Reconstructed)
			{
				Debug.Log("Removing user defined surface geometries");
				DestroySurfaceGeometries();
			}
			passthroughOverlay.currentOverlayShape = overlayShape;
		}
		passthroughOverlay.enabled = OVRManager.instance != null && OVRManager.instance.isInsightPassthroughEnabled && OVRManager.IsInsightPassthroughInitialized();
	}

	private void Update()
	{
		SyncToOverlay();
	}

	private void LateUpdate()
	{
		if (passthroughOverlay.layerId <= 0)
		{
			return;
		}
		if (projectionSurfaceType == ProjectionSurfaceType.UserDefined)
		{
			UpdateSurfaceGeometryTransforms();
			AddDeferredSurfaceGeometries();
		}
		UpdateColorMapFromControls();
		if (!styleDirty)
		{
			return;
		}
		OVRPlugin.InsightPassthroughStyle style = default(OVRPlugin.InsightPassthroughStyle);
		style.Flags = (OVRPlugin.InsightPassthroughStyleFlags)7;
		style.TextureOpacityFactor = textureOpacity;
		style.EdgeColor = (edgeRenderingEnabled ? edgeColor.ToColorf() : new OVRPlugin.Colorf
		{
			r = 0f,
			g = 0f,
			b = 0f,
			a = 0f
		});
		style.TextureColorMapType = colorMapType;
		style.TextureColorMapData = IntPtr.Zero;
		style.TextureColorMapDataSize = 0u;
		if (style.TextureColorMapType != OVRPlugin.InsightPassthroughColorMapType.None && colorMapData == null)
		{
			Debug.LogError("Color map not allocated");
			style.TextureColorMapType = OVRPlugin.InsightPassthroughColorMapType.None;
		}
		if (style.TextureColorMapType != OVRPlugin.InsightPassthroughColorMapType.None)
		{
			if (!colorMapDataHandle.IsAllocated)
			{
				Debug.LogError("Passthrough color map enabled but data isn't pinned");
			}
			else
			{
				style.TextureColorMapData = colorMapDataHandle.AddrOfPinnedObject();
				switch (style.TextureColorMapType)
				{
				case OVRPlugin.InsightPassthroughColorMapType.MonoToRgba:
					style.TextureColorMapDataSize = 4096u;
					break;
				case OVRPlugin.InsightPassthroughColorMapType.MonoToMono:
					style.TextureColorMapDataSize = 256u;
					break;
				default:
					Debug.LogError("Unexpected texture color map type");
					break;
				}
			}
		}
		OVRPlugin.SetInsightPassthroughStyle(passthroughOverlay.layerId, style);
		styleDirty = false;
	}

	private void OnEnable()
	{
		auxGameObject = new GameObject("OVRPassthroughLayer auxiliary GameObject");
		auxGameObject.transform.parent = base.transform;
		passthroughOverlay = auxGameObject.AddComponent<OVROverlay>();
		passthroughOverlay.currentOverlayShape = overlayShape;
		SyncToOverlay();
		styleDirty = true;
	}

	private void OnDisable()
	{
		if (OVRManager.loadedXRDevice == OVRManager.XRDevice.Oculus)
		{
			DestroySurfaceGeometries(addBackToDeferredQueue: true);
		}
		if (auxGameObject != null)
		{
			UnityEngine.Object.Destroy(auxGameObject);
			auxGameObject = null;
			passthroughOverlay = null;
		}
	}

	private void OnDestroy()
	{
		DestroySurfaceGeometries();
	}
}
