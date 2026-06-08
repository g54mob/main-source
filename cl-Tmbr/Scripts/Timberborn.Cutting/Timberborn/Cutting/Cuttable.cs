using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.Common;
using Timberborn.EntitySystem;
using Timberborn.GoodStackSystem;
using Timberborn.Growing;
using Timberborn.NaturalResourcesLifecycle;
using Timberborn.WorldPersistence;
using Timberborn.Yielding;
using UnityEngine;

namespace Timberborn.Cutting
{
	public class Cuttable : BaseComponent, IAwakableComponent, IStartableComponent
	{
		private readonly EntityService _entityService;

		private LivingNaturalResource _livingNaturalResource;

		private BlockObject _blockObject;

		private GoodStack _goodStack;

		private Growable _growable;

		private CuttableSpec _cuttableSpec;

		private GameObject _leftoverModel;

		public Yielder Yielder { get; private set; }

		public bool RemoveOnCut => _cuttableSpec.RemoveOnCut;

		public YielderSpec YielderSpec => _cuttableSpec.Yielder;

		public event EventHandler WasCut;

		public Cuttable(EntityService entityService)
		{
			_entityService = entityService;
		}

		public void Awake()
		{
			_livingNaturalResource = GetComponent<LivingNaturalResource>();
			_blockObject = GetComponent<BlockObject>();
			_goodStack = GetComponent<GoodStack>();
			_growable = GetComponent<Growable>();
			_cuttableSpec = GetComponent<CuttableSpec>();
			Yielder = this.GetNamedComponent<Yielder>(YielderSpec.YielderComponentName);
			Yielder.YieldDecreased += delegate
			{
				Cut();
			};
			_growable.HasGrown += delegate
			{
				Yielder.Enable();
			};
			_leftoverModel = base.GameObject.FindChildIfNameNotEmpty(_cuttableSpec.LeftoverModelName);
		}

		public void Start()
		{
			if (_goodStack.Enabled && Yielder.IsYieldRemoved)
			{
				InitializeDisabledAction();
			}
		}

		public void ShowLeftoverModel()
		{
			if ((bool)_leftoverModel)
			{
				_leftoverModel.SetActive(value: true);
			}
		}

		public void HideLeftoverModel()
		{
			if ((bool)_leftoverModel)
			{
				_leftoverModel.SetActive(value: false);
			}
		}

		private void Cut()
		{
			EnableGoodStack();
			_livingNaturalResource.Die();
			InitializeDisabledAction();
			this.WasCut?.Invoke(this, EventArgs.Empty);
		}

		private void EnableGoodStack()
		{
			if (Yielder.IsYielding)
			{
				_goodStack.EnableGoodStack(Yielder.Yield);
				Yielder.RemoveRemainingYield();
			}
		}

		private void InitializeDisabledAction()
		{
			if (RemoveOnCut)
			{
				InitializeDisabledAction(delegate
				{
					_entityService.Delete(this);
				});
			}
			else
			{
				InitializeDisabledAction(MakeOverridable);
			}
		}

		private void InitializeDisabledAction(Action action)
		{
			if (_goodStack.Inventory.IsEmpty)
			{
				action();
				return;
			}
			_goodStack.GoodStackDisabled += delegate
			{
				action();
			};
		}

		private void MakeOverridable()
		{
			_blockObject.MakeOverridable();
		}
	}
}
