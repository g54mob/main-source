using System.Collections.Generic;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class G_FpsManager : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		private GameObject m_fpsGraphGameObject;

		[SerializeField]
		private List<GameObject> m_nonBasicTextGameObjects;

		[SerializeField]
		private List<Image> m_backgroundImages;

		private GraphyManager m_graphyManager;

		private G_FpsGraph m_fpsGraph;

		private G_FpsMonitor m_fpsMonitor;

		private G_FpsText m_fpsText;

		private RectTransform m_rectTransform;

		private List<GameObject> m_childrenGameObjects;

		private GraphyManager.ModuleState m_previousModuleState;

		private GraphyManager.ModuleState m_currentModuleState;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void SetPosition(GraphyManager.ModulePosition newModulePosition)
		{
		}

		public void SetState(GraphyManager.ModuleState state, bool silentUpdate = false)
		{
		}

		public void RestorePreviousState()
		{
		}

		public void UpdateParameters()
		{
		}

		public void RefreshParameters()
		{
		}

		private void Init()
		{
		}

		private void SetGraphActive(bool active)
		{
		}
	}
}
