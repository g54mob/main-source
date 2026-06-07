using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class LikedDrinkPanel : AbsAgentPanel
	{
		[SerializeField]
		private LikedDrinkLayout _likedLayout;

		[SerializeField]
		private LikedDrinkLayout _dislikedLayout;

		[SerializeField]
		private VampireBloodRequired _bloodRequiredLayout;

		[SerializeField]
		private GameObject _humanEndFooter;

		public override void ClearAgentInfo()
		{
		}

		public override void SetAgentInfo()
		{
			if (base._agent is Customer customer)
			{
				_likedLayout.SetDrinks(customer.SpawnParameters.DrinksLiked, base._agent);
				_dislikedLayout.SetDrinks(customer.SpawnParameters.DrinksHate, base._agent);
				_bloodRequiredLayout.gameObject.SetActive(!base._agent.IsHuman);
				_humanEndFooter.SetActive(customer.IsHuman);
				_bloodRequiredLayout.SetText(customer);
			}
		}
	}
}
