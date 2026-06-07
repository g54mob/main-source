using DV.Highlighting;
using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class GeneralHighlighter : AGeneralHighlighter
	{
		public Material materialPost;

		public Material materialMesh;

		private Highlight highlight;

		private bool isVR;

		protected override void Awake()
		{
			base.Awake();
			isVR = VRManager.IsVREnabled();
			highlight = base.gameObject.AddComponent<Highlight>();
			highlight.meshRenderMaterial = materialMesh;
			highlight.imageEffectMaterial = materialPost;
			highlightTypeRuntimeHelpers.Add(HighlightType.Generic, new HighlightTypeRuntimeValues
			{
				condition = () => isVR || !SingletonBehaviour<PlayerCameraSwitcher>.Instance || !SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode
			});
			highlightTypeRuntimeHelpers.Add(HighlightType.Sign, new HighlightTypeRuntimeValues
			{
				condition = () => (isVR || !SingletonBehaviour<PlayerCameraSwitcher>.Instance || !SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode) && GamePreferences.Get<bool>(Preferences.HighlightSigns)
			});
			highlightTypeRuntimeHelpers.Add(HighlightType.Control, new HighlightTypeRuntimeValues
			{
				condition = () => (isVR || !SingletonBehaviour<PlayerCameraSwitcher>.Instance || !SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode) && GamePreferences.Get<bool>(Preferences.HighlightControls)
			});
			highlightTypeRuntimeHelpers.Add(HighlightType.Item, new HighlightTypeRuntimeValues
			{
				condition = () => (isVR || !SingletonBehaviour<PlayerCameraSwitcher>.Instance || !SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode) && GamePreferences.Get<bool>(Preferences.HighlightItems)
			});
			SetupListeners(on: true);
			OnCamChanged();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				PlayerManager.CameraChanged += OnCamChanged;
				GamePreferences.RegisterToPreferenceUpdated(Preferences.HighlightSigns, base.RefreshConditions);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.HighlightItems, base.RefreshConditions);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.HighlightControls, base.RefreshConditions);
			}
			else
			{
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.HighlightSigns, base.RefreshConditions);
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.HighlightItems, base.RefreshConditions);
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.HighlightControls, base.RefreshConditions);
				PlayerManager.CameraChanged -= OnCamChanged;
			}
		}

		private void OnCamChanged()
		{
			highlight.targetCamera = PlayerManager.ActiveCamera;
		}

		protected override void AddHighlight(Renderer renderer, bool useObstructedMaterial, Color color)
		{
			highlight.AddRenderer(renderer, color, useObstructedMaterial);
		}

		protected override void RemoveHighlight(Renderer renderer, bool useObstructedMaterial)
		{
			highlight.RemoveRenderer(renderer);
		}
	}
}
