using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TrainingMenuQualificationRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _numTrainees;

		[SerializeField]
		private TMP_Text _numTrained;

		[SerializeField]
		private Color _colourNonZeroCount = Color.white;

		[SerializeField]
		private Color _colourZeroCount = Color.white;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Button _rowButton;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		public void Setup(QualificationDefinition course, Action<QualificationDefinition> onClicked, bool isSelected, List<Staff> allStaff)
		{
			int numStaffCanLearn = 0;
			int numStaffWithQualification = 0;
			foreach (Staff item in allStaff)
			{
				if (course.ValidForExcludeIncomplete(item) && item.IsReadyForTraining())
				{
					numStaffCanLearn++;
				}
				if (item.HasCompletedQualification(course))
				{
					numStaffWithQualification++;
				}
			}
			_name.text = course.NameLocalised.Translation;
			_name.color = (isSelected ? Color.black : Color.white);
			_icon.sprite = course.Icon;
			_numTrainees.text = $"{numStaffCanLearn}";
			_numTrained.text = $"{numStaffWithQualification}";
			_numTrainees.color = ((numStaffCanLearn > 0) ? _colourNonZeroCount : _colourZeroCount);
			_numTrained.color = ((numStaffWithQualification > 0) ? _colourNonZeroCount : _colourZeroCount);
			_rowButton.onClick.AddListener(delegate
			{
				onClicked.InvokeSafe(course);
			});
			GameObjectUtils.SetInteractable(_rowButton, !isSelected);
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				TooltipTrainingCourse tooltipTrainingCourse = tooltip as TooltipTrainingCourse;
				if (tooltipTrainingCourse != null)
				{
					tooltipTrainingCourse.SetData(course.NameLocalised.Translation, course.GetTooltipText(), numStaffWithQualification, numStaffCanLearn, course.TrainingPoints);
				}
			});
		}
	}
}
