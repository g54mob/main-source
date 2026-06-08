using Shapes;
using UnityEngine;

namespace Kitchen.Modules
{
	public class GridMenuMiniElement : GridMenuElement
	{
		[Header("Configuration")]
		[SerializeField]
		protected Rectangle Colour;

		public void Set(Color colour)
		{
			BackButton.SetActive(value: false);
			Colour.enabled = true;
			Colour.Color = colour;
		}

		public override void SetAsBack()
		{
			base.SetAsBack();
			Colour.enabled = false;
		}

		public override void SetAsNext()
		{
			base.SetAsNext();
			Colour.enabled = false;
		}
	}
}
