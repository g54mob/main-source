using System.Collections.Generic;
using UnityEngine;

public class PreUpdater : MonoBehaviour
{
	public delegate void Func();

	private List<Func> funcs = new List<Func>();

	private bool appHasFocus;

	private static PreUpdater instance_;

	private static PreUpdater instance
	{
		get
		{
			if (instance_ == null)
			{
				GameObject gameObject = new GameObject();
				gameObject.name = "PreUpdater";
				instance_ = gameObject.AddComponent<PreUpdater>();
			}
			return instance_;
		}
	}

	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		RInput.UpdateMousePosition(appHasFocus);
		foreach (Func func in funcs)
		{
			func();
		}
		Framerate.Update();
	}

	private void OnApplicationFocus(bool focus)
	{
		appHasFocus = focus;
		if (focus)
		{
			ScreenHelper.ApplyScreenResolution();
		}
		else
		{
			RInput.UpdateMousePosition(false);
		}
	}

	private void OnDisable()
	{
		instance_ = null;
	}

	private void OnEnable()
	{
		if (instance_ == null)
		{
			instance_ = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public static void Add(Func func)
	{
		if (Application.isPlaying && instance.funcs.IndexOf(func) < 0)
		{
			instance.funcs.Add(func);
		}
	}

	public static void Remove(Func func)
	{
		if (Application.isPlaying)
		{
			instance.funcs.Remove(func);
		}
	}
}
