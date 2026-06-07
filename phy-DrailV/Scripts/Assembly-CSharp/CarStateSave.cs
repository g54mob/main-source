using DV.Damage;
using DV.JObjectExtstensions;
using DV.ServicePenalty;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CarStateSave : MonoBehaviour
{
	private const string CAR_DAMAGE_SAVE_KEY = "carDmg";

	private const string CARGO_DAMAGE_SAVE_KEY = "cargoDmg";

	private const string CAR_DEBT_TRACKER_SAVE_KEY = "debt";

	private CarDamageModel carDmg;

	private CargoDamageModel cargoDmg;

	private DebtTrackerCar debtTrackerCar;

	public void Initialize(CarDamageModel carDmg, CargoDamageModel cargoDmg)
	{
		this.carDmg = carDmg;
		this.cargoDmg = cargoDmg;
	}

	public void SetDebtTrackerCar(DebtTrackerCar debtTrackerCar)
	{
		this.debtTrackerCar = debtTrackerCar;
	}

	public JObject GetCarStateSaveData()
	{
		JObject jObject = new JObject();
		if (carDmg != null)
		{
			jObject.SetFloat("carDmg", carDmg.HealthPercentage);
		}
		if (cargoDmg != null)
		{
			jObject.SetFloat("cargoDmg", cargoDmg.HealthPercentage);
		}
		if (debtTrackerCar != null)
		{
			jObject.SetJObject("debt", debtTrackerCar.GetDebtTrackerCarSaveData());
		}
		return jObject;
	}

	public void SetCarStateSaveData(JObject data)
	{
		if (carDmg != null)
		{
			float? num = data.GetFloat("carDmg");
			if (num.HasValue)
			{
				carDmg.LoadCarDamageState(num.Value);
			}
			else
			{
				Debug.LogError("Couldn't find carDmg to load!", this);
			}
		}
		if (cargoDmg != null)
		{
			float? num2 = data.GetFloat("cargoDmg");
			if (num2.HasValue)
			{
				cargoDmg.LoadCargoDamageState(num2.Value);
			}
			else
			{
				Debug.LogError("Couldn't find cargoDmg to load!", this);
			}
		}
		if (debtTrackerCar != null)
		{
			JObject jObject = data.GetJObject("debt");
			if (jObject != null)
			{
				debtTrackerCar.LoadDebtTrackerCarStateFromSaveData(jObject);
			}
			else
			{
				Debug.LogError("Couldn't find debt to load!", this);
			}
		}
	}
}
