using NBT.Tags;
using UnityEngine;
using UnityEngine.UI;

public class OrbitalPane : MonoBehaviour
{
	public Text countText;

	public ButtonHelper buttonDamper;

	public ButtonHelper buttonSingularity;

	public ButtonHelper buttonRain;

	public ButtonHelper buttonConversion;

	private int _orbitalCount;

	public int orbitalCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public void Refresh()
	{
	}

	public int GetOrbitalCount()
	{
		return 0;
	}

	public void SetOrbitalCount(int val)
	{
	}

	public void InstallOrbital()
	{
	}

	public void RemoveOrbital(int count = 1)
	{
	}

	public void DeployOrbitalDamper()
	{
	}

	public void DeployOrbitalSingularity()
	{
	}

	public void DeployOrbitalRain()
	{
	}

	public void DeployOrbitalConversion()
	{
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
