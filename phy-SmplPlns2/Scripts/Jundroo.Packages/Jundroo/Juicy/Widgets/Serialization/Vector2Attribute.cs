using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Juicy.Helpers;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public class Vector2Attribute<T> : Attribute where T : class
	{
		public Vector2 Default { get; set; } = Vector2.zero;

		public Func<T, Vector2> Getter { get; set; }

		public override string SchemaType
		{
			get
			{
				if (Getter != null)
				{
					return "vector2OrAnimation";
				}
				return "vector2";
			}
		}

		public Action<T, Vector2> Setter { get; set; }

		public bool SupportsAnimation => Getter != null;

		public Vector2Attribute(string name)
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
				Vector2 vector = StringParser.ToVector2(animationData.Target, Default);
				Vector2? vector2 = (string.IsNullOrWhiteSpace(animationData.From) ? ((Vector2?)null) : new Vector2?(StringParser.ToVector2(animationData.From, Default)));
				if (!vector2.HasValue)
				{
					Vector2 vector3 = Getter(w as T);
					if (vector == vector3)
					{
						return;
					}
				}
				if (w.Animation.IsInitialized || vector2.HasValue)
				{
					if (vector2.HasValue)
					{
						Setter(w as T, vector2.Value);
					}
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(() => Getter(w as T), delegate(Vector2 x)
					{
						Setter(w as T, x);
					}, vector, animationData.Duration).SetUpdate(isIndependentUpdate: true);
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
					Setter(w as T, vector);
				}
			}
			else
			{
				Vector2 arg = StringParser.ToVector2(s, Default);
				Setter(w as T, arg);
			}
		}
	}
}
