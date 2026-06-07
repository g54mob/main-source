using UnityEngine;

namespace Simulator.GameWorld
{
	public class ClientCash : MonoBehaviour, ISensable
	{
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private InputHint m_inputHint;

		private bool m_interactive;

		public void Activate()
		{
			m_interactive = true;
		}

		public bool CanBeSensed()
		{
			if (m_interactive)
			{
				return World.PlayerController.Context == EControllerContext.REGISTER;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}
	}
}
