using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class FloatAttribute<T> : Attribute where T : class
	{
		public float Default { get; set; }

		public Func<T, float> Getter { get; set; }

		public override string SchemaType
		{
			get
			{
				if (Getter != null)
				{
					return "floatOrAnimation";
				}
				return "float";
			}
		}

		public Action<T, float> Setter { get; set; }

		public bool SupportsAnimation => Getter != null;

		public FloatAttribute(string name)
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
				float num = StringParser.ToFloat(animationData.Target, Default);
				float? num2 = (string.IsNullOrWhiteSpace(animationData.From) ? ((float?)null) : new float?(StringParser.ToFloat(animationData.From, Default)));
				if (!num2.HasValue)
				{
					float num3 = Getter(w as T);
					if (num == num3)
					{
						return;
					}
				}
				if (w.Animation.IsInitialized || num2.HasValue)
				{
					if (num2.HasValue)
					{
						Setter(w as T, num2.Value);
					}
					TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(() => Getter(w as T), delegate(float x)
					{
						Setter(w as T, x);
					}, num, animationData.Duration).SetUpdate(isIndependentUpdate: true);
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
					Setter(w as T, num);
				}
			}
			else
			{
				float arg = StringParser.ToFloat(s, Default);
				Setter(w as T, arg);
			}
		}
	}
}
