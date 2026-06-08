using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Kitchen.Modules
{
	public class SeedInputElement : Element
	{
		public List<CharacterInputElement> Inputs = new List<CharacterInputElement>();

		private int CurrentIndex;

		public override Bounds BoundingBox
		{
			get
			{
				Bounds result = default(Bounds);
				foreach (CharacterInputElement input in Inputs)
				{
					result.Encapsulate(input.BoundingBox);
				}
				return result;
			}
		}

		public override bool IsSelectable => true;

		public void StartUsage(bool wipe_value = false)
		{
			foreach (CharacterInputElement input in Inputs)
			{
				input.LoseFocus();
				if (wipe_value)
				{
					input.Clear();
				}
				input.RefreshDisplay();
			}
			CurrentIndex = 0;
			if (Inputs.Count > 0)
			{
				Inputs[0].GainFocus();
			}
		}

		public string GetResult()
		{
			string text = "";
			foreach (CharacterInputElement input in Inputs)
			{
				if (input.Current != ' ')
				{
					text += input.Current;
				}
			}
			return text;
		}

		private CharacterInputElement CurrentInput()
		{
			if (CurrentIndex < 0)
			{
				CurrentIndex = 0;
			}
			if (CurrentIndex >= Inputs.Count)
			{
				CurrentIndex = Inputs.Count - 1;
			}
			return Inputs[CurrentIndex];
		}

		private void SetIndex(int i)
		{
			CurrentInput().LoseFocus();
			if (i < 0)
			{
				i = 0;
			}
			if (i >= Inputs.Count)
			{
				i = Inputs.Count - 1;
			}
			CurrentIndex = i;
			Inputs[CurrentIndex].GainFocus();
		}

		public override bool HandleInteraction(InputState state)
		{
			CharacterInputElement characterInputElement = CurrentInput();
			if (characterInputElement == null)
			{
				return false;
			}
			if (state.MenuUp == ButtonState.Pressed)
			{
				characterInputElement.Move(back: true);
				return true;
			}
			if (state.MenuDown == ButtonState.Pressed)
			{
				characterInputElement.Move();
				return true;
			}
			if (state.MenuLeft == ButtonState.Pressed)
			{
				SetIndex(CurrentIndex - 1);
			}
			if (state.MenuRight == ButtonState.Pressed)
			{
				SetIndex(CurrentIndex + 1);
			}
			return false;
		}
	}
}
