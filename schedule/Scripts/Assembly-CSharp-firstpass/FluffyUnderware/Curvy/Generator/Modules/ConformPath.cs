using System;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/Conform Path", ModuleName = "Conform Path", Description = "Projects a path")]
	[HelpURL("https://curvyeditor.com/doclink/cgconformpath")]
	public class ConformPath : CGModule, IOnRequestProcessing, IPathProvider
	{
		private const int DefaultMaxDistance = 100;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path", ModifiesData = true)]
		public CGModuleInputSlot InPath;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGPath))]
		public CGModuleOutputSlot OutPath;

		[Tooltip("The direction to raycast in ")]
		[SerializeField]
		[VectorEx(null, null)]
		private Vector3 m_Direction;

		[SerializeField]
		[Tooltip("The maximum raycast distance")]
		private float m_MaxDistance;

		[SerializeField]
		[Tooltip("Defines an offset shift along the raycast direction")]
		private float m_Offset;

		[SerializeField]
		[Tooltip("If enabled, the entire path is moved to the nearest possible distance. If disabled, each path point is moved individually")]
		private bool m_Warp;

		[SerializeField]
		[Tooltip("The layers to raycast against")]
		private LayerMask m_LayerMask;

		public Vector3 Direction
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float MaxDistance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool Warp
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LayerMask LayerMask
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public bool PathIsClosed => false;

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}

		public static void Conform(CGPath path, Transform pathTransform, LayerMask layers, Vector3 projectionDirection, float offset, float rayLength, bool warp)
		{
		}

		[UsedImplicitly]
		[Obsolete("Use the other override")]
		public static CGPath Conform(Transform pathTransform, CGPath path, LayerMask layers, Vector3 projectionDirection, float offset, float rayLength, bool warp)
		{
			return null;
		}
	}
}
