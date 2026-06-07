using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class GUILoading : MonoBehaviour
{
	public BlurOptimized BlurScript;

	public static GUILoading Instance;

	private float _rot;

	[NonSerialized]
	private List<GUIWindow> _disabledWindows;

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public static void SetState(bool active)
	{
		if (Instance != null)
		{
			Instance.gameObject.SetActive(active);
		}
	}

	private void OnEnable()
	{
		_rot = 0f;
		BlurScript.enabled = true;
		_disabledWindows = WindowManager.DisableAll(true);
	}

	private void OnDisable()
	{
		if (BlurScript != null && !GameSettings.IsQuitting)
		{
			BlurScript.enabled = false;
			WindowManager.EnableAll(_disabledWindows);
		}
	}

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		_rot += (0f - Time.deltaTime) * 100f;
		base.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.RoundToInt(_rot));
	}
}
