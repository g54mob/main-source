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

		private static HashSet<Outlinable> outlinables;

		[SerializeField]
		private ComplexMaskingMode complexMaskingMode;

		[SerializeField]
		private OutlinableDrawingMode drawingMode;

		[SerializeField]
		private int outlineLayer;

		[SerializeField]
		private List<OutlineTarget> outlineTargets;

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

		public IReadOnlyList<OutlineTarget> OutlineTargets => null;

		public OutlineProperties OutlineParameters => null;

		public OutlineProperties FrontParameters => null;

		public OutlineProperties BackParameters => null;

		internal bool NeedsFillMask => false;

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

		public int OutlineTargetsCount => 0;

		public void AddRenderer(Renderer rendererToAdd, OutlineTargetProvider targetProvider = null)
		{
		}

		[Obsolete("It's obsolete and will be removed. Use AddTarget instead")]
		public void TryAddTarget(OutlineTarget target)
		{
		}

		public void AddTarget(OutlineTarget target)
		{
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

		public static void GetAllActiveOutlinables(List<Outlinable> outlinablesList)
		{
		}

		public void AddAllChildRenderersToRenderingList(RenderersAddingMode renderersAddingMode = RenderersAddingMode.All)
		{
		}

		private void Update()
		{
		}

		private bool MatchingMode(Renderer rendererToMatch, RenderersAddingMode mode)
		{
			return false;
		}
	}
}
