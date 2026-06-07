using UnityEngine;
using UnityEngine.UI;

namespace TriLib.Samples
{
	public class BlendShapeControl : MonoBehaviour
	{
		[SerializeField]
		private Text _text;

		[SerializeField]
		private Slider _slider;

		public SkinnedMeshRenderer SkinnedMeshRenderer;

		private Animation _animation;

		public int BlendShapeIndex;

		private bool _ignoreValueChange;

		public string Text
		{
			get
			{
				return _text.text;
			}
			set
			{
				_text.text = value;
			}
		}

		public void OnValueChange(float value)
		{
			if (_ignoreValueChange)
			{
				_ignoreValueChange = false;
			}
			else
			{
				AssetLoaderWindow.Instance.HandleBlendEvent(SkinnedMeshRenderer, BlendShapeIndex, value);
			}
		}

		private void Start()
		{
			_animation = SkinnedMeshRenderer.GetComponentInParent<Animation>();
		}

		private void Update()
		{
			if (_animation == null)
			{
				return;
			}
			if (_animation.isPlaying)
			{
				if (_slider.interactable)
				{
					_slider.interactable = false;
				}
				_ignoreValueChange = true;
				_slider.value = SkinnedMeshRenderer.GetBlendShapeWeight(BlendShapeIndex);
			}
			else if (!_slider.interactable)
			{
				_slider.interactable = true;
			}
		}
	}
}
