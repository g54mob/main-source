using UnityEngine;

public class LiquidSpreaderInfo
{
	public LiquidInfo liquidInfo;

	public float currentLiquidTimer;

	public float liquidTotal;

	public int lastFrameIncrease = -1;

	public ParticleSystem particleRef;
}
