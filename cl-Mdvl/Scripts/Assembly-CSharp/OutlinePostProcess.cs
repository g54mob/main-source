using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Managers.Selection;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using UnityEngine;
using UnityEngine.UI;

public class OutlinePostProcess : MonoBehaviour
{
	private static OutlinePostProcess instance;

	private static bool isInstantiated;

	private GlobalSettings globalSettings;

	public bool enable;

	public bool pixelBase;

	public bool occluder;

	public bool alphaDepth;

	private Camera postProcessCam;

	private Camera maskCam;

	[SerializeField]
	private Color outlineColor = new Color(1f, 0.2f, 0f, 1f);

	[SerializeField]
	private Color outlineColorSecondary = new Color(0f, 0f, 0f, 0.5f);

	[SerializeField]
	private Color fillColor = new Color(1f, 1f, 1f, 0.2f);

	private float originalFillColorAlpha;

	[SerializeField]
	private Color fillColorEnemy = new Color(1f, 0.1f, 0.01f, 0.25f);

	[SerializeField]
	private Color defaultFillColor = new Color(1f, 1f, 1f, 0.2f);

	[SerializeField]
	private Color dragSelectFillColor = new Color(0f, 1f, 0f, 0.2f);

	[SerializeField]
	public Color SkepPlantsInRangeFillColor = new Color(1f, 1f, 0.5f, 0.2f);

	[Range(1f, 6f)]
	[SerializeField]
	private int outlineThickness = 1;

	[Range(2f, 8f)]
	[SerializeField]
	private int secondaryOutlineThickness = 3;

	private HashSet<SelectableObject> objectsOutline = new HashSet<SelectableObject>();

	private ConcurrentHashSet<SelectableObject> objectsHoverFill = new ConcurrentHashSet<SelectableObject>();

	[Range(1f, 8f)]
	public int resolutionReduce = 4;

	private Resolution currentResolution;

	public string[] ignoreLayerName = new string[4] { "Outline", "Water", "TransparentFX", "UI" };

	private int[] ignoreLayerIndex;

	[NonSerialized]
	private RenderTexture maskTexture;

	[NonSerialized]
	private RenderTexture secondMaskTexture;

	[NonSerialized]
	private RenderTexture tempRT1;

	[NonSerialized]
	private RenderTexture tempRT2;

	private Material postMat;

	private Material flatColor;

	private Material grabDepth;

	[SerializeField]
	private RawImage mask;

	[SerializeField]
	private RawImage temp1;

	[SerializeField]
	private RawImage temp2;

	private bool isRuntime;

	private bool fullScreen;

	[NonSerialized]
	public bool HoverFillEnabled = true;

	public static OutlinePostProcess Instance
	{
		get
		{
			if ((bool)instance)
			{
				return instance;
			}
			instance = UnityEngine.Object.FindObjectOfType(typeof(OutlinePostProcess)) as OutlinePostProcess;
			if (!instance)
			{
				Camera main = Camera.main;
				if (main == null || main.gameObject == null)
				{
					isInstantiated = false;
					return null;
				}
				instance = main.gameObject.AddComponent<OutlinePostProcess>();
			}
			isInstantiated = true;
			instance.Init();
			return instance;
		}
		private set
		{
			if (value == null)
			{
				UnityEngine.Object.Destroy(instance);
			}
			isInstantiated = true;
			instance = value;
		}
	}

	public bool ShowHoverFill { get; set; } = true;

	public bool IsHoverFillShowing
	{
		get
		{
			if (ShowHoverFill)
			{
				return HoverFillEnabled;
			}
			return false;
		}
	}

	public Color OutlineColor
	{
		get
		{
			return outlineColor;
		}
		set
		{
			outlineColor = value;
			postMat.SetColor("_OutlineColor", value);
		}
	}

	public Color FillColor
	{
		get
		{
			return fillColor;
		}
		set
		{
			fillColor = value;
		}
	}

	public Color OutlineColorSecondary
	{
		get
		{
			return outlineColorSecondary;
		}
		set
		{
			outlineColorSecondary = value;
			postMat.SetColor("_OutlineColorSecondary", value);
		}
	}

	public int SecondaryOutlineThickness
	{
		get
		{
			return secondaryOutlineThickness;
		}
		set
		{
			secondaryOutlineThickness = value;
			postMat.SetInt("_SecondaryOutlineThickness", value);
		}
	}

	public int OutlineThickness
	{
		get
		{
			return outlineThickness;
		}
		set
		{
			outlineThickness = value;
			postMat.SetInt("_OutlineThickness", value);
		}
	}

