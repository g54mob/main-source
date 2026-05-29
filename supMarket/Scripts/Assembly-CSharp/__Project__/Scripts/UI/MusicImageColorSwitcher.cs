using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.UI
{
	public class MusicImageColorSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private float m_speed;

		private float m_hue;

		private float s;

		private float v;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
