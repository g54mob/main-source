using System.Collections;
using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

namespace DV.UI
{
	public class MainMenuVREnabler : NullCheckingMonoBehaviour
	{
		[NullCheck]
		public Canvas menuCanvas;

		[NullCheck]
		public GameObject vrtkPrefab;

		[NullCheck]
		public EventSystem eventSystem;

		public float canvasScale = 0.001f;

		public Vector3 canvasPos = new Vector3(-0.5f, 2f, 0.8f);

		private void Start()
		{
			if (!VRManager.IsVREnabled())
			{
				Debug.Log("VR is not enabled, destroying MainMenuVREnabler (" + base.name + ")", this);
				Object.Destroy(base.gameObject);
				return;
			}
			GameObject gameObject = eventSystem.gameObject;
			bool sendNavigationEvents = gameObject.GetComponent<EventSystem>().sendNavigationEvents;
			Object.Destroy(eventSystem);
			eventSystem = gameObject.AddComponent<VRTK_EventSystem>();
			eventSystem.sendNavigationEvents = sendNavigationEvents;
			GameObject gameObject2 = menuCanvas.transform.Find("Image").gameObject;
			GameObject obj = Object.FindObjectOfType<Camera>().gameObject;
			gameObject2.SetActive(value: false);
			obj.SetActive(value: false);
			menuCanvas.renderMode = RenderMode.WorldSpace;
			menuCanvas.transform.localScale = Vector3.one * canvasScale;
			menuCanvas.transform.position = canvasPos;
			menuCanvas.gameObject.AddComponent<VRTK_UICanvasDV>();
			GameObject gameObject3 = new GameObject("VRTK rig temp");
			gameObject3.SetActive(value: false);
			GameObject obj2 = Object.Instantiate(vrtkPrefab, gameObject3.transform);
			SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, state: true);
			obj2.transform.SetParent(null);
			Object.Destroy(gameObject3);
			StartCoroutine(SetCanvasCamera());
		}

		private IEnumerator SetCanvasCamera()
		{
			Transform transform = VRTK_DeviceFinder.HeadsetCamera();
			while (transform == null)
			{
				yield return null;
				transform = VRTK_DeviceFinder.HeadsetCamera();
			}
			menuCanvas.worldCamera = transform.GetComponent<Camera>();
		}
	}
}
