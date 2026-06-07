using Assets.Nimbatus.GUI.Common.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects
{
	public class DroneEffectSetting : SerializedScriptableObject
	{
		public bool UseInCreative;

		public DroneEffect Effect;

		public Texture2D Icon;

		public TranslationTerm Description;
	}
}
