using System.Collections;
using UnityEngine;

public class PacifistPact : MonoBehaviour
{
	private void Start()
	{
		if (PerkManager.instance.PacifistPactEquipped)
		{
			StartCoroutine(EnablePacifistPact());
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private IEnumerator EnablePacifistPact()
	{
		yield return null;
		yield return null;
		RoyalForgeUpgrade.AutoAttackMulti(PerkManager.instance.pacifistAutoAttackMulti);
		RoyalForgeUpgrade.ManualAttackMulti(PerkManager.instance.pacifistManualAttackMulti);
		RoyalForgeUpgrade.PlayerHealthMulti(PerkManager.instance.pacifistHpMulti);
		Object.Destroy(this);
	}
}
