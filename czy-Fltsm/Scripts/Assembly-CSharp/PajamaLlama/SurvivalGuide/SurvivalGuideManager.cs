using UnityEngine;
using UnityEngine.Serialization;

namespace PajamaLlama.SurvivalGuide
{
	public class SurvivalGuideManager : MonoBehaviour
	{
		[SerializeField]
		[FormerlySerializedAs("Properties")]
		private SurvivalGuideProperties _properties;

		[SerializeField]
		private SurvivalGuide[] _survivalGuides;

		public static SurvivalGuideProperties Properties { get; private set; }

		public void Initialize()
		{
			Properties = _properties;
			SurvivalGuide[] survivalGuides = _survivalGuides;
			for (int i = 0; i < survivalGuides.Length; i++)
			{
				survivalGuides[i].Initialize(_properties);
			}
		}
	}
}
