using System;
using Controllers;
using KitchenData;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class ButtonElement : MouseElement
	{
		[Header("Configuration")]
		[SerializeField]
		protected Rectangle BackingBorder;

		[SerializeField]
		protected Rectangle MouseBackingBorder;

		[SerializeField]
		protected TextMeshPro Label;

		[Header("State")]
		private Color DefaultColour;

		public override Bounds BoundingBox => new Bounds
		{
			center = ((this != null) ? base.transform.localPosition : Vector3.zero),
			size = new Vector3(BackingBorder.Width, BackingBorder.Height, 0f)
		};

		public event Action OnActivate = delegate
		{
		};

		private void OnEnable()
		{
			DefaultColour = Label.color;
		}

		public override void SetSelectable(bool selectable, bool keep_full_alpha = false)
		{
			base.SetSelectable(selectable, keep_full_alpha);
			Label.alpha = ((keep_full_alpha || IsSelectable) ? 1f : 0.2f);
		}

		public ButtonElement SetLabel(string label)
		{
			Label.text = label;
			return this;
		}

		public void SetColour(Color c)
		{
			Label.color = c;
		}

		public string GetCurrentLabel()
		{
			return Label.text;
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

		public virtual ButtonElement SetSize(float width, float height)
		{
			BackingBorder.Width = width;
			BackingBorder.Height = height;
			MouseBackingBorder.Width = width;
			MouseBackingBorder.Height = height;
			Label.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height - 0.05f);
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

		public ButtonElement SetStyle(ElementStyle style)
		{
			TextMeshPro label = Label;
			FontStyles fontStyle = ((style != ElementStyle.MainMenu) ? FontStyles.Normal : FontStyles.Normal);
			label.fontStyle = fontStyle;
			TextMeshPro label2 = Label;
			label2.font = style switch
			{
				ElementStyle.MainMenu => GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu], 
				ElementStyle.MainMenuBack => GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu], 
				_ => GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.Default], 
			};
			Rectangle backingBorder = BackingBorder;
			backingBorder.Color = style switch
			{
				ElementStyle.MainMenu => new Color(0.35f, 0.36f, 0.41f), 
				ElementStyle.MainMenuBack => new Color(0.35f, 0.36f, 0.41f), 
				_ => Color.black, 
			};
			return this;
		}
	}
}
