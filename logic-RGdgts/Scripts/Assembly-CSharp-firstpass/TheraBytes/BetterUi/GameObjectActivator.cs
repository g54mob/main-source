using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheraBytes.BetterUi
{
	[ExecuteAlways]
	public class GameObjectActivator : UIBehaviour, IResolutionDependency
	{
		[Serializable]
		public class Settings : IScreenConfigConnection
		{
			public List<GameObject> ActiveObjects;

			public List<GameObject> InactiveObjects;

			[SerializeField]
			private string screenConfigName;

			public string ScreenConfigName
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[Serializable]
		public class SettingsConfigCollection : SizeConfigCollection<Settings>
		{
		}

		[SerializeField]
		private Settings settingsFallback;

		[SerializeField]
		private SettingsConfigCollection customSettings;

		public Settings CurrentSettings => null;

		protected override void OnEnable()
		{
		}

		public void OnResolutionChanged()
		{
		}

		public void Apply()
		{
		}
	}
}
