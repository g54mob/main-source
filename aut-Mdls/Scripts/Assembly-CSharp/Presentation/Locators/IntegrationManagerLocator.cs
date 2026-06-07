using Integrations;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/IntegrationManager", fileName = "IntegrationManagerLocator", order = 0)]
	public class IntegrationManagerLocator : ScriptableObject
	{
		private IntegrationManager _integrationManager;

		public IntegrationManager Integration => _integrationManager;

		public void SetIntegrationManager(IntegrationManager integrationManager)
		{
			_integrationManager = integrationManager;
		}
	}
}
