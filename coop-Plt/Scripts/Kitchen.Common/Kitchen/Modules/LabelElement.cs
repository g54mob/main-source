using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class LabelElement : Element
	{
		[Header("Configuration")]
		[SerializeField]
		protected TextMeshPro Label;

		[Header("State")]
		private Color DefaultColour;

		private RectTransform LabelTransform;

		public override bool IsSelectable => false;

		public override Bounds BoundingBox
		{
			get
			{
				if (LabelTransform == null)
				{
					return default(Bounds);
				}
				Vector2 sizeDelta = LabelTransform.sizeDelta;
				return new Bounds(base.transform.localPosition, new Vector3(sizeDelta.x, sizeDelta.y, 0f));
			}
		}

		private void OnEnable()
		{
			LabelTransform = Label.GetComponent<RectTransform>();
			DefaultColour = Label.color;
		}

		public LabelElement SetLabel(string label)
		{
			if (Label.text == label)
			{
				return this;
			}
			Label.text = label;
			return this;
		}

		public virtual LabelElement SetSize(float width, float height)
		{
			if (LabelTransform != null)
			{
				LabelTransform.sizeDelta = new Vector2(width, height - 0.05f);
			}
			return this;
		}

		public LabelElement SetStyle(ElementStyle style)
		{
			TextMeshPro label = Label;
			TMP_FontAsset font = ((style != ElementStyle.MainMenu) ? GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.Default] : GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu]);
			label.font = font;
			return this;
		}
	}
}
