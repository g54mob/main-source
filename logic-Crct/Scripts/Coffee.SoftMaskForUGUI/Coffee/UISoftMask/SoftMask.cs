using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	public class SoftMask : Mask, IMeshModifier
	{
		public enum DownSamplingRate
		{
			None = 0,
			x1 = 1,
			x2 = 2,
			x4 = 4,
			x8 = 8
		}

		private static readonly List<SoftMask>[] s_TmpSoftMasks;

		private static readonly Color[] s_ClearColors;

		private static bool s_UVStartsAtTop;

		private static bool s_IsMetal;

		private static Shader s_SoftMaskShader;

		private static Texture2D s_ReadTexture;

		private static readonly List<SoftMask> s_ActiveSoftMasks;

		private static readonly List<SoftMask> s_TempRelatables;

		private static readonly Dictionary<int, Matrix4x4> s_PreviousViewProjectionMatrices;

		private static readonly Dictionary<int, Matrix4x4> s_NowViewProjectionMatrices;

		private static int s_StencilCompId;

		private static int s_ColorMaskId;

		private static int s_MainTexId;

		private static int s_SoftnessId;

		private static int s_Alpha;

		private static int s_PreviousWidth;

		private static int s_PreviousHeight;

		private MaterialPropertyBlock _mpb;

		private CommandBuffer _cb;

		private Material _material;

		private RenderTexture _softMaskBuffer;

		private int _stencilDepth;

		private Mesh _mesh;

		private SoftMask _parent;

		internal readonly List<SoftMask> _children;

		private bool _hasChanged;

		private bool _hasStencilStateChanged;

		[SerializeField]
		[Tooltip("The down sampling rate for soft mask buffer.")]
		[FormerlySerializedAs("m_DesamplingRate")]
		private DownSamplingRate m_DownSamplingRate;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The value used by the soft mask to select the area of influence defined over the soft mask's graphic.")]
		private float m_Softness;

		[Tooltip("The transparency of the whole masked graphic.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_Alpha;

		[Tooltip("Should the soft mask ignore parent soft masks?")]
		[SerializeField]
		[Header("Advanced Options")]
		private bool m_IgnoreParent;

		[SerializeField]
		[Tooltip("Is the soft mask a part of parent soft mask?")]
		private bool m_PartOfParent;

		[SerializeField]
		[Tooltip("Self graphic will not be drawn to soft mask buffer.")]
		private bool m_IgnoreSelfGraphic;

		[SerializeField]
		[Tooltip("Self graphic will not be written to stencil buffer.")]
		private bool m_IgnoreSelfStencil;

		public DownSamplingRate downSamplingRate
		{
			get
			{
				return default(DownSamplingRate);
			}
			set
			{
			}
		}

		public float softness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float alpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ignoreParent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool partOfParent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public RenderTexture softMaskBuffer => null;

		public bool hasChanged
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public SoftMask parent => null;

		public bool ignoreSelfGraphic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ignoreSelfStencil
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private Material material => null;

		private Mesh mesh => null;

		public override Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		void IMeshModifier.ModifyMesh(Mesh mesh)
		{
		}

		void IMeshModifier.ModifyMesh(VertexHelper verts)
		{
		}

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera, Graphic g, int[] interactions)
		{
			return false;
		}

		public override bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		public void ResetMask()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void OnTransformParentChanged()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private static void UpdateMaskTextures()
		{
		}

		private void UpdateMaskTexture()
		{
		}

		private static void GetDownSamplingSize(DownSamplingRate rate, out int w, out int h)
		{
			w = default(int);
			h = default(int);
		}

		private static void ReleaseRt(ref RenderTexture tmpRT)
		{
		}

		private static void ReleaseObject(Object obj)
		{
		}

		private void SetParent(SoftMask newParent)
		{
		}

		private float GetPixelValue(int x, int y, int[] interactions)
		{
			return 0f;
		}
	}
}
