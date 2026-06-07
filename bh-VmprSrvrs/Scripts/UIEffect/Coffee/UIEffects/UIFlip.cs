using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/UIEffects/UIFlip", 102)]
	public class UIFlip : BaseMeshEffect
	{
		[Tooltip("Flip horizontally.")]
		[SerializeField]
		private bool m_Horizontal;

		[Tooltip("Flip vertically.")]
		[SerializeField]
		private bool m_Veritical;

		public bool horizontal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool vertical
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void ModifyMesh(VertexHelper vh, Graphic graphic)
		{
		}
	}
}
