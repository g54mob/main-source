using System.Collections.Generic;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk
{
	public class MagicLevelUpdater : MonoBehaviour
	{
		public PatronAttractionDialog3DUIView attractionDialog;

		public List<ParticleSystem> steamJets;

		public List<ParticleSystem> rampEmissionRates;

		public List<ParticleSystem> rampColors;

		private List<float> emissionRates;

		private List<Color> startColors;

		public Renderer frameInnerEdgeDarkeningR;

		public Renderer frameGlowR;

		public Renderer backgroundOverlayDarkeningR;

		private Material frameInnerEdgeDarkening;

		private Material frameGlow;

		private Material backgroundOverlayDarkening;

		private Color frameInnerEdgeDarkeningColor;

		private Color frameGlowColor;

		private Color backgroundOverlayDarkeningColor;

		private bool updateDisabled;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void AttractionDialog_MagicLevelChanged(object sender, EventArgs<float> e)
		{
		}

		private void InitEffects()
		{
		}

		private void UpdateEffects(float magicLevel)
		{
		}

		public void BoxOpened()
		{
		}

		public void CloseBox()
		{
		}
	}
}
