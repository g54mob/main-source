using UnityEngine;

namespace TH20.UI
{
	[CreateAssetMenu(menuName = "TH20/Button Animator Preset", order = 1030)]
	public class ButtonAnimatorPreset : ScriptableObjectWithID
	{
		[SerializeField]
		private Sprite _selectedBackgroundSprite;

		[SerializeField]
		private Sprite _unselectableBackgroundSprite;

		public bool PointerOverAnimation;

		public Vector2 PointerOverSizeDelta;

		public bool AnimateIfUnselectable = true;

		public float MousOverIntoDuration;

		public EasingsUtils.Functions MouseOverIntoEaseFunction;

		public float MousOverOutroDuration;

		public EasingsUtils.Functions MouseOverOutroEaseFunction;

		public Sprite SelectedBackgroundSprite => _selectedBackgroundSprite;

		public Sprite UnselectableBackgroundSprite => _unselectableBackgroundSprite;
	}
}
