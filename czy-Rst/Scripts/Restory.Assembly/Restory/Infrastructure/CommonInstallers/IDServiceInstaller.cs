using Restory.Data.SaveLoad;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	[CreateAssetMenu(fileName = "IDServiceInstaller", menuName = "Restory/Infrastructure/IDServiceInstaller")]
	public class IDServiceInstaller : ScriptableObjectInstaller
	{
		[SerializeField]
		private GameObject idServicePrefab;

		public override void InstallBindings()
		{
			IDService component = base.Container.InstantiateAndQueueForInject(idServicePrefab).GetComponent<IDService>();
			base.Container.BindInterfacesAndSelfTo<IDService>().FromInstance(component).AsSingle();
		}
	}
}
