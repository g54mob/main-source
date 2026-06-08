using UnityEngine;

namespace Kitchen.Modules
{
	public class CharacterInputElement : LabelElement
	{
		public GameObject Selected;

		[Header("State")]
		private string CharSet = " abcdefghijklmnopqrstuvwxyz123456789";

		public override bool IsSelectable => false;

		public char Current
		{
			get
			{
				string text = Label.text;
				if (string.IsNullOrEmpty(text) || text.Length != 1)
				{
					SetIndex(0);
					return CharSet[0];
				}
				return text[0];
			}
		}

		public override void UpdateFocus()
		{
			base.UpdateFocus();
			Selected.SetActive(HasFocus);
		}

		public void RefreshDisplay()
		{
			Move(back: false, just_refresh: true);
			Selected.SetActive(HasFocus);
		}

		public void Move(bool back = false, bool just_refresh = false)
		{
			string text = Label.text;
			if (string.IsNullOrEmpty(text) || text.Length != 1)
			{
				SetIndex(0);
				return;
			}
			char value = text[0];
			int num = CharSet.IndexOf(value);
			if (num < 0)
			{
				num = 0;
			}
			if (!just_refresh)
			{
				num += ((!back) ? 1 : (-1));
			}
			num = WrapIndex(num);
			SetIndex(num);
		}

		public void Clear()
		{
			SetIndex(0);
		}

		private void SetIndex(int i)
		{
			if (i < 0)
			{
				i = 0;
			}
			if (i >= CharSet.Length)
			{
				i = CharSet.Length - 1;
			}
			Label.text = CharSet[i].ToString();
		}

		private int WrapIndex(int i)
		{
			int length = CharSet.Length;
			return (i % length + length) % length;
		}

		public override LabelElement SetSize(float width, float height)
		{
			return this;
		}
	}
}
