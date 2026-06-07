using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SandboxSettings.Scripts
{
	public class SliderSettingsUi : SandboxSettingsUi
	{
		public InputSlider Slider;

		public List<UILabel> Labels = new List<UILabel>();

		public Color ThumbActiveColor;

		public Color ThumbInactiveColor;

		public int Value
		{
			get
			{
				return Slider.CurrentValue;
			}
			set
			{
				Slider.CurrentValue = value;
			}
		}

		public override void Activate(bool active)
		{
			NameLabel.color = (active ? ActiveColor : InactiveColor);
			List<UILabel> labels = Labels;
			if (labels != null)
			{
				labels.ForEach(delegate(UILabel l)
				{
					l.color = (active ? ActiveColor : InactiveColor);
				});
			}
			Slider.Input.label.color = (active ? ActiveColor : InactiveColor);
			Slider.Slider.thumb.GetComponent<UISprite>().color = (active ? ThumbActiveColor : ThumbInactiveColor);
			GetComponentsInChildren<Collider>().ToList().ForEach(delegate(Collider c)
			{
				c.enabled = active;
			});
		}
	}
}
