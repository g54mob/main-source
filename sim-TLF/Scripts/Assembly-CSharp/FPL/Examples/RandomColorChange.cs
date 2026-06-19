using UnityEngine;

namespace FPL.Examples
{
	public class RandomColorChange : MonoBehaviour
	{
		[SerializeField]
		private FPL_Controller fplController;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space) && !(fplController == null))
			{
				Color color = Random.ColorHSV() * Random.Range(1, 3);
				color.a = 1f;
				fplController.SetProperty(FPL_Properties._LightTint, color);
				fplController.SetProperty(FPL_Properties._HaloTint, color * 3f);
			}
		}
	}
}
