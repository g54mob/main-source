using ModApi.Audio;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Career.Research.UI
{
	public class BlockScript : MonoBehaviour
	{
		public delegate void BlockScriptDelegate(BlockScript block);

		private bool _hover;

		private float _hoverTime;

		public AudioFile ClickSound { get; set; } = AudioLibrary.ButtonClicked;

		public AudioFile HoverSound { get; set; } = AudioLibrary.Vizzy.SuggestConnection;

		protected TechTreeUIScript TechTreeUI => GetComponentInParent<TechTreeUIScript>();

		public event BlockScriptDelegate BeginHover;

		public event BlockScriptDelegate Clicked;

		public event BlockScriptDelegate EndHover;

		public virtual void OnClicked()
		{
			this.Clicked?.Invoke(this);
			TechTreeUI?.PlaySound(ClickSound);
		}

		public virtual void OnHover(bool hover)
		{
			if (_hover == hover)
			{
				return;
			}
			_hover = hover;
			if (_hover)
			{
				this.BeginHover?.Invoke(this);
				if (_hoverTime + 0.5f < Time.unscaledTime)
				{
					TechTreeUI?.PlaySound(HoverSound);
				}
				_hoverTime = Time.unscaledTime;
			}
			else
			{
				this.EndHover?.Invoke(this);
			}
		}

		public void SetText(string text)
		{
			TextMeshPro componentInChildren = GetComponentInChildren<TextMeshPro>();
			if (componentInChildren != null)
			{
				componentInChildren.text = text;
			}
		}
	}
}
