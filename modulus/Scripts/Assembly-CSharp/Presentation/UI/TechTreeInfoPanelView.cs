using System.Linq;
using Data.Buildings;
using Data.TechTree.Behaviours;
using Events;
using Events.UI;
using Presentation.FactoryFloor.Toolbar;
using TMPro;
using UnityEngine;

namespace Presentation.UI
{
	public class TechTreeInfoPanelView : InfoPanelView
	{
		[SerializeField]
		private ShowTechTreeInfoPanelEvent _showInfoPanelEvent;

		[SerializeField]
		private UpdateInfoPanelEvent _updateInfoPanelEvent;

		[SerializeField]
		private BaseEvent _hideInfoPanelEvent;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private GameObject _notEnoughDataShardsWarning;

		[SerializeField]
		private GameObject _notEnoughRankWarning;

		[SerializeField]
		private GameObject _ingoingConnectionsLockedWarning;

		[SerializeField]
		private SpeedInfo _speedInfo;

		private TechTreeInfoPanelDto _techTreeInfoPanelDto;

		protected override void Awake()
		{
			base.gameObject.SetActive(value: false);
			_showInfoPanelEvent.Register(base.Show);
			_hideInfoPanelEvent.Register(Hide);
			_updateInfoPanelEvent.Register(UpdateWarnings);
		}

		protected override void OnDestroy()
		{
			_showInfoPanelEvent.UnRegister(base.Show);
			_hideInfoPanelEvent.UnRegister(Hide);
			_updateInfoPanelEvent.UnRegister(UpdateWarnings);
		}

		protected override void SetContent(InfoPanelDto dto)
		{
			_techTreeInfoPanelDto = dto as TechTreeInfoPanelDto;
			_titleText.SetText(_techTreeInfoPanelDto.Title);
			_text.SetText(_techTreeInfoPanelDto.Text);
			_notEnoughDataShardsWarning.SetActive(!_techTreeInfoPanelDto.HasEnoughDataShards);
			_notEnoughRankWarning.SetActive(!_techTreeInfoPanelDto.HasEnoughRank);
			_ingoingConnectionsLockedWarning.SetActive(!_techTreeInfoPanelDto.HasAllIncomingNodesUnlocked);
			_speedInfo.gameObject.SetActive(value: false);
			if (_techTreeInfoPanelDto.NodeBehaviours.OfType<UnlockFactoryObjectBehavior>().Count() > 1)
			{
				return;
			}
			for (int i = 0; i < _techTreeInfoPanelDto.NodeBehaviours.Count; i++)
			{
				if (_techTreeInfoPanelDto.NodeBehaviours[i] is UpdateFactoryObjectFrequencyBehavior)
				{
					UpdateFactoryObjectFrequencyBehavior updateFactoryObjectFrequencyBehavior = _techTreeInfoPanelDto.NodeBehaviours[i] as UpdateFactoryObjectFrequencyBehavior;
					if (updateFactoryObjectFrequencyBehavior.FactoryObjectUIData != null)
					{
						_speedInfo.SetSpeedsFromNode(updateFactoryObjectFrequencyBehavior.FactoryObjectUIData, updateFactoryObjectFrequencyBehavior.NewTotalValue);
						_speedInfo.gameObject.SetActive(value: true);
					}
					break;
				}
				if (_techTreeInfoPanelDto.NodeBehaviours[i] is UnlockFactoryObjectBehavior)
				{
					UnlockFactoryObjectBehavior unlockFactoryObjectBehavior = _techTreeInfoPanelDto.NodeBehaviours[i] as UnlockFactoryObjectBehavior;
					if (unlockFactoryObjectBehavior.FactoryObjectDatas.Count == 1 && unlockFactoryObjectBehavior.FactoryObjectDatas[0] != null && !(unlockFactoryObjectBehavior.FactoryObjectDatas[0] is BuildingObjectData) && unlockFactoryObjectBehavior.FactoryObjectDatas[0].UIData != null)
					{
						_speedInfo.SetSpeedsFromUIData(unlockFactoryObjectBehavior.FactoryObjectDatas[0].UIData);
						_speedInfo.gameObject.SetActive(value: true);
					}
					break;
				}
			}
		}

		private void UpdateWarnings(InfoPanelDto dto)
		{
			_techTreeInfoPanelDto = dto as TechTreeInfoPanelDto;
			_notEnoughDataShardsWarning.SetActive(!_techTreeInfoPanelDto.HasEnoughDataShards);
			_notEnoughRankWarning.SetActive(!_techTreeInfoPanelDto.HasEnoughRank);
			_ingoingConnectionsLockedWarning.SetActive(!_techTreeInfoPanelDto.HasAllIncomingNodesUnlocked);
			_titleText.gameObject.SetActive(_techTreeInfoPanelDto.ShowTitle);
		}
	}
}
