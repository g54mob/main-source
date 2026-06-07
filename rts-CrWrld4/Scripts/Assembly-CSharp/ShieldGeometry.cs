using UnityEngine;

public class ShieldGeometry : MonoBehaviour
{
	public Color32 defaultColor;

	public Color32 damagedColor;

	public Color32 damagedGoneColor;

	public Color32 _color;

	private const int DAMAGE_PULSE_TIME = 60;

	private int pulseCounter;

	public Color32 color
	{
		get
		{
			return default(Color32);
		}
		set
		{
		}
	}

	public void Awake()
	{
	}

	public void TurnOn()
	{
	}

	public void Update()
	{
	}

	public void Damage()
	{
	}

	private void SetColor(Color32 color)
	{
	}

	private void SetColor(Color32 color, Mesh m)
	{
	}
}
