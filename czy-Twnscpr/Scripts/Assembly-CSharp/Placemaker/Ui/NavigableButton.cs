using System;
using UnityEngine;

namespace Placemaker.Ui
{
	public class NavigableButton : MonoBehaviour, UiMaster.IUiSetup
	{
		public BaseButton baseButton;

		public Action onSubmit;

		public UpdateState selectedState;

		public Action onSelectedUpdate;

		public Action<int, float> onHorizontal;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		public void OnSelectedUpdate()
		{
		}

		public void OnHorizontal(int step, float axis)
		{
		}

		public void OnSubmit()
		{
		}
	}
}
