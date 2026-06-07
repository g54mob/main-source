using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UISoftMask
{
	[ExecuteAlways]
	[RequireComponent(typeof(Graphic))]
	public class SoftMaskable : MonoBehaviour, IMaterialModifier, ICanvasRaycastFilter
	{
		private const int kVisibleInside = 85;

		private const int kVisibleOutside = 170;

		private static readonly Hash128 k_InvalidHash;

		private static int s_SoftMaskTexId;

		private static int s_StencilCompId;

		private static int s_MaskInteractionId;

		private static int s_GameVPId;

		private static int s_GameTVPId;

		private static List<SoftMaskable> s_ActiveSoftMaskables;

		private static int[] s_Interactions;

		[HideInInspector]
		[SerializeField]
		[Obsolete]
		private bool m_Inverse;

		[HideInInspector]
		[SerializeField]
		[Tooltip("The interaction for each masks.")]
		private int m_MaskInteraction;

		[SerializeField]
		[Tooltip("Use stencil to mask.")]
		private bool m_UseStencil;

		[SerializeField]
		[Tooltip("Use soft-masked raycast target.\n\nNote: This option is expensive.")]
		private bool m_RaycastFilter;

		private Graphic _graphic;

		private SoftMask _softMask;

		private Hash128 _effectMaterialHash;

		public bool inverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool raycastFilter
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useStencil
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Graphic graphic => null;

		public SoftMask softMask => null;

		public Material modifiedMaterial { get; private set; }

		Material IMaterialModifier.GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		bool ICanvasRaycastFilter.IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		public void SetMaskInteraction(SpriteMaskInteraction intr)
		{
		}

		public void SetMaskInteraction(SpriteMaskInteraction layer0, SpriteMaskInteraction layer1, SpriteMaskInteraction layer2, SpriteMaskInteraction layer3)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}
