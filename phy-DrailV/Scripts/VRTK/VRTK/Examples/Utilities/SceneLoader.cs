using UnityEngine;
using UnityEngine.SceneManagement;

namespace VRTK.Examples.Utilities
{
	public class SceneLoader : MonoBehaviour
	{
		public Object sceneConstructor;

		public bool sdkSwitcher = true;

		public GameObject leftScriptAlias;

		public GameObject rightScriptAlias;

		protected VRTK_SDKSetupSwitcher setupSwitcher;

		protected virtual void Awake()
		{
			ToggleScriptAlias(state: false);
			SceneManager.sceneLoaded += OnSceneLoaded;
			SceneManager.LoadScene(sceneConstructor.name, LoadSceneMode.Additive);
		}

		protected virtual void LateUpdate()
		{
			if (setupSwitcher != null)
			{
				setupSwitcher.gameObject.SetActive(sdkSwitcher);
			}
		}

		protected virtual void OnSceneLoaded(Scene loadedScene, LoadSceneMode loadMode)
		{
			if (loadedScene.name == sceneConstructor.name)
			{
				VRTK_SDKManager vRTK_SDKManager = Object.FindObjectOfType<VRTK_SDKManager>();
				vRTK_SDKManager.gameObject.SetActive(value: false);
				vRTK_SDKManager.scriptAliasLeftController = leftScriptAlias;
				vRTK_SDKManager.scriptAliasRightController = rightScriptAlias;
				vRTK_SDKManager.gameObject.SetActive(value: true);
				ToggleScriptAlias(state: true);
				VRTK_SDKManager.ProcessDelayedToggleBehaviours();
				setupSwitcher = vRTK_SDKManager.GetComponentInChildren<VRTK_SDKSetupSwitcher>();
			}
		}

		protected virtual void ToggleScriptAlias(bool state)
		{
			leftScriptAlias.SetActive(state);
			rightScriptAlias.SetActive(state);
		}
	}
}
