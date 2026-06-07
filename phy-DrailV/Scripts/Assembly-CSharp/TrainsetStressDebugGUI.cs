using System.Collections.Generic;
using DV.ThingTypes;
using UnityEngine;

public class TrainsetStressDebugGUI : MonoBehaviour
{
	private TrainCar _car;

	private Rect windowRect = new Rect(300f, Screen.height - 150, 37f, 200f);

	private const float WIDTH = 37f;

	private const float TESTNUM = 1f;

	private const float WINDOW_HEIGHT = 200f;

	private const float MARGIN = 5f;

	private int carCount;

	private TrainCar car
	{
		get
		{
			if (!_car)
			{
				_car = GetComponent<TrainCar>();
			}
			return _car;
		}
	}

	private void OnGUI()
	{
		if (!car)
		{
			base.enabled = false;
			return;
		}
		windowRect.width = 84f * (float)carCount;
		GUI.skin = DVGUI.skin;
		windowRect = GUI.Window(3, windowRect, Window, "TrainSet Stress Debug");
	}

	private void Window(int id)
	{
		List<TrainCar> cars = car.trainset.cars;
		carCount = cars.Count;
		for (int i = 0; i < carCount; i++)
		{
			string text = cars[i].name;
			bool num = CarTypes.IsLocomotive(cars[i].carLivery);
			float num2 = 10f + (float)(i * cars[i].Bogies.Length) * 42f;
			Color textColor = GUI.skin.label.normal.textColor;
			GUI.skin.label.wordWrap = false;
			if (num)
			{
				GUI.skin.label.normal.textColor = Color.yellow;
			}
			GUI.Label(new Rect(num2, 25f, 67f, 20f), text);
			GUI.skin.label.wordWrap = true;
			GUI.skin.label.normal.textColor = textColor;
			for (int j = 0; j < cars[i].Bogies.Length; j++)
			{
				Bogie obj = cars[i].Bogies[j];
				float num3 = num2 + (float)(35 * j);
				float num4 = 45f;
				if (obj.HasDerailed)
				{
					GUI.skin.label.normal.textColor = Color.red;
				}
				GUI.Label(new Rect(num3 + 10f, num4, 100f, 20f), (j == 0) ? "F" : "R");
				if (obj.HasDerailed)
				{
					GUI.skin.label.normal.textColor = textColor;
				}
				num4 += 20f;
				float stress = cars[i].stress.stress;
				GUI.VerticalSlider(new Rect(num3, num4, 15f, 120f), 1f - stress, 0f, 1f);
				GUI.VerticalSlider(new Rect(num3 + 15f, num4, 15f, 120f), 2f - stress, 0f, 2f);
			}
		}
		GUI.DragWindow();
	}
}
