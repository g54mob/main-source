using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class ProgressBarAttributes
	{
		public static AttributeSet Set { get; private set; }

		static ProgressBarAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddColor("backgroundColor", delegate(ProgressBarWidget w, Color x)
			{
				w.BackgroundColor.Base = x;
			}, (ProgressBarWidget w) => w.BackgroundColor.Base);
			set.AddFloat("backgroundColorAlpha", delegate(ProgressBarWidget w, float x)
			{
				w.BackgroundColor.Alpha = x;
			}, (ProgressBarWidget w) => w.BackgroundColor.Alpha);
			set.AddFloat("backgroundColorMultiply", delegate(ProgressBarWidget w, float x)
			{
				w.BackgroundColor.Multiply = x;
			}, (ProgressBarWidget w) => w.BackgroundColor.Multiply);
			set.AddColor("fillColor", delegate(ProgressBarWidget w, Color x)
			{
				w.FillColor.Base = x;
			}, (ProgressBarWidget w) => w.FillColor.Base);
			set.AddFloat("fillColorAlpha", delegate(ProgressBarWidget w, float x)
			{
				w.FillColor.Alpha = x;
			}, (ProgressBarWidget w) => w.FillColor.Alpha);
			set.AddFloat("fillColorMultiply", delegate(ProgressBarWidget w, float x)
			{
				w.FillColor.Multiply = x;
			}, (ProgressBarWidget w) => w.FillColor.Multiply);
			set.AddString("fillSprite", delegate(ProgressBarWidget w, string x)
			{
				w.FillImage.sprite = w.Context.ResourceLoader.LoadSprite(x);
			});
		}
	}
}
