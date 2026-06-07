using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class WorhkshopGridManager : MonoBehaviour
	{
		public Camera Cam;

		public DisplayGrid SmallGrid;

		public DisplayGrid LargeGrid;

		public AnimationCurve SmallGridAlphaCurve;

		public void SetGridColor(Color color)
		{
			SmallGrid.SetColor(color);
			LargeGrid.SetColor(color);
		}

		public void Update()
		{
			float alpha = 1f - SmallGridAlphaCurve.Evaluate(Cam.orthographicSize / 70f);
			LargeGrid.Alpha = 1f;
			SmallGrid.Alpha = alpha;
		}
	}
}
