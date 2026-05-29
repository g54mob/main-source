using TMPro;
using UnityEngine;

namespace __Project__.Scripts.MiniMap
{
	[RequireComponent(typeof(CanvasGroup))]
	public class MapTooltip : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_TooltipText;

		private Vector2 m_TooltipOffset;

		private CanvasGroup m_CanvasGroup;

		private RectTransform m_RectTransform;

		private void Awake()
		{
		}

		private void Initialize()
		{
		}

		public void Open(string entry, RectTransform marker)
		{
		}

		public void Close()
		{
		}
	}
}
