using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LeaderboardRowElement : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _positionLabel;

		[SerializeField]
		private TMP_Text _hospitalNameLabel;

		[SerializeField]
		private TMP_Text _valueLabel;

		[SerializeField]
		private Image _hospitalIcon;

		[SerializeField]
		private Image _backing;

		[SerializeField]
		[FormerlySerializedAs("_hospitalIconSteam")]
		private Image _hospitalIconOnline;

		[SerializeField]
		private Image _hospitalStatusOnline;

		[SerializeField]
		private TooltipSpawner _hospitalTooltipOnline;

		[SerializeField]
		private Color _npcHospitalColour;

		[SerializeField]
		private Color _playerHospitalColour;

		[SerializeField]
		private Color _friendHospitalColour;

		[SerializeField]
		private Color _darkenAmount;

		private LeaderboardView.Hospital _cachedHospital;

		public void SetupForHospital(LeaderboardView.Hospital hospital, CareerStatsManager.Type type, int position)
		{
			_cachedHospital = hospital;
			if (_cachedHospital.ShouldUseOnlineAvatar())
			{
				Sprite avatar = OnlineManager.GetAvatar(_cachedHospital.HospitalDef.PlayerID);
				_cachedHospital.HospitalDef.AvatarIcon = avatar;
			}
			if (_positionLabel == null)
			{
				_hospitalNameLabel.text = $"{position}) {_cachedHospital.HospitalDef.FoundationName}";
			}
			else
			{
				_positionLabel.text = position.ToString();
				_hospitalNameLabel.text = _cachedHospital.HospitalDef.FoundationName;
			}
			switch (type)
			{
			case CareerStatsManager.Type.LevelHospitalValue:
			case CareerStatsManager.Type.LevelBalance:
			case CareerStatsManager.Type.LevelYearlyIncome:
			case CareerStatsManager.Type.TotalFoundationValue:
				_valueLabel.text = StringUtils.FormatCurrency(_cachedHospital.Value);
				break;
			case CareerStatsManager.Type.TotalSilverEarned:
				_valueLabel.text = StringUtils.FormatSilverCurrency(_cachedHospital.Value);
				break;
			case CareerStatsManager.Type.LevelCureRate:
			case CareerStatsManager.Type.LevelStaffMorale:
			case CareerStatsManager.Type.LevelReputation:
				_valueLabel.text = StringUtils.FormatPercentageValue((float)_cachedHospital.Value / 100f);
				break;
			default:
				_valueLabel.text = _cachedHospital.Value.ToString("N0");
				break;
			}
			RefreshAvatar();
			Color color = _npcHospitalColour;
			if (_cachedHospital.IsPlayer)
			{
				color = _playerHospitalColour;
			}
			else if (_cachedHospital.IsFriend)
			{
				color = _friendHospitalColour;
			}
			if (position % 2 == 1)
			{
				color -= _darkenAmount;
			}
			_backing.color = color;
		}

		private void OnDestroy()
		{
		}

		private void RefreshAvatar()
		{
			Sprite overrideSprite = null;
			if (_cachedHospital.HospitalDef.AvatarIcon != null)
			{
				overrideSprite = _cachedHospital.HospitalDef.AvatarIcon;
			}
			if (_cachedHospital.ShouldUseOnlineAvatar() && _hospitalIconOnline != null)
			{
				GameObjectUtils.SetActive(_hospitalIcon.gameObject, isActive: false);
				GameObjectUtils.SetActive(_hospitalIconOnline.gameObject, isActive: true);
				_hospitalIconOnline.color = Color.white;
				_hospitalIconOnline.overrideSprite = _cachedHospital.HospitalDef.AvatarIcon;
				_hospitalIconOnline.preserveAspect = true;
				_hospitalIconOnline.raycastTarget = true;
				if (_hospitalStatusOnline != null)
				{
					GameObjectUtils.SetActive(_hospitalStatusOnline.gameObject, _cachedHospital.IsOnline);
				}
				if (_hospitalTooltipOnline != null)
				{
					_hospitalTooltipOnline.TooltipText = $"{(_cachedHospital.IsOnline ? ScriptLocalization.Online.Status_Online_CS : ScriptLocalization.Online.Status_Offline_CS)}";
				}
			}
			else
			{
				GameObjectUtils.SetActive(_hospitalIcon.gameObject, isActive: true);
				_hospitalIcon.color = Color.white;
				_hospitalIcon.overrideSprite = overrideSprite;
				_hospitalIcon.preserveAspect = true;
				if (_hospitalIconOnline != null)
				{
					GameObjectUtils.SetActive(_hospitalIconOnline.gameObject, isActive: false);
				}
			}
		}

		public void ShowPlayerProfile()
		{
			if (_cachedHospital.IsFriend)
			{
				OnlineManager.ShowUserProfile(_cachedHospital.HospitalDef.PlayerID);
			}
		}
	}
}
