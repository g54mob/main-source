using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui.Sharing.Screenshot;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Ui.Sharing.Upload.Craft
{
	public class OrthoScreenshotHelper
	{
		public Texture2D FrontScreenshotTexture { get; private set; }

		public Texture2D SideScreenshotTexture { get; private set; }

		public Texture2D TopScreenshotTexture { get; private set; }

		public IEnumerator RenderScreenshots(ICraftScript craftScript)
		{
			GameObject cameraOrthoGameObject = Object.Instantiate(Resources.Load("Design/OrthoCamera")) as GameObject;
			Camera component = cameraOrthoGameObject.GetComponent<Camera>();
			component.enabled = true;
			RenderScreenshots(component, craftScript);
			yield return new WaitForEndOfFrame();
			Object.Destroy(cameraOrthoGameObject);
		}

		private void RenderScreenshots(Camera cameraOrtho, ICraftScript craftScript)
		{
			var list = (from x in Object.FindObjectsOfType<Light>()
				select new
				{
					Light = x,
					Enabled = x.enabled
				}).ToList();
			foreach (var item in list)
			{
				if (item.Light.gameObject.tag == "OrthoLights")
				{
					item.Light.enabled = true;
				}
				else
				{
					item.Light.enabled = false;
				}
			}
			ThemeData newTheme = craftScript.Data.Themes[0].Duplicate();
			ThemeData theme = Game.Instance.CraftThemes.GetTheme("Ortho");
			craftScript.Data.Themes[0].UpdateFromTheme(theme);
			craftScript.Data.Themes[0].Theme.RefreshAll();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			foreach (PartData part in craftScript.Data.Assembly.Parts)
			{
				dictionary[part.Id] = new List<int>();
				dictionary[part.Id].AddRange(part.MaterialIds);
				for (int num = 0; num < part.PartType.DefaultMaterialIds.Count; num++)
				{
					part.PartScript.PartMaterialScript.SetMaterial(part.PartType.DefaultMaterialIds[num], num);
				}
				part.PartScript.PartMaterialScript.OnMaterialsChanged();
			}
			Bounds bounds = Utilities.CalculateBounds(craftScript.Transform.gameObject);
			Vector3 center = bounds.center;
			cameraOrtho.orthographicSize = Mathf.Sqrt(bounds.size.x * bounds.size.x + bounds.size.y * bounds.size.y + bounds.size.z * bounds.size.z) / 2f;
			cameraOrtho.gameObject.transform.position = center + new Vector3(1f, 1f, -1f) * cameraOrtho.orthographicSize * 2f;
			cameraOrtho.gameObject.transform.LookAt(center);
			TopScreenshotTexture = ScreenshotDialogScript.TakeScreenShotWithCamera(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.orthographicSize = Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z) * 1.05f;
			cameraOrtho.gameObject.transform.position = center + Vector3.forward * cameraOrtho.orthographicSize * 2f;
			cameraOrtho.gameObject.transform.LookAt(center);
			FrontScreenshotTexture = ScreenshotDialogScript.TakeScreenShotWithCamera(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.gameObject.transform.position = center + Vector3.right * cameraOrtho.orthographicSize * 2f;
			cameraOrtho.gameObject.transform.LookAt(center);
			SideScreenshotTexture = ScreenshotDialogScript.TakeScreenShotWithCamera(cameraOrtho, 720, 720, allowTransparency: false);
			cameraOrtho.enabled = false;
			foreach (var item2 in list)
			{
				if (item2.Light.gameObject.tag == "OrthoLights")
				{
					item2.Light.enabled = false;
				}
				else
				{
					item2.Light.enabled = item2.Enabled;
				}
			}
			craftScript.Data.Themes[0].UpdateFromTheme(newTheme);
			craftScript.Data.Themes[0].Theme.RefreshAll();
			foreach (PartData part2 in craftScript.Data.Assembly.Parts)
			{
				List<int> list2 = dictionary[part2.Id];
				for (int num2 = 0; num2 < list2.Count; num2++)
				{
					part2.PartScript.PartMaterialScript.SetMaterial(list2[num2], num2);
				}
				part2.PartScript.PartMaterialScript.OnMaterialsChanged();
			}
		}
	}
}
