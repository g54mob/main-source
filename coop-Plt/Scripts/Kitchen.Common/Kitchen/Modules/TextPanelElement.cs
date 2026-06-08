using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class TextPanelElement : Element
	{
		public enum Style
		{
			Default = 0,
			Recipe = 1,
			Button = 2
		}

		[Header("References")]
		[SerializeField]
		private TextMeshPro Text;

		[SerializeField]
		private TextMeshPro Title;

		[SerializeField]
		private MeshRenderer Quad;

		[SerializeField]
		private RecipeLocalisation Recipes;

		[Header("State")]
		public InputPromptElement Prompt;

		public override Bounds BoundingBox => new Bounds(base.transform.localPosition, new Vector3(Quad.transform.localScale.x, Quad.transform.localScale.y, 0f));

		public InputPromptElement AddPrompt()
		{
			Prompt = Add<InputPromptElement>();
			PositionPrompt();
			return Prompt;
		}

		protected void PositionPrompt()
		{
			if (!(Prompt == null))
			{
				Vector3 localScale = Quad.transform.localScale;
				float num = ((localScale.y < 1f) ? 0.3f : 0.15f);
				Prompt.Position = new Vector2(localScale.x / 2f - 0.25f, (0f - localScale.y) / 2f + num);
			}
		}

		public TextPanelElement SetText(string title, string text)
		{
			Title.text = title;
			Text.text = text;
			return this;
		}

		public TextPanelElement Resize(float width, float height)
		{
			Text.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
			Quad.transform.localScale = new Vector3(width, height, 1f);
			Title.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 0.4f);
			Title.transform.localPosition = new Vector3(0f, height / 2f + 0.2f, -0.05f);
			PositionPrompt();
			return this;
		}

		public TextPanelElement SetStyle(Style style, ThemeColour colour = ThemeColour.Default)
		{
			switch (style)
			{
			case Style.Default:
				Resize(3f, 2f);
				break;
			case Style.Recipe:
				Resize(4f, 3f);
				break;
			case Style.Button:
				Resize(2.5f, 0.6f);
				break;
			}
			base.MemoryManagerHandle.Register(Quad.material).SetColor("_Highlight", Element.Colours[colour]);
			return this;
		}

		public TextPanelElement SetRecipe(Dish dish)
		{
			SetStyle(Style.Recipe);
			SetText(dish.Name, Recipes[dish]);
			return this;
		}
	}
}
