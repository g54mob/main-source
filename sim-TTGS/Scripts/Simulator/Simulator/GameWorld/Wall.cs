using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Wall : MonoBehaviour
	{
		[SerializeField]
		private ExtensionModifier m_extensionModifier;

		public event Action Destroyed;

		private void Awake()
		{
			if (m_extensionModifier != null)
			{
				m_extensionModifier.Modified += OnExtensionModified;
			}
		}

		private void OnDestroy()
		{
			if (m_extensionModifier != null)
			{
				m_extensionModifier.Modified -= OnExtensionModified;
			}
		}

		protected virtual void OnExtensionModified(bool active)
		{
			if (!active)
			{
				this.Destroyed?.Invoke();
			}
		}
	}
}
