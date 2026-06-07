using UnityEngine;
using UnityEngine.UI;

namespace UMA.CharacterSystem
{
	public class DNAEditor : MonoBehaviour
	{
		private string _DNAName;

		private int _Index;

		private UMADnaBase _Owner;

		private DynamicCharacterAvatar _Avatar;

		private float _InitialValue;

		private DNARangeAsset _dnr;

		public Slider ValueSlider;

		public Text Label;

		private void Start()
		{
		}

		public void Initialize(string name, int index, UMADnaBase owner, DynamicCharacterAvatar avatar, float currentval)
		{
		}

		public void ChangeValue(float value)
		{
		}
	}
}
