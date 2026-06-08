using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class HeadingElement : Element
	{
		[Header("Configuration")]
		[SerializeField]
		protected TextMeshPro Heading;

		[Header("State")]
		private Color DefaultColour;

		private RectTransform HeadingTransform;

		public override bool IsSelectable => false;

		public override Bounds BoundingBox
		{
			get
			{
				if (HeadingTransform == null)
				{
					return default(Bounds);
				}
				Vector2 sizeDelta = HeadingTransform.sizeDelta;
				return new Bounds(base.transform.localPosition, new Vector3(sizeDelta.x, sizeDelta.y, 0f));
			}
		}

		private void OnEnable()
		{
			HeadingTransform = Heading.GetComponent<RectTransform>();
			DefaultColour = Heading.color;
		}

		public HeadingElement SetHeading(string heading)
		{
			Heading.text = heading;
			return this;
		}

		public HeadingElement SetSize(float width, float height)
		{
			if (HeadingTransform != null)
			{
				HeadingTransform.sizeDelta = new Vector2(width, height - 0.05f);
			}
			return this;
		}

		public HeadingElement SetStyle(ElementStyle style)
		{
			TextMeshPro heading = Heading;
			TMP_FontAsset font = ((style != ElementStyle.MainMenu) ? GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.Default] : GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu]);
			heading.font = font;
			return this;
		}
	}
}
