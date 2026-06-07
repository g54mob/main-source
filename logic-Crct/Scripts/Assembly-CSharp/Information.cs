using UnityEngine;
using UnityEngine.UI;

public class Information : MonoBehaviour
{
	[Header("Main")]
	public GameObject mainObject;

	public Text heading;

	[Header("Breadboard")]
	public GameObject breadboardObject;

	public string breadboardHeading;

	[Header("Label")]
	public GameObject labelObject;

	public string labelHeading;

	[Header("Jumper Wire")]
	public GameObject wireObject;

	public string wireHeading;

	[Header("Resistor")]
	public GameObject resObject;

	public string resHeading;

	[Header("Buzzer")]
	public GameObject buzObject;

	public string buzHeading;

	[Header("Diode")]
	public GameObject dioObject;

	public string dioHeading;

	[Header("Zener")]
	public GameObject zenObject;

	public string zenHeading;

	[Header("Zener")]
	public GameObject trObject;

	public string trHeading;

	[Header("Capacitor")]
	public GameObject capObject;

	public string capHeading;

	[Header("Inductor")]
	public GameObject indObject;

	public string indHeading;

	[Header("Tactile Switch")]
	public GameObject tsObject;

	public string tsHeading;

	[Header("Slide Switch")]
	public GameObject ssObject;

	public string ssHeading;

	[Header("DIP Switch")]
	public GameObject dipObject;

	public string dipHeading;

	[Header("Potentiometer")]
	public GameObject potObject;

	public string potHeading;

	[Header("LED")]
	public GameObject ledObject;

	public string ledHeading;

	[Header("Seven Segment Display")]
	public GameObject segObject;

	public string segHeading;

	[Header("DC 12V Power")]
	public GameObject dc12Object;

	public string dc12Heading;

	[Header("LM555")]
	public GameObject lm555Object;

	public string lm555Heading;

	[Header("74HC Series")]
	public GameObject[] _74HCObjects;

	public string[] _74HCHeadings;

	[Header("HD44780")]
	public GameObject lcdObject;

	public string lcdHeading;

	private void Awake()
	{
	}

	private void Clear()
	{
	}

	public void CloseInformation()
	{
	}

	public void OpenBreadboard()
	{
	}

	public void OpenLabel()
	{
	}

	public void OpenJumperWire()
	{
	}

	public void OpenResistor()
	{
	}

	public void OpenBuzzer()
	{
	}

	public void OpenDiode()
	{
	}

	public void OpenZener()
	{
	}

	public void OpenTransistor()
	{
	}

	public void OpenCapacitor()
	{
	}

	public void OpenInductor()
	{
	}

	public void OpenTactileSwitch()
	{
	}

	public void OpenSlideSwitch()
	{
	}

	public void OpenDIPSwitch()
	{
	}

	public void OpenPotentiometer()
	{
	}

	public void OpenLED()
	{
	}

	public void Open7Seg()
	{
	}

	public void OpenDC12()
	{
	}

	public void OpenLM555()
	{
	}

	public void Open74HC(int i)
	{
	}

	public void OpenLCD()
	{
	}
}
