using System;
using Controllers;
using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ColourSelectorElement : MouseElement, IActivateModule
	{
		[Header("Configuration")]
		[SerializeField]
		protected Rectangle ColourElement;

		[SerializeField]
		protected Rectangle BackingBorder;

		[SerializeField]
		protected Rectangle MouseBackingBorder;

		[Header("State")]
		private Color CurrentColour;

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(BackingBorder.Width, BackingBorder.Height, 0f));

		public event Action OnActivate = delegate
		{
		};

		public void SetColour(Color colour)
		{
			ColourElement.Color = colour;
		}

		public override bool HandleInteraction(InputState state)
		{
			if (state.MenuSelect == ButtonState.Pressed)
			{
				this.OnActivate();
				return true;
			}
			return false;
		}

		public virtual ColourSelectorElement SetSize(float width, float height)
		{
			BackingBorder.Width = width;
			BackingBorder.Height = height;
			MouseBackingBorder.Width = width;
			MouseBackingBorder.Height = height;
			return this;
		}

		public override void OnMouseUIUp(Vector3 position)
		{
			if (IsSelectable && base.gameObject.activeInHierarchy)
			{
				base.OnMouseUIUp(position);
				this.OnActivate();
			}
		}
	}
}
