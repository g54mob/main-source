using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DV.Common;
using DV.Highlighting;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.Signs
{
	public class SignHover : MonoBehaviour
	{
		public List<SignDisplayInstance> signTypes;

		private bool isHovered;

		private GameParams gameParams;

		private MeshRenderer[] renderers;

		private bool CanDisplay
		{
			get
			{
				if (SingletonBehaviour<ScreenspaceMouse>.Instance.on)
				{
					return gameParams.RemoteSignReadingAllowed;
				}
				return false;
			}
		}

		private void Awake()
		{
			if (VRManager.IsVREnabled())
			{
				Object.Destroy(this);
				return;
			}
			gameParams = Globals.G.GameParams;
			renderers = base.transform.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		}

		protected virtual void Start()
		{
			SignGeneratorData componentInParent = GetComponentInParent<SignGeneratorData>();
			if ((bool)componentInParent)
			{
				signTypes = new List<SignDisplayInstance>();
				SignParameters[] signParameters = componentInParent.signParameters;
				for (int i = 0; i < signParameters.Length; i++)
				{
					SignParameters signParameters2 = signParameters[i];
					signTypes.Add(new SignDisplayInstance
					{
						prefab = Sign.Config.GetSignReference(signParameters2.type).uiDisplayElement.gameObject,
						text = signParameters2.signText
					});
				}
			}
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				if (!UnloadWatcher.isUnloading)
				{
					SetHovered(on: false);
				}
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceChanged;
				gameParams.PropertyChanged += PropChanged;
				return;
			}
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceChanged;
			}
			gameParams.PropertyChanged -= PropChanged;
		}

		private void PropChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "RemoteSignReadingAllowed")
			{
				StartCoroutine(CheckShouldTurnOffCoro());
			}
		}

		private void ScreenspaceChanged(bool on)
		{
			StartCoroutine(CheckShouldTurnOffCoro());
		}

		private IEnumerator CheckShouldTurnOffCoro()
		{
			yield return null;
			if (isHovered)
			{
				SetHovered(CanDisplay);
			}
		}

		private void SetHovered(bool on)
		{
			SingletonBehaviour<HUDManager>.Instance.SignDisplay.UpdateSigns(on ? signTypes : null);
			ToggleHighlight(on);
		}

		protected virtual void ToggleHighlight(bool on)
		{
			MeshRenderer[] array = renderers;
			foreach (MeshRenderer renderer in array)
			{
				SingletonBehaviour<AGeneralHighlighter>.Instance.ToggleHighlight(on, renderer, AGeneralHighlighter.HighlightType.Sign, useObstructedMaterial: false);
			}
		}

		public void Hovered(bool nonScreenSpaceMode = false, bool ignoreRemoteSignReadingAllowed = false)
		{
			if (CanDisplay || (nonScreenSpaceMode && (gameParams.RemoteSignReadingAllowed || ignoreRemoteSignReadingAllowed)))
			{
				SetHovered(on: true);
			}
			isHovered = true;
		}

		public void Unhovered()
		{
			SetHovered(on: false);
			isHovered = false;
		}
	}
}
