using System.Collections.Generic;
using UnityEngine;

namespace Restory.Gameplay.Storages
{
	public class DevicesStoragesRegistry : MonoBehaviour
	{
		[SerializeField]
		private DevicesStorage[] storages = new DevicesStorage[0];

		public IReadOnlyList<DevicesStorage> Storages => storages;
	}
}
