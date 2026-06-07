using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class GameItemModelChanger : MonoBehaviour
	{
		private GameObjectX _targetObject;

		private GameItem _item;

		private List<Transform>[] _amountRangeTransforms;

		private List<Transform> _allAmountRangeTransforms;

		private List<Transform>[] items;

		private List<Transform>[] starModels;

		public void Awake()
		{
		}

		public void Init()
		{
		}

		private void UpdateStarModel()
		{
		}

		private void AmountChanged(object sender, EventArgs e)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
