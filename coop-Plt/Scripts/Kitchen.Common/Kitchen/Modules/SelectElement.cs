using System;
using System.Collections.Generic;
using Controllers;
using KitchenData;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class SelectElement : MouseElement, IInput<int>
	{
		[SerializeField]
		private Rectangle Backing;

		[SerializeField]
		private Rectangle MouseBacking;

		[SerializeField]
		private TextMeshPro Label;

		[SerializeField]
		private GameObject LeftPrompt;

		[SerializeField]
		private GameObject RightPrompt;

		[SerializeField]
		private Color BackingColour;

		[SerializeField]
		private Color BackingColourSelected;

		[SerializeField]
		private Animator Animator;

		public bool ShouldLoop;

		public List<string> Options;

		private int _Value;

		public int Value
		{
			get
			{
				return _Value;
			}
			set
			{
				_Value = (ShouldLoop ? ((value + Options.Count - 1) % Options.Count - 1) : Mathf.Clamp(value, 0, Options.Count - 1));
				if (value == _Value)
				{
					this.OnOptionHighlighted(value);
					SetLabel(Options[_Value]);
				}
				LeftPrompt.SetActive(ShouldLoop || _Value != 0);
				RightPrompt.SetActive(ShouldLoop || _Value != Options.Count - 1);
			}
		}

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(Backing.Width, Backing.Height, 0f));

		public event Action<int> OnOptionHighlighted = delegate
		{
		};

		public event Action<int> OnOptionChosen = delegate
		{
		};

		public SelectElement SetLabel(string label)
		{
			Label.text = label;
			return this;
		}

		public SelectElement SetOptions(List<string> options)
		{
			Options = options;
			if (Options.Count > 0)
			{
				Value = 0;
			}
			else
			{
				_Value = 0;
				SetLabel("-");
			}
			return this;
		}

		public SelectElement SetSize(float x, float y)
		{
			Backing.Width = x;
			Backing.Height = y;
			MouseBacking.Width = x;
			MouseBacking.Height = y;
			Label.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
			return this;
		}

		private void InteractRight()
		{
			Animator.Play("Right Highlight");
			Value++;
		}

		private void InteractLeft()
		{
			Animator.Play("Left Highlight");
			Value--;
		}

		public override bool HandleInteraction(InputState state)
		{
			if (state.MenuLeft == ButtonState.Pressed)
			{
				InteractLeft();
				return true;
			}
			if (state.MenuRight == ButtonState.Pressed)
			{
				InteractRight();
				return true;
			}
			if (state.MenuSelect == ButtonState.Pressed)
			{
				this.OnOptionChosen(Value);
				return true;
			}
			return false;
		}

		public override void OnMouseUIUp(Vector3 position)
		{
			if (IsSelectable && base.gameObject.activeInHierarchy)
			{
				base.OnMouseUIUp(position);
				float num = (RelativePosition(position).x - base.transform.localPosition.x) / Backing.Width;
				if (num > 0.25f)
				{
					InteractRight();
				}
				else if (num < -0.25f)
				{
					InteractLeft();
				}
				else
				{
					this.OnOptionChosen(Value);
				}
			}
		}

		public SelectElement SetStyle(ElementStyle style)
		{
			TextMeshPro label = Label;
			FontStyles fontStyle = ((style != ElementStyle.MainMenu) ? FontStyles.Normal : FontStyles.Normal);
			label.fontStyle = fontStyle;
			TextMeshPro label2 = Label;
			TMP_FontAsset font = ((style != ElementStyle.MainMenu) ? GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.Default] : GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu]);
			label2.font = font;
			Rectangle backing = Backing;
			backing.Color = style switch
			{
				ElementStyle.MainMenu => new Color(0.35f, 0.36f, 0.41f), 
				ElementStyle.MainMenuBack => new Color(0.35f, 0.36f, 0.41f), 
				_ => Color.black, 
			};
			return this;
		}
	}
}
