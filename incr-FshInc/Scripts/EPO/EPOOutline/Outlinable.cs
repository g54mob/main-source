using System;
using System.Collections.Generic;
using UnityEngine;

namespace EPOOutline
{
	[ExecuteAlways]
	public class Outlinable : MonoBehaviour
	{
		[Serializable]
		public class OutlineProperties
		{
			[SerializeField]
			private bool enabled = true;

			[SerializeField]
			private Color color = Color.yellow;

			[SerializeField]
			[Range(0f, 1f)]
			private float dilateShift = 1f;

			[SerializeField]
			[Range(0f, 1f)]
			private float blurShift = 1f;

			[SerializeField]
			[SerializedPassInfo("Fill style", "Hidden/EPO/Fill/")]
			private SerializedPass fillPass = new SerializedPass();

			public bool Enabled
			{
				get
				{
					return enabled;
				}
				set
				{
					enabled = value;
				}
			}

			public Color Color
			{
				get
				{
					return color;
				}
				set
				{
					color = value;
				}
			}

			public float DilateShift
			{
				get
				{
					return dilateShift;
				}
				set
				{
					dilateShift = value;
				}
			}

			public float BlurShift
			{
				get
				{
					return blurShift;
				}
				set
				{
					blurShift = value;
				}
			}

			public SerializedPass FillPass => fillPass;
		}

		private static HashSet<Outlinable> outlinables = new HashSet<Outlinable>();

		[SerializeField]
		private ComplexMaskingMode complexMaskingMode;

		[SerializeField]
		private OutlinableDrawingMode drawingMode = OutlinableDrawingMode.Normal;

		[SerializeField]
		private int outlineLayer;

		[SerializeField]
		private List<OutlineTarget> outlineTargets = new List<OutlineTarget>();

		[SerializeField]
		private RenderStyle renderStyle = RenderStyle.Single;

		[SerializeField]
		private OutlineProperties outlineParameters = new OutlineProperties();

		[SerializeField]
		private OutlineProperties backParameters = new OutlineProperties();

		[SerializeField]
		private OutlineProperties frontParameters = new OutlineProperties();

		private bool shouldValidateTargets;

		public RenderStyle RenderStyle
		{
			get
			{
				return renderStyle;
			}
			set
			{
				renderStyle = value;
			}
		}

		public ComplexMaskingMode ComplexMaskingMode
		{
			get
			{
				return complexMaskingMode;
			}
			set
			{
				complexMaskingMode = value;
			}
		}

		public OutlinableDrawingMode DrawingMode
		{
			get
			{
				return drawingMode;
			}
			set
			{
				drawingMode = value;
			}
		}

		public int OutlineLayer
		{
			get
			{
				return outlineLayer;
			}
			set
			{
				outlineLayer = value;
			}
		}

		public IReadOnlyList<OutlineTarget> OutlineTargets => outlineTargets;

		public OutlineProperties OutlineParameters => outlineParameters;

		public OutlineProperties FrontParameters => frontParameters;

		public OutlineProperties BackParameters => backParameters;

		internal bool NeedsFillMask
		{
			get
			{
				if ((drawingMode & OutlinableDrawingMode.Normal) == 0)
				{
					return false;
				}
				if (renderStyle != RenderStyle.FrontBack)
				{
					return false;
				}
				if (frontParameters.Enabled || backParameters.Enabled)
				{
					if (!(frontParameters.FillPass.Material != null))
					{
						return backParameters.FillPass.Material != null;
					}
					return true;
				}
				return false;
			}
		}

		public OutlineTarget this[int index]
		{
			get
			{
				return outlineTargets[index];
			}
			set
			{
				outlineTargets[index] = value;
				ValidateTargets();
			}
		}

		public int OutlineTargetsCount => outlineTargets.Count;

		public void AddRenderer(Renderer rendererToAdd, OutlineTargetProvider targetProvider = null)
		{
			int submeshCount = RendererUtility.GetSubmeshCount(rendererToAdd);
			for (int i = 0; i < submeshCount; i++)
			{
				OutlineTarget target = ((targetProvider == null) ? new OutlineTarget(rendererToAdd, i) : targetProvider(rendererToAdd, i));
				AddTarget(target);
			}
		}

		[Obsolete("It's obsolete and will be removed. Use AddTarget instead")]
		public void TryAddTarget(OutlineTarget target)
		{
			AddTarget(target);
		}

