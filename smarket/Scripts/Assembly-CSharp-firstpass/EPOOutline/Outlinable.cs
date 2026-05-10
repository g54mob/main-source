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
			private bool enabled;

			[SerializeField]
			private Color color;

			[SerializeField]
			[Range(0f, 1f)]
			private float dilateShift;

			[SerializeField]
			[Range(0f, 1f)]
			private float blurShift;

			[SerializeField]
			[SerializedPassInfo("Fill style", "Hidden/EPO/Fill/")]
			private SerializedPass fillPass;

			public bool Enabled
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public Color Color
			{
				get
				{
					return default(Color);
				}
				set
				{
				}
			}

			public float DilateShift
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float BlurShift
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public SerializedPass FillPass => null;
		}

		private static List<TargetStateListener> tempListeners;

		private static HashSet<Outlinable> outlinables;

		private Action _visibilityCallback;

		[SerializeField]
		private ComplexMaskingMode complexMaskingMode;

		[SerializeField]
		private OutlinableDrawingMode drawingMode;

		[SerializeField]
		private int outlineLayer;

		[SerializeField]
		public List<OutlineTarget> outlineTargets;

		[SerializeField]
		private RenderStyle renderStyle;

		[SerializeField]
		private OutlineProperties outlineParameters;

		[SerializeField]
		private OutlineProperties backParameters;

		[SerializeField]
		private OutlineProperties frontParameters;

		private bool shouldValidateTargets;

		public RenderStyle RenderStyle
		{
			get
			{
				return default(RenderStyle);
			}
			set
			{
			}
		}

		public ComplexMaskingMode ComplexMaskingMode
		{
			get
			{
				return default(ComplexMaskingMode);
			}
			set
			{
			}
		}

		public bool ComplexMaskingEnabled => false;

		public OutlinableDrawingMode DrawingMode
		{
			get
			{
				return default(OutlinableDrawingMode);
			}
			set
			{
			}
		}

		public int OutlineLayer
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public List<OutlineTarget> OutlineTargets => null;

		public OutlineProperties OutlineParameters => null;

		public OutlineProperties BackParameters => null;

		public bool NeedFillMask => false;

		public OutlineProperties FrontParameters => null;

		public bool IsObstacle => false;

		public OutlineTarget this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool TryAddTarget(OutlineTarget target)
		{
			return false;
		}

		public void RemoveTarget(OutlineTarget target)
		{
		}

		private void Reset()
		{
		}

		private void OnValidate()
		{
		}

		private void SubscribeToVisibilityChange(GameObject go)
		{
		}

		private void UpdateVisibility()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Awake()
		{
		}

		private void ValidateTargets()
		{
		}

		private void OnDestroy()
		{
		}

		public static void GetAllActiveOutlinables(Camera camera, List<Outlinable> outlinablesList)
		{
		}

		public int GetSubmeshCount(Renderer renderer)
		{
			return 0;
		}

		public void AddAllChildRenderersToRenderingList(RenderersAddingMode renderersAddingMode = RenderersAddingMode.All)
		{
		}

		private void Update()
		{
		}

		public bool MatchingMode(Renderer renderer, RenderersAddingMode mode)
		{
			return false;
		}
	}
}
