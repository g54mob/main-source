using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Staging
{
	public class ActivationTypeIcons
	{
		private static Dictionary<StageActivationType, Sprite> _icons = new Dictionary<StageActivationType, Sprite>();

		public static Sprite GetActivationIcon(StageActivationType stageActivationType)
		{
			Sprite value = null;
			if (!_icons.TryGetValue(stageActivationType, out value))
			{
				value = LoadIcon(stageActivationType);
				_icons[stageActivationType] = value;
			}
			return value;
		}

		private static Sprite LoadIcon(StageActivationType stageActivationType)
		{
			string text = string.Empty;
			switch (stageActivationType)
			{
			case StageActivationType.Detacher:
				text = "IconStagingInterstage";
				break;
			case StageActivationType.Engine:
				text = "IconStagingEngine";
				break;
			case StageActivationType.Fairing:
				text = "IconStagingFairing";
				break;
			case StageActivationType.LandingLeg:
				text = "IconStagingLandingLeg";
				break;
			case StageActivationType.Parachute:
				text = "IconStagingParachute";
				break;
			case StageActivationType.Payload:
				text = "IconStagingPayload";
				break;
			}
			return Game.Instance.ResourceLoader.Load<Sprite>("Ui/Sprites/Common/" + text);
		}
	}
}
