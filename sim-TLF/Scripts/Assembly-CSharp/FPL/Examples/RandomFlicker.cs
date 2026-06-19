using UnityEngine;

namespace FPL.Examples
{
	public class RandomFlicker : MonoBehaviour
	{
		[SerializeField]
		private bool refresh;

		private void Start()
		{
			SetRandomFlickering();
		}

		private void Update()
		{
			if (refresh)
			{
				refresh = false;
				SetRandomFlickering();
			}
		}

		private void SetRandomFlickering()
		{
			FPL_Controller[] componentsInChildren = GetComponentsInChildren<FPL_Controller>();
			foreach (FPL_Controller fPL_Controller in componentsInChildren)
			{
				if (!(fPL_Controller == null))
				{
					fPL_Controller.SetProperty(FPL_Properties._RandomOffset, Random.value * 5f);
					fPL_Controller.SetProperty(FPL_Properties._FlickerSpeed, Random.value * 2f);
				}
			}
		}
	}
}
