using UnityEngine;
using UnityEngine.UI;

public class PostcardModuleStat : PostcardStat
{
	[SerializeField]
	private Image _moduleImg;

	public void SetupStat(Module module)
	{
		_moduleImg.sprite = module.GetEnhancementModule().Icon;
		_statNameTxt.text = module.GetEnhancementModule().Name + "\n" + module.MainStatName;
		_measureUnit = "";
		_statValueTxt.text = ((int)module.GetMainStat()).ToString();
	}
}
