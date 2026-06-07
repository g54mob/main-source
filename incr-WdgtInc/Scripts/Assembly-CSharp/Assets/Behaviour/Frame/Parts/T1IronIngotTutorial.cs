using Assets.Source.Player;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T1IronIngotTutorial : MonoBehaviour
	{
		public void CheckTutorial()
		{
			TechNode techNode = "t1u_iron_smelter_auto";
			if (!GamePlayer.Current.HasTech(techNode) && GamePlayer.Current.GetTechConstruction(techNode) == null)
			{
				GameUI.Instance.ShowTechTutorial();
			}
		}
	}
}
