using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorldSpaceOverlayUI : MonoBehaviour
	{
		private const string shaderTestMode = "unity_GUIZTestMode";

		[Tooltip("Set to blank to automatically populate from the child UI elements")]
		[SerializeField]
		private Graphic[] uiElementsToApplyTo;

		private Dictionary<Material, Material> materialMappings = new Dictionary<Material, Material>();

		private void OnEnable()
		{
			if (uiElementsToApplyTo.Length == 0)
			{
				uiElementsToApplyTo = base.gameObject.GetComponentsInChildren<Graphic>();
			}
			Graphic[] array = uiElementsToApplyTo;
			foreach (Graphic graphic in array)
			{
				Material materialForRendering = graphic.materialForRendering;
				if (materialForRendering == null)
				{
					Debug.LogError("WorldSpaceOverlayUI: skipping target without material " + graphic.name + "." + graphic.GetType().Name);
				}
				else if (!materialForRendering.HasInt("unity_GUIZTestMode") || materialForRendering.GetInt("unity_GUIZTestMode") != 8)
				{
					if (!materialMappings.TryGetValue(materialForRendering, out var value))
					{
						value = new Material(materialForRendering);
						materialMappings.Add(materialForRendering, value);
					}
					value.SetInt("unity_GUIZTestMode", 8);
					graphic.material = value;
				}
			}
		}
	}
}
