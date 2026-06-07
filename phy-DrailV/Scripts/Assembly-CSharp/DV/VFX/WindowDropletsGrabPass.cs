using System.Collections.Generic;
using DV.Rain;
using UnityEngine;

namespace DV.VFX
{
	public class WindowDropletsGrabPass : MonoBehaviour
	{
		private static readonly int USE_SECOND_GRAB_PASS = Shader.PropertyToID("_useSecondGrabPass");

		public CameraTrigger trigger;

		public GameObject grabPassHackRenderer;

		public HashSet<Window> windows = new HashSet<Window>();

		private bool shouldBeOn;

		private void Awake()
		{
			trigger.OnMainCameraEnter += Refresh;
			trigger.OnMainCameraExit += Refresh;
			GamePreferences.RegisterToPreferenceUpdated(Preferences.RainQualityIndex, Refresh);
			Refresh();
		}

		private void OnDestroy()
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RainQualityIndex, Refresh);
		}

		private void Refresh()
		{
			shouldBeOn = trigger.IsMainCameraInside && GamePreferences.Get<int>(Preferences.RainQualityIndex) >= 2;
			SetGrabPass(shouldBeOn ? 1 : 0);
			grabPassHackRenderer.SetActive(shouldBeOn);
		}

		private void SetGrabPass(int secondGrabPassEnabled)
		{
			foreach (Window window in windows)
			{
				SetSpecificWindow(window, secondGrabPassEnabled);
			}
		}

		private void SetSpecificWindow(Window window, int secondGrabPassEnabled)
		{
			window.propertyBlock.SetInt(USE_SECOND_GRAB_PASS, secondGrabPassEnabled);
			MeshRenderer[] visuals = window.visuals;
			for (int i = 0; i < visuals.Length; i++)
			{
				visuals[i].SetPropertyBlock(window.propertyBlock);
			}
			Window[] duplicates = window.duplicates;
			foreach (Window window2 in duplicates)
			{
				window2.propertyBlock.SetInt(USE_SECOND_GRAB_PASS, secondGrabPassEnabled);
				visuals = window2.visuals;
				for (int j = 0; j < visuals.Length; j++)
				{
					visuals[j].SetPropertyBlock(window2.propertyBlock);
				}
			}
		}

		public void AddWindow(Window window)
		{
			windows.Add(window);
			SetSpecificWindow(window, shouldBeOn ? 1 : 0);
		}

		public void RemoveWindow(Window window)
		{
			windows.Remove(window);
		}

		public void GrabReferences()
		{
			if (trigger == null)
			{
				trigger = GetComponentInChildren<CameraTrigger>();
			}
			if (grabPassHackRenderer == null)
			{
				grabPassHackRenderer = GetComponentInChildren<WindowDropletsGrabPassHackRenderer>().gameObject;
			}
		}
	}
}
