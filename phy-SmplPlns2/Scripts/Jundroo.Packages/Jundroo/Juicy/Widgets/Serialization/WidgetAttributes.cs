using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class WidgetAttributes
	{
		public static AttributeSet Set { get; private set; }

		static WidgetAttributes()
		{
			Set = new AttributeSet();
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddBool("visible", delegate(Widget w, bool x)
			{
				w.Animation.SetVisibilityWithAnimation(x, force: true);
			});
			set.AddBool("startVisible", delegate(Widget w, bool x)
			{
				w.StartVisible = x;
			});
			set.AddBool("allowDragging", delegate(Widget w, bool x)
			{
				w.AllowDragging = x;
			});
			set.AddEnum("anchor", delegate(Widget w, AnchorPreset x)
			{
				RectHelper.ApplyAnchor(w.Rect, x);
				if (w.Height.HasValue)
				{
					w.Height = w.Height;
				}
				if (w.Width.HasValue)
				{
					w.Width = w.Width;
				}
			});
			set.AddVector2("anchorMin", delegate(Widget w, Vector2 x)
			{
				w.Rect.anchorMin = x;
			}, (Widget w) => w.Rect.anchorMin);
			set.AddVector2("anchorMax", delegate(Widget w, Vector2 x)
			{
				w.Rect.anchorMax = x;
			}, (Widget w) => w.Rect.anchorMax);
			set.AddInt("colOffset", delegate(Widget w, int x)
			{
				w.ColumnOffset = x;
			});
			set.AddInt("colSpan", delegate(Widget w, int x)
			{
				w.ColumnSpan = x;
			});
			set.AddInt("colStart", delegate(Widget w, int x)
			{
				w.ColumnStart = x;
			});
			set.AddRectOffset("colPadding", delegate(Widget w, RectOffset x)
			{
				w.ColumnPadding = x;
			});
			set.AddString("data", delegate(Widget w, string x)
			{
				w.Data = x;
			});
			set.AddFloat("height", delegate(Widget w, float x)
			{
				w.Height = x;
			}, (Widget w) => w.Height.GetValueOrDefault());
			set.AddString("errorClass", delegate(Widget w, string x)
			{
				w.ErrorClass = x;
			});
			set.AddString("hoverClass", delegate(Widget w, string x)
			{
				w.HoverClass = x;
			});
			set.AddString("pressClass", delegate(Widget w, string x)
			{
				w.PressClass = x;
			});
			set.AddString("flaggedClass", delegate(Widget w, string x)
			{
				w.FlaggedClass = x;
			});
			set.AddBool("flagged", delegate(Widget w, bool x)
			{
				w.Flagged = x;
			});
			set.AddString("selectClass", delegate(Widget w, string x)
			{
				w.SelectClass = x;
			});
			set.AddBool("interactable", delegate(Widget w, bool x)
			{
				w.Interactable = x;
			});
			set.AddRectOffset("margin", delegate(Widget w, RectOffset x)
			{
				w.Margin = x;
			});
			set.AddInt("margin-top", delegate(Widget w, int x)
			{
				w.Margin = UpdateRect(w.Margin, x, null, null, null);
			});
			set.AddInt("margin-right", delegate(Widget w, int x)
			{
				w.Margin = UpdateRect(w.Margin, null, x, null, null);
			});
			set.AddInt("margin-bottom", delegate(Widget w, int x)
			{
				w.Margin = UpdateRect(w.Margin, null, null, x, null);
			});
			set.AddInt("margin-left", delegate(Widget w, int x)
			{
				w.Margin = UpdateRect(w.Margin, null, null, null, x);
			});
			set.AddString("name", delegate(Widget w, string x)
			{
				w.gameObject.name = x;
			});
			set.AddFloat("opacity", delegate(Widget w, float x)
			{
				w.Opacity = x;
			}, (Widget w) => w.Opacity);
			set.AddVector2("pivot", delegate(Widget w, Vector2 x)
			{
				w.Rect.pivot = x;
			}, (Widget w) => w.Rect.pivot);
			set.AddVector2("position", delegate(Widget w, Vector2 x)
			{
				w.Position = x;
			}, (Widget w) => w.Position);
			set.AddEnum("positionConstraint", delegate(Widget w, Widget.WidgetPositionConstraintType x)
			{
				w.PositionConstraint = x;
			});
			set.AddFloat("rotation", delegate(Widget w, float x)
			{
				w.Rect.localRotation = Quaternion.Euler(0f, 0f, x);
			}, (Widget w) => w.Rect.localRotation.eulerAngles.z);
			set.AddVector2("scale", delegate(Widget w, Vector2 x)
			{
				w.Rect.localScale = new Vector3(x.x, x.y, 1f);
			}, (Widget w) => new Vector2(w.Rect.localScale.x, w.Rect.localScale.y));
			set.AddString("script", delegate(Widget w, string x)
			{
				w.AttachScript(x);
			});
			set.AddString("tooltip", delegate(Widget w, string x)
			{
				w.Tooltip = x;
			});
			set.AddEnum("tooltipPosition", delegate(Widget w, TooltipPosition x)
			{
				w.TooltipPosition = x;
			});
			set.AddFloat("tooltipDelay", delegate(Widget w, float x)
			{
				w.TooltipDelay = x;
			}, (Widget w) => w.TooltipDelay.GetValueOrDefault());
			set.AddFloat("width", delegate(Widget w, float x)
			{
				w.Width = x;
			}, (Widget w) => w.Width.GetValueOrDefault());
			set.AddString("onClick", delegate(Widget w, string x)
			{
				w.EventClick = x;
			});
			set.AddString("onHoverEnter", delegate(Widget w, string x)
			{
				w.EventHoverEnter = x;
			});
			set.AddString("onHoverExit", delegate(Widget w, string x)
			{
				w.EventHoverExit = x;
			});
			set.AddString("onSelect", delegate(Widget w, string x)
			{
				w.EventSelect = x;
			});
			set.AddString("onDeselect", delegate(Widget w, string x)
			{
				w.EventDeselect = x;
			});
			set.AddString("onPointerDown", delegate(Widget w, string x)
			{
				w.EventPointerDown = x;
			});
			set.AddString("onPointerUp", delegate(Widget w, string x)
			{
				w.EventPointerUp = x;
			});
			set.AddBool("safeArea", delegate(Widget w, bool x)
			{
				w.SafeArea = x;
			});
			set.AddBool("useLayoutElement", delegate(Widget w, bool x)
			{
				w.UseLayoutElement = x;
			});
			set.AddBool("ignoreLayout", delegate(Widget w, bool x)
			{
				w.IgnoreLayout = x;
			});
			set.AddFloat("minHeight", delegate(Widget w, float x)
			{
				w.MinHeight = x;
			}, (Widget w) => w.MinHeight);
			set.AddFloat("minWidth", delegate(Widget w, float x)
			{
				w.MinWidth = x;
			}, (Widget w) => w.MinWidth);
			set.AddFloat("preferredHeight", delegate(Widget w, float x)
			{
				w.PreferredHeight = x;
			}, (Widget w) => w.PreferredHeight);
			set.AddFloat("preferredWidth", delegate(Widget w, float x)
			{
				w.PreferredWidth = x;
			}, (Widget w) => w.PreferredWidth);
			set.AddFloat("flexibleWidth", delegate(Widget w, float x)
			{
				w.FlexibleWidth = x;
			}, (Widget w) => w.FlexibleWidth);
			set.AddFloat("flexibleHeight", delegate(Widget w, float x)
			{
				w.FlexibleHeight = x;
			}, (Widget w) => w.FlexibleHeight);
			set.AddInt("layoutPriority", delegate(Widget w, int x)
			{
				w.LayoutPriority = x;
			});
			set.AddAnimation("showAnimation", delegate(Widget w, AnimationData x)
			{
				w.Animation.ShowAnimation = x;
			});
			set.AddAnimation("hideAnimation", delegate(Widget w, AnimationData x)
			{
				w.Animation.HideAnimation = x;
			});
			set.AddColor("border", delegate(Widget w, Color x)
			{
				w.Border.Color.Base = x;
			}, (Widget w) => w.Border.Color.Base);
			set.AddFloat("borderAlpha", delegate(Widget w, float x)
			{
				w.Border.Color.Alpha = x;
			}, (Widget w) => w.Border.Color.Alpha);
			set.AddFloat("borderMultiply", delegate(Widget w, float x)
			{
				w.Border.Color.Multiply = x;
			}, (Widget w) => w.Border.Color.Multiply);
			set.AddString("borderSprite", delegate(Widget w, string x)
			{
				w.Border.Sprite = x;
			});
			set.AddEnum("borderSpriteType", delegate(Widget w, Image.Type x)
			{
				w.Border.SpriteType = x;
			});
			set.AddRectOffset("borderPadding", delegate(Widget w, RectOffset x)
			{
				w.Border.Padding = x;
			});
			set.AddSound("sound", delegate(Widget w, SoundData x)
			{
				w.Sound = x;
			});
			set.AddSound("clickSound", delegate(Widget w, SoundData x)
			{
				w.SoundClick = x;
			});
			set.AddSound("hideSound", delegate(Widget w, SoundData x)
			{
				w.SoundHide = x;
			});
			set.AddSound("showSound", delegate(Widget w, SoundData x)
			{
				w.SoundShow = x;
			});
			set.AddSound("hoverSound", delegate(Widget w, SoundData x)
			{
				w.SoundHover = x;
			});
			set.AddSound("hoverExitSound", delegate(Widget w, SoundData x)
			{
				w.SoundHoverExit = x;
			});
			set.AddSound("pressSound", delegate(Widget w, SoundData x)
			{
				w.SoundPress = x;
			});
			set.AddSound("releaseSound", delegate(Widget w, SoundData x)
			{
				w.SoundRelease = x;
			});
		}

		private static RectOffset UpdateRect(RectOffset o, int? top, int? right, int? bottom, int? left)
		{
			return new RectOffset
			{
				top = (top ?? o.top),
				right = (right ?? o.right),
				bottom = (bottom ?? o.bottom),
				left = (left ?? o.left)
			};
		}
	}
}
