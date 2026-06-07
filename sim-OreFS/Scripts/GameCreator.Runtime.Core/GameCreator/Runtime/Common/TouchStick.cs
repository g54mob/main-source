using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("Game Creator/UI/Touch Stick")]
	public class TouchStick : TTouchStick
	{
		[SerializeField]
		private GameObject m_Root;

		[SerializeField]
		private RectTransform m_Surface;

		[SerializeField]
		private RectTransform m_Stick;

		public override GameObject Root => m_Root;

		protected internal override RectTransform Surface => m_Surface;

		protected internal override RectTransform Stick => m_Stick;
	}
}
