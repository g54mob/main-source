using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class BugFixesInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject bugFixesPrefab;

		public override void InstallBindings()
		{
			base.Container.InstantiateAndQueueForInject(bugFixesPrefab);
		}
	}
}
