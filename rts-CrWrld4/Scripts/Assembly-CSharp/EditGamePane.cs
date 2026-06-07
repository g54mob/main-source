using UnityEngine;
using UnityEngine.UI;

public class EditGamePane : MonoBehaviour
{
	public GameObject cmodUnitLimitRowPrefab;

	public Transform cmodLimitsContainer;

	public Toggle objectiveNullify;

	public Toggle objectiveTotem;

	public Toggle objectiveReclaim;

	public Toggle objectiveSurvive;

	public Toggle objectiveCollect;

	public Toggle objectiveCustom;

	public Toggle objectiveNullifyReq;

	public Toggle objectiveTotemReq;

	public Toggle objectiveReclaimReq;

	public Toggle objectiveSurviveReq;

	public Toggle objectiveCollectReq;

	public Toggle objectiveCustomReq;

	public InputField objectiveReclaimAmt;

	public InputField objectiveReclaimThreshold;

	public InputField objectiveSurviveTime;

	public InputField objectiveSurviveCount;

	public Toggle objectiveHoldKeepGoing;

	public InputField objectiveCustomName;

	public InputField progressiveGraceTime;

	public InputField progressiveTime;

	public InputField progressiveMax;

	public InputField progressiveNullifierOffLevel;

	public InputField voidHeight;

	public InputField digiDepth;

	public InputField globalFieldCRL;

	public InputField globalFieldCUD;

	public InputField globalFieldACRL;

	public InputField globalFieldACUD;

	public InputField creeperFlow;

	public InputField creeperWaveTransferCap;

	public InputField creeperWaveTransfer;

	public InputField creeperCutoffMax;

	public InputField wallDecayRate;

	public InputField maxEggs;

	public InputField eggPayload;

	public InputField eggBravePercent;

	public InputField eggBraveInterval;

	public InputField eggBrageMaxPickup;

	public Toggle terraforming;

	public Toggle decon;

	public Toggle soylent;

	public InputField soylentDeployDelay;

	public InputField soylentDeployCount;

	public Toggle canMoveUnits;

	public Toggle minimapAvailable;

	public Toggle creeperGraphAvailable;

	public Toggle departButtonAvailable;

	public Toggle canOverloadNullifiers;

	public Toggle buildRiftLab;

	public Toggle buildFactory;

	public Toggle buildErnPortal;

	public Toggle buildTowers;

	public InputField buildTowersLimit;

	public Toggle buildPylons;

	public InputField buildPylonsLimit;

	public Toggle buildMiners;

	public InputField buildMinersLimit;

	public Toggle buildGreenarRefineries;

	public InputField buildGreenarRefineriesLimit;

	public Toggle buildTerps;

	public InputField buildTerpsLimit;

	public Toggle buildPorters;

	public InputField buildPortersLimit;

	public Toggle buildCannons;

	public InputField buildCannonsLimit;

	public Toggle buildMortars;

	public InputField buildMortarsLimit;

	public Toggle buildSprayers;

	public InputField buildSprayersLimit;

	public Toggle buildSnipers;

	public InputField buildSnipersLimit;

	public Toggle buildMissileLaunchers;

	public InputField buildMissileLaunchersLimit;

	public Toggle buildNullifiers;

	public InputField buildNullifiersLimit;

	public Toggle buildRunways;

	public InputField buildRunwaysLimit;

	public Toggle buildBombers;

	public InputField buildBombersLimit;

	public Toggle buildACBombers;

	public InputField buildACBombersLimit;

	public Toggle buildRockets;

	public InputField buildRocketsLimit;

	public Toggle buildPlatforms;

	public InputField buildPlatformsLimit;

	public Toggle buildShields;

	public InputField buildShieldsLimit;

	public Toggle buildMicrorifts;

	public InputField buildMicroriftsLimit;

	public Toggle buildBeacons;

	public InputField buildBeaconsLimit;

	public Toggle buildAirships;

	public InputField buildAirshipsLimit;

	public Toggle buildBerthas;

	public InputField buildBerthasLimit;

	public Toggle buildSweepers;

	public InputField buildSweepersLimit;

	public void OnEnable()
	{
	}

	public void OnApply()
	{
	}

	private void SetBuildLimit(string unit, string val)
	{
	}
}
