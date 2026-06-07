using Data.FactoryFloor.Islands;
using UnityEngine;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class FactoryObjectEditorToolbarView : IslandEditorToolbarView
	{
		[SerializeField]
		private FactoryObjectLevelEditorButton _button;

		public void SetItems(EnvironmentObjectsDatabase.ItemCollection itemCollection)
		{
			foreach (EnvironmentObjectsDatabase.Item item in itemCollection.Items)
			{
				Object.Instantiate(_button, base.transform).SetItem(item);
			}
		}
	}
}