		public void AddTarget(OutlineTarget target)
		{
			outlineTargets.Add(target);
			ValidateTargets();
		}

		public void RemoveTarget(OutlineTarget target)
		{
			outlineTargets.Remove(target);
			if (target.renderer != null)
			{
				TargetStateListener component = target.renderer.GetComponent<TargetStateListener>();
				if (!(component == null))
				{
					component.RemoveCallback(this, UpdateVisibility);
				}
			}
		}

		private void Reset()
		{
			AddAllChildRenderersToRenderingList(RenderersAddingMode.MeshRenderer | RenderersAddingMode.SkinnedMeshRenderer | RenderersAddingMode.SpriteRenderer);
		}

		private void OnValidate()
		{
			outlineLayer = Mathf.Clamp(outlineLayer, 0, 63);
			shouldValidateTargets = true;
		}

		private void SubscribeToVisibilityChange(GameObject go)
		{
			TargetStateListener targetStateListener = go.GetComponent<TargetStateListener>();
			if (targetStateListener == null)
			{
				targetStateListener = go.AddComponent<TargetStateListener>();
			}
			targetStateListener.RemoveCallback(this, UpdateVisibility);
			targetStateListener.AddCallback(this, UpdateVisibility);
			targetStateListener.ForceUpdate();
		}

		private void UpdateVisibility()
		{
			if (!base.enabled)
			{
				outlinables.Remove(this);
				return;
			}
			outlineTargets.RemoveAll((OutlineTarget x) => x.renderer == null);
			for (int num = 0; num < OutlineTargets.Count; num++)
			{
				OutlineTarget outlineTarget = OutlineTargets[num];
				outlineTarget.IsVisible = outlineTarget.renderer.isVisible;
			}
			outlineTargets.RemoveAll((OutlineTarget x) => x.renderer == null);
			foreach (OutlineTarget outlineTarget2 in outlineTargets)
			{
				if (outlineTarget2.IsVisible)
				{
					outlinables.Add(this);
					return;
				}
			}
			outlinables.Remove(this);
		}

		private void OnEnable()
		{
			UpdateVisibility();
		}

		private void OnDisable()
		{
			outlinables.Remove(this);
		}

		private void Awake()
		{
			ValidateTargets();
		}

		private void ValidateTargets()
		{
			outlineTargets.RemoveAll((OutlineTarget x) => x.renderer == null);
			foreach (OutlineTarget outlineTarget in outlineTargets)
			{
				SubscribeToVisibilityChange(outlineTarget.renderer.gameObject);
			}
		}

		private void OnDestroy()
		{
			outlinables.Remove(this);
		}

		public static void GetAllActiveOutlinables(List<Outlinable> outlinablesList)
		{
			outlinablesList.Clear();
			foreach (Outlinable outlinable in outlinables)
			{
				outlinablesList.Add(outlinable);
			}
		}

		public void AddAllChildRenderersToRenderingList(RenderersAddingMode renderersAddingMode = RenderersAddingMode.All)
		{
			outlineTargets.Clear();
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
			foreach (Renderer renderer in componentsInChildren)
			{
				if (MatchingMode(renderer, renderersAddingMode))
				{
					int submeshCount = RendererUtility.GetSubmeshCount(renderer);
					for (int j = 0; j < submeshCount; j++)
					{
						AddTarget(new OutlineTarget(renderer, j));
					}
				}
			}
		}

		private void Update()
		{
			if (shouldValidateTargets)
			{
				shouldValidateTargets = false;
				ValidateTargets();
			}
		}

		private bool MatchingMode(Renderer rendererToMatch, RenderersAddingMode mode)
		{
			if ((rendererToMatch is MeshRenderer || rendererToMatch is SkinnedMeshRenderer || rendererToMatch is SpriteRenderer || (mode & RenderersAddingMode.Others) == 0) && (!(rendererToMatch is MeshRenderer) || (mode & RenderersAddingMode.MeshRenderer) == 0) && (!(rendererToMatch is SpriteRenderer) || (mode & RenderersAddingMode.SpriteRenderer) == 0))
			{
				if (rendererToMatch is SkinnedMeshRenderer)
				{
					return (mode & RenderersAddingMode.SkinnedMeshRenderer) != 0;
				}
				return false;
			}
			return true;
		}
	}
}
