using System;
using UnityEngine;
using UnityEngine.UI;

public class NumberRangeWindow : MonoBehaviour
{
	public InputField FromField;

	public InputField ToField;

	public GUIWindow Window;

	public Action<double, double> WhenDone;

	public void Show(float from, float to, Action<float, float> action)
	{
		Show(from, to, delegate(double a, double b)
		{
			action((float)a, (float)b);
		});
	}

	public void Show(double from, double to, Action<double, double> action)
	{
		Window.Show();
		FromField.text = from.ToString("#,0.##");
		ToField.text = to.ToString("#,0.##");
		WhenDone = action;
	}

	public void ClickOK()
	{
		bool flag = true;
		double arg = 0.0;
		double arg2 = 0.0;
		try
		{
			arg = Convert.ToDouble(FromField.text.Replace(",", ""));
			arg2 = Convert.ToDouble(ToField.text.Replace(",", ""));
		}
		catch (Exception)
		{
			flag = false;
		}
		if (flag)
		{
			WhenDone(arg, arg2);
		}
		Window.Close();
	}
}
