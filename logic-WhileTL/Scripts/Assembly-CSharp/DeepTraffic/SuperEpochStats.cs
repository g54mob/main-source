using Localization;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class SuperEpochStats : ActiveComponent
	{
		[SceneBind("EpochNumberText")]
		private Text epochNumberText;

		[SceneBind("MeanSpeedField/NumberText")]
		private Text meanSpeedText;

		[SceneBind("StdSpeedField/NumberText")]
		private Text stdSpeedText;

		[SceneBind("EstimatedCostField/NumberText")]
		private Text estimatedCostText;

		[SceneBind("MutatedSpeciesField/NumberText")]
		private Text mutatedSpeciesText;

		[SceneBind("MutatedGeneField/NumberText")]
		private Text mutatedGenesText;

		private AgentUnlockedParams agentUnlockedParams;

		private int epochNumber;

		private float? meanSpeed;

		private float? stdSpeed;

		private int? estimatedCost;

		private int? mutatedSpecies;

		private int? mutatedGenes;

		public int EpochNumber
		{
			get
			{
				return epochNumber;
			}
			set
			{
				epochNumber = value;
				epochNumberText.text = TextResources.GetString("EPOCH_NUMBER") + " " + value;
				base.gameObject.SetActive(value > 0);
			}
		}

		public float? MeanSpeed
		{
			get
			{
				return meanSpeed;
			}
			set
			{
				meanSpeed = value;
				meanSpeedText.text = Logic.ColorTransform("SPEED", SetNullType(value, " " + TextResources.GetString("SPEED_TEXT"), round: true));
			}
		}

		public float? StdSpeed
		{
			get
			{
				return stdSpeed;
			}
			set
			{
				stdSpeed = value;
				stdSpeedText.text = Logic.ColorTransform("SPEED", SetNullType(value, " " + TextResources.GetString("SPEED_TEXT"), round: true));
			}
		}

		public int? EstimatedCost
		{
			get
			{
				return estimatedCost;
			}
			set
			{
				estimatedCost = value;
				estimatedCostText.text = Logic.ColorTransform("MONEY", SetNullType(value, "$"));
			}
		}

		public int? MutatedSpecies
		{
			get
			{
				return mutatedSpecies;
			}
			set
			{
				mutatedSpecies = value;
				mutatedSpeciesText.text = SetNullType(value);
			}
		}

		public int? MutatedGenes
		{
			get
			{
				return mutatedGenes;
			}
			set
			{
				mutatedGenes = value;
				mutatedGenesText.text = SetNullType(value);
			}
		}

		private string SetNullType<T>(T value, string addStr = "", bool round = false, string roundFormat = "n2")
		{
			if (value == null)
			{
				return "?";
			}
			if (round)
			{
				return (value as float?).GetValueOrDefault().ToString(roundFormat) + addStr;
			}
			return value.ToString() + addStr;
		}

		public void ResetStats()
		{
			MeanSpeed = null;
			StdSpeed = null;
			EstimatedCost = null;
			MutatedSpecies = null;
			MutatedGenes = null;
		}

		public void Init(int superEpochSize, AgentUnlockedParams agentUnlockedParams)
		{
			this.agentUnlockedParams = agentUnlockedParams;
			if (!base.IsInited)
			{
				base.Init();
			}
			EpochNumber = 1;
			ResetStats();
			mutatedSpeciesText.transform.parent.gameObject.SetActive(agentUnlockedParams.chromosomeMutationProbability);
			mutatedGenesText.transform.parent.gameObject.SetActive(agentUnlockedParams.geneMutationProbability);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
		}

		public void UpdateData(SuperEpochData data)
		{
			EpochNumber = data.superEpochNumber;
			MeanSpeed = data.meanSpeed;
			StdSpeed = data.stdSpeed;
			EstimatedCost = data.estimatedCost;
			MutatedSpecies = data.mutatedSpecies;
			MutatedGenes = data.meanMutatedGenes;
		}

		public void CloneData(SuperEpochStats stats)
		{
			EpochNumber = stats.EpochNumber;
			MeanSpeed = stats.MeanSpeed;
			StdSpeed = stats.StdSpeed;
			EstimatedCost = stats.EstimatedCost;
			MutatedSpecies = stats.MutatedSpecies;
			MutatedGenes = stats.MutatedGenes;
		}
	}
}
