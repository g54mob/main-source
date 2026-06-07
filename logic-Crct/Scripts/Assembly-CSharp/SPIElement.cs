using System.Collections.Generic;
using Simulation;

public class SPIElement : CircuitModel
{
	public bool SPIMaster;

	public int SCK;

	public int MOSI;

	public int MISO;

	public int SS;

	public int SDI;

	public int SDO;

	public bool hasCLK;

	public bool hasMOSI;

	public bool hasMISO;

	public bool hasSS;

	public SPIElement masterElm;

	public List<SPIElement> slaveElms;

	public virtual void SlaveReceive(byte val)
	{
	}
}
