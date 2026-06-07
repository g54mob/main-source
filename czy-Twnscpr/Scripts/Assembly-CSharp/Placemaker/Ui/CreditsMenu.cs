using System;
using Placemaker.SceneProcessing;
using TMPro;
using UnityEngine;

namespace Placemaker.Ui
{
	public class CreditsMenu : MonoBehaviour, UiMaster.IUiSetup, IOnScenePostProcess
	{
		[Serializable]
		private struct AutoScroll
		{
			public bool isActive { get; set; }

			public bool speedIsSet { get; set; }

			public float speed { get; set; }

			public float time { get; private set; }

			public float targetPosition { get; private set; }

			public float direction { get; private set; }

			public void OnOpen()
			{
			}

			public void ChangeDirection()
			{
			}

			public void ResetTimer(float value)
			{
			}
		}

		private UiMaster master;

		public UpdateState openState;

		[SerializeField]
		private BetterScrollRect scrollRect;

		[SerializeField]
		private TMP_Text rawFuryText;

		[SerializeField]
		private TMP_Text specialThanksText;

		[SerializeField]
		private TMP_Text firstNamesText;

		[SerializeField]
		private AutoScroll autoScroll;

		[SerializeField]
		private int openingFrame;

		[SerializeField]
		private Vector2 oldScreenSize;

		[SerializeField]
		private MenuMusic menuMusic;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Open()
		{
		}

		private void Close()
		{
		}

		public void Toggle()
		{
		}

		private bool MaybeUpdateScreenSize()
		{
			return false;
		}

		private void MaybeAdaptAutoScrollSpeed()
		{
		}

		private void Update()
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}
	}
}
