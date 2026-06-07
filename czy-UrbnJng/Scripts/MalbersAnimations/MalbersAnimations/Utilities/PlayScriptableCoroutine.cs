using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	public class PlayScriptableCoroutine : MonoBehaviour
	{
		public FloatReference time = new FloatReference(0.5f);

		public AnimationCurve curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public List<PresetItem> presets;

		private void Start()
		{
			PlayAll();
		}

		public virtual void PlayAll()
		{
			foreach (PresetItem preset in presets)
			{
				preset.Preset.Evaluate(this, preset.Target, time, curve);
			}
		}
	}
}
