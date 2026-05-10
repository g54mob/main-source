using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Horizontal Selector", 20006)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/horizontal-selector")]
	public class HorizontalSelector : MonoBehaviour
	{
		[Tooltip("The 3D text used to show the current value")]
		public Modular3DText text;

		[Tooltip("If keyboard control is enabled, selected = you can control via selected. \nThis value will be controlled by list, if it is in one")]
		public bool focused;

		[Tooltip("If keyboard control is enabled, selected = you can control via selected\nOr selected/deselected in a List")]
		public bool interactable;

		[Tooltip("Available options for horizontal selector. \nVariable name: options")]
		public List<string> options;

		public AudioClip valueChangeSoundEffect;

		public AudioSource audioSource;

		public UnityEvent onSelectEvent;

		[Tooltip("The new value is passed as dynamic value")]
		public UnityEvent<int> onValueChangedEvent;

		public UnityEvent onValueIncreasedEvent;

		public UnityEvent onValueDecreasedEvent;

		[Tooltip("This is to avoid key presses changing values too fast.")]
		public bool limitFastValueChanges;

		public float valueChangeMinDelay;

		private float nextValidValueChangeTime;

		[SerializeField]
		[FormerlySerializedAs("value")]
		private int _value;

		public int Value
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Increase()
		{
		}

		public void Decrease()
		{
		}

		private int ValidValue(int newValue)
		{
			return 0;
		}

		public void UpdateText()
		{
		}

		public void Focus(bool enable)
		{
		}

		private bool ValidTime()
		{
			return false;
		}
	}
}
