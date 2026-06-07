using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UMA.Examples
{
	public class ClothAccelerationPanelScript : MonoBehaviour
	{
		public DynamicCharacterAvatar avatar;

		public Slider xSlider;

		public Slider ySlider;

		public Slider zSlider;

		private Cloth m_Cloth;

		private Vector3 acceleration;

		public void UpdateClothAcceleration()
		{
		}
	}
}
