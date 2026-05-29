using System.Collections.Generic;
using UnityEngine;

namespace __Project__.Scripts.Meta
{
	public class BackgroundScaleHelper : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> m_ChildObjects;

		[SerializeField]
		private RectTransform m_TransformToScale;

		[SerializeField]
		private float m_DefaultScale;

		[SerializeField]
		private float m_TotalPadding;

		[SerializeField]
		private bool m_IsHorizontal;

		private void OnEnable()
		{
		}

		public void Setup()
		{
		}
	}
}
