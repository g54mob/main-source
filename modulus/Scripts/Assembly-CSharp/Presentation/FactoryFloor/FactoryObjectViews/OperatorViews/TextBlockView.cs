using Data.FactoryFloor.FactoryObjectBehaviours;
using SaveData.FactoryFloor.SaveStates;
using TMPro;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class TextBlockView : FactoryBehaviorView<TextBlockBehaviour>
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		[LocaKey]
		private string _defaultTextLocKey = "TextBlock.DefaultText";

		[SerializeField]
		private Color _textColour = Color.white;

		[SerializeField]
		private Color _defaultTextColour = new Color(1f, 1f, 1f, 0.5f);

		protected override void Init()
		{
			base.Init();
			_behaviour.OnConfigurationChanged.RegisterMainThread(RebuildUI);
			RebuildUI(_behaviour.Configuration);
		}

		protected override void ResetFactoryObject()
		{
			if (_behaviour != null)
			{
				_behaviour.OnConfigurationChanged.UnRegisterMainThread(RebuildUI);
			}
			base.ResetFactoryObject();
			_text.SetText(string.Empty);
		}

		private void RebuildUI(TextBlockBehaviourConfigurationDto config)
		{
			_text.alignment = config.Alignment;
			if (!string.IsNullOrEmpty(config.Text))
			{
				_text.SetText(config.Text);
				_text.color = _textColour;
			}
			else
			{
				_text.SetText(LocalizationUtility.GetLocalizedText(_defaultTextLocKey));
				_text.color = _defaultTextColour;
			}
		}
	}
}
