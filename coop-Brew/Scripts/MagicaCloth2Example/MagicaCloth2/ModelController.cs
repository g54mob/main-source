using System;
using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class ModelController : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> characterList;

		[SerializeField]
		private float slowTime;

		private bool slow;

		protected void Start()
		{
		}

		private void AnimatorAction(Action<Animator> act)
		{
		}

		private void ClothAction(Action<MagicaCloth> act)
		{
		}

		public void OnNextButton()
		{
		}

		public void OnBackButton()
		{
		}

		public void OnSlowButton()
		{
		}

		public void OnActiveButton()
		{
		}
	}
}
