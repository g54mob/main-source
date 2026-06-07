using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ToggleOutlineOnSelection : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		protected OutlineRendererCollection _outlineRendererCollection;

		[SerializeField]
		[Inject(false)]
		private SelectableObject _selectableObject;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_selectableObject.Selected += OnObjectSelected;
			_selectableObject.Deselected += OnObjectDeselected;
			_selectableObject.HoverEnter += OnHoverEnter;
			_selectableObject.HoverExit += OnHoverExit;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_selectableObject.Selected -= OnObjectSelected;
			_selectableObject.Deselected -= OnObjectDeselected;
			_selectableObject.HoverEnter -= OnHoverEnter;
			_selectableObject.HoverExit -= OnHoverExit;
		}

		protected virtual void OnHoverEnter(SelectionMode selectionMode)
		{
			_outlineRendererCollection.EnableOutline(EOutline.Hover);
		}

		protected virtual void OnHoverExit(SelectionMode selectionMode)
		{
			_outlineRendererCollection.DisableOutline(EOutline.Hover);
		}

		protected virtual void OnObjectSelected(SelectionMode selectionMode)
		{
			_outlineRendererCollection.EnableOutline(EOutline.Select);
		}

		protected virtual void OnObjectDeselected(SelectionMode selectionMode)
		{
			_outlineRendererCollection.DisableOutline(EOutline.Select);
		}
	}
}
