using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Cameras;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Flight;
using ModApi.Craft;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Screenshot
{
	public class PromotionalScreenshot
	{
		public static void SavePlanetScreenshot()
		{
			DateTime now = DateTime.Now;
			string text = $"C:\\temp\\Planet-{now.Year}-{now.Month}-{now.Day} {now.Hour}-{now.Minute}-{now.Second}.png";
			Camera component = GameObject.Find("ScaledSpaceCamera").GetComponent<Camera>();
			SceneCameraScript component2 = component.GetComponent<SceneCameraScript>();
			if (component2 != null)
			{
				UnityEngine.Object.Destroy(component2);
			}
			byte[] bytes = ScreenshotDialogScript.TakeScreenShotWithCamera(component, component.pixelWidth, component.pixelHeight, allowTransparency: true).EncodeToPNG();
			File.WriteAllBytes(text, bytes);
			Debug.LogFormat("Saved Planet Screenshot: {0}", text);
		}

		public static void SaveCraftScreenshot(ICraftScript craftScript, bool exhaustEnabled, string suffix)
		{
			DateTime now = DateTime.Now;
			string text = $"C:\\temp\\Craft-{now.Year}-{now.Month}-{now.Day} {now.Hour}-{now.Minute}-{now.Second}-{suffix}.png";
			List<GameObject> list = new List<GameObject>();
			if (!exhaustEnabled)
			{
				IExhaustSystem[] componentsInChildren = craftScript.Transform.GetComponentsInChildren<IExhaustSystem>();
				foreach (IExhaustSystem exhaustSystem in componentsInChildren)
				{
					list.Add(exhaustSystem.GameObject);
				}
			}
			foreach (GameObject item in list)
			{
				item.SetActive(value: false);
			}
			Camera nearCamera = FlightSceneScript.Instance.ViewManager.GameView.GameCamera.NearCamera;
			SceneCameraScript component = nearCamera.GetComponent<SceneCameraScript>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			byte[] bytes = ScreenshotDialogScript.TakeScreenShotWithCamera(nearCamera, nearCamera.pixelWidth, nearCamera.pixelHeight, allowTransparency: true).EncodeToPNG();
			File.WriteAllBytes(text, bytes);
			foreach (GameObject item2 in list)
			{
				item2.SetActive(value: true);
			}
			Debug.LogFormat("Saved Craft Screenshot: {0}", text);
		}
	}
}
