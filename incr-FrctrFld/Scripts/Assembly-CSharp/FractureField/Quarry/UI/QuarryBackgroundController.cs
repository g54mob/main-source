using System.Collections.Generic;
using FractureField.Prestige;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Quarry.UI
{
	public class QuarryBackgroundController : MonoBehaviour
	{
		[Header("UI References")]
		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private AspectRatioFitter _aspectRatioFitter;

		[SerializeField]
		private RectTransform _backgroundRectTransform;

		[Header("Background Data")]
		[SerializeField]
		private List<QuarryBackgroundSettings> _allBackgrounds;

		[Header("Debug")]
		[SerializeField]
		private bool _debugMode;

		private QuarryBackgroundSettings _currentBackground;

		public QuarryBackgroundSettings CurrentBackground => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnPrestigeLayerReset()
		{
		}

		private bool IsFirstTimePrestige(PrestigeLayerType prestigeLayer)
		{
			return false;
		}

		private void LoadSavedBackgroundOrSelectInitial()
		{
		}

		private void SelectInitialBackground()
		{
		}

		private void SelectBackgroundForFirstTimePrestige(PrestigeLayerType prestigeLayer)
		{
		}

		private void SelectRandomBackgroundForPrestigeLayerOrHigher(PrestigeLayerType prestigeLayer)
		{
		}

		private void SelectRandomBackground()
		{
		}

		private bool IsPrestigeLayerUnlocked(PrestigeLayerType prestigeLayer)
		{
			return false;
		}

		private void ApplyBackground(QuarryBackgroundSettings backgroundData)
		{
		}

		private void ValidateBackgrounds()
		{
		}

		public void ForceSelectBackground(string backgroundName)
		{
		}
	}
}
