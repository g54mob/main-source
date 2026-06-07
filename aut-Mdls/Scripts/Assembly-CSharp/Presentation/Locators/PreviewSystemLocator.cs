using Presentation.FactoryFloor;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/PreviewSystem", fileName = "PreviewSystemLocator", order = 0)]
	public class PreviewSystemLocator : ScriptableObject
	{
		public PreviewSystem PreviewSystem;
	}
}
