using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Generic
{
	public class NamedSlider : MonoBehaviour
	{
		[SerializeField]
		private Slider m_slider;

		[SerializeField]
		private TextMeshProUGUI m_title;

		[SerializeField]
		private TextMeshProUGUI m_value;

		public bool pum
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public event Action<float> pul
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void dvs(float a, float b, float c)
		{
		}

		public void dvt(string a)
		{
		}

		private void Awake()
		{
		}

		private void dvu(float a)
		{
		}

		private void dvv(float a)
		{
		}
	}
}
