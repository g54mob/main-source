using System.Text.RegularExpressions;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class DeveloperEditorTechTreeEditor : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TextMeshProUGUI _pointsValueTextField;

		public void ChangePointsAmount()
		{
			if (int.TryParse(Regex.Replace(_pointsValueTextField.text, "[^0-9/-]", ""), out var result))
			{
				CTSSingleton<TechTreePoints>.Instance.SetPoints(result);
			}
		}

		public void ResearchAllTechnologies()
		{
			TechTreeManager.ResearchAllTechnologies();
		}
	}
}
