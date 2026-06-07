using Simulation;
using Unity.Burst;

public class ST7735Element : SPIElement
{
	public ST7735Display st;

	public double VIN_MAX;

	public double VIN_MIN;

	public double SINK_MAX;

	public double SOURCE_MAX;

	public double V_HL;

	public double V_LL;

	private const int GND = 0;

	private const int VCC = 1;

	private const int SCL = 2;

	private const int SDA = 3;

	private const int RES = 4;

	private const int DC = 5;

	private const int CS = 6;

	private const int BL = 7;

	protected Pin[] pins;

	private byte commandByte;

	public byte[] dataBuffer;

	private int dataBufferAddress;

	private int bit;

	public override string GetName()
	{
		return null;
	}

	public void setupPins()
	{
	}

	public override void Reset()
	{
	}

	public override int GetLeadCount()
	{
		return 0;
	}

	public override void MatrixInitialise()
	{
	}

	private void ClearData()
	{
	}

	public override void SlaveReceive(byte val)
	{
	}

	public override void CheckFail()
	{
	}

	[BurstCompile(FloatMode = FloatMode.Fast)]
	public override void Step()
	{
	}
}
