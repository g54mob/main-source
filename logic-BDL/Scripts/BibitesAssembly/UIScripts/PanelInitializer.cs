using System.Collections.Generic;
using UnityEngine;

namespace UIScripts
{
	public class PanelInitializer : MonoBehaviour
	{
		public List<GameObject> panels;

		private void Start()
		{
			panels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: true);
			});
			panels.ForEach(delegate(GameObject p)
			{
				p.SetActive(value: false);
			});
		}
	}
}
