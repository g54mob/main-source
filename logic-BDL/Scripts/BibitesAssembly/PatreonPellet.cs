using ManagementScripts.SceneManagers;
using SimulationScripts;
using TMPro;
using UnityEngine;

public class PatreonPellet : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private MatterPellet pellet;

	private PatreonTier tier;

	private string patron;

	private void Start()
	{
	}

	public void InitializePatron(PatreonInfo info)
	{
		pellet.material = MatterMaterialManager.Plant;
		if (info != null)
		{
			tier = PatreonTier.Pellet;
			patron = info.name;
			nameText.text = patron;
			pellet.InitializePelletWithAmount(100f);
		}
		else
		{
			nameText.gameObject.SetActive(value: false);
			pellet.InitializePelletWithAmount(Random.Range(15f, 75f));
		}
		pellet.AfterAmountChange.AddListener(CheckIfDestroyed);
	}

	private void CheckIfDestroyed(MatterPellet pelletToCheck, float amount)
	{
		if (pellet.amount <= 0f)
		{
			PatreonSimulation.instance.PatreonDeath(tier, patron);
		}
	}
}
