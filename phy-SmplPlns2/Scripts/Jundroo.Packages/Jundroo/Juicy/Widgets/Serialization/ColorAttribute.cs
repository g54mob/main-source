using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class ColorAttribute<T> : Attribute where T : class
	{
		public Func<T, Color> Getter { get; set; }

		public override string SchemaType
		{
			get
			{
				if (Getter != null)
				{
					return "colorOrAnimation";
				}
				return "color";
			}
		}

		public Action<T, Color> Setter { get; set; }

		public bool SupportsAnimation => Getter != null;

		public ColorAttribute(string name)
			: base(name)
		{
		}

		public override void Apply(Widget w, string s)
		{
			if (SupportsAnimation)
			{
				w.Animation.StopAnimation(base.Name);
			}
			if (SupportsAnimation && s.Contains(':'))
			{
				AnimationData animationData = StringParser.ToAnimationData(s);
				Color color = StringParser.ToColor(animationData.Target);
				Color? color2 = (string.IsNullOrWhiteSpace(animationData.From) ? ((Color?)null) : new Color?(StringParser.ToColor(animationData.From)));
				if (!color2.HasValue)
				{
					Color color3 = Getter(w as T);
					if (color == color3)
					{
						return;
					}
				}
				if (w.Animation.IsInitialized || color2.HasValue)
				{
					if (color2.HasValue)
					{
						Setter(w as T, color2.Value);
					}
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(() => Getter(w as T), delegate(Color x)
					{
						Setter(w as T, x);
					}, color, animationData.Duration).SetUpdate(isIndependentUpdate: true);
					animationData.ApplyEase(tweenerCore);
					if (animationData.Delay > 0f)
					{
						tweenerCore.SetDelay(animationData.Delay);
					}
					if (animationData.NumLoops != 0)
					{
						tweenerCore.SetLoops(animationData.NumLoops, animationData.LoopType);
					}
					tweenerCore.Pause();
					w.Animation.StartAnimation(base.Name, new WidgetTweenAnimation(tweenerCore));
				}
				else
				{
					Setter(w as T, color);
				}
			}
			else
			{
				Color arg = StringParser.ToColor(s);
				Setter(w as T, arg);
			}
		}
	}
}
