using UnityEngine;
using UnityEngine.UI;

public class Properties : MonoBehaviour
{
	[Header("Base")]
	public GameObject mainGameObject;

	public Transform containerBox;

	public Text headingText;

	[Header("Resistor")]
	public GameObject resistorOhms;

	public GameObject resistorPower;

	[Header("Capacitor")]
	public GameObject capacitorFarads;

	public GameObject capacitorUnit;

	public GameObject capacitorType;

	[Header("Transistor")]
	public GameObject trBeta;

	public GameObject trType;

	[Header("LED")]
	public GameObject ledForwardVoltage;

	public GameObject ledMaxCurrent;

	[Header("Diode")]
	public GameObject diodeForwardVoltage;

	public GameObject diodeMaxCurrent;

	public GameObject diodeLeakage;

	[Header("Zener")]
	public GameObject zenZVoltage;

	[Header("7 Seg Display")]
	public GameObject segForwardVoltage;

	public GameObject segMaxCurrent;

	public GameObject segType;

	[Header("Potentiometer")]
	public GameObject potMaxOhms;

	[Header("Inductor")]
	public GameObject inductance;

	[Header("Label")]
	public GameObject labelText;

	private static Properties inst { get; set; }

	private void Awake()
	{
	}

	public static void Close()
	{
	}

	public static void Resistor()
	{
	}

	public static void Capacitor()
	{
	}

	public static void Transistor()
	{
	}

	public static void LED()
	{
	}

	public static void Diode()
	{
	}

	public static void Zener()
	{
	}

	public static void SevenSegmentDisplay()
	{
	}

	public static void Potentiometer()
	{
	}

	public static void Inductor()
	{
	}

	public static void Label()
	{
	}
}
