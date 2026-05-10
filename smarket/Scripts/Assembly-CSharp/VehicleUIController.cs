using UnityEngine;
using UnityEngine.UI;

public class VehicleUIController : MonoBehaviour
{
	public Image GasConsumerBarImage;

	public Image GasConsumerIcon;

	[SerializeField]
	private Color m_LowLevelGas;

	[SerializeField]
	private Color m_DefaultLevelGas;

	[SerializeField]
	private AudioSource m_OutOfGasSound;

	public void ChangeGasBarRate(float _value)
	{
	}

	public void PlayOutOfGasSound()
	{
	}
}
