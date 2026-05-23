using Presentation.FactoryFloor;
using UnityEngine;

namespace Presentation.Locators.Assigners
{
	public class ToolSystemAssigner : MonoBehaviour
	{
		[SerializeField]
		private ToolSystem _toolSystem;

		[SerializeField]
		private ToolSystemLocator _toolSystemLocator;

		private void Awake()
		{
			_toolSystemLocator.SetToolSystem(_toolSystem);
		}
	}
}
