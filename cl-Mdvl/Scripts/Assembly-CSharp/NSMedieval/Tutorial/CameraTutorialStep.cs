using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class CameraTutorialStep : TutorialStep
	{
		private const float PositionGoal = 100f;

		private const float RotationGoal = 200f;

		private const float HeightGoal = 150f;

		private float positionProgress;

		private float rotationProgress;

		private float heightProgress;

		public CameraTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_move_camera"),
				new TutorialStepTask("tut_rotate_camera"),
				new TutorialStepTask("tut_zoom_camera")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			foreach (TutorialStepTask task in Tasks)
			{
				task.SetActive(active: true);
			}
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: true);
			MonoSingleton<RtsCamera>.Instance.CameraPositionEvent += OnCameraPositionChange;
			MonoSingleton<RtsCamera>.Instance.CameraRotationEvent += OnCameraRotationChange;
			MonoSingleton<RtsCamera>.Instance.CameraHeightEvent += OnCameraHeightChange;
			ForceUnpause();
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<RtsCamera>.Instance.CameraPositionEvent -= OnCameraPositionChange;
			MonoSingleton<RtsCamera>.Instance.CameraRotationEvent += OnCameraRotationChange;
			MonoSingleton<RtsCamera>.Instance.CameraHeightEvent -= OnCameraHeightChange;
		}

		private void OnCameraPositionChange(float value)
		{
			positionProgress += value;
			float value2 = positionProgress / 100f;
			UpdateTaskCompletion(0, Mathf.Clamp01(value2));
		}

		private void OnCameraRotationChange(float value)
		{
			rotationProgress += value;
			float value2 = rotationProgress / 200f;
			UpdateTaskCompletion(1, Mathf.Clamp01(value2));
		}

		private void OnCameraHeightChange(float value)
		{
			heightProgress += value;
			float value2 = heightProgress / 150f;
			UpdateTaskCompletion(2, Mathf.Clamp01(value2));
		}
	}
}
