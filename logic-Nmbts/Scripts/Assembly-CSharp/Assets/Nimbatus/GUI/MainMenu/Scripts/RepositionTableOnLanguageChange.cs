using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class RepositionTableOnLanguageChange : MonoBehaviour
	{
		public UITable Table;

		public void Start()
		{
			StartCoroutine(UpdateTable());
		}

		private IEnumerator UpdateTable()
		{
			while (true)
			{
				Table.Reposition();
				Table.enabled = true;
				yield return new WaitForSeconds(0.5f);
			}
		}
	}
}
