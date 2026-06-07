using Libs;
using ScriptableObjects.ScriptableObjectScripts.Settings;
using TMPro;

namespace UI
{
	public class CostCtrl : SingletonMonoBehaviour<CostCtrl>
	{
		public TMP_Text costText1;

		public TMP_Text moneyText;

		public TMP_Text removeMachineCountText;

		private WaveInfoData _waveInfo;

		private double _counter;

		public bool CountUpOk => false;

		private void Awake()
		{
		}

		public void Init()
		{
		}

		private void Update()
		{
		}

		public void UpdateCostMaterial()
		{
		}

		public static int ConvertSpritePointNum(ePointType type)
		{
			return 0;
		}
	}
}
