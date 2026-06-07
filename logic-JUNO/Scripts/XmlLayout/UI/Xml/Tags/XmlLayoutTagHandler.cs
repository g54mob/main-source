using System.Collections.Generic;
using UnityEngine;

namespace UI.Xml.Tags
{
	public class XmlLayoutTagHandler : ElementTagHandler
	{
		public override MonoBehaviour primaryComponent => null;

		protected override AttributeDictionary defaultAttributeValues => new AttributeDictionary(new Dictionary<string, string>
		{
			{
				"vm-DataSource",
				string.Empty
			},
			{
				"onClickSound",
				string.Empty
			},
			{
				"onShowSound",
				string.Empty
			},
			{
				"onHideSound",
				string.Empty
			},
			{
				"onMouseEnterSound",
				string.Empty
			},
			{
				"onMouseExitSound",
				string.Empty
			},
			{ "showAnimation", "None" },
			{ "hideAnimation", "None" },
			{ "showAnimationDelay", "0" },
			{ "hideAnimationDelay", "0" },
			{ "animationDuration", "0.25" },
			{ "defaultOpacity", "1" },
			{ "audioVolume", "1" },
			{
				"audioMixerGroup",
				string.Empty
			},
			{ "allowDragging", "false" },
			{ "restrictDraggingToParentBounds", "true" },
			{ "returnToOriginalPositionWhenReleased", "true" },
			{ "isDropReceiver", "true" },
			{
				"tooltip",
				string.Empty
			},
			{
				"tooltipBackgroundColor",
				string.Empty
			},
			{
				"tooltipBackgroundImage",
				string.Empty
			},
			{
				"tooltipBorderColor",
				string.Empty
			},
			{
				"tooltipBorderImage",
				string.Empty
			},
			{ "tooltipFollowMouse", "false" },
			{
				"tooltipFont",
				string.Empty
			},
			{ "tooltipFontSize", "0" },
			{ "tooltipOffset", "0" },
			{ "tooltipPadding", "0" },
			{ "tooltipPosition", "Right" },
			{
				"tooltipTextColor",
				string.Empty
			},
			{
				"tooltipTextOutlineColor",
				string.Empty
			},
			{
				"cursor",
				string.Empty
			},
			{
				"cursorClick",
				string.Empty
			},
			{ "currentOffset", "0" }
		});

		public override void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			attributesToApply = XmlLayoutUtilities.MergeAttributes(defaultAttributeValues, attributesToApply);
			base.ApplyAttributes(attributesToApply);
			if (!Application.isPlaying)
			{
				return;
			}
			if (attributesToApply.ContainsKey("cursor") && !string.IsNullOrEmpty(attributesToApply["cursor"]))
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					XmlLayoutSingleton<XmlLayoutCursorController>.Instance.SetCursorForState(XmlLayoutCursorController.eCursorState.Default, attributesToApply["cursor"].ToCursorInfo(), isDefault: true);
				}, base.currentXmlElement);
			}
			if (attributesToApply.ContainsKey("cursorClick") && !string.IsNullOrEmpty(attributesToApply["cursorClick"]))
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					XmlLayoutSingleton<XmlLayoutCursorController>.Instance.SetCursorForState(XmlLayoutCursorController.eCursorState.Click, attributesToApply["cursorClick"].ToCursorInfo(), isDefault: true);
				}, base.currentXmlElement);
			}
		}
	}
}
