using System.Globalization;
using CTS.BBT.AI;
using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class WorkerBasicInformationCanvas : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text nameText;

		[SerializeField]
		private TMP_Text levelText;

		[SerializeField]
		private TMP_Text salaryText;

		[SerializeField]
		private TMP_Text hireCostText;

		[SerializeField]
		private ObjectToggleByKey _visualToggle;

		[SerializeField]
		private PaletteData _textNormalColor;

		[SerializeField]
		private PaletteData _textDiscountColor;

		[SerializeField]
		private Image _backgroundImage;

		private static readonly StringKey _freeVisualKey = "Worker_Engage_Free";

		private static readonly StringKey _costVisualKey = "Worker_Engage_Cost";

		public Worker assingedWorker { get; private set; }

		private void Awake()
		{
			assingedWorker = GetComponentInParent<Worker>();
			assingedWorker.Spawned += UpdateInformations;
		}

		private void OnEnable()
		{
			InterimAgency.OnInterimHiringAlterationChanged += OnInterimHiringCostChanged;
		}

		private void OnDisable()
		{
			InterimAgency.OnInterimHiringAlterationChanged -= OnInterimHiringCostChanged;
		}

		private void Start()
		{
			assingedWorker.PowerFeatures.OnPowerAdded += UpdateInformations;
			assingedWorker.Level.LeveledUp += UpdateInformations;
		}

		private void Update()
		{
			base.transform.rotation = MonoSingleton<MainCamera>.Instance.transform.rotation;
		}

		private void OnInterimHiringCostChanged()
		{
			UpdateInformations();
		}

		public void UpdateInformations()
		{
			nameText.text = assingedWorker.agentFirstName;
			levelText.text = assingedWorker.Level.CurrentLevel.ToString();
			if (InterimAgency.IsWorkerSalaryFree)
			{
				salaryText.text = 0.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
			else
			{
				salaryText.text = assingedWorker.Salary.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
			}
			if ((float)InterimAgency.HiringMultiplier >= 0f)
			{
				_backgroundImage.color = _textNormalColor;
			}
			else
			{
				_backgroundImage.color = _textDiscountColor;
			}
			if (InterimAgency.GetWorkerCost(assingedWorker) > 0)
			{
				hireCostText.text = InterimAgency.GetWorkerCost(assingedWorker).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
				_visualToggle.Swap(_costVisualKey);
			}
			else
			{
				_visualToggle.Swap(_freeVisualKey);
			}
		}
	}
}
