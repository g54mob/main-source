using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class MinigameSubSwitcher3D : MonoBehaviour
	{
		[Header("Sub-Buttons")]
		[Tooltip("Button3D instances — one per sub-panel (e.g. '1' and '2')")]
		[SerializeField]
		private Button3D[] subButtons;

		[Tooltip("TabButton3D visuals — parallel with subButtons")]
		[SerializeField]
		private TabButton3D[] subVisuals;

		[Header("Panels")]
		[Tooltip("Sub-panel root GameObjects — toggled via SetActive")]
		[SerializeField]
		private GameObject[] subPanels;

		private int activeIndex;

		public int ActiveIndex => 0;

		public event Action<int> OnSubSwitched
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

		private void Start()
		{
		}

		public void SwitchTo(int index)
		{
		}
	}
}
