using System.Collections.Generic;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Fps
{
	public class FpsManager : MonoBehaviour, IMovable, IModifiableState
	{
		private GraphyManager m_graphyManager;

		private FpsGraph m_fpsGraph;

		private FpsMonitor m_fpsMonitor;

		private FpsText m_fpsText;

		private RectTransform m_rectTransform;

		[SerializeField]
		private GameObject m_fpsGraphGameObject;

		[SerializeField]
		private List<GameObject> m_nonBasicTextGameObjects;

		[SerializeField]
		private List<Image> m_backgroundImages;

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

		public void SetState(GraphyManager.ModuleState state)
		{
		}

		public void RestorePreviousState()
		{
		}

		public void UpdateParameters()
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
