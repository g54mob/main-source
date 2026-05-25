using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
	public GameObject PeonHelpButton;

	public GameObject GarbageHelpButton;

	public GameObject ControlHelpButton;

	public GameObject ShardHelpButton;

	public GameObject BookHelpButton;

	public GameObject DeviceButton;

	public GameObject CloggedButton;

	public GameObject GolemButton;

	public GameObject ExtraButton;

	public GameObject PeonHelpPanel;

	public GameObject GarbageHelpPanel;

	public GameObject ControlHelpPanel;

	public GameObject ShardHelpPanel;

	public GameObject BookHelpPanel;

	public GameObject DevicePanel;

	public GameObject CloggedPanel;

	public GameObject GolemPanel;

	public GameObject ExtraPanel;

	public TMP_Text PeonSpeed;

	public TMP_Text PeonCarryAmount;

	public TMP_Text PeonHappyLength;

	public TMP_Text PeonContentLength;

	public TMP_Text PeonSadLength;

	public TMP_Text PeonSpeedLength;

	public TMP_Text GarbageSFillValue;

	public TMP_Text GarbageMFillValue;

	public TMP_Text GarbageLFillValue;

	public TMP_Text GarbageXLFillValue;

	public GameObject BlueShardSection;

	public GameObject YellowShardSection;

	public GameObject RedShardSection;

	public GameObject CompressorHelp;

	public GameObject DroneHelp;

	public GameObject HelicopterHelp;

	public GameObject HotAirStationHelp;

	public GameObject HouseHelp;

	public GameObject IndustryHelp;

	public GameObject PowerHelp;

	public GameObject ResearchHelp;

	public GameObject TrainingHelp;

	public TMP_Text RedShardFrom;

	private void Start()
	{
		SetButtonVisibility();
	}

	private void Update()
	{
		SetButtonVisibility();
	}

	private void SetButtonVisibility()
	{
		if (GameController.Instance.BluePoint.TotalAmount == 0 && GameController.Instance.YellowPoint.TotalAmount == 0 && GameController.Instance.RedPoint.TotalAmount == 0)
		{
			ShardHelpButton.SetActive(value: false);
		}
		else
		{
			ShardHelpButton.SetActive(value: true);
		}
		if (GameController.Instance.Book.TotalAmount == 0)
		{
			BookHelpButton.SetActive(value: false);
		}
		else
		{
			BookHelpButton.SetActive(value: true);
		}
		if (Compressor.GlobalInfo.CanHighlightDevice() || Drone.GlobalInfo.CanHighlightDevice() || Helicopter.GlobalInfo.CanHighlightDevice() || HotAirStation.GlobalInfo.CanHighlightDevice() || House.GlobalInfo.CanHighlightDevice() || Industry.GlobalInfo.CanHighlightDevice() || Power.GlobalInfo.CanHighlightDevice() || Research.GlobalInfo.CanHighlightDevice() || Training.GlobalInfo.CanHighlightDevice())
		{
			DeviceButton.SetActive(value: true);
		}
		else
		{
			DeviceButton.SetActive(value: false);
		}
		if (GameController.TotalBlockedOutput == 0)
		{
			CloggedButton.SetActive(value: false);
		}
		else
		{
			CloggedButton.SetActive(value: true);
		}
		if (GameController.Instance.Golem.HadGolem())
		{
			GolemButton.SetActive(value: true);
		}
		else
		{
			GolemButton.SetActive(value: false);
		}
		if (Installation.IsDemo())
		{
			ExtraButton.SetActive(value: false);
		}
		else
		{
			ExtraButton.SetActive(value: true);
		}
		GetRedShardFrom();
	}

	private void GetRedShardFrom()
	{
		List<string> list = new List<string>();
		RedShardFrom.text = "";
		if (Compressor.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Compressor");
		}
		if (Drone.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Cloud Seeder");
		}
		if (Helicopter.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Helipad");
		}
		if (HotAirStation.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Hangar");
		}
		if (House.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("House");
		}
		if (Industry.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Factory");
		}
		if (Power.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Power");
		}
		if (Research.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Research Lab");
		}
		if (Training.GlobalInfo.EvilExplosionCount > 0)
		{
			list.Add("Training");
		}
		if (list.Count > 0)
		{
			RedShardFrom.text = "Already obtained from: " + string.Join(", ", list.ToArray());
		}
	}

	public void SetDisplayLogic()
	{
		DisplayPeonHelp();
		PeonSpeed.text = "Happy peon move " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharHappySpeed() - 1f) + " faster";
		TMP_Text peonSpeed = PeonSpeed;
		peonSpeed.text = peonSpeed.text + ", content peon move " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharNormalSpeed() - 1f) + " faster";
		TMP_Text peonSpeed2 = PeonSpeed;
		peonSpeed2.text = peonSpeed2.text + " and sad peon move " + BaseBuildingPanel.FormatPercentage(GameController.GlobalInfo.CharSadSpeed() - 1f) + " faster.";
		PeonCarryAmount.text = GameController.GlobalInfo.GetCharacterCarryLimit().ToString();
		PeonHappyLength.text = CharV2.GetHapinessLength() + "s";
		PeonContentLength.text = CharV2.GetContentLength() + "s";
		PeonSadLength.text = CharV2.GetSuperSadLength() + "s";
		PeonSpeedLength.text = GameController.GlobalInfo.GetCharacterSpeed(isHappy: false, isContent: true, isSad: false).ToString();
		if (Helicopter.GlobalInfo.CanIncreaseSizeOfGarbageAttribute.IsEnabled)
		{
			GarbageSFillValue.text = 2.ToString();
			GarbageMFillValue.text = 10.ToString();
			GarbageLFillValue.text = 50.ToString();
			GarbageXLFillValue.text = 250.ToString();
		}
		else
		{
			GarbageSFillValue.text = 1.ToString();
			GarbageMFillValue.text = 5.ToString();
			GarbageLFillValue.text = 25.ToString();
			GarbageXLFillValue.text = 125.ToString();
		}
	}

	public void DisplayPeonHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: true);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayGarbageHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: true);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayControlHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: true);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayShardHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: true);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
		if (GameController.Instance.BluePoint.TotalAmount > 0)
		{
			BlueShardSection.SetActive(value: true);
		}
		else
		{
			BlueShardSection.SetActive(value: false);
		}
		if (GameController.Instance.YellowPoint.TotalAmount > 0)
		{
			YellowShardSection.SetActive(value: true);
		}
		else
		{
			YellowShardSection.SetActive(value: false);
		}
		if (GameController.Instance.RedPoint.TotalAmount > 0)
		{
			RedShardSection.SetActive(value: true);
		}
		else
		{
			RedShardSection.SetActive(value: false);
		}
	}

	public void DisplayBookHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: true);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayDeviceHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: true);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
		CompressorHelp.SetActive(Compressor.GlobalInfo.CanHighlightDevice());
		DroneHelp.SetActive(Drone.GlobalInfo.CanHighlightDevice());
		HelicopterHelp.SetActive(Helicopter.GlobalInfo.CanHighlightDevice());
		HotAirStationHelp.SetActive(HotAirStation.GlobalInfo.CanHighlightDevice());
		HouseHelp.SetActive(House.GlobalInfo.CanHighlightDevice());
		IndustryHelp.SetActive(Industry.GlobalInfo.CanHighlightDevice());
		PowerHelp.SetActive(Power.GlobalInfo.CanHighlightDevice());
		ResearchHelp.SetActive(Research.GlobalInfo.CanHighlightDevice());
		TrainingHelp.SetActive(Training.GlobalInfo.CanHighlightDevice());
	}

	public void DisplayCloggedHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: true);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayGolemHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: true);
		ExtraPanel.SetActive(value: false);
	}

	public void DisplayExtraHelp()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_gamemenu_tab_appear);
		PeonHelpPanel.SetActive(value: false);
		GarbageHelpPanel.SetActive(value: false);
		ControlHelpPanel.SetActive(value: false);
		ShardHelpPanel.SetActive(value: false);
		BookHelpPanel.SetActive(value: false);
		DevicePanel.SetActive(value: false);
		CloggedPanel.SetActive(value: false);
		GolemPanel.SetActive(value: false);
		ExtraPanel.SetActive(value: true);
	}
}
