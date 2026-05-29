using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/input-action-glyph")]
	[RequireComponent(typeof(RawImage))]
	public class InputActionGlyph : MonoBehaviour
	{
		public InputActionSet set;

		public InputActionSetLayer layer;

		public InputAction action;

		private RawImage image;

		private void Start()
		{
			image = GetComponent<RawImage>();
			if (!App.Initialized)
			{
				App.evtSteamInitialized.AddListener(HandleInitialization);
			}
			else
			{
				HandleInitialization();
			}
		}

		private void HandleInitialization()
		{
			App.evtSteamInitialized.RemoveListener(HandleInitialization);
			RefreshImage();
		}

		private void OnEnable()
		{
			RefreshImage();
		}

		public void RefreshImage()
		{
			if (!(action != null) || !(image != null))
			{
				return;
			}
			if (set != null)
			{
				InputHandle_t[] controllers = Input.Client.Controllers;
				if (controllers.Length != 0)
				{
					Texture2D[] inputGlyphs = action.GetInputGlyphs(controllers[0], set);
					if (inputGlyphs.Length != 0)
					{
						image.texture = inputGlyphs[0];
					}
				}
			}
			else
			{
				if (!(layer != null))
				{
					return;
				}
				InputHandle_t[] controllers2 = Input.Client.Controllers;
				if (controllers2.Length != 0)
				{
					Texture2D[] inputGlyphs2 = action.GetInputGlyphs(controllers2[0], layer);
					if (inputGlyphs2.Length != 0)
					{
						image.texture = inputGlyphs2[0];
					}
				}
			}
		}
	}
}
