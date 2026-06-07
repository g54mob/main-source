using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class PageManager : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> _Pages;

		[SerializeField]
		private TextMeshProUGUI _PageCount;

		[SerializeField]
		private Button _LeftArrow;

		[SerializeField]
		private Button _RightArrow;

		private int pageIndex;

		protected Rewired.Player Player;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		public void NextPage()
		{
		}

		public void ClearAllPages()
		{
		}

		public void PreviousPage()
		{
		}

		public void RemovePage(GameObject g)
		{
		}

		public void AddPage(GameObject g)
		{
		}

		public int GetPageCount()
		{
			return 0;
		}

		public void SetDownNavigation(Selectable s)
		{
		}

		public void SetUpNavigation(Selectable s)
		{
		}

		public Selectable GetSelectable()
		{
			return null;
		}
	}
}
