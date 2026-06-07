using System;
using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class ShowTagPopup : MonoBehaviour
	{
		public UILabel Label;

		public UITexture Background;

		public Color AssignedColor;

		public Color UnassignedColor;

		private string _currentTag;

		private bool _unknownCode;

		public event Action<string> TagChanged;

		public void Init(string startTag, bool unknownCode)
		{
			_currentTag = startTag;
			_unknownCode = unknownCode;
			UpdateText();
		}

		public void OnClick()
		{
			StartCoroutine(ShowPopup());
		}

		public void UpdateText()
		{
			if (_unknownCode)
			{
				Background.color = UnassignedColor;
				Label.text = "?";
			}
			else if (string.IsNullOrEmpty(_currentTag))
			{
				Background.color = UnassignedColor;
				Label.text = LocalizationManager.GetTermTranslation("DroneWorkshop/AddTag");
			}
			else
			{
				Background.color = AssignedColor;
				Label.text = _currentTag;
			}
		}

		private IEnumerator ShowPopup()
		{
			yield return StartCoroutine(TagInputPopup.Instance.Show(_currentTag));
			if (TagInputPopup.Instance.TagRemoved && _currentTag != "")
			{
				Action<string> action = this.TagChanged;
				if (action != null)
				{
					action("");
				}
				_unknownCode = false;
				_currentTag = "";
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.AddStringBinding);
			}
			if (TagInputPopup.Instance.TagSaved)
			{
				string text = TagInputPopup.Instance.TagText.ToUpper();
				Action<string> action2 = this.TagChanged;
				if (action2 != null)
				{
					action2(text);
				}
				_unknownCode = false;
				_currentTag = text;
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.AddStringBinding);
			}
			UpdateText();
		}
	}
}
