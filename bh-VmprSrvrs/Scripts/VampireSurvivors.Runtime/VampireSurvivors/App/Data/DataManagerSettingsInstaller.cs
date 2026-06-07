using UnityEngine;
using Zenject;

namespace VampireSurvivors.App.Data
{
	[CreateAssetMenu(fileName = "DataManagerSettings", menuName = "VampireSurvivors/New DataManagerSettings")]
	public class DataManagerSettingsInstaller : ScriptableObjectInstaller<DataManagerSettingsInstaller>
	{
		[SerializeField]
		private DataManagerSettings _Settings;

		public DataManagerSettings Settings => null;

		public override void InstallBindings()
		{
		}
	}
}
