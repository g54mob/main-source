using System.Collections.Generic;
using System.Text;
using Tayx.Graphy.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Advanced
{
	public class AdvancedData : MonoBehaviour, IMovable, IModifiableState
	{
		private GraphyManager m_graphyManager;

		private RectTransform m_rectTransform;

		[SerializeField]
		private List<Image> m_backgroundImages;

		[SerializeField]
		private Text m_graphicsDeviceVersionText;

		[SerializeField]
		private Text m_processorTypeText;

		[SerializeField]
		private Text m_operatingSystemText;

		[SerializeField]
		private Text m_systemMemoryText;

		[SerializeField]
		private Text m_graphicsDeviceNameText;

		[SerializeField]
		private Text m_graphicsMemorySizeText;

		[SerializeField]
		private Text m_screenResolutionText;

		[SerializeField]
		private Text m_gameWindowResolutionText;

		[Range(1f, 60f)]
		[SerializeField]
		private float m_updateRate;

		private float m_deltaTime;

		private StringBuilder m_sb;

		private GraphyManager.ModuleState m_previousModuleState;

		private GraphyManager.ModuleState m_currentModuleState;

		private readonly string[] m_windowStrings;

		private void Awake()
		{
		}

		private void Update()
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
	}
}
