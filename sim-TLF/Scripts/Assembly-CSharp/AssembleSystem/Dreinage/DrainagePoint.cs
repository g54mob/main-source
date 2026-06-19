using AssembleSystem.Utils;
using Items;
using MyBox;
using UnityEngine;

namespace AssembleSystem.Dreinage
{
	public class DrainagePoint : MonoBehaviour, IProgressable
	{
		[SerializeField]
		private PartConfig _config;

		[SerializeField]
		[Range(0f, 100f)]
		[ReadOnly(new string[] { })]
		private float _progress;

		private bool _canProgress;

		ProgressToolType IProgressable.ProgressTool => _config.ToolType;

		float IProgressable.CurrentProgress => _progress;

		bool IProgressable.CanProgress => _canProgress;

		void IProgressable.AddProgress(float value)
		{
			_progress += value;
			CheckForMaxProgress();
		}

		private void CheckForMaxProgress()
		{
			if (!(_progress >= 2f) && !(_progress <= 0f))
			{
				_progress = Mathf.Clamp(_progress, 0f, 2f);
			}
		}

		void IProgressable.SetProgress(float value)
		{
			_progress = value;
			CheckForMaxProgress();
		}
	}
}
