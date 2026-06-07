using Assets.Behaviour.UI;
using Assets.Source.World.Frames;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1IronIngotSecret : MonoBehaviour
	{
		[SerializeField]
		private SecretButtonSlider _secretSlider;

		[SerializeField]
		private Interactable _secretInteractable;

		private ActiveWorldFrame _frame;

		private void Start()
		{
			_frame = GetComponent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (_frame.ActiveFrame != null)
			{
				bool isSmelting = ((T1IronIngot)_frame.ActiveFrame).IsSmelting;
				_secretSlider.enabled = isSmelting;
				_secretInteractable.enabled = isSmelting;
			}
		}
	}
}
