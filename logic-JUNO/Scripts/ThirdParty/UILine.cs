using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class UILine : MonoBehaviour
{
	protected bool _bDirty = true;

	protected Vector2 vecStartPoint;

	protected Vector2 vecEndPoint;

	public float _fLineThickness;

	protected Graphic TargetGraphic => GetComponent<Graphic>();

	public Vector2 StartPoint
	{
		get
		{
			return vecStartPoint;
		}
		set
		{
			if (value != vecStartPoint)
			{
				_bDirty = true;
				vecStartPoint = value;
			}
		}
	}

	public Vector2 EndPoint
	{
		get
		{
			return vecEndPoint;
		}
		set
		{
			if (value != vecEndPoint)
			{
				_bDirty = true;
				vecEndPoint = value;
			}
		}
	}

	private void OnGUI()
	{
		if (_bDirty)
		{
			_bDirty = false;
			Posittionline();
		}
	}

	public void Posittionline()
	{
		float magnitude = (StartPoint - EndPoint).magnitude;
		Vector2 vector = (StartPoint + EndPoint) * 0.5f;
		float angle = Mathf.Atan((EndPoint.y - StartPoint.y) / (EndPoint.x - StartPoint.x)) * 57.29578f;
		Debug.Log("Line Rotation " + angle + " Rise " + (EndPoint.y - StartPoint.y) + " Run " + (EndPoint.x - StartPoint.x));
		TargetGraphic.rectTransform.localScale = new Vector3(magnitude + _fLineThickness, _fLineThickness, 1f);
		TargetGraphic.rectTransform.localRotation = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
		TargetGraphic.rectTransform.localPosition = vector;
	}
}
