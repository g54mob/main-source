using UnityEngine;

namespace Kitchen.Modules
{
	public class SpinnerElement : Element
	{
		[SerializeField]
		[Header("Configuration")]
		protected SpriteRenderer Spinner;

		[Header("State")]
		private RectTransform SpriteRendererTransform;

		public override bool IsSelectable => false;

		public override Bounds BoundingBox
		{
			get
			{
				if (SpriteRendererTransform == null)
				{
					return default(Bounds);
				}
				Vector2 sizeDelta = SpriteRendererTransform.sizeDelta;
				return new Bounds(base.transform.localPosition, new Vector3(sizeDelta.x, sizeDelta.y, 0f));
			}
		}

		private void OnEnable()
		{
			if (Spinner != null)
			{
				SpriteRendererTransform = Spinner.GetComponent<RectTransform>();
			}
		}

		public SpinnerElement SetSize(float width, float height)
		{
			if (SpriteRendererTransform != null)
			{
				SpriteRendererTransform.sizeDelta = new Vector2(width, height - 0.05f);
			}
			return this;
		}
	}
}
