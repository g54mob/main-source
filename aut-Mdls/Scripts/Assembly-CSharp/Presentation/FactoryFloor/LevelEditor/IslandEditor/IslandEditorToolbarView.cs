using UnityEngine;

namespace Presentation.FactoryFloor.LevelEditor.IslandEditor
{
	public class IslandEditorToolbarView : MonoBehaviour
	{
		[SerializeField]
		private Sprite _sprite;

		[SerializeField]
		private string _name;

		[SerializeField]
		private ToolBarType _toolBarType;

		public Sprite Sprite => _sprite;

		public string DisplayName => _name;

		public ToolBarType ToolBarType => _toolBarType;

		public void DeSelect()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Select()
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
