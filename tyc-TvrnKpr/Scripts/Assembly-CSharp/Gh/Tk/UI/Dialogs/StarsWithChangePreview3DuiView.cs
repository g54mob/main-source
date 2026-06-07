using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class StarsWithChangePreview3DuiView : Stars3DUIView
	{
		private int? _previewValue;

		[SerializeField]
		protected GameObject _rightHalfStarPrefab;

		[SerializeField]
		protected GameObject _leftHalfStarPrefabGain;

		[SerializeField]
		protected GameObject _rightHalfStarPrefabGain;

		[SerializeField]
		protected GameObject _leftHalfStarPrefabLoose;

		[SerializeField]
		protected GameObject _rightHalfStarPrefabLoose;

		public override void SetValue(float rating)
		{
		}

		public void SetPreviewValue(float? value)
		{
		}

		private void UpdateVisual()
		{
		}
	}
}
