using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableButtonInWaveZero : MonoBehaviour
{
	public bool alwaysDisableInTutorial = true;

	public bool disableInWaveZero = true;

	public GameObject buttonToDisable;

	public void OnEnable()
	{
		bool flag = SceneManager.GetActiveScene().name == "Neuland(Tutorial)";
		bool flag2 = EnemySpawner.instance != null && EnemySpawner.instance.Wavenumber < 1;
		if ((alwaysDisableInTutorial && flag) || (disableInWaveZero && flag2))
		{
			buttonToDisable.SetActive(value: false);
		}
		else
		{
			buttonToDisable.SetActive(value: true);
		}
	}
}
