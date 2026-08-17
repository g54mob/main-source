using System;
using Assets.Scripts.UI.DynamicWindows;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DynamicWindows : MonoBehaviour
{
	public Transform contentParent;

	public Transform overlay;

	public GameObject dynamicWindowPrefab;

	public GameObject dynamicWindowPromptPrefab;

	private void Awake()
	{
		UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnNewSceneLoaded);
		SceneManager.sceneLoaded += value;
	}

	private void OnDestroy()
	{
		UnityAction<Scene, LoadSceneMode> value = (UnityAction<Scene, LoadSceneMode>)(object)new UnityAction<Scene, System.Int32Enum>(OnNewSceneLoaded);
		SceneManager.sceneLoaded -= value;
	}

	private void Update()
	{
		Transform transform = contentParent.transform;
		int childCount = transform.childCount;
		if (childCount <= 1)
		{
			GameObject gameObject = overlay.gameObject;
			if (gameObject.activeSelf)
			{
				GameObject gameObject2 = overlay.gameObject;
				gameObject2.SetActive(value: false);
			}
		}
		else
		{
			GameObject gameObject3 = overlay.gameObject;
			if (!gameObject3.activeSelf)
			{
				GameObject gameObject4 = overlay.gameObject;
				gameObject4.SetActive(value: true);
			}
		}
	}

	public bool HasWindows()
	{
		//IL_00ca: Expected I4, but got O
		//IL_003c: Expected O, but got I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected I4, but got Unknown
		if ((object)contentParent != null)
		{
			int childCount = contentParent.childCount;
			object obj = childCount - 1;
			int num = childCount ^ 1;
			int num2 = childCount ^ obj;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnNewSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		int childCount = contentParent.childCount;
		int num = childCount - 1;
		if (num >= 1)
		{
			do
			{
				Transform child = contentParent.GetChild(num);
				GameObject obj = child.gameObject;
				UnityEngine.Object.Destroy(obj);
				num--;
			}
			while (num >= 1);
		}
	}

	public void NewWindow(string header, string content)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(dynamicWindowPrefab, contentParent);
		DWindow component = gameObject.GetComponent<DWindow>();
		component.Set(header, content);
	}

	public void NewWindowPrompt(string header, string content, Action A_Accept)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(dynamicWindowPromptPrefab, contentParent);
		DWindowPrompt component = gameObject.GetComponent<DWindowPrompt>();
		component.Set(header, content, A_Accept);
	}
}
