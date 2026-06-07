using DV.Utils;
using UnityEngine;

namespace DV
{
	public class TeleportHoverGlow : MonoBehaviour
	{
		private static readonly int TINT_COLOR = Shader.PropertyToID("_TintColor");

		private const float DISTANCE_FADEIN = 20f;

		public GameObject highlight;

		private MaterialPropertyBlock highlightPropertyBlock;

		private Renderer highlightRenderer;

		private Color highlightColor;

		private bool highlightAllowed;

		private float initialAlpha;

		private void Awake()
		{
			if (highlight == null)
			{
				Debug.LogError("Unexpected state: highlight couldn't be found on CabTeleportDestination! Highlight glow won't work properly!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			highlight.SetActive(value: false);
			highlightPropertyBlock = new MaterialPropertyBlock();
			highlightRenderer = highlight.GetComponentInChildren<Renderer>();
			Color color = (highlightColor = highlightRenderer.sharedMaterial.GetColor(TINT_COLOR));
			initialAlpha = color.a;
		}

		private void OnEnable()
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.HighlightCabToggle, RefreshHighlightAllowed);
			RefreshHighlightAllowed();
		}

		private void OnDisable()
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.HighlightCabToggle, RefreshHighlightAllowed);
		}

		public void Hover(float value = 1f)
		{
			if (!highlightAllowed)
			{
				return;
			}
			PlayerCameraSwitcher instance = SingletonBehaviour<PlayerCameraSwitcher>.Instance;
			if (!instance || !instance.externalCamera.PhotoMode)
			{
				bool flag = value > 0.5f;
				highlight.SetActive(flag);
				if (flag)
				{
					Transform transform = PlayerManager.ActiveCamera.transform;
					highlight.transform.LookAt(transform);
					highlightColor.a = initialAlpha * Mathf.Clamp01(Vector3.Distance(highlight.transform.position, transform.position) / 20f);
					highlightPropertyBlock.SetColor(TINT_COLOR, highlightColor);
					highlightRenderer.SetPropertyBlock(highlightPropertyBlock);
				}
			}
		}

		public void Unhover()
		{
			highlight.SetActive(value: false);
		}

		private void RefreshHighlightAllowed()
		{
			highlightAllowed = GamePreferences.Get<bool>(Preferences.HighlightCabToggle);
			if (!highlightAllowed && (bool)highlight)
			{
				highlight.SetActive(value: false);
			}
		}
	}
}
