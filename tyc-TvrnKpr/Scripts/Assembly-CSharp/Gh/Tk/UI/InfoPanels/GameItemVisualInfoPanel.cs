using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class GameItemVisualInfoPanel : GameObjectXInfoPanel
	{
		[SerializeField]
		private Button3DUIView _trashButton;

		[SerializeField]
		private Stars3DUIView _stars;

		[SerializeField]
		private Transform _spoilageElement;

		[SerializeField]
		private ObjectProgressBar3DUIView _spoilageProgressBar;

		[SerializeField]
		private TextMeshPro _spoilageMultiplier;

		[SerializeField]
		private TextBlock3DUIView _spoilageDurationText;

		public override GameObjectX Gox
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		public override void Refresh()
		{
		}

		private void InvalidateSpoilPageVisibility()
		{
		}

		private void OnSpoilProgressChanged(object sender, EventArgs<float> e)
		{
		}

		private void UpdateSpoilProgress(float value)
		{
		}

		private void OnSpoilRateModifierChanged(object sender, EventArgs<float> e)
		{
		}

		private void UpdateSpoilRateModifier(float value)
		{
		}

		private void OnSuspendSpoilingChanged(object sender, EventArgs<bool> e)
		{
		}

		private void UpdateSuspendSpoiling(bool value)
		{
		}
	}
}
