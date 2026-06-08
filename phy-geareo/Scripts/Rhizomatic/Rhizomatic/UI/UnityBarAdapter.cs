using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class UnityBarAdapter : MonoBehaviour, IBar
	{
		public Slider component;

		public float progress
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}
	}
}
