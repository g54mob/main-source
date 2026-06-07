using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class TierRow3DUIView : MonoBehaviour
	{
		public GameObject sectionPrefab;

		[SerializeField]
		private List<Transform> slots;

		private List<Tuple<GameObject, TierSection3DUIView>> _sections;

		private void Awake()
		{
		}

		public void SetSections(int tierX, int tierY, int tierZ)
		{
		}
	}
}
