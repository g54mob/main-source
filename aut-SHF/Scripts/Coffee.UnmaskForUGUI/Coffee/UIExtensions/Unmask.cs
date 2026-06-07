using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	[ExecuteInEditMode]
	[AddComponentMenu("UI/Unmask/Unmask", 1)]
	public class Unmask : MonoBehaviour, IMaterialModifier
	{
		private static readonly Vector2 s_Center;

		[Tooltip("Fit graphic's transform to target transform.")]
		[SerializeField]
		private RectTransform m_FitTarget;

		[Tooltip("Fit graphic's transform to target transform on LateUpdate every frame.")]
		[SerializeField]
		private bool m_FitOnLateUpdate;

		[Tooltip("Unmask affects only for children.")]
		[SerializeField]
		private bool m_OnlyForChildren;

		[Tooltip("Show the graphic that is associated with the unmask render area.")]
		[SerializeField]
		private bool m_ShowUnmaskGraphic;

		[Tooltip("Edge smoothing.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float m_EdgeSmoothing;

		private Material _unmaskMaterial;

		private Material _revertUnmaskMaterial;

		private MaskableGraphic _graphic;

		public MaskableGraphic graphic => null;

		public RectTransform fitTarget
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool fitOnLateUpdate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showUnmaskGraphic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool onlyForChildren
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float edgeSmoothing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Material GetModifiedMaterial(Material baseMaterial)
		{
			return null;
		}

		public void FitTo(RectTransform target)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void LateUpdate()
		{
		}

		private void SetDirty()
		{
		}

		private static void Smoothing(MaskableGraphic graphic, float smooth)
		{
		}
	}
}
