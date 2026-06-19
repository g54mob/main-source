using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class SandboxMenuSettingCycleImage : SandboxMenuSetting
	{
		[SerializeField]
		private RolodexControl RolodexControl;

		[SerializeField]
		private GameObject RolodexCardPrefab;

		private Func<int> _getValue;

		private List<SandboxCycleImage> _cards = new List<SandboxCycleImage>();

		public int CardIndex => RolodexControl.CardIndex;

		public void Setup(bool canBeEditedWhenPlayingLevel, bool loop, SandboxTextImageOption[] options, Func<int> getValue, Action<int> valueChanged)
		{
			Setup(new LocalisedString(""), new LocalisedString(""), canBeEditedWhenPlayingLevel);
			Transform parent = RolodexControl.transform;
			List<RectTransform> list = new List<RectTransform>();
			_cards.Clear();
			_getValue = getValue;
			foreach (SandboxTextImageOption sandboxTextImageOption in options)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(RolodexCardPrefab, parent);
				RectTransform component = gameObject.GetComponent<RectTransform>();
				if (component != null)
				{
					SandboxCycleImage componentInChildren = gameObject.GetComponentInChildren<SandboxCycleImage>();
					if (componentInChildren != null)
					{
						componentInChildren.SetTitle(sandboxTextImageOption.Text);
						componentInChildren.SetImage(sandboxTextImageOption.Image);
					}
					_cards.Add(componentInChildren);
					list.Add(component);
				}
			}
			RolodexControl.SetCards<SandboxCycleImage>(list, loop);
			RolodexControl.CardIndex = _getValue();
			RolodexControl.OnCardChanged = valueChanged;
		}

		public void Refresh(SandboxTextImageOption[] options)
		{
			if (_cards.Count != 0)
			{
				for (int i = 0; i < options.Length; i++)
				{
					SandboxTextImageOption sandboxTextImageOption = options[i];
					SandboxCycleImage sandboxCycleImage = _cards[i];
					sandboxCycleImage.SetTitle(sandboxTextImageOption.Text);
					sandboxCycleImage.SetImage(sandboxTextImageOption.Image);
				}
			}
		}

		public override void SetActive(bool active)
		{
			RolodexControl.SetActive(active);
		}

		public override void OnSettingChanged()
		{
			RolodexControl.CardIndex = _getValue();
		}
	}
}
