using System;
using Data.FeatureFlags;
using Data.Variables;
using Logic.Factory;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	[CreateAssetMenu(menuName = "UI/Toolbar/OperatorBarDatabaseCollection", fileName = "OperatorBarDatabaseCollection", order = 0)]
	public class OperatorBarDatabaseCollection : InitScriptableObject
	{
		[SerializeField]
		private FeatureFlags _featureFlags;

		[SerializeField]
		private ZenModeVariableSO _zenMode;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		[Space]
		[Header("Default")]
		[SerializeField]
		private OperatorBarDatabase _operatorBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _cosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _cosmeticBar2Database;

		[SerializeField]
		private OperatorBarDatabase _supportersEditionCosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _devBarDatabase;

		[Space]
		[SerializeField]
		private OperatorBarDatabase _demoOperatorBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _demoCosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _demoCosmeticBar2Database;

		[SerializeField]
		private OperatorBarDatabase _demoDevBarDatabase;

		[Space(20f)]
		[Header("Creative")]
		[SerializeField]
		private OperatorBarDatabase _creativeOperatorBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _creativeCosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _supportersEditionCreativeCosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _creativeDevBarDatabase;

		[Space]
		[SerializeField]
		private OperatorBarDatabase _creativeDemoOperatorBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _creativeDemoCosmeticBarDatabase;

		[SerializeField]
		private OperatorBarDatabase _creativeDemoDevBarDatabase;

		public OperatorBarDatabase OperatorBarData { get; private set; }

		public OperatorBarDatabase CosmeticsBarData { get; private set; }

		public OperatorBarDatabase CosmeticsBar2Data { get; private set; }

		public OperatorBarDatabase DevBarData { get; private set; }

		public event Action OnRefresh = delegate
		{
		};

		public override void Init()
		{
			RefreshObjectsList();
			SubscribeToZenModeChanged();
		}

		private void SubscribeToZenModeChanged()
		{
			_zenMode.ValueChanged -= OnZenModeChanged;
			if (Application.isPlaying)
			{
				_zenMode.ValueChanged += OnZenModeChanged;
			}
		}

		private void OnZenModeChanged(bool zenMode)
		{
			RefreshObjectsList();
		}

		private void RefreshObjectsList()
		{
			switch (_featureFlags.Current.OperatorsDatabase)
			{
			case FeatureFlagsData.EOperatorDatabase.Default:
				OperatorBarData = (_zenMode.Value ? _creativeOperatorBarDatabase : _operatorBarDatabase);
				CosmeticsBarData = ((!_integrationManagerLocator.Integration.IsSupportersEdition()) ? (_zenMode.Value ? _creativeCosmeticBarDatabase : _cosmeticBarDatabase) : (_zenMode.Value ? _supportersEditionCreativeCosmeticBarDatabase : _supportersEditionCosmeticBarDatabase));
				CosmeticsBar2Data = _cosmeticBar2Database;
				DevBarData = (_zenMode.Value ? _creativeDevBarDatabase : _devBarDatabase);
				break;
			case FeatureFlagsData.EOperatorDatabase.Demo:
				OperatorBarData = (_zenMode.Value ? _creativeDemoOperatorBarDatabase : _demoOperatorBarDatabase);
				CosmeticsBarData = (_zenMode.Value ? _creativeDemoCosmeticBarDatabase : _demoCosmeticBarDatabase);
				CosmeticsBar2Data = _demoCosmeticBar2Database;
				DevBarData = (_zenMode.Value ? _creativeDemoDevBarDatabase : _demoDevBarDatabase);
				break;
			}
			this.OnRefresh();
		}
	}
}
