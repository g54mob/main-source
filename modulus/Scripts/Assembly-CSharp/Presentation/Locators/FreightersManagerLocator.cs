using System;
using Logic.Freighter;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/FreightersManagerLocator", fileName = "FreightersManagerLocator", order = 0)]
	public class FreightersManagerLocator : ScriptableObject
	{
		public FreightersManager Manager { get; private set; }

		public bool Exists { get; private set; }

		public event Action<FreightersManager> ManagerSetEvent = delegate
		{
		};

		public void SetFreightersManager(FreightersManager freightersManager)
		{
			Manager = freightersManager;
			Exists = true;
			this.ManagerSetEvent(Manager);
			this.ManagerSetEvent = delegate
			{
			};
		}

		public void ClearFreightersManager()
		{
			Manager = null;
			Exists = false;
		}
	}
}
