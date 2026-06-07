using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Doozy.Engine.Progress
{
	[AddComponentMenu("Doozy/Progress/Progressor Group", 13)]
	[DefaultExecutionOrder(-100)]
	public class ProgressorGroup : MonoBehaviour
	{
		public const float TOLERANCE = 0.001f;

		public bool DebugMode;

		public List<Progressor> Progressors;

		public ProgressEvent OnProgressChanged;

		public ProgressEvent OnInverseProgressChanged;

		private Sequence m_animationSequence;

		private float m_previousProgress;

		private float m_progress;

		public float Progress
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float InverseProgress => 0f;

		private bool DebugComponent => false;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void UpdateProgress()
		{
		}

		public float GetProgress(TargetProgress direction)
		{
			return 0f;
		}

		private void RemoveAnyNullProgressors()
		{
		}

		private void OnProgressUpdated()
		{
		}

		private static ProgressorGroup AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
