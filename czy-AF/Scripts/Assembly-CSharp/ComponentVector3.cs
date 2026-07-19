using System;
using UnityEngine;
using UnityEngine.UI;

public class ComponentVector3 : MonoBehaviour
{
	public Vector3 data = Vector3.zero;

	public InputField inputX;

	public InputField inputY;

	public InputField inputZ;

	public void SetValue(string _vector)
	{
		_vector = _vector.Replace("(", "").Replace(")", "").Trim();
		string[] array = _vector.Split(',');
		if (array.Length == 3)
		{
			float x = float.Parse(array[0].Trim());
			float y = float.Parse(array[1].Trim());
			float z = float.Parse(array[2].Trim());
			SetVector(new Vector3(x, y, z));
		}
	}

	public void SetValue(Vector3 _vector)
	{
		SetVector(_vector);
	}

	public void SetVector(Vector3 v)
	{
		inputX.text = (Mathf.Round(v.x * 100f) / 100f).ToString();
		inputY.text = (Mathf.Round(v.y * 100f) / 100f).ToString();
		inputZ.text = (Mathf.Round(v.z * 100f) / 100f).ToString();
	}

	public void ValueChanged(Transform t)
	{
		data = ParseVector();
		GetComponent<ComponentBase>().Callback(base.name + "Change", data, t);
	}

	public void EndEdit(Transform t)
	{
		data = ParseVector();
		GetComponent<ComponentBase>().Callback(base.name + "Update", data, t);
	}

	public Vector3 ParseVector()
	{
		float x = data.x;
		float y = data.y;
		float z = data.z;
		try
		{
			x = Convert.ToSingle(inputX.text);
		}
		catch
		{
		}
		try
		{
			y = Convert.ToSingle(inputY.text);
		}
		catch
		{
		}
		try
		{
			z = Convert.ToSingle(inputZ.text);
		}
		catch
		{
		}
		return new Vector3(x, y, z);
	}
}
