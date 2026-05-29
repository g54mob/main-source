using CTS.BBT.TechTree;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_MachineMgr_CategoryLevel : UI_MachineMgr_CategoryFeature
	{
		[SerializeField]
		private TMP_Text _levelTextContainer;

		protected override void OnAwake()
		{
			base.OnAwake();
			TechTreeManager.OnTechnologyResearched += OnTechResearched;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			TechTreeManager.OnTechnologyResearched -= OnTechResearched;
		}

		private void OnTechResearched(TechTreeTechnologySO obj)
		{
			if (_category.CategoryData.AssociatedFurniture.TechTreeTechnologyRequiered == obj)
			{
				Repaint();
			}
		}

		protected override void OnRepaint()
		{
			TechTreeTechnologySO techTreeTechnologyRequiered = _category.CategoryData.AssociatedFurniture.TechTreeTechnologyRequiered;
			if ((object)techTreeTechnologyRequiered != null)
			{
				_levelTextContainer.text = ((int)TechTreeManager.GetTechnologyResearchLevel(techTreeTechnologyRequiered)).ToString();
			}
		}
	}
}
