using DG.Tweening;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Activity
{
	public class CategoryButtonScript : WidgetScript
	{
		private float _originalWidth;

		private Widget _sprite;

		private TextWidget _text;

		public SelectActivityDialogScript.Category Category { get; private set; }

		public void Initialize(SelectActivityDialogScript.Category category)
		{
			Category = category;
			_text = base.Widget.FindWidget<TextWidget>("text");
			_text.Text = category.Name;
			_sprite = base.Widget.FindWidget("icon");
			_sprite.SetStyle("sprite", category.Icon);
			_originalWidth = base.Widget.Width.Value;
		}

		public void SetSelected(bool selected)
		{
			_text.SetVisible(selected);
			base.Widget.EnableClass("category-selected", selected);
			DOTween.To(() => base.Widget.Width.GetValueOrDefault(), delegate(float x)
			{
				base.Widget.Width = x;
				LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponentInParent<LayoutGroup>().GetComponent<RectTransform>());
			}, selected ? (_originalWidth + _text.TextMeshPro.preferredWidth + 25f) : _originalWidth, 0.4f).SetUpdate(isIndependentUpdate: true).SetEase((!selected) ? Ease.Linear : Ease.OutBack);
		}
	}
}