	public Camera MaskCam
	{
		get
		{
			if (maskCam == null)
			{
				maskCam = new GameObject().AddComponent<Camera>();
				maskCam.transform.SetParent(PostProcessCam.transform);
				maskCam.gameObject.name = "OutlineRenderCamera";
				maskCam.enabled = false;
				maskCam.CopyFrom(PostProcessCam);
				maskCam.clearFlags = CameraClearFlags.Nothing;
				maskCam.backgroundColor = Color.magenta;
				maskCam.renderingPath = RenderingPath.Forward;
				maskCam.cullingMask = 1 << LayerMask.NameToLayer("Outline");
				maskCam.allowHDR = false;
			}
			return maskCam;
		}
	}

	public Camera PostProcessCam
	{
		get
		{
			if (postProcessCam == null)
			{
				postProcessCam = GetComponent<Camera>();
			}
			return postProcessCam;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void OnDomainReload()
	{
		instance = null;
		isInstantiated = false;
	}

	public static bool IsInstantiated()
	{
		return isInstantiated;
	}

	private void OnDestroy()
	{
		isInstantiated = false;
		objectsOutline = null;
		objectsHoverFill = null;
		ReleaseTempTexture(maskTexture);
		ReleaseTempTexture(secondMaskTexture);
		ReleaseTempTexture(tempRT1);
		ReleaseTempTexture(tempRT2);
		maskTexture = null;
		secondMaskTexture = null;
		tempRT1 = null;
		tempRT2 = null;
		if (MonoSingleton<SelectionManager>.IsInstantiated())
		{
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnSelectionAssignOrder;
			MonoSingleton<SelectionManager>.Instance.ResetOrderEvent -= OnSelectionResetOrder;
			MonoSingleton<SelectionManager>.Instance.SelectionDrag -= OnZoneSelectionDrag;
			MonoSingleton<SelectionManager>.Instance.SelectionFinishedEvent -= OnSelectionFinished;
			MonoSingleton<SelectionManager>.Instance.SetFillColorEvent -= OnSetFillColor;
			MonoSingleton<SelectionManager>.Instance.ResetFillColorEvent -= OnResetFillColor;
		}
		if (MonoSingleton<ConstructionController>.IsInstantiated())
		{
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnSelectionChangeBuildingType;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnCreatedBuilding;
		}
		if (MonoSingleton<BuildingPlacementManager>.IsInstantiated())
		{
			MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent -= OnSelectionCanceled;
		}
		if (MonoSingleton<NPCController>.IsInstantiated())
		{
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent -= OnHumanoidDied;
		}
		if (MonoSingleton<WorkerController>.IsInstantiated())
		{
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent -= OnHumanoidDied;
		}
		if (MonoSingleton<OptionsController>.IsInstantiated())
		{
			MonoSingleton<OptionsController>.Instance.SetHoverIntensityEvent -= UpdateFillColor;
		}
		postProcessCam = null;
		maskCam = null;
	}

	public void UpdateFillColor()
	{
		Color color = fillColor;
		color.a = originalFillColorAlpha * globalSettings.HoverIntensity;
		fillColor = color;
	}

	public void SetOutlineOnObject(SelectableObject selectable, bool selectionOutline, bool hoverFill)
	{
		if (selectionOutline)
		{
			objectsOutline.Add(selectable);
		}
		if (!selectionOutline && objectsOutline.Remove(selectable))
		{
			selectable.ResetSelectionOutline();
		}
		if (hoverFill)
		{
			objectsHoverFill.Add(selectable);
		}
		if (!hoverFill && objectsHoverFill.Remove(selectable))
		{
			selectable.ResetSelectionOutline();
		}
	}

	private void OnValidate()
	{
		if (isRuntime)
		{
			OutlineColor = outlineColor;
			FillColor = fillColor;
			OutlineColorSecondary = outlineColorSecondary;
			OutlineThickness = outlineThickness;
			SecondaryOutlineThickness = secondaryOutlineThickness;
		}
	}

	private void Start()
	{
		globalSettings = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings;
		Init();
	}

	private void Init()
	{
		if (Instance != this)
		{
			UnityEngine.Object.Destroy(this);
		}
		if (!isRuntime)
		{
			isRuntime = true;
			ignoreLayerIndex = new int[ignoreLayerName.Length];
			for (int i = 0; i < ignoreLayerName.Length; i++)
			{
				ignoreLayerIndex[i] = 1 << LayerMask.NameToLayer(ignoreLayerName[i]);
			}
			postMat = new Material(Shader.Find("Hide/OutlinePostprocess"));
			flatColor = new Material(Shader.Find("Hide/FlatColor"));
			grabDepth = new Material(Shader.Find("Hide/GrabDepth"));
			SetupOutlineCamera(Screen.width, Screen.height, globalSettings.Fullscreen);
			AttachToRawImage();
			OnValidate();
			postMat.SetTexture("_MainTex", maskTexture);
			postMat.SetTexture("_FillMaskTexture", secondMaskTexture);
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnSelectionAssignOrder;
			MonoSingleton<SelectionManager>.Instance.ResetOrderEvent += OnSelectionResetOrder;
			MonoSingleton<SelectionManager>.Instance.SelectionDrag += OnZoneSelectionDrag;
			MonoSingleton<SelectionManager>.Instance.SelectionFinishedEvent += OnSelectionFinished;
			MonoSingleton<SelectionManager>.Instance.SetFillColorEvent += OnSetFillColor;
			MonoSingleton<SelectionManager>.Instance.ResetFillColorEvent += OnResetFillColor;
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnSelectionChangeBuildingType;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnCreatedBuilding;
			MonoSingleton<BuildingPlacementManager>.Instance.SelectionCanceledEvent += OnSelectionCanceled;
			MonoSingleton<NPCController>.Instance.OnNPCDiedEvent += OnHumanoidDied;
			MonoSingleton<WorkerController>.Instance.RemoveWorkerEvent += OnHumanoidDied;
			MonoSingleton<OptionsController>.Instance.SetHoverIntensityEvent += UpdateFillColor;
			originalFillColorAlpha = fillColor.a;
			UpdateFillColor();
		}
	}

	private void OnHumanoidDied(HumanoidInstance humanoid)
	{
		objectsHoverFill.Clear();
	}

	private void OnCreatedBuilding(BaseBuildingInstance building)
	{
		objectsHoverFill.Clear();
	}

	private void OnAutoconstructCompleted(BaseBuildingInstance building)
	{
		objectsHoverFill.Clear();
	}

	private void OnSelectionChangeBuildingType()
	{
		HoverFillEnabled = false;
	}

	private void OnZoneSelectionDrag(float minX, float maxX, float minZ, float maxZ)
	{
		HoverFillEnabled = false;
	}

	private void OnSelectionFinished()
	{
	}

	private void OnSelectionCanceled()
	{
		HoverFillEnabled = true;
	}

	private void OnSelectionResetOrder()
	{
		HoverFillEnabled = true;
	}

	private void OnSelectionAssignOrder(OrderType order, AreaType areaType)
	{
		HoverFillEnabled = order != OrderType.Digging;
	}

	private void OnSetFillColor()
	{
		fillColor = dragSelectFillColor;
	}

	public void OnResetFillColor()
	{
		fillColor = defaultFillColor;
	}

	private static void ReleaseTempTexture(RenderTexture tempRenderTexture)
	{
		if (tempRenderTexture != null)
		{
			RenderTexture.ReleaseTemporary(tempRenderTexture);
		}
	}

	private void SetupOutlineCamera(int width, int height, bool fullscreen)
	{
		if (width != 0 && height != 0)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(61, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\OutlineSelect\\Script\\OutlinePostProcess.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Resizing outline post-processing camera from ");
				messageBuilder.AppendFormatted(currentResolution.width);
				messageBuilder.AppendLiteral(" x ");
				messageBuilder.AppendFormatted(currentResolution.height);
				messageBuilder.AppendLiteral(" (");
				messageBuilder.AppendFormatted(fullScreen ? "fullscreen" : "windowed");
				messageBuilder.AppendLiteral(") to ");
				messageBuilder.AppendFormatted(width);
				messageBuilder.AppendLiteral(" x ");
				messageBuilder.AppendFormatted(height);
				messageBuilder.AppendLiteral(" (");
				messageBuilder.AppendFormatted(fullscreen ? "fullscreen" : "windowed");
				messageBuilder.AppendLiteral(")");
			}
			Log.Info(messageBuilder);
			currentResolution.width = width;
			currentResolution.height = height;
			fullScreen = fullscreen;
			ReleaseTempTexture(maskTexture);
			maskTexture = RenderTexture.GetTemporary(currentResolution.width / resolutionReduce, currentResolution.height / resolutionReduce, 16, RenderTextureFormat.RGB565);
			maskTexture.name = "[temp] OutlinePostprocess.maskTexture";
			ReleaseTempTexture(tempRT1);
			ReleaseTempTexture(tempRT2);
			tempRT1 = RenderTexture.GetTemporary(currentResolution.width / resolutionReduce, currentResolution.height / resolutionReduce, 0, RenderTextureFormat.R8);
			tempRT2 = RenderTexture.GetTemporary(currentResolution.width / resolutionReduce, currentResolution.height / resolutionReduce, 0, RenderTextureFormat.R8);
			tempRT1.name = "[temp] OutlinePostprocess.tempRT1";
			tempRT2.name = "[temp] OutlinePostprocess.tempRT2";
			ReleaseTempTexture(secondMaskTexture);
			secondMaskTexture = RenderTexture.GetTemporary(currentResolution.width / resolutionReduce, currentResolution.height / resolutionReduce, 16, RenderTextureFormat.RGB565);
			secondMaskTexture.name = "[temp] secondMaskTexture.tempRT2";
			postMat.SetTexture("_MainTex", maskTexture);
			postMat.SetTexture("_FillMaskTexture", secondMaskTexture);
		}
	}

	private void LateUpdate()
	{
		if (isInstantiated && !MonoSingleton<LoadingController>.IsApplicationIsQuitting())
		{
			int width = Screen.width;
			int height = Screen.height;
			if (currentResolution.width != width || currentResolution.height != height)
			{
				SetupOutlineCamera(width, height, fullScreen);
			}
		}
	}

	private void CopyCameraSetting(Camera form, Camera to)
	{
		to.fieldOfView = form.fieldOfView;
		to.nearClipPlane = form.nearClipPlane;
		to.farClipPlane = form.farClipPlane;
		to.rect = form.rect;
	}

	private void AttachToRawImage()
	{
		if ((bool)mask && (bool)temp1 && (bool)temp2)
		{
			mask.texture = maskTexture;
			temp1.texture = tempRT1;
			temp2.texture = tempRT2;
		}
	}

	[ImageEffectOpaque]
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		OnValidate();
		Graphics.Blit(source, destination);
		if (!enable)
		{
			return;
		}
		CopyCameraSetting(PostProcessCam, MaskCam);
		Graphics.SetRenderTarget(secondMaskTexture);
		GL.Clear(clearDepth: true, clearColor: true, Color.magenta);
		if (ShowHoverFill && HoverFillEnabled)
		{
			if (HoverFillEnabled && objectsHoverFill.Count == 1 && objectsHoverFill.First() is NPCView { HumanoidInstance: not null } nPCView && nPCView.HumanoidInstance.IsEnemy())
			{
				postMat.SetColor("_FillColor", fillColorEnemy);
			}
			else
			{
				postMat.SetColor("_FillColor", fillColor);
			}
			maskCam.targetTexture = secondMaskTexture;
			objectsHoverFill.RemoveWhere((SelectableObject obj) => obj == null);
			foreach (SelectableObject item in objectsHoverFill)
			{
				if (!item.IsDestroyed)
				{
					item.EnableDisabledRenderers();
					item.ShowSelectionOutline();
				}
			}
			MaskCam.RenderWithShader(null, "");
			foreach (SelectableObject item2 in objectsHoverFill)
			{
				if (!item2.IsDestroyed && !objectsOutline.Contains(item2))
				{
					item2.ResetSelectionOutline();
				}
			}
		}
		maskCam.targetTexture = maskTexture;
		Graphics.SetRenderTarget(maskTexture);
		GL.Clear(clearDepth: true, clearColor: true, Color.magenta);
		if (pixelBase)
		{
			foreach (SelectableObject item3 in objectsOutline)
			{
				item3.ShowSelectionOutline();
			}
			MaskCam.RenderWithShader(null, "");
			Graphics.Blit(maskTexture, tempRT1, flatColor, 0);
			Graphics.Blit(tempRT1, tempRT2, flatColor, 1);
			Graphics.Blit(tempRT2, destination, postMat);
			if (!HoverFillEnabled)
			{
				return;
			}
			{
				foreach (SelectableObject item4 in objectsOutline)
				{
					if (!objectsHoverFill.Contains(item4))
					{
						item4.ResetSelectionOutline();
					}
					else
					{
						item4.RevertDisabledRenderers();
					}
				}
				return;
			}
		}
		MaskCam.RenderWithShader(flatColor.shader, "RenderType");
		Graphics.Blit(maskTexture, destination, postMat);
	}

	public bool IsObjectTypeSelected<T>()
	{
		foreach (SelectableObject item in objectsHoverFill)
		{
			if (item is T)
			{
				return true;
			}
		}
		return false;
	}
}
