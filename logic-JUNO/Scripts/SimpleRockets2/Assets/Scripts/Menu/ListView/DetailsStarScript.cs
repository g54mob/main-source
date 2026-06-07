using System;
using ModApi.Audio;
using TMPro;
using UI.Xml;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.ListView
{
	public class DetailsStarScript : DetailsWidgetBaseScript, IDetailsWidget
	{
		private bool _complete;

		private XmlElement _progressBar;

		private Image _progressFill;

		private XmlElement _progressFillElement;

		private TextMeshProUGUI _progressText;

		private TextMeshProUGUI _researchText;

		private XmlElement _star;

		private TextMeshProUGUI _starCount;

		private TextMeshProUGUI _text;

		public bool IsComplete
		{
			get
			{
				return _complete;
			}
			set
			{
				_complete = value;
				if (value)
				{
					_star.AddClass("star-complete");
				}
				else
				{
					_star.RemoveClass("star-complete");
				}
			}
		}

		public Action<DetailsStarScript> OnClick { get; set; }

		public string ResearchText
		{
			get
			{
				return _researchText.text;
			}
			set
			{
				_researchText.text = value;
			}
		}

		public string StarCountText
		{
			get
			{
				return _starCount.text;
			}
			set
			{
				_starCount.text = value;
			}
		}

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

		public override void Initialize(ListViewDetailsScript details)
		{
			_text = GetComponent<TextMeshProUGUI>();
			XmlElement component = GetComponent<XmlElement>();
			_star = component.GetElementByInternalId("star");
			_starCount = component.GetElementByInternalId<TextMeshProUGUI>("star-count");
			_researchText = component.GetElementByInternalId<TextMeshProUGUI>("research-text");
			_progressBar = component.GetElementByInternalId("progress-bar");
			_progressFillElement = component.GetElementByInternalId("milestone-progress-fill");
			_progressFill = _progressFillElement.GetComponent<Image>();
			_progressBar.SetActive(active: false);
			_progressText = component.GetElementByInternalId<TextMeshProUGUI>("subtitle");
			component.AddOnClickEvent(delegate
			{
				if (OnClick != null)
				{
					OnClick(this);
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.ButtonClicked);
				}
			});
		}

		public void SetProgressBar(float fill, string text, bool complete)
		{
			_progressBar.SetActive(active: true);
			_progressFill.fillAmount = fill;
			_progressText.text = text;
			if (complete)
			{
				_progressFillElement.AddClass("milestone-complete");
				_star.AddClass("milestone-complete");
			}
			else
			{
				_progressFillElement.RemoveClass("milestone-complete");
				_star.RemoveClass("milestone-complete");
			}
		}
	}
}
