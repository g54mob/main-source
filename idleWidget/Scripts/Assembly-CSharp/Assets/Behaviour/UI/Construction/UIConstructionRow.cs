using Assets.Source.Player;
using Assets.Source.UI;
using Assets.Source.Util;
using Assets.Source.World;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviour.UI.Construction
{
	public class UIConstructionRow : MonoBehaviour, ITooltipTitleSource, ITooltipCustomSource, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private Button _prioritize;

		private bool _completed;

		public ConstructionProgress Contained { get; private set; }

		public void SetConstruction(ConstructionProgress progress)
		{
			Contained = progress;
			_icon.sprite = progress.Icon;
			UpdateLabel();
		}

		public void UpdateLabel(string text = null)
		{
			if (!_completed)
			{
				_name.text = Contained.Name + "\n" + (text ?? ("Progress: " + UIHelper.HighlightText(GameMath.FormatPercentage(Contained.MaterialProgress))));
			}
		}

		public string GetTooltipTitle()
		{
			return Contained.Name;
		}

		public void AddTooltipCustomContent(UITooltip tooltip)
		{
			if (_completed)
			{
				tooltip.AddTextLine(UIHelper.HighlightText("Right-click") + " to clear.");
				return;
			}
			tooltip.AddTextLine(UIHelper.HighlightText("Right-click") + " to cancel.");
			tooltip.AddConstructionLines(Contained);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				PlayerControls.RightClickUtilized = true;
				if (_completed)
				{
					UISounds.CraftStep();
					GetComponentInParent<ConstructionUI>().ConstructionRemoved(Contained);
				}
				else
				{
					Contained.Cancel();
				}
			}
		}

		public void SetCompleted()
		{
			_background.color = new Color(0f, 0.5f, 0f, 0.2f);
			UpdateLabel("Construction completed!");
			_completed = true;
			_prioritize.gameObject.SetActive(value: false);
		}

		public void MoveConstructionUp()
		{
			UISounds.Button();
			GamePlayer.Current.PrioritizeConstruction(Contained);
			GetComponentInParent<ConstructionUI>().PrioritizeConstruction(this);
		}
	}
}
