using System.Collections;
using Bolt;
using DV.Game.Tutorial;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitTitle("Validator Tutorial")]
[UnitSubtitle("Validate job and wait for printouts")]
[UnitCategory("Interaction")]
[TypeIcon(typeof(BoxCollider))]
public class ValidatorTutorialUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput validatorObject;

	[DoNotSerialize]
	public ValueInput attentionTarget;

	[DoNotSerialize]
	[LocalizedValue]
	public ValueInput floatieMessage;

	[DoNotSerialize]
	public ValueInput floatieOffset;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		validatorObject = ValueInput<GameObject>("Validator", null);
		attentionTarget = ValueInput<GameObject>("Attention", null);
		floatieMessage = ValueInput("Message", string.Empty);
		floatieOffset = ValueInput("Offset", Vector3.zero);
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		TutorialJobValidator jobValidator = flow.GetValue<GameObject>(validatorObject).GetComponentInChildren<TutorialJobValidator>();
		string value = flow.GetValue<string>(floatieMessage);
		Vector3 value2 = flow.GetValue<Vector3>(floatieOffset);
		GameObject value3 = flow.GetValue<GameObject>(attentionTarget);
		bool validated = false;
		bool messageShown = false;
		if (!string.IsNullOrEmpty(value))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(value, value3 ? value3.transform : null, value2);
			messageShown = true;
		}
		AssignCurrentJob("TutorialSummary");
		MarkJobAsCompleted("TutorialSummary");
		jobValidator.TutorialJobValidated += OnJobValidated;
		while (!validated)
		{
			yield return null;
		}
		if (messageShown)
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
		TutorialHelper.MakeItemEssential(ActivateItem("Driver"), belongsToPlayer: true, immuneToDumpster: true);
		SingletonBehaviour<LicenseManager>.Instance.AcquireGeneralLicense(GeneralLicenseType.TrainDriver.ToV2());
		yield return WaitFor.Seconds(3f);
		jobValidator.PlayPrintSoundExternally();
		TutorialHelper.MakeItemEssential(ActivateItem("DE2"), belongsToPlayer: true, immuneToDumpster: true);
		SingletonBehaviour<LicenseManager>.Instance.AcquireGeneralLicense(GeneralLicenseType.DE2.ToV2());
		yield return WaitFor.Seconds(3f);
		jobValidator.PlayPrintSoundExternally();
		TutorialHelper.MakeItemEssential(ActivateItem("FreightHaul"), belongsToPlayer: true, immuneToDumpster: true);
		SingletonBehaviour<LicenseManager>.Instance.AcquireJobLicense(JobLicenses.FreightHaul.ToV2());
		yield return null;
		yield return doneTrigger;
		void OnJobValidated()
		{
			Debug.Log("JOB VALIDATED!");
			validated = true;
		}
	}

	private GameObject ActivateItem(string partialItemName)
	{
		GameObject gameObject = null;
		GameObject[] objectList = SingletonBehaviour<TutorialObjectRegistry>.Instance.objectList;
		foreach (GameObject gameObject2 in objectList)
		{
			if ((bool)gameObject2)
			{
				InventoryItemSpec component = gameObject2.GetComponent<InventoryItemSpec>();
				if ((bool)component && component.name.Contains(partialItemName))
				{
					gameObject = component.gameObject;
					gameObject.SetActive(value: true);
					break;
				}
			}
		}
		return gameObject;
	}

	private void MarkJobAsCompleted(string jobName)
	{
		GameObject[] objectList = SingletonBehaviour<TutorialObjectRegistry>.Instance.objectList;
		foreach (GameObject gameObject in objectList)
		{
			if ((bool)gameObject)
			{
				InventoryItemSpec component = gameObject.GetComponent<InventoryItemSpec>();
				if (!string.IsNullOrEmpty(component?.ItemPrefabName) && component.ItemPrefabName.Contains(jobName))
				{
					component.GetComponent<TutorialJob>().jobDone = true;
					break;
				}
			}
		}
	}

	private void AssignCurrentJob(string jobName)
	{
		GameObject[] objectList = SingletonBehaviour<TutorialObjectRegistry>.Instance.objectList;
		foreach (GameObject gameObject in objectList)
		{
			if ((bool)gameObject)
			{
				InventoryItemSpec component = gameObject.GetComponent<InventoryItemSpec>();
				if (!string.IsNullOrEmpty(component?.ItemPrefabName) && component.ItemPrefabName.Contains(jobName))
				{
					component.GetComponent<TutorialJob>().isCurrentJob = true;
					break;
				}
			}
		}
	}
}
