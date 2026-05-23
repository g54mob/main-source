using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ResultRouteNode : MonoBehaviour
	{
		[Serializable]
		private struct NodeSprite
		{
			public ResultDialog.NodeState state;

			public Sprite sprite;
		}

		[SerializeField]
		private Image background;

		[SerializeField]
		private Image enemyIcon;

		[SerializeField]
		private Image bossIcon;

		[SerializeField]
		private ChoiceArrow choiceArrow;

		[SerializeField]
		private List<NodeSprite> nodeSprites;

		public void InitComponent(eEnemy enemy, ResultDialog.NodeState state = ResultDialog.NodeState.Normal)
		{
		}
	}
}
