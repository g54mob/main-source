using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI.Dialogs
{
	public class BindingButton3DUIView : Button3DUIView, IContextMenuProvider
	{
		[SerializeField]
		private BindingVisual _bindVisual;

		[SerializeField]
		private BindingVisual _popupBindVisual;

		private Button3DUIView _bindingField;

		private InputAction _inputAction;

		private int _bindingIndex;

		private List<int> _compositeIndexes;

		private Container3DUIView _ourContainer;

		public void SetData(Button3DUIView bindingField, InputAction inputAction, int bindingIndex, List<int> compositeIndexes)
		{
		}

		private void RefreshVisual()
		{
		}

		protected override void OnClickedInternal()
		{
		}

		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}
	}
}
