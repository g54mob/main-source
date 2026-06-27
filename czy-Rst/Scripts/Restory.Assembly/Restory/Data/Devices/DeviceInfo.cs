using System.Collections.Generic;
using Restory.Data.Base;
using Restory.Data.Elements;
using Restory.Data.Licenses;
using Restory.Data.Localization;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Data.Devices
{
	[CreateAssetMenu(menuName = "Restory/Devices/DeviceInfo", fileName = "Name - DeviceInfo")]
	public class DeviceInfo : RestoryEntityInfoBase, IDeviceInfo
	{
		[SerializeField]
		[LocalizationKey]
		private string nameLocalizationKey;

		[SerializeField]
		private LicenseInfo license;

		[SerializeField]
		[Min(1f)]
		private int defaultPrice = 1;

		[SerializeField]
		private DeviceCategory category;

		[SerializeField]
		private DeviceContainer prefab;

		[SerializeField]
		private List<ElementInfo> elements = new List<ElementInfo>();

		[SerializeField]
		private Vector2Int generatedDirtMaskTextureSize = new Vector2Int(1024, 1024);

		[SerializeField]
		private Vector2Int paintTextureSize = new Vector2Int(1024, 1024);

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private float paintingBrushSizeMultiplier = 1f;

		[SerializeField]
		private bool hackable;

		[SerializeField]
		private bool useBigBackgroundForGeneratedShopLots;

		[SerializeField]
		private int competitionParticipationPrice;

		[SerializeField]
		private int competitionReward;

		[SerializeField]
		private int competitionDefaultBestTimeHours;

		[SerializeField]
		private int competitionDefaultBestTimeMinutes;

		[SerializeField]
		private int competitionDefaultBestTimeSeconds;

		private int competitionDefaultBestTimeInGameSeconds = -1;

		public InteractiveObject Prefab => prefab;

		public string NameLocalizationKey => nameLocalizationKey;

		public LicenseInfo License => license;

		public int DefaultPrice => defaultPrice;

		public IDeviceCategory Category => category;

		public IReadOnlyCollection<IElementInfo> Elements => elements;

		public IReadOnlyCollection<ElementSocket> Sockets => prefab.Device.ElementSockets;

		public Vector2Int GeneratedDirtMaskTextureSize => generatedDirtMaskTextureSize;

		public Vector2Int PaintTextureSize => paintTextureSize;

		public float PaintingBrushSizeMultiplier => paintingBrushSizeMultiplier;

		public Color DefaultColor => defaultColor;

		public bool Hackable => hackable;

		public bool UseBigBackgroundForGeneratedShopLots => useBigBackgroundForGeneratedShopLots;

		public int CompetitionParticipationPrice => competitionParticipationPrice;

		public int CompetitionReward => competitionReward;

		public int CompetitionDefaultBestTimeInGameSeconds
		{
			get
			{
				if (competitionDefaultBestTimeInGameSeconds < 0)
				{
					competitionDefaultBestTimeInGameSeconds = competitionDefaultBestTimeSeconds + competitionDefaultBestTimeMinutes * 60 + competitionDefaultBestTimeHours * 3600;
				}
				return competitionDefaultBestTimeInGameSeconds;
			}
		}
	}
}
