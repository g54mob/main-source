using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
	public class DebugUnitButton : MonoBehaviour
	{
		[SerializeField]
		private Slider secondPerUnitSlider;

		[SerializeField]
		private Text secondPerUnitText;

		public eLuggage luggage;

		public string tmpLuggageStr;

		private float secondPerUnit;

		private double autoUnitCounter;

		private const string _luggageTextureBaseAddress = "Assets/Textures/Factory/Luggage/";

		public void OnCreateUnit()
		{
		}

		public void ChangeSecondPerUnit()
		{
		}

		public void OnDebugUnlockUnit()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
