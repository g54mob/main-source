using System.Collections.Generic;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class G_AudioManager : MonoBehaviour, IMovable, IModifiableState
	{
		[SerializeField]
		private GameObject m_audioGraphGameObject;

		[SerializeField]
		private Text m_audioDbText;

		[SerializeField]
		private List<Image> m_backgroundImages;

		private GraphyManager m_graphyManager;

		private G_AudioGraph m_audioGraph;

		private G_AudioMonitor m_audioMonitor;

		private G_AudioText m_audioText;

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
