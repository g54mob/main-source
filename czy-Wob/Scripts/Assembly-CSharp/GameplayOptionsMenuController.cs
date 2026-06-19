using System.Collections;
using TMPro;
using UnityEngine;

public class GameplayOptionsMenuController : MonoBehaviour
{
	public OptionsMenuToggle dogDeathToggle;

	public OptionsMenuToggle passiveModeToggle;

	public OptionsMenuToggle ghostAutoSpawnToggle;

	public OptionsMenuToggle cappedGeneticsToggle;

	public TMP_InputField dogLifespanInputField;

	private bool cappedGenetics;

	private bool dogDeathEnabled = true;

	private bool passiveModeEnabled;

	private bool ghostAutoSpawnEnabled = true;

	private int currentDogLifespanInMinutes = 35;

	private void OnEnable()
	{
		LoadSettings();
	}

	public IEnumerator SaveOnClose(SaveLoadManager.SaveFinishedCallback callback)
	{
		yield return new WaitForEndOfFrame();
		SaveLoadManager saveLoadManager = ObjectRegistration.GetRegistrationScript().saveLoadManager;
		if (saveLoadManager == null)
		{
			callback?.Invoke(result: false);
		}
		else
		{
			yield return StartCoroutine(saveLoadManager.SaveGameplaySettings(callback));
		}
	}

	public void ToggleDogDeath()
	{
		SetDogDeath(!dogDeathEnabled);
	}

	private void SetDogDeath(bool val)
	{
		dogDeathEnabled = val;
		dogDeathToggle.SetToggleState(dogDeathEnabled);
		ApplyDogDeath();
	}

	private void ApplyDogDeath()
	{
		GameSettings.SetDogDeathEnabled(dogDeathEnabled);
	}

	public void ToggleCappedGenetics()
	{
		SetCappedGenetics(!cappedGenetics);
	}

	private void SetCappedGenetics(bool val)
	{
		cappedGenetics = val;
		cappedGeneticsToggle.SetToggleState(cappedGenetics);
		ApplyCappedGenetics();
	}

	private void ApplyCappedGenetics()
	{
		GameSettings.SetCappedGenetics(cappedGenetics);
	}

	public void ToggleGhostAutoSpawn()
	{
		SetGhostAutoSpawn(!ghostAutoSpawnEnabled);
	}

	private void SetGhostAutoSpawn(bool val)
	{
		ghostAutoSpawnEnabled = val;
		ghostAutoSpawnToggle.SetToggleState(ghostAutoSpawnEnabled);
		ApplyGhostAutoSpawn();
	}

	private void ApplyGhostAutoSpawn()
	{
		GameSettings.SetGhostAutoSpawnEnabled(ghostAutoSpawnEnabled);
	}

	public void TogglePassiveMode()
	{
		SetPassiveMode(!passiveModeEnabled);
	}

	private void SetPassiveMode(bool val)
	{
		passiveModeEnabled = val;
		passiveModeToggle.SetToggleState(passiveModeEnabled);
		ApplyPassiveMode();
	}

	private void ApplyPassiveMode()
	{
		GameSettings.SetPassiveModeEnabled(passiveModeEnabled);
	}

	private void LoadDogDeath()
	{
		dogDeathEnabled = GameSettings.IsDogDeathEnabled();
		dogDeathToggle.SetToggleState(dogDeathEnabled);
	}

	private void LoadCappedGenetics()
	{
		cappedGenetics = GameSettings.AreGeneticsCapped();
		cappedGeneticsToggle.SetToggleState(cappedGenetics);
	}

	private void LoadPassiveMode()
	{
		passiveModeEnabled = GameSettings.IsPassiveModeEnabled();
		passiveModeToggle.SetToggleState(passiveModeEnabled);
	}

	private void LoadGhostAutoSpawn()
	{
		ghostAutoSpawnEnabled = GameSettings.IsGhostAutoSpawnEnabled();
		ghostAutoSpawnToggle.SetToggleState(ghostAutoSpawnEnabled);
	}

	private void LoadDogLifespan()
	{
		currentDogLifespanInMinutes = GameSettings.GetAverageAdultDogLifespanInMinutes();
		int num = Mathf.RoundToInt(currentDogLifespanInMinutes);
		dogLifespanInputField.SetTextWithoutNotify(num.ToString());
	}

	private void LoadSettings()
	{
		LoadDogDeath();
		LoadPassiveMode();
		LoadDogLifespan();
		LoadCappedGenetics();
		LoadGhostAutoSpawn();
	}

	public void OnLifespanEndEdit()
	{
		if (!int.TryParse(dogLifespanInputField.text, out var result))
		{
			result = 1;
		}
		if (result <= 0)
		{
			dogLifespanInputField.SetTextWithoutNotify("1");
		}
	}

	public void ResetLifespan()
	{
		GameSettings.UseDefaultAdultDogLifespanInMinutes();
		LoadDogLifespan();
	}

	public void ApplyLifespan()
	{
		if (!int.TryParse(dogLifespanInputField.text, out var result))
		{
			LoadDogLifespan();
		}
		else
		{
			GameSettings.SetAverageAdultDogLifespanInMinutes(result);
		}
	}
}
