using UnityEngine;

namespace Coffee.UIExtensions
{
	[AddComponentMenu("UI/Unmask/UnmaskRaycastFilter", 2)]
	public class UnmaskRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
	{
		[Tooltip("Target unmask component. The ray passes through the unmasked rectangle.")]
		[SerializeField]
		private Unmask m_TargetUnmask;

		public Unmask targetUnmask
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		private void OnEnable()
		{
		}
	}
}
