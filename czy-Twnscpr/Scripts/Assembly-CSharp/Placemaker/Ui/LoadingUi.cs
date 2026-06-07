using System.Collections.Generic;
using Placemaker.SceneProcessing;
using UnityEngine;

namespace Placemaker.Ui
{
	public class LoadingUi : MonoBehaviour, UiMaster.IUiSetup, IOnScenePostProcess
	{
		private enum State
		{
			Loading = 0,
			LoadingDone = 1,
			Done = 2,
			Gone = 3,
			ReallyGone = 4,
			IdleShowLogo = 5
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private UpdateState openState;

		[SerializeField]
		private Transform logoContainer;

		[SerializeField]
		private AudioSource audioSource;

		[SerializeField]
		private AudioSource audioJuiceSource;

		[SerializeField]
		private AudioSource doneLoadingSource;

		[SerializeField]
		private List<Color> targetColors;

		public int counter;

		public float timer;

		private bool first;

		private const float fullValue = 0.55f;

		private const float invisibleValue = 0.15f;

		[SerializeField]
		private State state;

		[SerializeField]
		private int pitcher;

		[SerializeField]
		private float minWidth;

		public bool isLoading => false;

		private void Awake()
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void Update()
		{
		}

		public void ShowLogo()
		{
		}

		public void StartLoading()
		{
		}

		public void StopLoading()
		{
		}

		public void StopLoadingNow()
		{
		}

		void IOnScenePostProcess.OnScenePostProcess(bool isBuild, TargetPlatformFlags platform)
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}
	}
}
