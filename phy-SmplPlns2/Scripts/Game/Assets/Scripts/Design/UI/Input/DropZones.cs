using Jundroo.Common.Platform;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI.Input
{
	public class DropZones
	{
		private Widget _container;

		private DesignerUIScript _designerUI;

		private Widget _lockMove;

		private Widget _subassembly;

		private Widget _trash;

		public DropZones(DesignerUIScript designerUI)
		{
			_designerUI = designerUI;
			_container = designerUI.RootWidget.FindWidget("drop-zones");
			_container.EventHandler = this;
			_trash = _container.FindWidget("drop-zone-trash");
			_subassembly = _container.FindWidget("drop-zone-create-subassembly");
			_lockMove = _container.FindWidget("lock-move");
		}

		public void Hide()
		{
			_container.Hide();
			_designerUI.DesignerScript.Designer.LockMovePart = false;
		}

		public bool IsOverCreateSubassembly()
		{
			return _subassembly.HasClass("drop-zone-hover");
		}

		public bool IsOverTrashCan()
		{
			return _trash.HasClass("drop-zone-hover");
		}

		public void Show(bool isNewOrClonedPart)
		{
			_container.Show();
			_trash.Visible = true;
			_subassembly.Visible = !isNewOrClonedPart;
			_lockMove.Visible = Device.IsMultiTouchEnabled;
		}

		private void OnLockPressed(Widget widget)
		{
			_designerUI.DesignerScript.Designer.LockMovePart = true;
		}

		private void OnLockReleased(Widget widget)
		{
			_designerUI.DesignerScript.Designer.LockMovePart = false;
		}
	}
}
