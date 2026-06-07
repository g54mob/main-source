using Localization;
using UnityEngine;
using UnityEngine.UI;

public class CarQuestResultController : ActiveComponent
{
	[SceneBind("MetaStatsField/AverageDestinationTimeField/ValueText")]
	private Text averageDestinationTimeText;

	[SceneBind("MetaStatsField/EstimatedCostField/ValueText")]
	private Text estimatedCost;

	[SceneBind("OkBtn")]
	private Button okButton;

	[SceneBind("ClassifierStatsField/LeftStatsField/Holder")]
	private Transform leftHolderTransform;

	[SceneBind("ClassifierStatsField/FrontStatsField/Holder")]
	private Transform frontHolderTransform;

	[SceneBind("ClassifierStatsField/BehindStatsField/Holder")]
	private Transform behindHolderTransform;

	[SceneBind("ClassifierStatsField/RightStatsField/Holder")]
	private Transform rightHolderTransform;

	private Transform[] holders = new Transform[5];

	private GameObject[] classifierStatsInstances = new GameObject[5];

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		base.gameObject.SetActive(value: false);
		averageDestinationTimeText.color = Logic.GetColor("BLUE");
		estimatedCost.color = Logic.GetColor("RED");
		okButton.onClick.AddListener(OkButtonListener);
		holders[0] = leftHolderTransform;
		holders[1] = frontHolderTransform;
		holders[2] = null;
		holders[3] = behindHolderTransform;
		holders[4] = rightHolderTransform;
	}

	private void OkButtonListener()
	{
		GameObject[] array = classifierStatsInstances;
		foreach (GameObject gameObject in array)
		{
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
		base.gameObject.SetActive(value: false);
	}

	public void Show(float averageDestinationTime, float money, GameObject[] classifierStats)
	{
		averageDestinationTimeText.text = Logic.ColorTransform("TIME", averageDestinationTime.ToString("f1") + " " + TextResources.GetString("SEC"));
		estimatedCost.text = Logic.ColorTransform("BAD", Mathf.RoundToInt(money) + "$");
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = classifierStats[i];
			Transform transform = holders[i];
			_ = classifierStatsInstances[i];
			if (gameObject == null || transform == null)
			{
				if (transform != null)
				{
					transform.parent.gameObject.SetActive(value: false);
				}
			}
			else
			{
				transform.parent.gameObject.SetActive(value: true);
				GameObject obj = Object.Instantiate(gameObject, transform, worldPositionStays: false);
				obj.GetComponent<MoveObjToY>().enabled = false;
				obj.transform.localPosition = Vector3.zero;
			}
		}
		base.gameObject.SetActive(value: true);
		ActiveComponent.Program.cursor.SetPosition(okButton.transform.position);
	}
}
