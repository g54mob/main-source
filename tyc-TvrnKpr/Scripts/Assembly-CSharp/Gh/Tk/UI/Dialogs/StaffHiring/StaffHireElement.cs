using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.StaffHiring
{
	public class StaffHireElement : MonoBehaviour
	{
		public bool AnimateStaffPreview;

		public TextMeshProI18n Name;

		[SerializeField]
		private TraitsContainer3DUIView _traitsContainer;

		public TextMeshProI18n Level;

		[SerializeField]
		private TextMeshProI18n _stressReactionText;

		public TextMeshProI18n Salary;

		public StaffBiosElement StaffBiosElement;

		public GameObject PreviewParent;

		private Staff _staff;

		private GameObject _model;

		[SerializeField]
		private BaseInteractable3DUIView _raceTrait;

		[SerializeField]
		private Transform _stressTraitSocket;

		[SerializeField]
		private Transform _tierTraitSocket;

		[SerializeField]
		private Transform _uniqueStaffTraitSocket;

		private string _salaryTemplate;

		public StaffStatBlock statBlock;

		public bool includeBioInTraitTooltip;

		public Func<IAiComponentVisualInfo, bool> traitsFilter;

		public static Dictionary<string, string> LastHiringScreenAnimationPerRace;

		public virtual Staff Staff
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		private void OnHourChanged(object sender, EventArgs e)
		{
		}

		protected virtual void OnEnable()
		{
		}

		private void Staff_AiComponentRemoved(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		private void UpdateTraits()
		{
		}

		private void Staff_AiComponentAdded(object sender, GameObjectX.GameObjectXEventArgs<AiComponent> e)
		{
		}

		protected void InvalidateVisual()
		{
		}

		private void UpdateSkills()
		{
		}

		protected void InvalidateWageText()
		{
		}
	}
}
