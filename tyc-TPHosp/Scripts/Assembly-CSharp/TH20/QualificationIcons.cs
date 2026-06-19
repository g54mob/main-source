using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class QualificationIcons : MonoBehaviour
	{
		[SerializeField]
		private Image[] _qualificationSlots = new Image[5];

		[SerializeField]
		private Image[] _qualificationBack = new Image[5];

		[SerializeField]
		private Image[] _qualificationImages = new Image[5];

		[SerializeField]
		private Color _slotQualificationCompleteColor = new Color(1f, 1f, 1f, 1f);

		[SerializeField]
		private Color _slotQualificationIncompleteColor = new Color(1f, 1f, 1f, 1f);

		[SerializeField]
		private Color _slotEmptyColor = new Color(1f, 1f, 1f, 0.75f);

		[SerializeField]
		private Color _slotUnavailableColor = new Color(0.9f, 0.9f, 0.9f, 0.125f);

		[SerializeField]
		private TooltipSpawner[] _tooltipSpawner = new TooltipSpawner[5];

		[SerializeField]
		private bool _layoutSafe;

		public Image[] QualificationSlots => _qualificationSlots;

		private void SetActive(GameObject gameObject, bool active)
		{
			if (_layoutSafe)
			{
				gameObject.transform.localScale = (active ? Vector3.one : Vector3.zero);
			}
			else
			{
				GameObjectUtils.SetActive(gameObject, active);
			}
		}

		public void UpdateFrom(List<QualificationSlot> qualifications, int maxQualifications, List<Staff> allStaff)
		{
			for (int i = 0; i < 5; i++)
			{
				Image image = _qualificationSlots[i];
				Image image2 = ((_qualificationBack != null) ? _qualificationBack[i] : null);
				Image image3 = _qualificationImages[i];
				TooltipSpawner tooltipSpawner = _tooltipSpawner[i];
				QualificationSlot qualification = ((i < qualifications.Count) ? qualifications[i] : null);
				if (i >= maxQualifications)
				{
					image.color = _slotUnavailableColor;
					SetActive(image3.gameObject, active: false);
					if (image2 != null)
					{
						SetActive(image2.gameObject, active: false);
					}
					if (tooltipSpawner != null)
					{
						tooltipSpawner.enabled = false;
					}
				}
				else if (i >= qualifications.Count)
				{
					image.color = _slotEmptyColor;
					SetActive(image3.gameObject, active: false);
					if (image2 != null)
					{
						SetActive(image2.gameObject, active: false);
					}
					if (!(tooltipSpawner != null))
					{
						continue;
					}
					tooltipSpawner.enabled = true;
					tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
					{
						TooltipQualification tooltipQualification = tooltip as TooltipQualification;
						tooltip.Text = ScriptLocalization.Tooltip.Qualification_ReadyForTraining_CS;
						if (tooltipQualification != null)
						{
							GameObjectUtils.SetActive(tooltipQualification.Info.gameObject, isActive: false);
							GameObjectUtils.SetActive(tooltipQualification.Description.gameObject, isActive: false);
							GameObjectUtils.SetActive(tooltipQualification.ProgressBar.gameObject, isActive: false);
						}
					});
				}
				else
				{
					if (qualification == null)
					{
						continue;
					}
					image.color = _slotQualificationCompleteColor;
					if (image2 != null)
					{
						image2.color = _slotQualificationIncompleteColor;
						GameObjectUtils.SetImageSprite(image2, qualification.Definition.Icon);
						SetActive(image2.gameObject, active: true);
					}
					image3.fillAmount = qualification.FractionComplete;
					GameObjectUtils.SetImageSprite(image3, qualification.Definition.Icon);
					SetActive(image3.gameObject, active: true);
					if (!(tooltipSpawner != null))
					{
						continue;
					}
					tooltipSpawner.enabled = true;
					tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
					{
						TooltipQualification tooltipQualification = tooltip as TooltipQualification;
						if (tooltipQualification != null)
						{
							int num = 0;
							foreach (Staff item in allStaff)
							{
								if (item.HasCompletedQualification(qualification.Definition))
								{
									num++;
								}
							}
							string qualification_StaffCount_CS = ScriptLocalization.Tooltip.Qualification_StaffCount_CS;
							qualification_StaffCount_CS = qualification_StaffCount_CS.Replace("{[COUNT]}", num.ToString());
							tooltipQualification.Text = qualification.Definition.NameLocalised.Translation;
							tooltipQualification.Description.text = qualification.Definition.GetTooltipText();
							tooltipQualification.Info.text = qualification_StaffCount_CS;
							GameObjectUtils.SetActive(tooltipQualification.ProgressBar.gameObject, !qualification.IsComplete());
							tooltipQualification.ProgressBar.Progress = qualification.FractionComplete;
						}
					});
				}
			}
		}
	}
}
