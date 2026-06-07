using System;
using Doozy.Engine.UI.Animation;
using UnityEngine;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIButtonLoopAnimation
	{
		public UIAnimation Animation;

		public bool Enabled;

		public bool IsPlaying;

		public ButtonLoopAnimationType LoopAnimationType;

		public bool LoadSelectedPresetAtRuntime;

		public string PresetCategory;

		public string PresetName;

		public UIButtonLoopAnimation(ButtonLoopAnimationType loopAnimationType)
		{
		}

		public void LoadPreset()
		{
		}

		public void LoadPreset(string presetCategory, string presetName)
		{
		}

		public void Reset(ButtonLoopAnimationType loopAnimationType)
		{
		}

		public void Start(RectTransform target, Vector3 startPosition, Vector3 startRotation)
		{
		}

		public void Stop(RectTransform target)
		{
		}
	}
}
