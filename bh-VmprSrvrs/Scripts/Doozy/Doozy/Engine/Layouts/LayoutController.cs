using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Layouts
{
	public class LayoutController : MonoBehaviour
	{
		private const bool DEFAULT_NEEDS_REBUILD = true;

		public bool NeedsRebuild;

		private float m_lastRebuildTime;

		private LayoutGroup m_layoutGroup;

		private RectTransform m_rectTransform;

		public LayoutGroup Layout
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RectTransform RectTransform => null;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void DisableLayoutGroup()
		{
		}

		public void EnableLayoutGroup()
		{
		}

		public void Rebuild(bool forced = false)
		{
		}

		private void UpdateReference()
		{
		}
	}
}
