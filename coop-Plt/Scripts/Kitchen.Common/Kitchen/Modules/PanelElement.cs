using UnityEngine;

namespace Kitchen.Modules
{
	public class PanelElement : Element
	{
		[SerializeField]
		private Renderer PanelBacking;

		public float Padding;

		public IModule Target;

		public override Bounds BoundingBox
		{
			get
			{
				if (Target == null)
				{
					return default(Bounds);
				}
				Bounds boundingBox = Target.BoundingBox;
				boundingBox.Expand(Padding);
				boundingBox.size += new Vector3(0f, 0.1f, 0f);
				return boundingBox;
			}
		}

		public override bool IsSelectable => false;

		public InputPromptElement AddPrompt()
		{
			InputPromptElement inputPromptElement = Add<InputPromptElement>();
			PositionPrompt(inputPromptElement);
			return inputPromptElement;
		}

		protected void PositionPrompt(InputPromptElement prompt)
		{
			if (!(prompt == null))
			{
				Vector3 localScale = PanelBacking.transform.localScale;
				float num = ((localScale.y < 1f) ? 0.3f : 0.15f);
				prompt.Position = (Vector2)PanelBacking.transform.localPosition + new Vector2(localScale.x / 2f - 0.25f, (0f - localScale.y) / 2f + num);
			}
		}

		public void SetColour(Color col)
		{
			base.MemoryManagerHandle.Register(PanelBacking.material).SetColor("_Highlight", col);
		}

		public void SetColour(int player)
		{
			SetColour(Players.Main.Get(player).Profile.Colour);
		}

		public void SetTarget(IModule target)
		{
			if (target == null)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			base.gameObject.SetActive(value: true);
			Target = target;
			Bounds boundingBox = BoundingBox;
			Transform obj = PanelBacking.transform;
			obj.localScale = new Vector3(boundingBox.size.x, boundingBox.size.y, 1f);
			obj.localPosition = boundingBox.center;
		}
	}
}
