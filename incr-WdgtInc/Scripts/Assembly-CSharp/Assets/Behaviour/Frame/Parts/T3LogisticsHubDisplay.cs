using Assets.Source.Util;
using Assets.Source.World.Frames;
using TMPro;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T3LogisticsHubDisplay : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _label;

		private void OnEnable()
		{
			T3LogisticsHub t3LogisticsHub = GetComponent<ActiveWorldFrame>().ActiveFrame as T3LogisticsHub;
			_label.text = Translation.Translate("@LogisticsHubPowerDraw", GameMath.FormatNumber(t3LogisticsHub.DisplayedPowerDraw, 1));
		}
	}
}
