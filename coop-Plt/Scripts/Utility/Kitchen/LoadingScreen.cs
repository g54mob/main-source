using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kitchen
{
	public class LoadingScreen : SerializedMonoBehaviour
	{
		public static bool IsPerformingLoad;

		public Image LoadImage;

		public string SceneToLoad;

		public Animator LoadingAnimator;

		private AsyncOperation LoadingOperation;

		private PostLoadingInstructionManager PostLoad;

		private float BestLoadTime;

		private float AnimatorTime => LoadingAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime * LoadingAnimator.GetCurrentAnimatorStateInfo(0).length;

		private void Start()
		{
			IsPerformingLoad = true;
			if (!Application.isEditor)
			{
				GlobalConfig<GlobalSerializationConfig>.Instance.LoggingPolicy = LoggingPolicy.LogErrors;
			}
		}

		private void OnDestroy()
		{
			IsPerformingLoad = false;
		}

		private void UpdateProgress()
		{
			AsyncOperation loadingOperation = LoadingOperation;
			float num = ((loadingOperation != null) ? (loadingOperation.progress / 0.85f) : 0f);
			PostLoad?.GetProgress();
			float a = num;
			BestLoadTime = Mathf.Max(a, BestLoadTime);
			LoadImage.fillAmount = BestLoadTime;
		}

		private void Update()
		{
			UpdateProgress();
			if (LoadingOperation == null)
			{
				StartLoading();
			}
			else if (!(LoadingOperation.progress < 0.85f))
			{
				if (PostLoad == null)
				{
					PostLoad = new PostLoadingInstructionManager();
					StartCoroutine(PostLoad.BeginProcessing());
				}
				else if (PostLoad.IsComplete() && (Application.isEditor || AnimatorTime > 4.2f))
				{
					IsPerformingLoad = false;
					LoadingOperation.allowSceneActivation = true;
				}
			}
		}

		public void StartLoading()
		{
			LoadingOperation = SceneManager.LoadSceneAsync(SceneToLoad);
			if (LoadingOperation != null)
			{
				LoadingOperation.allowSceneActivation = false;
			}
		}
	}
}
