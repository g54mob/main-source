using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
	[Serializable]
	public class InteractionVariants
	{
		public string des;

		public string keyNames;

		public KeyCode[] keys;

		public object[] param;

		public Transform _object;

		public bool visible;

		[HideInInspector]
		public Action<KeyCode, object[]> function;

		[HideInInspector]
		public IEnumerator functionDone;
	}

	[Serializable]
	public class InteractionKeyImage
	{
		public string name;

		public KeyCode key;

		public Sprite img;
	}

	public static InteractionManager instance;

	public Transform CrosshairUI;

	public RectTransform UiInteractionInfo;

	public Transform UiParentButtonKey;

	public Transform UiPrefabButtonKey;

	public TMP_Text UiDescription;

	public CanvasGroup canvasGroup;

	public bool activeInteraction;

	[Header(null)]
	public List<InteractionVariants> interactions;

	public static void ActiveInteraction(bool value)
	{
	}

	public static bool GetActiveInteraction()
	{
		return false;
	}

	public void ClearAllInteraction()
	{
	}

	public void Update()
	{
	}

	public void UpdateUI()
	{
	}

	private Sprite findKeyImage(KeyCode key)
	{
		return null;
	}

	public static bool isNone(InteractionVariants interaction)
	{
		return false;
	}

	public InteractionVariants SetInteraction(string des, string keyNames, bool visible, KeyCode[] keys, object[] param, Action<KeyCode, object[]> act, IEnumerator act_done)
	{
		return null;
	}

	public InteractionVariants SetInteraction(Transform _object, string des, string keyNames, bool visible, KeyCode[] keys, object[] param, Action<KeyCode, object[]> act, IEnumerator act_done)
	{
		return null;
	}

	public InteractionVariants UnsetInteraction(InteractionVariants interaction)
	{
		return null;
	}

	private void Awake()
	{
	}
}
