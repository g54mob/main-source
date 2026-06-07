using UnityEngine.Experimental.Rendering.Universal;

public class MultitoolPrinter : Printer
{
	public Light2D destroyLight;

	public float destroyLightSpeed;

	public FloatRange destroyLightIntensity;

	public float destroyLightPulsePow;

	private float destroyLightStartTime;

	private bool destroyLightEnabled;

	private float destroyLightON;

	private float destroyLightONvel;

	private void Awake()
	{
	}

	protected override void OnPrintComplete(bool result)
	{
	}

	public void OnMultitoolOpen()
	{
	}

	public void OnMultitoolClose()
	{
	}

	public void SetDestroyLight(bool enabled)
	{
	}

	protected override void Update()
	{
	}
}
