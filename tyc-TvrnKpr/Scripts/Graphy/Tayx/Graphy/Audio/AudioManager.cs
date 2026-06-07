using System.Collections.Generic;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Audio
{
	public class AudioManager : MonoBehaviour, IMovable, IModifiableState
	{
		private GraphyManager m_graphyManager;

		private AudioGraph m_audioGraph;

		private AudioMonitor m_audioMonitor;

		private AudioText m_audioText;

		private RectTransform m_rectTransform;

		[SerializeField]
		private GameObject m_audioGraphGameObject;

		[SerializeField]
		private Text m_audioDbText;

		private List<GameObject> m_childrenGameObjects;

		[SerializeField]
		private List<Image> m_backgroundImages;

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
