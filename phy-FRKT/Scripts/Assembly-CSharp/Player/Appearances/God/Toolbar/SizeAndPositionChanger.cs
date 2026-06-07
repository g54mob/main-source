using UnityEngine;

namespace Player.Appearances.God.Toolbar
{
	public class SizeAndPositionChanger : pi
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_startEffectT;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_endEffectT;

		[SerializeField]
		private Vector3 m_startSize;

		[SerializeField]
		private Vector3 m_endSize;

		[SerializeField]
		private Vector3 m_startPosition;

		[SerializeField]
		private Vector3 m_endPosition;

		[SerializeField]
		private Transform m_changedTransform;

		public override void gcj()
		{
		}

		public override void gck(float a)
		{
		}

		public override void gcl()
		{
		}
	}
}
